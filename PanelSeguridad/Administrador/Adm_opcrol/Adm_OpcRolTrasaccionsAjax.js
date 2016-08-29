/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaBusqueda(State) {
    $.ajax({
        url: "Adm_OpcRolAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tabla": 'OPTION_ROL'
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


/*-------------------- carga subrol---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaRol(State) {
    $.ajax({
        url: "Adm_OpcRolAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State

        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayComboSubRol = [];
            }
            else {
                ArrayComboSubRol = JSON.parse(result);
                charge_CatalogList(ArrayComboSubRol, "DDLSubRol_Rol", 1);
                charge_CatalogList(ArrayComboSubRol, "DDL_ID", 1);
            }
        },
        error: function () {

        }
    });
}




/*-------------------- carga subrol---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaLinks(State, tipo_link) {

    $.ajax({
        url: "Adm_OpcRolAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tipo_link": tipo_link

        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayComboLinks = [];
            }
            else {
                ArrayComboLinks = JSON.parse(result);
                charge_CatalogList(ArrayComboLinks, "DDLLink_ID", 1);
            }
        },
        error: function () {

        }
    });

}

/*------------------------------ consulta ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_opcRol(State, filtro, opcion) {
    var contenido;

    if ($("#TxtRead").val() == "") {
        contenido = "ALL";
    }
    else {
        contenido = $("#TxtRead").val();
    }


    $.ajax({
        url: "Adm_OpcRolAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "filtro": filtro,
            "opcion": opcion,
            "contenido": contenido
        },
        //mostrar resultados de la creacion de la opcion rol
        success: function (result) {
            if (result == "") {
                ArrayOpcRol = [];
            }
            else {
                ArrayOpcRol = JSON.parse(result);
                Table_opcRol();
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ crear ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_opcRol_create(State) {

    var ID;
    var param;

    if (State == "modificar") {
        ID = editID;
    } else {
        ID = $("#DDL_ID").val();
    }


    $.ajax({
        url: "Adm_OpcRolAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": ID,
            "consecutivo": $("#TxtConsecutivo").val(),
            "tipo": $("#DDLTipo").val(),
            "subrol_rol": $("#DDLSubRol_Rol").val(),
            "link_ID": $("#DDLLink_ID").val()
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se realizo El ingreso de la opcion perfil!");
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
                        $("#Mensaje_alert").text("La opcion perfil fue modificada exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        Clear();
                    }
                    else {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("La opcion perfil fue creada exitosamente! ");
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
function transacionAjax_opcRol_delete(State) {

    $.ajax({
        url: "Adm_OpcRolAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": editID,
            "DeleteConsecutivo": DeleteConsecutivo
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "Error") {
                $("#dialog").dialog("option", "title", "Disculpenos :(");
                $("#Mensaje_alert").text("No se realizo la eliminación de la opcion perfil!");
                $("#dialog").dialog("open");
                $("#DE").css("display", "block");
            }
            else {
                $("#dialog_eliminar").dialog("close");
                $("#dialog").dialog("option", "title", "Exito");
                $("#Mensaje_alert").text("la opcion perfil fue eliminada exitosamente! ");
                $("#dialog").dialog("open");
                $("#SE").css("display", "block");
                Clear();
            }
        },
        error: function () {

        }
    });

}