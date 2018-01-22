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
        private IFileUploadService fileService { get; }
        public PaymentService(IFileUploadService fileService, IOptions<GoogleCloudStorage> ggSetting)
        {
            this.fileService = this.fileService;
        }

        

        public int addPayment(Order data)
        {
            throw new NotImplementedException();
        }

    }
}
