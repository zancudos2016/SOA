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
    var LST_TECN = [];
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
    //GARDAR LA ATENCIÓN
    //--------------------------------------------------------------------------
    function clickSavepopupAtenciones() {
        $.isLoading();
        var uri = "";
        if (Action === 1) {
            uri = "../../WA0002_ATEN";
        }
        else {
            uri = "../../WA0003_ATEN";
        }
        var data = {};
        $.post(uri, {
            COD_ATEN: $("#txtCOD_ATEN").dxTextBox("instance").option("value"),
            ALF_PTOA: $("#txtALF_COME").dxTextBox("instance").option("value"),
            COD_TIPO: $("#cmbCOD_TIPO").dxSelectBox("instance").option("value"),
            FEC_ATEN: $("#deFEC_ATEN").dxDateBox("instance").option("text"),
            FEC_PROG: $("#deFEC_PROG").dxDateBox("instance").option("text"),
            COD_TECN: $("#cmbCOD_TECN").dxSelectBox("instance").option("value"),
            ALF_COME: $("#txtALF_COME_ATEN").dxTextBox("instance").option("value"),
            COD_ESTA: Action === 1 ? 1 : Action - 1,
            NUM_ACCI: Action
        })
        .done(function (data) {
            console.log(data);
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
        height: 350
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
        $("#txtALF_COME").dxTextBox({ width: 350, readOnly: false, value: "" });
        $("#cmbCOD_TIPO").dxSelectBox({ width: 350, readOnly: false, value: 0, dataSource: COD_TIPO_ATEN, displayExpr: "ALF_TIPO", valueExpr: "COD_TIPO" });
        $("#deFEC_ATEN").dxDateBox({ width: 150, readOnly: false, value: new Date() });
        $("#txtALF_COME_ATEN").dxTextBox({ width: 350, readOnly: false, value: "" });
        $("#cmbCOD_TECN").dxSelectBox({ width: 350, readOnly: true, dataSource: LST_TECN, displayExpr: "ALF_EMPL", valueExpr: "COD_TECN", value: 0 });
        $("#deFEC_PROG").dxDateBox({ width: 150, readOnly: true, value: null });
    }
    function cmdEdit() {
        if (Dato.COD_ATEN === undefined) {
            alert("Debe seleccionar un registro.");
        }
        else {
            popupAtenciones.show();
            Action = 2;
            $("#txtCOD_ATEN").dxTextBox({ width: 100, readOnly: true, value: Dato.COD_ATEN });
            $("#txtALF_COME").dxTextBox({ width: 350, readOnly: false, value: Dato.ALF_PTOA });
            $("#cmbCOD_TIPO").dxSelectBox({ width: 350, readOnly: false, dataSource: COD_TIPO_ATEN, displayExpr: "ALF_TIPO", valueExpr: "COD_TIPO", value: Dato.COD_TIPO });
            $("#deFEC_ATEN").dxDateBox({ width: 150, readOnly: false, text: Dato.FEC_ATEN });
            $("#txtALF_COME_ATEN").dxTextBox({ width: 350, readOnly: false, value: Dato.ALF_COME });
            $("#cmbCOD_TECN").dxSelectBox({ width: 350, readOnly: true, dataSource: LST_TECN, displayExpr: "ALF_EMPL", valueExpr: "COD_TECN", value: Dato.COD_TECN });
            $("#deFEC_PROG").dxDateBox({ width: 150, readOnly: true, value: Dato.FEC_PROG === "" ? null : new Date(Dato.FEC_PROG) });
            console.log(Dato.FEC_PROG);
        }
    }
    function cmdProgram() {
        if (Dato.COD_ATEN === undefined) {
            alert("Debe seleccionar un registro.");
        }
        else {
            popupAtenciones.show();
            Action = 3;
            $("#txtCOD_ATEN").dxTextBox({ width: 100, readOnly: true, value: Dato.COD_ATEN });
            $("#txtALF_COME").dxTextBox({ width: 350, readOnly: true, value: Dato.ALF_PTOA });
            $("#cmbCOD_TIPO").dxSelectBox({ width: 350, readOnly: true, dataSource: COD_TIPO_ATEN, displayExpr: "ALF_TIPO", valueExpr: "COD_TIPO", value: Dato.COD_TIPO });
            $("#deFEC_ATEN").dxDateBox({ width: 150, readOnly: true, text: Dato.FEC_ATEN });
            $("#txtALF_COME_ATEN").dxTextBox({ width: 350, readOnly: true, value: Dato.ALF_COME });
            $("#cmbCOD_TECN").dxSelectBox({ width: 350, readOnly: false, dataSource: LST_TECN, displayExpr: "ALF_EMPL", valueExpr: "COD_TECN", value: Dato.COD_TECN });
            $("#deFEC_PROG").dxDateBox({ width: 150, readOnly: false, value: Dato.FEC_PROG === "" ? null : new Date(Dato.FEC_PROG) });
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
    $("#cmdProgram").dxButton({
        hint: 'Programar',
        icon: 'cmdProgram',
        onClick:cmdProgram,
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
            { NUM_ACCI: 1 })
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
    //--------------------------------------------------------------------------
    //POBLAR LA LISTA TÉCNICOS
    //--------------------------------------------------------------------------
    technicianListInitialize();
    function technicianListInitialize() {
        $.post(
            "../../WA0004_ATEN")
          .done(function (oList) {
              LST_TECN = oList;
          });
    }
});