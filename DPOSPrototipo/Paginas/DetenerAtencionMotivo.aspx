<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetenerAtencionMotivo.aspx.cs" Inherits="DPOSPrototipo.Paginas.DetenerAtencionMotivo" %>

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
        .auto-style4 {
        }
        .auto-style5 {
            height: 18px;
            width: 301px;
        }
        .auto-style6 {
            width: 167px;
        }
        .auto-style7 {
            height: 18px;
            width: 167px;
        }
        .auto-style8 {
            width: 301px;
        }
    </style>
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
				            <td colspan="2" style="border:2px solid black;background:#CC0000; text-align:center;color:white;">MOTIVO - MAR 2013-04-13 - 16:00</td>
			            </tr>
                        <tr>
				            <td colspan="2" style="border:2px solid black;text-align:center;">Atención : <asp:Label ID="lblAtencion" runat="server"></asp:Label></td>
			            </tr>
                        <tr>
				            <td class="auto-style6"></td>
                            <td class="auto-style8">&nbsp;</td>
			            </tr>
                        <tr>
				            <td class="auto-style7">Central Cancela</td>
			            <td class="auto-style5">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/_Images/apply_c.gif" />
                            </td>
                            
                        </tr>
                        <tr>
				            <td class="auto-style7">Motivo del &lt;Técnico/Capacitador&gt;</td>
			           <td class="auto-style8">
                           <asp:Image ID="Image2" runat="server" ImageUrl="~/_Images/apply_c.gif" />
                            </td>
                             </tr>
                        <tr>
				            <td></td>
                            <td></td>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Comentarios</td>
			            </tr>
                        <tr>
				            <td colspan="2">&nbsp;</td>
			            </tr>
                        <tr>
				            <td colspan="2">
                                <asp:TextBox ID="txtComentario" runat="server" Height="79px" Width="401px" style="margin-right: 0px"></asp:TextBox>
                            </td>
			            </tr>
                        <tr>
				            <td class="auto-style4" colspan="2">&nbsp;</td>
			            </tr>
                        <tr>
				            <td class="auto-style6">
                                &nbsp;</td>
                            <td class="auto-style7" style="text-align:left;">
                                <a href="Confirmacion.aspx"><span id="btnOpción" class="button" style="width:100px;">Siguiente</span></a>
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
