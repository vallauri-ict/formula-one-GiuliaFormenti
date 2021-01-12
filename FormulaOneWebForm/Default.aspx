<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br /><br />

            <asp:Label id="lblMessaggio" runat="server" Text=" "></asp:Label> <br /><br />
            <asp:DropDownList id="lbxScelta" runat="server" OnSelectedIndexChanged="lbxScelta_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <br /><br />

            <!--<asp:Button id="btnInvia" runat="server" Text="Invia"></asp:Button> <br /><br />-->
            
            <!--<asp:ListBox id="lbxElenco" runat="server"></asp:ListBox>-->
            <asp:DataGrid ID="dataTable" runat="server"></asp:DataGrid>
        </div>
    </form>
</body>
</html>
