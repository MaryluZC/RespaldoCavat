<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Cavat.Admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
 <asp:UpdatePanel runat="server" ID="UpdatePanel5">
        <ContentTemplate>
<nav class="navbar navbar-expand-lg navbar-light hidden" style="background:white; text-align:center;">   
            <div class="container-fluid">
                <button class="navbar-toggler text-decoration-none" style="background:#b69e9e; float:right;" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" ">
                    <span class="navbar-toggler-icon"></span>
                </button>                        
                           
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mx-auto ">
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkHome" CssClass="nav-link animate__animated animate__fadeInDown" OnClick="lnkHome_Click" Style="font-weight: bold;" runat="server">Solicitud de Registro</asp:LinkButton>
                        </li>
                        <li class="nav-item ">
                            <asp:LinkButton ID="lnkUserRegistrados" CssClass="nav-link  animate__animated animate__fadeInDown" OnClick="lnkUserRegistrados_Click" Style="font-weight: bold;" runat="server">Usuarios Registrados</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkCambioPsw" CssClass="nav-link animate__animated animate__fadeInDown" OnClick="lnkCambioPsw_Click" Style="font-weight: bold;" runat="server">Cambios de Contraseña</asp:LinkButton>
                        </li>
                     </ul>
                </div>
            </div>        
