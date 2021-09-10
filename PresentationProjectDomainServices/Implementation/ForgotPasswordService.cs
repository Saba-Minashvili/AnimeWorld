using MailKit.Net.Smtp;
using MimeKit;
using PresentationProjectDomainDb;
using PresentationProjectDomainServices.Abstraction;

namespace PresentationProjectDomainServices.Implementation
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        public bool SendForgotPasswordMessage(string email)
        {
            try
            {
                var message = new MimeMessage();
                var emailSQL = "select Email from [AccountTbl] where Email = '" + email + "'";
                var passwordSQL = "select Password from [AccountTbl] where Email = '" + email + "'";
                var emailValue = "Email";
                var passwordValue = "Password";
                var emailResult = SQLDatabaseServerConnection.ExecuteSQLByCmd(emailSQL, @"Data Source=DESKTOP-0FM65T2;Initial Catalog=Account;Integrated Security=True", emailValue);
                var passwordResult = SQLDatabaseServerConnection.ExecuteSQLByCmd(passwordSQL, @"Data Source=DESKTOP-0FM65T2;Initial Catalog=Account;Integrated Security=True", passwordValue);

                if (emailResult != string.Empty)
                {
                    // enter your email that will send a password to user
                    message.From.Add(new MailboxAddress(""));
                    message.To.Add(new MailboxAddress(email));
                    message.Subject = "AnimeWorld account password";
                    message.Body = new TextPart("plain") { Text = $"Your password is {passwordResult}" };

                    using (SmtpClient client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);

                        // enter mail and password that will send a password to user
                        client.Authenticate("", "");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
