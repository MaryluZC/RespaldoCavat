using Cavat.data;
using InfoUsuarios;
using InfoUsuarios.cache;
using InfoUsuarios.infoPredio;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cavat
{
    public partial class Notarios : System.Web.UI.Page
    {

        catalogos cat = new catalogos();
        Catalogos catt = new Catalogos();//CAPA COMUN
        valoresCalculo valores = new valoresCalculo();
        private static DataTable tabla = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//lo que solo se ejeuta una vez
            {
                crearTablaC();
            }

            if (UserLoginCache.nombre == string.Empty || UserLoginCache.nombre == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    GVConstrucciones.DataBind();
                    ddlUbicaManzana();
                    ddlUbicaManzana();
                    ddlClasificacionPred();
                    ddlConvercavionConstrucion();
                    ddlEdadConstruc();
                    //lblUserNot.Text = "Usuario: " + UserLoginCache.tipoUser;///Coloca el nombre del Usuario
                    //lblNombreNot.Text = "Nombre: " + UserLoginCache.nombre + " " + UserLoginCache.ape1 + " " + UserLoginCache.ape2;
                }
                else
                {
                    var random = new Random();
                    var r1 = random.Next(1, 999999);
                    lblFOLIOT.Text = Convert.ToString(r1);
                }
            }

        }
        public void llenarAvanceConstruccion()
        {
            DataSet dt = new DataSet();
            ddlAvanceConstruccion.DataSource = catt.Catalogo(13); ;
            ddlAvanceConstruccion.DataValueField = "avance";
            ddlAvanceConstruccion.DataBind();
            ddlAvanceConstruccion.Items.Insert(0, new ListItem("AVANCE DE OBRA"));
        }
        public void llenarHabitada()
        {
            ddlHabitada.ClearSelection();
            ddlHabitada.Items.Insert(0, new ListItem("HABITADA"));
            ddlHabitada.Items.Insert(1, new ListItem("SI"));
            ddlHabitada.Items.Insert(2, new ListItem("NO"));
        }

        public void ddlEdadConstruc()
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlEdadConstruccion.Items.Insert(0, new ListItem("EDAD"));
                    ddlEdadConstruccion.Items.Insert(1, new ListItem("1 - 10 AÑOS"));
                    ddlEdadConstruccion.Items.Insert(2, new ListItem("11 - 20 AÑOS"));
                    ddlEdadConstruccion.Items.Insert(3, new ListItem("21 - 30 AÑOS"));
                    ddlEdadConstruccion.Items.Insert(4, new ListItem("31 - 40 AÑOS"));
                    ddlEdadConstruccion.Items.Insert(5, new ListItem("41 - 50 AÑOS"));
                    ddlEdadConstruccion.Items.Insert(6, new ListItem("51 - EN ADELANTE"));

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlConvercavionConstrucion()
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlCoservacion.Items.Insert(0, new ListItem("CONCERVACIÓN"));
                    ddlCoservacion.Items.Insert(1, new ListItem("BUENO"));
                    ddlCoservacion.Items.Insert(2, new ListItem("REGULAR"));
                    ddlCoservacion.Items.Insert(3, new ListItem("MALO"));

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        public void ddlTipoPredio1()
        {
            if (IsPostBack) //checar que no se vuelva a llenar
            {
                try
                {
                    ddlTipoPredio.ClearSelection();
                    DataTable ddt;
                    ddt = cat.Catalogo(6);//--> Catalogo Localidades 
                    ddlTipoPredio.DataSource = ddt;
                    ddlTipoPredio.DataValueField = "tipPredio";
                    ddlTipoPredio.DataBind();
                    ddlTipoPredio.Items.Insert(0, new ListItem("TIPO PREDIO"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void llenaCatObraComp()
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(14);//--> Catalogo Obras Complementarias
                    ddlObraComplementaria.DataSource = ddt;
                    ddlObraComplementaria.DataValueField = "obrasComplementarias";
                    ddlObraComplementaria.DataBind();
                    ddlObraComplementaria.Items.Insert(0, new ListItem("OBRA COMPLEMENTARIA"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        public void ddlmunicipio()
        {
            if (IsPostBack) ///Verificar si no se rellenan nuevamente
            {
                try
                {
                    ddlMunicipio.ClearSelection();
                    DataTable ddt;
                    ddt = cat.Catalogo(4);//--> Catalogo Municipio
                    ddlMunicipio.DataSource = ddt;
                    ddlMunicipio.DataValueField = "municipio";
                    ddlMunicipio.DataBind();
                    ddlMunicipio.Items.Insert(0, new ListItem("MUNICIPIO"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlUbicaManzana()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(9);//--> Catalogo Municipio
                    ddlUbicacionManzana.DataSource = ddt;
                    ddlUbicacionManzana.DataValueField = "ubicacion";
                    ddlUbicacionManzana.DataBind();
                    ddlUbicacionManzana.Items.Insert(0, new ListItem("UBICACIÓN MANZANA"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlClasificacionPred()
        {
            if (!IsPostBack) //este postback si va
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(10);//--> Catalogo clasificacion predio 
                    ddlClasPred.DataSource = ddt;
                    ddlClasPred.DataValueField = "classPredio";
                    ddlClasPred.DataBind();
                    ddlClasPred.Items.Insert(0, new ListItem("CLASIFICACIÓN DE CONSTRUCCIÓN"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }


        protected void btnUbicaPredio_Click(object sender, ImageClickEventArgs e)
        {
            UbicacionPredio.Visible = true;
            Presentacion.Visible = false;
            FactorTerreno.Visible = false;
            FactorConstruccion.Visible = false;
            Georreferencia.Visible = false;
            ContentUrbano.Visible = false;
            btnTerminar.Enabled = false;
            if (IsPostBack)
            {
                ddlmunicipio();
                ddlTipoPredio1();
            }
        }

        protected void btnFactorTerreno_Click(object sender, ImageClickEventArgs e)
        {
            fFactorTerreno();
            //    RBUDMSuperficie.SelectedValue = "m";
        }
        public void fFactorTerreno()
        {
            FactorConstruccion.Visible = false;

            if (usoSuelo.tipoPredio == string.Empty || usoSuelo.tipoPredio == null || ddlTipoPredio.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','PARA PODER CONTINUAR DEBE ELEGIR UN TIPO DE PREDIO.')", true);

                UbicacionPredio.Visible = true;
                ddlTipoPredio.BorderColor = Color.Red;
                ddlTipoPredio.BorderWidth = 3;
            }
            else if (usoSuelo.tipoPredio == "RÚSTICO")
            {
                lbltipoPredio.Text = usoSuelo.tipoPredio;
                UbicacionPredio.Visible = false;
                FactorTerreno.Visible = true;
                ContentRustico.Visible = true;
                ContentUrbano.Visible = false;

                //ddlSuperficieRustico.Visible = true; //Sustituir por seleccion UDM

                //VerSuperficeRustico();//llenar ddl
                ddlUsoSueloRustico.ClearSelection();
                ddlUsoSueloRustico.Items.Clear();
                UsoSueloRustico();//checar el postback

                ddlTopografiaRustico.ClearSelection();
                ddlTopografiaRustico.Items.Clear();
                topografiaRustico();

                ddlDistanciaUDM.ClearSelection();
                ddlDistanciaUDM.Items.Clear();
                ddlUDMDistancia();
                ddlUbicaciónRustico.ClearSelection();
                ddlUbicaciónRustico.Items.Clear();
                ddlUbicacionRustic();
                ddlTipoSRustico.Items.Insert(0, new ListItem("TIPO"));
                //Poner contenedor Urbao y Suburabao en false
                //cuando cambie vaciar los componentes del otro
            }
            else
            {
                lbltipoPredio.Text = usoSuelo.tipoPredio;
                UbicacionPredio.Visible = false;
                FactorTerreno.Visible = true;
                ContentUrbano.Visible = true;
                ContentRustico.Visible = false;

                //   ddlSuperficieRustico.Visible = false;//Sustituir por seleccion UDM
                //cuando cambie vaciar los componentes del otro
                ddlUsoSueloUrbano.Items.Clear();
                ddlUsoSueloUrbano.ClearSelection();
                verUsoSueloUrbano();
                ddlDesnivelUrbano.Items.Clear();
                ddlDesnivelUrbano.ClearSelection();
                VerDesnivelUrbano();

            }
        }
        protected void btnFactorConstruccion_Click(object sender, ImageClickEventArgs e)
        {
            UbicacionPredio.Visible = false;
            Presentacion.Visible = false;
            VerMapa.Visible = false;
            FactorTerreno.Visible = false;
            FactorConstruccion.Visible = true;
            Georreferencia.Visible = false;
            ContentUrbano.Visible = false;
            ddlAvanceConstruccion.ClearSelection();
            llenarAvanceConstruccion();
            ddlHabitada.ClearSelection();
            llenarHabitada();
            btnTerminar.Enabled = true;
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int va = int.Parse(ddlMunicipio.SelectedIndex.ToString());
                predios.municipio = ddlMunicipio.SelectedValue.ToString();//Envia a la variable el valor del municipio
                //Label1.Text = va.ToString();
                try
                {
                    ddlLocalidad.ClearSelection();
                    ddlLocalidad.Items.Clear();
                    ddlLocalidadD(8, va);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ddlZonaValor.Items.Insert(1, new ListItem("H1"));
                ddlZonaValor.Items.Insert(1, new ListItem("H2"));
            }
        }
        public void ddlLocalidadD(int opc, int idmun)
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.CatLocalidad(opc, idmun);//--> Catalogo Municipio
                    ddlLocalidad.DataSource = ddt;
                    ddlLocalidad.DataValueField = "localidad";
                    ddlLocalidad.DataBind();
                    ddlLocalidad.Items.Insert(0, new ListItem("LOCALIDAD"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
            predUrbano.cp = txtCP.Text;
            if (true)
            {
                btnUbicaPredio.BorderColor = Color.Aquamarine;
                btnUbicaPredio.BorderStyle = BorderStyle.Solid;
                Response.Write("<script>alert('" + ddlMunicipio.SelectedIndex + "')</script>");
            }
        }

        protected void ddlTipoPredio_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlTipoPredio.BorderColor = Color.Transparent;
            ddlTipoPredio.BorderWidth = 0;

            int va = int.Parse(ddlTipoPredio.SelectedIndex.ToString());//Label1.Text = va.ToString();
            predios.tipoPredio = usoSuelo.tipoPredio = ddlTipoPredio.SelectedValue.ToString();

            try
            {
                if (va == 1)//rústico
                {
                    txtParaje.Visible = true;
                    ddlLocalidad.Visible = ddlZonaValor.Visible = false;
                    txtCalle.Visible = txtNumero.Visible = txtColonia.Visible = txtCP.Visible = false;
                    //Poner conteedor Urbao y Suburabao en false
                    //cuando cambie vaciar los componentes del otro


                }
                else if (va == 2 || va == 3)
                { //Urban o suburbano
                    txtParaje.Visible = false;
                    txtParaje.Text = "";
                    ddlLocalidad.Visible = ddlZonaValor.Visible = true;
                    txtCalle.Visible = txtNumero.Visible = txtColonia.Visible = txtCP.Visible = true;
                }
                else
                {
                    //ddlSuperficieRustico.Visible = false;//Sustituir por seleccion UDM
                    txtParaje.Visible = txtCalle.Visible = txtNumero.Visible = txtColonia.Visible = txtCP.Visible = false;
                    ddlLocalidad.Visible = ddlZonaValor.Visible = false;
                    //Falta vaciar cada componente
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void VerSuperficeRustico()
        //{
        //    try
        //    {
        //        ddlSuperficieRustico.Items.Insert(0, new ListItem("UDM"));
        //        ddlSuperficieRustico.Items.Insert(1, new ListItem("METROS"));
        //        ddlSuperficieRustico.Items.Insert(2, new ListItem("HECTAREAS"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex);
        //    }
        //}
        public void VerDesnivelUrbano()
        {
            try
            {
                ddlDesnivelUrbano.Items.Insert(0, new ListItem("¿EXISTE DESNIVEL?"));
                ddlDesnivelUrbano.Items.Insert(1, new ListItem("SI"));
                ddlDesnivelUrbano.Items.Insert(2, new ListItem("NO"));

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        public void verUsoSueloUrbano()
        {
            try
            {
                ddlUsoSueloUrbano.Items.Insert(0, new ListItem("Uso de Suelo"));
                ddlUsoSueloUrbano.Items.Insert(1, new ListItem("Habitacional")); //Devolver 1 a mony
                ddlUsoSueloUrbano.Items.Insert(2, new ListItem("Comercial Alta (Subsuelos Urbanos o Centros Comerciales)"));//Devolver 3 a mony
                ddlUsoSueloUrbano.Items.Insert(3, new ListItem("Comercial Media"));//Devolver 2 a mony
                ddlUsoSueloUrbano.Items.Insert(4, new ListItem("Comercial Baja (Comercio de Barrio)"));//Devolver 2 a mony
                ddlUsoSueloUrbano.Items.Insert(5, new ListItem("Historica"));//Devolver 2 a mony
                ddlUsoSueloUrbano.Items.Insert(6, new ListItem("Industrial"));//Devolver 2 a mony
                ddlUsoSueloUrbano.Items.Insert(7, new ListItem("Otras"));//Devolver 4 a mony
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void ddlUbicacionRustic()
        {
            try
            {
                ddlUbicaciónRustico.Items.Insert(0, new ListItem("Ubicación"));
                ddlUbicaciónRustico.Items.Insert(1, new ListItem("Predio interior sin derecho de paso constituido"));
                ddlUbicaciónRustico.Items.Insert(2, new ListItem("Predio interior con derecho de paso constituido"));
                ddlUbicaciónRustico.Items.Insert(3, new ListItem("Camino vecinal transitable durante determinadas épocas del año"));
                ddlUbicaciónRustico.Items.Insert(4, new ListItem("Camino rural con estructura de terracería transitable todo el año"));
                ddlUbicaciónRustico.Items.Insert(5, new ListItem("Carretera pavimentada (feredal o estatal)"));

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        public void ddlUDMDistancia()
        {
            try
            {
                ddlDistanciaUDM.Items.Insert(0, new ListItem("UDM"));
                ddlDistanciaUDM.Items.Insert(1, new ListItem("m"));
                ddlDistanciaUDM.Items.Insert(2, new ListItem("km"));

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void UsoSueloRustico()
        {
            try
            {
                ddlUsoSueloRustico.Items.Insert(0, new ListItem("Uso de Suelo"));
                ddlUsoSueloRustico.Items.Insert(1, new ListItem("Agrícola"));
                ddlUsoSueloRustico.Items.Insert(2, new ListItem("Ganadero"));
                ddlUsoSueloRustico.Items.Insert(3, new ListItem("Forestal"));
                ddlUsoSueloRustico.Items.Insert(4, new ListItem("Extracción"));
                ddlUsoSueloRustico.Items.Insert(5, new ListItem("Eriazo"));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        public void topografiaRustico()
        {
            try
            {
                ddlTopografiaRustico.Items.Insert(0, new ListItem("Topografía y Relieve"));
                ddlTopografiaRustico.Items.Insert(1, new ListItem("Llano/Plano"));
                ddlTopografiaRustico.Items.Insert(2, new ListItem("Lomerío Suave/Modernamente Inclinado"));
                ddlTopografiaRustico.Items.Insert(3, new ListItem("Lomerío accidentado/Iniciado "));
                ddlTopografiaRustico.Items.Insert(4, new ListItem("Escarpado"));
                ddlTopografiaRustico.Items.Insert(5, new ListItem("Montañoso"));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void ddlClasPred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int va = int.Parse(ddlClasPred.SelectedIndex.ToString());
                //Label1.Text = va.ToString();
                try
                {
                    ddlTipoConstruccion.ClearSelection();
                    ddlCalidadConstruccion.ClearSelection();
                    ddlTipoCons(11, va);
                    if (ddlClasPred.SelectedValue.ToString() == "ANTIGUO")
                    {
                        ddlEdadConstruccion.Enabled = false;
                    }
                    else if (ddlClasPred.SelectedValue.ToString() == "MODERNO")
                    {
                        ddlEdadConstruccion.Enabled = true;
                        ddlCoservacion.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void ddlTipoCons(int opc, int idClass) ///Devuelve el catalogo dependiendo de la opcion enviada por ddlClasificacion construccion
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.CatTipoPredCons(opc, idClass);//--> Catalogo Municipio
                    ddlTipoConstruccion.DataSource = ddt;
                    ddlTipoConstruccion.DataValueField = "tipoPredio";
                    ddlTipoConstruccion.DataBind();
                    ddlTipoConstruccion.Items.Insert(0, new ListItem("Tipo de Construcción"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void ddlTipoConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string va = ddlTipoConstruccion.SelectedValue.ToString();
                try
                {
                    ddlCalidadConstruccion.ClearSelection();
                    ddlCalidadConstruccion.Items.Clear();
                    ddlCalidadPred(12, int.Parse(ddlClasPred.SelectedIndex.ToString()), va);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void ddlCalidadPred(int opc, int idClass, string clv) ///Devuelve el catalogo dependiendo de la opcion enviada por ddlClasificacion construccion
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.CatClaseConstrucion(opc, idClass, clv);//--> Catalogo Municipio
                    ddlCalidadConstruccion.DataSource = ddt;
                    ddlCalidadConstruccion.DataValueField = "calidad";
                    ddlCalidadConstruccion.DataBind();
                    ddlCalidadConstruccion.Items.Insert(0, new ListItem("Calidad de Construcción"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void chekMap_CheckedChanged(object sender, EventArgs e)
        {
            if (chekMap.Checked == true)
            {
                VerMapa.Visible = true;
                Presentacion.Visible = false;
            }
            else
            {
                VerMapa.Visible = false;
                Presentacion.Visible = false;
            }
        }



        protected void ddlUsoSueloRustico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int va = int.Parse(ddlUsoSueloRustico.SelectedIndex.ToString());
            predios.usoSuelo = ddlUsoSueloRustico.SelectedValue.ToString();
            //Label1.Text = va.ToString();
            try
            {
                ddlTipoSRustico.ClearSelection();
                ddlTipoSRustico.Items.Clear();
                ddltipoSueloRustico(va);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ddltipoSueloRustico(int id)
        {
            try
            {
                //hacer SP para obteer los datos
                ddlTipoSRustico.Items.Insert(0, new ListItem("Tipo"));
                switch (id)
                {
                    case 1:

                        ddlTipoSRustico.Items.Insert(1, new ListItem("Temporal 1a"));
                        ddlTipoSRustico.Items.Insert(2, new ListItem("Temporal 2a"));
                        ddlTipoSRustico.Items.Insert(3, new ListItem("Riego"));
                        break;
                    case 2:
                        ddlTipoSRustico.Items.Insert(1, new ListItem("Agostadero de temporal"));
                        ddlTipoSRustico.Items.Insert(2, new ListItem("Agostadero incluido"));
                        break;
                    case 3:
                        ddlTipoSRustico.Items.Insert(1, new ListItem("Monte Alto"));
                        ddlTipoSRustico.Items.Insert(2, new ListItem("Monte Bajo"));
                        ddlTipoSRustico.Items.Insert(3, new ListItem("Bosque de Monaña"));
                        break;
                    case 4:
                        ddlTipoSRustico.Items.Insert(1, new ListItem("Canteras"));
                        ddlTipoSRustico.Items.Insert(2, new ListItem("Minas"));
                        break;
                    case 5:
                        ddlTipoSRustico.Items.Insert(1, new ListItem("Eriazo"));
                        break;
                    default:
                        ddlTipoSRustico.ClearSelection();
                        ddlTipoSRustico.Items.Clear();
                        break;
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void ddlTipoSRustico_SelectedIndexChanged(object sender, EventArgs e)
        {
            predRustico.tipoSuelo = ddlTipoSRustico.SelectedValue.ToString();
            switch (ddlTipoSRustico.SelectedValue.ToString())
            {
                case "Temporal 1a":
                    txtClave.Text = "RAT 01";

                    break;
                case "Temporal 2a":
                    txtClave.Text = "RAT 02";
                    break;
                case "Riego":
                    txtClave.Text = "RAT 03";
                    break;
                case "Agostadero de temporal":
                    txtClave.Text = "RGA 04";
                    break;
                case "Agostadero incluido":
                    txtClave.Text = "RGA 05";
                    break;
                case "Monte Alto":
                    txtClave.Text = "RFM 06";
                    break;
                case "Monte Bajo":
                    txtClave.Text = "RFM 07";
                    break;
                case "Bosque de Monaña":
                    txtClave.Text = "RFB 08";
                    break;
                case "Canteras":
                    txtClave.Text = "REC 09";
                    break;
                case "Minas":
                    txtClave.Text = "REM 10";
                    break;
                case "Eriazo":
                    txtClave.Text = "RER 11";
                    break;
                default:
                    txtClave.Text = "Clave";
                    break;
            }
            predRustico.clave = txtClave.Text;
        }

        protected void ddlDesnivelUrbano_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor1 = int.Parse(ddlDesnivelUrbano.SelectedIndex.ToString());//obtiene el indice del elemento
            predUrbano.exisDesnivel = ddlDesnivelUrbano.SelectedValue.ToString();

            if (valor1 == 1)
            {
                TipodesnivelUrb.Visible = true;
                ddlTipoDesnivelUrbano.Items.Clear();
                ddlTipoDesnivelUrbano.ClearSelection();
                verTipoDesnivelUrbano();                
            }
            else
            {
                TipodesnivelUrb.Visible = false;
                predUrbano.tipoDesnivel = "NO APLICA";
            }
        }

        public void verTipoDesnivelUrbano()
        {
            try
            {
                ddlTipoDesnivelUrbano.Items.Insert(0, new ListItem("Tipo"));
                ddlTipoDesnivelUrbano.Items.Insert(1, new ListItem("Poco Hundido"));// Factor de topografia devuelto 0.85
                ddlTipoDesnivelUrbano.Items.Insert(2, new ListItem("Muy Hundido"));//Factor de Topografia 0.70
                ddlTipoDesnivelUrbano.Items.Insert(3, new ListItem("Poco Elevado"));//Factor de topografia devuelto 0.9
                ddlTipoDesnivelUrbano.Items.Insert(4, new ListItem("Muy Elevado"));//Factor de Topografia 0.80
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void ddlUbicacionManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cad = ddlUbicacionManzana.SelectedValue.ToString();
            predios.ubicacion = cad;
            switch (cad)
            {
                case "Cabecera de manzana":
                    try
                    {
                        ddlTipoVialidad.ClearSelection();
                        TipoVialidad.Visible = true;
                        AngulosEsq.Visible = false;
                        TieneEsquina.Visible = true;
                        EsquinasColin.Visible = false;
                        ddlTipoVialidad.Items.Insert(0, new ListItem("¿Alguna de las vialidades que rodea el predio pertecenece a ?"));
                        ddlTipoVialidad.Items.Insert(1, new ListItem("Andador"));//devolver 1
                        ddlTipoVialidad.Items.Insert(2, new ListItem("Callejón"));//devolver 1
                        ddlTipoVialidad.Items.Insert(3, new ListItem("Privada"));//devolver 1
                        ddlTipoVialidad.Items.Insert(4, new ListItem("Ninguno"));//devolver 0
                        predUrbano.anguloEsquinas = "NO APLICA";
                        predUrbano.noEsquinasColinadantes = "NO APLICA";


                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                    break;
                case "Esquina":
                    //preguntar sobre los angulos de las esquinas 
                    //si angulo > 135 y angulo < 45 regreso 1 
                    // y si no regreso un 0 y preguntar si las esquinas estan formadas por andador callejon o privada
                    TieneEsquina.Visible = true;
                    TipoVialidad.Visible = true;
                    AngulosEsq.Visible = true;
                    EsquinasColin.Visible = false;
                    break;
                case "Lote manzanero":
                    TieneEsquina.Visible = true;
                    TipoVialidad.Visible = true;
                    EsquinasColin.Visible = true;
                    ddlTipoVialidad.Items.Insert(0, new ListItem("¿Alguna de las vialidades que rodea el predio pertecenece a ?"));
                    ddlTipoVialidad.Items.Insert(1, new ListItem("Andador"));//devolver 1
                    ddlTipoVialidad.Items.Insert(2, new ListItem("Callejón"));//devolver 1
                    ddlTipoVialidad.Items.Insert(3, new ListItem("Privada"));//devolver 1
                    ddlTipoVialidad.Items.Insert(4, new ListItem("Ninguno"));//devolver 0

                    break;
                default:
                    TipoVialidad.Visible = false;
                    TieneEsquina.Visible = false;
                    AngulosEsq.Visible = false;
                    EsquinasColin.Visible = false;

                    ddlTipoVialidad.ClearSelection();
                    txtNoTotalEsquinas.Text = "";

                    predUrbano.vialidad= "NO APLICA";
                    predUrbano.noesquinas = "NO APLICA";
                    predUrbano.anguloEsquinas="NO APLICA";
                    predUrbano.noEsquinasColinadantes = "NO APLICA";
                    break;
            }
        }

        protected void txtFrenterustico_TextChanged(object sender, EventArgs e)
        {
            valoresCalculo.valorFrente = float.Parse(txtFrenterustico.Text);
            predUrbano.frente = txtFrenterustico.Text + " m";

            if (valoresCalculo.valorFrente < 1.5)
            {
                //   Response.Write("<script>alert('El frente no puede ser menor a 1.5m, por favor verifique.')</script>");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','El frente no puede ser menor a 1.5m, por favor verifique.')", true);
                txtFrenterustico.Text = "";
                txtFrenterustico.BorderColor = Color.Red;
                txtFrenterustico.BorderWidth = 2;
                predUrbano.fraccionamiento = "";
            }
            else if (valoresCalculo.valorFrente < 6.0)
            {              
                txtFrenterustico.BorderColor = Color.Transparent;
                txtFrenterustico.BorderWidth = 0;
                //Habilitar caja de texto para 
                ddlPreguntaFraccionamiento.ClearSelection();
                ddlPreguntaFraccionamiento.Items.Clear();
                //llenar ddl
                ddlPreguntaFraccionamiento.Items.Insert(0, new ListItem("FRACCIONAMIENTO/UNIDAD DE INTERES SOCIAL"));
                ddlPreguntaFraccionamiento.Items.Insert(1, new ListItem("SÍ")); //envio 1
                ddlPreguntaFraccionamiento.Items.Insert(2, new ListItem("NO")); // envio 0
                
                PreguntaFraccionamiento.Visible = true;
            }
            else
            {
                PreguntaFraccionamiento.Visible = false;
                predUrbano.fraccionamiento = "NO APLICA";
            }
         
        }

        protected void RDBntConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RDBntConstruccion.SelectedValue.ToString())
            {
                case "SI":
                    //Habilita Construcciones
                    btnFactorConstruccion.Enabled = true;
                    btnTerminar.Enabled = false;
                    break;
                case "NO":
                    //NO HABILITA NADA
                    btnFactorConstruccion.Enabled = false;
                    btnTerminar.Enabled = true;
                    break;
                default:
                    //NO HABILITA NADA
                    btnFactorConstruccion.Enabled = false;
                    btnTerminar.Enabled = false;
                    break;
            }
        }

        protected void btnCabeceroManzana_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 1;
        }

        protected void btnEsquinaa_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 2;
        }

        protected void btnCnAccPropio_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 3;
        }

        protected void btnSNAccPropio_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 4;
        }

        protected void btnIntermedio2Fr_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 5;
        }

        protected void btnInterReg_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 6;
        }

        protected void btnManzaneroo_Click(object sender, ImageClickEventArgs e)
        {
            ddlUbicacionManzana.SelectedIndex = 7;
        }

        protected void btnSiguiente1_Click(object sender, EventArgs e)
        {
            try
            {
                if (usoSuelo.tipoPredio == "RÚSTICO")
                {
                    if (txtParaje.Text == string.Empty)
                    {
                        txtParaje.BorderColor = Color.Red;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE COMPLETAR LOS CAMPOS.')", true);
                    }
                    else
                    {
                        //debe entrar al siguiente apartado y habilitar el boton FACTOR TERRENO                     
                        btnFactorTerreno.Enabled = true;
                        fFactorTerreno();
                        //checkUbicarPredio.Checked = true;
                    }
                }
                else
                {
                    if (ddlLocalidad.SelectedIndex == 0 && ddlZonaValor.SelectedIndex == 0)
                    {
                        ddlLocalidad.BorderColor = ddlZonaValor.BorderColor = Color.Red;
                        ddlLocalidad.BorderWidth = ddlZonaValor.BorderWidth = 3;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE COMPLETAR LOS CAMPOS.')", true);
                        //checkUbicarPredio.Checked = false;
                    }
                    else if (ddlLocalidad.SelectedIndex == 0)
                    {
                        txtParaje.BorderColor = Color.Red;
                        ddlZonaValor.BorderWidth = 3;
                        ddlZonaValor.BorderColor = Color.Transparent;
                        ddlZonaValor.BorderWidth = 0;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','DEBE COMPLETAR LOS CAMPOS.')", true);
                        //checkUbicarPredio.Checked = false;
                    }
                    else if (ddlZonaValor.SelectedIndex == 0)
                    {
                        ddlLocalidad.BorderColor = ddlZonaValor.BorderColor = Color.Transparent;
                        ddlLocalidad.BorderWidth = ddlZonaValor.BorderWidth = 0;
                        ddlZonaValor.BorderColor = Color.Red;
                        ddlZonaValor.BorderWidth = 3;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','DEBE COMPLETAR LOS CAMPOS.')", true);
                        //checkUbicarPredio.Checked = false;
                    }
                    else
                    {
                        ddlZonaValor.BorderColor = Color.Transparent;
                        ddlZonaValor.BorderWidth = 0;
                        //debe entrar al siguiente apartado y habilitar el boton FACTOR TERRENO 

                        btnFactorTerreno.Enabled = true;
                        fFactorTerreno();
                        //checkUbicarPredio.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void RBUDMSuperficie_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RBUDMSuperficie.SelectedValue.ToString())
            {
                case "m²":
                    txtSuperficieRu.Text = Conversiones.converMetrosM(txtSuperficieRu.Text);
                    predios.superficie = txtSuperficieRu.Text + " m²";
                    break;
                case "ha":
                    txtSuperficieRu.Text = Conversiones.converHA(txtSuperficieRu.Text);
                    predios.superficie = txtSuperficieRu.Text + " ha";
                    break;
                default: //NO HABILITA NADA                   
                    break;
            }


        }

        protected void txtSuperficieRu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (RBUDMSuperficie.SelectedValue == "")
                //{
                //    Response.Write("<script>alert('Debe elegir una opcion')</script>");
                //}
                //else
                //{
                RBUDMSuperficie.SelectedValue = "m²";
                txtSuperficieRu.Text = Conversiones.converMetrosM(txtSuperficieRu.Text);

                predios.superficie = txtSuperficieRu.Text + " " + RBUDMSuperficie.SelectedValue;
                // }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void crearTablaC()
        {
            tabla.Columns.Clear();
            tabla.Rows.Clear();
            DataColumn c0 = new DataColumn("AvanceObra");
            DataColumn c1 = new DataColumn("Habitada");
            DataColumn c2 = new DataColumn("Superficie");
            DataColumn c3 = new DataColumn("Clasificacion");
            DataColumn c4 = new DataColumn("Tipo");
            DataColumn c5 = new DataColumn("Calidad");
            DataColumn c6 = new DataColumn("Conservacion");
            DataColumn c7 = new DataColumn("Edad");
            DataColumn c8 = new DataColumn("Condominio");
            DataColumn c9 = new DataColumn("SupPriv");
            DataColumn c10 = new DataColumn("SupInd");
            DataColumn c11 = new DataColumn("ObrasComp");
            DataColumn c12 = new DataColumn("ObraCM");
            DataColumn c13 = new DataColumn("CalidadObra");

            //for (int i =0; i < 11; i++)
            //{
            //    tabla.Columns.Add(c+i);
            //}
            tabla.Columns.Add(c0);
            tabla.Columns.Add(c1);
            tabla.Columns.Add(c2);
            tabla.Columns.Add(c3);
            tabla.Columns.Add(c4);
            tabla.Columns.Add(c5);
            tabla.Columns.Add(c6);
            tabla.Columns.Add(c7);
            tabla.Columns.Add(c8);
            tabla.Columns.Add(c9);
            tabla.Columns.Add(c10);
            tabla.Columns.Add(c11);
            tabla.Columns.Add(c12);
            tabla.Columns.Add(c13);
        }
        protected void btnAddList_Click(object sender, ImageClickEventArgs e)
        {

            if (ddlAvanceConstruccion.SelectedIndex == 0 || ddlHabitada.SelectedIndex == 0 || txtSuperficieObra.Text == "" || ddlClasPred.SelectedIndex == 0 || ddlTipoConstruccion.SelectedIndex == 0
                || ddlCalidadConstruccion.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR/RELLENAR TODOS LOS CAMPOS')", true);
            }
            else
            {
                DataRow fila = tabla.NewRow();
                fila["AvanceObra"] = ddlAvanceConstruccion.SelectedValue.ToString();
                fila["Habitada"] = ddlHabitada.SelectedValue.ToString();
                fila["Superficie"] = txtSuperficieObra.Text;
                fila["Clasificacion"] = ddlClasPred.SelectedValue.ToString();
                fila["Tipo"] = ddlTipoConstruccion.SelectedValue.ToString();
                fila["Calidad"] = ddlCalidadConstruccion.SelectedValue.ToString();
                fila["Condominio"] = RadBtnCondominio.SelectedValue.ToString();
                fila["ObrasComp"] = RBObrasComplementarias.SelectedValue.ToString();
                if (RadBtnCondominio.SelectedValue.ToString() == "SI")
                {
                    fila["SupPriv"] = txtSupPriv.Text;
                    fila["SupInd"] = txtSubInd.Text;
                }
                else
                {
                    fila["SupPriv"] = "NO APLICA";
                    fila["SupInd"] = "NO APLICA";
                }
                if (RBObrasComplementarias.SelectedValue.ToString() == "SI")
                {
                    fila["ObraCM"] = ddlObraComplementaria.SelectedValue.ToString();
                    fila["CalidadObra"] = ddlCalidadObra.SelectedValue.ToString();
                }
                else
                {
                    fila["ObraCM"] = "NO APLICA";
                    fila["CalidadObra"] = "NO APLICA";
                }
                if (ddlCoservacion.SelectedIndex == 0)
                {
                    fila["Conservacion"] = "NO APLICA";
                }
                else
                {
                    fila["Conservacion"] = ddlCoservacion.SelectedValue.ToString();
                }
                if (ddlEdadConstruccion.SelectedIndex == 0)
                {
                    fila["Edad"] = "NO APLICA";
                }
                else
                {
                    fila["Edad"] = ddlEdadConstruccion.SelectedValue.ToString();
                }

                tabla.Rows.Add(fila);
            }
            //Limpiar todo lo seleccionado
            ddlAvanceConstruccion.ClearSelection();
            ddlHabitada.ClearSelection();
            txtSuperficieObra.Text = "";
            ddlClasPred.ClearSelection();
            ddlTipoConstruccion.ClearSelection();
            ddlCalidadConstruccion.ClearSelection();
            ddlCoservacion.ClearSelection();
            ddlEdadConstruccion.ClearSelection();
            txtSupPriv.Text = "";
            txtSubInd.Text = "";
            ddlObraComplementaria.ClearSelection();
            ddlCalidadObra.ClearSelection();
            //llena el gridview nuevamente
            GVConstrucciones.DataSource = tabla;
            GVConstrucciones.DataBind();

        }

        protected void ddlObraComplementaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    ddlLocalidad.ClearSelection();
                    ddlLocalidad.Items.Clear();
                    llenaCalidadObra(15, ddlObraComplementaria.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void llenaCalidadObra(int opc, string cal)
        {
            if (IsPostBack)
            {
                try
                {
                    //  cata.CatCalidadObra
                    DataTable ddt;
                    ddt = catt.CatCalidadObra(opc, cal);//--> Catalogo Municipio
                    ddlCalidadObra.DataSource = ddt;
                    ddlCalidadObra.DataValueField = "CALIDAD_OBRA";
                    ddlCalidadObra.DataBind();
                    ddlCalidadObra.Items.Insert(0, new ListItem("CALIDAD OBRA"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void RBObrasComplementarias_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RBObrasComplementarias.SelectedValue.ToString())
            {
                case "SI":
                    obrasComplementarias.Visible = true;
                    llenaCatObraComp();
                    break;
                case "NO":
                    obrasComplementarias.Visible = false;
                    break;
                default:
                    //NO HABILITA NADA
                    break;
            }
        }

        protected void RadBtnCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RadBtnCondominio.SelectedValue.ToString())
            {
                case "SI":
                    condominio.Visible = true;
                    llenaCatObraComp();
                    break;
                case "NO":
                    condominio.Visible = false;
                    break;
                default:
                    //NO HABILITA NADA
                    break;
            }
        }

        protected void GVConstrucciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    if (e.CommandName.Equals("eliminar"))
                    {
                        int rowIndex = int.Parse(e.CommandArgument.ToString());
                        string user = (string)this.GVConstrucciones.DataKeys[rowIndex]["AvanceObra"];
                        Response.Write("<script>alert('Borro la opción: " + rowIndex + " usuario: " + user + "')</script>");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','Esta re')", true);
                        tabla.Rows[rowIndex].Delete();
                        GVConstrucciones.DataSource = tabla;
                        GVConstrucciones.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");//Se podria sustiruir por pagina error 404
            }
        }


        protected void ddlUsoSueloUrbano_TextChanged(object sender, EventArgs e)
        {
            predios.usoSuelo = ddlUsoSueloUrbano.SelectedValue.ToString();
        }

        protected void ddlTopografiaRustico_SelectedIndexChanged(object sender, EventArgs e)
        {
            predios.topoReliev = ddlTopografiaRustico.SelectedValue.ToString();
        }
        protected void ddlUbicaciónRustico_SelectedIndexChanged(object sender, EventArgs e)
        {
            predios.ubicacion = ddlUbicaciónRustico.SelectedValue.ToString();
        }
        protected void txtParaje_TextChanged(object sender, EventArgs e)
        {
            predRustico.paraje = txtParaje.Text;
        }
        protected void txtDistanciaRustico_TextChanged(object sender, EventArgs e)
        {
            predRustico.distanciaPredio = txtDistanciaRustico.Text + " " + ddlDistanciaUDM.SelectedValue.ToString();
        }
        //DATOS PARA PREDIO  URBANO 
        protected void txtSuperficieUrbano_TextChanged(object sender, EventArgs e)
        {
            predios.superficie = txtSuperficieUrbano.Text+" m²";
        }


        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.localidad = ddlLocalidad.SelectedValue.ToString();
        }
        protected void ddlZonaValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.zonaValor = ddlZonaValor.SelectedValue.ToString();
        }
        protected void txtCalle_TextChanged(object sender, EventArgs e)
        {
            predUrbano.calle = txtCalle.Text;
        }
        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            predUrbano.numero = int.Parse(txtNumero.Text);
        }

        protected void txtColonia_TextChanged(object sender, EventArgs e)
        {
            predUrbano.colonia = txtColonia.Text;
        }
        protected void txtProfundidad_TextChanged(object sender, EventArgs e)
        {
            predUrbano.profundidad = txtProfundidad.Text +" m";
        }

        protected void ddlTipoDesnivelUrbano_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.tipoDesnivel = ddlTipoDesnivelUrbano.SelectedValue.ToString();
        }

        protected void ddlTipoVialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.vialidad = ddlTipoVialidad.SelectedValue.ToString();
        }


        protected void txtNoTotalEsquinas_TextChanged(object sender, EventArgs e)
        {
            predUrbano.noesquinas = txtNoTotalEsquinas.Text;
        }
        protected void ddlPreguntaFraccionamiento_TextChanged(object sender, EventArgs e)
        {

            if (ddlPreguntaFraccionamiento.SelectedValue.ToString() == "NO")
            {

                //Llamar WS del Calcular valor MONY
                predUrbano.fraccionamiento = "NO APLICA";
            }
            else
            {
                predUrbano.fraccionamiento = "SI PERTENECE";
                //factor a 1
            }
        }


        protected void btnVerificaInfo_Click(object sender, EventArgs e)
        {
            if (predios.tipoPredio == "RÚSTICO")
            {//para enviar informacion de predios rusticos
                cleanUrbanos clU = new cleanUrbanos();
                clU.cleanUr();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "OpenModalVerificacionRUS('" + predios.municipio.ToUpper() + "','" + predios.tipoPredio.ToUpper() + "'," +
                "'" + predios.superficie + "','" + predios.usoSuelo + "','" + predios.topoReliev + "','" + predios.ubicacion + "','" + predRustico.paraje + "','" + predRustico.tipoSuelo + "'" +
                ",'" + predRustico.clave + "','" + predRustico.distanciaPredio + "','"+predios.tieneConst+"')", true);



            }
            else //para enviar informacion de predios urbanos
            {
                cleanRusticos clU = new cleanRusticos();
                clU.cleanR();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "OpenModalVerificacionURB('" + predios.municipio.ToUpper() + "','" + predios.tipoPredio.ToUpper() + "'," +
                "'" + predios.superficie + "','" + predios.usoSuelo.ToUpper() + "','" + predios.topoReliev + "','" + predios.ubicacion.ToUpper() + "','"+ predUrbano.localidad.ToUpper() + "'" +
                ",'"+ predUrbano.zonaValor + "','" + predUrbano.calle.ToUpper() + "','" + predUrbano.numero + "','" + predUrbano.colonia.ToUpper() + "','"+predUrbano.cp+"','" + predUrbano.frente + "'," +
                "'"+ predUrbano.profundidad + "','"+ predUrbano.exisDesnivel.ToUpper() + "','"+ predUrbano.tipoDesnivel + "','"+ predUrbano.vialidad + "','" + predUrbano.noesquinas + "','"+ predUrbano.anguloEsquinas + "'," +
                "'" + predUrbano.noEsquinasColinadantes + "','" + predUrbano.fraccionamiento + "','" + predios.tieneConst + "')", true);
               

            }

        }

        public void habilitaRusticos()
        {
            lblVerifParaje.Visible =lblVerifTipoUsSuelo.Visible =   lblVerifClave.Visible =  lblVerifDisPred.Visible = true;

        }
        public void habilitaUrbano()
        {
            lblVerifLocalidad.Visible = true;
            lblVerifZonaVal.Visible = true;
            lblVerifCalle.Visible = true;
            lblVerifNumero.Visible = true;
            lblVerifColonia.Visible = true;
            lblVerifCP.Visible = true;
            lblVerifFrente.Visible = true;
            lblVerifProfundidad.Visible = true;
            lblVerifExisDesnivel.Visible = true;
            lblVerifTipoDesNiv.Visible = true;
            lblVerifVialidad.Visible = true;
            lblVerifNoEsqTotales.Visible = true;
            lblVerifAnguloEsq.Visible = true;
            lblVerifNoEsqCol.Visible = true;
            lblVerifFraccionamiento.Visible = true;
            lblVerifParaje.Visible = lblVerifTipoUsSuelo.Visible = lblVerifClave.Visible = lblVerifDisPred.Visible = true;
        }




    }

}