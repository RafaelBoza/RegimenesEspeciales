<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="RegimenesEspeciales.Aspx.DatosPersonales" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src ="../Content/sweetalert.min.js" type="text/javascript"></script>
    <link href="../Content/bootstrap-theme.css" rel="stylesheet" />
   <script>
        function alertme(titulo,mesaje,Tipo) {
            swal(titulo, mesaje, Tipo);
            unblockUI();
        }
   </script>

    <asp:MultiView runat="server" ID="multiview1">
        <%--Vista Busqueda de Carnet en Ficha Unica--%>
        <asp:View runat="server" ID="view_buscar" OnDeactivate="view_buscar_Deactivate">            
            <br />
            <br />            
            <div id="" class="row">
                <div class="col-xs-3 col-md-3 col-xs-3">
                    <h4>Carnet de Identidad</h4>
                    <asp:TextBox ID="tbx_carnet" AutoCompleteType="Disabled" runat="server" CssClass="form-control filter" ToolTip="Carnet de Identidad" MaxLength="11"></asp:TextBox>
                </div>                
                <div class="col-xs-3 col-md-3 col-lg-3">
                    <div class="col-xs-2 col-md-2 col-lg-2">
                        <h4>Buscar</h4>
                        <asp:Button ID="btn_Buscar" runat="server" Class="btn btn-primary" title="Finalizar" Text="Buscar" OnClick="btn_Buscar_Click"  />
                    </div>
                </div>                   
            </div>                       
        </asp:View>

        <asp:View runat="server" ID="view_datospersonales">           
            <br />
            <br />
             <div class="row" id="Datos personales">
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <h4>Nombre</h4>
                    <asp:TextBox ID="tbx_nombres" AutoCompleteType="Disabled" runat="server" CssClass="form-control" ToolTip="Nombre" ReadOnly="true" BackColor="White"></asp:TextBox>
                </div>
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <h4 >Apellidos</h4>
                    <asp:TextBox ID="tbx_apellidos" AutoCompleteType="Disabled" runat="server" CssClass="form-control" ToolTip="Apellidos" ReadOnly="true" BackColor="White"></asp:TextBox>
                </div>
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <h4 >Dirección</h4>
                    <asp:TextBox ID="tbx_direccion" AutoCompleteType="Disabled" runat="server" CssClass="form-control" ToolTip="Direccion" ReadOnly="true" BackColor="White"></asp:TextBox>
                </div>
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <h4>Provincia</h4>
                    <asp:TextBox ID="tbx_provincia" AutoCompleteType="Disabled" runat="server" CssClass="form-control" ToolTip="Provincia" ReadOnly="true" BackColor="White"></asp:TextBox>
                </div>
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <h4>Municipio</h4>
                    <asp:TextBox ID="tbx_municipio" AutoCompleteType="Disabled" runat="server" CssClass="form-control" ToolTip="Municipio" ReadOnly="true" BackColor="White"></asp:TextBox>
                </div>
            </div>  
            <br />
            <br />
            <asp:GridView ID="gvCambiosBase" runat="server" CssClass="table table-bordered bs-table" margin-left="auto" margin-right="auto" AutoGenerateColumns="False" CellPadding="4" Width="50%"
                ForeColor="#333333" GridLines="None">               
                <Columns>
                    <asp:BoundField DataField="Descripbase" HeaderText="Base de Contribucion" ReadOnly="True"/>
                    <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" ReadOnly="True"/>
                    <asp:BoundField DataField="Año" HeaderText="Año" ReadOnly="True"/>    
                    <asp:BoundField DataField="FechaCambio" HeaderText="Fecha de Cambio" ReadOnly="True"/>                                   
                </Columns>               
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />              
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />               
            </asp:GridView>

            <br />
            <br />
            <div class="row" id="botones">
                <div class="col-xs-4 col-md-4 col-lg-4">                  
                      <asp:Button ID="btn_registrar" runat="server" Class="btn btn-primary" title="Registrar" Text="Registrar" OnClick="btn_registrar_Click" />
                 </div>
                <div class="col-xs-4 col-md-4 col-lg-4">                     
                      <asp:Button ID="btn_cambiarbase" runat="server" Class="btn btn-primary" title="Cambiar Base de Contribucion" Text="Cambiar Base de Contribucion" OnClick="btn_cambiarbase_Click" />
                 </div>
                <div class="col-xs-4 col-md-4 col-lg-4">                    
                     <asp:Button ID="btn_ancelar" runat="server" Class="btn btn-primary" title="Cancelar" Text="Cancelar" OnClick="btn_ancelar_Click" />
                 </div>
            </div>            
        </asp:View>

        <asp:View runat="server" ID="view_registro">          
            <br />
            <br />            
                <div class="row" id="Datos registro">
                    <div class="col-xs-3 col-md-3 col-lg-3">
                        <h4>Regimen:</h4>
                        <span class="dropdown-header">
                            <asp:DropDownList ID="drop_regimen" class="selectpicker show-tick form-control" data-live-search="true" data-style="btn-primary" runat="server">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="col-xs-3 col-md-3 col-lg-3">
                        <h4>Fecha de Registro:</h4>
                        <div class="col-lg-12 col-sm-12 col-xs-12">
                            <asp:TextBox type="date" name="fecha" ID="tbx_fecharegistro" AutoComplete="off" AutoCompleteType="Disabled" min="1980-01-01" max="2050-12-31" step="1" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col-xs-3 col-md-3 col-lg-3">
                        <h4>Fecha de Desvinculación:</h4>
                        <div class="col-lg-12 col-sm-12 col-xs-12">
                            <asp:TextBox type="date" name="fecha" ID="tbx_fechadesvinculacion" AutoComplete="off" AutoCompleteType="Disabled" min="1980-01-01" max="2050-12-31" step="1" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col-xs-3 col-md-3 col-lg-3">
                        <h4>Base de Contribución:</h4>
                        <span class="dropdown-header">
                            <asp:DropDownList ID="drop_basecontribucion" class="selectpicker show-tick form-control" data-live-search="true" data-style="btn-primary" runat="server">
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-xs-4 col-md-4 col-lg-4">
                        <asp:Button ID="btn_guardarregistro" runat="server" Class="btn btn-primary" title="Guardar" Text="Guardar" OnClick="btn_guardarregistro_Click" />
                    </div>
                    <div class="col-xs-4 col-md-4 col-lg-4">
                        <asp:Button ID="btn_cancelar_registro" runat="server" Class="btn btn-primary" title="Cancelar" Text="Cancelar" OnClick="btn_cancelar_registro_Click" />
                    </div>
                </div>              
        </asp:View>

        <asp:View ID="view_cambio" runat="server">
            <br />
            <br />
            <div class="row">
                <div class="col-xs-3 col-md-3 col-xs-3">
                    <h4>Base de Contribucion Actual</h4>
                    <asp:TextBox ID="tbx_base" AutoCompleteType="Disabled" runat="server" CssClass="form-control filter" ToolTip="Carnet de Identidad" ReadOnly="true" BackColor="White"></asp:TextBox>
                </div>
                <div class="col-xs-3 col-md-3 col-lg-3">
                    <h4>Nueva Base de Contribución:</h4>
                    <span class="dropdown-header">
                        <asp:DropDownList ID="drop_nuevabase" class="selectpicker show-tick form-control" data-live-search="true" data-style="btn-primary" runat="server">
                        </asp:DropDownList>
                    </span>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <asp:Button ID="btn_guardarbase" runat="server" Class="btn btn-primary" title="Guardar" Text="Guardar" OnClick="btn_guardarbase_Click" />
                </div>
                <div class="col-xs-4 col-md-4 col-lg-4">
                    <asp:Button ID="btn_cancelarcambio" runat="server" Class="btn btn-primary" title="Cancelar" Text="Cancelar" OnClick="btn_cancelarcambio_Click" />
                </div>
            </div>       

        </asp:View>
    </asp:MultiView>
            
       
        
                 
              
     
        
   
    
    
</asp:Content>
