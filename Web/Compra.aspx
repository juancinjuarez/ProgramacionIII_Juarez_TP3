<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="Web.Compra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form2" runat="server">
        <header>
            <asp:Label runat="server" Text="CARRITO DE COMPRAS">
            </asp:Label>
        </header>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Nombre de articulo</th>
                    <th scope="col">Descripcion</th>
                    <th scope="col">Precio</th>
                    <th scope="col">Eliminar</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="repeaterCompra">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Nombre") %></td>
                            <td><%#Eval("Descripcion")%></td>
                            <td><%#Eval("Precio")%></td>
                            <td>
                                <asp:Button ID="btnQuitar" CssClass="btn btn-primary" Text="Quitar" CommandName="QuitarArticulo" CommandArgument='<%#Eval("Codigo") %>'
                                    runat="server" OnClick="btnQuitar_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <table class="table">
            <thead>
                <tr>
                    <asp:Label ID="lblPrecio" Text="TOTAL A PAGAR: $" runat="server" />
                </tr>
            </thead>
        </table>
        <asp:Button ID="btnVolver" Text="VOLVER" runat="server" OnClick="btnVolver_Click" />
    </form>
</body>
</html>
