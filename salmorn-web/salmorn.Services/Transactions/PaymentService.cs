using salmorn.IServices.Transactions;
using System;
using System.Collections.Generic;
using System.Text;
using salmorn.Models.Logs;
using salmorn.Models.Transactions;
using salmorn.IServices.Commons;
using salmorn.Models.Configurations;
using Microsoft.Extensions.Options;

namespace salmorn.Services.Transactions
{
    public class PaymentService : IPaymentService
    {
        private DBContext db;
        private IFileUploadService fileService { get; }
        public PaymentService(DBContext db, IFileUploadService fileService, IOptions<GoogleCloudStorage> ggSetting)
        {
            this.fileService = this.fileService;
            this.db = db;
        }

        

        public int addPayment(PaymentNotification data)
        {
            this.db.PaymentNotifications.Add(data);
            this.db.SaveChanges();
            return -1;
        }

    }
}
