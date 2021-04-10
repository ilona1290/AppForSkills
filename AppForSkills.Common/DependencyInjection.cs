﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}