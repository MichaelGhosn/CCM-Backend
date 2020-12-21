using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Day.Command.Update
{
    public class UpdateDayHandler: IRequestHandler<UpdateDay, ResponseModel<UpdateDayResponseModel>>
    {
        private readonly ccmContext _context;

        public UpdateDayHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateDayResponseModel>> Handle(UpdateDay request, CancellationToken cancellationToken)
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
            await _context.SaveChangesAsync();
            
            
            return new ResponseModel<UpdateDayResponseModel>()
            {
                Success = true,
                Description = "Successfully updated day"
            };
        }
    }
}