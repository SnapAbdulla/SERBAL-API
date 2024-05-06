using System.Net.Mail;
namespace Serbal.Utility
{
    public class SentOTP
    {
        public static void SendOTP(int otp, string email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                client.Port = 587;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential("snaprayyan@outlook.com", "qwertyui123");
                client.EnableSsl = true;
                client.Credentials = credential;

                MailMessage message = new MailMessage("snaprayyan@outlook.com", email);
                message.Subject = "Your One-Time Password (OTP) for Account Verification";
                message.Body = "<html><body><h1>One-Time Password (OTP) for Account Verification</h1><p>Dear User," +
                    "</p><p>Your One-Time Password (OTP) for your email (" + email + ") is: <strong>" + otp + "</strong>." +
                    "</p><p>Please use this OTP to verify your account.</p><p>Thank you.</p></body></html>";
                message.IsBodyHtml = true;
                client.Send(message);

                Console.WriteLine("OTP email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
