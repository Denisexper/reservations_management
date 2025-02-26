<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="codigoReserva.aspx.cs" Inherits="PresentatonLayer.statusReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header bg-primary text-white">
                            <h4 class="card-title">Buscar Reserva</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtCodigoReserva">Código de Reserva</label>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtCodigoReserva" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese el código de reserva"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </div>
                            <br /> 
                            <div class="form-group text-center">
                                <asp:Button ID="btnBuscarReserva" runat="server" Text="Buscar Reserva" OnClick="btnBuscarReserva_Click" CssClass="btn btn-primary btn-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
