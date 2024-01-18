﻿using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
             services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
            });
            services.AddQuartzHostedService();
        }

    }
}
