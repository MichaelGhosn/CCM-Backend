using System;
using System.Reflection;
using CCM.Application.Day.Command.Add;
using CCM.Application.Day.Command.Delete;
using CCM.Application.Day.Command.Update;
using CCM.Application.Day.Query.GetAll;
using CCM.Application.Map.Command.Add;
using CCM.Application.Map.Command.Delete;
using CCM.Application.Map.Command.Update;
using CCM.Application.Map.Query.GetAll;
using CCM.Application.OpeningTime.Command.Add;
using CCM.Application.Organisation.Command.Add;
using CCM.Application.Organisation.Command.Delete;
using CCM.Application.Organisation.Command.Update;
using CCM.Application.Organisation.Query.GetAll;
using CCM.Application.Reservation.Command.Add;
using CCM.Application.Role.Command.Add;
using CCM.Application.Role.Command.Delete;
using CCM.Application.Role.Command.Update;
using CCM.Application.Role.Query.GetAll;
using CCM.Application.Seat.Command.Add;
using CCM.Application.Seat.Command.Delete;
using CCM.Application.Seat.Query.GetAll;
using CCM.Application.User.Command.Add;
using CCM.Application.User.Command.Delete;
using CCM.Application.User.Command.Update;
using CCM.Application.User.Query.AuthenticateUser;
using CCM.Application.User.Query.GetAll;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace CCM.WebApi.Extensions
{
    public static class MediatRServices
    {
        internal static void AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IGetAllRoles).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IAddRole).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDeleteRole).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IUpdateRole).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(IGetAllOrganisations).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IAddOrganisation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDeleteOrganisation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IUpdateOrganisation).GetTypeInfo().Assembly);
            
            services.AddMediatR(typeof(IAddUser).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IGetAllUsers).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDeleteUser).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IUpdateUser).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(IGetAllDays).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IAddDay).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDeleteDay).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IUpdateDay).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(IAddMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IGetAllMapsByOrganisation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDeleteMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IUpdateMap).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(IAddSeatToMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IGetAllSeatsByMapId).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDeleteSeat).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(IAddReservation).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(IAddOpeningTimeToMap).GetTypeInfo().Assembly);
            
            
            
            services.AddMediatR(typeof(IAuthenticateUser).GetTypeInfo().Assembly);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}