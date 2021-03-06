<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Notarios.aspx.cs" Inherits="Cavat.Notarios" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.15/jquery.mask.min.js"></script>

    <div class="container-fluid vh-100 hidden" style="padding-top: 2rem; margin-bottom: 1em; height: 100%;">
        <div class="row ">
            <%--  MENU o BOTONES--%>
            <div class="col-12 col-sm-12 col-md-5 hidden">
                <div class="row rounded-3 mx-3 shadow-lg" style="background: #595A57;">
                    <div class="container">
                        <div class="row mx-3 rounded-top border-top-0" style="background: rgb(214 215 213 / 0.50); height: 5em; margin-top: 2em; border: inset; border-bottom: none; font-size: 0.8em;">
                            <div class="col my-auto">
                                <p style="font-weight: bold; color: white; text-align: center;">FACTOR TERRENO  </p>
                            </div>
                            <div class="col my-auto" style="text-align: center;">
                                <p style="font-weight: bold; color: white; text-align: center;">FACTOR CONSTRUCCIÓN</p>
                            </div>
                            <div class="col my-auto" style="text-align: center;">
                                <p style="font-weight: bold; color: white; text-align: center;">OBRA COMPLEMENTARIA  </p>
                            </div>
                        </div>

                        <div class="row mx-3 border-top-0" style="background: rgb(214 215 213 / 0.50); text-align: right; border: inset; border-top: none; border-bottom: none;">
                            <div class="col my-auto">
                                <h5 style="font-weight: bold; color: white; text-align: center;">
                                    <asp:Label ID="lblValorFactorTerreno" runat="server" Text="0"></asp:Label>
                                </h5>
                            </div>
                            <div class="col my-auto " style="text-align: center;">
                                <h2 style="font-weight: bold; color: white; text-align: center;">+ </h2>
                            </div>
                            <div class="col my-auto" style="text-align: center;">
                                <h5 style="font-weight: bold; color: white; text-align: center;">
                                    <asp:Label ID="lblValorFactorconstruccion" runat="server" Text="0"></asp:Label>
                                </h5>
                            </div>
                            <div class="col my-auto " style="text-align: center;">
                                <h2 style="font-weight: bold; color: white; text-align: center;">+ </h2>
                            </div>
                            <div class="col my-auto" style="text-align: center;">
                                <h5 style="font-weight: bold; color: white; text-align: center;">
                                    <asp:Label ID="lblValorFactorObraCom" runat="server" Text="0"></asp:Label>
                                </h5>
                            </div>
                        </div>

                        <div class="row rounded-bottom mx-3" style="background: rgb(214 215 213 / 0.50); text-align: right; border: inset; border-top: none;">
                            <hr style="background: white; width: 100%; height: 0.1rem; margin-bottom: 1rem; text-align: center;" />
                            <p style="font-weight: bold; color: white; text-align: right;">TOTAL: </p>
                        </div>

                        <div class="row border-bottom-0 border border-2 rounded-2 m-5" style="border: red 3px inset;">
                            <div class="col mx-auto " style="padding: 1rem; text-align: center;">
                                <asp:CheckBox ID="checkUbicarPredio" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:ImageButton ID="btnUbicaPredio" runat="server" OnClick="btnUbicaPredio_Click" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Ubicar Predio" BackColor="#590422" ImageUrl="img/btn/UbicaPredio.png" CssClass="btn" Style="width: 6em;" draggable="false" />
                                <p style="font-size: 1rem; color: gray; font-weight: bold; text-align: center;">Ubicar Predio</p>
                            </div>
                            <div class="col mx-auto" style="padding: 1rem; text-align: center;">
                                <asp:CheckBox ID="checkFactorTerreno" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:ImageButton ID="btnFactorTerreno" Enabled="false" OnClick="btnFactorTerreno_Click" runat="server" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Factor del Terreno" ImageUrl="img/btn/FactorTerreno.png" CssClass="btn" BackColor="#5F5E5C" Style="width: 6em;" draggable="false" />
                                <p style="font-size: 1rem; color: gray; font-weight: bold; text-align: center;">Factor Terreno</p>
                            </div>
                        </div>
                        <div class="row border-top-0 border border-2 m-5 rounded-2">
                            <div class="col  mx-auto" style="padding: 1rem; text-align: center;">
                                <asp:CheckBox ID="checkFactorConstruccion" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:ImageButton ID="btnFactorConstruccion" runat="server" Enabled="false" OnClick="btnFactorConstruccion_Click" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Factor de Construcción" BackColor="#A99696" ImageUrl="img/btn/factorConstr.png" CssClass="btn" Style="width: 6em;" draggable="false" />
                                <p style="font-size: 1rem; color: gray; font-weight: bold; text-align: center;">Factor Construcción</p>
                            </div>
                            <div class="col  mx-auto" style="padding: 1rem; text-align: center; align-content: center;">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnTerminar" Enabled="false" CssClass="btn " Style="background: #590422; width: 6em; height: 6em; color: white;" runat="server" Text="CALCULAR" /><%-- --%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col mx-auto" style="padding: 1rem; text-align: center;">
                                <asp:ImageButton ID="btnGeorreferencia" Visible="false" runat="server" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Georeferencia" BackColor="#F8EFEF" ImageUrl="img/btn/Georreferencia.png" CssClass="btn" Style="width: 6em;" draggable="false" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:Button ID="btnImprimir" runat="server" Text="IMPPRIMIR CALCULO" CssClass="btnEntrar btn" Font-Size="Small" Width="100%" BackColor="#003366" ForeColor="White" />
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>
            <%--INFORMACION DEPENDIENDO DEL BOTON--%>
            <div class="col-12 col-sm-12 col-md-7 hidden">
                <div class="container">
                    <%--PRESENTACION----%>
                    <div class="container rounded" style="background: transparent; padding: 2rem; height: 40rem;" id="Presentacion" runat="server">
                        <%--#F5EAF0--%>
                        <%--082346 AZUL--%>
                        <div class="row d-block align-content-center" style="margin-left: auto; margin: auto; text-align: center;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="img/mundo.gif" Style="width: 50%;" draggable="false" />
                            <%--Colocar codigo de ARgis con su mundo 3d--%>
                        </div>
                    </div>
                    <%--************UBICAR PREDIO************************--%>
                    <div class="rounded" visible="false" style="background: #D6D7D5; margin-right: 1rem; padding: 2rem; height: auto;" id="UbicacionPredio" runat="server">
                        <h4>UBICAR PREDIO</h4>
                        <hr style="background: #A71A35; width: 100%; height: 0.2rem; margin-top: 1rem;" />
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row row-cols-md-4" style="padding: 1.5rem;">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4  col-xl-4 ">
                                        <h6 style="font-size: 0.8em; text-align: left;">TIPO DE PREDIO</h6>
                                        <div class="input-group mb-2">
                                            <asp:DropDownList ID="ddlTipoPredio" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split " Style="width: 85%; text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoPredio_SelectedIndexChanged">
                                                <asp:ListItem>Tipo</asp:ListItem>
                                            </asp:DropDownList>
                                            <div class="input-group-prepend">
                                                <div class="input-group-text border-0 bg-transparent">
                                                    <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalTipoPredio" style="width: 1em; height: auto; border: none; background: none;">
                                                        <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <h6 style="font-size: 0.8em; text-align: left;">MUNICIPIO</h6>
                                        <asp:DropDownList ID="ddlMunicipio" runat="server" Enabled="false" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="display:flex;text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged">
                                            <asp:ListItem>Municipio</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" runat="server" id="tagLocalidad" visible="false">
                                        <h6 style="font-size: 0.8em; text-align: left;">LOCALIDAD</h6>
                                        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="display:flex;text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged">
                                            <asp:ListItem>Localidad</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" runat="server" id="tagParaje" visible="false">
                                        <h6 style="font-size: 0.8em; text-align: left;">PARAJE</h6>
                                        <asp:TextBox ID="txtParaje" runat="server" CssClass="form-control w-75" Style="display:flex;text-align: left;" Font-Size="Small" PlaceHolder="Paraje" OnTextChanged="txtParaje_TextChanged"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row row-cols-md-4" style="padding: 1.5rem;">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" runat="server" id="tagZonaValor" visible="false">
                                        <h6 style="font-size: 0.8em; text-align: left;">ZONA DE VALOR</h6>
                                        <asp:DropDownList ID="ddlZonaValor" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display:flex;text-align: left;" OnSelectedIndexChanged="ddlZonaValor_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Zona de Valor</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" runat="server" id="tagCalle" visible="false">
                                        <h6 style="font-size: 0.8em; text-align: left;">CALLE</h6>
                                        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control w-75" Style="display:flex;text-align: left;" Font-Size="Small" PlaceHolder="CALLE" OnTextChanged="txtCalle_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" runat="server" id="tagNumero" visible="false">
                                        <h6 style="font-size: 0.8em; text-align: left;">NÚMERO</h6>
                                        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control w-75" Style="display:flex;text-align: left;" Font-Size="Small" PlaceHolder="NÚMERO" OnTextChanged="txtNumero_TextChanged"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row" style="padding: 1.5rem;">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" runat="server" id="tagCP" visible="false">
                                        <h6 style="font-size: 0.8em; text-align: left;">CODGO POSTAL</h6>
                                        <asp:TextBox ID="txtCP" runat="server" MaxLength="5" Font-Size="Small" CssClass="form-control w-75" Style="display:flex;text-align: left;" PlaceHolder="Codigo Postal" OnTextChanged="txtCP_TextChanged" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"></div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"></div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" style="text-align: right;">
                                        <div class="input-group mb-2">
                                            <asp:Button ID="btnSiguiente1" runat="server" Text="SIGUIENTE" CssClass="btn btn-sm" Style="background: #570E25; color: white; font-weight:bold;" OnClick="btnSiguiente1_Click" />
                                            <div class="input-group-prepend " style="background: #570E25;">
                                                <div class="input-group-text border-0 bg-transparent">
                                                    <img src="img/nextt.png" style="width: 1em;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlMunicipio" />
                                <asp:AsyncPostBackTrigger ControlID="ddlTipoPredio" />
                                <asp:AsyncPostBackTrigger ControlID="ddlLocalidad" />
                                <asp:AsyncPostBackTrigger ControlID="ddlZonaValor" />
                                <asp:PostBackTrigger ControlID="btnSiguiente1" />

                            </Triggers>
                        </asp:UpdatePanel>
                    </div>


                    <%-- *************** FACTOR TERRENO *****************--%>
                    <div class="container-fluid rounded" style="background: #D6D7D5; margin-right: 1rem; padding: 0.5rem; height: auto;" id="FactorTerreno" visible="false" runat="server">
                        <div class="row">
                            <div class="col-md-12">
                                <h4>FACTOR TERRENO
                                    <asp:Label ID="lbltipoPredio" runat="server" Text=""></asp:Label></h4>
                            </div>
                        </div>
                        <%--<hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />--%>
                        <hr style="background: #A71A35; width: 100%; height: 0.2rem; margin-top: 1rem;" />

                        <%--CONTENEDOR PREDIOS RUSTICOS--%>
                        <asp:UpdatePanel runat="server" ID="UpdatePanelGrid" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="ContentRustico" visible="false" runat="server">
                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-4 p-1">
                                            <h6 style="font-size: 0.8em; text-align: left;">SUPERFICIE</h6>
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="txtSuperficieRu" runat="server" MaxLength="12" Font-Size="Small" ToolTip="Se debe ingresar la superficie total de su predio." CssClass="form-control w-50" PlaceHolder="Superfice" onkeypress="return onlyNumbersSuperficie(evt);" OnTextChanged="txtSuperficieRu_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text" style="font-size: 0.8em;">
                                                        <asp:RadioButtonList ID="RBUDMSuperficie" runat="server" OnSelectedIndexChanged="RBUDMSuperficie_SelectedIndexChanged" AutoPostBack="true" Font-Size="Small" RepeatLayout="Flow" Style="display: flex;">
                                                            <asp:ListItem>m²</asp:ListItem>
                                                            <asp:ListItem>ha</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <h6 style="font-size: 0.8em; text-align: left;">TIPO TERRENO</h6>
                                                <asp:DropDownList ID="ddlTipoSRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align: left;" AutoPostBack="true">
                                                    <%--OnSelectedIndexChanged="ddlTipoSRustico_SelectedIndexChanged"--%>
                                                </asp:DropDownList>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalTipoSueloRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-12 col-sm-12 col-md-5 col-lg-5 col-xl-4 p-1">
                                            <h6 style="font-size: 0.8em; text-align: left;">RELIEVE</h6>
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlTopografiaRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTopografiaRustico_SelectedIndexChanged"></asp:DropDownList>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalTopografiaRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-4 p-1">
                                            <h6 style="font-size: 0.8em; text-align: left;">DISTANCIA AL PREDIO</h6>
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="txtDistanciaRustico" runat="server" CssClass="form-control w-50" Font-Size="Small" PlaceHolder="Distancia" ToolTip="Se refiere a la cercanía del predio que se está valuando con la infraestructura urbana y mercado de productos." onkeypress="return onlyNumbers(event);" Visible="true" OnTextChanged="txtDistanciaRustico_TextChanged"></asp:TextBox>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <asp:DropDownList ID="ddlDistanciaUDM" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split" Style="text-align: left;">
                                                        </asp:DropDownList>
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalDisanciaRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <h6 style="font-size: 0.8em; text-align: left;">UBICACIÓN</h6>
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlUbicaciónRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align: left;" OnSelectedIndexChanged="ddlUbicaciónRustico_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-5 col-lg-5 col-xl-4 p-1"></div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--CONTENEDOR PREDIOS URBANOS--%>
                        <div id="ContentUrbano" visible="false" runat="server">
                            <div class="row justify-content p-4">
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1 ">
                                    <h6 style="font-size: 0.8em; text-align: left;">USO DE SUELO</h6>
                                    <div class="input-group mb-2">
                                        <asp:DropDownList ID="ddlUsoSueloUrbano" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="text-align: left;" OnTextChanged="ddlUsoSueloUrbano_TextChanged"></asp:DropDownList>
                                        <div class="input-group-prepend ">
                                            <div class="input-group-text bg-transparent border-0">
                                                <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUsoSueloUrbano" font-size="Small" style="width: 1em; height: auto; border: none; background: none;">
                                                    <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: inline-block;">
                                    <h6 style="font-size: 0.8em; text-align: left;">SUPERFICIE</h6>
                                    <div class="input-group mb-2">
                                        <asp:TextBox ID="txtSuperficieUrbano" runat="server" CssClass="form-control" PlaceHolder="Superficie" Font-Size="Small" ToolTip="Se refiere a la cercanía del predio que se está valuando con la infraestructura urbana y mercado de productos." onkeypress="return onlyNumbers(event);" Style="display: inline-block" Visible="true" OnTextChanged="txtSuperficieUrbano_TextChanged"></asp:TextBox>
                                        <div class="input-group-prepend ">
                                            <div class="input-group-text bg-transparent border-0">
                                                <label>m²</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: block;">
                                    <h6 style="font-size: 0.8em; text-align: left;">FRENTE</h6>
                                    <div class="input-group mb-2">
                                        <asp:TextBox ID="txtFrenterustico" runat="server" CssClass="form-control" PlaceHolder="Frente" Font-Size="Small" Style="display: inline-block" OnTextChanged="txtFrenterustico_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <div class="input-group-prepend ">
                                            <div class="input-group-text bg-transparent border-0">
                                                <label>m</label>
                                                <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalFRNETE" style="width: 1em; height: auto; border: none; background: none;">
                                                    <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>                              
                            </div>                           

                            <div class="row justify-content p-4" runat="server">                                   
                                 <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: block; text-align:center;">
                                    <h6 style="font-size: 0.8em; text-align: left;">¿PERTENECE A FRACCIONAMIENTO?</h6>
                                    <asp:DropDownList ID="ddlPreguntaFraccionamiento" Enabled="false" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display:flex; text-align:left;" AutoPostBack="true" OnTextChanged="ddlPreguntaFraccionamiento_TextChanged"></asp:DropDownList>
                                </div>
                                 <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: block;">
                                    <h6 style="font-size: 0.8em; text-align: left;">PROFUNDIDAD</h6>
                                    <div class="input-group mb-2">
                                        <asp:TextBox ID="txtProfundidad" runat="server" CssClass="form-control form-control-sm w-50" PlaceHolder="Profundidad" Font-Size="Small" onkeypress="return onlyNumbers(event);" Style="display:inline-block" Visible="true" OnTextChanged="txtProfundidad_TextChanged"></asp:TextBox>
                                        <div class="input-group-prepend ">
                                            <div class="input-group-text bg-transparent border-0">
                                                <label>m </label>
                                                <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalFONDO" style="width: 1em; height: auto; border: none; background: none;">
                                                    <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                    <h6 style="font-size: 0.8em; text-align: left;">DESNIVEL</h6>
                                    <asp:DropDownList ID="ddlDesnivelUrbano" runat="server" CssClass="btn btn-light btn-sm dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="display:flex; text-align: left;" OnSelectedIndexChanged="ddlDesnivelUrbano_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>                                
                            </div>
                            <div class="row justify-content p-4"> 
                                 <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                    <h6 style="font-size: 0.8em; text-align: left;">TIPO DESNIVEL</h6>
                                    <div class="input-group mb-2">
                                        <asp:DropDownList ID="ddlTipoDesnivelUrbano" Enabled="false" Font-Size="Small" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDesnivelUrbano_SelectedIndexChanged"></asp:DropDownList>
                                        <div class="input-group-prepend ">
                                            <div class="input-group-text bg-transparent border-0">
                                                <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalTipoDesnivelUrbano" style="width: 1em; height: auto; border: none; background: none;">
                                                    <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                    <h6 style="font-size: 0.8em; text-align: left;">UBICACION EN MANZANA</h6>
                                    <div class="input-group mb-2">
                                        <asp:DropDownList ID="ddlUbicacionManzana" runat="server" CssClass="btn btn-light btn-sm dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="text-align: left;" OnSelectedIndexChanged="ddlUbicacionManzana_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <div class="input-group-prepend ">
                                            <div class="input-group-text bg-transparent border-0">
                                                <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" style="width: 1em; height: auto; border: none; background: none;">
                                                    <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                    <h6 style="font-size: 0.8em; text-align: left;">VIALIDADES COLINDANTES</h6>
                                    <asp:DropDownList ID="ddlTipoVialidad" Enabled="false" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="display:flex; text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoVialidad_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>    

                            <div class="row justify-content p-4">
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" >
                                    <h6 style="font-size: 0.8em; text-align: left;">ESQINAS TOTALES</h6>
                                    <asp:TextBox ID="txtNoTotalEsquinas" Enabled="false" runat="server" CssClass="form-control w-75" Font-Size="Small" PlaceHolder="No de Esquinas totales" ToolTip="debe ingresar el numero de esquinas que rodea el predio" onkeypress="return onlyNumbers(event);" Visible="true" OnTextChanged="txtNoTotalEsquinas_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" >
                                    <h6 style="font-size: 0.8em; text-align: left;">ANGULO ESQINAS</h6>
                                    <asp:TextBox ID="txtAnguloEsquinas" Enabled="false" runat="server" CssClass="form-control w-75" Font-Size="Small" PlaceHolder="Ándulo de las esquinas" ToolTip="debe ingresar el numero de esquinas que rodea el predio" onkeypress="return onlyNumbers(event);" Visible="true" OnTextChanged="txtAnguloEsquinas_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" >
                                    <h6 style="font-size: 0.8em; text-align: left;">ESQUINAS COLINDANTES CON VIALIDAD</h6>
                                    <asp:TextBox ID="txtNoEsquinasColinVialidad" Enabled="false" runat="server" CssClass="form-control w-75" PlaceHolder="Cuantas esquinas colindan con el tipo  de vialidad seleccionado" Font-Size="Small" ToolTip="debe ingresar el numero de esquinas que rodea el predio" onkeypress="return onlyNumbers(event);" Visible="true" OnTextChanged="txtNoEsquinasColinVialidad_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- *************** PREGUNTA SI TIENE CONSTRUCCION *****************--%>
                        <div class="row bg-in" style="padding-top: 1rem;">
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1" style="margin-left:1em;">
                                <div class="input-group mb-2">
                                    <h6 style="font-size: 0.8em; text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Text="¿SU PREDIO CUENTA CON CONSTRUCCIÓN?"></asp:Label>
                                    </h6>
                                    <div class="input-group-prepend">
                                        <div class="input-group-text bg-transparent border-0">
                                            <asp:RadioButtonList ID="RDBntConstruccion" runat="server" OnSelectedIndexChanged="RDBntConstruccion_SelectedIndexChanged" AutoPostBack="true" Font-Size="Small" Style="display: flex;">
                                                <asp:ListItem>SI</asp:ListItem>
                                                <asp:ListItem>NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1" style="text-align: left;"></div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1" style="text-align: left;"></div>
                        </div>


                        <div class="row bg-in" style="padding-top: 1rem;" runat="server" id="btnSiguienteConstruccion" visible="true"> 
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" style="text-align: right;"></div>
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" style="text-align: right;"></div>
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" style="text-align: right;" >
                                        <div class="input-group mb-2" >
                                            <asp:Button ID="btnSiguienteConstr" runat="server" Text="SIGUIENTE" CssClass="btn btn-sm" Style="background: #570E25; color: white; font-weight:bold; border:none; width:7em;" OnClick="btnSiguienteConstr_Click" />
                                            <div class="input-group-prepend " style="background: #570E25;">
                                                <div class="input-group-text border-0 bg-transparent">
                                                    <img src="img/nextt.png" style="width: 1em;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    </div>





                    <%-- TERMINA CONTENEDOR FACTOR TERREBO--%>
                    <%-- *************** FACTORES CONSTRUCCIÓN *****************--%>
                    <div class="container rounded" style="background: #D6D7D5; margin-right: 1rem; padding: 2rem; height: 40rem; overflow-y: auto; overflow-x: hidden;" id="FactorConstruccion" visible="false" runat="server">
                        <h4>FACTOR CONSTRUCCIÓN</h4>
                        <%--    <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />--%>
                        <hr style="background: #A71A35; width: 100%; height: 0.2rem; margin-top: 1rem;" />
                        <div class="container">                           
                            <div class="row bg-danger" style="padding: 1.5rem;">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="GVConstrucciones" runat="server" DataKeyNames="AvanceObra" EmptyDataText="No elementos para mostrar." HeaderStyle-Font-Size="Small" EditRowStyle-Font-Size="Smaller" BorderColor="#CCCCCC" BorderStyle="None" CaptionAlign="Top" CssClass="table table-responsive" AutoGenerateColumns="False" AllowPaging="True" Font-Size="X-Small" PagerStyle-BackColor="White" Width="100%" OnRowCommand="GVConstrucciones_RowCommand">
                                            <AlternatingRowStyle BackColor="#F2E7EB" />
                                            <Columns>
                                                <asp:ButtonField ButtonType="Image" CommandName="eliminar" ImageUrl="~/img/backspace.png">
                                                    <ControlStyle Height="1em" Width="2em" />
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="AvanceObra" HeaderText="AVANCE OBRA">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Superficie" HeaderText="SUPERFICIE" DataFormatString="{0:d}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Clasificacion" HeaderText="CLASIFICACION">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Tipo" HeaderText="TIPO">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Calidad" HeaderText="CALIDAD">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Conservacion" HeaderText="CONSERVACIÒN"><%-- DataFormatString="{0:d}" HtmlEncode="false">--%>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Edad" HeaderText="EDAD">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Condominio" HeaderText="CONDOMINIO">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SupPriv" HeaderText="SUP PRIV">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SupInd" HeaderText="SUP IND" DataFormatString="{0:d}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ObrasComp" HeaderText="OBRAS COMP" DataFormatString="{0:d}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ObraCM" HeaderText="OBRA COMPL" DataFormatString="{0:d}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CalidadObra" HeaderText="CALIDAD OBRA" DataFormatString="{0:d}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EditRowStyle Font-Size="Smaller"></EditRowStyle>
                                            <HeaderStyle Font-Size="Small" BackColor="#590422" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination page-item" Font-Bold="True" Font-Size="Small" />
                                            <RowStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" Wrap="true" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>   
                                        <asp:PostBackTrigger ControlID="GVConstrucciones" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col" style="text-align: right; margin-top:2em;">
                                        <asp:ImageButton ID="btnAgregaConstruccion" ToolTip="AGREGAR CONSTRUCCIÓN" runat="server" ImageUrl="img/add.png" Style="width: 2.5em;" OnClick="btnAgregaConstruccion_Click" />

                                    </div>
                                </div>
                                <div class="container" runat="server" id="ContentAgregarConstruccion" visible="false" style="background:#A2A1A1;">
                                    <div class="row" style="padding: 1.5rem;">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <asp:TextBox ID="txtSuperficieObra" PlaceHolder="Superficie Construcciòn" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <asp:DropDownList ID="ddlAvanceConstruccion" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;">
                                                <asp:ListItem>AVANCE DE OBRA</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <asp:DropDownList ID="ddlClasPred" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" OnSelectedIndexChanged="ddlClasPred_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem>Clasificación de Construcción</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <asp:UpdatePanel runat="server" ID="UpdatePanel7" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row" style="padding: 1.5rem;">
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:DropDownList ID="ddlTipoConstruccion" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" OnSelectedIndexChanged="ddlTipoConstruccion_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem>Tipo de Construcción</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:DropDownList ID="ddlCalidadConstruccion" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" AutoPostBack="true">
                                                        <asp:ListItem>Calidad de Construcción</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <div class="input-group mb-2">
                                                        <asp:DropDownList ID="ddlCoservacion" runat="server" Font-Size="Small" CssClass="btn btn-sm btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;">
                                                            <%--     <asp:ListItem>Conservación</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                        <div class="input-group-prepend ">
                                                            <div class="input-group-text bg-transparent border-0">
                                                                <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalConservacion" style="width: 1em; height: auto; border: none; background: none;">
                                                                    <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                                </button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlClasPred" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlTipoConstruccion" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel runat="server" ID="UpdatePanel8" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row" style="padding: 1.5rem;">
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:DropDownList ID="ddlEdadConstruccion" runat="server" Font-Size="Small" CssClass="btn btn-sm btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1">
                                                    <h6 style="text-align: right;">¿CUENTA CON OBRAS COMPLEMENTARIAS?</h6>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-2 col-lg-2 col-xl-2 p-1 text-left">
                                                    <asp:RadioButtonList ID="RBObrasComplementarias" runat="server" AutoPostBack="true" Font-Size="Small" OnSelectedIndexChanged="RBObrasComplementarias_SelectedIndexChanged">
                                                        <asp:ListItem>SI</asp:ListItem>
                                                        <asp:ListItem>NO</asp:ListItem>
                                                    </asp:RadioButtonList>

                                                </div>
                                            </div>
                                            <div class="row" style="padding: 1rem;" runat="server" id="obrasComplementarias" visible="false">
                                                <%--visible="false"--%>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1"></div>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:DropDownList ID="ddlObraComplementaria" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" runat="server" Style="text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlObraComplementaria_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:DropDownList ID="ddlCalidadObra" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;">
                                                        <asp:ListItem>CALIDAD DE OBRA</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="RBObrasComplementarias" />
                                        </Triggers>
                                    </asp:UpdatePanel>


                                    <asp:UpdatePanel runat="server" ID="UpdatePanel9" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row" style="padding: 1.5rem;">

                                                <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1" style="text-align: left;">
                                                    <h6>¿LA PROPIEDAD PERTENECE A UN CONDOMINIO?</h6>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3 p-1" style="text-align: left;">
                                                    <asp:RadioButtonList ID="RadBtnCondominio" runat="server" AutoPostBack="true" Font-Size="Small" OnSelectedIndexChanged="RadBtnCondominio_SelectedIndexChanged">
                                                        <asp:ListItem>SI</asp:ListItem>
                                                        <asp:ListItem>NO</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3 p-1">
                                                </div>
                                            </div>
                                            <div class="row" style="padding: 1.5rem;" runat="server" id="condominio" visible="false">
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:TextBox ID="txtSupPriv" PlaceHolder="Superficie Privativa" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                                    <asp:TextBox ID="txtSubInd" PlaceHolder="Superficie Indivisa" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1"></div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="RadBtnCondominio" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="row" style="padding: 1.5rem;">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1"></div>
                                        <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1"></div>
                                        <div class="col-12 col-sm-12 col-md-2 col-lg-2 col-xl-2 p-1 text-left">
                                            <asp:Button ID="btnAddList" runat="server" CssClass="btn btn-sm" Style="background: #570E25; color: white;" Text="AGREGAR REGISTRO" OnClick="btnAddList_Click" />
                                        </div>
                                    </div>


                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAgregaConstruccion" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <%-- *************** AGREGAR CONSTRUCCION A LA LISTA    *****************--%>
                        <div class="row" style="padding: 1.5em;">
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" runat="server" id="Div1" visible="false">
                                <div class="input-group mb-2">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="text-align: left;" AutoPostBack="true"></asp:DropDownList>
                                    <div class="input-group-prepend ">
                                        <div class="input-group-text bg-transparent border-0">
                                            <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" style="width: 1em; height: auto; border: none; background: none;">
                                                <img src="img/ask.png" style="width: 100%; height: auto;" />
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- *************** GEORREFERENCIACION *****************--%>
                    <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height: 40rem;" id="Georreferencia" visible="false" runat="server">
                        <h4>Georreferenciaciòn</h4>
                        <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                        <div class="row" style="padding: 1.5rem;">
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1">
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control w-50" PlaceHolder="Latidud" Style="display: inline-block"></asp:TextBox>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1" style="display: block">
                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control w-50" PlaceHolder="Longitud" Style="display: inline-block"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" Style="display: inline-block; width: 3rem; height: auto;" ImageUrl="img/buscar.png" BackColor="#89AFB6" CssClass="btn rounded" />
                            </div>
                        </div>
                        <div class="row" style="padding-top: 10rem;">
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1">
                                <div class="row">
                                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1">
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chekMap" runat="server" Text="  Ver Mapa" OnCheckedChanged="chekMap_CheckedChanged" AutoPostBack="true" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="chekMap" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1"></div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1"></div>
                        </div>
                    </div>

                </div>
                <div class="row" runat="server" id="FOLIOTRAMITE" visible="false">
                    <div class="co-4 col-sm-4 col-md-4 col-lg-4 ">
                        <h5 class="text-danger">FOLIO: 
                            <asp:Label ID="lblFOLIOT" runat="server" Text=""></asp:Label></h5>
                    </div>
                    <div class="co-4 col-sm-4 col-md-4 col-lg-4 "></div>
                    <div class="co-4 col-sm-4 col-md-4 col-lg-4 "></div>
                </div>
            </div>
        </div>
    </div>

    <%--VISUALIZARA MAPA--%>
    <div class="container-fluid hidden" id="VerMapa" visible="false" runat="server" style="padding: 1rem;">
        <div class="row" id="map" style="width: 100%; height: 40rem;">
        </div>
    </div>
 

    <%-------- MODALES ---------%>
    <%--MODAL TIPO PREDIO--%>
    <div class="modal fade" id="ModalTipoPredio" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabel">Tipo de Predio</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Rústico</h5>
                                <p>Un terreno rústico, o suelo rústico, es un espacio de tierra que no es urbano y su uso más común es en el sector agrícola o ganadero.</p>
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
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/Suburbano.JPG" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Suburbano</h5>
                                <p>El contiguo a las zonas urbanas, con facilidad para uso habitacional, industrial o de servicios, de conformidad con lo que establezca la autoridad competente.</p>
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
    <%-- *************   MODAL FRENTE  ********************** --%>
    <div class="modal fade" id="ModalFRNETE" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabe">Modal Frente</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-4 text-center">
                                <img src="img/predio/urbano/frente1.png" style="width: 100%;" />
                            </div>
                            <div class="col-md-4 text-center">
                                <img src="img/predio/urbano/frente2.png" style="width: 100%;" />
                            </div>
                            <div class="col-md-4 text-center">
                                <img src="img/predio/urbano/frente3.png" style="width: 100%;" />
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-12 p-5">
                                <p>
                                    Se considera como frente, la dimensión del lindero que se encuentra de manera directa
                                   con la vía pública, pudiendo ser en línea recta o curva. En los casos donde se tenga
                                   colindancia a mas de una vialidad, se considerará el siguiente orden de prioridad.                                   
                                </p>
                                <ul>
                                    <li>La que se emplea como acceso principal.</li>
                                    <li>La que tenga mayor longitud.</li>
                                </ul>
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
    <%-- *************   MODAL FRENTE  ********************** --%>
    <div class="modal fade" id="ModalFONDO" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabee">Modal Frente</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-4 text-center">
                                <img src="img/predio/urbano/fondo1.png" style="width: 100%;" />
                            </div>
                            <div class="col-md-4 text-center">
                                <img src="img/predio/urbano/fondo2.png" style="width: 100%;" />
                            </div>
                            <div class="col-md-4 text-center">
                                <img src="img/predio/urbano/fondo3.png" style="width: 100%;" />
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-12 p-5">
                                <p>
                                    El fondo de un predio se considera como la distancia perpendicular
                                   desde el frente del fondo hasta el punto mas alejado. En el caso de
                                   frentes curvos, se trazará una tangente a este para medir la distancia.                                  
                                </p>
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
    <%--MODAL Uso de Suelo Rústico--%>
    <div class="modal fade" id="ModalUsoSueloRustico" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabell">Uso de suelo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/agricola.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Agrícola</h5>
                                <p>Aquel que se utiliza en el ámbito de la productividad para hacer referencia a determinado tipo de suelo que es apto para todo tipo de cultivos y plantacciones, es decir, para la actividad agrícola o agricultura.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/ganadero.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Ganadero</h5>
                                <p>Aquel que se usa para la reproducción y cría de animales mediante el uso de su vegetación como alimeto, sea aquella natural o inducida.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/forestal.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Forestal</h5>
                                <p>
                                    Sistema dinámico que ejerce funciones de soporte biológico en los ecocistemas terrestres; interviene
                                    en los ciclos de carbono, azufre, nitrógeno y fósforo como parte fundamental en el equilibrio de los
                                    ecosistemas, funciona como filtro y amortiguador que retiene sustancias, protegiendo las aguas
                                    subterráneas y superficies contra la penetración de agentes nocivos, transforma compuetos orgánicos 
                                    descomponiéndolos o modificando su estructura consiguiendo la mineralización,
                                    también proporciona materias primas renovables y no renovables de utilidad para el ser humano.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/extraccion.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Extracción</h5>
                                <p>
                                    Terreno de extracción consiste en la extracción de minerales y elementos comercializables
                                    del interior de la corteza terrestre. Estos materiales se hallan formando depósitos o
                                    yacimientos de miles de años de antigüedad geológica.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Eriazo</h5>
                                <p>
                                    Se considera terrenos eriazos aquellos que se encuentran sin cultivar por falta o exceso
                                    de agua y los terrenos improductivos y terrenos ribereños al mar los ubicados a lo largo
                                    del litoral de la República, en la franja de 1 Km. medido a partir de la línea de la más
                                    alta marea.
                                </p>
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
    <%--MODAL Uso de Suelo Urbano--%>
    <div class="modal fade" id="ModalUsoSueloUrbano" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabel4">Uso de suelo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/agricola.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Habitacional</h5>
                                <p>WQEASASDASFSFDGFASDASDASDASDSADASDASDASDASDSADASDASDSADa</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/ganadero.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Comercial Alta (Subsuelos Urbanos o Centros Comerciales) </h5>
                                <p>WQEASASDASFSFDGFASDASDASDASDSADASDASDASDASDSADASDASDSADa</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/forestal.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Comercial Media </h5>
                                <p>WQEASASDASFSFDGFASDASDASDASDSADASDASDASDASDSADASDASDSADa</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/extraccion.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Comercial Baja (Comercio de Barrio) </h5>
                                <p>WQEASASDASFSFDGFASDASDASDASDSADASDASDASDASDSADASDASDSADa</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Historica </h5>
                                <p>WQEASASDASFSFDGFASDASDASDASDSADASDASDASDASDSADASDASDSADa</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Industrial </h5>
                                <p>WQEASASDASFSFDGFASDASDASDASDSADASDASDASDASDSADASDASDSADa</p>
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
    <%--MODAL Tipo Desnivel Urbano--%>
    <div class="modal fade" id="ModalTipoDesnivelUrbano" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabel5">Uso de suelo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 40rem; overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <h5>Poco Hundido</h5>
                                <img src="img/predio/urbano/pocoHundido.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6 text-center">
                                <h5>Muy Hundido</h5>
                                <img src="img/predio/urbano/muyHundido.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <h5>Poco Elevado</h5>
                                <img src="img/predio/urbano/pocoElevado.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6 text-center">
                                <h5>Muy Elevado</h5>
                                <img src="img/predio/urbano/muyElevado.png" class="muestaImg" style="width: 70%; height: auto;" />
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
    <%--MODAL TIPO de Suelo Rústico--%>
    <div class="modal fade" id="ModalTipoSueloRustico" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabelll">Tipo de suelo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/temporal1a.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Temporal 1a</h5>
                                <p>
                                    Aquellos cuya fuente de abastecimiento de agua es la precipitación pluvial directa, 
                                    presentan suelos profundos, que se adapten y favorezcan la productividad de los
                                    cultivos de la región, con clima propicio para presentar lluvias intensas, con buenos 
                                    accesos y cercanos a vías de comunicación.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/temporal2a.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Temporal 2a</h5>
                                <p>
                                    Aquellos cuya fuente de abastecimiento de agua es la precipitación pluvial directa,
                                    presentan suelos ligeramente deficientes en adaptabilidad y productividad a los 
                                    cultivos de la región, con precipitación pluvial sensiblemente similar a la temporal
                                    primera, con regulares acceso y ligeramente alejados a vías de comunicación.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/riego.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Riego</h5>
                                <p>
                                    Terreno de Riego son los que, debido a obras artificiales, disponen de agua suficiente
                                    para sostener en forma permanente los cultivos propios de cada región,
                                    con independencia de la precipitación pluvial.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/agostaderotemporal.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Agostadero de temporal</h5>
                                <p>slkgmslgkmsgklmsdkglsmglksmdgksdml.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/agostaderoincluido.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Agostadero incluido</h5>
                                <p>
                                    Son aquellos terrenos con vegetación natural, predominantemente gramíneas, 
                                    cuya vegetación puede ser de origen natural o inducido y se aprovecha para
                                    el pastoreo directo, para corte o en forma mixta.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/monte.png" class="muestaImg" style="width: 70%; height: auto;" />
                                <p>
                                    Monte, (del latín mons y montis), desde el punto de vista biogeográfico es un terreno no
                                     urbano y sin cultivar en el que hay vegetación. Esta vegetación puede estar formada por
                                     árboles, arbustos y hierbas. Además es una eminencia topológica mayor que un cerro pero
                                     menor que una montaña.
                                </p>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <h5>Monte Alto</h5>
                                        <img src="img/predio/rustico/monteAlto.png" class="muestaImg" style="width: 50%; height: auto;" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <h5>Monte Bajo</h5>
                                        <img src="img/predio/rustico/monteBajo.png" class="muestaImg" style="width: 50%; height: auto;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/bosqueMontaña.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Bosque de Montaña</h5>
                                <p>
                                    Bosques de coníferas y caducifolios ubicados en lo alto de las montañas, se caracteriza 
                                    por tener bajas temperaturas.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/cantera.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Canteras</h5>
                                <p>
                                    Explotación minera generalmente a cielo abierto en la que se obtienen rocas industriales,
                                    ornamentales o áridas. Las canteras suelen ser explotaciones de pequeño tamaño.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/mina.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Minas</h5>
                                <p>
                                    Es el conjunto de labores o huecos necesarios para explotar minerales en un yacimiento y,
                                    en algunos casos, las plantas anexas para el tratamiento del mineral extraído.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Eriazo</h5>
                                <p>
                                    Son los terrenos pedregosos, arenosos, medianos o gruesos, o erosionados, 
                                    con poca arcilla y que por sus características propias no pueden retener 
                                    humedad suficiente, por lo que no son susceptibles de cultivo alguno.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6 text-center">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Suelos Pedregosos</h5>
                                <p>
                                    Son los que tienen muchas piedras, ya sean grandes o pequeñas y son difíciles para cultivar. 
                                    Es la manera como se unen partículas para formar terrones. Cuando las partículas del suelo,
                                    están unidas en formas de láminas o lajas se dice que hay estructura laminar.
                                </p>
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
    <%--MODAL TOPOGRAFIA Y RELIEVE Rústico--%>
    <div class="modal fade" id="ModalTopografiaRustico" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabelal">Topografía y Relieve</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/llanoPlano.png" class="muestaImg" style="width: 70%; height: auto;" draggable="false" />
                            </div>
                            <div class="col-md-6">
                                <h5>Plano o llano</h5>
                                <p>
                                    Una llanura es un campo o terreno sin altos ni bajos. Se trata, por lo tanto, de una superficie dilatada que se 
                                    caracteriza por su igualdad. Se conoce como llanura o planicie al área geográfica plana o cuya ondulación es 
                                    inferior a los 150 metros de altura sobre el nivel del mar.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/lomerioSuave.png" class="muestaImg" style="width: 70%; height: auto;" draggable="false" />
                            </div>
                            <div class="col-md-6">
                                <h5>Lomerío suave o modernamente inclinado</h5>
                                <p>
                                    El lomerío es una porción del terreno quebrado, caracterizado por una repetición de colinas redondas
                                    o lomas alargadas, con cumbres a alturas variables, separadas por valles coluvio-aluviales.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/lomerioAccidentado.png" class="muestaImg" style="width: 70%; height: auto;" draggable="false" />
                            </div>
                            <div class="col-md-6">
                                <h5>Lomerío accidentado o inclinado</h5>
                                <p>
                                    Elevación de tierra de altura pronunciada.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/escarpado.png" class="muestaImg" style="width: 70%; height: auto;" draggable="false" />
                            </div>
                            <div class="col-md-6">
                                <h5>Escarpado</h5>
                                <p>
                                    Un terreno escarpado, es aquel que posee mucha inclinación o pendiente. Se trata de elevaciones 
                                    que son abruptas, extremadamente desniveladas y contienen rocas, lo que las hacen de muy dificultoso 
                                    o imposible tránsito.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/montañoso.jpg" class="muestaImg" style="width: 70%; height: auto;" draggable="false" />
                            </div>
                            <div class="col-md-6">
                                <h5>Montañoso</h5>
                                <p>Declive del terreno y la inclinación, respecto a la horizontal, de una vertiente de la montaña</p>
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
    <%--MODAL TOPOGRAFIA Y RELIEVE Rústico--%>
    <div class="modal fade" id="ModalDisanciaRustico" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalr">Distancia al predio</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="overflow-y: auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-12">
                                <img src="img/predio/rustico/distanciaPredio.png" style="width: 100%; height: auto;" draggable="false" />
                                <p>
                                    La distancia del predio a los servicios hace se debe medir,
                                    desde el borde de la población mas cercana donde hay servicios 
                                    urbanos, hasta el borde mas cercano del predio. En caso de haber
                                    dos poblaciones, prevalecerá la distancia mas corta.
   
                                </p>
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
                    <div class="row" style="overflow-y: auto; height: 30rem;">
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
                                <p>
                                    Construcciones con acabados en mal estado, falta de pintura, elementos estructurales con pequeñas grietas, humedad en muros, falta de barníz o de esmalte en puertas, ventanas o protecciones y algunas piezas rotas en el
                                    caso de pisos o lambrines.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/conservacion/mala.jpg" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Malo</h5>
                                <p>
                                    Las construcciones cuyos acabados estén desprendiendose (aplanados inservibles), herrería con fuerte avance de corrosión, gran cantidad de vidrios
                                    rotos, muebles sanitarios con deficiente funcionamiento y algunos elementos estructurales con fallas como grietas y que nesecitan reparación mayor
                                    o su reemplazo. <b>Construcción en casi estado de abandono</b>.
                                </p>
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
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6 text-center p-5">
                            <asp:ImageButton ID="btnCabeceroManzana" runat="server" CssClass="btn rounded-2" ImageUrl="img/ubiMan/cabeManzana.png" OnClick="btnCabeceroManzana_Click" ToolTip="Cabecero de manzana" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 text-center p-5">
                            <asp:ImageButton ID="btnEsquinaa" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnEsquina.png" ToolTip="Lote en Esquina" OnClick="btnEsquinaa_Click" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6 text-center p-5">
                            <asp:ImageButton ID="btnCnAccPropio" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnCNAccesoPropio.png" OnClick="btnCnAccPropio_Click" ToolTip="Lote Interior con acceso propio" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 text-center p-5">
                            <asp:ImageButton ID="btnSNAccPropio" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnInteriorSNAccesoPropio.png" OnClick="btnSNAccPropio_Click" ToolTip="Lote Interior sin acceso propio" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6 text-center p-5">
                            <asp:ImageButton ID="btnIntermedio2Fr" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnIntermedio2Frentes.png" OnClick="btnIntermedio2Fr_Click" ToolTip="Lote intermedio con dos frentes" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 text-center p-5">
                            <asp:ImageButton ID="btnInterReg" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnIntermedioReg.png" OnClick="btnInterReg_Click" ToolTip="Lote intermedio regular" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 text-center p-5">
                            <asp:ImageButton ID="btnManzaneroo" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnManzanero.png" OnClick="btnManzaneroo_Click" ToolTip="Lote manzanero" Style="width: 20rem; height: 15rem; background: rgb(224 205 184);" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
    </div>
    <%--  MODAL UBICACION RUSTICO  --%>
    <div class="modal fade" id="ModalUbicaRustico" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModal1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content ">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModal3">UBICACIÓN PREDIO RUSTICO</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row p-2">
                        <div class="col-6 col-sm-6 col-md-6 text-center">
                            <img src="img/ubiRu/PredioInterSNDerechoPiso.png" class="muestaImg" style="width: 50%;" />
                            <h5>Predio Interior sin derecho de paso constituido</h5>
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 text-center">
                            <img src="img/ubiRu/PredioInterDerechoPiso.png" class="muestaImg" style="width: 50%;" />
                            <h5>Predio Interior con derecho de paso constituido</h5>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-6 col-sm-6 col-md-6 text-center">
                            <img src="img/ubiRu/caminovecinalTransitable.png" class="muestaImg" style="width: 50%;" />
                            <h5>Camino Vecinal Transitable durante determinadas ecopas del año</h5>
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 text-center">
                            <img src="img/ubiRu/CaminoRuralconEstructuradeTerraceriaTransitableTAno.jpg" class="muestaImg" style="width: 50%;" />
                            <h5>Camino Rural con Estructura de Terraceria Trancitable todo el año</h5>
                        </div>
                    </div>

                    <div class="row p-2">
                        <div class="col-6 col-sm-6 col-md-6 text-center">
                            <img src="img/ubiRu/carretera[Pavimentada.png" class="muestaImg" style="width: 50%;" />
                            <h5>Carretera Pavimentada</h5>
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 text-center">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
    </div>
    <%--    ******************   LETREROS     **************************--%>
    <%--MODAL PARA APROBAR SOLICITUD DE USUARIO--%>
    <div class="modal fade" id="LetreroSuccess" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header text-white text-center" style="background: rgbA(79, 71 ,71 ,0.5);">
                    <h5 class="modal-title" id="exampleModalLabel1">MENSAJE</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body text-center" style="background: rgbA(79, 71 ,71 ,0.5);">
                    <asp:Label ID="lblLetreroSuccess" runat="server" Text="" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-footer" style="background: rgbA(79, 71 ,71 ,0.5);">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>
                </div>
            </div>
        </div>
    </div>
    <%--Leaflet--%>
    <%--      <script type="text/javascript">
        //// Initialize the map
        //const map = L.map('map').setView([19.0436627, -98.1982195], 13);
        //L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        //    attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://cloudmade.com">CloudMade</a>',
        //    maxZoom: 18
        //}).addTo(map);
        //L.control.scale().addTo(map);
        //L.marker([19.0436627, -98.1982195], { draggable: true }).addTo(map);
        $(document).ready(function () {
            $("#phone").mask("(0000)0000-000");
            $("#txtSuperficieRu").mask("000-000-000.00");      
        })
      </script>--%>
    <script type="text/javascript">
                <%-- $(document).ready(function () {
            $("input[name=radioName]").click(function () {
                if ($('input:radio[name=radioName]:checked').val() === 'm') {
                    $('#<%=txtSuperficieRu.ClientID%>').mask("000000000.00");
                 } else {
                     $('#<%=txtSuperficieRu.ClientID%>').mask("000-000-000.00");
                    function onlyNumbersSuperficie(evt) {
                        // code is the decimal ASCII representation of the pressed key.
                        var code = (evt.which) ? evt.which : evt.keyCode;

                        if (code == 8 || code == 46 || code == 44) { // backspace.
                            return true;
                        } else if (code >= 48 && code <= 57) { // is a number.
                            return true;
                        } else { // other keys.
                            return false;
                        }
                    }
                 }
             });
         });--%>      



    </script>
    <script src="js/mask.js"></script>
    <%-- <script type="text/javascript" src="js/mask.js"></script>--%>
    <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js" integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==" crossorigin=""></script>
</asp:Content>
