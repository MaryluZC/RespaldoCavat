using Cavat.data;
using InfoUsuarios;
using InfoUsuarios.cache;
using InfoUsuarios.infoPredio;
using InfoUsuarios.construciones;//Informacion para las construcciones
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
/*
 * | Autor: Ing. Maria de Lourdes Sosa Cruz
 * | Contiene toda la estructura para llevar a cabo el ejercicio de valuacion catastral 
 */
namespace Cavat
{
    public partial class Notarios : System.Web.UI.Page
    {
        Catalogos catt = new Catalogos();//CAPA COMUN //ELIMINAR UNA VES QUE HAYAN QUEDADO LOS SERVICIO        
        resultado rs = new resultado();
        catalogosSW catSW = new catalogosSW();// servicio WEB 
        DataSet dsaux = new DataSet();
        DataTable dtaux = new DataTable();
        private static DataTable tabla = new DataTable();
        private static DataTable tablaObras = new DataTable();
        private NumberStyles style;
        CultureInfo culture;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)//lo que solo se ejeuta una vez
                {
                    crearTablaObras();//Crea la tabla inicial para poder alamcenar informacion temporal OBRAS COMPLEMENTARIAS
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
                        GVObrasComplem.DataBind();                        
                    }
                    else
                    {
                        var random = new Random();
                        var r1 = random.Next(1, 999999);
                        lblFOLIOT.Text = Convert.ToString(r1);
                    }
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ddlEdadConstruc()
        {            
                try
                {
                    ddlEdadConstruccion.Items.Insert(0, new ListItem("EDAD"));
                    ddlEdadConstruccion.Items.Insert(1, new ListItem("01-10"));
                    ddlEdadConstruccion.Items.Insert(2, new ListItem("11-20"));
                    ddlEdadConstruccion.Items.Insert(3, new ListItem("21-30"));
                    ddlEdadConstruccion.Items.Insert(4, new ListItem("31-40"));
                    ddlEdadConstruccion.Items.Insert(5, new ListItem("41-50"));
                    ddlEdadConstruccion.Items.Insert(6, new ListItem("51-EN ADELANTE"));
                }
                catch (Exception ex)
                {
                Response.Write(ex);
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
        public DataSet VerCatalogo(int opc)  //Pasar a Clase Catalogos
        {
            try
            {
                rs = catSW.Cataloggo(opc); //CONSUMO SW             
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux;
            } catch (Exception ex)
            {
                throw ex;
                //Response.Redirect("404.aspx");
            }
        }
        public DataTable VerCatUsoGeneral(int opc, string idtipoPredio)  //METODO QUE CONSUME EL SERVICIO WEB LLAMADO DESDE LA CLASE CATALOGOSSW
        {
            try
            {
                rs = catSW.CatUsoGeneral(opc, idtipoPredio); //LLAMA AL METODO DE LA CLASE CATALOGOSSW QUE ESTA CONSUMIENDO EL SERVICIO WEB           
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                dtaux = dsaux.Tables[0];
                return dtaux; // DEVUELVE LA TABLA CON EL RESULTADO GENERADO
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String esCentralizado(string municipio)//Corregir a Filtrar desde la tabla que ya se tiene
        {
            try
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
            } catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnUbicaPredio_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //limpiar las cajas posteriores 
                //Limpia lo seleccionado en Ubicar predio
                ddlLocalidad.ClearSelection();
                ddlZonaValor.ClearSelection();
                // *******Limpia lo que se encuentre en el Factor de Terreno *********
                ddlUsoSueloUrbano.ClearSelection();
                txtSuperficieUrbano.Text = "";
                txtFrenterustico.Text = "";
                ddlPreguntaFraccionamiento.ClearSelection();
                txtProfundidad.Text = "";
                ddlDesnivelUrbano.ClearSelection();
                ddlTipoDesnivelUrbano.ClearSelection();
                ddlUbicacionManzana.ClearSelection();
                ddlTipoVialidad.ClearSelection();
                txtNoTotalEsquinas.Text = "";
                txtAnguloEsquinas.Text = "";
                txtNoEsquinasColinVialidad.Text = "";
                RDBntConstruccion.ClearSelection();
                /////////
                ddlObraComplementaria.ClearSelection();
                ddlCalidadObra.ClearSelection();
                ContentAgregarObraCom.Visible = false;

                ////dejar asi porque es la primera presentacion es en donde se dan los datos generales del predio
                UbicacionPredio.Visible = true;
                Presentacion.Visible = false;
                FactorTerreno.Visible = false;
                FactorConstruccion.Visible = false;
                Georreferencia.Visible = false;
                ContentUrbano.Visible = false;
                btnGetAvaluo.Enabled = false;
                if (IsPostBack)
                {
                    llenarCatalgos(4, "municipio", ddlMunicipio, "MUNICIPIO");
                    llenarCatalgos(6, "tipoPredio", ddlTipoPredio, "TIPO PREDIO");
                }


            } catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnFactorTerreno_Click(object sender, ImageClickEventArgs e)
        {
            fFactorTerreno();
        }
        public void fFactorTerreno()
        {
            try
            {
                FactorConstruccion.Visible = false;
                if (usoSuelo.tipoPredio == string.Empty || usoSuelo.tipoPredio == null || ddlTipoPredio.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('error','PARA PODER CONTINUAR DEBE ELEGIR UN TIPO DE PREDIO.')", true);
                    UbicacionPredio.Visible = true;
                    ddlTipoPredio.BorderColor = Color.Red;
                    ddlTipoPredio.BorderWidth = 3;
                }
                else if (usoSuelo.tipoPredio == "RÚSTICO") //Tipo de suelo Rustico
                {
                    lbltipoPredio.Text = usoSuelo.tipoPredio;
                    UbicacionPredio.Visible = ContentUrbano.Visible = false;
                    FactorTerreno.Visible = ContentRustico.Visible = true;
                    ddlTopografiaRustico.ClearSelection();
                    verCatalogoCompartido(17, "2", ddlTopografiaRustico, "TOPOGRAFIA", "Topografia");//ddlDistanciaUDM.ClearSelection();//ddlDistanciaUDM.Items.Clear();//ddlUDMDistancia();
                    ddlUbicaciónRustico.ClearSelection();
                    ddlUbicaciónRustico.ClearSelection();
                    verCatalogoUbicacion(9, 2, ddlUbicaciónRustico, "UBICACIÓN PREDIO", "Ubicacion");//USO DE SUELO URBANO//cuando cambie vaciar los componentes del otro
                }
                else //Tipo de suelo Urbano o Suburbano
                {
                    lbltipoPredio.Text = usoSuelo.tipoPredio;
                    UbicacionPredio.Visible = ContentRustico.Visible = false; ;
                    FactorTerreno.Visible = ContentUrbano.Visible = true;
                   // verCatalogoCompartido(9, "1", ddlUbicacionManzana, "UBICACIÓN EN MANZANA", "Ubicacion"); //cuando cambie vaciar los componentes del otro
                    verCatalogoUbicacion(9, 1, ddlUbicacionManzana, "UBICACIÓN EN MANZANA", "Ubicacion");
                    ddlUsoSueloUrbano.ClearSelection();

                    verCatalogoUsoSuelo(16, "U", ddlUsoSueloUrbano, "USO DE SUELO", "descripcion");//USO DE SUELO URBANO// verCatalogoCompartido(16, predios.tipoPredio, ddlUsoSueloUrbano, "USO DE SUELO", "descripcion");//USO DE SUELO URBANO
                    ddlDesnivelUrbano.ClearSelection();
                    VerDesnivelUrbano();
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable VerCatUsoSuelo(int opc, string Predio)  //METODO QUE CONSUME EL SERVICIO WEB LLAMADO DESDE LA CLASE CATALOGOSSW y devuelve el uso de suelo del terreno
        {
            try
            {
                rs = catSW.CatUsoSuelo(opc,Predio); //LLAMA AL METODO DE LA CLASE CATALOGOSSW QUE ESTA CONSUMIENDO EL SERVICIO WEB           
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                dtaux = dsaux.Tables[0];
                return dtaux; // DEVUELVE LA TABLA CON EL RESULTADO GENERADO
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void verCatalogoUsoSuelo(int opc, string tipoPredio, DropDownList lista, string ubicacion, string columnna)
        {
            try
            {
                DataTable ddt;
                ddt = VerCatUsoSuelo(opc, tipoPredio);//catt.CatUsoSuelo(opc, idtipoPredio);//-->  VERIFICAR PROQEUE ES COMPARTIDO
                lista.DataSource = ddt;
                lista.DataValueField = columnna;//"Ubicacion";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem(ubicacion));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
        }



        public void verCatalogoUbicacion(int opc, int idtipoPredio, DropDownList lista, string ubicacion, string columnna)
        {
            try
            {
                DataTable ddt;
                DataSet ds;
                ds = VerCatUbicacion(opc, idtipoPredio);
                ddt = ds.Tables[0];//catt.CatUsoSuelo(opc, idtipoPredio);//-->  VERIFICAR PROQEUE ES COMPARTIDO
                if(ubicacion== "UBICACIÓN EN MANZANA")
                {
                    infoMunicipio.Centralizado.UbicacionManzana = ddt;
                }
                else
                {
                    infoMunicipio.Centralizado.UbicacionPredio = ddt;
                }
                lista.DataSource = ddt;
                lista.DataValueField = columnna;//"Ubicacion";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem(ubicacion));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
        }

        protected void btnFactorConstruccion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                UbicacionPredio.Visible = Presentacion.Visible = VerMapa.Visible = FactorTerreno.Visible = Georreferencia.Visible = ContentUrbano.Visible = false;
                FactorConstruccion.Visible = true;
                ddlAvanceConstruccion.ClearSelection();
                llenarCatalgos(13, "avance", ddlAvanceConstruccion, "AVANCE DE OBRA");
                btnGetAvaluo.Enabled = true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet VerCatalogoCons(int opc, int mun, int anio)
        {
            try
            {
                rs = catSW.CatConstruccion(opc, mun, anio);//Consumo SERVICIO WEB
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux;
            } catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet GetinfoDescentralizado(int opc, string mun, string anio) //Metodo que obtiene la informacion de los municipios descentralizados desde la clase catalogosSW (Donde se consume el servicio)
        {
            try
            {
                rs = catSW.CatZonasValorDesCentralizados(opc, mun, anio);// llama al metodo de la clase catalogosSW
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux; //Regresa un dataset con toda la informacion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ZonasValorDes(DropDownList listaDestino, int tipoPredio, string titulo) //Metodo que rellenea el dropdown list filtrando los datos que correspondan al tipo de predio seleccionado
        {
            try
            {
                DataTable dtAux = infoMunicipio.Descentralizados.dtDescentralizados; //DataTable en donde se aloja la informacion que se obtuvo del servicio de los municipios descentralizados
                List<string> myList = new List<String>(); //lista auxiliar en donde se almacenaran los datos filtadros
                myList.Add("ZONA DE VALOR");
                foreach (DataRow row in dtAux.Rows)  //se recorre el datatable 
                {
                    if ((int)row[5] == tipoPredio) // si la dila 5 (tipoPredio) es igual al tipo de predio que se selecciono (variable comun de almacenamiento)
                    {
                        myList.Add((string)row["nombreZona"]); //almacena en la lista los datos de la zona de valor
                    }
                }
                myList = myList.Distinct().ToList(); // Se limpian los duplicados de la lista
                foreach (string elemento in myList)//Se agregan los elementos de la lista en el Dropdown List
                {
                    listaDestino.Items.Add(elemento);//llenar el dropdown list con los elementos que estan en la lista
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    int va = int.Parse(ddlMunicipio.SelectedIndex.ToString());//obtiene el id del municipio seleccionado 
                    int val = int.Parse(ddlTipoPredio.SelectedIndex.ToString());//Obtiene el id del tipo de predio que se esta seleccionando
                    predios.municipio = ddlMunicipio.SelectedValue.ToString();//Envia a la variable el valor del municipio
                    predios.centralizado = esCentralizado(ddlMunicipio.SelectedValue.ToString()); //Indica si el municipio es centralizado o descentralizado                                 
                    switch (predios.centralizado)
                    {
                        case "True"://Se maneja la informacion de serverBox
                            ddlLocalidad.ClearSelection();//limpia la lista desplegable para poder llenar con los valores nuevos que se envian                   
                            ddlLocalidadCentralizado(8, va);//obtiene los nuevos valos para la lista desplegable de localidades para municipios Centralizados
                            Construcciones.dtConstrucciones = VerCatalogoCons(1, va, 2022); /// tiene la tabla estatica de los valores de las construcciones dependiendo del municipio Seleccionado   
                            if (val == 2)//RUSTICO
                            {
                                verZonaValor(7, ddlMunicipio.SelectedIndex, 'R', "2022", ddlTipoSRustico, "TIPO PREDIO");
                            }
                            else//Suburbano [pasar val==3 para que ya queden las condiciones bien definidas]
                            {
                                if (val == 1 || val == 3)//URBANO Y SUBURBANO
                                {
                                    verZonaValor(7, ddlMunicipio.SelectedIndex, 'U', "2022", ddlZonaValor, "ZONA DE VALOR");
                                }
                            }
                            break;
                        case "False"://Se maneja la informacion de los descentralizados de la base de datos local
                            DataSet ds = new DataSet(); DataSet ds1 = new DataSet();
                            ds = GetinfoDescentralizado(1, predios.municipio, "2022");
                            infoMunicipio.Descentralizados.dtDescentralizados = ds.Tables[0];  // GetinfoDescentralizado(1, predios.municipio, "2022");//contiene la tabla con la información de los municipios descentralizados                                                                                                                                                                
                            ds1 = GetinfoLocalidaDes(3, predios.municipio);
                            infoMunicipio.Descentralizados.dtLocalidades = ds1.Tables[0];//Se obtine la informacion de las localidades del municipio Descentralizado
                            LocalidadesDes(ddlLocalidad, "LOCALIDAD");//Llena la lista desplegable de localidades, acorde al municipio seleccionado.
                            //CATALODO DE DESCENTRALIZADOS
                            Construcciones.dtConstrucciones = VerCatalogoCons(2,va, 2021); /// tiene la tabla estatica de los valores de las construcciones dependiendo del municipio Seleccionado   
                            if (val == 2)//RUSTICO 
                            {
                                ddlTipoSRustico.ClearSelection(); //Vacia para volver a llenar
                                ZonasValorDes(ddlTipoSRustico, val, "TIPO PREDIO");//Llena las zonas de valor para los tipos rusticos
                            }
                            else
                            {
                                if (val == 1 || val == 3)//URBANO Y SUBURBANO
                                {
                                    ddlZonaValor.ClearSelection(); //Vacia para volver a llenar
                                    ZonasValorDes(ddlZonaValor, val, "ZONA DE VALOR");//Llena las zonas de valor para los tipos urbanos y suburvbanos
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet VerCatZonasValorCentralizados(int opc, int idmun, char tipoPredio, string anio)  //METODO QUE CONSUME EL SERVICIO WEB LLAMADO DESDE LA CLASE CATALOGOSSW
        {
            try
            {
                rs = catSW.CatZonasValorCentralizados(opc, idmun, tipoPredio, anio);// catalog.Cataloggo(opc);
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void verZonaValor(int opc, int idmun, char tipoPredio, string annio, DropDownList ddlzona, string titulo)//Zona de Valor Centralizados 
        {
            try
            {
                DataSet ds = new DataSet();
                ds = VerCatZonasValorCentralizados(opc, idmun, tipoPredio, annio); //VerCatalogo(opc);
                infoMunicipio.Centralizado.ZonasValor = ds.Tables[0];
                ddlzona.DataSource = ds.Tables[0];
                ddlzona.DataValueField = "nombreZona";// columna;
                ddlzona.DataBind();
                ddlzona.Items.Insert(0, new ListItem(titulo));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
        }
        public DataSet GetinfoLocalidaDes(int opc, string mun) //Metodo que obtiene la informacion de las localidades del municipio que es descentralizado
        {
            try
            {
                rs = catSW.CatLocalidadesDesCentralizados(opc, mun); //LLAMA AL METODO DE LA CLASE CATALOGOSSW QUE ESTA CONSUMIENDO EL SERVICIO WEB           
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux; // DEVUELVE LA TABLA CON EL RESULTADO GENERADO
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LocalidadesDes(DropDownList listaDestino, string titulo)//Metodo que llena el dropdownList de las locaclidades de los municipios descentralizados
        {
            try
            {
                DataTable dtAux = new DataTable();
                dtAux = infoMunicipio.Descentralizados.dtLocalidades;//Informacion almacenada en clase infoMunicipio.
                listaDestino.DataSource = dtAux;
                listaDestino.DataValueField = "localidad";
                listaDestino.DataBind();
                listaDestino.Items.Insert(0, new ListItem(titulo));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet VerCatLocalidadescentralizados(int opc, int mun)  //2) METODO QUE CONSUME EL SERVICIO WEB LLAMADO DESDE LA CLASE CATALOGOSSW
        {
            try
            {
                rs = catSW.CatLocalidadesCentralizados(opc, mun); //LLAMA AL METODO DE LA CLASE CATALOGOSSW QUE ESTA CONSUMIENDO EL SERVICIO WEB           
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux; // DEVUELVE LA TABLA CON EL RESULTADO GENERADO
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ddlLocalidadCentralizado(int opc, int idmun)//1) Metodo que llena la lista de las localidades de los municipios Centralizados
        {
            try
            {
                DataTable ddt = new DataTable();
                DataSet ds = VerCatLocalidadescentralizados(opc, idmun);// catSW.CatLocalidad(opc, idmun);//--> Catalogo Municipio  CONSUMO SW
                ddt = ds.Tables[0];
                ddlLocalidad.DataSource = ddt;
                ddlLocalidad.DataValueField = "localidad";
                ddlLocalidad.DataBind();
                ddlLocalidad.Items.Insert(0, new ListItem("LOCALIDAD"));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
        }       
        public DataSet VerCatUbicacion(int opc, int idtipoPredio)  //2) METODO QUE CONSUME EL SERVICIO WEB LLAMADO DESDE LA CLASE CATALOGOSSW
        {
            try
            {
                rs = catSW.CatUbicacionPredio(opc, idtipoPredio); //LLAMA AL METODO DE LA CLASE CATALOGOSSW QUE ESTA CONSUMIENDO EL SERVICIO WEB           
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                return dsaux; // DEVUELVE LA TABLA CON EL RESULTADO GENERADO
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        protected void txtCP_TextChanged(object sender, EventArgs e)
        {         
            try
            {
                predUrbano.cp = txtCP.Text;
                if (true)
                {
                    btnUbicaPredio.BorderColor = Color.Aquamarine;
                    btnUbicaPredio.BorderStyle = BorderStyle.Solid;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlTipoPredio_SelectedIndexChanged(object sender, EventArgs e)
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
          
        public void VerDesnivelUrbano()
        {
            try
            {
                ddlDesnivelUrbano.ClearSelection();
                ddlDesnivelUrbano.Items.Insert(0, new ListItem("¿EXISTE DESNIVEL?"));
                ddlDesnivelUrbano.Items.Insert(1, new ListItem("SI"));
                ddlDesnivelUrbano.Items.Insert(2, new ListItem("NO"));

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
        }


        public void verCatalogoCompartido(int opc, string idtipoPredio, DropDownList lista, string ubicacion, string columnna)
        {
            try
            {
                DataTable ddt;
                ddt = VerCatUsoGeneral(opc, idtipoPredio);//catt.CatUsoSuelo(opc, idtipoPredio);//-->  VERIFICAR PROQEUE ES COMPARTIDO
                lista.DataSource = ddt;
                lista.DataValueField = columnna;//"Ubicacion";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem(ubicacion));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
        } 
        

        public string ValorConstruccion(DropDownList listClasif, DropDownList listCalidad)
        {
            try
            {
                string valorConsm2 = "";
                DataTable dtAux = new DataTable();
                DataSet ds = new DataSet();
                ds = Construcciones.dtConstrucciones;
                dtAux = ds.Tables[0];
                if (predios.centralizado=="True")//si es centralizado
                {
                    foreach (DataRow row in dtAux.Rows)
                    {
                        if ((string)row[2] == listClasif.SelectedValue.ToString() && (string)row[4] == listCalidad.SelectedValue.ToString())
                        {
                            valorConsm2 = row[6].ToString();
                        }
                    }
                    return valorConsm2;
                }
                else//si no es centralizado
                {
                    foreach (DataRow row in dtAux.Rows)
                    {
                        if (((string)row[7] == listClasif.SelectedValue.ToString() && (string)row[5] == listCalidad.SelectedValue.ToString()) || ((string)row[6] == listClasif.SelectedValue.ToString() && (string)row[5] == listCalidad.SelectedValue.ToString()))
                        {
                            if (ddlCoservacion.SelectedValue == "BUENO")
                            {
                                valorConsm2 = row[1].ToString();
                            }
                            else
                            {
                                if (ddlCoservacion.SelectedValue == "REGULAR")
                                {
                                    valorConsm2 = row[2].ToString();
                                }
                                else
                                {
                                    valorConsm2 = row[3].ToString();
                                }
                            }
                        }
                    }
                    return valorConsm2;
                }
              

            }
            catch(Exception ex)
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
                    ddt = catSW.CatClaseConstrucion(opc, clv, idClass);//--> Catalogo Municipio CONSUMO SW
                    ddlCalidadConstruccion.DataSource = ddt;
                    ddlCalidadConstruccion.DataValueField = "calidad";
                    ddlCalidadConstruccion.DataBind();
                    ddlCalidadConstruccion.Items.Insert(0, new ListItem("CALIDAD DE LA CONSTRUCCIÓN"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    Response.Redirect("404.aspx");
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
                        predUrbano.factorEsquina = 1.0;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                    break;
                case "ESQUINA":
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
                case "LOTE INTERIOR CON ACCESO PROPIO":
                case "LOTE INTERIOR SIN ACCESO PROPIO":
                    predUrbano.factorEsquina = 1.0;
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
                    //Limpieza de cajas deshabilitadas
                    ddlTipoVialidad.ClearSelection();
                    txtNoTotalEsquinas.Text = "";
                    txtAnguloEsquinas.Text = "";
                    txtNoEsquinasColinVialidad.Text = "";
                    break;
                default:
                    predUrbano.factorEsquina = 1.0;
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
                    //Limpieza de cajas deshabilitadas
                    ddlTipoVialidad.ClearSelection();
                    txtNoTotalEsquinas.Text = "";
                    txtAnguloEsquinas.Text = "";
                    txtNoEsquinasColinVialidad.Text = "";
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
                //Se pregunta si pertenece a un fraccionamiento y en ese ddl se agrega el factor del frente
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
                predUrbano.factorFrente = 1;   //factor a 1
            }
        }
        protected void txtProfundidad_TextChanged(object sender, EventArgs e)
        {
            predUrbano.tamprofundidad = Convert.ToDouble(txtProfundidad.Text);

            if (predUrbano.tamprofundidad < 10.0)
            {
                //Aplica demerito
                predUrbano.factorProfundidad = factorPredio.factorProfundidad(predUrbano.tamfrente, predUrbano.tamprofundidad);
            }
            else//el tamaño de la profundidad es mayor a 10, por tanto el Factor de Profundidad es 1
            {
                predUrbano.factorProfundidad = 1.0;
            }
        }

        protected void RDBntConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (RDBntConstruccion.SelectedValue.ToString())
                {
                    case "SI":
                        //Habilita Construcciones
                        // btnFactorConstruccion.Enabled = true;
                        btnSiguienteConstr.Enabled = true;
                        btnGetAvaluo.Enabled = false;

                        break;
                    case "NO":
                        //NO HABILITA NADA
                        //   btnFactorConstruccion.Enabled = false;
                        btnSiguienteConstr.Enabled = false;
                        btnGetAvaluo.Enabled = true;
                        break;
                    default:
                        //NO HABILITA NADA
                        //  btnFactorConstruccion.Enabled = false;
                        btnSiguienteConstr.Enabled = false;
                        btnGetAvaluo.Enabled = false;
                        break;
                }
                switch (predios.centralizado)//Si es Centralizado
                {
                    case "True"://Se maneja la informacion de serverBox
                        if (predios.tipoPredio == "RÚSTICO")
                        {
                            predRustico.factorResultanteTR = factorPredio.FactoResultanteTerrenoRustico(predRustico.fatorSuperficieR, predRustico.factorTopografia, predRustico.fatorDistanciaPredio, predRustico.factorUbicacion);
                            double valorM2 = predRustico.ValorTerrenoM2 / 10000;//valor por metro cuadrado
                            predios.ValorCatastralTerreno = factorPredio.ValorCatastralPredio(valorM2, predRustico.factorResultanteTR, predRustico.SuperficieR);
                            lblValorFactorTerreno.Text = predios.ValorCatastralTerreno.ToString("C", new CultureInfo("es-MX"));
                        }
                        else if (predios.tipoPredio == "URBANO")
                        {
                            predUrbano.factorResultanteTERRENO = factorPredio.FactoResultanteTerreno(predUrbano.factorFrente, predUrbano.factorProfundidad, predUrbano.factorTopografia, predUrbano.factorUbicacion, predios.factorSuperficie, predUrbano.factorEsquina);
                            predios.ValorCatastralTerreno = factorPredio.ValorCatastralPredio(Convert.ToDouble(predUrbano.zonaValor), predUrbano.factorResultanteTERRENO, predios.superficie);
                            lblValorFactorTerreno.Text = predios.ValorCatastralTerreno.ToString("C", new CultureInfo("es-MX"));
                        }
                        else//suburbano
                        {
                            //quedan pendientes las operaciones porque el  proceso sera diferente, dependiendo del proceso que dara El area de Valuacion
                        }
                        break;
                    case "False"://Se maneja la informacion local
                        if (predios.tipoPredio == "RÚSTICO")
                        {
                            predRustico.factorResultanteTR = factorPredio.FactoResultanteTerrenoRustico(predRustico.fatorSuperficieR, predRustico.factorTopografia, predRustico.fatorDistanciaPredio, predRustico.factorUbicacion);
                            double valorM2 = predRustico.ValorTerrenoM2 / 10000;//valor por metro cuadrado
                            predios.ValorCatastralTerreno = factorPredio.ValorCatastralPredio(valorM2, predRustico.factorResultanteTR, predRustico.SuperficieR);
                            lblValorFactorTerreno.Text = predios.ValorCatastralTerreno.ToString("C", new CultureInfo("es-MX"));
                        }
                        else if (predios.tipoPredio == "URBANO")
                        {
                            predUrbano.factorResultanteTERRENO = factorPredio.FactoResultanteTerreno(predUrbano.factorFrente, predUrbano.factorProfundidad, predUrbano.factorTopografia, predUrbano.factorUbicacion, predios.factorSuperficie, predUrbano.factorEsquina);
                            predios.ValorCatastralTerreno = factorPredio.ValorCatastralPredio(Convert.ToDouble(predUrbano.zonaValor), predUrbano.factorResultanteTERRENO, predios.superficie);
                            lblValorFactorTerreno.Text = predios.ValorCatastralTerreno.ToString("C", new CultureInfo("es-MX")); 
                        }
                        else//suburbano
                        {
                            //quedan pendientes las operaciones porque el  proceso sera diferente, dependiendo del proceso que dara El area de Valuacion
                        }
                        break;
                }
                //CAMBIAR COLOR DE BOTON FACTOR TERRENO
                btnFactorTerreno.Width = 10;
                btnFactorTerreno.BackColor = Color.Green;
                btnFactorTerreno.BorderColor = Color.LimeGreen;
                checkFactorTerreno.Checked = true;
            }
            catch (Exception ex)
            {
                throw ex;
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
                verCatalogoCompartido(17, "1", ddlTipoDesnivelUrbano, "TIPO DESNIVEL", "Topografia");
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
                    predios.superficie = Convert.ToDouble(Conversiones.converMetrosM(txtSuperficieRu.Text));
                    break;
                default: //NO HABILITA NADA                   
                    break;
            }
        }
        protected void txtSuperficieRu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtSuperficieRu.Text) < 1.00)
                {
                    txtSuperficieRu.BorderColor = Color.Red;
                    txtSuperficieRu.BorderWidth = 3;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE EXISTIR AL MENOS UN METRO CUADRADO COMO SUPERFICIE DEL PREDIO')", true);
                }
                else
                {
                    txtSuperficieRu.BorderColor = Color.Transparent;
                    txtSuperficieRu.BorderWidth = 0;
                    // COMPARACION PARA PODER MANDAR UNIDAD DE MEDIDA CORRECTA EN EL RADIO BUTTON
                    if (Convert.ToDouble(txtSuperficieRu.Text) >= 1.00 && Convert.ToDouble(txtSuperficieRu.Text) < 10000.00)
                    {
                        RBUDMSuperficie.SelectedValue = "m²";
                        predRustico.fatorSuperficieR = 1.00;
                        double comparar = Convert.ToDouble(Conversiones.converMetrosM(txtSuperficieRu.Text));
                        predRustico.SuperficieR = comparar;
                    }
                    else
                    {
                        RBUDMSuperficie.SelectedValue = "ha";
                        txtSuperficieRu.Text = Conversiones.converHA(txtSuperficieRu.Text);
                        double comparar = Convert.ToDouble(Conversiones.converMetrosM(txtSuperficieRu.Text));
                        predRustico.SuperficieR = comparar;
                        if (comparar >= 10001.00 && comparar <= 20000.00)
                        {
                            predRustico.fatorSuperficieR = 1.00;
                        }
                        else
                        {
                            if (comparar >= 20001.00 && comparar <= 40000.00)
                            {
                                predRustico.fatorSuperficieR = 0.90;
                            }
                            else
                            {
                                if (comparar >= 40001.00 && comparar <= 60000.00)
                                {
                                    predRustico.fatorSuperficieR = 0.85;
                                }
                                else if (comparar >= 60001.00 && comparar <= 100000.00)
                                {
                                    predRustico.fatorSuperficieR = 0.80;
                                }
                                else
                                {
                                    predRustico.fatorSuperficieR = 0.75;
                                }
                            }
                        }
                    }
                    ///COMPROBACION DE VALORES PARA PODER  MANDAR SU FACTOR
                    predios.superficieRU = txtSuperficieRu.Text + " " + RBUDMSuperficie.SelectedValue;
                }
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
            List<string> listCostriccion = new List<string>() { "AvanceObra", "Superficie", "Clasificacion", "Tipo", "Calidad", "Conservacion", "Edad", "Condominio", "SupPriv", "SupInd", "CalidadObra", "ValorM2" };
            var c = new DataColumn[listCostriccion.Count];
            for (int i = 0; i < listCostriccion.Count; i++)
            {
                c[i] = new DataColumn(listCostriccion[i]);
                tabla.Columns.Add(c[i]);
            }
        }
        public void crearTablaObras()
        {
            tablaObras.Columns.Clear();
            tablaObras.Rows.Clear();
            List<string> listObras = new List<string>() { "OBRA COM", "CALIDAD", "VALORM2" };
            var c = new DataColumn[listObras.Count];
            for (int i = 0; i < listObras.Count; i++)
            {
                c[i] = new DataColumn(listObras[i]);
                tablaObras.Columns.Add(c[i]);
            }
        }
        protected void ddlObraComplementaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoConstrucciones.obraComplementaria = ddlObraComplementaria.SelectedValue;
            if (IsPostBack)
            {
                try
                {
                    ddlLocalidad.ClearSelection();
                    ddlLocalidad.ClearSelection();
                    catClasificacionConst(ddlObraComplementaria, ddlCalidadObra);
                }
                catch (Exception ex)
                {
                     throw ex;
                }
            }
        }

        protected void ddlClasPred_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoConstrucciones.ClasificacionConstruccion = ddlClasPred.SelectedValue;// almacena la seleccion
            try
            {
                ddlCalidadConstruccion.ClearSelection();
                //    ddlTipoCons(11, va);
                if (ddlClasPred.SelectedIndex.ToString().Contains("Antigu") || ddlClasPred.SelectedIndex.ToString().Contains("ANTIGU") || ddlClasPred.SelectedIndex.ToString().Contains("antigu"))//ddlClasPred.SelectedValue.ToString() == "ANTIGUO")
                {
                    ddlEdadConstruccion.Enabled = false;
                    ddlCoservacion.Enabled = true;
                }
                else if (ddlClasPred.SelectedIndex.ToString().Contains("MODERNO") || ddlClasPred.SelectedIndex.ToString().Contains("Moderno") || ddlClasPred.SelectedIndex.ToString().Contains("moderno"))//ddlClasPred.SelectedValue.ToString() == "MODERNO")
                {
                    ddlEdadConstruccion.Enabled = true;
                    ddlCoservacion.Enabled = false;
                }
                catClasificacionConst(ddlClasPred, ddlCalidadConstruccion);
            }
            catch (Exception ex)
            {
              throw ex;
            }

        }
        public void catClasificacionConst(DropDownList listaSeleccion, DropDownList listaDestino)
        {
            try
            {
                DataTable dtAux = new DataTable();
                DataSet ds = new DataSet();
                ds = Construcciones.dtConstrucciones;
                dtAux = ds.Tables[0];
                List<string> myList = new List<String>();
                string columnaBuscar = "";
                string columnaCalidad = "";

                switch (predios.centralizado)//Verifica que se centralizado o no
                {
                    case "True":
                        columnaBuscar = "descripcion";//columna que se va a comparar con la seleccion 
                        columnaCalidad = "calidad";//columna que se va a agregar a la lista en cuanto la enterior coinsida con lo selecionado                
                        foreach (DataRow row in dtAux.Rows)
                        {
                            if ((string)row[columnaBuscar] == listaSeleccion.SelectedValue.ToString())
                            {
                                myList.Add((string)row[columnaCalidad]);
                            }
                        }
                        myList = myList.Distinct().ToList();
                        listaDestino.DataSource = myList;
                        listaDestino.DataBind();
                        listaDestino.Items.Insert(0, new ListItem("CALIDAD"));
                        break;
                    case "False":
                        if (listaSeleccion == ddlClasPred)
                        {
                            columnaBuscar = "tipoconstruccion";
                        }
                        else if (listaSeleccion == ddlObraComplementaria)
                        {
                            columnaBuscar = "obraComplementaria";
                        }
                        columnaCalidad = "CalidadObraComplementaria";
                        foreach (DataRow row in dtAux.Rows)
                        {
                            if ((string)row[columnaBuscar] == listaSeleccion.SelectedValue.ToString())
                            {
                                myList.Add((string)row[columnaCalidad]);
                            }
                        }
                        myList = myList.Distinct().ToList();
                        listaDestino.DataSource = myList;
                        listaDestino.DataBind();
                        listaDestino.Items.Insert(0, new ListItem("CALIDAD"));
                        break;
                }
            }catch(Exception ex)
            {
             throw ex;
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
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','Borro la opción: " + rowIndex + "')", true);
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
            //     predios.topoReliev = ddlTopografiaRustico.SelectedValue.ToString();// Verificar si va a ir comoletrero si no pues no tomarlo ne cuenta 

            if (ddlTopografiaRustico.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UN TIPO DE TOPOGRAFIA.')", true);
            }
            else
            {
                Double valorTopografia = 0.00;
                DataTable dt = new DataTable();

                if (predios.tipoPredio == "URBANO")
                {
                    dt = VerCatUsoGeneral(17, "1");
                }
                else if (predios.tipoPredio == "RÚSTICO")
                {
                    dt = VerCatUsoGeneral(17, "2");
                }
                else
                {
                    dt = VerCatUsoGeneral(17, "3");
                }
                EnumerableRowCollection<DataRow> query = from fila in dt.AsEnumerable()
                                                         where fila.Field<String>("Topografia") == ddlTopografiaRustico.SelectedValue.ToString()
                                                         select fila;
                DataTable dt1 = query.CopyToDataTable();
                valorTopografia = Convert.ToDouble(dt1.Rows[0]["factor"]);
                predRustico.factorTopografia = Convert.ToDouble(valorTopografia);  //envia el valor de la zona de valor a la variable statica que contendra el valor
            }

            //Obtener el valor de la topografia segun lo que selecciono el usuario y enviarlo a la variable estatica correspondiente, para poder realizar las operaciones. 
        }
        protected void ddlUbicaciónRustico_SelectedIndexChanged(object sender, EventArgs e)
        {
            predios.ubicacion = ddlUbicaciónRustico.SelectedValue.ToString();

            if (ddlUbicaciónRustico.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR LA UBICACIÓN DEL PREDIO.')", true);
            }
            else
            {
                Double valorUbicacionRustico = 0.00;
                EnumerableRowCollection<DataRow> query = from fila in infoMunicipio.Centralizado.UbicacionPredio.AsEnumerable()// dt.AsEnumerable()
                                                         where fila.Field<String>("Ubicacion") == predios.ubicacion// ddlUbicaciónRustico.SelectedValue.ToString()
                                                         select fila;
                DataTable dt1 = query.CopyToDataTable();
                valorUbicacionRustico = Convert.ToDouble(dt1.Rows[0]["factor"]);
                predRustico.factorUbicacion = valorUbicacionRustico;  //envia el valor de la zona de valor a la variable statica que contendra el valor
            }
        }
        protected void txtParaje_TextChanged(object sender, EventArgs e)
        {
            predRustico.paraje = txtParaje.Text;
        }
        protected void txtDistanciaRustico_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtDistanciaRustico.Text) < 1.00)
                {
                    txtDistanciaRustico.BorderColor = Color.Red;
                    txtDistanciaRustico.BorderWidth = 3;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE EXISTIR AL MENOS UN METRO DE DISTRANCIA AL PREDIO')", true);
                }
                else if (Convert.ToDouble(txtDistanciaRustico.Text) >= 1.00 && Convert.ToDouble(txtDistanciaRustico.Text) < 1000.00)
                {
                    txtDistanciaRustico.BorderColor = Color.Transparent;
                    txtDistanciaRustico.BorderWidth = 0;

                    RDBDistanciaPredio.SelectedValue = "m";

                    if (Convert.ToDouble(txtDistanciaRustico.Text) >= 1.00 && Convert.ToDouble(txtDistanciaRustico.Text) <= 500.00)
                    {
                        predRustico.fatorDistanciaPredio = 1.40;
                    }
                    else if (Convert.ToDouble(txtDistanciaRustico.Text) >= 501.00 && Convert.ToDouble(txtDistanciaRustico.Text) < 1000.00)
                    {
                        predRustico.fatorDistanciaPredio = 1.20;
                    }
                }
                else
                {
                    txtDistanciaRustico.BorderColor = Color.Transparent;
                    txtDistanciaRustico.BorderWidth = 0;
                    RDBDistanciaPredio.SelectedValue = "km";
                    txtDistanciaRustico.Text = Conversiones.convertKm(txtDistanciaRustico.Text);
                    double comparar = Convert.ToDouble(Conversiones.converMetrosM(txtSuperficieRu.Text));
                    if (comparar >= 1000.00 && comparar <= 1500.00)
                    {
                        predRustico.fatorDistanciaPredio = 1.20;
                    }
                    else
                    {
                        predRustico.fatorDistanciaPredio = 1.00;
                    }

                    predRustico.distanciaPredio = txtDistanciaRustico.Text + " " + RDBDistanciaPredio.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void RDBDistanciaPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RDBDistanciaPredio.SelectedValue.ToString())
            {
                case "m":
                    txtDistanciaRustico.Text = Conversiones.convertMeter(txtDistanciaRustico.Text);
                    predios.superficie = Convert.ToDouble(txtDistanciaRustico.Text);
                    break;
                case "km":
                    txtDistanciaRustico.Text = Conversiones.convertKm(txtDistanciaRustico.Text);
                    predios.superficie = Convert.ToDouble(Conversiones.converMetrosM(txtDistanciaRustico.Text));
                    break;
                default: //NO HABILITA NADA                   
                    break;
            }
        }
        //DATOS PARA PREDIO  URBANO 
        protected void txtSuperficieUrbano_TextChanged(object sender, EventArgs e)
        {
            predios.superficie = Convert.ToDouble(txtSuperficieUrbano.Text);
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
            Double valorZonza = 0.00;
            try
            {
                switch (predios.centralizado)//Si es Centralizado
                {
                    case "True"://Se maneja la informacion de serverBox
                        ddlZonaValor.Enabled = true;
                        break;
                    case "False"://Se maneja la informacion local
                        foreach (ListItem li in ddlZonaValor.Items)
                        {
                            if (li.Value == predUrbano.localidad)
                            {
                                ddlZonaValor.SelectedValue = ddlLocalidad.SelectedValue;
                                ddlZonaValor.Enabled = false;
                                EnumerableRowCollection<DataRow> queryval = from fila in infoMunicipio.Descentralizados.dtDescentralizados.AsEnumerable()
                                                                            where fila.Field<String>("nombreZona") == ddlLocalidad.SelectedValue.ToString()
                                                                            select fila;
                                DataTable dt2 = queryval.CopyToDataTable();
                                valorZonza = Convert.ToDouble(dt2.Rows[0]["valorM2"]);
                                predUrbano.zonaValor = valorZonza.ToString();  //envia el valor de la zona de valor a la variable statica que contendra el valor
                            }
                        }
                       
                        break;
                }
            }catch(Exception ex)
            {
                throw ex;
            }

        }
        protected void txtCalle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                predUrbano.calle = txtCalle.Text;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            try
            {
                predUrbano.numero = txtNumero.Text;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlTipoDesnivelUrbano_SelectedIndexChanged(object sender, EventArgs e)
        {
            predUrbano.tipoDesnivel = ddlTipoDesnivelUrbano.SelectedValue.ToString();
            if (predUrbano.tipoDesnivel == "TIPO DESNIVEL")
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
                    predUrbano.factorUbicacion = factorPredio.factorCabeceroManza(predios.superficie, categoria, 1, int.Parse(predUrbano.noesquinas));
                    break;
                case "COMERCIAL MEDIA":
                case "COMERCIAL BAJA (COMERCIO DE BARRIO)":
                    predUrbano.factorUbicacion = factorPredio.factorCabeceroManza(predios.superficie, categoria, 2, int.Parse(predUrbano.noesquinas));
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
        protected void btnAddList_Click(object sender, EventArgs e)
        {           
                try
                {
                    if (txtSuperficieObra.Text == string.Empty || ddlClasPred.SelectedIndex == 0 
                        || ddlCalidadConstruccion.SelectedIndex == 0 || ddlAvanceConstruccion.SelectedIndex == 0 )//|| ddlTipoConstruccion.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','PARA PODER CONTINUAR DEBE EXISTIR INFORMACIÓN.')", true);
                    }
                    else
                    {

                    infoConstrucciones.VCUS= Convert.ToDouble(ValorConstruccion(ddlClasPred, ddlCalidadConstruccion)); //valor de la construccion  publicado 
                     double valreal = infoConsRegular.VCCRegular(infoConstrucciones.VCUS, infoConsRegular.FTR, infoConsRegular.FED, infoConstrucciones.Sc);//, infoConstrucciones.VCUS                    
                    DataRow fila = tabla.NewRow();
                        fila["AvanceObra"] = ddlAvanceConstruccion.SelectedValue.ToString();
                        fila["Superficie"] = txtSuperficieObra.Text; 
                        fila["Clasificacion"] = ddlClasPred.SelectedValue.ToString();
                        fila["Calidad"] = ddlCalidadConstruccion.SelectedValue.ToString();
                        fila["Condominio"] = RadBtnCondominio.SelectedValue.ToString();
                        fila["ValorM2"] = valreal.ToString("c");//GENARITO 

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
                        if (ContentAgregarObraCom.Visible)
                        {
                            fila["CalidadObra"] = ddlCalidadObra.SelectedValue.ToString();
                        }
                        else
                        {
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
                        ContentAgregarConstruccion.Visible = false;
                        if (IsPostBack)
                        {
                            limpiarAddConstrucciones();
                        }
                    }

                    //llena el gridview nuevamente
                    GVConstrucciones.DataSource = tabla;
                    GVConstrucciones.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }          
        }
        public void limpiarAddConstrucciones()
        {
            //Limpiar todo lo seleccionado
            ddlAvanceConstruccion.ClearSelection();
            txtSuperficieObra.Text = "";
            ddlClasPred.ClearSelection();
         //   ddlTipoConstruccion.ClearSelection();
            ddlCalidadConstruccion.ClearSelection();
            ddlCoservacion.ClearSelection();
            ddlEdadConstruccion.ClearSelection();
            txtSupPriv.Text = "";
            txtSubInd.Text = "";
            ddlObraComplementaria.ClearSelection();
            ddlCalidadObra.ClearSelection();
        }
        protected void ddlZonaValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                        ddlZonaValor.ClearSelection();
                        ddlLocalidad.ClearSelection();
                    }
                    else
                    {
                        predios.ZonaValorTxt = ddlZonaValor.SelectedValue.ToString();//Envia la informacion que se esta seleccionando en el ddl Zona valor en la clase estatica predios
                        Double valorZonza = 0.00;
                        DataTable dt = new DataTable();
                        DataSet ds = new DataSet();
                        switch (predios.centralizado)
                        {
                            case "True"://Se maneja la informacion de serverBox
                                EnumerableRowCollection<DataRow> queryvalue = from fil in infoMunicipio.Centralizado.ZonasValor.AsEnumerable()//dt.AsEnumerable()
                                                                              where fil.Field<String>("nombreZona") == predios.ZonaValorTxt
                                                                              select fil;
                                DataTable dt2 = queryvalue.CopyToDataTable();
                                valorZonza = Convert.ToDouble(dt2.Rows[0]["valorM2"]);
                                predUrbano.zonaValor = valorZonza.ToString();  //envia el valor de la zona de valor a la variable statica que contendra el valor
                                break;
                            case "False"://Se maneja la informacion local
                                if (ddlZonaValor.SelectedValue.Contains(ddlLocalidad.SelectedValue))
                                {
                                    ddlZonaValor.SelectedValue = ddlLocalidad.SelectedValue;
                                }
                                EnumerableRowCollection<DataRow> queryval = from fila in infoMunicipio.Descentralizados.dtDescentralizados.AsEnumerable()
                                                                            where fila.Field<String>("nombreZona") == predios.ZonaValorTxt
                                                                            select fila;
                                DataTable dt3 = queryval.CopyToDataTable();
                                valorZonza = Convert.ToDouble(dt3.Rows[0]["valorM2"]);
                                predUrbano.zonaValor = valorZonza.ToString();  //envia el valor de la zona de valor a la variable statica que contendra el valor                                                    
                                break;
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
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
            btnGetAvaluo.Enabled = true;
            //btnTerminar.CssClass = "animate__animated animate__fadeInDown";
            ddlAvanceConstruccion.ClearSelection();           
        }
      
        public DataTable ClasificacionConstruccionCen(int opc, string anio, string municipio)
        {
            try
            {
                rs = catSW.CatClasifConstCentralizados(opc, anio, municipio); //LLAMA AL METODO DE LA CLASE CATALOGOSSW QUE ESTA CONSUMIENDO EL SERVICIO WEB           
                int msg = rs.mensaje;
                dsaux = rs.elDataSet;
                dtaux = dsaux.Tables[0];
                return dtaux; // DEVUELVE LA TABLA CON EL RESULTADO GENERADO
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CatConstruccion()//llena la lista desplegable de Claseficacion de la construccion dependiendo del municipio que se selecciono
        {
            DataTable dtAux = new DataTable();
            DataSet ds = new DataSet();
            ds = Construcciones.dtConstrucciones;
            dtAux = ds.Tables[0];
            List<string> myListA = new List<String>();

            switch (predios.centralizado)//Verifica que se centralizado o no
            {
                case "True":
                    //llena catalogos con informacion del serverbox.
                    foreach (DataRow row in dtAux.Rows)
                    {
                        myListA.Add((string)row["descripcion"]); //Obtiene la informacion de la columna de la tabla que se esta solicitando
                    }
                    myListA = myListA.Distinct().ToList();//Elimina los duplicados de la lista obtenida
                    var myListB = myListA;
                    var query = from w in myListB
                                where w.Contains("OBRA") || w.Contains("BARDA") || w.Contains("REJAS") ||
                                        w.Contains("CESPED") || w.Contains("MALLA") || w.Contains("TANQUE")
                                        || w.Contains("ESTRUCTURA") || w.Contains("MAMPOSTERIA")
                                select w;
                    myListA = myListA.Except(query).ToList();
                    ddlClasPred.DataSource = myListA;
                    ddlClasPred.DataBind();
                    ddlClasPred.Items.Insert(0, new ListItem("CLASIFICACION"));

                    break;
                case "False":
                    //llenar catalogos con informacion de base de datos local de descentralizdos
                    foreach (DataRow row in dtAux.Rows)
                    {
                        myListA.Add((string)row["tipoConstruccion"]);
                    }
                    myListA = myListA.Distinct().ToList();
                    var myListB1 = myListA;
                    var query1 = from w in myListB1
                                where w.Contains("N/A")
                                select w;
                    myListA = myListA.Except(query1).ToList();
                    ddlClasPred.DataSource = myListA;
                    ddlClasPred.DataBind();
                    ddlClasPred.Items.Insert(0, new ListItem("CLASIFICACION"));
                    break;                   
            }         
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

            if (predUrbano.anguloEsquinas < 45.0 || predUrbano.anguloEsquinas > 135.0)
            {
                predUrbano.factorEsquina = 1.0;
            }
            else
            {
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

   

        protected void ddlTipoSRustico_SelectedIndexChanged(object sender, EventArgs e)
        {          
            try
            {
                predRustico.tipoSuelo = ddlTipoSRustico.SelectedValue.ToString();
                if (ddlTipoSRustico.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UNA ZONA DE VALOR.')", true);
                }
                else
                {
                    if (ddlTipoSRustico.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','DEBE SELECCIONAR UN MUNICIPIO.')", true);
                    }
                    else
                    {
                        Double valorZonza = 0.00;
                        switch (predios.centralizado)
                        {
                            case "True"://Si es Centralizado se maneja la informacion de serverBox                                
                                EnumerableRowCollection<DataRow> query = from fila in infoMunicipio.Centralizado.ZonasValor.AsEnumerable() // la informacion de infoMunicipio.Centralizado.ZonasValor se almaceno al elegir el municipio y el tipo de predio
                                                                         where fila.Field<String>("nombreZona") == predRustico.tipoSuelo// la variable predRustico.tipoSuelo contiene el tipo de suelo seleccionado 
                                                                         select fila;
                                DataTable dt1 = query.CopyToDataTable();
                                valorZonza = Convert.ToDouble(dt1.Rows[0]["valorM2"]);//convierte el valor a doble para poder operarlo algebraicamente
                                predRustico.ValorTerrenoM2 = valorZonza;  //envia el valor de la zona de valor a la variable statica que contendra el valor
                                break;
                            case "False"://Se maneja la informacion de los descentralizados de la base de datos local
                                //DataSet ds1 = new DataSet();
                                //ds1 = GetinfoDescentralizado(1, predios.municipio, "2022");
                                //infoMunicipio.Descentralizados.dtDescentralizados = ds.Tables[0];
                                // infoMunicipio.Descentralizados.dtDescentralizados = GetinfoDescentralizado(1, predios.municipio, "2022");//contiene la tabla con la información de los municipios descentralizados                                                                                                                                                                
                              
                                EnumerableRowCollection<DataRow> query1 = from f in infoMunicipio.Descentralizados.dtDescentralizados.AsEnumerable()  // la informacion de infoMunicipio.Centralizado.ZonasValor se almaceno al elegir el municipio y el tipo de predio
                                                                          where f.Field<String>("nombreZona") == predRustico.tipoSuelo // la variable predRustico.tipoSuelo contiene el tipo de suelo seleccionado 
                                                                          select f;
                                DataTable dt2 = query1.CopyToDataTable();
                                valorZonza = Convert.ToDouble(dt2.Rows[0]["valorM2"]);//convierte el valor a doble para poder operarlo algebraicamente
                                predRustico.ValorTerrenoM2 = valorZonza;  //envia el valor de la zona de valor a la variable statica que contendra el valor
                                break;
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void GVConstrucciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GVConstrucciones.PageIndex = e.NewPageIndex;
                GVConstrucciones.DataSource = tabla;
                GVConstrucciones.DataBind(); //llena el gridview nuevamente
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        protected void btnAddObrasCom_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    if (ddlObraComplementaria.SelectedIndex == 0 || ddlCalidadObra.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','PARA PODER CONTINUAR DEBE EXISTIR INFORMACIÓN.')", true);
                    }
                    else
                    {
                        string valor = ValorConstruccion(ddlObraComplementaria, ddlCalidadObra);
                        double valorObra = infoConsRegular.VCCObraComplementaria(Convert.ToDouble(txtMetroObraComp.Text), Convert.ToDouble(valor));

                        DataRow fila = tablaObras.NewRow();
                        fila["OBRA COM"] = ddlObraComplementaria.SelectedValue.ToString();
                        fila["CALIDAD"] = ddlCalidadObra.Text;
                        fila["VALORM2"] = valorObra.ToString("c");                        // fila["VALORM2"] = ddlCalidadObra.Text;
                        tablaObras.Rows.Add(fila);       
                        //Limpiar todo lo seleccionado
                        ddlObraComplementaria.ClearSelection();
                        ddlCalidadObra.ClearSelection();                
                    }
                    //llena el gridview nuevamente
                    GVObrasComplem.DataSource = tablaObras;
                    GVObrasComplem.DataBind();
                    txtMetroObraComp.Text="";
                    ddlObraComplementaria.ClearSelection();
                    ddlCalidadObra.ClearSelection();
                    ContentAgregarObraCom.Visible = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        protected void btnAgregarConstruccion_Click(object sender, EventArgs e)
        {
            ContentAgregarConstruccion.Visible = true;
            //Llamar al metodo que va a llenar la clasificacion de la construccion
            llenarCatalgos(13, "avance", ddlAvanceConstruccion, "AVANCE DE OBRA");
            llenarCatalgos(19, "estadoConservacion", ddlCoservacion, "ESTADO DE CONSERVACIÓN");
            ddlEdadConstruc();
            CatConstruccion();
        }
        protected void btnCancelAddConstr_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                limpiarAddConstrucciones();
                ContentAgregarConstruccion.Visible = false;
            }          
        }

        protected void btnAgregarObrasComp_Click(object sender, EventArgs e)
        {            
            ContentAgregarObraCom.Visible = true;
            btnCancelAddConstr.Visible = true;
            obrasComplementarias.Visible = true;
            ddlObraComplementaria.ClearSelection();
            //    llenarCatalgos(14, "obrasComplementarias", ddlObraComplementaria, "OBRA COMPLEMENTARIA");
            CatObraCompl();
        }
        public void CatObraCompl()//llena la lista desplegable de Claseficacion de la construccion dependiendo del municipio que se selecciono
        {
            DataTable dtAux = new DataTable();
            DataSet ds = new DataSet();
            ds = Construcciones.dtConstrucciones;
            dtAux = ds.Tables[0];            
            List<string> myList = new List<String>();     
            switch (predios.centralizado)//Verifica que se centralizado o no
            {
                case "True":
                    //llena catalogos con informacion del serverbox.
                    foreach (DataRow row in dtAux.Rows)
                    {
                        myList.Add((string)row[2]);
                    }
                    myList = myList.Distinct().ToList();
                    var words = myList;
                    var query = from w in words
                                where w.Contains("OBRA") || w.Contains("BARDA") || w.Contains("REJAS") ||
                                        w.Contains("CESPED") || w.Contains("MALLA") || w.Contains("TANQUE")
                                        || w.Contains("ESTRUCTURA") || w.Contains("MAMPOSTERIA")
                                select w;
                    myList = query.ToList();
                    ddlObraComplementaria.DataSource = myList;
                    ddlObraComplementaria.DataBind();
                    ddlObraComplementaria.Items.Insert(0, new ListItem("OBRAS"));
                    break;
                case "False":
                    //llenar catalogos con informacion de base de datos local de descentralizdos
                    foreach (DataRow row in dtAux.Rows)
                    {
                        myList.Add((string)row["obraComplementaria"]);
                    }
                    myList = myList.Distinct().ToList();
                    var word = myList;
                    var quer = from w in word
                                where w.Contains("N/A")
                                select w;
                    myList = myList.Except(quer).ToList();   
                    ddlObraComplementaria.DataSource = myList;
                    ddlObraComplementaria.DataBind();
                    ddlObraComplementaria.Items.Insert(0, new ListItem("OBRAS"));
                    break;
            }




        }

        protected void btnGetAvaluo_Click(object sender, ImageClickEventArgs e)
        {
            if (IsPostBack)
            {
                style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                double a, a1;
                double b, b1;
                double c, c1;
                if (Double.TryParse(lblValorFactorTerreno.Text, style, culture, out a) && Double.TryParse(lblValorFactorconstruccion.Text, style, culture, out b) && Double.TryParse(lblValorFactorObraCom.Text, style, culture, out c))
                {
                    a1 = a;
                    b1 = b;
                    c1 = c;
                    predios.ValorCatastralTerreno = a1 + b1 + c1;
                }
                lblVALORTOTAL.Text = predios.ValorCatastralTerreno.ToString("C", new CultureInfo("es-MX"));
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenReporteUrbano()", true);
        }

        protected void txtSuperficieObra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtSuperficieObra.Text) <= predios.superficie)
                {
                    infoConstrucciones.Sc = Convert.ToDouble(txtSuperficieObra.Text);//Almacena la superfice de la construccion
                    txtSuperficieObra.BorderColor = Color.Transparent;
                    txtSuperficieObra.BorderWidth = 0;
                }
                else
                {
                    txtSuperficieObra.Text = "";
                    txtSuperficieObra.BorderColor = Color.Red;
                    txtSuperficieObra.BorderWidth = 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "OpenLetreros('warning','LA SUPERFICIE DE LA CONSTRUCCION DEBE SER MENOR O IGUAL AL VALOR TOTAL DE LA SUPERFICIE DEL PREDIO'')", true);
                }
            }catch(Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("404.aspx");
            }
                                                                            
        }

        protected void ddlAvanceConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
                infoConstrucciones.AvanceConstruccion = ddlAvanceConstruccion.SelectedValue;
                switch (ddlAvanceConstruccion.SelectedValue){
                    case "TERMINADA":
                         infoConsRegular.FTR = 1.0;
                        break;
                case "OBRA NEGRA, INSTALACIONES Y ACABADOS":
                    if (ddlClasPred.SelectedValue.Contains("HABITACIONAL HORIZONTAL")|| ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO")
                        || ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIANO")|| ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA"))
                    {
                        infoConsRegular.FTR = 1.0;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("ANTIGU") || ddlClasPred.SelectedValue.Contains("MODERNO HABITACIONAL HORIZONTAL") 
                            || ddlClasPred.SelectedValue.Contains("HABITACIONAL VERTICAL"))
                        {
                            infoConsRegular.FTR = 0.85;
                        }
                        else
                        {
                            if (ddlClasPred.SelectedValue.Contains("MODERNO") || (ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO"))
                                && ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FTR = 0.90;
                            }
                            else
                            {

                            }
                        }
                    }
                    break;
                case "OBRA NEGRA E INSTALACIONES":
                    if (ddlClasPred.SelectedValue.Contains("HABITACIONAL HORIZONTAL") || ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO")
                      || ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIANO") || ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA"))
                    {
                        infoConsRegular.FTR = 0.90;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("ANTIGU") || ddlClasPred.SelectedValue.Contains("MODERNO HABITACIONAL HORIZONTAL")
                            || ddlClasPred.SelectedValue.Contains("HABITACIONAL VERTICAL"))
                        {
                            infoConsRegular.FTR = 0.55;
                        }
                        else
                        {
                            if (ddlClasPred.SelectedValue.Contains("MODERNO") || (ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO"))
                                && ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FTR = 0.65;
                            }
                            else
                            {

                            }
                        }
                    }
                    break;
                case "OBRA NEGRA":
                    if (ddlClasPred.SelectedValue.Contains("HABITACIONAL HORIZONTAL") || ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO")
                      || ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIANO") || ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA"))
                    {
                        infoConsRegular.FTR = 0.75;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("ANTIGU") || ddlClasPred.SelectedValue.Contains("MODERNO HABITACIONAL HORIZONTAL"))
                        {
                            infoConsRegular.FTR = 0.40;
                        } else if (ddlClasPred.SelectedValue.Contains("HABITACIONAL VERTICAL")) {
                            infoConsRegular.FTR = 0.45;
                        }
                        else
                        {
                            if (ddlClasPred.SelectedValue.Contains("MODERNO") || (ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO"))
                                && ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FTR = 0.60;
                            }
                        }
                    }
                    break;
                default:
                    infoConsRegular.FTR = 1.0;
                    break;
            }          
        }

        protected void ddlEdadConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoConstrucciones.edadConstruccion = ddlEdadConstruccion.SelectedValue;
            switch (ddlAvanceConstruccion.SelectedValue)
            {
                case "01-10":
                    infoConsRegular.FED = 1.00;
                    break;
                case "11-20":
                    if (ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIO") || ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO") || ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA") || ddlCalidadConstruccion.SelectedValue.Contains("MEDIA")|| ddlCalidadConstruccion.SelectedValue.Contains("MEDIO"))
                    {
                        infoConsRegular.FED = 0.70;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("INTERES SOCIAL") || ( ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO")) || ddlCalidadConstruccion.SelectedValue.Contains("MEDIA") || ddlCalidadConstruccion.SelectedValue.Contains("MEDIO"))
                        {
                            infoConsRegular.FED = 0.80;
                        }
                        else
                        {
                            if (ddlCalidadConstruccion.SelectedValue.Contains("SUPERIOR")|| ddlCalidadConstruccion.SelectedValue.Contains("LUJO")|| ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FED = 0.90;
                            }
                            else
                            {
                                infoConsRegular.FED = 1; //Revisar si corresponde a 1 el fator en este caso, basandose en la pagina 39 del pdf del manual de valuacion
                            }
                        }
                    }
                    break;
                case "21-30":
                    if (ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIO") || ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO") || ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA"))
                    {
                        infoConsRegular.FED = 0.50;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("INTERES SOCIAL") || (ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO")))
                        {
                            infoConsRegular.FED = 0.70;
                        }
                        else
                        {
                            if (ddlCalidadConstruccion.SelectedValue.Contains("SUPERIOR") || ddlCalidadConstruccion.SelectedValue.Contains("LUJO") || ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FED = 0.80;
                            }
                            else
                            {
                                infoConsRegular.FED = 1; //Revisar si corresponde a 1 el fator en este caso, basandose en la pagina 39 del pdf del manual de valuacion
                            }
                        }
                    }
                    break;
                case "31-40":
                    if (ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIO") || ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO") || ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA"))
                    {
                        infoConsRegular.FED = 0.50;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("INTERES SOCIAL") || (ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO")))
                        {
                            infoConsRegular.FED = 0.60;
                        }
                        else
                        {
                            if (ddlCalidadConstruccion.SelectedValue.Contains("SUPERIOR") || ddlCalidadConstruccion.SelectedValue.Contains("LUJO") || ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FED = 0.70;
                            }
                            else
                            {
                                infoConsRegular.FED = 1; //Revisar si corresponde a 1 el fator en este caso, basandose en la pagina 39 del pdf del manual de valuacion
                            }
                        }
                    }
                    break;
                case "41-50":
                    if (ddlClasPred.SelectedValue.Contains("INDUSTRIAL MEDIO") || ddlClasPred.SelectedValue.Contains("INDUSTRIAL LIGERO") || ddlCalidadConstruccion.SelectedValue.Contains("PRECARIA"))
                    {
                        infoConsRegular.FED = 0.50;
                    }
                    else
                    {
                        if (ddlClasPred.SelectedValue.Contains("INTERES SOCIAL") || (ddlClasPred.SelectedValue.Contains("INDUSTRIAL PESADO")))
                        {
                            infoConsRegular.FED = 0.50;
                        }
                        else
                        {
                            if (ddlCalidadConstruccion.SelectedValue.Contains("SUPERIOR") || ddlCalidadConstruccion.SelectedValue.Contains("LUJO") || ddlCalidadConstruccion.SelectedValue.Contains("ESPECIAL"))
                            {
                                infoConsRegular.FED = 0.60;
                            }
                            else
                            {
                                infoConsRegular.FED = 1; //Revisar si corresponde a 1 el fator en este caso, basandose en la pagina 39 del pdf del manual de valuacion
                            }
                        }
                    }
                    break;
                case "51-EN ADELANTE":
                    infoConsRegular.FED = 0.50;
                    break;
                default:
                    infoConsRegular.FED = 1.0;
                    break;
            }
        }

        protected void ddlCalidadConstruccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoConstrucciones.CalidadConstruccion = ddlCalidadConstruccion.SelectedValue;
        }

        protected void ddlCoservacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoConstrucciones.edoConservacionConstruccion = ddlCoservacion.SelectedValue;
        }

        protected void btnCancelAddObraC_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ddlObraComplementaria.ClearSelection();
                ddlCalidadObra.ClearSelection();
                ContentAgregarObraCom.Visible = false;
            }
        }

        protected void btnValConstruccion_Click(object sender, EventArgs e)
        {
            //Se encarga de sealizar las sumas correspondientes a los valores de las construcciones 
            try
            {
                double suma1 = 0.0, suma2 = 0.0;
                suma1 = (double)GVConstrucciones.Rows.Cast<GridViewRow>().Sum(x => double.Parse(x.Cells[11].Text, NumberStyles.Currency));//suma los valores de la columna de la tabla de construcciones
                suma2 = (double)GVObrasComplem.Rows.Cast<GridViewRow>().Sum(x => double.Parse(x.Cells[3].Text, NumberStyles.Currency));//suma los valores de la columna de la tabla de las obras complementarias 
                lblValorFactorconstruccion.Text = suma1.ToString("C"); // se envia a la etiqueta del factor de la construccion la suma total de construcciones 
                lblValorFactorObraCom.Text = suma2.ToString("C");// se envia a la etiqueta del factor de la obras complementarias la suma total de las obras complementarias
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
