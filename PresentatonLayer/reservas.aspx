<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="PresentatonLayer.reservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <title>Reservas</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
        </div>
        <br />
        <br />
        <br />
        <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="id_reserva" HeaderText="ID Reserva" />
                <asp:BoundField DataField="id_cliente" HeaderText="ID Cliente" />
                <asp:BoundField DataField="id_habitacion" HeaderText="ID Habitación" />
                <asp:BoundField DataField="precio" HeaderText="Precio Total" DataFormatString="{0:C}" />
                <asp:BoundField DataField="descuento" HeaderText="Descuento (%)" />
                <asp:BoundField DataField="checkin" HeaderText="Check-In" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="checkout" HeaderText="Check-Out" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="fecha_registro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" />
            </Columns>
        </asp:GridView>

        <div class="container mt-5">
            <h2 class="text-center">Agregar Reserva</h2>

            <div class="mb-3">
                <label for="txtIdReserva" class="form-label">ID Reserva:</label>
                <asp:TextBox ID="txtIdReserva" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ddlCliente" class="form-label">Cliente:</label>
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlHabitacion" class="form-label">Habitación:</label>
                <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="txtCheckIn" class="form-label">Fecha Check-in:</label>
                <asp:TextBox ID="txtCheckIn" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCheckOut" class="form-label">Fecha Check-out:</label>
                <asp:TextBox ID="txtCheckOut" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtDescuento" class="form-label">Descuento (%):</label>
                <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ddlUsuario" class="form-label">Usuario que registra:</label>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="txtFechaRegistro" class="form-label">Fecha de Registro:</label>
                <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" TextMode="DateTime"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnAgregarReserva" runat="server" CssClass="btn btn-primary" Text="Agregar Reserva" OnClick="btnAgregarReserva_Click" />
            </div>
        </div>

    </form>
</body>
</html>
