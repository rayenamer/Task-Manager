using Microsoft.Extensions.DependencyInjection;
using gestion_taches.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestion_taches.Domain.models;

namespace gestion_taches.infra
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Project>, IGenericRepository<Project>>();
            services.AddTransient<IGenericRepository<Ressources>, IGenericRepository<Ressources>>();


        }
    }
}
