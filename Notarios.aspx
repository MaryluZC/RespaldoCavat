<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Notarios.aspx.cs" Inherits="Cavat.Notarios" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
   <%-- <link href="css/notarios.css" rel="stylesheet" />--%>

    <div class="container-fluid" style="padding-top:2rem;">
        <div class="row">
            <%--MENU o BOTONES--%>
            <div class="col-md-5">
                <div class="row">
                    <div class="col-auto mx-auto" style="padding: 1rem;">
                        <asp:CheckBox ID="checkUbicarPredio" runat="server" AutoPostBack="true" />
                        <asp:ImageButton ID="btnUbicaPredio" runat="server" OnClick="btnUbicaPredio_Click" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Ubicar Predio" BackColor="#590422" ImageUrl="img/btn/UbicaPredio.png" CssClass="btn" Style="width: 8rem;" draggable="false" />
                        <center><p style="font-size:1.3rem; color:rgb(128 128 128); font-weight:bold;">Ubicar Predio</p></center>
                    </div>
                    <div class="col-auto mx-auto" style="padding: 1rem;">
                        <asp:CheckBox ID="checkFactorTerreno" runat="server" AutoPostBack="true" />
                        <asp:ImageButton ID="btnFactorTerreno" OnClick="btnFactorTerreno_Click" runat="server" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Factor del Terreno" ImageUrl="img/btn/FactorTerreno.png" CssClass="btn" BackColor="#5F5E5C" Style="width: 8rem;"  draggable="false"/>
                    <p style="font-size:1.3rem; color:rgb(128 128 128); font-weight:bold;">Factor Terreno</p>
                        </div>
                    <div class="col-auto   mx-auto" style="padding: 1rem;">
                        <asp:CheckBox ID="checkFactorConstruccion" runat="server" AutoPostBack="true" />
                        <asp:ImageButton ID="btnFactorConstruccion" runat="server" OnClick="btnFactorConstruccion_Click" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Factor de Construcción" BackColor="#A99696" ImageUrl="img/btn/factorConstr.png" CssClass="btn" Style="width: 8rem;" draggable="false" />
                     <p style="font-size:1.3rem; color:rgb(128 128 128); font-weight:bold;">Factor Construcción</p>
                        </div>
                    <div class="col-auto mx-auto" style="padding: 1rem;">
                        <asp:ImageButton ID="btnGeorreferencia" Visible="false" runat="server" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Georeferencia" BackColor="#F8EFEF" ImageUrl="img/btn/Georreferencia.png" CssClass="btn" Style="width: 8rem;" draggable="false" />
                    </div>
                </div>
            </div>
            <%--INFORMACION DEPENDIENDO DEL BOTON--%>
            <div class="col-md-7 mx-auto ">
                <%--PRESENTACION----%>
                <div class="container rounded mx-auto d-block" style="background:transparent; padding: 2rem; height:40rem;" id="Presentacion" runat="server">  <%--#F5EAF0--%>
                    <%--082346 AZUL--%>
                    <div class="row mx-auto d-block" style="margin: auto; align-content: center;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="img/mundo.gif" Style="width: 50%;" draggable="false" />
                    </div>
                </div>

                <%--************UBICAR PREDIO************************--%>
                <div class="container rounded" visible="false" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height:40rem;" id="UbicacionPredio" runat="server">

                    <h4>Ubicar Predio</h4>
                    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" style="text-align:left;" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged">
                                <asp:ListItem>Municipio</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" style="text-align:left;" AutoPostBack="true">
                                <asp:ListItem>Localidad</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlZonaValor" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" style="text-align:left;">
                                <asp:ListItem>Zona de Valor</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>



                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" PlaceHolder="Calle"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" PlaceHolder="Numero"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control" PlaceHolder="Colonia"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="txtParaje" runat="server" CssClass="form-control" PlaceHolder="Paraje"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="txtCP" runat="server" MaxLength="6" CssClass="form-control" PlaceHolder="Codigo Postal" OnTextChanged="txtCP_TextChanged" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-4">
                        </div>
                    </div>
                    
                    
                </div>
                <%-- *************** FACTOR TERRENO *****************--%>
                <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height:40rem;" id="FactorTerreno" visible="false" runat="server">
                    <h4>Factor Terreno</h4>
                    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4" style="display: block">
                            <asp:DropDownList ID="ddlTipoPredio" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align:left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoPredio_SelectedIndexChanged"></asp:DropDownList>
                            <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalTipoPredio" style="display: inline-block; width: 1.5rem; height: 1.5rem; border: none; background: none;">
                                <img src="img/ask.png" style="width: 100%; height: auto;" />
                            </button>
                        </div>
                        <div class="col-md-4 col-sm-4" style="display: block">
                            <asp:DropDownList ID="ddlTipoRelieve" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align:left;"></asp:DropDownList>
                            <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalRelieve" style="display: inline-block; width: 1.5rem; height: 1.5rem; border: none; background: none;">
                                <img src="img/ask.png" style="width: 100%; height: auto;" />
                            </button>
                        </div>
                        <div class="col-md-4 col-sm-4" style="display: block">
                            <asp:DropDownList ID="ddlPorcentaje" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align:left;">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlUbicacionManzana" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align:left;"></asp:DropDownList>
                            <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" style="display: inline-block; width: 1.5rem; height: 1.5rem; border: none; background: none;">
                                <img src="img/ask.png" style="width: 100%; height: auto;" />
                            </button>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control w-75 " PlaceHolder="Frente: 10.00 ml" onkeypress="return onlyNumbers(event);" Style="display: inline-block"></asp:TextBox>

                        </div>
                        <div class="col-md-4 col-sm-" style="display: block">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control w-75 " PlaceHolder="Profundidad: 40ml" onkeypress="return onlyNumbers(event);" Style="display: inline-block"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-5">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control w-50" PlaceHolder="Superfice" onkeypress="return onlyNumbers(event);" Style="display: inline-block"></asp:TextBox>
                            <asp:TextBox ID="txtUDM" runat="server" placeholder="UDM" CssClass="form-control w-25" Style="display: inline-block; text-align:center;" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-7"></div>
                    </div>
                    <h4>Datos Terreno</h4>
                    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                    <div class="row" style="padding: 1.5rem;">
                        <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlUsoSuelo" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" style="text-align:left;">
                                <asp:ListItem>Uso de Suelo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       
                        <div class="col-md-4 col-sm-4" style="display: block">     
                            <asp:DropDownList ID="ddltipoPred" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-25" Style="display: inline-block; text-align:left;">
                                <asp:ListItem>Tipo </asp:ListItem>
                            </asp:DropDownList> 
                            <asp:TextBox ID="txtCuentaPredial" MaxLength="5" runat="server" CssClass="form-control w-50 " PlaceHolder="Cuenta Predial" onkeypress="return onlyNumbers(event);" Style="display: inline-block"></asp:TextBox>
                        </div>
                         <div class="col-md-4 col-sm-4" style="display: block">                            
                            
                        </div>
                    </div>
                </div>
                </div>
           

                <%-- *************** DATOS CONSTRUCCIÓN *****************--%>
                <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height:40rem;" id="DatosConstruccion" visible="false" runat="server">
                    <h4>Datos Construcciòn</h4>
                    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="DropDownList17" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="DropDownList18" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="DropDownList19" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <%-- *************** FACTORES CONSTRUCCIÓN *****************--%>
                <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height:40rem;" id="FactorConstruccion" visible="false" runat="server">
                    <h4>Factor Construcciòn</h4>
                    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlClasPred" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" style="text-align:left;" OnSelectedIndexChanged="ddlClasPred_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Clasificación de Construcción</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlTipoConstruccion" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" style="text-align:left;" OnSelectedIndexChanged="ddlTipoConstruccion_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Tipo de Construcción</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4">
                             <asp:DropDownList ID="ddlCalidadConstruccion" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" style="text-align:left;" AutoPostBack="true">
                                   <asp:ListItem>Calidad de Construcción</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlCoservacion" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" style="text-align:left; display: inline-block;">
                        <%--     <asp:ListItem>Conservación</asp:ListItem>--%>
                            </asp:DropDownList>
                            <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalConservacion" style="display: inline-block; width: 1.5rem; height: 1.5rem; border: none; background: none;">
                                <img src="img/ask.png" style="width: 100%; height: auto;" />
                            </button>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddlAvanceConstruccion" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100">
                             <asp:ListItem>Avance de Obra</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                         <div class="col-md-4 col-sm-4">
                             <asp:DropDownList ID="ddlEdadConstruccion" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100">
                             <asp:ListItem>Edad</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <%-- *************** GEORREFERENCIACION *****************--%>
                <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height:40rem;" id="Georreferencia" visible="false" runat="server">
                    <h4>Georreferenciaciòn</h4>
                    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                    <div class="row" style="padding: 1.5rem;">
                        <div class="col-md-6 col-sm-6">
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control w-50" PlaceHolder="Latidud" Style="display: inline-block"></asp:TextBox>
                        </div>
                        <div class="col-md-6 col-sm-6" style="display: block">
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control w-50" PlaceHolder="Longitud" Style="display: inline-block"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" Style="display: inline-block; width: 3rem; height: auto;" ImageUrl="img/buscar.png" BackColor="#89AFB6" CssClass="btn rounded" />
                        </div>
                    </div>
                    <div class="row" style="padding-top: 10rem;">
                        <div class="col-md-6 col-sm-6">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:CheckBox ID="chekMap" runat="server" Text="  Ver Mapa" OnCheckedChanged="chekMap_CheckedChanged" AutoPostBack="true" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="chekMap" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-6 col-sm-6"></div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6"></div>
                    </div>
                </div>

            </div>
        </div>
        <%--VISUALIZARA MAPA--%>
        <div class="container-fluid" id="VerMapa" visible="false" runat="server" style="padding: 1rem;">
            <div class="row" id="map" style="width: 100%; height: 40rem;">
            </div>
        </div>

        <div class="row" style="padding: 1rem;">
            <div class="col-md-6 col-sm-6"></div>
            <div class="col-md-6 col-sm-6">
                <div class="row">
                    <div class="col-md-4 ">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control " PlaceHolder="Valor Catastral Aproximado" Style="display: inline-block"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btnEntrar btn btn-dark" Width="100%" />
                    </div>
                     <div class="col-md-4">
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir Calculo" CssClass="btnEntrar btn" Width="100%" BackColor="#003366" ForeColor="White"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <%-------- MODALES ---------%>

    <%--MODAL TIPO PREDIO--%>
    <div class="modal fade" id="ModalTipoPredio" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabel">Tipo de Predio</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Rústico</h5>
                                <p>El que se ubica afuera de las zonas urbanas y suburbanas y se destina a uso agrícola, ganadero, minero, pesquero, forestal o de preservación ecológica, entre otros. </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/Suburbano.JPG" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Suburbano</h5>
                                <p>El contiguo a las zonas urbanas, con facilidad para uso habitacional, industrial o de servicios, de conformidad con lo que establezca la autoridad competente.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/urbano.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Urbano</h5>
                                <p>El que ubica en zonas que cuentan, total o parcialmente, con equipamiento urbano y servicios públicos y su destino es habitacional, industrial, comercial o de servicios. </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
    </div>
      
   
     <%--MODAL CONSERVACION--%>
    <div class="modal fade" id="ModalConservacion" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabe3" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabe3">Estado de Conservación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row" style=" overflow-y:auto; height:30rem;">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/conservacion/buena.jpg" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Bueno</h5>
                                <p>Construcción nueva o en buen estado, pudiendo estar dentro de esta clasificación aún y cuando le falte pintura o reparaciones menores (grietas pequeñas o humedad aislada).</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/conservacion/estadoRegular.JPG" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Regular</h5>
                                <p>Construcciones con acabados en mal estado, falta de pintura, elementos estructurales con pequeñas grietas, humedad en muros, falta de barníz o de esmalte en puertas, ventanas o protecciones y algunas piezas rotas en el
                                    caso de pisos o lambrines.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/conservacion/mala.jpg" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Malo</h5>
                                <p>Las construcciones cuyos acabados estén desprendiendose (aplanados inservibles), herrería con fuerte avance de corrosión, gran cantidad de vidrios
                                    rotos, muebles sanitarios con deficiente funcionamiento y algunos elementos estructurales con fallas como grietas y que nesecitan reparación mayor
                                    o su reemplazo. <b>Construcción en casi estado de abandono</b>. </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
     <%--    <asp:Label ID="lblUserNot" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblNombreNot" runat="server" Text=""></asp:Label><br />--%>

    </div>


    <%--MODAL TOPOGRAFIA Y RELIEVE--%>
    <div class="modal fade" id="ModalRelieve" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModal">Topografìa y Relieve</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 mx-auto text-center" style="background: rgb(230 200 200);">
                                <h2>Nivel</h2>
                            </div>
                            <div class="col-md-6 mx-auto" style="background: rgb(230 200 200);">
                                <img src="img/relieve/Nivel.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 mx-auto text-center" style="background: rgb(247 241 200);">
                                <h2>Elevada</h2>
                            </div>
                            <div class="col-md-6 mx-auto" style="background: rgb(247 241 200);">
                                <img src="img/relieve/Elevada.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 mx-auto text-center" style="background: rgb(214 241 184);">
                                <h2>Hundida</h2>
                            </div>
                            <div class="col-md-6 mx-auto" style="background: rgb(214 241 184);">
                                <img src="img/relieve/Hundida.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
    </div>
    <%--MODAL UBICACION MANZANA--%>
    <div class="modal fade" id="ModalUbicaManzana" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModal1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content ">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModal1">Ubicación en Manzana</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                       <div class="col-md-8">
                            <img src="img/ubiMan/UbicacionManzana.png" style="width: 100%; height: auto;" />
                       </div>
                        <div class="col-md-4">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>1 Cabecera de manzana</asp:ListItem>
                                <asp:ListItem>2 Lote intermedio irregular</asp:ListItem>
                                <asp:ListItem>3 Lote intermedio regular</asp:ListItem>
                                <asp:ListItem>4 Lote interior con acceso propio</asp:ListItem>
                                <asp:ListItem>5 Intermedio con 2 frentes a distintas calles</asp:ListItem>
                                <asp:ListItem>6 Intermedio con 3 frentes a distintas calles</asp:ListItem>
                                <asp:ListItem>7 En esquina irregular </asp:ListItem>
                                <asp:ListItem>8 En esquina regular</asp:ListItem>
                                <asp:ListItem>9 Lote intermedio regular</asp:ListItem>
                                <asp:ListItem>10 Interior sin acceso propio</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
    </div>


    <%--Leaflet--%>
    <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js" integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==" crossorigin=""></script>
    <script type="text/javascript">
        // Initialize the map
        const map = L.map('map').setView([19.0436627, -98.1982195], 13);
        L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://cloudmade.com">CloudMade</a>',
            maxZoom: 18
        }).addTo(map);
        L.control.scale().addTo(map);
        L.marker([19.0436627, -98.1982195], { draggable: true }).addTo(map);
    </script>


</asp:Content>
