using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Map.Command.Add
{
    public class AddMapHandler: IRequestHandler<AddMap, ResponseModel<AddMapResponseModel>>
    {
        private readonly ccmContext _context;

        public AddMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddMapResponseModel>> Handle(AddMap request, CancellationToken cancellationToken)
        {
            bool doesOrganisationExists =
                _context.Organisation.Any(organisation => organisation.Id == request.OrganisationId);

            if (!doesOrganisationExists)
            {
                return new ResponseModel<AddMapResponseModel>()
                {
                    Success = false,
                    Description = "Organisation does not exists"
                };
            }

            bool doesMapNameExistsInOrganisation = _context.Map.Any(map =>
                map.Name.ToLower() == request.Name.ToLower() && map.OrganisationId == request.OrganisationId);

            if (doesMapNameExistsInOrganisation)
            {
                return new ResponseModel<AddMapResponseModel>()
                {
                    Success = false,
                    Description = "Map name already exists for this organisation"
                };
            }
            
            
            var fileName = (request.Name + "_" + request.OrganisationId + "_" + Path.GetFileName(request.Image.FileName)).Replace(" ", "");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\maps", fileName);
            
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.Image.CopyToAsync(fileStream);
            }

            Domain.Map newMap = new Domain.Map()
            {
                Name = request.Name,
                ImagePath = fileName,
                Capacity = request.Capacity,
                AuthorizedCapacity = request.AuthorizedCapacity,
                OrganisationId = request.OrganisationId
            };
         
            _context.Map.Add(newMap);
            await _context.SaveChangesAsync();
            
            
            return new ResponseModel<AddMapResponseModel>()
            {
                Success = true,
                Data = new AddMapResponseModel()
                {
                    MapId = newMap.Id
                },
                Description = "Added map successfully"
            };
        }
    }
}