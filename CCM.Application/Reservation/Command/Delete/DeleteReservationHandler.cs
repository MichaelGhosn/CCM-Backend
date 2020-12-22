using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using CCM.Infrastructure.Calendar;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CCM.Application.Reservation.Command.Delete
{
    public class DeleteReservationHandler: IRequestHandler<DeleteReservation, ResponseModel<DeleteReservationResponseModel>>
    {
        private readonly ccmContext _context;
        private ICalendar _calendar;

        public DeleteReservationHandler(ccmContext context, ICalendar calendar)
        {
            _context = context;
            _calendar = calendar;
        }
        
        public async Task<ResponseModel<DeleteReservationResponseModel>> Handle(DeleteReservation request, CancellationToken cancellationToken)
        {
            var reservation = _context.Reservation
                .Include(resv => resv.User)
                .Where(reservation => reservation.Id == request.ReservationId)
                .FirstOrDefault();

            if (reservation == null)
            {
                return new ResponseModel<DeleteReservationResponseModel>()
                {
                    Success = false,
                    Description = "Reservation not found"
                }; 
            }


             _calendar.DeleteEventFromCalendar(reservation.User.Email, reservation.EventId);

            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();


            return new ResponseModel<DeleteReservationResponseModel>()
            {
                Success = true,
                Description = "Deleted reservation from calendar"
            }; 
        }
    }
}