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
using CCM.Application.OpeningTime.Command.Update;
using CCM.Application.OpeningTime.Query.GetAllByOrganisation;
using CCM.Application.Organisation.Command.Add;
using CCM.Application.Organisation.Command.Delete;
using CCM.Application.Organisation.Command.Update;
using CCM.Application.Organisation.Query.GetAll;
using CCM.Application.Reservation.Command.Add;
using CCM.Application.Reservation.Command.Delete;
using CCM.Application.Reservation.Query.Get;
using CCM.Application.Role.Command.Add;
using CCM.Application.Role.Command.Delete;
using CCM.Application.Role.Command.Update;
using CCM.Application.Role.Query.GetAll;
using CCM.Application.Seat.Command.Add;
using CCM.Application.Seat.Command.AddMultiple;
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
            services.AddMediatR(typeof(GetAllRoles).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddRole).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteRole).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateRole).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetAllOrganisations).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddOrganisation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteOrganisation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateOrganisation).GetTypeInfo().Assembly);
            
            services.AddMediatR(typeof(AddUser).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllUsers).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteUser).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateUser).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(GetAllDays).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddDay).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteDay).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateDay).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(AddMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllMapsByOrganisation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateMap).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(AddSeatToMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddMultipleSeatToMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllSeatsByMapId).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteSeat).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(AddReservation).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetReservationByUserId).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteReservation).GetTypeInfo().Assembly);
            
            
            services.AddMediatR(typeof(AddOpeningTimeToMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateOpeningTimeToMap).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllOpeningTimeByOrganisation).GetTypeInfo().Assembly);
            
            
            
            services.AddMediatR(typeof(AuthenticateUser).GetTypeInfo().Assembly);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}