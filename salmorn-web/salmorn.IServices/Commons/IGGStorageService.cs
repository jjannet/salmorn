using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace salmorn.IServices.Commons
{
    public interface IGGStorageService
    {
        void createBucket(string bucketName);
        void Upload(Stream file, string bucketName, string fileName);
        void Delete(string bucketName, string fileName);
    }
}
