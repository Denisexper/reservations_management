<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="PresentatonLayer.principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Dashboard Hotel</title>

    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <nav class="navbar navbar-expand-lg navbar-dark bg-info fixed-top">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">Hotel Malibu</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav ms-auto">
                            <li class="nav-item">
                                <a class="nav-link active" href="#">Inicio</a>
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
                <h1 class="text-center">BIENVENIDOS AL DASHBOARD DEL HOTEL MALIBU</h1>
                <h2 class="text-center">Gestiona habitaciones, servicios y más desde aquí.</h2>
            </div>
        </div>
    </form>
</body>
</html>