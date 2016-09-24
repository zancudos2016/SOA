<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="DPOSPrototipo.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Sistema POS ::.</title>
    <link rel="icon" href="_Images/POS.png" />
    <link href="_Css/StyleMenuMaster.css" rel="stylesheet" />
    <link href="_Css/StylePageMaster.css" rel="stylesheet" />
    <style type='text/css' rel='stylesheet'>
        .Primario{background: rgb(255,51,51);} 
        .BorderBottom{border-bottom:1px solid rgba(, 0.5) !Important;} 
        .BorderRight{border-right:1px solid rgba(, 0.5) !Important;} 
        .mGrid tr:hover{background-color: rgba(51,153,255, 0.7);color: white !Important;} 
        .ui-widget-header{background: rgb(255,51,51) !Important;}
        .PanelModal{border-color: rgb(255,51,51);}
        #lblMenu ul ul a:hover {background-color: rgba(255,51,51, 0.5);}

        /*DIV{border: 1px solid black;}*/
    </style>
</head>
<body onload="nobackbutton();">
    <div id="container">
        <header id="mainHeader">
            <div style="float:left;"></div>
            <form runat="server">
            <div id="news">
                <asp:Image ID="imgUsuario" runat="server" width="20px" ImageUrl="~/_Images/User.png" />
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario">123</asp:Label>
                <br/>
                <br/>
                <div>
                    <a href="#">Cambio de Clave</a>
                    |
                    <a href="Login.aspx">Cerrar Sesión</a>
                </div>
            </div>
            </form>
        </header>
        <div id="Cuerpo" style="border: 0.5px solid white;">
            <div id="columnaIzquierda" class="BorderRight">
                <div id="lblMenu" runat="server" class="side-menu">
                    <ul>
                        <li><a href='#' class='Primario desplegable js-accordionTrigger'>Atenciones</a>
                            <ul class='subnavegador is-collapsed'>
                                <li><div><a onclick='Menu(this)' target='visor' href='Paginas/Atenciones.aspx' data-id_permiso='1'>Atenciones</a></div></li>
                            </ul>
                        </li>
                        <li><a href='#' class='Primario desplegable js-accordionTrigger'>Reportes</a>
                            <ul class='subnavegador is-collapsed'>
                                <li><div><a onclick='Menu(this)' href='#' data-id_permiso='6'>Indicadores</a></div></li>
                            </ul>
                        </li>
                        <li><a href='#' class='Primario desplegable js-accordionTrigger'>Ayuda</a>
                            <ul class='subnavegador is-collapsed'>
                                <li><div><a onclick='Menu(this)' href='#' data-id_permiso='7'>Manual del Sistema</a></div></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <div id="columnaDerecha">
                <iframe name='visor' style='width:330px;height:100%;border:0px;' src="Paginas/Atenciones.aspx"></iframe>
            </div>
        </div>
        <div id="bottomContent"></div>
        <div id="bottomContentText">            
            Copyrigth. Todos los derechos reservados.
        </div>
    </div>

    <script type="text/javascript">
        //Tuerca y Acordeon
        (function () {
            var d = document,
            accordionToggles = d.querySelectorAll('.js-accordionTrigger'),
            switchAccordion;

            switchAccordion = function (e) {
                e.preventDefault();
                //Tuerca
                var ahref = e.target;
                ahref.classList.toggle('is-expanded');

                //Acordeon
                var li = ahref.parentElement;

                if (li != null && li.childNodes.length > 0) {
                    var ul = li.childNodes[2]; //en este nivel esta el class subnavegador
                    if (ul.classList.contains('subnavegador')) {
                        if (ul != null) {
                            ul.classList.toggle('is-collapsed');
                            ul.classList.toggle('animateIn');
                        }
                    }
                }
            };

            for (var i = 0, len = accordionToggles.length; i < len; i++) {
                accordionToggles[i].addEventListener('click', switchAccordion, false);
            }

            if (getSessionStorage("Menu") != "") {
                for (var i = 0, len = accordionToggles.length; i < len; i++) {
                    if (accordionToggles[i].textContent == getSessionStorage("Menu")) {
                        accordionToggles[i].click();
                    }
                }
            }
        })();

        function Menu(li) {
        }

        function mostrarConsulta(rpta) {
        }

        function setLocalStorage(cname, cvalue) {
            window.localStorage.setItem(cname, cvalue);
        }

        function getLocalStorage(cname) {
            return window.localStorage.getItem(cname);
        }

        function setSessionStorage(cname, cvalue) {
            window.sessionStorage.setItem(cname, cvalue);
        }

        function getSessionStorage(cname) {
            return window.sessionStorage.getItem(cname);
        }

        function nobackbutton() {
            window.location.hash = "no-back-button";
            window.location.hash = "Again-No-back-button" //chrome 
            window.onhashchange = function () { window.location.hash = "no-back-button"; }
        }
    </script>
</body>
</html>
