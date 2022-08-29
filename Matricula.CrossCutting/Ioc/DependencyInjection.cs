using Matricula.Application.Interfaces;
using Matricula.Application.Mappings;
using Matricula.Application.Services;
using Matricula.Domain.Interfaces;
using Matricula.Domain.Interfaces.Service;
using Matricula.Domain.Validation;
using Matricula.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<NotificationContext>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IMatriculaAlunoService, MatriculaAlunoService>();
            services.AddScoped<IProcessImportService, ProcessImportService>();
            
            //Definido como singleton, pois a intenção é que se mantenha o mesmo objeto durante o ciclo de vida.
            services.AddSingleton<IConfiguracaoSistemaService, ConfiguracaoSistemaService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
