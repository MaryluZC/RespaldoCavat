using Cavat.data;
using InfoUsuarios;
using InfoUsuarios.cache;
using InfoUsuarios.infoPredio;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Cavat
{

    public partial class Notarios : System.Web.UI.Page
    {

        catalogos cat = new catalogos();// ELIMINAR UNA VES QUE HAYAN QUEDADO LOS SERVICIOS
        Catalogos catt = new Catalogos();//CAPA COMUN //ELIMINAR UNA VES QUE HAYAN QUEDADO LOS SERVICIO        
        resultado rs = new resultado();
        catalogos catalog = new catalogos();// servicio WEB 
        DataSet dsaux = new DataSet();
        private static DataTable tabla = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//lo que solo se ejeuta una vez
            {
                crearTablaC();//Crea la tabla inicial para poder alamcenar informacion temporal
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
                    llenarCatalgos(10, "clasificacionConstruccion", ddlClasPred, "CLASIFICACIÓN DE CONSTRUCCIÓN");
                    llenarCatalgos(19, "estadoConservacion", ddlCoservacion, "ESTADO DE CONSERVACIÓN");
                    ddlEdadConstruc();
                    //limpiar campos
                }
                else
                {
                    var random = new Random();
                    var r1 = random.Next(1, 999999);
                    lblFOLIOT.Text = Convert.ToString(r1);
                }
            }
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
        public String esCentralizado(string municipio)//Corregir a Filtrar desde la tabla que ya se tiene
        {
            string cent = "";
            if (municipio == "MUNICIPIO")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UN MUNICIPIO.')", true);
            }
            else
            {
                DataSet ds = new DataSet();
                DataTable dtAux = new DataTable();
                ds = VerCatalogo(4);
                dtAux = ds.Tables[0];//devulve municipios Centralizados
                EnumerableRowCollection<DataRow> query = from fila in dtAux.AsEnumerable()
                                                         where fila.Field<String>("MUNICIPIO") == municipio
                                                         select fila;
                DataTable dt1 = query.CopyToDataTable();
                cent = dt1.Rows[0]["esCentralizado"].ToString();

            }
            return cent;
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
                llenarCatalgos(4, "municipio", ddlMunicipio, "MUNICIPIO");
                llenarCatalgos(6, "tipoPredio", ddlTipoPredio, "TIPO PREDIO");
            }
        }

        protected void btnFactorTerreno_Click(object sender, ImageClickEventArgs e)
        {
            fFactorTerreno();
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


                ddlTopografiaRustico.ClearSelection();
                ddlTopografiaRustico.Items.Clear();
                verCatalogoCompartido(17, 2, ddlTopografiaRustico, "TOPOGRAFIA", "Topografia");

                ddlDistanciaUDM.ClearSelection();
                ddlDistanciaUDM.Items.Clear();
                ddlUDMDistancia();
                ddlUbicaciónRustico.ClearSelection();
                ddlUbicaciónRustico.Items.Clear();
                //ddlUbicacionRustic();
                verCatalogoCompartido(9, 2, ddlUbicaciónRustico, "UBICACIÓN PREDIO", "Ubicacion");
                ddlTipoSRustico.ClearSelection();
                verCatalogoCompartido(16, 2, ddlTipoSRustico, "TIPO TERRENO", "usoSuelo");//USO DE SUELO URBANO
                //cuando cambie vaciar los componentes del otro
            }
            else
            {
                lbltipoPredio.Text = usoSuelo.tipoPredio;
                UbicacionPredio.Visible = false;
                FactorTerreno.Visible = true;
                ContentUrbano.Visible = true;
                ContentRustico.Visible = false;

                verCatalogoCompartido(9, 1, ddlUbicacionManzana, "UBICACIÓN EN MANZANA", "Ubicacion");
                //cuando cambie vaciar los componentes del otro
                ddlUsoSueloUrbano.ClearSelection();
                verCatalogoCompartido(16, 1, ddlUsoSueloUrbano, "USO DE SUELO", "usoSuelo");//USO DE SUELO URBANO

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
            llenarCatalgos(13, "avance", ddlAvanceConstruccion, "AVANCE DE OBRA");
            btnTerminar.Enabled = true;
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int va = int.Parse(ddlMunicipio.SelectedIndex.ToString());
                predios.municipio = ddlMunicipio.SelectedValue.ToString();//Envia a la variable el valor del municipio
                string centralizado = esCentralizado(ddlMunicipio.SelectedValue.ToString());
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('" + centralizado + "')", true);

                try
                {
                    int val = int.Parse(ddlTipoPredio.SelectedIndex.ToString());
                    ddlLocalidad.ClearSelection();
                    ddlLocalidad.Items.Clear();
                    ddlLocalidadD(8, va);

                    if (centralizado == "True")//Se toma la informacion de serverbox
                    {
                        if (val == 2)//RUSTICO
                        {
                            verZonaValor(7, ddlMunicipio.SelectedIndex, 'R', "2022");
                        }
                        else if (val == 1 || va == 3)//URBANO Y SUBURBANO
                        {
                            verZonaValor(7, ddlMunicipio.SelectedIndex, 'U', "2022");
                        }
                        else
                        {

                        }
                    }
                    else//se debe tomar la informacion de la base de datos "local"
                    {
                        if (val == 2)//RUSTICO
                        {
                            verZonaValorDescentralizados(20, ddlMunicipio.SelectedValue, val, "2022");//rustico
                        }
                        else if (va == 1 || va == 3)//URBANO Y SUBURBANO
                        {
                            verZonaValorDescentralizados(20, ddlMunicipio.SelectedValue, val, "2022");//urbano
                        }
                        else
                        {

                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

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
            if (IsPostBack)
            {
                if (ddlTipoPredio.SelectedIndex != 0)
                {
                    ddlTipoPredio.BorderColor = Color.Transparent;
                    ddlTipoPredio.BorderWidth = 0;
                    int va = int.Parse(ddlTipoPredio.SelectedIndex.ToString());//Label1.Text = va.ToString();
                    predios.tipoPredio = usoSuelo.tipoPredio = ddlTipoPredio.SelectedValue.ToString();//Envia la informacion al valor statico del preedio
                    ddlZonaValor.ClearSelection();
                    ddlMunicipio.Enabled = true;
                    try
                    {
                        if (va == 2)//rústico
                        {
                            tagParaje.Visible = true;
                            tagLocalidad.Visible = false;
                            tagZonaValor.Visible = false;
                            tagCalle.Visible = tagNumero.Visible = tagCP.Visible = false;
                            //Poner conteedor Urbao y Suburabao en false
                            //VER COMO OBTENER EL VALOR DEL 

                        }
                        else if (va == 1 || va == 3)
                        { //Urban o suburbano
                            tagParaje.Visible = false;
                            txtParaje.Text = "";
                            tagLocalidad.Visible = true;
                            tagZonaValor.Visible = true;
                            tagCalle.Visible = true;
                            tagNumero.Visible = tagCP.Visible = true;
                        }
                        else
                        {
                            //ddlSuperficieRustico.Visible = false;//Sustituir por seleccion UDM
                            tagParaje.Visible = tagCalle.Visible = tagNumero.Visible = tagCP.Visible = false;
                            tagLocalidad.Visible = false;
                            tagZonaValor.Visible = false;
                            //Falta vaciar cada componente
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UNA OPCIÓN.')", true);
                    ddlMunicipio.Enabled = false;

                }
            }
        }

        public void verZonaValor(int opc, int idmun, char tipoPredio, string annio)
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = catt.CatZonasValor(opc, idmun, tipoPredio, annio); //--> Catalogo Municipio
                    ddlZonaValor.DataSource = ddt;
                    ddlZonaValor.DataValueField = "nombreZona";
                    ddlZonaValor.DataBind();
                    ddlZonaValor.Items.Insert(0, new ListItem("ZONA VALOR"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void verZonaValorDescentralizados(int opc, string idmun, int tipoPredio, string annio)
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = catt.CatZonasValorDes(opc, idmun, tipoPredio, annio); //--> Catalogo Municipio
                    ddlZonaValor.DataSource = ddt;
                    ddlZonaValor.DataValueField = "ZonaValor";
                    ddlZonaValor.DataBind();
                    ddlZonaValor.Items.Insert(0, new ListItem("ZONA VALOR"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
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


        public void verCatalogoCompartido(int opc, int idtipoPredio, DropDownList lista, string ubicacion, string columnna)
        {
            try
            {
                DataTable ddt;
                ddt = catt.CatUsoSuelo(opc, idtipoPredio);//--> Catalogo Municipio
                lista.DataSource = ddt;
                lista.DataValueField = columnna;//"Ubicacion";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem(ubicacion));
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
                    ddlTipoConstruccion.DataValueField = "tipoConstruccion";
                    ddlTipoConstruccion.DataBind();
                    ddlTipoConstruccion.Items.Insert(0, new ListItem("TIPO DE CONSTRUCCIÓN"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void ddlTipoConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {

            string va = ddlTipoConstruccion.SelectedValue.ToString();
            try
            {
                ddlCalidadConstruccion.ClearSelection();
                ddlCalidadPred(12, va, int.Parse(ddlClasPred.SelectedIndex.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ddlCalidadPred(int opc, string clv, int idClass) ///Devuelve el catalogo dependiendo de la opcion enviada por ddlClasificacion construccion
        {
            if (IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.CatClaseConstrucion(opc, clv, idClass);//--> Catalogo Municipio
                    ddlCalidadConstruccion.DataSource = ddt;
                    ddlCalidadConstruccion.DataValueField = "calidad";
                    ddlCalidadConstruccion.DataBind();
                    ddlCalidadConstruccion.Items.Insert(0, new ListItem("CALIDAD DE LA CONSTRUCIÓN"));
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


        protected void ddlDesnivelUrbano_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor1 = int.Parse(ddlDesnivelUrbano.SelectedIndex.ToString());//obtiene el indice del elemento
            predUrbano.exisDesnivel = ddlDesnivelUrbano.SelectedValue.ToString();

            if (valor1 == 1)//sI
            {
                ddlTipoDesnivelUrbano.Enabled = true;               
            }
            else//No
            {
                ddlTipoDesnivelUrbano.Enabled = false;
                predUrbano.tipoDesnivel = "NO APLICA";
                predUrbano.factorTopografia = 1.0;
            }
        }


        protected void ddlUbicacionManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cad = ddlUbicacionManzana.SelectedValue.ToString();
            predios.ubicacion = cad;
            switch (cad)
            {
                case "CABECERA DE MANZANA":
                    try
                    {                     

                        ddlTipoVialidad.Enabled = true;
                        txtAnguloEsquinas.Enabled = false;
                        txtNoTotalEsquinas.Enabled = true;
                        txtNoEsquinasColinVialidad.Enabled = false;
                        //predUrbano.anguloEsquinas = "NO APLICA";
                        predUrbano.noEsquinasColinadantes = "NO APLICA";                     
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                    break;
                case "ESQUINA":
                    //preguntar sobre los angulos de las esquinas 
                    //si angulo > 135 y angulo < 45 regreso 1 
                    // y si no regreso un 0 y preguntar si las esquinas estan formadas por andador callejon o privada
                    txtNoTotalEsquinas.Enabled = true;
                    ddlTipoVialidad.Enabled = true;
                    txtAnguloEsquinas.Enabled = true;
                    txtNoEsquinasColinVialidad.Enabled = false;                                      
                    break;
                case "LOTE MANZANERO":
                    txtNoTotalEsquinas.Enabled = true;
                    ddlTipoVialidad.Enabled = true;
                    txtNoEsquinasColinVialidad.Enabled = true;

                    switch (predios.usoSuelo)
                    {
                        case "HABITACIONAL":
                            factorPredio.factorEsquina(predios.superficie, 1);
                            break;
                        case "COMERCIAL MEDIA":
                        case "COMERCIAL BAJA (COMERCIO DE BARRIO)":
                            factorPredio.factorEsquina(predios.superficie, 2);
                            break;
                        case "COMERCIAL ALTA (SUBSUELOS URBANOS O CENTROS COMERCIALES)":
                            factorPredio.factorEsquina(predios.superficie, 3);
                            break;
                        default:
                            factorPredio.factorEsquina(predios.superficie, 4);
                            break;
                    }

                    break;
                /// quiza jale
                case "LOTE INTERIOR CON ACCESO PROPIO":
                case "LOTE INTERIOR SIN ACCESO PROPIO":

                    //MADO EL  FACTOR UBICACION EN 0.5
                    predUrbano.factorUbicacion = 0.5;
                    ddlTipoVialidad.Enabled = false;
                    txtNoTotalEsquinas.Enabled = false;
                    txtAnguloEsquinas.Enabled = false;
                    txtNoEsquinasColinVialidad.Enabled = false;

                    ddlTipoVialidad.ClearSelection();
                    txtNoTotalEsquinas.Text = "";

                    predUrbano.vialidad = "NO APLICA";
                    predUrbano.noesquinas = "NO APLICA";
                    //predUrbano.anguloEsquinas = "NO APLICA";
                    predUrbano.noEsquinasColinadantes = "NO APLICA";
                    break;
                default:

                    //ENVIAR FACTOR UBICACION COMO 1
                    predUrbano.factorUbicacion = 1.0;
                    ddlTipoVialidad.Enabled = false;
                    txtNoTotalEsquinas.Enabled = false;
                    txtAnguloEsquinas.Enabled = false;
                    txtNoEsquinasColinVialidad.Enabled = false;

                    ddlTipoVialidad.ClearSelection();
                    txtNoTotalEsquinas.Text = "";

                    predUrbano.vialidad = "NO APLICA";
                    predUrbano.noesquinas = "NO APLICA";
                    //predUrbano.anguloEsquinas = "NO APLICA";
                    predUrbano.noEsquinasColinadantes = "NO APLICA";
                    break;
            }
        }

        protected void txtFrenterustico_TextChanged(object sender, EventArgs e)
        {
            predUrbano.tamfrente = Convert.ToDouble(txtFrenterustico.Text);

            if (predUrbano.tamfrente < 1.5)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','EL FRENTE NO PUEDE SER MENOR A MENOR A 1.5M, POR FAVOR VERIFICAR.')", true);
                txtFrenterustico.Text = "";
                txtFrenterustico.BorderColor = Color.Red;
                txtFrenterustico.BorderWidth = 2;
                predUrbano.fraccionamiento = "";
            }
            else if (predUrbano.tamfrente < 6.0)
            {
                txtFrenterustico.BorderColor = Color.Transparent;
                txtFrenterustico.BorderWidth = 0;
                //llenar ddl               
                ddlPreguntaFraccionamiento.Enabled = true;
            }
            else //Si es mayo a 6 el factor sera 1
            {
                ddlPreguntaFraccionamiento.Enabled = false;
                predUrbano.fraccionamiento = "NO APLICA";
                predUrbano.factorFrente = 1;
            }

        }
        protected void ddlPreguntaFraccionamiento_TextChanged(object sender, EventArgs e)
        {

            if (ddlPreguntaFraccionamiento.SelectedValue.ToString() == "NO")
            {
                //Llamar WS del Calcular valor MONY
                predUrbano.factorFrente = factorPredio.factorFrente(predUrbano.tamfrente);

                predUrbano.fraccionamiento = "NO APLICA";
            }
            else
            {
                predUrbano.fraccionamiento = "SI PERTENECE";
                //factor a 1
                predUrbano.factorFrente = 1;
            }
        }
        protected void txtProfundidad_TextChanged(object sender, EventArgs e)
        {
            predUrbano.tamprofundidad = Convert.ToDouble(txtProfundidad.Text);

            if (predUrbano.tamprofundidad < 10.0)
            {
                //Aplica demerito
                predUrbano.factorProfundidad= factorPredio.factorProfundidad(predUrbano.tamfrente, predUrbano.tamprofundidad);
            }
            else//el tamaño de la profundidad es mayor a 10, por tanto el Factor de Profundidad es 1
            {
                predUrbano.factorProfundidad = 1.0;
            }
        }




        protected void RDBntConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RDBntConstruccion.SelectedValue.ToString())
            {
                case "SI":
                    //Habilita Construcciones
                    // btnFactorConstruccion.Enabled = true;
                    btnSiguienteConstr.Enabled = true;
                    btnTerminar.Enabled = false;
                   
                    break;
                case "NO":
                    //NO HABILITA NADA
                    //   btnFactorConstruccion.Enabled = false;
                    btnSiguienteConstr.Enabled = false;
                    btnTerminar.Enabled = true;
                    break;
                default:
                    //NO HABILITA NADA
                    //  btnFactorConstruccion.Enabled = false;
                    btnSiguienteConstr.Enabled = false;
                    btnTerminar.Enabled = false;
                    break;
            }
            predUrbano.factorResultanteTERRENO = factorPredio.FactoResultanteTerreno(predUrbano.factorFrente, predUrbano.factorProfundidad, predUrbano.factorTopografia, predUrbano.factorUbicacion, predios.factorSuperficie, predUrbano.factorEsquina);
           predios.ValorCatastralTerreno= factorPredio.ValorCatastralPredio(Convert.ToDouble(predUrbano.zonaValor), predUrbano.factorResultanteTERRENO, predios.superficie);
            lblValorFactorTerreno.Text = predios.ValorCatastralTerreno.ToString("C", new CultureInfo("us-US"));
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
                        btnUbicaPredio.BorderStyle = 0;
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
                        checkUbicarPredio.Checked = false;
                        btnUbicaPredio.BorderStyle = 0;
                    }
                    else if (ddlLocalidad.SelectedIndex == 0)
                    {
                        txtParaje.BorderColor = Color.Red;
                        ddlZonaValor.BorderWidth = 3;
                        ddlZonaValor.BorderColor = Color.Transparent;
                        ddlZonaValor.BorderWidth = 0;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','DEBE COMPLETAR LOS CAMPOS.')", true);
                        checkUbicarPredio.Checked = false;
                        btnUbicaPredio.BorderStyle = 0;
                    }
                    else if (ddlZonaValor.SelectedIndex == 0)
                    {
                        ddlLocalidad.BorderColor = ddlZonaValor.BorderColor = Color.Transparent;
                        ddlLocalidad.BorderWidth = ddlZonaValor.BorderWidth = 0;
                        ddlZonaValor.BorderColor = Color.Red;
                        ddlZonaValor.BorderWidth = 3;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','DEBE COMPLETAR LOS CAMPOS.')", true);
                        checkUbicarPredio.Checked = false;
                        btnUbicaPredio.BorderStyle = 0;
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
                checkUbicarPredio.Checked = true;
                btnUbicaPredio.Width = 10;
                btnUbicaPredio.BackColor = Color.Green;
                btnUbicaPredio.BorderColor = Color.LimeGreen;

                ddlPreguntaFraccionamiento.ClearSelection();
                ddlPreguntaFraccionamiento.Items.Insert(0, new ListItem("FRACCIONAMIENTO"));
                ddlPreguntaFraccionamiento.Items.Insert(1, new ListItem("SÍ")); //envio 1
                ddlPreguntaFraccionamiento.Items.Insert(2, new ListItem("NO")); // envio 0

                ddlTipoDesnivelUrbano.ClearSelection();
                verCatalogoCompartido(17, 1, ddlTipoDesnivelUrbano, "TIPO DESNIVEL", "Topografia");

                ddlTipoVialidad.ClearSelection();
                llenarCatalgos(21, "vialidad", ddlTipoVialidad, "¿EL PREDIO COLINDA CON ALGUNA VIALIDAD?");


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
                    predios.superficie = Convert.ToDouble(txtSuperficieRu.Text);
                    break;
                case "ha":
                    txtSuperficieRu.Text = Conversiones.converHA(txtSuperficieRu.Text);
                    predios.superficie = Convert.ToDouble(txtSuperficieRu.Text);
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

                predios.superficieRU = txtSuperficieRu.Text + " " + RBUDMSuperficie.SelectedValue;
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
                    llenarCatalgos(14, "obrasComplementarias", ddlObraComplementaria, "OBRA COMPLEMENTARIA");
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','Esta re')", true);
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
                    break;
                case "NO":
                    condominio.Visible = false;
                    txtSubInd.Text = "";
                    txtSupPriv.Text = "";
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
            predios.superficie =Convert.ToDouble(txtSuperficieUrbano.Text);
            if (predios.superficie < 1.0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','LA SUPERFICIE NO PUEDE SER MENOR A 1.0 m²')", true);
                predios.superficie = 0.0;
            }
            else
            {
                if (predios.usoSuelo == string.Empty)//ddlUsoSueloUrbano.SelectedValue LISTA DE usO DE SUELO URBANO
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','SELECCIONE EL USO DEL SUELO.')", true);
                }
                else if (predios.usoSuelo == "INDUSTRIAL")
                {
                    predios.factorSuperficie = 1;

                }
                else
                {
                    predios.factorSuperficie = factorPredio.factorSuperficie(predios.superficie);
                }
            }
        }


        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.localidad = ddlLocalidad.SelectedValue.ToString();
            ddlLocalidad.BorderWidth = 0;

            Response.Write("<script>alert('" + predUrbano.localidad + "')</script>");
        }

        protected void txtCalle_TextChanged(object sender, EventArgs e)
        {
            predUrbano.calle = txtCalle.Text;
        }
        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            predUrbano.numero = int.Parse(txtNumero.Text);
        }

        protected void ddlTipoDesnivelUrbano_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.tipoDesnivel = ddlTipoDesnivelUrbano.SelectedValue.ToString();
            if (predUrbano.tipoDesnivel=="TIPO DESNIVEL")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','SELECCIONE UN TIPO DE DESNIVEL.')", true);
            }
            else
            {
                switch (predUrbano.tipoDesnivel)
                {
                    case "POCO HUNDIDO":
                        predUrbano.factorTopografia = 0.85;
                        break;
                    case "MUY HUNDIDO":
                        predUrbano.factorTopografia = 0.70;
                        break;
                    case "POCO ELEVADO":
                        predUrbano.factorTopografia = 0.90;
                        break;
                    case "MUY ELEVADO":
                        predUrbano.factorTopografia = 0.80;
                        break;
                }
            }
        }

        protected void ddlTipoVialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.vialidad = ddlTipoVialidad.SelectedValue.ToString();
        }


        protected void txtNoTotalEsquinas_TextChanged(object sender, EventArgs e)
        {
            int categoria;
            predUrbano.noesquinas = txtNoTotalEsquinas.Text;
            if (predUrbano.vialidad=="OTROS")
            {
                categoria = 0;

            }
            else
            {
                categoria = 1;
            }

            switch (predios.usoSuelo)
            {
                case "HABITACIONAL":
                   predUrbano.factorUbicacion =factorPredio.factorCabeceroManza(predios.superficie, categoria, 1, int.Parse(predUrbano.noesquinas));
                    break;
                case "COMERCIAL MEDIA":
                case "COMERCIAL BAJA (COMERCIO DE BARRIO)":
                    predUrbano.factorUbicacion=factorPredio.factorCabeceroManza(predios.superficie, categoria, 2, int.Parse(predUrbano.noesquinas));
                    break;
                case "COMERCIAL ALTA (SUBSUELOS URBANOS O CENTROS COMERCIALES)":
                    predUrbano.factorUbicacion = factorPredio.factorCabeceroManza(predios.superficie, categoria, 3, int.Parse(predUrbano.noesquinas));
                    break;
                default:
                    predUrbano.factorUbicacion = factorPredio.factorCabeceroManza(predios.superficie, categoria, 4, int.Parse(predUrbano.noesquinas));
                    break;
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
                ",'" + predRustico.clave + "','" + predRustico.distanciaPredio + "','" + predios.tieneConst + "')", true);
            }
            else //para enviar informacion de predios urbanos
            {
                cleanRusticos clU = new cleanRusticos();
                clU.cleanR();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "OpenModalVerificacionURB('" + predios.municipio.ToUpper() + "','" + predios.tipoPredio.ToUpper() + "'," +
                "'" + predios.superficie + "','" + predios.usoSuelo.ToUpper() + "','" + predios.topoReliev + "','" + predios.ubicacion.ToUpper() + "','" + predUrbano.localidad.ToUpper() + "'" +
                ",'" + predUrbano.zonaValor + "','" + predUrbano.calle.ToUpper() + "','" + predUrbano.numero + "','" + predUrbano.colonia.ToUpper() + "','" + predUrbano.cp + "','" + predUrbano.factorFrente + "'," +
                "'" + predUrbano.tamprofundidad + "','" + predUrbano.exisDesnivel.ToUpper() + "','" + predUrbano.tipoDesnivel + "','" + predUrbano.vialidad + "','" + predUrbano.noesquinas + "','" + predUrbano.anguloEsquinas + "'," +
                "'" + predUrbano.noEsquinasColinadantes + "','" + predUrbano.fraccionamiento + "','" + predios.tieneConst + "')", true);
            }
        }

        protected void btnAgregaConstruccion_Click(object sender, ImageClickEventArgs e)
        {
            ContentAgregarConstruccion.Visible = true;
        }

        protected void btnAddList_Click(object sender, EventArgs e)
        {

            if (ddlAvanceConstruccion.SelectedIndex == 0 || txtSuperficieObra.Text == "" || ddlClasPred.SelectedIndex == 0 || ddlTipoConstruccion.SelectedIndex == 0
                || ddlCalidadConstruccion.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR/RELLENAR TODOS LOS CAMPOS')", true);
            }
            else
            {
                DataRow fila = tabla.NewRow();
                fila["AvanceObra"] = ddlAvanceConstruccion.SelectedValue.ToString();
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
            //      ContentAgregarConstruccion.Visible = false;
        }

        protected void ddlZonaValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlZonaValor.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UNA ZONA DE VALOR.')", true);
            }
            else
            {
                if (ddlMunicipio.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UN MUNICIPIO.')", true);
                }
                else
                {
                    Double valorZonza = 0.00;
                    DataTable dt = new DataTable();

                    if (predios.tipoPredio == "URBANO")
                    {
                        dt = catt.CatZonasValor(7, ddlMunicipio.SelectedIndex, 'U', "2022");
                    }
                    else if (predios.tipoPredio == "RUSTICO")
                    {
                        dt = catt.CatZonasValor(7, ddlMunicipio.SelectedIndex, 'R', "2022");
                    }
                    else
                    {
                        dt = catt.CatZonasValor(7, ddlMunicipio.SelectedIndex, 'S', "2022");
                    }

                    EnumerableRowCollection<DataRow> query = from fila in dt.AsEnumerable()
                                                             where fila.Field<String>("nombreZona") == ddlZonaValor.SelectedValue.ToString()
                                                             select fila;
                    DataTable dt1 = query.CopyToDataTable();
                    valorZonza = Convert.ToDouble(dt1.Rows[0]["valorM2"]);
                    predUrbano.zonaValor = valorZonza.ToString();  //envia el valor de la zona de valor a la variable statica que contendra el valor

                }
            }

           

        }

        protected void btnSiguienteConstr_Click(object sender, EventArgs e)
        {
            //Habilita Construcciones
            btnFactorConstruccion.Enabled = true;
            FactorConstruccion.Visible = true;
            UbicacionPredio.Visible = false;
            Presentacion.Visible = false;
            VerMapa.Visible = false;
            FactorTerreno.Visible = false;
            Georreferencia.Visible = false;
            ContentUrbano.Visible = false;
            ddlAvanceConstruccion.ClearSelection();
            btnTerminar.Enabled = false;
            btnTerminar.CssClass = "animate__animated animate__fadeInDown";
        }

        protected void txtNoEsquinasColinVialidad_TextChanged(object sender, EventArgs e)
        {
            int categoria;
            predUrbano.noEsquinasColinadantes = txtNoEsquinasColinVialidad.Text;
            if (predUrbano.vialidad == "OTROS")
            {
                categoria = 0;
            }
            else
            {
                categoria = 1;
            }
            switch (predios.usoSuelo)
            {
                case "HABITACIONAL":
                    predUrbano.factorUbicacion = factorPredio.factorManzanero(predios.superficie, categoria, 1, int.Parse(predUrbano.noesquinas), int.Parse(predUrbano.noEsquinasColinadantes));
                    break;
                case "COMERCIAL MEDIA":
                case "COMERCIAL BAJA (COMERCIO DE BARRIO)":
                    predUrbano.factorUbicacion = factorPredio.factorManzanero(predios.superficie, categoria, 2, int.Parse(predUrbano.noesquinas), int.Parse(predUrbano.noEsquinasColinadantes));
                    break;
                case "COMERCIAL ALTA (SUBSUELOS URBANOS O CENTROS COMERCIALES)":
                    predUrbano.factorUbicacion = factorPredio.factorManzanero(predios.superficie, categoria, 3, int.Parse(predUrbano.noesquinas), int.Parse(predUrbano.noEsquinasColinadantes));
                    break;
                default:
                    predUrbano.factorUbicacion = factorPredio.factorManzanero(predios.superficie, categoria, 4, int.Parse(predUrbano.noesquinas), int.Parse(predUrbano.noEsquinasColinadantes));
                    break;
            }
        }

        protected void txtAnguloEsquinas_TextChanged(object sender, EventArgs e)
        {
            predUrbano.anguloEsquinas = Convert.ToDouble(txtAnguloEsquinas.Text);

            if (predUrbano.anguloEsquinas<45.0 || predUrbano.anguloEsquinas>135.0) {
               predUrbano.factorEsquina = 1.0;
            }
            else{
                switch (predios.usoSuelo)
                {
                    case "HABITACIONAL":
                        predUrbano.factorEsquina = factorPredio.factorEsquina(predios.superficie, 1);
                        break;
                    case "COMERCIAL MEDIA":
                    case "COMERCIAL BAJA (COMERCIO DE BARRIO)":
                        predUrbano.factorEsquina = factorPredio.factorEsquina(predios.superficie, 2);
                        break;
                    case "COMERCIAL ALTA (SUBSUELOS URBANOS O CENTROS COMERCIALES)":
                        predUrbano.factorEsquina = factorPredio.factorEsquina(predios.superficie, 3);
                        break;
                    default:
                        predUrbano.factorEsquina = factorPredio.factorEsquina(predios.superficie, 4);
                        break;
                }
            }            
        }
    }
}