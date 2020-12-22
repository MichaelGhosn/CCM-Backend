using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CCM.Application.Reservation.Query.Get
{
    public class GetReservationByUserIdHandler: IRequestHandler<GetReservationByUserId, ResponseModel<GetReservationByUserIdResponseModel>>
    {
        private readonly ccmContext _context;

        public GetReservationByUserIdHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<GetReservationByUserIdResponseModel>> Handle(GetReservationByUserId request, CancellationToken cancellationToken)
        {

            bool userExists = _context.User.Any(user => user.Id == request.UserId);

            if (!userExists)
            {
                return new ResponseModel<GetReservationByUserIdResponseModel>()
                {
                    Success = false,
                    Description = "User id not available"
                };
            }

            var reservations = _context.Reservation
                .Include(reservation => reservation.Seat)
                .ThenInclude(seat => seat.Map).ThenInclude(map => map.Organisation)
                .Where(reservation => reservation.UserId == request.UserId)
                .Select( res => new GetReservationByUserIdModel()
                {
                    ReservationId = res.Id,
                    Date = res.Date,
                    StartHour = res.StartHour,
                    EndHour = res.EndHour,
                    SeatName = res.Seat.Name,
                    MapName = res.Seat.Map.Name,
                    OrganisationName = res.Seat.Map.Organisation.Name,
                    Link = res.Link,
                }).Skip(request.PageNumber * request.PageSize).Take(request.PageSize).ToList();


            int count = _context.Reservation
                .Where(reservation => reservation.UserId == request.UserId).Count();
            
            return new ResponseModel<GetReservationByUserIdResponseModel>()
            {
                Success = true,
                Data = new GetReservationByUserIdResponseModel()
                {
                    Reservations = reservations,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalItemCount = count
                },
                Description = "Successfully fetched user reservations"
            };
        }
    }
}