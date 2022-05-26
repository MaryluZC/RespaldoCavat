using InfoUsuarios.cache;
using System;
using System.Web.UI;

namespace Cavat
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                UserLoginCache.tipoUser = "";
                UserLoginCache.nombre = "";
                UserLoginCache.ape1 = "";
                UserLoginCache.ape2 = "";
                UserLoginCache.userCache = "";
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}