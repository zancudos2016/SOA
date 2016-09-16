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
</head>
<body>
    <div>
        <table style="width:100%;">
            <tr><td class="Primario tituloWF" colspan="2">DETALLES</td></tr>
            <tr>
                <td>
		            <table class="dGrid" cellspacing="1" cellpadding="0" border="0" id="gvDetalles" style="color:#333333;width:310px;">
			            <tr>
				            <td colspan="2" style="border:2px solid black;background:rgb(255,51,51);text-align:center;color:white;">Detalles - MAR 2013-04-13 - 16:00</td>
			            </tr>
                        <tr>
				            <td colspan="2" style="border:2px solid black;text-align:center;">Atención C-097600021</td>
			            </tr>
                        <tr>
				            <td style="text-align:left;"><a href="Opcion.aspx"><span id="btnOpción" class="button">Continuar</span></a></td>
                            <td style="text-align:right;"><a href="DetenerAtencionMotivo.aspx"><span id="btnDetener" class="button">Detener Atención</span></a></td>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Comercio</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>DIR</td>
                            <td style="color:#ff9999;">DDDD08080</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Comercio</td>
                            <td style="color:#ff9999;">RVC XXXXXX</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Dirección</td>
                            <td style="color:#ff9999;">AV. LOS ALAMOS VERDES</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Referencia</td>
                            <td style="color:#ff9999;">Esquina pared verde</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Contacto</td>
                            <td style="color:#ff9999;">Juan Del Carpio</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Teléfono</td>
                            <td style="color:#ff9999;">999999999</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Distrito</td>
                            <td style="color:#ff9999;">Cerro Dorado</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Prov/Dpto</td>
                            <td style="color:#ff9999;">Arequipa/Arequipa</td>
			            </tr>
                        <tr>
				            <td colspan="2" style="background: #ff9999;color:white;">Otros</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>RUC</td>
                            <td style="color:#ff9999;">20154856952</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Razón Social</td>
                            <td style="color:#ff9999;">RVC xxxxxx</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Dirección <br />Registrada</td>
                            <td style="color:#ff9999;">AV. LOS ALAMOS VERDES</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Otros Datos</td>
                            <td style="color:#ff9999;">
                                054-555555<br />
                                959595959<br />
                                Pepe Cortizona<br />
                                Juan Alamo<br />
                            </td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>e-mail</td>
                            <td style="color:#ff9999;">Hola@yahoo.com</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Problema <br />Reportado</td>
                            <td style="color:#ff9999;">Hola@yahoo.com</td>
			            </tr>
                        <tr style="border-bottom: 1px solid black;">
				            <td>Comentarios</td>
                            <td style="color:#ff9999;">Que se apuren que se va de viaje</td>
			            </tr>
                        <tr>
				            <td colspan="2"></td>
			            </tr>
		            </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
