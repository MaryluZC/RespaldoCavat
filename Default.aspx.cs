using Cavat.data;
using Cavat.ServiceCavat;
using InfoUsuarios;
using InfoUsuarios.cache;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Cavat
{
    public partial class Default : System.Web.UI.Page
    {

        resultado rs = new resultado();
        DataSet dsaux = new DataSet();
        LoginCavat entrar = new LoginCavat();
        dataUser datauser = new dataUser();
        catalogos catalog = new catalogos();//SERVICIO WEB
        TestConexion ts = new TestConexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ts.VerificarConexionURL("http://localhost:65007/ServiceCavat.svc?wsdl"))//CAMBIAR LA RUTA DEL SERVICIO A LA PUBLICADA
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache); //Response.Cache.SetExpires(DateTime.Now.AddDays(-1));  //Response.Cache.SetNoStore();
                if (!IsPostBack)
                {
                    SolicitudReg.Visible = false;
                    RecuperacionPsw.Visible = false;
                    lnkRecuperaPsw.Visible = false;

                    ddlTipoDocumento();
                    ddlTipoUser();
                    llenarCatalgos(1, "Pregunta", ddlPreguntaR, "PREGUNTA DE SEGURIDAD");//
                    llenarCatalgos(1, "Pregunta", ddlPregRecPsw, "PREGUNTA DE SEGURIDAD");//
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        public void llenarCatalgos(int opc, string columna, DropDownList lista, string titulo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = VerCatalogo(opc);
                lista.DataSource = ds.Tables[0];
                lista.DataValueField = columna;//"avance";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem(titulo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet VerCatalogo(int opc)
        {
            rs = catalog.Cataloggo(opc);
            int msg = rs.mensaje;
            dsaux = rs.elDataSet;
            return dsaux;
        }
        public void ddlTipoUser()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    rs = catalog.Cataloggo(5);
                    int msg = rs.mensaje;
                    dsaux = rs.elDataSet;
                    ddt = dsaux.Tables[0];
                    var v = ddt.Rows[1]["Perfil"];
                    ddlTipoUserR.Items.Add(v.ToString());
                    ddlTipoUserR.Items.Insert(0, new ListItem("TIPO DE USUARIO"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        public void ddlTipoDocumento()
        {
            try
            {
                //DataTable ddt;
                //ddt = catalog.Catalogo(2);//2
                DataTable ddt;
                rs = catalog.Cataloggo(2);
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                ddt = dsaux.Tables[0];

                ListItem i;
                for (int p = 0; p < ddt.Rows.Count - 1; p++)
                {
                    i = new ListItem(ddt.Rows[p]["nombreDoc"].ToString());
                    ddlTipoComR.Items.Add(i);
                }
                ddlTipoComR.Items.Insert(0, new ListItem("TIPO DE DOCUMENTO"));

            }
            catch (Exception ex)
            {
                Response.Write(ex);
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
            if (txtUser.Text != "")
            {
                if (txtPass.Text != "")
                {
                    UserLoginCache.userCache = txtUser.Text;
                    datauser.user = txtUser.Text;
                    datauser.contrasena = txtPass.Text;
                    datauser.opc1 = 1;

                    rs = entrar.LoginDA(datauser);
                    int msgRes = rs.mensaje;
                    dsaux = rs.elDataSet;
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
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','NO EXISTE ESTE TIPO DE USUARIO --> " + UserLoginCache.tipoUser + " .')", true);
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
            string namefile = flUpFileR.FileName;
            if (txtNombreR.Text == string.Empty || txtApePatR.Text == string.Empty || txtApeMatR.Text == string.Empty || txtCorreoR.Text == string.Empty ||
                  txtCedulaR.Text == string.Empty || ddlPreguntaR.SelectedIndex == 0 || txtRespuestaR.Text == string.Empty || txtTelefonoCelularR.Text == string.Empty
                  || txtNumeroNotariaR.Text == string.Empty || ddlTipoUserR.SelectedIndex == 0 || ddlTipoComR.SelectedIndex == 0 || namefile == string.Empty)
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
                    Registro dataReg = new Registro();

                    datauser.nombre = txtNombreR.Text;
                    datauser.ape1 = txtApePatR.Text;
                    datauser.ape2 = txtApeMatR.Text;
                    datauser.correo = txtCorreoR.Text;
                    datauser.cedulaP = txtCedulaR.Text;
                    datauser.idPregunta = ddlPreguntaR.SelectedIndex;
                    datauser.respuesta = txtRespuestaR.Text;
                    datauser.telCel = txtTelefonoCelularR.Text;
                    datauser.numNotaria = numNotaria;
                    datauser.idStatus = status;
                    datauser.idTipoUser = ddlTipoUserR.SelectedIndex.ToString();
                    datauser.idTipoDoc = ddlTipoComR.SelectedIndex;
                    datauser.nombreDoc = flUpFileR.FileName;
                    datauser.opc1 = 2;
                    //CORRREGIR

                    int validReg = entrar.RegistroUser(datauser);//user.Registrar(, , ,,, , , ,  , , ,, , );                
                    if (validReg == 3)
                    {
                        SaveFile(namefile);//Llama al metodo para guardar el archivo en la carpeta
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('success','USUARIO REGISTRADO .')", true);
                        LimpiarCajas();
                        SolicitudReg.Visible = false;
                        Logiin.Visible = true;
                    }
                    else if (validReg == -3 || validReg == 0)
                    {
                        //          Response.Write("<script>alert('No se pudo enviar la solicitud, La cedula ya existe')</script>");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','NO SE PUDO ENVIAR LA SOLICITUD, LA CEDULA YA EXISTE .')", true);
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

                txtNombreR.Enabled = txtApePatR.Enabled = txtApeMatR.Enabled = txtCorreoR.Enabled = txtCedulaR.Enabled = txtTelefonoCelularR.Enabled = ddlPreguntaR.Enabled = txtRespuestaR.Enabled = txtNumeroNotariaR.Enabled = ddlTipoUserR.Enabled = ddlTipoComR.Enabled = flUpFileR.Enabled = true;
            }
            else
            {
                btnSendSolicitud.Enabled = false;
                txtNombreR.Enabled = txtApePatR.Enabled = txtApeMatR.Enabled = txtCorreoR.Enabled = txtCedulaR.Enabled = txtTelefonoCelularR.Enabled = ddlPreguntaR.Enabled = txtRespuestaR.Enabled = txtNumeroNotariaR.Enabled = ddlTipoUserR.Enabled = ddlTipoComR.Enabled = flUpFileR.Enabled = false;
            }
        }

        public void SaveFile(string namefile)
        {
            if (flUpFileR.HasFile)//Primero se verifica si hay archivo
            {
                //Obtenermos la expresion y el tamaño para delimitar si es necesario
                string ext = System.IO.Path.GetExtension(namefile);
                ext = ext.ToLower();
                //el tamaño esta en bytes
                int tam = flUpFileR.PostedFile.ContentLength;
                Response.Write(ext + " " + tam);
                //Podemos llevar a cabo verificacion de extension y tamaño
                if (ext == ".pdf")
                {
                    if (tam < 1048576)
                    {
                        flUpFileR.SaveAs(Server.MapPath("~\\Comprobantes\\" + namefile));
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('success','SE SUBIÓ EL ARCHIVO')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','EL ARCHIVO EXCEDE EL TAMAÑO PERMITIDO')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','SOLO SE PERMITEN ARCHIVOS PDF')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','SELECCIONE UN ARCHIVO')", true);
            }
        }
    }
}