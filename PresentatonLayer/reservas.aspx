<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="PresentatonLayer.reservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
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
    </form>
</body>
</html>
