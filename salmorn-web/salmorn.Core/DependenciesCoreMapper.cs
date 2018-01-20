using Microsoft.Extensions.DependencyInjection;
using salmorn.Core.GGClouds;
using salmorn.Core.Utils;
using salmorn.IServices.Commons;
using salmorn.Services.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.Core
{
    public static class DependenciesCoreMapper
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IGGStorage, GGStorage>();
            services.AddTransient<IFileUploadProcess, FileUploadProcess>();
            services.AddTransient<IEmailSender, AuthMessageSender>();

        }
    }
}
