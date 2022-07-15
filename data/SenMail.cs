using System;
using System.Net;
using System.Net.Mail;

namespace Cavat.data
{
    public class SenMail : ConnectionToString
    {
        public int SendMail(string correo1, string motivo, string asunto)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("lourdeszoza@gmail.com");

            mail.To.Add(correo1);
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = motivo;

            SmtpClient smtp = new SmtpClient();
            // var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;//----
            smtp.Credentials = new NetworkCredential("lourdeszoza@gmail.com", "MaryluZoza1");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);               
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
                //return -1;
            }
            finally
            {
                smtp.Dispose();
            }
        }


    }
}