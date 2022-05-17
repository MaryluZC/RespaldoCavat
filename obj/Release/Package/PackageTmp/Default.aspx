<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cavat.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <div class="container-fluid" style="background-image: url(img/fnd.png); background-repeat: no-repeat; background-position: center center; background-size: cover; height: 100vh;">
        <div class="container" style="display: flex; align-items: center; justify-content: center; min-height: 100vh;">
            <div class="row" style="display: flex; align-items: center; justify-content: center;">
                <div class="col-md-6">
                    <div class="row">
                        <img src="img/logoCavat.png" style="width: 90%" />
                    </div>
                </div>
                <%--login--%>
                <div class="col-md-6 text-white" id="Logiin" runat="server" style="background: rgba(0, 0, 0,0.6); border-radius: 10px; font-family: 'Josefin Sans'">
                    <div class="row" style="text-align: center; margin: 3rem; align-content: center;">
                        <div class="mb-3">
                            <h2>Bienvenido</h2>
                            <hr style="background: rgb(255 255 255); width: 100%; height: 0.2rem;" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" Placeholder="Ingrese su Usuario" onkeypress="return alphaNum(event);" required="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div class="g-recaptcha" data-sitekey="6LcQgIUeAAAAABKl8HN5kGd-zVF5pbtp-IM5U2yt">
                            </div>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lblMsg" runat="server" Text="" Visible="false"></asp:Label>
                            <br />
                            <asp:LinkButton ID="lnkRegistro" runat="server" Visible="true" ForeColor="#CCCCCC" OnClick="lnkRegistro_Click" >¿No tiene cuenta? ¿Desea enviar una solicitud de registrarse?</asp:LinkButton>
                            <asp:LinkButton ID="lnkRecuperaPsw" runat="server" Visible="false" ForeColor="#CCCCCC" OnClick="lnkRecuperaPsw_Click">Recuperar Contraseña</asp:LinkButton>
                        </div>
                        <div class="mb-3">
                            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btnEntrar btn btn-dark" Width="100%" OnClick="btnEntrar_Click" />
                        </div>
                    </div>
                </div>

                <%--Solicitud de Registro--%>

                <div class="col-md-6 text-white" id="SolicitudReg" runat="server" style="background: rgba(0, 0, 0,0.6); border-radius: 10px; font-family: 'Josefin Sans'">
                    <div class="row" style="text-align: center; margin: 3rem; align-content: center;">
                        <div class="mb-3">
                            <h2>Bienvenido</h2>
                            <hr style="background: rgb(255 255 255); width: 100%; height: 0.2rem;" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtNombreR" runat="server" CssClass="form-control" onkeypress="return onlyletters(event);" Placeholder="Ingrese su Nombre(s)"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtApePatR" runat="server" CssClass="form-control" onkeypress="return onlyletters(event);" Placeholder="Primer Apellido"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtApeMatR" runat="server" CssClass="form-control" onkeypress="return onlyletters(event);" Placeholder="Segundo Apellido"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtCorreoR" runat="server" CssClass="form-control" Placeholder="correo@ejemplo.com" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtCedulaR" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);" Placeholder="Cedúla Profesional"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:DropDownList ID="ddlPreguntaR" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtRespuestaR" runat="server" CssClass="form-control" MaxLength="250" onkeypress="return onlyletters(event);" Placeholder="Escriba su respuesta"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtTelefonoCelularR" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return onlyNumbers(event);" Placeholder="Número de contacto"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtNumeroNotariaR" runat="server" CssClass="form-control" MaxLength="3" onkeypress="return onlyNumbers(event);" Placeholder="Número de notaría"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:DropDownList ID="ddlTipoUserR" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <asp:DropDownList ID="ddlTipoComR" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <asp:FileUpload ID="flUpFileR" CssClass="form-control" runat="server" Width="100%" />
                        </div>
                        <div class="mb-3" style="text-align: left;">
                            Aceptar los
                            <asp:LinkButton ID="lnkTerminos" runat="server" data-bs-toggle="modal" data-bs-target="#ModalTerminosCondiciones">términos y condiciones.</asp:LinkButton>
                        </div>
                        <div class="mb-3" style="text-align: center; font-size: 1.3rem;">
                            <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="mb-3">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btnEntrar btn btn-danger" OnClick="btnCancelar_Click"  Width="80%" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSendSolicitud" runat="server" Enabled="false" Text="Enviar Solicitud" CssClass="btnEntrar btn btn-dark"  OnClick="btnSendSolicitud_Click" Width="80%" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <%--Solicitar Cambio de Contraseña--%>

                <div class="col-md-6 text-white" id="RecuperacionPsw" runat="server" style="background: rgba(0, 0, 0,0.6); border-radius: 10px; font-family: 'Josefin Sans'">
                    <div class="row" style="text-align: center; margin: 3rem; align-content: center;">
                        <div class="mb-3">
                            <h2>Bienvenido</h2>
                            <hr style="background: rgb(255 255 255); width: 100%; height: 0.2rem;" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtUsuRecPsw" runat="server" CssClass="form-control" onkeypress="return onlyletters(event);" Placeholder="Ingrese su usuario"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtMailRecPsw" runat="server" CssClass="form-control" Placeholder="correo@ejemplo.com" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:DropDownList ID="ddlPregRecPsw" runat="server" CssClass="btn btn-light dropdown-toggle dropdown-toggle-split w-100" Style="text-align: left;" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtRespRecPsw" runat="server" CssClass="form-control" Placeholder="Respuesta"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div class="g-recaptcha" data-sitekey="6LcQgIUeAAAAABKl8HN5kGd-zVF5pbtp-IM5U2yt">
                            </div>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lblmsgPsw" runat="server" Text="" Visible="false"></asp:Label>
                            <br />
                        </div>
                        <div class="mb-3">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button ID="btnCancelarRecPsw" runat="server" Text="Cancelar" CssClass="btnEntrar btn btn-danger" OnClick="btnCancelarRecPsw_Click" Width="80%" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSolicitudPsw" runat="server" Text="Enviar Solicitud" CssClass="btnEntrar btn btn-dark" Width="80%" OnClick="btnSolicitudPsw_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--MODAL TERMINOS Y CONDICIONES--%>
    <div class="modal fade" id="ModalTerminosCondiciones" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabe3" aria-hidden="true">
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
