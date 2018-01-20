using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using salmorn.Models.Commons;
using salmorn.Services.Commons;

namespace salmorn.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Generate()
        {
            EmailSettings appSettings = new EmailSettings()
            {
                PrimaryDomain = "smtp.gmail.com",
                PrimaryPort = 587,
                SecondayDomain = "smtp.live.com",
                SecondaryPort = 587,
                UsernameEmail = "jirawat.jannet@gmail.com",
                UsernamePassword = "jirawat1369",
                FromEmail = "jirawat.jannet@gmail.com",
                ToEmail = "jirawat.jannet@gmail.com",
                CcEmail = ""
            };
            IOptions<EmailSettings> options = Options.Create(appSettings);
            AuthMessageSender mail = new AuthMessageSender(options);
            mail.SendEmailAsync("jirawat.jannet@gmail.com", "Test sender", "Test");
        }
    }
}
