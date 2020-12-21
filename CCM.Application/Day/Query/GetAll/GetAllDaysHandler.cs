using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Day.Query.GetAll
{
    public class GetAllDaysHandler: IRequestHandler<GetAllDays, ResponseModel<List<GetAllDaysResponseModel>>>
    {
        private readonly ccmContext _context;

        public GetAllDaysHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllDaysResponseModel>>> Handle(GetAllDays request, CancellationToken cancellationToken)
        {
            return new ResponseModel<List<GetAllDaysResponseModel>>()
            {
                Success = true,
                Data = _context.Day.Select(day => new GetAllDaysResponseModel()
                {
                    Id = day.Id,
                    Name = day.Name
                }).ToList(),
                Description = "Successfully fetched data"
            };
        }
    }
}