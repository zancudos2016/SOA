$(document).ready(function () {
    $.post(
        "../../WAP0002_USUA")
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
    //TIPOS DE ATENCIÓN
    //--------------------------------------------------------------------------
    var COD_TIPO_ATEN = [{ COD_TIPO: 1, ALF_TIPO: "Instalación" }, { COD_TIPO: 2, ALF_TIPO: "Desinstalación" }, { COD_TIPO: 3, ALF_TIPO: "Incidencia" }]
    //--------------------------------------------------------------------------
    //INICIALIZAR CONTROLES PARA LA VENTANA AGREGAR USUARIO
    //--------------------------------------------------------------------------
    function clickSavepopupAtenciones() {
        $.isLoading();
        $.post('../../WA0002_ATEN', {
            COD_ATEN:$("#txtCOD_ATEN").dxTextBox("instance").option("value"),
            ALF_PTOA:$("#txtALF_COME").dxTextBox("instance").option("value"),
            COD_TIPO: $("#cmbCOD_TIPO").dxSelectBox("instance").option("value"),
            FEC_ATEN:$("#deFEC_ATEN").dxDateBox("instance").option("text"),
            ALF_COME: $("#meALF_COME").dxTextArea("instance").option("value"),
            COD_ESTA: 1,
            NUM_ACCI:Action
        })
        .done(function (data) {
            if (data.IND_ERRO) {
                alert(data.ALF_ERRO);
            }
            else {
                alert("Operación exitosa!!!.")
                popupAtenciones.hide();
                UsersListInitialize();
            }
            $.isLoading("hide");
        });
    }

    var clickClosepopupAtenciones = function () {
        popupAtenciones.hide();
    }
    var buttonItemspopupAtenciones = [
        { toolbar: 'bottom', location: 'after', widget: 'button', options: { hint: 'Guardar', icon: 'save', width: 25, disabled: false, onClick: clickSavepopupAtenciones } },
        { toolbar: 'bottom', location: 'after', widget: 'button', options: { hint: 'Cerrar', icon: 'close', width: 25, disabled: false, onClick: clickClosepopupAtenciones } },
    ];
    var popupAtenciones_options = {
        title: 'Agregar usuario',
        showTitle: true,
        buttons: buttonItemspopupAtenciones,
        width: 600,
        height: 250
    }
    var popupAtenciones = $("#popupAtenciones").dxPopup(popupAtenciones_options).dxPopup("instance");
    //--------------------------------------------------------------------------
    //DEFINICIÓN DE FUNCIONES PARA LA BARRA DE HERRAMIENTAS
    //--------------------------------------------------------------------------
    var Action = 1;
    function cmdNew() {
        popupAtenciones.show();
        Action = 1;
        $("#txtCOD_ATEN").dxTextBox({ width: 100, readOnly: false,value:"" });
        $("#txtALF_COME").dxTextBox({ width: 350, value: "" });
        $("#cmbCOD_TIPO").dxSelectBox({ width: 350, value: 0, dataSource: COD_TIPO_ATEN,displayExpr:"ALF_TIPO", valueExpr:"COD_TIPO"  });
        $("#deFEC_ATEN").dxDateBox({ width: 150, value: new Date() });
        $("#meALF_COME").dxTextArea({ width: 250, height: 40, value: "" });
    }
    function cmdEdit() {
        if (Dato.COD_ATEN === undefined) {
            alert("Debe seleccionar un registro.");
        }
        else {
            popupAtenciones.show();
            console.log(Dato);
            Action = 2;
            $("#txtCOD_ATEN").dxTextBox({ width: 100, readOnly: true, value:Dato.COD_ATEN });
            $("#txtALF_COME").dxTextBox({ width: 350, value: Dato.ALF_PTOA });
            $("#cmbCOD_TIPO").dxSelectBox({ width: 350,dataSource: COD_TIPO_ATEN, displayExpr: "ALF_TIPO", valueExpr: "COD_TIPO", value: Dato.COD_TIPO });
            $("#deFEC_ATEN").dxDateBox({ width: 150, text: Dato.FEC_ATEN });
            $("#meALF_COME").dxTextArea({ width: 250, height: 40, value: Dato.ALF_COME });
        }
    }

    function cmdActivate() {
        if (Dato.COD_ATEN === undefined) {
            alert("Debe seleccionar un registro.");
        }
        else {
            $.isLoading();
            $.post('../../WAS0003_USUA', {
                COD_ATEN: Dato.COD_ATEN,
                NUM_ACCI: 4
            })
            .done(function (data) {
                if (data.IND_ERRO) {
                    alert(data.ALF_ERRO);
                }
                else {
                    alert(data.ALF_ERRO);
                    UsersListInitialize();
                }
                $.isLoading("hide");
            });
        }
    }

    function cmdDeactivate() {
        if (Dato.COD_ATEN === undefined) {
            alert("Debe seleccionar un registro.");
        }
        else {
            $.isLoading();
            $.post('../../WAS0003_USUA', {
                COD_ATEN: Dato.COD_ATEN,
                NUM_ACCI: 3
            })
            .done(function (data) {
                if (data.IND_ERRO) {
                    alert(data.ALF_ERRO);
                }
                else {
                    alert(data.ALF_ERRO);
                    UsersListInitialize();
                }
                $.isLoading("hide");
            });
        }
    }

    function cmdRevert() {
        if (Dato.COD_ATEN === undefined) {
            alert("Debe seleccionar un registro.");
        }
        else {
            $.isLoading();
            $.post('../../WAS0003_USUA', {
                COD_ATEN: Dato.COD_ATEN,
                NUM_ACCI: 5
            })
            .done(function (data) {
                if (data.IND_ERRO) {
                    alert(data.ALF_ERRO);
                }
                else {
                    alert(data.ALF_ERRO);
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
    $("#cmdDeactivate").dxButton({
        hint: 'Programar',
        icon: 'cmdDeactivate',
        onClick:cmdDeactivate,
        width: 50
    });
    $("#cmdActivate").dxButton({
        hint: 'Confirmar',
        icon: 'cmdActivate',
        onClick: cmdActivate,
        width: 50
    });
    $("#cmdRevert").dxButton({
        hint: 'Cancelar',
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
    var gdvAtenciones_options = {
        columns: [{
                        dataField: 'COD_ATEN',
                        caption: 'Atención',
                        width: 100,
                        alignment: 'center',
                        encodeHtml: false
                    }, {
                        dataField: 'ALF_PTOA',
                        caption: 'Comercio',
                        encodeHtml: false
                    }, {
                        dataField: 'FEC_ATEN',
                        caption: 'Atención',
                        encodeHtml: false
                    }, {
                        dataField: 'FEC_PROG',
                        caption: 'Programada',
                        width: 100,
                        encodeHtml: false
                    }, {
                        dataField: 'ALF_COME',
                        caption: 'Comentario',
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
            "../../WA0001_ATEN",
            { NUM_ACCI:1 })
          .done(function (oBe) {
              console.log(oBe);
              if (!oBe.IND_ERRO) {
                  gdvAtenciones_options.dataSource = oBe.LST_ATEN;
                  $("#gdvAtenciones").dxDataGrid(gdvAtenciones_options);
              }
              else {
                  alert(oBe.ALF_ERRO);
              }
              $.isLoading("hide");
          });
    }
});