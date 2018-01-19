using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.Core.Utils
{
    public interface IFileUploadProcess
    {
        string GenerateHTTPFilePath(string fileName);
    }
}
