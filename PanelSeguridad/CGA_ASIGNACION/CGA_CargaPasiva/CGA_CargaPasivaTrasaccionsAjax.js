/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaCentro(State) {
    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayCentro = [];
            }
            else {
                ArrayCentro = JSON.parse(result);
                charge_CatalogList(ArrayCentro, "DDLCentro", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaDepto(State) {
    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayDepto = [];
            }
            else {
                ArrayDepto = JSON.parse(result);
                charge_CatalogList(ArrayDepto, "DDLSolicitud", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaGrpMaq(State, ID_Centro) {
    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID_Centro": ID_Centro
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayGrpMaq = [];
            }
            else {
                ArrayGrpMaq = JSON.parse(result);
                charge_CatalogList(ArrayGrpMaq, "DDLGprMaquina", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga Maquina---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los campos del TVC
function transacionAjax_Maquina(State, ID_Maquina, ID_Centro) {

    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID_Maquina": ID_Maquina,
            "ID_Centro": ID_Centro

        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayMaquina = [];
            }
            else {
                ArrayMaquina = JSON.parse(result);
                charge_CatalogList(ArrayMaquina, "DDLMaquina", 1);
            }
        },
        error: function () {
        }
    });

}


/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaBusqueda(State) {
    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tabla": 'CGA_CargaPasiva'
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayCombo = [];
            }
            else {
                ArrayCombo = JSON.parse(result);
                charge_CatalogList(ArrayCombo, "DDLColumns", 1);
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ consulta ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_CargaPasiva(State, filtro, opcion) {
    var contenido;

    if ($("#TxtRead").val() == "") {
        contenido = "ALL";
    }
    else {
        contenido = $("#TxtRead").val();
    }


    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "filtro": filtro,
            "opcion": opcion,
            "contenido": contenido
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayCargaPasiva = [];
            }
            else {
                ArrayCargaPasiva = JSON.parse(result);
                Table_CargaPasiva();
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ crear ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_CargaPasiva_create(State) {

    var ID;
    var param;

    if (State == "modificar") {
        ID = editID;
    } else {
        ID = 0;
    }

    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": ID,
            "departamento": $("#DDLSolicitud").val(),
            "centro": $("#DDLCentro").val(),
            "g_maq": $("#DDLGprMaquina").val(),
            "maq": $("#DDLMaquina").val(),
            "horasplan": $("#TxtHorasPlan").val(),
            "n_ofertas": $("#TxtNOfertas").val(),
            "orden": $("#TxtOrden").val(),
            "user": User
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se realizo El ingreso del CargaPasiva!");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "block");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "none");
                    break;

                case "Existe":
                    $("#dialog").dialog("option", "title", "Ya Existe");
                    $("#Mensaje_alert").text("El codigo ingresado ya existe en la base de datos!");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "None");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    break;

                case "Exito":
                    if (estado == "modificar") {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("El CargaPasiva fue modificado exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        $("#WE").css("display", "none");
                        Clear();
                    }
                    else {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("El CargaPasiva fue creado exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        $("#WE").css("display", "none");
                        Clear();
                    }
                    break;
            }

        },
        error: function () {

        }
    });
}

/*------------------------------ eliminar ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_CargaPasiva_delete(State) {

    $.ajax({
        url: "CGA_CargaPasivaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": editID,
            "user": User
        },
        //Transaccion Ajax en proceso
        success: function (result) {

            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se elimino el CargaPasiva!");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "block");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "none");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exist_M":
                    $("#dialog").dialog("option", "title", "Integridad referencial");
                    $("#Mensaje_alert").text("No se elimino el CargaPasiva, para eliminarlo debe eliminar primero el registro en la tabla Maquina");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exist_O":
                    $("#dialog").dialog("option", "title", "Integridad referencial");
                    $("#Mensaje_alert").text("No se elimino el CargaPasiva, para eliminarlo debe eliminar primero el registro en la tabla Operario");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exist_All":
                    $("#dialog").dialog("option", "title", "Integridad referencial");
                    $("#Mensaje_alert").text("No se elimino el CargaPasiva, para eliminarlo debe eliminar primero el registro en la tabla Operario y en la tabla Maquina");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exito":
                    $("#dialog_eliminar").dialog("close");
                    $("#dialog").dialog("option", "title", "Exito");
                    $("#Mensaje_alert").text("El CargaPasiva fue eliminado exitosamente! ");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "block");
                    $("#WE").css("display", "none");
                    $("#dialog_eliminar").dialog("close");
                    Clear();
                    break;
            }
        },
        error: function () {

        }
    });

}