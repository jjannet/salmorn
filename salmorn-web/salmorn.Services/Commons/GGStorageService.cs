using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using salmorn.IServices.Commons;
using salmorn.Models.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace salmorn.Services.Commons
{
    public class GGStorageService : IGGStorageService
    {
        private StorageClient _storage;
        public IConfiguration Configuration { get; }

        public GGStorageService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        private StorageClient Storage
        {
            get
            {
                if (this._storage == null) this._storage = StorageClient.Create();
                return this._storage;
            }
        }

        private string ProjectId
        {
            get
            {
                return this.Configuration["GoogleCloudStorage:ProjectId"];
            }
        }

        public void createBucket(string bucketName)
        {
            if (!BucketIsExist(bucketName))
                Storage.CreateBucket(ProjectId, bucketName);
        }

        private bool BucketIsExist(string bucketName)
        {
            try
            {
                var chk = Storage.GetBucket(bucketName);
                return chk != null;
            }
            catch
            {
                return false;
            }
        }

        public void Upload(Stream file, string bucketName, string fileName)
        {
            Storage.UploadObject(bucketName, fileName, null, file);
        }

        public void Delete(string bucketName, string fileName)
        {
            Storage.DeleteObject(bucketName, fileName);
        }
    }
}
