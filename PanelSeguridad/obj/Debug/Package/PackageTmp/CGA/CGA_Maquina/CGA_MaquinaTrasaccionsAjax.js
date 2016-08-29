/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaBusqueda(State) {
    $.ajax({
        url: "CGA_MaquinaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tabla": 'CGA_MAQUINA'
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

/*-------------------- carga el DDL Centro---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaCentro(State) {
    $.ajax({
        url: "CGA_MaquinaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State

        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayComboCentro = [];
            }
            else {
                ArrayComboCentro = JSON.parse(result);
                charge_CatalogList(ArrayComboCentro, "DDLCentro", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga el DDL Grupo de maquinas---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaGrpMaquinas(State) {
    $.ajax({
        url: "CGA_MaquinaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State

        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayComboGrpMaquina = [];
            }
            else {
                ArrayComboGrpMaquina = JSON.parse(result);
                charge_CatalogList(ArrayComboGrpMaquina, "DDLGrpMaquina", 1);
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ consulta ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_Maquina(State, filtro, opcion) {
    var contenido;

    if ($("#TxtRead").val() == "") {
        contenido = "ALL";
    }
    else {
        contenido = $("#TxtRead").val();
    }

    $.ajax({
        url: "CGA_MaquinaAjax.aspx",
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
                ArrayMaquina = [];
            }
            else {
                ArrayMaquina = JSON.parse(result);
                Table_Maquina();
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ crear ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_Maquina_create(State) {

    var ID;
    var param;

    if (State == "modificar") {
        ID = editID;
    } else {
        ID = $("#Txt_ID").val();
    }

    $.ajax({
        url: "CGA_MaquinaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": ID,
            "descripcion": $("#TxtDescription").val(),
            "centro": $("#DDLCentro").val(),
            "grpMaquina": $("#DDLGrpMaquina").val(),
            "ceco": $("#TxtCECO").val(),
            "user": User
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se realizo El ingreso de la maquina!");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "block");
                    $("#SE").css("display", "none");
                    break;

                case "Existe":
                    $("#dialog").dialog("option", "title", "Ya Existe");
                    $("#Mensaje_alert").text("El codigo ingresado ya existe en la base de datos!");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "block");
                    $("#SE").css("display", "none");
                    break;

                case "Exito":
                    if (estado == "modificar") {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("La maquina fue modificada exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        Clear();
                    }
                    else {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("La maquina fue creada exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
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
function transacionAjax_Maquina_delete(State) {

    $.ajax({
        url: "CGA_MaquinaAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": editID,
            "user": User
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "Error") {
                $("#dialog").dialog("option", "title", "Disculpenos :(");
                $("#Mensaje_alert").text("No elimino la maquina!");
                $("#dialog").dialog("open");
                $("#DE").css("display", "block");
            }
            else {
                $("#dialog_eliminar").dialog("close");
                $("#dialog").dialog("option", "title", "Exito");
                $("#Mensaje_alert").text("la maquina fue eliminada exitosamente! ");
                $("#dialog").dialog("open");
                $("#DS").css("display", "block");
                Clear();
            }
        },
        error: function () {

        }
    });

}