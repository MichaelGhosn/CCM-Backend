using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Map.Command.Update
{
    public class UpdateMapHandler: IRequestHandler<IUpdateMap, ResponseModel<UpdateMapResponseModel>>
    {
        private ccmContext _context;

        public UpdateMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateMapResponseModel>> Handle(IUpdateMap request, CancellationToken cancellationToken)
        {
            Domain.Map map = _context.Map.FirstOrDefault(m => m.Id == request.MapId);

            if (map == null)
            {
                return new ResponseModel<UpdateMapResponseModel>()
                {
                    Success = false,
                    Description = "Map does not exist"
                };
            }


            if (request.Image != null && request.Image.Length > 0)
            {
                var fileName = (request.Name + "_" + map.OrganisationId + "_" + Path.GetFileName(request.Image.FileName)).Replace(" ", "");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\maps", fileName);
            
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(fileStream);
                }

                map.ImagePath = fileName;
            }

            map.Name = String.IsNullOrEmpty(request.Name) ? map.Name : request.Name;
            map.Capacity = request.Capacity == -1 ? map.Capacity : request.Capacity;
            map.AuthorizedCapacity =
                request.AuthorizedCapacity == -1 ? map.AuthorizedCapacity : request.AuthorizedCapacity;

            _context.Map.Update(map);

            _context.SaveChangesAsync();
     
            
            return new ResponseModel<UpdateMapResponseModel>()
            {
                Success = true,
                Description = "Map updated successfully"
            };
        }
    }
}