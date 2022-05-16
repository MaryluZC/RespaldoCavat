using Cavat.data;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoUsuarios;
using InfoUsuarios.cache;
namespace Cavat
{
    public partial class Admin : System.Web.UI.Page
    {
        dataUser ifus = new dataUser();
        UserDAo user = new UserDAo();
        SenMail mail = new SenMail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ifus.user != string.Empty || ifus.user!=null)
            {
                 if (!IsPostBack)
                {
                    llenaRegistrosA();
                    llenaSolReg();
                    llenaSolCambioPsw();
                    lnkHome.ForeColor = Color.FromArgb(171, 68, 104);
                    lnkUserRegistrados.ForeColor = Color.FromArgb(89, 4, 34);
                    lnkCambioPsw.ForeColor = Color.FromArgb(89, 4, 34);
                    lblLetterOption.Text = "Solicitudes de Registro";
                    lblUserAdm.Text = "Usuario: " + UserLoginCache.tipoUser;///Coloca el nombre del Usuario
                    lblNombre.Text = "Nombre: " + UserLoginCache.nombre + " " + UserLoginCache.ape1 + " " + UserLoginCache.ape2;

                }
            }
            else
            {               
                Response.Redirect("Default.aspx");
            }
        }
        public void llenaRegistrosA()
        {
            DataSet dt = new DataSet();
            dt = user.ListSolicitudes(2);
            GVRegistrados.DataSource = dt;
            GVRegistrados.DataBind();
        }
        public void llenaSolReg()
        {
            DataSet dt = new DataSet();
            dt = user.ListSolicitudes(3);
            GVSolicitudes.DataSource = dt;
            GVSolicitudes.DataBind();
        }
        public void llenaSolCambioPsw()
        {
            DataSet dt = new DataSet();
            dt = user.ListSolicitudes(6);
            GVCambioPss.DataSource = dt;
            GVCambioPss.DataBind();
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            lnkHome.ForeColor = Color.FromArgb(171, 68, 104);
            lnkUserRegistrados.ForeColor = Color.FromArgb(89, 4, 34);
            lnkCambioPsw.ForeColor = Color.FromArgb(89, 4, 34);
            lblLetterOption.Text = "Solicitudes de Registro";

            GVSolicitudes.Visible = true;
            GVRegistrados.Visible = false;
            GVCambioPss.Visible = false;
            CambioPsw.Visible = false;
            ContenRegNewNotario.Visible = true;
        }

        protected void lnkUserRegistrados_Click(object sender, EventArgs e)
        {
            lnkHome.ForeColor = Color.FromArgb(89, 4, 34);
            lnkUserRegistrados.ForeColor = Color.FromArgb(171, 68, 104);
            lnkCambioPsw.ForeColor = Color.FromArgb(89, 4, 34);
            lblLetterOption.Text = "Usuarios Registrados";

            GVSolicitudes.Visible = false;
            GVRegistrados.Visible = true;
            GVCambioPss.Visible = false;
            CambioPsw.Visible = false;
            ContenRegNewNotario.Visible = true;
        }

        protected void lnkCambioPsw_Click(object sender, EventArgs e)
        {
            lnkHome.ForeColor = Color.FromArgb(89, 4, 34);
            lnkUserRegistrados.ForeColor = Color.FromArgb(89, 4, 34);
            lnkCambioPsw.ForeColor = Color.FromArgb(171, 68, 104);
            lblLetterOption.Text = "Solicitudes de Cambio de Contraseña";

            GVSolicitudes.Visible = false;
            GVRegistrados.Visible = false;
            GVCambioPss.Visible = true;
            CambioPsw.Visible = true;
            ContenRegNewNotario.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNewUser.Text == String.Empty || txtNewPsw.Text == String.Empty)
            {
                lblMsgAviso.Text = "Genere un usuario y contraseña para poder enviar el correo.";
                lblMsgAviso.ForeColor = Color.FromArgb(169, 150, 150);
            }
            else
            {
                string nombrec = txtNombre.Text + " " + txtApe1.Text + " " + txtApe2.Text;//nombreCm;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "OpenModalAprob('" + nombrec + "','" + txtNewUser.Text + "','" + txtNewPsw.Text + "')", true);
            }
        }

        protected void btnDenegar_Click(object sender, EventArgs e)
        {
            if (txtcorreo.Text == String.Empty || txtNewUser.Text == String.Empty)
            {
                lblMsgAviso.Text = "(*) Verifique el el campo correo, usuario y contraseña no se encuentren vacios";
                lblMsgAviso.ForeColor = Color.FromArgb(169, 150, 150);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "OpenModalDen()", true);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
                CleanRegNuevNota();
          //  }
        }
        public void CleanRegNuevNota()
        {
            txtNombre.Text = "";
            txtApe1.Text = "";
            txtApe2.Text = "";
            txtcorreo.Text = "";
            txtTelefono.Text = "";
            txtPregunta.Text = "";
            txtRespuesta.Text = "";
            txtNotaria.Text = "";
            txtCedulaP.Text = "";
            txtTipoUser.Text = "";
            txtComprobante.Text = "";
            txtNewUser.Text = "";
            txtNewPsw.Text = "";
            //------------- CAMBIO DE CONTRASEÑA
            txtNombreCPSW.Text = "";
            txtApe1CPSW.Text = "";
            txtApe2CPSW.Text = "";
            txtUserCPSW.Text = "";
            txtNewCPSW.Text = "";
            txtMailCPSW.Text = "";

        }

        protected void btnLimpiarCPW_Click(object sender, EventArgs e)
        {
            CleanRegNuevNota();
        }

        protected void btnEnviarCPW_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (txtMailCPSW.Text == String.Empty || txtUserCPSW.Text == String.Empty || txtNewCPSW.Text == String.Empty)
                {
                    lblMsgCPW.Text = "(*) Verifique que el campo correo, usuario o nueva contraseña no se encuentren vacios";
                    lblMsgCPW.ForeColor = Color.FromArgb(169, 150, 150);
                }
                else
                {
                    lblMsgCPW.Text = "";
                    string body = "Su contraseña fue restaurada <br><br>" +
                      "<b>Nueva Contraseña: </b>" + txtNewCPSW.Text;
                    int val = mail.SendMail(txtMailCPSW.Text, body, "Contraseña Nueva CAVAT");
                    string mensaje = "";
                    if (val == 1)
                    {
                        int v =user.ChangePass(txtNewCPSW.Text, 7, txtUserCPSW.Text); //debe la contraseña.

                        if (v == 7)
                        {
                            CleanRegNuevNota();//Limpia las cajas de texto
                            mensaje = "Correo Enviado";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                        }
                        else
                        {
                            CleanRegNuevNota();//Limpia las cajas de texto
                            mensaje = "No Puedo Actualizar la Informacion";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                        }
                    }
                    else
                    {
                        CleanRegNuevNota();//Limpia las cajas de texto
                        mensaje = "No Puedo Enviar el Correo";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                    }
                    llenaRegistrosA();
                    llenaSolReg();
                    llenaSolCambioPsw();
                    CleanRegNuevNota();//Limpia las cajas de texto
                }
            }
        }

        protected void GVSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Poner el paaso de paginacion en Grid
        }

        protected void GVSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.CommandName == "aprobar")
                {
                    lblMsgAviso.Text = "";
                    int ind = int.Parse(e.CommandArgument.ToString());
                    txtNombre.Text = GVSolicitudes.Rows[ind].Cells[1].Text;
                    txtApe1.Text = GVSolicitudes.Rows[ind].Cells[2].Text;
                    txtApe2.Text = GVSolicitudes.Rows[ind].Cells[3].Text;
                    txtcorreo.Text = GVSolicitudes.Rows[ind].Cells[4].Text;

                    txtCedulaP.Text = GVSolicitudes.Rows[ind].Cells[7].Text;
                    txtPregunta.Text = System.Web.HttpUtility.HtmlDecode(GVSolicitudes.Rows[ind].Cells[8].Text);
                    txtRespuesta.Text = GVSolicitudes.Rows[ind].Cells[9].Text;
                    txtTelefono.Text = GVSolicitudes.Rows[ind].Cells[10].Text;
                    txtNotaria.Text = GVSolicitudes.Rows[ind].Cells[11].Text;
                    txtTipoUser.Text = GVSolicitudes.Rows[ind].Cells[15].Text;
                    txtComprobante.Text = GVSolicitudes.Rows[ind].Cells[16].Text;

                }
            }
            else
            {
                CleanRegNuevNota();
            }
        }

        protected void GVRegistrados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //En caso de cancelar la edicion de la fila se indica la terminacion de la edicion
            GVRegistrados.EditIndex = -1;
            //Se indica que se termino la edicion y se recarga la tabla/Grid
            llenaRegistrosA();
        }

        protected void GVRegistrados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //asignacion de los parametros,obtenidos de la variable e qe es argumento del método.
                string nombre = e.NewValues[0].ToString();
                string ape1 = e.NewValues[1].ToString();
                string ape2 = e.NewValues[2].ToString();
                string correo = e.NewValues[3].ToString();
                string Pss = e.NewValues[5].ToString();
                string cedula = e.NewValues[6].ToString();
                string telcel = e.NewValues[7].ToString();
                //    string telcel = GVRegistrados.Rows[ind].Cells[10].Text;
                //Sellama al SP para editar la informacion 
                int v = user.ChangeInfoUserr(nombre, ape1, ape2, correo, Pss, cedula, telcel, 1);
                GVRegistrados.EditIndex = -1;
                llenaRegistrosA();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVRegistrados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVRegistrados.EditIndex = e.NewEditIndex;//Indica que el componente entra en modo de edicion indicando el indice de la fila seleccionada
                                                     //Complementariamente, se recargan los datos del componente para el momento de entrar en modo de edicion se visualicen los datosde la fila seleecionada
            llenaRegistrosA();
        }

        protected void GVCambioPss_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.CommandName == "CambioPsw")
                {
                    lblMsgAviso.Text = "";
                    int ind = int.Parse(e.CommandArgument.ToString());
                    txtNombreCPSW.Text = GVCambioPss.Rows[ind].Cells[1].Text;
                    txtApe1CPSW.Text = GVCambioPss.Rows[ind].Cells[2].Text;
                    txtApe2CPSW.Text = GVCambioPss.Rows[ind].Cells[3].Text;
                    txtMailCPSW.Text = GVCambioPss.Rows[ind].Cells[4].Text;
                    txtUserCPSW.Text = GVCambioPss.Rows[ind].Cells[5].Text;
                }
            }
            else
            {
                CleanRegNuevNota();
            }
        }

        protected void txtEnviarCorreo_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (txtCausaRechazo.Text == string.Empty) {
                mensaje = "El motivo de causa de rechazo no debe estar vacío. Intente Nuevamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                CleanRegNuevNota();//Limpia las cajas de texto
            }
            else
            {
            
            mail.SendMail(txtcorreo.Text, txtCausaRechazo.Text, "Rechazo de Solicitud Portal Notarial Cavat");
            int v1 = user.DeleteUserr(txtCedulaP.Text, 5);            
            if (v1 == 8)
            {
                mensaje = "Se Elimino la Solicitud";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                    CleanRegNuevNota();//Limpia las cajas de texto
                }
            else
            {
                mensaje = "No Puedo Eliminar la Solicitud";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                    CleanRegNuevNota();//Limpia las cajas de texto
                }
            llenaRegistrosA(); //Actualiza los datos del sistema
            llenaSolReg();//Actualiza los datos del sistema            
            txtCausaRechazo.Text = "";
            }
        }

        protected void btnGenerarUP_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var r1 = random.Next(1, 999);
            if (txtNombre.Text == String.Empty || txtApe1.Text == String.Empty)
            {
                lblMsgAviso.Text = "No se puede generar el usuario. Selecciona fila de la tabla";
                lblMsgAviso.ForeColor = Color.FromArgb(169, 150, 150);
            }
            else
            {
                GeneraUser(txtNombre.Text, txtApe1.Text, r1);
                txtNewPsw.Text = GeneraPsw();
                lblMsgAviso.Text = "";
            }
        }
        public void GeneraUser(string nombre, string apellido, int r1)
        {
            string n1 = nombre.Substring(0, 2);
            string n2 = apellido.Substring(0, 2);
            txtNewUser.Text = n1 + n2 + r1.ToString();
        }
        public string GeneraPsw()
        {
            var random = new Random();
            string cad = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string sig = "%$#@&/.";
            char letra;
            string contAle = string.Empty;

            for (int i = 0; contAle.Length < 6; i++)
            {
                letra = cad[random.Next(cad.Length)];
                var k = sig[random.Next(sig.Length)];
                contAle += letra.ToString() + k.ToString();
            }

            return contAle;
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string body = "Bienvido al sistema Cavat. <br> Este sistema sirve como apoyo para realizar una simulación" +
                   "de un valor aproximado al real de la propiedad. <br><b>USUARIO: </b>" + txtNewUser.Text + "<br> <b>CONTRASEÑA: </b>" + txtNewPsw.Text;
                int val = mail.SendMail(txtcorreo.Text, body, "Solicitud Aprobada, Registro Portal Notarial Cavat");
                string mensaje = "";
                if (val == 1)
                {
                    int v = user.ChangeStatusAprob(txtNewUser.Text, txtNewPsw.Text, 4, txtCedulaP.Text); //debe actualizar el status a aprobado para que se actualice la tabla de datos.

                    if (v == 9)
                    {
                        mensaje = "Correo Enviado";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                        CleanRegNuevNota();//Limpia las cajas de texto
                    }
                    else
                    {
                        mensaje = "No Puedo Enviar el Correo";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                        CleanRegNuevNota();//Limpia las cajas de texto
                    }
                }
                else
                {
                    mensaje = "No Puedo Enviar el Correo";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "Msg('" + mensaje + "')", true);
                    CleanRegNuevNota();//Limpia las cajas de texto
                }
                llenaRegistrosA(); //Actualiza los datos del sistema
                llenaSolReg();//Actualiza los datos del sistema
                CleanRegNuevNota();//Limpia las cajas de texto
                //Falta enviar mensaje de exito o fracaso para informar al usuario que se envio el correo
            }
        }
    }
}