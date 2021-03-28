<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> FormulaOne </title>

    <style>
        .grid {
            border: solid 1px Tan;
            margin: 0 auto;
            background-color: Tan;
        }

        .grid td {
            border: solid 3px #FFFFFF;
            margin: 3px 3px 3px 3px;
            font-family: Arial;
            padding: 5px 5px 5px 5px;
            text-align: center;
        }

        .GridHeader
        {
            font-weight: bold;
            background-color: Tan;
        }

        .GridHeader a
        {
            text-decoration: none;
            color: LightGoldenrodYellow;
            padding: 0px 15px 0px 15px;
        }

        .GridItem, .GridAltItem
        {
            font-size: smaller;
        }

        .GridItem
        {
            background-color: LightGoldenrodYellow;
        }

        .GridAltItem
        {
            background-color: PaleGoldenrod;
        }

        #lbxScelta {
            border-radius: 10px;
            margin-left: 10px;
            background-color: transparent;
            font-size: 14pt;
        }

        body{
            background: rgb(229,230,227);
            background: linear-gradient(173deg, rgba(229,230,227,1) 0%, rgba(119,130,157,1) 46%, rgba(36,39,89,1) 100%);
            height: 750px;
            font-family: Arial;
        }

        :root {
			--underline-intrinsic-width: 8;
			--underline-width: 12;
			--underline-color: PaleGoldenrod/*#f4ff5d*/;
			--underline-cap-width: 4px;
			--underline-offset-y: -2px;
			--underline-padding-x: 0.12em;
		}

		.heading {
			margin-left: 40%;
            font-size: 22pt;
			display: inline;
			--underline-width-scale: calc(var(--underline-width) / var(--underline-intrinsic-width));
			padding: 0 calc(var(--underline-padding-x) + calc(var(--underline-cap-width) * var(--underline-width-scale)));
			box-decoration-break: clone;
			background-repeat: no-repeat;
			color: black;
			background-image:
				linear-gradient(180deg, var(--underline-color), var(--underline-color));
			background-position-x:
				calc(var(--underline-cap-width) * var(--underline-width-scale)),
				0,
				100%;
			background-position-y: calc(100% - var(--underline-offset-y) * -1);
			background-size:
				calc(100% - calc(var(--underline-cap-width) * var(--underline-width-scale) * 2)) calc(var(--underline-width) * 1px),
				auto calc(var(--underline-width) * 1px),
				auto calc(var(--underline-width) * 1px);
		}

        #lblMessaggio{
            font-size: 16pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <h1 class="heading"> FROMULA UNO </h1>
            <br />

            <asp:Label id="lblMessaggio" runat="server" Text=" "></asp:Label> <br /><br />
            <asp:DropDownList id="lbxScelta" runat="server" OnSelectedIndexChanged="lbxScelta_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <br /><br />
            
            <asp:DataGrid ID="dataTable" runat="server" CssClass="grid" AllowPaging="True" PageSize="18">
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <ItemStyle CssClass="GridItem"></ItemStyle>
                <AlternatingItemStyle CssClass="GridAltItem"></AlternatingItemStyle>
            </asp:DataGrid>
        </div>
    </form>
</body>
</html>