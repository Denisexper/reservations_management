<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="PresentatonLayer.cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Clientes</title>
</head>
<body>

    <!-- navbar -->
    <div>
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top">
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
                            <a class="nav-link" href="reservas.aspx">Reservas</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- contenido -->
    </div>
            <br />
            <br />
            <br />
            <h2 class="text-center mb-4">Gestionar Clientes</h2>
        <form id="form1" runat="server">
            <div class="row mb-3">
                <div class="col-12">
                    <asp:GridView ID="dvClientes"
                        AutoGenerateColumns="False"
                        runat="server" DataKeyNames="id_cliente"
                        OnRowCancelingEdit="dvClientes_RowCancelingEdit"
                        OnRowDeleting="dvClientes_RowDeleting"
                        OnRowEditing="dvClientes_RowEditing"
                        OnRowUpdating="dvClientes_RowUpdating"
                        CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="id_cliente" HeaderText="ID" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="dui" HeaderText="DUI" />
                            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="correo" HeaderText="Correo" />
                            <asp:BoundField DataField="departamento" HeaderText="Departamento" />
                            <asp:BoundField DataField="fecha_registro" HeaderText="Fecha Registro" />
                            <asp:BoundField DataField="id_usuario" HeaderText="Usuario" />

                            <asp:CommandField ShowEditButton="True" EditText="Editar" ButtonType="Button" ControlStyle-CssClass="btn btn-primary btn-sm" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-sm" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="container mt-5">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6">
                        <h3 class="text-center mb-4">Agregar Cliente</h3>
                        <form>
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="txtnombre" class="form-label">Nombre</label>
                                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label for="txtdui" class="form-label">DUI</label>
                                    <asp:TextBox ID="txtdui" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="txttelefono" class="form-label">Teléfono</label>
                                    <asp:TextBox ID="txttelefono" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label for="txtcorreo" class="form-label">Correo</label>
                                    <asp:TextBox ID="txtcorreo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="txtdepartamento" class="form-label">Departamento</label>
                                    <asp:TextBox ID="txtdepartamento" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label for="txtFechaRegistro" class="form-label">Fecha Registro</label>
                                    <asp:TextBox ID="txtFechaRegistro" runat="server" TextMode="Date" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <label for="txtusuario" class="form-label">Usuario</label>
                                    <asp:DropDownList ID="dlusuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="d-grid">
                                <asp:Button ID="btnguardar" runat="server" OnClick="Button1_Click" Text="Guardar" CssClass="btn btn-primary btn-block" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>

        </form>
</body>
</html>
