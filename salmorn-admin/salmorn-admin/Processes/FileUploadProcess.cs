using salmorn_admin.BO;
using salmorn_admin.Models.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace salmorn_admin.Processes
{
    public class FileUploadProcess
    {
        private GGStorage gg;
        public FileUploadProcess()
        {
            gg = new GGStorage();
        }

        public FileUpload upload(Stream file, string fileName, string type, int userId, string ipAddress, ref string errorMessage)
        {
            try
            {
                FileBO bo = new FileBO();
                string fName = fileName;
                string fPath = genFilePathRandomFileName(ref fName);

                var f = new FileUpload()
                {
                    fileName = fName,
                    ipAddress = ipAddress,
                    type = type,
                    userId = userId,
                    uploadDate = new DateTime()
                };

                if (this.upload(file, fName, ref errorMessage))
                {
                    f = bo.addFile(f);
                    f.fileName = GenerateHTTPFilePath(f.fileName);
                }
                return f;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }

            
        }

        private bool upload(Stream file, string fileName, ref string errorMessage)
        {
            try
            {
                this.gg.Upload(file, JSettings.GoogleCloudStorage.Bucket.Root, fileName);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public string GenerateHTTPFilePath(string fileName)
        {
            return string.Format("{0}/{1}/{2}", JSettings.GoogleCloudStorage.RootUrl
                , JSettings.GoogleCloudStorage.Bucket.Root, fileName);
        }

        private string genFilePathRandomFileName(ref string fileName)
        {
            string fPath = string.Empty;
            FileBO bo = new FileBO();
            do
            {
                fileName = bo.RandomFileName(fileName);
                fPath = genPhysicalUploadFilePath(fileName);
            } while (bo.isExist(fileName));

            return fPath;
        }
        private string genPhysicalUploadFilePath(string fileName)
        {
            string fPath = System.IO.Path.Combine(JSettings.GoogleCloudStorage.RootUrl
                , JSettings.GoogleCloudStorage.productImageFolder);
            return System.IO.Path.Combine(fPath, fileName);
        }
    }
}