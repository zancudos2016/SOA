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
            <tr><td class="Primario tituloWF" colspan="2">ATENCIONES - <label id="lblTiempo"></label></td></tr>
            <tr>
                <td>
                    <asp:GridView runat="server" ID="gvAtenciones" CssClass="mGrid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="FEC_ATEN" HeaderText="Hora" DataFormatString=""/>
                            <asp:BoundField DataField="TIPO" HeaderText="Tipo"/>
                            <asp:BoundField DataField="ALF_PTOA" HeaderText="Dir"/>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <label><%# Eval("ESTADO") %></label><a href='Detalles.aspx?COD_ATEN=<%# Eval("COD_ATEN") %>'><img src="../_Images/edit.png" style="width:16px;border-width:0px;" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
    </form>
</body>
</html>
