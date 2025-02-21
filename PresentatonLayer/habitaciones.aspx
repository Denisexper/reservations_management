<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="habitaciones.aspx.cs" Inherits="PresentatonLayer.huespedes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- link SweetAlert2 -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Habitaciones</title>
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

            <div class="container mt-5">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6">
                        <h2 class="text-center mb-4">Agregar nueva Habitación</h2>

                        <div class="card p-4 shadow">
                            <form>
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label for="txtnumero" class="form-label">Número</label>
                                        <asp:TextBox ID="txtnumero" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="txthuespedes" class="form-label">Huéspedes</label>
                                        <asp:TextBox ID="txthuespedes" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row mb-3">
                                    <div class="col-md-12">
                                        <label for="txtdescripcion" class="form-label">Descripción</label>
                                        <asp:TextBox ID="txtdescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row mb-3">
                                    <div class="col-md-12">
                                        <label for="ddlUsuario" class="form-label">ID Usuario</label>
                                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-select"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="text-center">
                                    <asp:Button ID="BtnGuardar" runat="server" OnClick="Button1_Click" Text="Guardar" CssClass="btn btn-primary w-50" />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
