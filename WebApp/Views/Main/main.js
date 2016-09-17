$(document).ready(function () {
    $.post(
        "../../WASECURITYG0002_SESI",
        { NUM_ACCI: 1 })
      .done(function (oBe) {
          if (!oBe.IND_ERRO) {
              $("#mainContent").css("visibility", "visible");
          }
          else {
              $(location).attr('href', "../../index.html");
          }
      }).fail(function () {
          $(location).attr('href', "../../index.html");
      });
    //--------------------------------------------------------------------------
    //DEFINICIÓN DE CONFIGURACIONES PARA PERÚ
    //--------------------------------------------------------------------------
    Globalize.culture('es-PE');
    //--------------------------------------------------------------------------
    //OPCIONES DEL MENU PRINCIPAL
    //--------------------------------------------------------------------------
    var menuItems = [
    {
        text: "Administración",
        items: [
            { text: "Usuarios", id: 10001, url: "../Users/users.html" },
        ]
    },
    {
        text: "Listados",
        items: [
            { text: "Incidencias", id: 20001, url: "../Report/list.html" }
        ]
    }
    ];
    //--------------------------------------------------------------------------
    //DEFINICIÓN DEL MENÚ PRINCIPAL
    //--------------------------------------------------------------------------
    $("#menu").dxMenu({
        items: menuItems,
        onItemClick: function (data) {
            if (data.itemData.id === 10001 || data.itemData.id === 20001) {
                $(location).attr('href', data.itemData.url);
            }
        },
        height:25
    });
});