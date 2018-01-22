using salmorn.Models.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace salmorn.IServices.Commons
{
    public interface IFileUploadService
    {
        FileUpload upload(Stream file, FileUpload fileData, string bucketName, ref string errorMessage);
        string GenerateHTTPFilePath(string fileName, string bucketName);
    }
}
