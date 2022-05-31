﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Notarios.aspx.cs" Inherits="Cavat.Notarios" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.15/jquery.mask.min.js"></script>

    <div class="container-fluid " style="padding-top: 2rem; margin-bottom: 5rem;">
        <div class="row">
            <%--  MENU o BOTONES--%>
            <%--<div class="col-12 col-sm-12 col-md-5 col-lg-5">--%>
            <div class="col-md-4">
                <div class="row ">
                    <div class="col-auto mx-auto" style="padding: 1rem; text-align: left;">
                        <asp:CheckBox ID="checkUbicarPredio" runat="server" AutoPostBack="true" />
                        <asp:ImageButton ID="btnUbicaPredio" runat="server" OnClick="btnUbicaPredio_Click" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Ubicar Predio" BackColor="#590422" ImageUrl="img/btn/UbicaPredio.png" CssClass="btn" Style="width: 6em;" draggable="false" />
                        <p style="font-size: 1rem; color: rgb(128 128 128); font-weight: bold;">Ubicar Predio</p>
                    </div>
                    <div class="col-auto mx-auto" style="padding: 1rem; text-align: left;">
                        <asp:CheckBox ID="checkFactorTerreno" runat="server" AutoPostBack="true" />
                        <asp:ImageButton ID="btnFactorTerreno" OnClick="btnFactorTerreno_Click" runat="server" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Factor del Terreno" ImageUrl="img/btn/FactorTerreno.png" CssClass="btn" BackColor="#5F5E5C" Style="width: 6em;" draggable="false" />
                        <p style="font-size: 1rem; color: rgb(128 128 128); font-weight: bold;">Factor Terreno</p>
                    </div>
                    <div class="col-auto  mx-auto" style="padding: 1rem; text-align: left;">
                        <asp:CheckBox ID="checkFactorConstruccion" runat="server" AutoPostBack="true" />
                        <asp:ImageButton ID="btnFactorConstruccion" runat="server" Enabled="false" OnClick="btnFactorConstruccion_Click" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Factor de Construcción" BackColor="#A99696" ImageUrl="img/btn/factorConstr.png" CssClass="btn" Style="width: 6em;" draggable="false" />
                        <p style="font-size: 1rem; color: rgb(128 128 128); font-weight: bold;">Factor Construcción</p>
                    </div>
                    <div class="col-md-4 mx-auto" style="padding: 1rem; text-align: left;">
                        <asp:ImageButton ID="btnGeorreferencia" Visible="false" runat="server" data-bs-toggle="tooltip" data-bs-placement="right" ToolTip="Georeferencia" BackColor="#F8EFEF" ImageUrl="img/btn/Georreferencia.png" CssClass="btn" Style="width: 6em;" draggable="false" />
                    </div>
                </div>
            </div>
            <%--INFORMACION DEPENDIENDO DEL BOTON--%>
            <div class="col-md-8 ">
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
                    <div class="rounded" visible="false" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height: auto;" id="UbicacionPredio" runat="server">
                        <h4>Ubicar Predio</h4>
                        <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row row-cols-md-4" style="padding: 1.5rem;">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4  col-xl-4 ">
                                        <div class="input-group mb-2">
                                            <asp:DropDownList ID="ddlTipoPredio" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-50" Style="text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoPredio_SelectedIndexChanged"></asp:DropDownList>
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
                                        <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Font-Size="Small" Style="text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged">
                                            <asp:ListItem>Municipio</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <asp:DropDownList ID="ddlLocalidad" runat="server" Visible="false" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Font-Size="Small" Style="text-align: left;" AutoPostBack="true">
                                            <asp:ListItem>Localidad</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtParaje" runat="server" CssClass="form-control" Font-Size="Small" PlaceHolder="Paraje" Visible="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row row-cols-md-4" style="padding: 1.5rem;">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <asp:DropDownList ID="ddlZonaValor" runat="server" Visible="false" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;">
                                            <asp:ListItem>Zona de Valor</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" Font-Size="Small" PlaceHolder="Calle" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" Font-Size="Small" PlaceHolder="Número" Visible="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row" style="padding: 1.5rem;">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control" Font-Size="Small" PlaceHolder="Colonia" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4">
                                        <asp:TextBox ID="txtCP" runat="server" MaxLength="5" Font-Size="Small" CssClass="form-control" Visible="false" PlaceHolder="Codigo Postal" OnTextChanged="txtCP_TextChanged" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"></div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"></div>
                                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4" style="text-align: right;">
                                        <div class="input-group mb-2">
                                            <asp:Button ID="btnSiguiente1" runat="server" Text="Siguiente" CssClass="btn btn-sm" Style="background: rgb(29 75 14); color: white;" />
                                            <div class="input-group-prepend " style="background: rgb(29 75 14);">
                                                <div class="input-group-text border-0 bg-transparent">
                                                    <img src="img/nextt.png" style="width: 1em;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <%-- *************** FACTOR TERRENO *****************--%>
                    <div class="container-fluid rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 0.5rem; height: auto;" id="FactorTerreno" visible="false" runat="server">
                        <h4>Factor Terreno 
                           <asp:Label ID="lbltipoPredio" runat="server" Text=""></asp:Label></h4>
                        <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />

                        <%--CONTENEDOR PREDIOS RUSTICOS--%>
                        <asp:UpdatePanel runat="server" ID="UpdatePanelGrid" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="ContentRustico" visible="false" runat="server">
                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="txtSuperficieRustico" ToolTip="Se debe ingresar la superficie total de su predio." Font-Size="Small" runat="server" CssClass="form-control w-75" PlaceHolder="Superfice" onkeypress="return onlyNumbers(event);" Style="width: 90%; display: inline-block" Visible="false" TextMode="Number"></asp:TextBox>
                                                <asp:TextBox ID="txtSuperficieRu" runat="server" Font-Size="Small" CssClass="form-control w-50" PlaceHolder="Superfice"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text" style="font-size: 0.8em;">
                                                        <input type='radio' class="form-check-input" id='radio_m' name='radioName' value='m' style="display: inline-block" />m  &nbsp; 
                                                    <input type='radio' class="form-check-input" id='radio_ha' name='radioName' value='ha' style="display: inline-block" />ha
                                                    </div>
                                                </div>
                                            </div>
                                            <%--  <div class="row">
                                            <div class="col-5" style="text-align: center;">
                                                <div class="row">
                                                    <div class="col-12">
                                                        
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-7">
                                               
                                            </div>
                                        </div>--%>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlUsoSueloRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split" Style="display: inline-block; text-align: left; width: 80%;" OnSelectedIndexChanged="ddlUsoSueloRustico_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUsoSueloRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlTipoSRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split" Style="width: 80%; display: inline-block; text-align: left;" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoSRustico_SelectedIndexChanged">
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

                                    </div>

                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-4 p-1">
                                            <asp:TextBox ID="txtClave" runat="server" placeholder="Clave" Font-Size="Small" CssClass="form-control" Style="display: inline-block; text-align: center; width: 80%;" Enabled="false" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlTopografiaRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align: left;" AutoPostBack="true"></asp:DropDownList>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalTopografiaRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-5 col-lg-5 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="txtDistanciaRustico" runat="server" CssClass="form-control w-50" Font-Size="Small" PlaceHolder="Distancia" ToolTip="Se refiere a la cercanía del predio que se está valuando con la infraestructura urbana y mercado de productos." onkeypress="return onlyNumbers(event);" Visible="true"></asp:TextBox>
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
                                    </div>
                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlUbicaciónRustico" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="display: inline-block; text-align: left;">
                                                </asp:DropDownList>
                                                <div class="input-group-prepend">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalDisanciaRustico" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <%--CONTENEDOR PREDIOS URBANOS--%>
                        <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height: auto; margin-top: 1rem;" id="ContentUrbano" visible="false" runat="server">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: inline-block;">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" PlaceHolder="Superficie" Font-Size="Small" ToolTip="Se refiere a la cercanía del predio que se está valuando con la infraestructura urbana y mercado de productos." onkeypress="return onlyNumbers(event);" Style="display: inline-block" Visible="true"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <label>m²</label>
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalDisanciaRustico" style="width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: block;">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="txtFrenterustico" runat="server" CssClass="form-control" PlaceHolder="Frente" Font-Size="Small" ToolTip="Se refiere a la cercanía del predio que se está valuando con la infraestructura urbana y mercado de productos." Style="display: inline-block" OnTextChanged="txtFrenterustico_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <label>m </label>
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalDisanciaRustico" style="width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: block;">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control w-50" PlaceHolder="Profundidad" Font-Size="Small" ToolTip="Se refiere a la cercanía del predio que se está valuando con la infraestructura urbana y mercado de productos." onkeypress="return onlyNumbers(event);" Style="display: inline-block" Visible="true"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <label>m </label>
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalDisanciaRustico" style="width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row justify-content p-4" runat="server">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1 ">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlUsoSueloUrbano" runat="server" CssClass="btn btn-light btn-sm dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="text-align: left;"></asp:DropDownList>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" font-size="Small" style="width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlDesnivelUrbano" runat="server" CssClass="btn btn-light btn-sm dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="text-align: left;" OnSelectedIndexChanged="ddlDesnivelUrbano_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                                    </div>
                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" style="display: block;" runat="server" id="PreguntaFraccionamiento" visible="false">
                                            <asp:DropDownList ID="ddlPreguntaFraccionamiento" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" runat="server" id="TipodesnivelUrb" visible="false">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlTipoDesnivelUrbano" Font-Size="Small" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;" AutoPostBack="true"></asp:DropDownList>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" style="width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" runat="server" id="TipoVialidad" visible="false">
                                            <div class="input-group mb-2">
                                                <asp:DropDownList ID="ddlTipoVialidad" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small" Style="text-align: left;" AutoPostBack="true"></asp:DropDownList>
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

                                    <div class="row justify-content p-4">
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" runat="server" id="TieneEsquina" visible="false">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control w-75" Font-Size="Small" PlaceHolder="No de Esquinas totales" ToolTip="debe ingresar el numero de esquinas que rodea el predio" onkeypress="return onlyNumbers(event);" Visible="true"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" style="width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" runat="server" id="AngulosEsq" visible="false">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control w-75" PlaceHolder="Ándulo de las esquinas" ToolTip="debe ingresar el numero de esquinas que rodea el predio" onkeypress="return onlyNumbers(event);" Visible="true"></asp:TextBox>
                                                <div class="input-group-prepend ">
                                                    <div class="input-group-text bg-transparent border-0">
                                                        <button type="button" title="Saber más" data-bs-placement="bottom" data-bs-toggle="modal" data-bs-target="#ModalUbicaManzana" style="display: inline-block; width: 1em; height: auto; border: none; background: none;">
                                                            <img src="img/ask.png" style="width: 100%; height: auto;" />
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1" runat="server" id="EsquinasColin" visible="false">
                                            <div class="input-group mb-2">
                                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control w-75" PlaceHolder="Cuantas esquinas colindan con el tipo  de vialidad seleccionado" Font-Size="Small" ToolTip="debe ingresar el numero de esquinas que rodea el predio" onkeypress="return onlyNumbers(event);" Visible="true"></asp:TextBox>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="row" style="padding-top: 1rem;">
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1 text-center">
                                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="¿Su predio cuenta con construcción?"></asp:Label>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-1">
                                <asp:RadioButtonList ID="RDBntConstruccion" runat="server" OnSelectedIndexChanged="RDBntConstruccion_SelectedIndexChanged" AutoPostBack="true" Font-Size="Small">
                                    <asp:ListItem>SI</asp:ListItem>
                                    <asp:ListItem>NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                    </div>

                    <%-- TERMINA CONTENEDOR FACTOR TERREBO--%>


                    <%-- *************** FACTORES CONSTRUCCIÓN *****************--%>
                    <div class="container rounded" style="background: #E5DDDD; margin-right: 1rem; padding: 2rem; height: 40rem;" id="FactorConstruccion" visible="false" runat="server">
                        <h4>Factor Construcciòn</h4>
                        <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                        <div class="row" style="padding: 1.5rem;">
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                <asp:DropDownList ID="ddlClasPred" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" OnSelectedIndexChanged="ddlClasPred_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem>Clasificación de Construcción</asp:ListItem>
                                </asp:DropDownList>
                            </div>
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
                        </div>
                        <div class="row" style="padding: 1.5rem;">
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                <div class="input-group mb-2">
                                    <asp:DropDownList ID="ddlCoservacion" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;">
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
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                <asp:DropDownList ID="ddlAvanceConstruccion" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100">
                                    <asp:ListItem>Avance de Obra</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 p-1">
                                <asp:DropDownList ID="ddlEdadConstruccion" runat="server" Font-Size="Small" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100">
                                    <asp:ListItem>Edad</asp:ListItem>
                                </asp:DropDownList>
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
            </div>
        </div>
         <div class="row">
            <h5 class="text-danger"> FOLIO:  <asp:Label ID="lblFOLIOT" runat="server" Text=""></asp:Label></h5>
         </div>
       
    </div> 

        <%--VISUALIZARA MAPA--%>
        <div class="container-fluid" id="VerMapa" visible="false" runat="server" style="padding: 1rem;">
            <div class="row" id="map" style="width: 100%; height: 40rem;">
            </div>
        </div>

        <div class="row" style="padding: 1rem;" runat="server" id="DivGetResultados" visible="false">
            <div class="col-md-6 col-sm-6"></div>
            <div class="col-md-6 col-sm-6">
                <div class="row">
                    <div class="col-md-4 ">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control " Font-Size="Small" PlaceHolder="Valor Catastral Aproximado" Style="display: inline-block"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btnEntrar btn btn-dark" Font-Size="Small" Width="100%" />
                    </div>
                     <div class="col-md-4">
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir Calculo" CssClass="btnEntrar btn" Font-Size="Small" Width="100%" BackColor="#003366" ForeColor="White"/>
                    </div>
                </div>
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
                <div class="modal-body" style="height:30rem; overflow-y:auto;">
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
      

      <%--MODAL Uso de Suelo Rústico--%>
    <div class="modal fade" id="ModalUsoSueloRustico" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class=" modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabell">Uso de suelo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="height:30rem; overflow-y:auto;">
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
                                <p>Sistema dinámico que ejerce funciones de soporte biológico en los ecocistemas terrestres; interviene
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
                                <p>Los suelos son segregados en función de los contaminantes o concentraciones que presenten. Para ello, 
                                    es necesario un correcto diseño de ejecución de la excavación, así como un adecuado control analítico 
                                    de los suelos extraídos y de los suelos remanentes. Las mediciones se realizan in-situ pero es necesario
                                    contrastar los resultados en el laboratorio. </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Eriazo</h5>
                                <p>Es un bien raíz con destino no agrícola, en el que no existen construcciones (no edificado). </p>
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
                <div class="modal-body" style="height:30rem; overflow-y:auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/temporal1a.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Temporal 1a</h5>
                                <p>Aquellos cuya fuente de abastecimiento de agua es la precipitación pluvial directa, 
                                    presentan suelos profundos, que se adapten y favorezcan la productividad de los
                                    cultivos de la región, con clima propicio para presentar lluvias intensas, con buenos 
                                    accesos y cercanos a vías de comunicación.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/temporal2a.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Temporal 2a</h5>
                                <p> Aquellos cuya fuente de abastecimiento de agua es la precipitación pluvial directa,
                                    presentan suelos ligeramente deficientes en adaptabilidad y productividad a los 
                                    cultivos de la región, con precipitación pluvial sensiblemente similar a la temporal
                                    primera, con regulares acceso y ligeramente alejados a vías de comunicación.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/riego.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Riego</h5>
                                <p>Son terrenos en los que el suministro de agua es por medios artificiales, 
                                    ya sean fuentes de agua permanente o intermitente; de depósitos, presas 
                                    o vasos. La aplicación del riego es por gravedad o por bombeo de fuerza motriz,
                                    según provenga de fuentes superficiales o profundas. Por el sistema de aplicación
                                    podrá ser de riego, aspersión, goteo, compuertas, etc.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/agostaderotemporal.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Agostadero de temporal</h5>
                                <p>slkgmslgkmsgklmsdkglsmglksmdgksdml.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/agostaderoincluido.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Agostadero incluido</h5>
                                 <p>Son aquellos terrenos con vegetación natural, predominantemente gramíneas, 
                                    cuya vegetación puede ser de origen natural o inducido y se aprovecha para
                                    el pastoreo directo, para corte o en forma mixta.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/monteAlto.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Monte Alto</h5>
                                <p>Son aquellos terrenos en los que se presenta el desarrollo de diversas
                                    especies arbóreas que son utilizadas en aprovechamientos maderables y
                                    otros productos derivados, en beneficio del género humano. Equivalente a terreno boscoso. </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/monteBajo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Monte Bajo</h5>
                                <p>Terrenos en los que se presenta el desarrollo de vegetación baja como matorrales,
                                    diversas especies de hierbas y arbustos. Este tipo de vegetación resulta el 
                                    escondite de diversos insectos. </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/bosqueMontaña.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Bosque de Montaña</h5>
                                <p> Bosques de coníferas y caducifolios ubicados en lo alto de las montañas, se caracteriza 
                                    por tener bajas temperaturas.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/cantera.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Canteras</h5>
                                <p> Explotación minera generalmente a cielo abierto en la que se obtienen rocas industriales,
                                    ornamentales o áridas. Las canteras suelen ser explotaciones de pequeño tamaño. </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/mina.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Minas</h5>
                                <p>Es el conjunto de labores o huecos necesarios para explotar minerales en un yacimiento y,
                                    en algunos casos, las plantas anexas para el tratamiento del mineral extraído.</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/eriazo.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Eriazo</h5>
                                <p>Son los terrenos pedregosos, arenosos, medianos o gruesos, o erosionados, 
                                    con poca arcilla y que por sus características propias no pueden retener 
                                    humedad suficiente, por lo que no son susceptibles de cultivo alguno. </p>
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
                <div class="modal-body" style="height:30rem; overflow-y:auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/llanoPlano.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Plano o llano</h5>
                                <p>Forma terrestre plana no perturbada en la superficie de la tierra. Un relieve llano es un área amplia de masa de tierra que
                                    generalmene no cambia mucho en elevación.
                                </p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/lomerioSuave.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Lomerío suave o modernamente inclinado</h5>
                                <p>Elevación de tierra de altura pequeña y prolongada</p>
                            </div>
                        </div>
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/lomerioAccidentado.png" class="muestaImg" style="width: 70%; height: auto;" />
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
                                <img src="img/predio/rustico/escarpado.png" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Escarpado</h5>
                                <p>Terreno muy inclinado, que no permite el paso. </p>
                            </div>
                        </div>   
                         <div class="row" style="padding: 1rem;">
                            <div class="col-md-6">
                                <img src="img/predio/rustico/montañoso.jpg" class="muestaImg" style="width: 70%; height: auto;" />
                            </div>
                            <div class="col-md-6">
                                <h5>Montañoso</h5>
                                <p>Representan frágiles cimientos de ecosistemas que en última instancia proporcionan agua a más de la población. </p>
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
                <div class="modal-body" style="height:30rem; overflow-y:auto;">
                    <div class="row">
                        <div class="row" style="padding: 1rem;">
                            <div class="col-md-8">
                                <img src="img/predio/rustico/distanciaPredio.png"  style="width: 100%; height: auto;" />
                            </div>
                            <div class="col-md-4">
                                <h5>Distancia al predio</h5>
                                <p>
                                    Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas "Letraset", las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.
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
                <div class="modal-body" style="height: 30rem; overflow-y: auto;">
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnCabeceroManzana" runat="server" CssClass="btn" ImageUrl="img/ubiMan/cabeManzana.png" OnClick="btnCabeceroManzana_Click" ToolTip="Cabecero de manzana" Style="width: 90%;" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnEsquinaa" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnEsquina.png" ToolTip="Lote en Esquina" OnClick="btnEsquinaa_Click" Style="width: 90%;" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnCnAccPropio" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnCNAccesoPropio.png" OnClick="btnCnAccPropio_Click" ToolTip="Lote Interior con acceso propio" Style="width: 90%;" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnSNAccPropio" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnInteriorSNAccesoPropio.png" OnClick="btnSNAccPropio_Click" ToolTip="Lote Interior sin acceso propio" Style="width: 80%;" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnIntermedio2Fr" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnIntermedio2Frentes.png" OnClick="btnIntermedio2Fr_Click" ToolTip="Lote intermedio con dos frentes" Style="width: 80%;" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnInterReg" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnIntermedioReg.png" OnClick="btnInterReg_Click" ToolTip="Lote intermedio regular" Style="width: 80%;" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6">
                            <asp:ImageButton ID="btnManzaneroo" runat="server" CssClass="btn" ImageUrl="img/ubiMan/btnManzanero.png" OnClick="btnManzaneroo_Click" ToolTip="Lote manzanero" Style="width: 80%;" />
                        </div>
                        <div class="col-6 col-sm-6 col-md-6">
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
           $(document).ready(function () {              

               $("input[name=radioName]").click(function () {
                  /* alert("La edad seleccionada es: " + $('input:radio[name=radioName]:checked').val());*/
                   if ($('input:radio[name=radioName]:checked').val() === 'm') {
                       /*alert("Metro: " + $('input:radio[name=radioName]:checked').val());*/
                       $('#<%=txtSuperficieRu.ClientID%>').mask("000000000.00");
                   } else {
                     /*  alert("Hectarea: " + $('input:radio[name=radioName]:checked').val());*/
                       $('#<%=txtSuperficieRu.ClientID%>').mask("000-000-000.00");
                   }     
               });

            <%--   $('#<%=txtSuperficieRu.ClientID%>').keypress(function () {
                   if ($('input:radio[name=radioName]').not(':checked')) {
                     
                       alert('seleccione');
                   }
               });--%>

         
  });
       </script>
     <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js" integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==" crossorigin=""></script>
</asp:Content>
