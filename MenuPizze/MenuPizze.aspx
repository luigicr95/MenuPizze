<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPizze.aspx.cs" Inherits="MenuPizze.MenuPizze" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style>
        #CheckBoxListExtra label{
            margin: 10px;

        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1>Scegli la tua pizza</h1>
                        <asp:DropDownList ID="ElencoPizze" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <hr />

                <div class="row">
                    <div class="text-center">
                        <h4>Extra</h4>
                        <asp:CheckBoxList ID="CheckBoxListExtra" CssClass="form-control" RepeatLayout="Flow" RepeatColumns="5" runat="server">
                            <asp:ListItem Text="Mozz. Bufala (+ 3,00)" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Salame piccante (+ 3,00)" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Funghi (+ 2,00)" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Bacon (+ 2,00)" Value="2"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>

                <div class="row text-center">
                    <asp:Button ID="AggiungiPizza" runat="server" Text="Aggiungi Pizza" OnClick="AggiungiPizza_Click" />
                </div>
                <hr />
                  <div class="row text-center">
                    <asp:Button ID="ConcludiOrdine" runat="server" Text="Concludi Ordine" OnClick="ConcludiOrdine_Click" />
                </div>

                <div id="RiepilogoConto" class="alert alert-info" runat="server">
                    <asp:Label ID="ElencoOrdine" runat="server" Text=""></asp:Label>
                    <hr />
                    <asp:Label ID="TotaleConto" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
