<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Atenciones.aspx.cs" Inherits="DPOSPrototipo.Paginas.Atenciones" %>

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
        #lblMenu ul ul a:hover {background-color: rgba(255,51,51, 0.5);}
    </style>
</head>
<body>
    <div>
        <table style="width:100%;">
            <tr><td class="Primario tituloWF" colspan="2">ATENCIONES - MAR 2013-04-13</td></tr>
            <tr>
                <td>
		            <table class="mGrid" cellspacing="1" cellpadding="0" border="0" id="gvAtenciones" style="color:#333333;width:310px;">
			            <tr>
				            <th scope="col">Hora</th><th scope="col">Tipo</th><th scope="col">Dir</th><th scope="col">Estado</th>
			            </tr>
                        <tr>
				            <td class="centrado">09:00</td>
                            <td class="centrado">A</td>
                            <td class="centrado">DDD04040</td>
                            <td class="centrado">INFRC <input type="image" src="../_Images/mail.png" style="width:16px;border-width:0px;" /></td>
			            </tr>
                        <tr class="alt">
				            <td class="centrado">11:30</td>
                            <td class="centrado">B</td>
                            <td class="centrado">DDD06060</td>
                            <td class="centrado">EXITO <input type="image" src="../_Images/mail.png" style="width:16px;border-width:0px;" /></td>
			            </tr>
                        <tr>
				            <td class="centrado">16:00</td>
                            <td class="centrado">B</td>
                            <td class="centrado">DDD08080</td>
                            <td class="centrado"> <a href='Detalles.aspx?DIR=DDD08080'><input type="image" src="../_Images/edit.png" style="width:16px;border-width:0px;" /></a></td>
			            </tr>
                        <tr class="alt">
				            <td class="centrado">17:00</td>
                            <td class="centrado">C</td>
                            <td class="centrado">DDD09090</td>
                            <td class="centrado"> <a href='Detalles.aspx?DIR=DDD09090'><input type="image" src="../_Images/edit.png" style="width:16px;border-width:0px;" /></a></td>
			            </tr>
		            </table>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset class="fsConsulta" style="color:#333333;width:300px;">
                        <legend>Buscar</legend>
                        <table>
                            <tr>
                                <td>
                                    <input name="txtUsuario" type="text" id="txtUsuario" class="input" style="width:100px;" placeholder="Ingrese DDD" />
                                </td>
                                <td style="text-align:right;">
                                    <input type="image" src="../_Images/find.png" style="width:16px;border-width:0px;" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="Confirmacion">
                    <span id="lblConfirmacion" class="labelMensajeValidacion"></span>
                </td>
            </tr>
            <tr>
                <td>
		            <table class="mGrid" cellspacing="1" cellpadding="0" border="0" id="gvCASyTecnico" style="color:#333333;width:310px;">
			            <tr>
				            <th scope="col">CAS y Técnico Asignados</th>
			            </tr>
                        <tr>
				            <td>(12) CAS Arequipa</td>
			            </tr>
                        <tr class="alt">
				            <td>(124) Juan Perez</td>
			            </tr>
		            </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
