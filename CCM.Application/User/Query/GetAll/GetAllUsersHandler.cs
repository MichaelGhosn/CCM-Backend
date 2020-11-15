using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CCM.Application.User.Query.GetAll
{
    public class GetAllUsersHandler: IRequestHandler<IGetAllUsers, ResponseModel<List<GetAllUsersResponseModel>>>
    {
        private ccmContext _context;

        public GetAllUsersHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllUsersResponseModel>>> Handle(IGetAllUsers request, CancellationToken cancellationToken)
        {
           return new ResponseModel<List<GetAllUsersResponseModel>>()
           {
               Success = true,
               Data = _context.User
                   .Include(user => user.Role)
                   .Include(user => user.Organisation)
                   .Select(user => new GetAllUsersResponseModel()
                   {
                       Id = user.Id,
                       Email = user.Email,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Organisation = new UserOrganisationResponseModel()
                       {
                           Id = user.Organisation.Id,
                           Name = user.Organisation.Name
                       },
                       Role = new UserRoleResponseModel()
                       {
                           Id = user.Role.Id,
                           Name = user.Role.Name
                       }
                   }).ToList()
           };
        }
    }
}