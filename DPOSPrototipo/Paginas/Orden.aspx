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
        .auto-style1 {
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%;">
            <tr><td class="Primario tituloWF" colspan="2">DETALLES</td></tr>
            <tr>
                <td>
		            <table class="dGrid" cellspacing="1" cellpadding="0" border="0" id="gvDetalles" style="color:#333333;width:310px;">
			            <tr>
				            <td colspan="2" style="border:2px solid black;background:rgb(204, 0, 0); text-align:center;color:white;">Orden - MAR 2013-04-13 - 16:00</td>
			            </tr>
                        <tr>
				            <td colspan="2" style="border:2px solid black;text-align:center;">Atención C-097600021</td>
			            </tr>
                        <tr>
				            <td style="text-align:left;" class="auto-style1" colspan="2"></td>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Comentarios</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td colspan="2">
                                <asp:TextBox ID="TextBox1" runat="server" Height="167px" Width="296px" TextMode="MultiLine" >El número de serie del equipo que encontré no corresponde. 
Serie real es 0505050505. 

Me indicaron al llegar que recogiera en otra dirección.

Equipo con rayones.Falta cable de poder.</asp:TextBox>
                            </td>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Estado del Equipo</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Estado</td>
                            <td style="color:#ff9999;">
                                <asp:TextBox ID="TextBox2" runat="server">Ubicable</asp:TextBox>
                            </td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Sub-Estado</td>
                            <td style="color:#ff9999;">
                                <asp:TextBox ID="TextBox3" runat="server" BackColor="#FFFFCC">Operativo Completo</asp:TextBox>
                            </td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td colspan="2" style="background: #ff9999;color:white;">Detalles del Equipo que Sale</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td class="auto-style1">Serie</td>
                            <td style="color:#000000;" class="auto-style1">
                                0505050505<br />
                            </td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Tipo/Marca/Modelo</td>
                            <td style="color:#ff9999;">POS FED</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Conexión</td>
                            <td style="color:#ff9999;">GPRS</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Operación de Chip</td>
                            <td style="color:#ff9999;">Movistar</td>
			            </tr>
                        <tr>
				            <td>Serie de Chip</td>
				            <td style="color: #ff9999;">8951100110020780745</td>
			            </tr>
                        <tr>
				            <td>&nbsp;</td>
				            <td>&nbsp;</td>
			            </tr>
                        <tr>
				      		            <td colspan="2" style="background: #ff9999;color:white;">Detalles del Equipo que Entra</td>
			            </tr>
                        <tr>
				      		            <td>Serie</td>
                            <td style="color: #ff9999;">0909090909</td>
			            </tr>
                        <tr>
				      		            <td>Tipo/Marca/</td>
			           <td style="color: #ff9999;">POS Ingénico FED</td>
                             </tr>
                        <tr>
				      		            <td>Conexión</td>
			          <td style="color: #ff9999;">GPRS</td>
                              </tr>
                        <tr>
				      		            <td>Operador de Chip</td>
                            <td style="color: #ff9999;">Movistar</td>
			            </tr>
                        <tr>
				      		            <td>Serie de Chip</td>
                            <td style="color: #ff9999;">89511001100207804558</td>
			            </tr>
                        <tr>
				      		            <td>&nbsp;</td>
                            <td style="color: #ff9999;">
                                <asp:Button ID="Button1" runat="server" BackColor="#CC0000" ForeColor="White" Text="Siguiente" Width="80px" />
                                        </td>
			            </tr>
		            </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
