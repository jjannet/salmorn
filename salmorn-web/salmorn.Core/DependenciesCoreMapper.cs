using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<IGGStorageService, GGStorageService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IEmailSender, AuthMessageSender>();

        }
    }
}
