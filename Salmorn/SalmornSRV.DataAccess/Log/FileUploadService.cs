using SalmornSRV.IService.Log;
using System;
using System.Linq;
using SalmornSRV.Models.Log;
using System.IO;
using System.Collections.Generic;

namespace SalmornSRV.Service.Log
{
    public class FileUploadService : IFileUploadService
    {
        private DBContext db;

        public FileUploadService(DBContext db)
        {
            this.db = db;
        }

        public void Delete(long id)
        {
            var item = this.db.FileUploads.Where(m => m.id == id).FirstOrDefault();
            if (item != null)
            {
                this.db.Remove(item);
                this.db.SaveChanges();
            }
        }

        public FileUpload Get(long id)
        {
            return this.db.FileUploads.Where(m => m.id == id).FirstOrDefault();
        }

        public IEnumerable<FileUpload> Gets()
        {
            return this.db.FileUploads;
        }

        public bool isExist(string fileName)
        {
            return this.db.FileUploads.Where(m => m.fileName == fileName).Count() > 0;
        }

        public FileUpload Put(FileUpload file)
        {
            file.uploadDate = DateTime.Now;
            this.db.FileUploads.Add(file);
            this.db.SaveChanges();
            return file;
        }

        public string RandomFileName(string fileName)
        {
            return string.Format("{0}{1}", RandomString(30), Path.GetExtension(fileName));
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