</nav>   
</ContentTemplate>
</asp:UpdatePanel>

        <div class="container-fluid hidden">
            <div class="row">
                <div class="col-md-3">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <div class="row" runat="server" id="ContenRegNewNotario">
                                <div class="row text-white" style="background: rgb(89,4,34); font-weight: bold; margin: 0.5rem;">
                                    <span>Registro de Nuevo Notario</span>
                                </div>
                                <div class="row text-white" style="background: rgb(242,239,239); margin: 0.5rem;">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNombre" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Nombre" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtApe1" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Primer Apellido" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtApe2" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Segundo Apellido" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtcorreo" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="correo@ejemplo.com" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtTelefono" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Telefono" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtPregunta" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Pregunta" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtRespuesta" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Repuesta" Style="margin-top: 0.5rem;"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNotaria" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Notaria" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtCedulaP" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Cedula Profesional" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtTipoUser" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Tipo Usuario" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtComprobante" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Comprobante" Style="margin-top: 0.5rem;"></asp:TextBox>

                                        <asp:Button ID="btnGenerarUP" runat="server" Text="Generar Usuario y Contraseña" Style="margin-top: 0.5rem;" Font-Size="Small" CssClass="btnEntrar btn btn-dark form-control form-control-sm" OnClick="btnGenerarUP_Click" /><%-- OnClick="btnGenerarUP_Click" />--%>

                                        <asp:TextBox ID="txtNewUser" CssClass="form-control form-control-sm" Font-Size="Small" runat="server" Placeholder="Usuario" Style="margin-top: 0.5rem;" Enabled="false"></asp:TextBox>
                                        <asp:TextBox ID="txtNewPsw" CssClass="form-control form-control-sm" Font-Size="Small" runat="server" Placeholder="Password" Style="margin-top: 0.5rem;" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="col-md-12 mx-auto">
                                        <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="lblMsgAviso" runat="server" Text="" Style="text-align:left; padding:1em;"></asp:Label><br />
                                                <div class="row">
                                                    <div class="col-md-6 mx-auto">
                                                        <asp:Button ID="btnAgregar" runat="server" Text="Aprobar" CssClass="btnEntrar btn btn-dark btn-sm" Width="100%" Style="margin-bottom: 2rem;" OnClick="btnAgregar_Click" />
                                                    </div>
                                                    <div class="col-md-6 mx-auto">
                                                        <asp:Button ID="btnDenegar" runat="server" Text="Denegar" CssClass="btnEntrar btn text-white btn-sm" Width="100%" Style="margin-bottom: 2rem; background: #590422;" OnClick="btnDenegar_Click" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnAgregar" />
                                                <asp:AsyncPostBackTrigger ControlID="btnDenegar" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <div class="row">
                                            <div class="col-md-12 mx-auto">
                                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btnEntrar btn btn-dark btn-sm" Width="100%" Style="margin-bottom: 2rem;" OnClick="btnLimpiar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                        <ContentTemplate>
                            <div class="row" runat="server" id="CambioPsw" visible="false">
                                <div class="row text-white" style="background: rgb(89,4,34); font-weight: bold; margin: 0.5rem;">
                                    <span>Cambio de Contraseña</span>
                                </div>
                                <div class="row text-white" style="background: rgb(242,239,239); margin: 0.5rem;">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNombreCPSW" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Nombre" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtApe1CPSW" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Primer Apellido" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtApe2CPSW" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="Segundo Apellido" Style="margin-top: 0.5rem;"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtMailCPSW" CssClass="form-control form-control-sm" Enabled="false" Font-Size="Small" runat="server" Placeholder="correo@ejemplo.com" Style="margin-top: 0.5rem;"></asp:TextBox>
                                        <asp:TextBox ID="txtUserCPSW" CssClass="form-control form-control-sm" Font-Size="Small" runat="server" Placeholder="Usuario" Style="margin-top: 0.5rem;" Enabled="false"></asp:TextBox>
                                        <asp:Button ID="btnCPSW" runat="server" Text="Generar Nueva Contraseña" OnClick="btnCPSW_Click" Style="margin-top: 0.5rem;" Font-Size="Small" CssClass="btnEntrar btn btn-dark form-control form-control-sm" /><%-- OnClick="btnCPSW_Click" />--%>
                                        <asp:TextBox ID="txtNewCPSW" CssClass="form-control form-control-sm" Font-Size="Small" runat="server" Placeholder="Password" Style="margin-top: 0.5rem;" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="col-md-12 mx-auto">
                                        <hr style="background: rgb(128 128 128); width: 100%; height: 0.1rem; margin-top: 1rem;" />

                                        <asp:Label ID="lblMsgCPW" runat="server" Text=""></asp:Label><br />
                                        <div class="row">
                                            <div class="col-md-6 mx-auto">
                                                <asp:Button ID="btnLimpiarCPW" runat="server" Text="Limpiar" CssClass="btnEntrar btn btn-dark btn-sm" Width="100%" Style="margin-bottom: 2rem;" OnClick="btnLimpiarCPW_Click" />
                                            </div>
                                            <div class="col-md-6 mx-auto">
                                                <asp:Button ID="btnEnviarCPW" runat="server" Text="Enviar" CssClass="btnEntrar btn text-white btn-sm" Width="100%" Style="margin-bottom: 2rem; background: #590422;" OnClick="btnEnviarCPW_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCPSW" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            <div class="col-md-9">
                <div class="row text-white" style="background:rgb(89,4,34); font-weight:bold;  margin:0.5rem;">
                    <asp:Label ID="lblLetterOption" runat="server" Text="SOLICITUDES DE REGISTRO"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-3"></div>
                    <div class="col-md-3"></div>
                    <div class="col-md-3 mx-auto">
                        <asp:TextBox ID="txtBusca1" CssClass="form-control form-control-sm" Font-Size="Small" runat="server" Placeholder="Usuario" Style="margin-top:0.5rem; width:90%;"></asp:TextBox>
                    </div>
                </div>
                <div class="row text-white" id="listUsers" >
                    <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                        <ContentTemplate>
                           <asp:GridView ID="GVSolicitudes" runat="server" EmptyDataText="No hay nuevas solicitudes de registro."  BorderColor="#CCCCCC" BorderStyle="None" CssClass="table table-responsive shadow" AutoGenerateColumns="False" AllowPaging="True" Font-Size="X-Small" PagerStyle-BackColor="White" Width="100%" OnSelectedIndexChanged="GVSolicitudes_SelectedIndexChanged" OnRowCommand="GVSolicitudes_RowCommand" OnPageIndexChanging="GVSolicitudes_PageIndexChanging">
                                        <AlternatingRowStyle BackColor="#F2E7EB" />
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" CommandName="aprobar" ImageUrl="~/img/ojo.png">
                                            <ControlStyle Height="2em" Width="2em" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido" DataFormatString="{0:d}" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="correo" HeaderText="Correo">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="usuario" HeaderText="Usuario">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="contrasena" HeaderText="Password">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cedulaP" HeaderText="Cedula Profesional" DataFormatString="{0:d}" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Pregunta" HeaderText="Pregunta">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="respuesta" HeaderText="Respuesta">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="telCel" HeaderText="Telefono">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="numeroNotaria" HeaderText="No Notaría" DataFormatString="{0:d}" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="statusN" HeaderText="Status" > <%--DataFormatString="{0:d}" HtmlEncode="false"--%>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="intentos" HeaderText="Intentos">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bloqueado" HeaderText="Bloqueado" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Perfil" HeaderText="Tipo User">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Documento" HeaderText="Comprobante">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                             <asp:ButtonField ButtonType="Image" CommandName="viewPdf" ImageUrl="~/img/pdf.png" Text="Botón" HeaderText="Archivo">
                                                <ControlStyle Height="3em" Width="3em" />
                                            </asp:ButtonField>
                                        </Columns>                           
                                        <HeaderStyle Font-Size="Small" BackColor="#590422" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination page-item" Font-Bold="True" Font-Size="Small" />
                                        <RowStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" Wrap="true" />
                                    </asp:GridView>
                                 

                            <asp:GridView ID="GVRegistrados" runat="server" Visible="False" EmptyDataText="No hay registros." DataKeyNames="cedulaP" BorderColor="#CCCCCC" BorderStyle="None"  CssClass="table table-responsive shadow" AutoGenerateColumns="False" AllowPaging="True" Font-Size="X-Small" PagerStyle-BackColor="White" Width="100%" OnRowCancelingEdit="GVRegistrados_RowCancelingEdit" OnRowUpdating="GVRegistrados_RowUpdating" OnRowEditing="GVRegistrados_RowEditing">
                                <AlternatingRowStyle BackColor="#F2E7EB" />
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="correo" HeaderText="Correo">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="usuario" HeaderText="Usuario">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="contrasena" HeaderText="Password">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cedulaP" HeaderText="Cedula Profesional">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="telCel" HeaderText="Telefono">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="idPerfil" HeaderText="Tipo User">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />  
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Documento" HeaderText="Comprobante">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle Font-Size="Small" BackColor="#590422" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination page-item" Font-Bold="True" Font-Size="Small" />
                                <RowStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" Wrap="true" />
                            </asp:GridView>

                             <asp:GridView ID="GVCambioPss" runat="server" Visible="False" EmptyDataText="No hay registros."  BorderColor="#CCCCCC" BorderStyle="None" CaptionAlign="Top" CssClass="table table-responsive shadow" AutoGenerateColumns="False" AllowPaging="True" Font-Size="X-Small" PagerStyle-BackColor="White" Width="100%" OnRowCommand="GVCambioPss_RowCommand"> 
                                    <AlternatingRowStyle BackColor="#F2E7EB" />
                                    <Columns>
                                        <asp:ButtonField ButtonType="Image" CommandName="CambioPsw" ImageUrl="~/img/CambioPsw.png" Text="Botón">
                                        <ControlStyle Height="2em" Width="2em" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido" >
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="correo" HeaderText="Correo">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="contrasena" HeaderText="Password">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cedulaP" HeaderText="Cedula Profesional">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="telCel" HeaderText="Telefono">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Perfil" HeaderText="Tipo User">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>                                   
                                    <HeaderStyle Font-Size="Small" BackColor="#590422" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination page-item" Font-Bold="True" Font-Size="Small" />
                                    <RowStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" Wrap="true" />
                                </asp:GridView>   
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GVSolicitudes"></asp:AsyncPostBackTrigger>
                                <asp:PostBackTrigger ControlID="txtNombre"></asp:PostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="GVCambioPss"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="GVRegistrados"></asp:AsyncPostBackTrigger>
                            </Triggers>
                         </asp:UpdatePanel>
                </div>     
            </div>
        </div>

        <asp:Label ID="lblUserAdm" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
    </div>
       <%--MODAL PARA VISUALIZAR PDF--%>   
    <div class="modal fade " id="ModalViewPFD"data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
          <div class="modal-header text-white" style="background:rgb(86,75,75);">
            <h5 class="modal-title">DOCUMENTO NOTARIAL</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body" style="height:40em;">  
              <div class="container h-100">
                  <embed  type="application/pdf" style="width: 100%; height: 100%;"  id="docPDF"/>
                  <asp:Label ID="blb" runat="server" Text=""></asp:Label>
              </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">SALIR</button>           
          </div> 
        </div>
      </div>
    </div>
     <%--MODAL PARA DENEGAR SOLICITUD DE USUARIO--%>
    <div class="modal fade" id="ModalDenegarSol"data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header text-white" style="background:rgb(86,75,75);">
            <h5 class="modal-title" id="exampleModalLabel">Denegación de Solicitud de Registro</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="row">
                <div class="col-md-6 align-middle">
                    <img src="img/logoGOBSNF.png" class="mx-auto d-block" style="width:70%; height:auto; margin:auto;">
                </div>
                <div class="col-md-6 mx-auto d-block" style="align-content:center;">
                     <label  class="form-label">Motivo de Rechazo</label>
                     <asp:TextBox ID="txtCausaRechazo" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="4" Font-Size="Small" runat="server" Placeholder="Razón..." Style="margin-top:0.5rem;"></asp:TextBox>                           
                </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
            <asp:Button ID="txtEnviarCorreo" runat="server" CssClass="btn text-white" BackColor="#590422" Text="Enviar Correo"  OnClick="txtEnviarCorreo_Click"/>
          </div> 
        </div>
      </div>
    </div>

       <%--MODAL PARA APROBAR SOLICITUD DE USUARIO--%>   
    <div class="modal fade" id="ModalAprobarSol"data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content"> 
          <div class="modal-header text-white" style="background:rgb(86,75,75);">
            <h5 class="modal-title" id="exampleModalLabel1">Aprobar Solicitud de Registro</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="row">
                <div class="col-md-6 align-middle">
                    <img src="img/logoGOBSNF.png" class="mx-auto d-block" style="width:70%; height:auto; margin:auto;">
                </div>
                <div class="col-md-6 mx-auto d-block" style="align-content:center;">
                     <label  class="form-label">¿Està seguro de aprobar a  : <asp:Label ID="lblPersona" Font-Bold="true" runat="server" Text="---"></asp:Label>
                         y enviarle los siguientes datos? <br />
                         Usuario: <asp:Label ID="lblUser" runat="server" Text="---" Font-Bold="true"></asp:Label><br />
                         Contraseña: <asp:Label ID="lblPsw" runat="server" Text="---" Font-Bold="true"></asp:Label> 
                     </label>                    
                </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
            <asp:Button ID="btnSendMail"  runat="server" CssClass="btn text-white" BackColor="#590422" Text="Enviar Correo" OnClick="btnSendMail_Click"/>
          </div>   
        </div>
      </div>
    </div>

    <script type="text/javascript">        
        function OpenModalDen() {
            $('#ModalDenegarSol').modal('show'); // abri r   
        }
        function OpenModalAprob(nombrec, usuario, psw) {
            $('#ModalAprobarSol').modal('show'); // abrir
            $('#<%=lblPersona.ClientID%>').html(nombrec);///sirve para enviar parametrosb 
            $('#<%=lblUser.ClientID%>').html(usuario);///sirve para enviar parametros
            $('#<%=lblPsw.ClientID%>').html(psw);///sirve para enviar parametros
        }

        function Msg(mensaje) {
            var iconS = "";
            if (mensaje === "Correo Enviado" || mensaje === "Se Elimino la Solicitud")
                iconS = 'success'
            else
                iconS = 'error'
            Swal.fire({
                icon: iconS,
                title: mensaje,
                showConfirmButton: true,
                backdrop: `rgba(90,9,9,0.7)
                           left top
                           no-repeat`,
                showClass: {
                    popup: 'animate__animated animate__bounce'
                },
                hideClass: {
                    popup: 'animate__animated animate__fadeOutUp'
                }
            })

        }

    </script>
   

</asp:Content>