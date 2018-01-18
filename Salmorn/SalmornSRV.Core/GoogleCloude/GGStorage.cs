using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalmornSRV.Core.GoogleCloude
{
    public class GGStorage : IGGStorage
    {
        private StorageClient _storage;
        private IConfiguration _connection;

        public GGStorage(IConfiguration configuration)
        {
            this._connection = configuration;
        }

        private StorageClient Storage
        {
            get
            {
                if(this._storage == null) this._storage = StorageClient.Create();
                return this._storage;
            }
        }

        private string ProjectId
        {
            get
            {
                return this._connection["GoogleCloudStorage:ProjectId"];
            }
        }

        private void createBucket(string bucketName)
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
