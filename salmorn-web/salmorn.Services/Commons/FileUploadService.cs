using Microsoft.Extensions.Options;
using salmorn.IServices.Commons;
using salmorn.Models.Configurations;
using salmorn.Models.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace salmorn.Services.Commons
{
    public class FileUploadService : IFileUploadService
    {
        public FileUploadService(IOptions<GoogleCloudStorage> ggSetting, IGGStorageService ggService, DBContext db)
        {
            this.db = db;
            this.ggService = ggService;
            this.ggcSetting = ggSetting.Value;
        }
        private GoogleCloudStorage ggcSetting { get; }
        private IGGStorageService ggService { get; }
        private DBContext db { get; }

        public FileUpload upload(Stream file, FileUpload fileData, string bucketName, ref string errorMessage)
        {
            try
            {
                string fName = fileData.fileName;
                string fPath = genFilePathRandomFileName(bucketName, ref fName);

                fileData.fileName = fName;

                if (this.upload(file, fName, bucketName, ref errorMessage))
                {
                    fileData = this.addFile(fileData);
                    fileData.fileName = GenerateHTTPFilePath(fileData.fileName, bucketName);
                }
                return fileData;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }


        }

        private bool upload(Stream file, string fileName, string bucketName, ref string errorMessage)
        {
            try
            {
                this.ggService.Upload(file, bucketName, fileName);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public string GenerateHTTPFilePath(string fileName, string bucketName)
        {
            return string.Format("{0}/{1}/{2}", this.ggcSetting.RootUrl
                , bucketName, fileName);
        }

        private string genFilePathRandomFileName(string buketName, ref string fileName)
        {
            string fPath = string.Empty;
            do
            {
                fileName = this.RandomFileName(fileName);
                fPath = genPhysicalUploadFilePath(fileName, buketName);
            } while (this.isExist(fileName));

            return fPath;
        }
        private string genPhysicalUploadFilePath(string fileName, string buketName)
        {
            string fPath = System.IO.Path.Combine(this.ggcSetting.RootUrl
                , buketName);
            return System.IO.Path.Combine(fPath, fileName);
        }

        #region Database

        private bool isExist(string fileName)
        {
            return this.getFileByName(fileName) != null;
        }

        private FileUpload addFile(FileUpload file)
        {
            file.uploadDate = DateTime.Now;
            db.FileUploads.Add(file);
            db.SaveChanges();
            return file;
        }

        private FileUpload getFileByName(string fileName) {
            return this.db.FileUploads.SingleOrDefault(m => m.fileName == fileName);
        }

        #endregion

        #region Random file name

        private string RandomFileName(string fileName)
        {
            return string.Format("{0}{1}", RandomString(30), Path.GetExtension(fileName));
        }

        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion
    }
}
