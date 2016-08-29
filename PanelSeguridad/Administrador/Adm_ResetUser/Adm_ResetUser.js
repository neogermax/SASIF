$(document).ready(function () {

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });

    $("#ImgID").css("display", "none");
    $("#Img2").css("display", "none");


});

//salida del formulario
function btnSalir() {
    window.location = "../../Menu/menu.aspx?User=" + $("#User").html();
}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        transacionAjax_Reset("reset");
    }

}

//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var estado = $("#DDLTipo").val();

    var validar = 0;

    if (estado == "-1" || valID == "") {
        validar = 1;
        if (valID == "") {
            $("#ImgID").css("display", "inline-table");
        }
        else {
            $("#ImgID").css("display", "none");
        }
        if (estado == "-1") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
    }
    else {
        $("#Img2").css("display", "none");
        $("#ImgID").css("display", "none");
    }
    return validar;
}


/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_Reset(State) {
    $.ajax({
        url: "Adm_ResetUserAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": $("#Txt_ID").val(),
            "estado": $("#DDLTipo").val()
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "NO") {
                $("#dialog").dialog("option", "title", "No Existe!");
                $("#Mensaje_alert").text("El usuario no existe en la base de datos!");
                $("#dialog").dialog("open");
                $("#DE").css("display", "block");
                $("#SE").css("display", "none");
            }
            else {
                $("#dialog").dialog("option", "title", "No Existe!");
                $("#Mensaje_alert").text("Se Reseteo la contraseña satifactoriamente!");
                $("#dialog").dialog("open");
                $("#SE").css("display", "block");
                $("#DE").css("display", "none");
            }
        },
        error: function () {

        }
    });
}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}
