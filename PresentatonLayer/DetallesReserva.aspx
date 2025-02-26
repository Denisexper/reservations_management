<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesReserva.aspx.cs" Inherits="PresentatonLayer.DetallesReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center">Detalles de la Reserva</h2>
            
            <!-- Mostrar mensaje de error si es necesario -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
            
            <div class="card mt-4">
                <div class="card-header">
                    Información de la Reserva
                </div>
                <div class="card-body">
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="lblIDReserva"><strong>ID Reserva:</strong></label>
                            <asp:Label ID="lblIDReserva" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <label for="lblIDCliente"><strong>ID Cliente:</strong></label>
                            <asp:Label ID="lblIDCliente" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="lblIDHabitacion"><strong>ID Habitación:</strong></label>
                            <asp:Label ID="lblIDHabitacion" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <label for="lblPrecioTotal"><strong>Precio Total:</strong></label>
                            <asp:Label ID="lblPrecioTotal" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="lblCheckIn"><strong>Check-In:</strong></label>
                            <asp:Label ID="lblCheckIn" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <label for="lblCheckOut"><strong>Check-Out:</strong></label>
                            <asp:Label ID="lblCheckOut" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="lblFechaRegistro"><strong>Fecha Registro:</strong></label>
                            <asp:Label ID="lblFechaRegistro" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <label for="lblIDUsuario"><strong>ID Usuario:</strong></label>
                            <asp:Label ID="lblIDUsuario" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </form>
</body>
</html>
