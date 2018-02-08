using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace salmorn_admin.Processes
{
    public class GGStorage
    {
        private StorageClient _storage;


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
                return JSettings.GoogleCloudStorage.ProjectId;
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