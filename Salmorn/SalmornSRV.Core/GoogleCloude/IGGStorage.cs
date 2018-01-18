using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalmornSRV.Core.GoogleCloude
{
    public interface IGGStorage
    {
        void Upload(Stream file, string bucketName, string fileName);
        void Delete(string bucketName, string fileName);
    }
}
