using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace salmorn_admin
{
    public static class JSettings
    {
        public static class GoogleCloudStorage
        {
            public static string RootUrl
            {
                get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:RootUrl"]; }
            }
            public static string AcountAPIKeyPath
            {
                get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:AcountAPIKeyPath"]; }
            }
            public static string ProjectId
            {
                get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:ProjectId"]; }
            }

            public static string productImageFolder
            {
                get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:productImageFolder"]; }
            }

            public static class Bucket
            {
                public static string Root
                {
                    get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:Bucket:Root"];  }
                }
                public static string Large
                {
                    get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:Bucket:Large"]; }
                }
                public static string Medium
                {
                    get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:Bucket:Medium"]; }
                }
                public static string Small
                {
                    get { return WebConfigurationManager.AppSettings["GoogleCloudStorage:Bucket:Small"]; }
                }
            }

            public static class Size
            {
                public static int Medium
                {
                    get { return int.Parse(WebConfigurationManager.AppSettings["GoogleCloudStorage:Size:Medium"]); }
                }
                public static int Small
                {
                    get { return int.Parse(WebConfigurationManager.AppSettings["GoogleCloudStorage:Size:Small"]); }
                }
            }
        }
    }
}
