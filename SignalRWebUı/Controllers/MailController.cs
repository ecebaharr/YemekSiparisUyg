using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using SignalRWebUı.Dtos.MailDtos;

namespace SignalRWebUı.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            var mimeMessage = new MimeMessage();

            // Gönderen
            mimeMessage.From.Add(new MailboxAddress("BendenMutfağınıza Rezervasyon", "odevmaili.ntp@gmail.com"));

            // Alıcı
            mimeMessage.To.Add(new MailboxAddress("Kullanıcı", createMailDto.ReceiverMail));

            // Konu ve Gövde
            mimeMessage.Subject = createMailDto.Subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = createMailDto.Body
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            // SMTP işlemleri
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("odevmaili.ntp@gmail.com", "alyxlkteyvtkioci"); // uygulama şifresi
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return RedirectToAction("Index", "Category");
        }
    }
}
