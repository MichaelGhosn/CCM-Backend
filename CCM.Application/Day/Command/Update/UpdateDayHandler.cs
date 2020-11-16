using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Day.Command.Update
{
    public class UpdateDayHandler: IRequestHandler<IUpdateDay, ResponseModel<UpdateDayResponseModel>>
    {
        private ccmContext _context;

        public UpdateDayHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateDayResponseModel>> Handle(IUpdateDay request, CancellationToken cancellationToken)
        {
            Domain.Day day = _context.Day.FirstOrDefault(d => d.Id == request.Id);

            if (day == null)
            {
                return new ResponseModel<UpdateDayResponseModel>()
                {
                    Success = false,
                    Description = "Day does not exists"
                };
            }

            day.Name = request.Name;

            _context.Day.Update(day);
            _context.SaveChangesAsync();
            
            
            return new ResponseModel<UpdateDayResponseModel>()
            {
                Success = true,
                Description = "Successfully updated day"
            };
        }
    }
}