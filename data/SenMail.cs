using System;
using System.Net;
using System.Net.Mail;
/// <summary>
/// | Autor: Ing. Maria de Lourdes Sosa Cruz
/// Clase para realizar el envio de correo electronico a los usuarios 
/// </summary>
namespace Cavat.data
{
    public class SenMail : ConnectionToString
    {
        public int SendMail(string correo1, string motivo, string asunto)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("ejemplo@gmail.com");

            mail.To.Add(correo1);
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = motivo;

            SmtpClient smtp = new SmtpClient();
            // var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;//----
            smtp.Credentials = new NetworkCredential("ejemplo@gmail.com", "contraseña");//la contraseña con la que accedes a tu correo, pero revisa que se pueda enviar desde un correo institucional.
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