using Cavat.data;
using Cavat.ServiceCavat;
using InfoUsuarios;
using InfoUsuarios.cache;
using System;
using System.Data;
using System.Web.UI.WebControls;
namespace Cavat
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            //Response.Cache.SetNoStore();

            if (!IsPostBack)
            {
                SolicitudReg.Visible = false;
                RecuperacionPsw.Visible = false;
                lnkRecuperaPsw.Visible = false;
                ddlPregunta();
                ddlTipoDocumento();
                ddlTipoUser();
                ddlPreguntaPsw();

            }

        }
        public void ddlPregunta()
        {
            catalogos cat = new catalogos();
            try
            {
                DataTable ddt;
                ddt = cat.Catalogo(1);//2
                ddlPreguntaR.DataSource = ddt;
                ddlPreguntaR.DataValueField = "pregunta";
                ddlPreguntaR.DataBind();
                ddlPreguntaR.Items.Insert(0, new ListItem("Seleccione su pregunta"));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        public void ddlPreguntaPsw()
        {
            catalogos cat = new catalogos();
            try
            {
                DataTable ddt;
                ddt = cat.Catalogo(1);//2
                ddlPregRecPsw.DataSource = ddt;
                ddlPregRecPsw.DataValueField = "pregunta";
                ddlPregRecPsw.DataBind();
                ddlPregRecPsw.Items.Insert(0, new ListItem("Seleccione su pregunta de seguridad ingresada en la solicitud de su registro"));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void ddlTipoDocumento()
        {
            catalogos cat = new catalogos();
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(2);//2
                    ListItem i;
                    for (int p = 0; p < ddt.Rows.Count - 1; p++)
                    {
                        i = new ListItem(ddt.Rows[p]["nombreDoc"].ToString());
                        ddlTipoComR.Items.Add(i);
                    }
                    ddlTipoComR.Items.Insert(0, new ListItem("Seleccione Documento"));

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlTipoUser()
        {
            catalogos cat = new catalogos();
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(5);//2                    
                    var v = ddt.Rows[1]["tipoUser"];
                    ddlTipoUserR.Items.Add(v.ToString());
                    ddlTipoUserR.Items.Insert(0, new ListItem("Tipo de Usuario"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        protected void lnkRegistro_Click(object sender, EventArgs e)
        {
            SolicitudReg.Visible = true;
            Logiin.Visible = false;
        }

        protected void lnkRecuperaPsw_Click(object sender, EventArgs e)
        {
            Logiin.Visible = false;
            SolicitudReg.Visible = false;
            RecuperacionPsw.Visible = true;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {

            resultado rs = new resultado();
            DataSet dsaux = new DataSet();
            login lg = new login();
            LoginCavat entrar = new LoginCavat();
            dataUser datauser = new dataUser();

            if (txtUser.Text != "")
            {
                if (txtPass.Text != "")
                {

                    UserLoginCache.userCache = txtUser.Text;
                    datauser.contrasena = txtPass.Text;
                    datauser.opc1 = 1;

                    rs = entrar.LoginDA(datauser);
                    int msgRes = rs.mensaje;
                    dsaux = rs.elDataSet;

                    //if (rs.elDataSet.Tables[0].Rows.Count > 0)
                    //{                                            
                    //   Aaqui estaba la asignacion de variales comunes pero se paso al caso 1 del switch
                    //   }
                    // Debemos sregresar la tabla y asignar a las variables comunes los valores devueltos y luego continuar con lo de abajo

                    switch (msgRes)
                    {
                        case 1:
                            //---VARIABLES COMUNES -------------------------------
                            UserLoginCache.nombre = UserLoginCache.nombre;
                            UserLoginCache.tipoUser = dsaux.Tables[0].Rows[0][0].ToString();
                            UserLoginCache.nombre = dsaux.Tables[0].Rows[0][2].ToString();
                            UserLoginCache.ape1 = dsaux.Tables[0].Rows[0][3].ToString();
                            UserLoginCache.ape2 = dsaux.Tables[0].Rows[0][4].ToString();

                            if (UserLoginCache.tipoUser == "Administrador")
                            {
                                Response.Redirect("Admin.aspx");
                            }
                            else if (UserLoginCache.tipoUser == "Notario")
                            {
                                Response.Redirect("Notarios.aspx");
                            }
                            else
                            {
                                Response.Write("<script>alert('No existe este tipo de usuario: " + UserLoginCache.tipoUser + "')</script>");
                            }
                            break;
                        case -1:
                            msgError("El usuario no existe");
                            lnkRegistro.Visible = true;
                            lnkRecuperaPsw.Visible = false;
                            break;
                        case -10:
                            msgError("Su usuario se encuentra bloqueado. Envie un correo a lj.aguilar@ircep.gob.mx para desbloquear su usuario");
                            lnkRegistro.Visible = false;
                            lnkRecuperaPsw.Visible = false;
                            break;
                        case -2:
                            msgError("Contraseña incorrecta, intente nuevamente");
                            lnkRegistro.Visible = false;
                            lnkRecuperaPsw.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    msgError("Ingrese su contraseña.");
                    lnkRegistro.Visible = false;
                }
            }
            else
            {
                msgError("Usuario Vacio.");
                lnkRegistro.Visible = false;
            }

        }
        private void msgError(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.Visible = true;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblMsgReg.Text = "";
            checkTerminos.Checked = false;
            LimpiarCajas();
            SolicitudReg.Visible = false;
            Logiin.Visible = true;
            lblMsg.Text = "";
            lblMsg.Visible = false;
            lnkRegistro.Visible = true;
            RecuperacionPsw.Visible = false;
            lnkRecuperaPsw.Visible = false;
        }

        protected void btnSendSolicitud_Click(object sender, EventArgs e)
        {
            if (txtNombreR.Text == string.Empty || txtApePatR.Text == string.Empty || txtApeMatR.Text == string.Empty || txtCorreoR.Text == string.Empty ||
                  txtCedulaR.Text == string.Empty || ddlPreguntaR.SelectedIndex == 0 || txtRespuestaR.Text == string.Empty || txtTelefonoCelularR.Text == string.Empty
                  || txtNumeroNotariaR.Text == string.Empty || ddlTipoUserR.SelectedIndex == 0 || ddlTipoComR.SelectedIndex == 0 || flUpFileR.FileName == string.Empty)
            {
                lblMsgReg.Text = "Verifique que todos los campos esten llenos.";
            }
            else
            {
                lblMsgReg.Text = "";
                //     Logiin.Visible = false;
                int numNotaria = Int32.Parse(txtNumeroNotariaR.Text);
                int status = 2; //Siempre se envia el valor dos, ya que las solicitudes siempre entraran con el valor en espera.
                try
                {
                    SolicitudReg.Visible = true;
                    //cORRREGIR
                    var validReg = 0; //user.Registrar(txtNombreR.Text, txtApePatR.Text, txtApeMatR.Text, txtCorreoR.Text,
                    //    txtCedulaR.Text, ddlPreguntaR.SelectedIndex, txtRespuestaR.Text, txtTelefonoCelularR.Text,
                    //    numNotaria, status, ddlTipoUserR.SelectedIndex, ddlTipoComR.SelectedIndex, flUpFileR.FileName, 2);

                    if (validReg == 3)
                    {
                        Response.Write("<script>alert('Usuario registrado')</script>");
                        LimpiarCajas();
                        SolicitudReg.Visible = false;
                        Logiin.Visible = true;
                    }
                    else if (validReg == -3 || validReg == 0)
                    {
                        Response.Write("<script>alert('No se pudo enviar la solicitud')</script>");
                        LimpiarCajas();
                        SolicitudReg.Visible = false;
                        Logiin.Visible = true;
                    }
                    Logiin.Visible = true;
                    lnkRegistro.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public void LimpiarCajas()
        {
            //***Datos de Login
            txtUser.Text = "";
            txtPass.Text = "";
            //***Datos Personales
            txtNombreR.Text = "";
            txtApePatR.Text = "";
            txtApeMatR.Text = "";
            txtCorreoR.Text = "";
            txtCedulaR.Text = "";
            ddlPreguntaR.SelectedIndex = 0;
            txtRespuestaR.Text = "";
            txtTelefonoCelularR.Text = "";
            txtNumeroNotariaR.Text = "";
            ddlTipoComR.SelectedIndex = 0;
            flUpFileR.Dispose(); //fileTipoDoc.PostedFile.InputStream.Dispose();
            //Datos para la solicitud de recuperacion de contraseña
            txtUsuRecPsw.Text = "";
            txtMailRecPsw.Text = "";
            ddlPregRecPsw.SelectedIndex = 0;
            txtRespRecPsw.Text = "";

        }

        protected void btnCancelarRecPsw_Click(object sender, EventArgs e)
        {
            lblMsgReg.Text = "";
            checkTerminos.Checked = false;
            LimpiarCajas();
            SolicitudReg.Visible = false;
            Logiin.Visible = true;
            lblMsg.Text = "";
            lblMsg.Visible = false;
            lnkRegistro.Visible = true;
            RecuperacionPsw.Visible = false;
            lnkRecuperaPsw.Visible = false;
        }

        protected void btnSolicitudPsw_Click(object sender, EventArgs e)
        {
            try
            {
                //CORREGIRRRRRRRRR
                var validReg = 0;// = user.solRecPsw(txtUsuRecPsw.Text, txtMailRecPsw.Text, ddlPregRecPsw.SelectedIndex, txtRespRecPsw.Text, 4);
                if (validReg == 2)
                {
                    lblmsgPsw.Visible = true;
                    lblmsgPsw.Text = "(*) Se envió con exito la solicitud";
                    LimpiarCajas();
                }
                else if (validReg == -100)
                {
                    lblmsgPsw.Visible = true;
                    lblmsgPsw.Text = "(*) La pregunta o respuesta no coincide con los datos en el registro.";
                    LimpiarCajas();
                }
                else if (validReg == -2)
                {
                    lblmsgPsw.Visible = true;
                    lblmsgPsw.Text = "(*) El usuario o correo no se encuentra registrado en el sistema.";
                    LimpiarCajas();
                }
                Logiin.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void checkTerminos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTerminos.Checked == true)
            {
                btnSendSolicitud.Enabled = true;
            }
            else
            {
                btnSendSolicitud.Enabled = false;
            }
        }
    }
}