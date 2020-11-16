﻿using System;
using System.Reflection;
using CCM.Application.Day.Command.Add;
using CCM.Application.Day.Command.Delete;
using CCM.Application.Day.Command.Update;
using CCM.Application.Day.Query.GetAll;
using CCM.Application.Organisation.Command.Add;
using CCM.Application.Organisation.Command.Delete;
using CCM.Application.Organisation.Command.Update;
using CCM.Application.Organisation.Query.GetAll;
using CCM.Application.Role.Command.Add;
using CCM.Application.Role.Command.Delete;
using CCM.Application.Role.Command.Update;
using CCM.Application.Role.Query.GetAll;
using CCM.Application.User.Command.Add;
using CCM.Application.User.Command.Delete;
using CCM.Application.User.Command.Update;
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

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}