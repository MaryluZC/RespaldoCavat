using System.Net;
namespace Cavat
{
    public class TestConexion
    {
        public bool VerificarConexionURL(string mURL)//http://localhost:65007/ServiceCavat.svc?wsdl
        {
            WebRequest Peticion = default(WebRequest);
            HttpWebResponse Respuesta = (HttpWebResponse)default(WebResponse);
            try
            {
                Peticion = WebRequest.Create(mURL);
                Respuesta = (HttpWebResponse)Peticion.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return false;
                }
                return false;
            }
        }
    }
}