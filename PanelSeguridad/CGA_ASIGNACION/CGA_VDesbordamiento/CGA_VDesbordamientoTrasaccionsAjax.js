/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaCentro(State) {
    $.ajax({
        url: "CGA_VDesbordamientoAjax.aspx",
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
function transacionAjax_CargaGrpMaq(State, ID_Centro) {
    $.ajax({
        url: "CGA_VDesbordamientoAjax.aspx",
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
        url: "CGA_VDesbordamientoAjax.aspx",
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
                charge_CatalogList(ArrayMaquina, "DDLD1", 1);
                charge_CatalogList(ArrayMaquina, "DDLD2", 1);
                charge_CatalogList(ArrayMaquina, "DDLD3", 1);
                charge_CatalogList(ArrayMaquina, "DDLD4", 1);
                charge_CatalogList(ArrayMaquina, "DDLD5", 1);
                charge_CatalogList(ArrayMaquina, "DDLD6", 1);
                charge_CatalogList(ArrayMaquina, "DDLD7", 1);
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
        url: "CGA_VDesbordamientoAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tabla": 'CGA_VDesbordamiento'
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
function transacionAjax_VDesbordamiento(State, filtro, opcion) {
    var contenido;

    if ($("#TxtRead").val() == "") {
        contenido = "ALL";
    }
    else {
        contenido = $("#TxtRead").val();
    }


    $.ajax({
        url: "CGA_VDesbordamientoAjax.aspx",
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
                ArrayVDesbordamiento = [];
            }
            else {
                ArrayVDesbordamiento = JSON.parse(result);
                Table_VDesbordamiento();
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ crear ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_VDesbordamiento_create(State) {

    var insDDLD4;
    var insDDLD5;
    var insDDLD6;
    var insDDLD7;

    if ($("#DDLD4").val() == "-1")
        insDDLD4 = "";
    else
        insDDLD4 = $("#DDLD4").val();

    if ($("#DDLD5").val() == "-1")
        insDDLD5 = "";
    else
        insDDLD5 = $("#DDLD5").val();

    if ($("#DDLD6").val() == "-1")
        insDDLD6 = "";
    else
        insDDLD6 = $("#DDLD6").val();

    if ($("#DDLD7").val() == "-1")
        insDDLD7 = "";
    else
        insDDLD7 = $("#DDLD7").val();

    $.ajax({
        url: "CGA_VDesbordamientoAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "centro": $("#DDLCentro").val(),
            "g_maq": $("#DDLGprMaquina").val(),
            "maq": $("#DDLMaquina").val(),
            "des_1": $("#DDLD1").val(),
            "des_2": $("#DDLD2").val(),
            "des_3": $("#DDLD3").val(),
            "des_4": insDDLD4,
            "des_5": insDDLD5,
            "des_6": insDDLD6,
            "des_7": insDDLD7,
            "user": User
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se realizo El ingreso del Desbordamiento!");
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
                        $("#Mensaje_alert").text("El Desbordamiento fue modificado exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        $("#WE").css("display", "none");
                        Clear();
                    }
                    else {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("El Desbordamiento fue creado exitosamente! ");
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
function transacionAjax_VDesbordamiento_delete(State) {

    $.ajax({
        url: "CGA_VDesbordamientoAjax.aspx",
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
                    $("#Mensaje_alert").text("No se elimino el Desbordamiento!");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "block");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "none");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exist_M":
                    $("#dialog").dialog("option", "title", "Integridad referencial");
                    $("#Mensaje_alert").text("No se elimino el Desbordamiento, para eliminarlo debe eliminar primero el registro en la tabla Maquina");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exist_O":
                    $("#dialog").dialog("option", "title", "Integridad referencial");
                    $("#Mensaje_alert").text("No se elimino el Desbordamiento, para eliminarlo debe eliminar primero el registro en la tabla Operario");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exist_All":
                    $("#dialog").dialog("option", "title", "Integridad referencial");
                    $("#Mensaje_alert").text("No se elimino el Desbordamiento, para eliminarlo debe eliminar primero el registro en la tabla Operario y en la tabla Maquina");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "none");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "block");
                    $("#dialog_eliminar").dialog("close");
                    break;

                case "Exito":
                    $("#dialog_eliminar").dialog("close");
                    $("#dialog").dialog("option", "title", "Exito");
                    $("#Mensaje_alert").text("El Desbordamiento fue eliminado exitosamente! ");
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