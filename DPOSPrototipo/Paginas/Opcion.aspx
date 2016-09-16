<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Opcion.aspx.cs" Inherits="DPOSPrototipo.Paginas.Opcion" %>

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
				            <td colspan="2" style="border:2px solid black;background:rgb(255,51,51);text-align:center;color:white;">Opción - 16:32</td>
			            </tr>
                        <tr>
				            <td colspan="2" style="border:2px solid black;text-align:center;">Atención C-097600021</td>
			            </tr>
                        <tr>
				            <td style="text-align:left;">Estar seguro?</td>
                        </tr>
                        <tr>
				            <td style="text-align:left;">Hora de este evento<input type="text" value="14:43" style="width:50px;" /></td>
                        </tr>
                        <tr>
                            <td style="text-align:right;"><a href="DetenerAtencionFacilidades.aspx"><span id="btnSiguiente" class="button">Continuar</span></a></td>
			            </tr>
		            </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
