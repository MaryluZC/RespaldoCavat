using System;

namespace Cavat
{
    public partial class _404 : System.Web.UI.Page
    {
        TestConexion ts = new TestConexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ts.VerificarConexionURL("http://localhost:65007/ServiceCavat.svc?wsdl"))//CAMBIAR LA RUTA DEL SERVICIO A LA PUBLICADA
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}