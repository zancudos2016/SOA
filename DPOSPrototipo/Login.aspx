﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DPOSPrototipo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Sistema POS ::.</title>
    <link rel="icon" href="_Images/POS.png" />
    <link rel="stylesheet" type="text/css" href="_Css/StyleLogin.css"/>
    <style type="text/css">
         #idheader {
            padding: 50px 50px 50px 50px;
        }
    </style>
    <script>
        window.localStorage.clear();
        window.sessionStorage.clear();
    </script>
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

        function ValidarIngreso() {
            var username = document.getElementById('username');
            var password = document.getElementById('password');
            var lblMensaje = document.getElementById('<%= lblMensaje.ClientID %>');

            if (username.value == "" || password.value == "") {
                lblMensaje.innerHTML = "Ingrese los datos correctamente.";

                setTimeout(function () {
                    var lblMensaje = document.getElementById('lblMensaje');
                    lblMensaje.innerHTML = "";
                }, 1500);

                return false;
            } else {
                return true;
            }
        }
    </script>
</head>
<body>
    <div id="background"></div>
    <div class="container_principal">
        <div id="idheader"></div>
        <section>				
            <div id="container_secundario">
                <a class="hiddenanchor" id="toregister"></a>
                <a class="hiddenanchor" id="tologin"></a>
                <div id="wrapper">
                    <form runat="server">
                    <div id="login" class="animate form">                          
                        <div id="mainFigure">
                            <asp:Image ID="imgPOS" runat="server" Width="90" ImageUrl="~/_Images/POS.png" /><br />
                        </div>
                        <div id="bodyLogin">
                            <p>
                                <label for="username">Usuario :</label>
                                <input id="username" name="username" required="required" type="text" placeholder="Usuario"/>
                            </p>
                            <p> 
                                <label for="password">Clave :</label>
                                <input id="password" name="password" required="required" type="password" placeholder="Clave" autocomplete="off"/> 
                            </p>
                            <div style="text-align:center;font-size:12px;font-weight:bold;color:red;">
                                &nbsp;<asp:Label ID="lblMensaje" runat="server"></asp:Label>
                            </div>
                            <p class="login button">
                                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClientClick="return ValidarIngreso();" OnClick="btnIngresar_Click" />
						    </p>
                        </div>
                    </div>
                    <div>
                        <table style="width:100%;text-align:center;">
                            <tr>
                                <td><label id="lblTiempo"></label></td>
                            </tr>
                        </table>
                    </div>
                    </form>
                </div>
            </div>
        </section>

        <div id="bottomContent"></div>
        <div id="bottomContentText">
            Copyrigth. Todos los derechos reservados.
        </div>
    </div>
</body>
</html>
