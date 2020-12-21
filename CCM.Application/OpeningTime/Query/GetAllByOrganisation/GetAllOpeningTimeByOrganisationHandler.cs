using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CCM.Application.OpeningTime.Query.GetAllByOrganisation
{
    public class GetAllOpeningTimeByOrganisationHandler: IRequestHandler<GetAllOpeningTimeByOrganisation, ResponseModel<List<GetAllOpeningTimeByOrganisationResponseModel>>>
    {
        private readonly ccmContext _context;

        public GetAllOpeningTimeByOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        
        public async Task<ResponseModel<List<GetAllOpeningTimeByOrganisationResponseModel>>> Handle(GetAllOpeningTimeByOrganisation request, CancellationToken cancellationToken)
        {
            bool mapDoesExists = _context.Map.Any(map => map.Id == request.MapId);

            if (!mapDoesExists)
            {
                return new ResponseModel<List<GetAllOpeningTimeByOrganisationResponseModel>>()
                {
                    Success = false,
                    Description = "Invalid map"
                };
            }

            var openingTimes = _context.Openingtime
                .Include(ot => ot.Day)
                .Where(ot => ot.MapId == request.MapId)
                .Select(ot => new GetAllOpeningTimeByOrganisationResponseModel()
                {
                    Day = ot.Day.Name,
                    Opening = ot.OpeningHour,
                    Closing = ot.ClosingHour
                }).ToList();
            
            return new ResponseModel<List<GetAllOpeningTimeByOrganisationResponseModel>>()
            {
                Success = true,
                Data = openingTimes,
                Description = "Successfully fetched opening times of map"
            };
        }
    }
}