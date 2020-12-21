using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Day.Command.Delete
{
    public class DeleteDayHandler: IRequestHandler<DeleteDay, ResponseModel<DeleteDayResponseModel>>
    {
        private readonly ccmContext _context;

        public DeleteDayHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteDayResponseModel>> Handle(DeleteDay request, CancellationToken cancellationToken)
        {
            Domain.Day day = _context.Day.FirstOrDefault(d => d.Id == request.Id);

            if (day == null)
            {
                return new ResponseModel<DeleteDayResponseModel>()
                {
                    Success = false,
                    Description = "Day does not exists"
                };
            }

            _context.Day.Remove(day);
            await _context.SaveChangesAsync();
            
            return new ResponseModel<DeleteDayResponseModel>()
            {
                Success = true,
                Description = "Successfully deleted day"
            };
            
        }
    }
}