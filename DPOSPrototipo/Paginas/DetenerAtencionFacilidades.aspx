<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetenerAtencionFacilidades.aspx.cs" Inherits="DPOSPrototipo.Paginas.DetenerAtencionFacilidades" %>

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

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            today = mm + '/' + dd + '/' + yyyy;
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
				            <td colspan="2" style="border:2px solid black;background:rgb(255,51,51);text-align:center;color:white;">Facilidades - <label id="lblTiempo"></label></td>
			            </tr>
                        <tr>
				            <td colspan="2" style="border:2px solid black;text-align:center;">Atención : <asp:Label ID="lblAtencion" runat="server"></asp:Label></td>
			            </tr>
                        <tr>
                            <td>
                                <asp:CheckBoxList runat="server" ID="chklFacilidades"></asp:CheckBoxList>
                            </td>
                        </tr>
                        <%--<tr style="border-bottom: 1px solid black;">
				            <td>Zona Accesible</td>
                            <td style="color:#ff9999;"></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Dirección Ubicable</td>
                            <td style="color:#ff9999;"></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Local Abierto</td>
                            <td style="color:#ff9999;"></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Contacto Ubicable</td>
                            <td style="color:#ff9999;"></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Contacto Colabora</td>
                            <td style="color:#ff9999;"></td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Equipo Ubicable</td>
                            <td style="color:#ff9999;"></td>
			            </tr>--%>
                        <tr>
				            <%--<td style="text-align:left;"><span id="btnSiguiente" class="button">Confirmar TODO</span></td>--%>
                            <td style="text-align:right;"><a href="Orden.aspx"><span id="btnSiguiente" class="button">Siguiente</span></a></td>
			            </tr>
		            </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
