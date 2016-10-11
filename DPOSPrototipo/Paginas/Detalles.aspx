<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="DPOSPrototipo.Paginas.Detalles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../_Css/StyleGeneral.css" rel="stylesheet" type="text/css" />
    <link href="../_Css/StyleGridView.css" rel="stylesheet" type="text/css" />
    <style type='text/css' rel='stylesheet'> 
        .Primario{background: rgb(255,51,51);}
        .BorderBottom{border-bottom:1px solid rgba(, 0.5) !Important;} 
        .BorderRight{border-right:1px solid rgba(, 0.5) !Important;} 
        .mGrid tr:hover{background-color: rgba(51,153,255, 0.7);color: white !Important;} 
        .ui-widget-header{background: rgb(255,51,51) !Important;}
        .PanelModal{border-color: rgb(255,51,51);}
        #lblMenu ul ul a:hover {background-color: rgba(51,153,255, 0.5);}
    </style>
    <script>
        setTimeout(function () {
            var lblTiempo = document.getElementById('lblTiempo');
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();
            var ho = today.getHours();
            var mi = today.getMinutes();

            if (dd < 10) { dd = '0' + dd; }
            if (mm < 10) { mm = '0' + mm; }
            if (ho < 10) { ho = '0' + ho; }
            if (mi < 10) { mi = '0' + mi; }

            today = mm + '/' + dd + '/' + yyyy + ' ' + ho + ':' + mi;
            lblTiempo.innerHTML = today;
        }, 500)
    </script>
</head>
<body>
    <form runat="server">
    <div>
        <table style="width:310px;">
            <%--<tr><td class="Primario tituloWF" colspan="2">DETALLES</td></tr>--%>
            <tr>
                <td>
		            <table class="dGrid" cellspacing="1" cellpadding="0" border="0" id="gvDetalles" style="color:#333333;width:310px;">
			            <tr>
				            <td colspan="2" style="border:2px solid black;background:rgb(255,51,51);text-align:center;color:white;">Detalles - <label id="lblTiempo"></label></td>
			            </tr>
                        <tr>
				            <td colspan="2" style="border:2px solid black;text-align:center;">Atención : <asp:Label ID="lblAtencion" runat="server"></asp:Label></td>
			            </tr>
                        <tr>
				            <td style="text-align:left;"><asp:Button runat="server" ID="btnOpcion" CssClass="button" style="width:100px;" Text="Continuar" OnClick="btnOpcion_Click" /></td>
                            <%--<td style="text-align:right;"><a href="DetenerAtencionMotivo.aspx"><span id="btnDetener" class="button" style="width:100px;">Detener Atención</span></a></td>--%>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Comercio</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Comercio</td>
                            <td style="color:#ff9999;"><asp:Label ID="lblComercio" runat="server"></asp:Label></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Dirección</td>
                            <td style="color:#ff9999;"></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Comentario</td>
                            <td style="color:#ff9999;"><asp:Label ID="lblComentario" runat="server"></asp:Label></td>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Otros</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Fecha Programada</td>
                            <td style="color:#ff9999;"><asp:Label ID="lblFechaProgramada" runat="server"></asp:Label></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Tipo de Atención</td>
                            <td style="color:#ff9999;"><asp:Label ID="lblTipoAtencion" runat="server"></asp:Label></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Estado de Atención</td>
                            <td style="color:#ff9999;"><asp:Label ID="lblEstadoAtencion" runat="server"></asp:Label></td>
			            </tr>
                        <tr>
				            <td colspan="2"></td>
			            </tr>
		            </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
