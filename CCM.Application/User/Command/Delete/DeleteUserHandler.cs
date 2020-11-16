using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.User.Command.Delete
{
    public class DeleteUserHandler: IRequestHandler<IDeleteUser, ResponseModel<DeleteUserResponseModel>>
    {
        private ccmContext _context;

        public DeleteUserHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteUserResponseModel>> Handle(IDeleteUser request, CancellationToken cancellationToken)
        {
            Domain.User user = _context.User.FirstOrDefault(user => user.Id == request.Id);

            if (user == null)
            {
                return new ResponseModel<DeleteUserResponseModel>()
                {
                    Success = false,
                    Description = "User does not exists"
                };
            }

            _context.User.Remove(user);
            _context.SaveChangesAsync();
            
           return new ResponseModel<DeleteUserResponseModel>()
           {
               Success = true,
               Description = "Successfully deleted user"
           };
        }
    }
}