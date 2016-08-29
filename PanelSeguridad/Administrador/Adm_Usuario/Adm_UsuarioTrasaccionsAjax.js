/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaBusqueda(State) {
    $.ajax({
        url: "Adm_UsuarioAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tabla": 'USUARIOS'
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

/*-------------------- carga rol---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaRol(State) {
    $.ajax({
        url: "Adm_UsuarioAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State

        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayComboRol = [];
            }
            else {
                ArrayComboRol = JSON.parse(result);
                charge_CatalogList(ArrayComboRol, "DDLRol", 1);
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ consulta ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_User(State, filtro, opcion) {
    var contenido;

    if ($("#TxtRead").val() == "") {
        contenido = "ALL";
    }
    else {
        contenido = $("#TxtRead").val();
    }


    $.ajax({
        url: "Adm_UsuarioAjax.aspx",
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
                ArrayUser = [];
            }
            else {
                ArrayUser = JSON.parse(result);
                Table_User();
            }
        },
        error: function () {

        }
    });
}

/*------------------------------ crear ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax
function transacionAjax_User_create(State) {

    var ID;
    var param;

    if (State == "modificar") {
        ID = editID;
    } else {
        ID = $("#Txt_ID").val();
    }


    $.ajax({
        url: "Adm_UsuarioAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": ID,
            "nombre": $("#TxtName").val(),
            "documento": $("#TxtDocument").val(),
            "rolID": $("#DDLRol").val()    
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se realizo El ingreso del Usuario!");
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
                        $("#Mensaje_alert").text("El Usuario fue modificado exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        Clear();
                    }
                    else {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("EL Usuario fue creado exitosamente! ");
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
function transacionAjax_User_delete(State) {

    $.ajax({
        url: "Adm_UsuarioAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID": editID
        },
       //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "Error") {
                $("#dialog").dialog("option", "title", "Disculpenos :(");
                $("#Mensaje_alert").text("No se realizo la eliminación del Usuario");
                $("#dialog").dialog("open");
                $("#DE").css("display", "block");
            }
            else {
                $("#dialog_eliminar").dialog("close");
                $("#dialog").dialog("option", "title", "Exito");
                $("#Mensaje_alert").text("El Usuario fue eliminado exitosamente! ");
                $("#dialog").dialog("open");
                $("#SE").css("display", "block");
                Clear();
            }
        },
        error: function () {

        }
    });

}