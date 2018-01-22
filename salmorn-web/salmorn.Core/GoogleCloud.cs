using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using salmorn.Models.Configurations;
using salmorn.Services.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.Core
{
    public static class GoogleCloud
    {
        public static void AddGoogleCloudAPI(this IServiceCollection services, IConfiguration Configuration)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Configuration["GoogleCloudStorage:AcountAPIKeyPath"]);
            GGStorageService gg = new GGStorageService(Configuration);
            gg.createBucket(Configuration["GoogleCloudStorage:Bucket_Product_Large"]);
            gg.createBucket(Configuration["GoogleCloudStorage:Bucket_Product_Small"]);
            gg.createBucket(Configuration["GoogleCloudStorage:Bucket_Product_Payment"]);
        }
    }
}
