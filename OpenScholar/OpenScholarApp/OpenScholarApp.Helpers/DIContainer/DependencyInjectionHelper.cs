using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenScholarApp.Data.Context;
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
            services.AddDbContext<OpenScholarDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
