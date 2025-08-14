using Bargheto.Application.Common.Mapper;
using Bargheto.Application.Common.UnitOfWorkPattern;
using Bargheto.Infrastructure.UnitOfWorkPattern;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bargheto.Application.Common.Validation;
using FluentValidation;
using Bargheto.Application.Services.Interfaces;
using Bargheto.Application.Services.Implementations;

namespace Bargheto.IoC
{
    public class DependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            #region UnitOfWork

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Packages

            services.AddAutoMapper(conf=> conf.AddProfile<MapperProfile>());
            services.AddValidatorsFromAssembly(typeof(UserValidator).Assembly);

            #endregion

            #region Services

            services.AddScoped<IUserManagementServices, UserManagementServices>();

            #endregion
        }
    }
}
