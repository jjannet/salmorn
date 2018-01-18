using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class FileDAO : BaseDAO
    {
        public FileDAO() : base() { }

        public L_FileUpload getFile(int id)
        {
            return context.L_FileUpload.SingleOrDefault(m => m.id == id);
        }

        public L_FileUpload getFileByName(string fileName)
        {
            return context.L_FileUpload.SingleOrDefault(m => m.fileName == fileName);
        }

        public IEnumerable<L_FileUpload> getFiles()
        {
            return context.L_FileUpload;//.Where(m => m.type == type).ToList();
        }

        public L_FileUpload addFile(L_FileUpload item)
        {
            L_FileUpload data = new L_FileUpload();

            data.fileName = item.fileName;
            data.ipAddress = item.ipAddress;
            data.macAddress = item.macAddress;
            data.type = item.type;
            data.uploadDate = DateTime.Now;
            data.userId = item.userId;

            context.L_FileUpload.Add(data);
            context.SaveChanges();

            return data;
        }

        public void deleteFile(int id)
        {
            var data = context.L_FileUpload.SingleOrDefault(m => m.id == id);
            if (data != null)
            {
                context.L_FileUpload.Remove(data);
                context.SaveChanges();
            }
        }

        public void deleteFile(L_FileUpload item)
        {
            context.L_FileUpload.Remove(item);
            context.SaveChanges();
        }
    }
}
