using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.BO
{
    public class FileBO
    {
        private FileDAO dao;
        public FileBO()
        {
            dao = new FileDAO();
        }

        public bool isExist(string fileName)
        {
            return dao.getFileByName(fileName) != null;
        }

        public FileUpload getFile(int id)
        {
            return ConvertToScreenModel.Logs.fileUpload(dao.getFile(id));
        }
        public FileUpload addFile(FileUpload item)
        {
            var data = dao.addFile(new L_FileUpload()
            {
                fileName = item.fileName,
                ipAddress = item.ipAddress,
                macAddress = item.macAddress,
                type = item.type,
                uploadDate = item.uploadDate,
                userId = item.userId
            });

            return ConvertToScreenModel.Logs.fileUpload(data);
        }
        public void deleteFile(int id)
        {
            dao.deleteFile(id);
        }
        public void deleteFile(FileUpload item)
        {
            dao.deleteFile(new L_FileUpload()
            {
                id = item.id,
                fileName = item.fileName,
                ipAddress = item.ipAddress,
                macAddress = item.macAddress,
                type = item.type,
                uploadDate = item.uploadDate,
                userId = item.userId
            });
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
