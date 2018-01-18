using Microsoft.AspNetCore.Http;
using SalmornSRV.Models.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.IService.Log
{
    public interface IFileUploadService
    {
        FileUpload Get(long id);
        IEnumerable<FileUpload> Gets();
        FileUpload Put(FileUpload file);
        void Delete(long id);
        string RandomFileName(string fileName);
        bool isExist(string fileName);
    }
}
