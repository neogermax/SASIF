//evento load del login
$(document).ready(function () {
    teclaEnter();
    $("#tituloPrincipal").html("GESTION Y CONTROL DE ORDENES DE TRABAJO");
    //evento del boton ingresar
    $("#BtnIngresar").click(function () {
        //llamamos la funcion de validar
        var flag_campos = ValidarCampos();
        if (flag_campos === 0) {
            //llamamos la funcion de transaccion
            transacionAjax("Ingresar");
        }
    });
    //evento del boton ingresar

    $("#EPassword").css("display", "none");
    $("#EUser").css("display", "none");

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });


});

//evento de la tecla enter
function teclaEnter() {
    $(document).keydown(function (ev) {

        if (ev.keyCode == 13) {
            var flag_campos = ValidarCampos();
            if (flag_campos === 0) {
                //llamamos la funcion de transaccion
                transacionAjax("Ingresar");
            }
        }
    });

}


//hacemos la transaccion al code behind por medio de Ajax 
function transacionAjax(State) {
    $.ajax({
        url: "LoginAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "user": $("#TxtUser").val(),
            "password": $("#TxtPassword").val()
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            result = JSON.parse(result);

            switch (result) {

                case 0: //ingresa
                    window.location = "../Menu/menu.aspx?User=" + $("#TxtUser").val();
                    break;
                case 1: //contraseña incorrecta
                    $("#EPassword").css("display", "-webkit-inline-box");
                    $("#EUser").css("display", "-webkit-inline-box");
                    $("#EPassword").attr("title", "* Contraseña incorrecta");
                    $("#EUser").attr("title", "Usuario Incorrecto");
                    $("#TxtUser").attr("title", "Revise Contraseña");
                    $("#TxtPassword").attr("title", "Revise Contraseña");
                    break;
                case 2: //no existe usuario
                    $("#EPassword").css("display", "-webkit-inline-box");
                    $("#EUser").css("display", "-webkit-inline-box");
                    $("#EPassword").attr("title", "Contraseña incorrecta");
                    $("#EUser").attr("title", "* Usuario Incorrecto");
                    $("#TxtUser").attr("title", "Revise Usuario");
                    $("#TxtPassword").attr("title", "Revise Usuario");
                    break;
                case 3: // cambio de contraseña
                    window.location = "../login/CambioPassword.aspx?User=" + $("#TxtUser").val();
                    break
                case 4: //usuario deshabilitado
                    $("#dialog").dialog("option", "title", "Desactivado!");
                    $("#Mensaje_alert").text("El usuario esta deshabilitado comuniquese con el administrador del sistema");
                    $("#dialog").dialog("open");
                    break;
            }

        },
        error: function () {
            $("#dialog").dialog("option", "title", "Disculpenos :(");
            $("#Mensaje_alert").text("Se genero error al realizar la transacción Ajax!");
            $("#dialog").dialog("open");

        }
    });

}

//validamos los campos de captura
function ValidarCampos() {
    var user = $("#TxtUser").val();
    var password = $("#TxtPassword").val();
    var flag_valida = 0;

    if (user === "" || password === "") {
        flag_valida = 1;
        if (user === "") {
            $("#EUser").css("display", "-webkit-inline-box");
            $("#EUser").attr("title", "Usuario Requerido");
        }
        else {
            $("#EUser").css("display", "none");
        }
        if (password === "") {
            $("#EPassword").css("display", "-webkit-inline-box");
            $("#EPassword").attr("title", "Contraseña requerida");
        }
        else {
            $("#EPassword").css("display", "none");
        }
    }
    else {
        $("#EUser").css("display", "none");
        $("#EPassword").css("display", "none");
    }
    return flag_valida;
}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}