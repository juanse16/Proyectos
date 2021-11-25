<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formulario.aspx.cs" Inherits="Web.formulario"   %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
    <title>Prueba</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:DropDownList ID="dlistap" runat="server"  AutoPostBack="true"  CssClass="form-control "></asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="NOMBRE"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="APELLIDOS"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-inline">
                <div class="mb-3 mx-sm-3">
                    <asp:Button ID="Button1" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="Button1_Click" /></div>
                <div class="mb-3 mx-sm-3">
                    <asp:Button ID="Button2" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="Button2_Click" /></div>
                <div class="mb-3 mx-sm-3">
                    <asp:Button ID="Button3" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="Button3_Click" /></div>
                <div class="mb-3 mx-sm-3">
                    <asp:Button ID="Button4" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="Button4_Click" /></div>
                </div>
            <div class="mb-3 mx-sm-3">
                    <asp:Button ID="Button5" runat="server" Text="Ver clientes" CssClass="btn btn-dark" OnClick="Button5_Click" /></div>
            </div>
        <div class="container" runat="server">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <asp:GridView ID="datos" runat="server" CssClass="table" AutoGenerateColumns="false" EmptyDataText="No se encontraron registros" howFooter="true" DataKeyNames="id"
                 OnRowCommand="datos_RowCommand" OnRowEditing="datos_RowEditing" 
                 OnRowCancelingEdit="datos_RowCancelingEdit" OnRowDeleting="datos_RowDeleting" OnRowUpdating="datos_RowUpdating" >
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                         <ItemTemplate>
                             <asp:Label  runat="server" Text='<%# Eval("id") %>'></asp:Label>
                         </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtID"  Text='<%# Eval("id") %>' runat="server" CssClass="form-control"></asp:TextBox>
                         </EditItemTemplate>
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                         <ItemTemplate>
                             <asp:Label  runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                         </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtNombre"  Text='<%# Eval("nombre") %>' runat="server" CssClass="form-control"></asp:TextBox>
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                         <ItemTemplate>
                             <asp:Label  runat="server" Text='<%# Eval("apellidos") %>'></asp:Label>
                         </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtApellido"  Text='<%# Eval("apellidos") %>' runat="server" CssClass="form-control"></asp:TextBox>
                         </EditItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Button ID="btnEditar" Text="Editar"  runat="server" CommandName="Edit" ToolTip="Edit" CssClass="btn btn-primary" />
                             <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CommandName="Delete" ToolTip="Delete" CssClass="btn btn-danger" />
                         </ItemTemplate>
                         <EditItemTemplate>
                             <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CommandName="Update" ToolTip="Update" CssClass="btn btn-success" />
                             <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" CommandName="Cancel" ToolTip="Cancel" CssClass="btn btn-secondary" />   
                         </EditItemTemplate>
                         <FooterTemplate>

                         </FooterTemplate>
                     </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    
</body>
</html>
