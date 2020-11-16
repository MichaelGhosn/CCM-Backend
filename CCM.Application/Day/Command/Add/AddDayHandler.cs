using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Day.Command.Add
{
    public class AddDayHandler: IRequestHandler<IAddDay, ResponseModel<AddDayResponseModel>>
    {
        private ccmContext _context;

        public AddDayHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddDayResponseModel>> Handle(IAddDay request, CancellationToken cancellationToken)
        {
            bool doesExists = _context.Day.Any(day => day.Name.ToLower() == request.Name.ToLower());

            if (doesExists)
            {
                return new ResponseModel<AddDayResponseModel>()
                {
                    Success = false,
                    Description = "Day already exists"
                };
            }

            _context.Day.Add(new Domain.Day()
            {
                Name = request.Name
            });

            _context.SaveChangesAsync();
            
            return new ResponseModel<AddDayResponseModel>()
            {
                Success = true,
                Description = "Successfully added day"
            };
            
        }
    }
}