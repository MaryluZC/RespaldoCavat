using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoUsuarios;
using InfoUsuarios.cache;

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