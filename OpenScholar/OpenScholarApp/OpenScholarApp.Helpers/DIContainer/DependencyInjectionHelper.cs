using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Helpers.DIContainer
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbCotext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OpenScholarAppDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
