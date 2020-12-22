using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Common.Extensions;
using CCM.Domain;
using CCM.Infrastructure.Calendar;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CCM.Application.Reservation.Command.Add
{
    public class AddReservationHandler: IRequestHandler<AddReservation, ResponseModel<AddEventToReservationResponseModelModel>>
    {
        private readonly ccmContext _context;
        private ICalendar _calendar;
        
        public AddReservationHandler(ccmContext context, ICalendar calendar)
        {
            _context = context;
            _calendar = calendar;
        }
        
        public async Task<ResponseModel<AddEventToReservationResponseModelModel>> Handle(AddReservation request, CancellationToken cancellationToken)
        {
            bool doesUserExists = _context.User.Any(user => user.Id == request.UserId);
            
            if (!doesUserExists)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "No user found"
                };
            }
            
            bool doesSeatExists = _context.Seat.Any(seat => seat.Id == request.SeatId);

            if (!doesSeatExists)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "No seat found"
                };
            }

            
            // int mapId = _context.Seat.Where(seat => seat.Id == request.SeatId).Select(seat => seat.MapId).FirstOrDefault();
            // int dayId = _context.Day.Where(day => day.Name == request.ReservationDate.DayOfWeek.ToString())
            //     .Select(day => day.Id).FirstOrDefault();


            Openingtime openingtime = _context.Openingtime
                .Where(ot => 
                    ot.Day.Name == request.ReservationDate.DayOfWeek.ToString()
                    && ot.MapId == ot.Map.Seat.Where(seat => seat.Id == request.SeatId && seat.MapId == ot.MapId).Select(seat =>  seat.MapId).FirstOrDefault() )
                .FirstOrDefault();

            if (openingtime == null)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "No opening times for chosen date"
                };
            }


            DateTime openingHour = DateTime.Parse(openingtime.OpeningHour);
            DateTime closingHour = DateTime.Parse(openingtime.ClosingHour);
            

            if (request.StartHour >= request.EndHour)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "Meeting has to start before ending"
                
                };
            }
            
            if (request.StartHour.Hour < openingHour.Hour
                || request.StartHour.Hour >= closingHour.Hour 
                || request.EndHour.Hour >= closingHour.Hour 
                || request.EndHour.Hour < openingHour.Hour)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "Time chosen outside of opening time"
                
                };
            }



            int mapTotalCapacity =  _context.Seat.Include(seat => seat.Map).Where(seat => seat.Id == request.SeatId)
                .Select(seat => seat.Map.Capacity * (seat.Map.AuthorizedCapacity / 100)).FirstOrDefault();


            var  alreadyBookedReservationsInThatTime = _context.Reservation
                .Include(reservation => reservation.Seat).ThenInclude(seat => seat.Map)
                .Where(reservation => reservation.Date.Value == request.ReservationDate.Date); //  reservation.SeatId == request.SeatId &&


            int alreadyBookedSeatsDuringThatTime = 0;
            bool chosenSeatAlreadyBooked = false;
            foreach (var reservation in alreadyBookedReservationsInThatTime)
            {
                if (request.StartHour.ToString("HH:mm:ss").Between(DateTime.Parse(reservation.StartHour).ToString("HH:mm:ss"),DateTime.Parse(reservation.EndHour).ToString("HH:mm:ss"))
                    || request.EndHour.ToString("HH:mm:ss").Between(DateTime.Parse(reservation.StartHour).ToString("HH:mm:ss"),DateTime.Parse(reservation.EndHour).ToString("HH:mm:ss"))
                    || (request.StartHour.ToString("HH:mm:ss").CompareTo(DateTime.Parse(reservation.StartHour).ToString("HH:mm:ss")) < 0 && request.EndHour.ToString("HH:mm:ss").CompareTo(DateTime.Parse(reservation.EndHour).ToString("HH:mm:ss")) >=0 ))
                {                      
                   alreadyBookedSeatsDuringThatTime++;
                   
                   if (request.SeatId == reservation.SeatId)
                   {
                       chosenSeatAlreadyBooked = true;
                   }
                }
            }
            if (alreadyBookedSeatsDuringThatTime >= mapTotalCapacity)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "Couldn't reserve, no places left during that time"
                };
            }

            if (chosenSeatAlreadyBooked)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "Couldn't reserve, chosen seat already booked during that time"
                };
            }

          
            
            
            
            String userIdentifier = _context.User.Where(user => user.Id == request.UserId).Select(user => user.Email).FirstOrDefault();
            var location = _context.Seat.Include(seat => seat.Map).ThenInclude(map => map.Organisation)
                .Where(seat => seat.Id == request.SeatId)
                .FirstOrDefault();
            
            var calendarData = _calendar.AddEventToCalendar(new AddUpdateEventToCalendarRequestModel()
            {
                userUniqueIdentifier = userIdentifier,
                location = location.Name + " | " + location.Map.Name + " | " + location.Map.Organisation.Name,
                summary = "Seat reservation",
                Description = "You have booked you place at the specific location with specific hours",
                startTime = request.StartHour,
                endTime = request.EndHour
            });

            if (calendarData == null)
            {
                return new ResponseModel<AddEventToReservationResponseModelModel>()
                {
                    Success = false,
                    Description = "Some error occured while connecting to your calendar"
                };
            }

            _context.Reservation.Add(new Domain.Reservation()
            {
                Date = request.ReservationDate,
                StartHour = request.StartHour.ToString("HH:mm:ss"),
                EndHour = request.EndHour.ToString("HH:mm:ss"),
                SeatId = request.SeatId,
                UserId = request.UserId,
                Link = calendarData.Link,
                EventId = calendarData.EventId
            });

            await _context.SaveChangesAsync();


       
            return new ResponseModel<AddEventToReservationResponseModelModel>()
            {
                Success = true,
                Data = new AddEventToReservationResponseModelModel()
                {
                    Link = calendarData.Link,
                    EventId = calendarData.EventId
                },
                Description = "Reservation was successful , " + (alreadyBookedSeatsDuringThatTime + 1) + " booked of " + mapTotalCapacity + " available during that time"
                
            };
            
        }
        
   
    }
}