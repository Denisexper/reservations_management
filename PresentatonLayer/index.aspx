<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PresentatonLayer.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login Form</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="d-flex justify-content-center align-items-center vh-100">
        <form id="form1" runat="server" class="border p-4 rounded shadow col-md-4 col-lg-3 mx-auto">
            <h3 class="text-center mb-4">Iniciar sesión</h3>
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Usuario</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Ingresa tu usuario"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="TextBox2" class="form-label">Contraseña</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingresa tu contraseña"></asp:TextBox>
            </div>
            <div class="mb-3 text-center">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning w-100" OnClick="Button1_Click" Text="Iniciar sesión" />
            </div>
            <div class="text-center">
                <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </form>
    </div>

</body>
</html>


