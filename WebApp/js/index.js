$(document).ready(function () {
    $(".input").focusin(function () {
        $(this).find("span").animate({ "opacity": "0" }, 200);
    });

    $(".input").focusout(function () {
        $(this).find("span").animate({ "opacity": "1" }, 300);
    });

    $("#cmbSend").click(function () {
        $.post(
            "WAP0001_USUA",
            { COD_USUA: $("#Usuario").val(), ALF_PASS: $("#Password").val() })
          .done(function (oBe) {
              console.log(oBe);
              if (!oBe.IND_ERRO) {
                  $(location).attr("href", oBe.ALF_URLL);
              }
              else {
                  DevExpress.ui.notify(oBe.ALF_ERRO, "error", 1500);
              }
          });
    });
});
