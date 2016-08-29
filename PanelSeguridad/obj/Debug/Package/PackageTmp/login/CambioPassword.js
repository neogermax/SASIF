//evento load del Cambio de password
$(document).ready(function () {
    //capturamos la url
    var URLPage = window.location.search.substring(1);
    var URLVariables = URLPage.split('&');
    var User = URLVariables[0].replace("User=", "");
    $("#TdUser").html(User.toUpperCase());
    $("#User").html(User.toUpperCase());

    $("#tituloPrincipal").html("GESTION Y CONTROL DE ORDENES DE TRABAJO");
    //evento del boton ingresar
    $("#BtnCambiar").click(function () {
        //llamamos la funcion de validar
        var flag_campos = ValidarCampos();
        if (flag_campos === 0) {
            $('#TxtPassword').keyup(function () {
                $("#E2").css("display", "none");
                $("#E1").css("display", "none");
            });
            //llamamos la funcion de campos
            RevisarContraseña();
        }
    });

    //evento del boton salir
    $("#BtnExit").click(function () {
        window.location = "../login/Login_CGA.aspx"
    });


    $('#show').attr('checked', false);

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });

    $("#E1").css("display", "none");
    $("#S1").css("display", "none");
    $("#E2").css("display", "none");
    $("#S2").css("display", "none");
    $("#DE").css("display", "none");
    $("#DS").css("display", "none");
    $("#BtnExit").css("display", "none");

    /*MostarContraseña();*/
    /*ValidarCamposIguales();*/

});

function RevisarContraseña() {
    var campo_1 = $('#TxtPassword').val();
    var campo_2 = $('#txtConfirmPassword').val();

    if (campo_1 == "") {
        $("#TxtPassword").focus();
        $('#TxtPassword').val("");
        $('#txtConfirmPassword').val("");
        $("#E1").css("display", "-webkit-inline-box");
        $("#E1").attr("title", "Debe diligenciar primero el campo (Digite Contraseña)");
    }
    else {
        $("#E1").css("display", "none");
        //validamos si los campos son iguales
        if (campo_1 == campo_2) {
            //llamamos funcion ajax
            transacionAjax("Cambiar");
        }
        else {
            $("#E1").css("display", "-webkit-inline-box");
            $("#E2").css("display", "-webkit-inline-box");
            $("#E1").attr("title", "Contraseña no coincide");
            $("#E2").attr("title", "Contraseña no coincide");
        }
    }
}

//validamos los campos de captura
function ValidarCampos() {
    var password = $("#TxtPassword").val();
    var passwordConfirm = $("#txtConfirmPassword").val();

    var flag_valida = 0;

    if (passwordConfirm === "" || password === "") {
        flag_valida = 1;
        if (passwordConfirm === "") {
            $("#E2").css("display", "-webkit-inline-box");
            $("#E2").attr("title", "Requiere contraseña");
            $("#txtConfirmPassword").attr("title", "Digite contraseña");
        }
        else {
            $("#E2").css("display", "none");
        }
        if (password === "") {
            $("#E1").css("display", "-webkit-inline-box");
            $("#E1").attr("title", "Requiere contraseña");
            $("#TxtPassword").attr("title", "Digite contraseña");
        }
        else {
            $("#E1").css("display", "none");
        }
    }
    else {
        $("#E2").css("display", "none");
        $("#E1").css("display", "none");
    }
    return flag_valida;
}

//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax(State) {
    $.ajax({
        url: "CambioPasswordAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "user": $("#TdUser").html(),
            "password": $("#TxtPassword").val()
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "Exito") {

                $("#dialog").dialog("option", "title", "Exito");
                $("#Mensaje_alert").text("Su contraseña fue modificada exitosamente! ");
                $("#dialog").dialog("open");
                $("#DS").css("display", "block");
                $("#BtnExit").css("display", "block");


            } else {

                $("#dialog").dialog("option", "title", "Disculpenos :(");
                $("#Mensaje_alert").text("No se realizo el cambio de clave!");
                $("#dialog").dialog("open");
                $("#DE").css("display", "block");
                $("#BtnExit").css("display", "block");

            }

        },
        error: function () {
            $("#dialog").dialog("option", "title", "Disculpenos :(");
            $("#Mensaje_alert").text("Se genero error al realizar la transacción Ajax!");
            $("#dialog").dialog("open");
            $("#DE").css("display", "block");
        }
    });
}

//funcion para ver los campos password
//function MostarContraseña() {
//    $('#show').click(function () {
//        if ($('#show').is(':checked')) {
//            $('#txtConfirmPassword').attr("type", "text");
//            $('#TxtPassword').attr("type", "text");
//        }
//        else {
//            $('#txtConfirmPassword').attr("type", "password");
//            $('#TxtPassword').attr("type", "password");
//        }
//    });
//}

//funcion que valida si los campos de la contraseña son igules soi no bloquea boton cambiar
//function ValidarCamposIguales() {

//    $('#TxtPassword').keyup(function () {
//        $("#TdHelpPassword").html("");
//    });

//    $('#txtConfirmPassword').keyup(function () {
//        var campo_1 = $('#TxtPassword').val();
//        var campo_2 = $('#txtConfirmPassword').val();
//        $("#TdHelpConfirmPassword").html("");
//        //validar si el primer campo esta diligenciado
//        if (campo_1 == "") {
//            $("#TxtPassword").focus();
//            $('#TxtPassword').val("");
//            $('#txtConfirmPassword').val("");
//            $("#dialog").dialog("option", "title", "Advertencia!");
//            $("#Mensaje_alert").html("debe diligenciar primero el campo (Digite Contraseña)");
//            $("#dialog").dialog("open");
//        }
//        else {
//            //validamos si los campos son iguales
//            if (campo_1 == campo_2) {
//                $("#S1").css("display", "-webkit-inline-box");
//                $("#S2").css("display", "-webkit-inline-box");
//                $("#E1").css("display", "none");
//                $("#E2").css("display", "none");
//                $('#TxtPassword').css("border", "solid");
//                $('#txtConfirmPassword').css("border", "solid");
//                $('#TxtPassword').css("border-color", "chartreuse");
//                $('#txtConfirmPassword').css("border-color", "chartreuse");
//                $('#BtnCambiar').removeAttr('disabled');
//            }
//            else {
//                $("#E1").css("display", "-webkit-inline-box");
//                $("#E2").css("display", "-webkit-inline-box");
//                $("#S1").css("display", "none");
//                $("#S2").css("display", "none");
//                $('#TxtPassword').css("border", "solid");
//                $('#txtConfirmPassword').css("border", "solid");
//                $('#TxtPassword').css("border-color", "darkred");
//                $('#txtConfirmPassword').css("border-color", "darkred");
//                $('#BtnCambiar').attr('disabled', 'disabled');
//            }
//        }

//    });

//}

