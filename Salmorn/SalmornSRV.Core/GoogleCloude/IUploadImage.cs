using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Core.GoogleCloude
{
    public interface IUploadImage
    {

        bool Upload(IFormFile file, string fileName, ref string errorMessage);
        bool Delete(string fileName);

    }
}
