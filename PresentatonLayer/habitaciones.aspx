<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="habitaciones.aspx.cs" Inherits="PresentatonLayer.huespedes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- link SweetAlert2 -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Habitaciones</title>
</head>
<body>
        <!-- navbar -->
        <div>
        <nav class="navbar navbar-expand-lg navbar-dark bg-info fixed-top">
            <div class="container-fluid">
                <a class="navbar-brand" href="principal.aspx">Hotel Costa Surf</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav ms-auto">
                        <li class="nav-item">
                            <a class="nav-link active" href="principal.aspx">Inicio</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="habitaciones.aspx">Habitaciones</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="cliente.aspx">Clientes</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Contacto</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

    
        <div class="container mt-5 pt-5">
            <h1 class="text-center">BIENVENIDOS AL DASHBOARD DEL HOTEL COASTA SURF</h1>
            <h2 class="text-center">Gestiona habitaciones, servicios y más desde aquí.</h2>
        </div>
    </div>
    <!-- contenido de la pagina-->
    <form id="form1" runat="server">
        <div class="container mt-4">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="id_habitaciones"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowDeleting="GridView1_RowDeleting" 
                OnRowEditing="GridView1_RowEditing" 
                OnRowUpdating="GridView1_RowUpdating" 
                CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="id_habitaciones" HeaderText="ID" />
                    <asp:BoundField DataField="numero" HeaderText="Numero" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="huespedes" HeaderText="Huespedes" />
                    <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" />

                    <asp:CommandField ShowEditButton="True" EditText="Editar" ButtonType="Button" ControlStyle-CssClass="btn btn-primary btn-sm" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-sm" />
                </Columns>
            </asp:GridView>

            <h2>Agregar nueva Habitacion</h2>

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Numero" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtnumero" runat="server" CssClass="form-control" Width="157px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Descripcion" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtdescripcion" runat="server" CssClass="form-control" Width="157px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Huespedes" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txthuespedes" runat="server" CssClass="form-control" Width="157px"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="ID Usuario" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList>
                <br />
            </div>

            <div class="form-group">
                <asp:Button ID="BtnGuardar" runat="server" OnClick="Button1_Click" Text="Guardar" CssClass="btn btn-warning" />
            </div>
        </div>
    </form>
</body>
</html>