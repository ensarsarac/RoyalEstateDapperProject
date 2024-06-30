using MimeKit.Text;
using MimeKit;

namespace RoyalEstateDapperProject.Services.SendMail
{
    public class SendMailService : ISendMailService
    {
        public void NewsletterSuccesMail(string mail)
        {
            var email = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ensar.src94@gmail.com");
            email.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);
            email.To.Add(mailboxAddressTo);

            email.Subject = "Merhaba, Mail Bültenine Abone Oldunuğunuz İçin Teşekkürler !!";
            email.Body = new TextPart(TextFormat.Html) { Text = " En güncel kampanyalarımızdan ve son ilanlarımızdan haberdar olacaksınız. Sitemizdeki yeni kampanyaları ve eklenen son ilanları keşfetmek için sitemizi ziyaret edebilirsiniz." };

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("ensar.src94@gmail.com", "regd idgz quoz fekx");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
