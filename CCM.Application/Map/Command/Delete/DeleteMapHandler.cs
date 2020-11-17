using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Map.Command.Delete
{
    public class DeleteMapHandler: IRequestHandler<IDeleteMap, ResponseModel<DeleteMapResponseModel>>
    {
        private ccmContext _context;

        public DeleteMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteMapResponseModel>> Handle(IDeleteMap request, CancellationToken cancellationToken)
        {
            Domain.Map map = _context.Map.FirstOrDefault(m => m.Id == request.MapId);

            if (map == null)
            {
                return new ResponseModel<DeleteMapResponseModel>()
                {
                    Success = false,
                    Description = "Map does not exist"
                };
            }

            _context.Map.Remove(map);
            _context.SaveChangesAsync();
            
            return new ResponseModel<DeleteMapResponseModel>()
            {
                Success = true,
                Description = "Map has been deleted"
            };
        }
    }
}