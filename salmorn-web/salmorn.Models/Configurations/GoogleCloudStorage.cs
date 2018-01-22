using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.Models.Configurations
{
    public class GoogleCloudStorage
    {
        public string AcountAPIKeyPath { get; set; }
        public string ProjectId { get; set; }
        public string RootUrl { get; set; }
        public string Bucket_Product_Large { get; set; }
        public string Bucket_Product_Small { get; set; }
        public string Bucket_Product_Payment { get; set; }
    }
}
