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
    var Heigth = $(window).height() - 200;
    //--------------------------------------------------------------------------
    //OPCIONES DEL MENU PRINCIPAL
    //--------------------------------------------------------------------------
    var menuItems = [
    {
        text: "Bandejas",
        items: [
            { text: "Atenciones", id: 10001, url: "../Atenciones/atenciones.html" }
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
    //--------------------------------------------------------------------------
    //INICIALIZAR CONTROLES PARA LA VENTANA AGREGAR USUARIO
    //--------------------------------------------------------------------------
    function clickSavepopupUser() {
        $.isLoading();
        $.post('../../WAS0003_USUA', {
            COD_USUA:$("#txtCOD_USUA").dxTextBox("instance").option("value"),
            ALF_NOMB:$("#txtALF_NOMB").dxTextBox("instance").option("value"),
            ALF_EMAI:$("#txtALF_EMAI").dxTextBox("instance").option("value"),
            ALF_PASS:$("#txtALF_PASS").dxTextBox("instance").option("value"),
            ALF_TELE: $("#txtALF_TELE").dxTextBox("instance").option("value"),
            NUM_ACCI:Action
        })
        .done(function (data) {
            if (data.IND_ERRO) {
                DevExpress.ui.notify(data.ALF_ERRO, "error", 1500);
            }
            else {
                popupUser.hide();
                DevExpress.ui.notify(data.ALF_ERRO, "success", 1500);
                UsersListInitialize();
            }
            $.isLoading("hide");
        });
    }

    var clickClosepopupUser = function () {
        popupUser.hide();
    }
    var buttonItemspopupUser = [
        { toolbar: 'bottom', location: 'after', widget: 'button', options: { hint: 'Guardar', icon: 'save', width: 25, disabled: false, onClick: clickSavepopupUser } },
        { toolbar: 'bottom', location: 'after', widget: 'button', options: { hint: 'Cerrar', icon: 'close', width: 25, disabled: false, onClick: clickClosepopupUser } },
    ];
    var popupUser_options = {
        title: 'Agregar usuario',
        showTitle: true,
        buttons: buttonItemspopupUser,
        width: 500,
        height: 250
    }
    var popupUser = $("#popupUser").dxPopup(popupUser_options).dxPopup("instance");
    //--------------------------------------------------------------------------
    //DEFINICIÓN DE FUNCIONES PARA LA BARRA DE HERRAMIENTAS
    //--------------------------------------------------------------------------
    var Action = 1;
    function cmdNew() {
        popupUser.show();
        Action = 1;
        $("#txtCOD_USUA").dxTextBox({ width: 100, readOnly: false,value:"" });
        $("#txtALF_NOMB").dxTextBox({ width: 350, value: "" });
        $("#txtALF_EMAI").dxTextBox({ width: 350, value: "" });
        $("#txtALF_PASS").dxTextBox({ width: 150, mode: 'password', value: "" });
        $("#txtALF_TELE").dxTextBox({ width: 150, value: "" });
    }
    function cmdEdit() {
        if (Dato.COD_USUA === undefined) {
            DevExpress.ui.notify("Debe seleccionar un registro.", "error", 1500);
        }
        else {
            popupUser.show();
            Action = 2;
            $("#txtCOD_USUA").dxTextBox({ width: 100, readOnly: true, value:Dato.COD_USUA });
            $("#txtALF_NOMB").dxTextBox({ width: 350, value: Dato.ALF_NOMB });
            $("#txtALF_EMAI").dxTextBox({ width: 350, value: Dato.ALF_EMAI });
            $("#txtALF_PASS").dxTextBox({ width: 150, mode: 'password', value: Dato.ALF_PASS });
            $("#txtALF_TELE").dxTextBox({ width: 150, value: Dato.ALF_TELE });
        }
    }

    function cmdActivate() {
        if (Dato.COD_USUA === undefined) {
            DevExpress.ui.notify("Debe seleccionar un registro.", "error", 1500);
        }
        else {
            $.isLoading();
            $.post('../../WAS0003_USUA', {
                COD_USUA: Dato.COD_USUA,
                NUM_ACCI: 4
            })
            .done(function (data) {
                if (data.IND_ERRO) {
                    DevExpress.ui.notify(data.ALF_ERRO, "error", 1500);
                }
                else {
                    DevExpress.ui.notify(data.ALF_ERRO, "success", 1500);
                    UsersListInitialize();
                }
                $.isLoading("hide");
            });
        }
    }

    function cmdDeactivate() {
        if (Dato.COD_USUA === undefined) {
            DevExpress.ui.notify("Debe seleccionar un registro.", "error", 1500);
        }
        else {
            $.isLoading();
            $.post('../../WAS0003_USUA', {
                COD_USUA: Dato.COD_USUA,
                NUM_ACCI: 3
            })
            .done(function (data) {
                if (data.IND_ERRO) {
                    DevExpress.ui.notify(data.ALF_ERRO, "error", 1500);
                }
                else {
                    DevExpress.ui.notify(data.ALF_ERRO, "success", 1500);
                    UsersListInitialize();
                }
                $.isLoading("hide");
            });
        }
    }

    function cmdRevert() {
        if (Dato.COD_USUA === undefined) {
            DevExpress.ui.notify("Debe seleccionar un registro.", "error", 1500);
        }
        else {
            $.isLoading();
            $.post('../../WAS0003_USUA', {
                COD_USUA: Dato.COD_USUA,
                NUM_ACCI: 5
            })
            .done(function (data) {
                if (data.IND_ERRO) {
                    DevExpress.ui.notify(data.ALF_ERRO, "error", 1500);
                }
                else {
                    DevExpress.ui.notify(data.ALF_ERRO, "success", 1500);
                    UsersListInitialize();
                }
                $.isLoading("hide");
            });
        }
    }
    //--------------------------------------------------------------------------
    //DEFINICIÓN DE LOS BOTONES PARA LA BARRA DE HERRAMIENTAS
    //--------------------------------------------------------------------------
    $("#cmdNew").dxButton({
        hint: 'Nuevo',
        icon: 'cmdNew',
        onClick: cmdNew,
        width: 50
    });
    $("#cmdEdit").dxButton({
        hint: 'Editar',
        icon: 'cmdEdit',
        onClick: cmdEdit,
        width: 50
    });
    $("#cmdActivate").dxButton({
        hint: 'Activar',
        icon: 'cmdActivate',
        onClick:cmdActivate,
        width: 50
    });
    $("#cmdDeactivate").dxButton({
        hint: 'Desactivar',
        icon: 'cmdDeactivate',
        onClick:cmdDeactivate,
        width: 50
    });
    $("#cmdRevert").dxButton({
        hint: 'Revocar alta',
        icon: 'cmdRevert',
        onClick:cmdRevert,
        width: 50
    });
    //--------------------------------------------------------------------------
    //CAPTURA DE INFORMACIÓN DE LA GRILLA
    //--------------------------------------------------------------------------
    var Dato = {};
    function GetRow(e) {
        Dato = e.key;
    }
    //--------------------------------------------------------------------------
    //DEFINICIÓN DE LA GRILLA PRINCIPAL
    //--------------------------------------------------------------------------
    var gdvUsers_options = {
        columns: [{
                        dataField: 'COD_USUA',
                        caption: 'Usuario',
                        width: 100,
                        alignment: 'center',
                        encodeHtml: false
                    }, {
                        dataField: 'ALF_NOMB',
                        caption: 'Nombre',
                        encodeHtml: false
                    }, {
                        dataField: 'ALF_EMAI',
                        caption: 'E-mail',
                        encodeHtml: false
                    }, {
                        dataField: 'IND_ALTA',
                        caption: 'Movil',
                        width: 100,
                        encodeHtml: false
                    }, {
                        dataField: 'IND_ACTI',
                        caption: 'Activo',
                        width: 100,
                        encodeHtml: false
                    }, {
                        dataField: 'ALF_TELE',
                        caption: 'Teléfono',
                        width: 100,
                        alignment: 'center',
                        encodeHtml: false
                    }, {
                        dataField: 'NUM_TOKE',
                        caption: 'Token',
                        width: 100,
                        alignment:'center',
                        encodeHtml: false
                    }
                    ],
                    height: Heigth,
                    showBorders: true,
                    showRowLines: true,
                    onRowClick: GetRow,
                    selection: { mode: 'single' },
                    hoverStateEnabled: true,
                    loadPanel: { enabled: true }
    }
    //--------------------------------------------------------------------------
    //POBLAR LA GRILLA PRINCIPAL
    //--------------------------------------------------------------------------
    UsersListInitialize();
    function UsersListInitialize() {
        $.isLoading();
        $.post(
            "../../WAG0002_USUA",
            { NUM_ACCI:1 })
          .done(function (oBe) {
              if (!oBe.IND_ERRO) {
                  gdvUsers_options.dataSource = oBe.LST_USUA;
                  $("#gdvUsers").dxDataGrid(gdvUsers_options);
              }
              else {
                  DevExpress.ui.notify(oBe.ALF_ERRO, "error", 1500);
              }
              $.isLoading("hide");
          });
    }
});