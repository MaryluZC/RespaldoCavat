using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cavat.data;
using InfoUsuarios;
using InfoUsuarios.cache;

namespace Cavat
{
    public partial class Notarios : System.Web.UI.Page
    {
     
            catalogos cat = new catalogos();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (UserLoginCache.nombre == string.Empty || UserLoginCache.nombre == null )
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ddlmunicipio();
                    ddlRelieve();
                    ddlTipoPredio1();
                    ddlUbicaManzana();
                    ddlTipoPredio2();
                    ddlRelPorcentaje();
                    ddlUbicaManzana();
                    ddlClasificacionPred();
                    ddlConvercavionConstrucion();
                    ddlEdadConstruc();

                    //lblUserNot.Text = "Usuario: " + UserLoginCache.tipoUser;///Coloca el nombre del Usuario
                    //lblNombreNot.Text = "Nombre: " + UserLoginCache.nombre + " " + UserLoginCache.ape1 + " " + UserLoginCache.ape2;
                }
            }
        }
        public void ddlEdadConstruc()
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlEdadConstruccion.Items.Insert(0, new ListItem("Edad"));
                    ddlEdadConstruccion.Items.Insert(1, new ListItem("1 - 10 Años"));
                    ddlEdadConstruccion.Items.Insert(2, new ListItem("11 - 20 Años"));
                    ddlEdadConstruccion.Items.Insert(3, new ListItem("21 - 30 Años"));
                    ddlEdadConstruccion.Items.Insert(4, new ListItem("31 - 40 Años"));
                    ddlEdadConstruccion.Items.Insert(5, new ListItem("41 - 50 Años"));
                    ddlEdadConstruccion.Items.Insert(6, new ListItem("51 - En adelante"));

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
                    ddlCoservacion.Items.Insert(0, new ListItem("Conservación"));
                    ddlCoservacion.Items.Insert(1, new ListItem("Bueno"));
                    ddlCoservacion.Items.Insert(2, new ListItem("Regular"));
                    ddlCoservacion.Items.Insert(3, new ListItem("Malo"));

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlRelPorcentaje()
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlPorcentaje.Items.Insert(0, new ListItem("Porcentaje"));
                    ddlPorcentaje.Items.Insert(1, new ListItem("0% (Nivel)"));
                    ddlPorcentaje.Items.Insert(2, new ListItem("1-5%"));
                    ddlPorcentaje.Items.Insert(3, new ListItem("5.1-10%"));
                    ddlPorcentaje.Items.Insert(4, new ListItem("10.1-20%"));
                    ddlPorcentaje.Items.Insert(5, new ListItem("20.1-30%"));
                    ddlPorcentaje.Items.Insert(6, new ListItem("30.1-40%"));
                    ddlPorcentaje.Items.Insert(7, new ListItem("40.1-50%"));
                    ddlPorcentaje.Items.Insert(8, new ListItem("50.1-Más%"));

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlTipoPredio1()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(6);//--> Catalogo Localidades 
                    ddlTipoPredio.DataSource = ddt;
                    ddlTipoPredio.DataValueField = "tipPredio";
                    ddlTipoPredio.DataBind();
                    ddlTipoPredio.Items.Insert(0, new ListItem("Tipo de Predio"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlTipoPredio2()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(6);//--> Catalogo Localidades 
                    ddltipoPred.DataSource = ddt;
                    ddltipoPred.DataValueField = "tipPredio";
                    ddltipoPred.DataBind();
                    ddltipoPred.Items.Insert(0, new ListItem("Tipo"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlmunicipio()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable ddt;
                    ddt = cat.Catalogo(4);//--> Catalogo Municipio
                    ddlMunicipio.DataSource = ddt;
                    ddlMunicipio.DataValueField = "municipio";
                    ddlMunicipio.DataBind();
                    ddlMunicipio.Items.Insert(0, new ListItem("Municipio"));
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
                    ddlUbicacionManzana.Items.Insert(0, new ListItem("Ubicaciòn Manzana"));
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
                    ddlClasPred.Items.Insert(0, new ListItem("Clasificación de Construcción"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        public void ddlRelieve()
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlTipoRelieve.Items.Insert(0, new ListItem("Topografìa y relieve"));
                    ddlTipoRelieve.Items.Insert(1, new ListItem("Nivel"));
                    ddlTipoRelieve.Items.Insert(2, new ListItem("Elevada"));
                    ddlTipoRelieve.Items.Insert(3, new ListItem("Hundida"));

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
            DatosConstruccion.Visible = false;
            FactorTerreno.Visible = false;
            FactorConstruccion.Visible = false;
            Georreferencia.Visible = false;
        }

        protected void btnFactorTerreno_Click(object sender, ImageClickEventArgs e)
        {
            UbicacionPredio.Visible = false;
            Presentacion.Visible = false;
            DatosConstruccion.Visible = false;
            VerMapa.Visible = false;
            FactorTerreno.Visible = true;
            FactorConstruccion.Visible = false;
            Georreferencia.Visible = false;
        }

        protected void btnFactorConstruccion_Click(object sender, ImageClickEventArgs e)
        {
            UbicacionPredio.Visible = false;
            Presentacion.Visible = false;
            DatosConstruccion.Visible = false;
            VerMapa.Visible = false;
            FactorTerreno.Visible = false;
            FactorConstruccion.Visible = true;
            Georreferencia.Visible = false;
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int va = int.Parse(ddlMunicipio.SelectedIndex.ToString());
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
                    ddlLocalidad.Items.Insert(0, new ListItem("Localidad"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
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
                int va = int.Parse(ddlTipoPredio.SelectedIndex.ToString());//Label1.Text = va.ToString();                
                try
                {
                    if (va == 1)
                    {
                        txtUDM.Text = "ha";
                    }
                    else
                    {
                        txtUDM.Text = "m²";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string valor =  RadioButtonList1.SelectedItem.Text.ToString();//Obtiene el string del elemeto
            int valor1 = int.Parse(RadioButtonList1.SelectedIndex.ToString());//obtiene el indice del elemento
            switch (valor1)
            {
                case 0:
                    ddlUbicacionManzana.SelectedIndex = 1;
                    break;
                case 1:
                    ddlUbicacionManzana.SelectedIndex = 2;
                    break;
                case 2:
                    ddlUbicacionManzana.SelectedIndex = 3;
                    break;
                case 3:
                    ddlUbicacionManzana.SelectedIndex = 4;
                    break;
                case 4:
                    ddlUbicacionManzana.SelectedIndex = 5;
                    break;
                case 5:
                    ddlUbicacionManzana.SelectedIndex = 6;
                    break;
                case 6:
                    ddlUbicacionManzana.SelectedIndex = 7;
                    break;
                case 7:
                    ddlUbicacionManzana.SelectedIndex = 8;
                    break;
                case 8:
                    ddlUbicacionManzana.SelectedIndex = 9;
                    break;
                case 9:
                    ddlUbicacionManzana.SelectedIndex = 10;
                    break;
                default:
                    ddlUbicacionManzana.ClearSelection();
                    break;
            }
        }

    }
}