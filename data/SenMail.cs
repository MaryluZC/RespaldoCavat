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
            mail.From = new MailAddress("alejandra.lobato.santos@hotmail.com");//Quien envia
            mail.To.Add(correo1);//Correo a quien de envia el correo
            mail.Subject = asunto;//Asunto del correo
            mail.IsBodyHtml = true;
            mail.Body = motivo;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";//Host del servidor
            smtp.Port = 587;//Puerto de salida
            smtp.UseDefaultCredentials = false;//----
            smtp.Credentials = new NetworkCredential("alejandra.lobato.santos@hotmail.com", "Rcmmcc25**");//la contraseña con la que accedes a tu correo, pero revisa que se pueda enviar desde un correo institucional.
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);                
            }
            finally
            {
                smtp.Dispose();
            }
        }
    }
}