<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cavat.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <div class="container-fluid d-flex hidden" style="background-image: url(img/fnd.png); background-repeat: no-repeat; background-position: center center; background-size: cover; height: 100vh;">
        <div class="container-fluid d-flex" > 
            <div class="row align-items-center justify-content-center m-5" >
                <div class="col-6 col-sm-4 col-md-4">
                    <div class="row" style=" align-items: center; justify-content: center;">
                        <img src="img/logoCavat.png" style="width: 80%" />
                    </div>
                </div>
                <%--login--%>
                <div class="col-6 col-sm-8 col-md-8 col-xl-6 text-white d-flex justify-content-center" id="Logiin" runat="server" style="top:5px; height:35em;">
                    <div class="content text-center w-75 " style="text-align: center; margin: 3rem; align-content: center; border-radius: 10px; background: rgba(0, 0, 0,0.6); font-family: 'Josefin Sans';">
                        <div class="row p-5" style="justify-content: center;">
                               <br /> <h4>Bienvenido</h4>
                               <hr style="background: rgb(255 255 255); width: 100%; height: 0.2rem;" />
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control w-75 form-control-sm" Placeholder="Ingrese su Usuario" onkeypress="return alphaNum(event);" required="true"></asp:TextBox>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control w-75 form-control-sm" Placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="row p-1 text-center d-flex">
                                <div class="g-recaptcha" data-sitekey="6LcQgIUeAAAAABKl8HN5kGd-zVF5pbtp-IM5U2yt" style="transform: scale(0.8); transform-origin:0 auto;"> </div>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                                <asp:Label ID="lblMsg" runat="server" Font-Size="Smaller" Text="" Visible="false"></asp:Label>
                                <br />
                                <asp:LinkButton ID="lnkRegistro" runat="server" Font-Size="Smaller" Visible="true" ForeColor="#CCCCCC" OnClick="lnkRegistro_Click">¿No tiene cuenta? ¿Desea enviar una solicitud de registrarse?</asp:LinkButton>
                                &nbsp<asp:LinkButton ID="lnkRecuperaPsw" runat="server" Font-Size="Smaller" Visible="false" ForeColor="#CCCCCC" OnClick="lnkRecuperaPsw_Click">  Recuperar Contraseña</asp:LinkButton>
                       </div>
                       <div class="row p-1" style="justify-content: center;">
                                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btnEntrar btn btn-dark w-75 btn-sm" Width="100%" OnClick="btnEntrar_Click" />
                       </div>
                        </div>
                 </div>
                <%--Solicitud de Registro--%>
                <div class="col-6 col-sm-8 col-md-8 col-xl-6 text-white d-flex"  id="SolicitudReg" runat="server" style="top:5px; height:100%;" >
                    <div class="content text-center"  style="text-align: center; margin: 3rem; overflow-y:auto;  scrollbar-base-color:aqua; overflow-x:hidden; align-content: center; border-radius: 10px; background: rgba(0, 0, 0,0.6); font-family: 'Josefin Sans';">
                        <div class="row p-2" style="justify-content: center; ">
                            <div class="row p-5" style="justify-content: center;">
                               <br /> <h4>Bienvenido</h4>
                               <hr style="background: rgb(255 255 255); width: 100%; height: 0.2rem;" />
                            </div>
                            <div class="row p-1" style="justify-content: center;"><%--<div class="mb-3 d-flex justify-content-center">--%>
                                <asp:TextBox ID="txtNombreR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium" onkeypress="return onlyletters(event);" Placeholder="Ingrese su Nombre(s)"></asp:TextBox>
                            </div>
                            <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtApePatR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  onkeypress="return onlyletters(event);" Placeholder="Primer Apellido"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtApeMatR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  onkeypress="return onlyletters(event);" Placeholder="Segundo Apellido"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtCorreoR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  Placeholder="correo@ejemplo.com" TextMode="Email"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtCedulaR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  MaxLength="8" onkeypress="return onlyNumbers(event);" Placeholder="Cedúla Profesional"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:DropDownList ID="ddlPreguntaR" runat="server" Font-Size="Medium"  CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtRespuestaR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  MaxLength="250" onkeypress="return onlyletters(event);" Placeholder="Escriba su respuesta"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtTelefonoCelularR" runat="server" Font-Size="Medium"  CssClass="form-control w-75 form-control-sm" MaxLength="10" onkeypress="return onlyNumbers(event);" Placeholder="Número de contacto"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:TextBox ID="txtNumeroNotariaR" runat="server" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  MaxLength="3" onkeypress="return onlyNumbers(event);" Placeholder="Número de notaría"></asp:TextBox>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:DropDownList ID="ddlTipoUserR" runat="server" Font-Size="Medium"  CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="row p-1" style="justify-content: center;">
                                <asp:DropDownList ID="ddlTipoComR" runat="server" Font-Size="Medium"  CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Style="text-align: left;" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:FileUpload ID="flUpFileR" CssClass="form-control w-75 form-control-sm" Font-Size="Medium"  runat="server"  />
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                               <asp:LinkButton ID="lnkTerminos" runat="server" Font-Size="Smaller" data-bs-toggle="modal" data-bs-target="#ModalTerminosCondiciones">  Aceptar los  términos y condiciones.</asp:LinkButton>
                            </div>
                             <div class="row p-1" style="justify-content: center;">
                                <asp:Label ID="lblMsgReg" runat="server" Font-Size="Smaller" Text=""></asp:Label>
                            </div>
                            <div class="row p-1" style="justify-content: center;">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btnEntrar btn btn-danger btn-sm" OnClick="btnCancelar_Click" Width="80%" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnSendSolicitud" runat="server" Enabled="false" Text="Enviar Solicitud" CssClass="btnEntrar btn btn-dark btn-sm" OnClick="btnSendSolicitud_Click" Width="80%" />
                                    </div>
                                </div>

                            </div>
                    </div>
                </div>
                <%--Solicitar Cambio de Contraseña--%>

                <div class="col-6 col-sm-8 col-md-8 col-xl-6 text-white" id="RecuperacionPsw" runat="server">
                    <div class="content text-center " style="text-align: center; margin: 3rem; align-content: center; border-radius: 10px;  background: rgba(0, 0, 0,0.6); font-family: 'Josefin Sans';">
                    <div class="row p-2" Style="justify-content:center;">                      
                        <div class="row p-3" style="justify-content: center;">
                               <br /> <h4>Bienvenido</h4>
                               <hr style="background: rgb(255 255 255); width: 100%; height: 0.2rem;" />
                         </div>
                         <div class="row p-1" style="justify-content: center;">
                            <asp:TextBox ID="txtUsuRecPsw" runat="server" CssClass="form-control w-75 form-control-sm" onkeypress="return onlyletters(event);" Font-Size="Small"  Placeholder="Ingrese su usuario"></asp:TextBox>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                            <asp:TextBox ID="txtMailRecPsw" runat="server" CssClass="form-control w-75 form-control-sm" Placeholder="correo@ejemplo.com" Font-Size="Small"  TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                            <asp:DropDownList ID="ddlPregRecPsw" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-75" Font-Size="Small"  Style="text-align: left;" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                            <asp:TextBox ID="txtRespRecPsw" runat="server" CssClass="form-control w-75  form-control-sm " Font-Size="Small" Placeholder="Respuesta"></asp:TextBox>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                            <div class="g-recaptcha" data-sitekey="6LcQgIUeAAAAABKl8HN5kGd-zVF5pbtp-IM5U2yt" style="transform: scale(0.8); transform-origin:0 auto;">
                            </div>
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                            <asp:Label ID="lblmsgPsw" runat="server" Text="" Font-Size="Smaller" Visible="false"></asp:Label>
                            <br />
                        </div>
                        <div class="row p-1" style="justify-content: center;">
                                <div class="col-md-6">
                                    <asp:Button ID="btnCancelarRecPsw" runat="server" Text="Cancelar" CssClass="btnEntrar btn btn-sm btn-danger" OnClick="btnCancelarRecPsw_Click" Width="80%" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSolicitudPsw" runat="server" Text="Enviar Solicitud" CssClass="btnEntrar btn btn-sm btn-dark" Width="80%" OnClick="btnSolicitudPsw_Click" />
                                </div>
                            </div>

                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--MODAL TERMINOS Y CONDICIONES--%>
    <div class="modal fade hidden" id="ModalTerminosCondiciones" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabe3" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">
                <div class="modal-header text-white" style="background: rgb(86,75,75);">
                    <h5 class="modal-title" id="exampleModalLabe3">Tèrminos y Condiciones.</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row align-content-center text-align-justify" style="padding:3rem;">
                       <div  class="rounded mx-auto d-block" style="width:90%; background:rgba(212, 203, 198 ,0.7); padding:1rem; align-content:center;">
                            “Términos y Condiciones” es el documento que rige la relación contractual entre el proveedor de un servicio y el usuario. En la web, este documento a menudo también se denomina “Condiciones de servicio” (ToS), “Condiciones de uso”, EULA (“Acuerdo de licencia de usuario final”), “Condiciones generales” o “Notas legales”.
                            Los Términos y Condiciones no son más que un contrato en el que el titular aclara las condiciones de uso de su servicio. Algunos ejemplos son el uso del contenido (derechos de autor), las reglas que los usuarios deben seguir mientras interactúan entre sí en el sitio web/app, las reglas relacionadas con la cancelación o suspensión de la cuenta de un usuario, etc.
                            Se debe prestar especial atención a las cláusulas de limitación de responsabilidad (y descargos de responsabilidad), por ejemplo, en caso de mal funcionamiento de la aplicación o el sitio web.
                            Los Términos y Condiciones representan el documento que ayuda a prevenir y resolver los problemas. Por ello, son fundamentales en muchos casos para defenderse en caso de abuso.
                       </div>
                    </div>
                    <div class="row ">
                        <div class="col-auto mx-auto d-block"> 
                            
                        </div>
                        <div class="col-auto mx-auto d-block">
                           Acepto Tèrminos y Condiciones.
                            <asp:CheckBox ID="checkTerminos" runat="server"  OnCheckedChanged="checkTerminos_CheckedChanged" AutoPostBack="true" />
                        </div>                    
                    </div>

                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entiendo</button>--%>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
