using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Misubishi.BLL.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        private readonly string _displayName;

        public EmailService(IConfiguration configuration)
        {
            var emailSection = configuration.GetSection("EmailSettings");

            _smtpServer = emailSection["SmtpServer"];
            _smtpPort = int.Parse(emailSection["SmtpPort"]);
            _smtpUser = emailSection["SmtpUser"];
            _smtpPass = emailSection["SmtpPass"];
            _displayName = emailSection["DisplayName"];
        }

        public async Task SendLeadEmail(string toEmail, string fullName, string phone, string carModel)
        {
            var subject = "🚘 Có khách đăng ký báo giá mới";

            var body = $@"
                <div style='font-family:Arial,sans-serif; max-width:600px; margin:auto; border:1px solid #ddd; padding:24px; background:#f9f9f9; border-radius:8px;'>
                    <h2 style='color:#e60000; text-align:center;'>🚗 Mitsubishi Motors</h2>
                    <h3 style='text-align:center; color:#333;'>Có khách đăng ký báo giá mới</h3>
                    <p style='font-size:16px;'><strong>Tên:</strong> {fullName}</p>
                    <p style='font-size:16px;'><strong>Điện thoại:</strong> {phone}</p>
                    <p style='font-size:16px;'><strong>Dòng xe quan tâm:</strong> {carModel}</p>
                    <hr style='margin:24px 0;' />
                    <p style='font-size:13px; color:#777;'>Đây là email tự động từ hệ thống Mitsubishi Auto. Vui lòng không trả lời email này.</p>
                </div>";

            var message = new MailMessage
            {
                From = new MailAddress(_smtpUser, _displayName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(toEmail);

            var client = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
    }
}
