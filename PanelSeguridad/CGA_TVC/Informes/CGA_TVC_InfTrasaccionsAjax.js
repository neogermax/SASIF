/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaCentro(State) {
    $.ajax({
        url: "CGA_TVC_InfAjax.aspx",
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
                charge_CatalogList(ArrayCentro, "DDLCentro", 2);
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
        url: "CGA_TVC_InfAjax.aspx",
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
                charge_CatalogList(ArrayGrpMaq, "DDLGprMaquina", 2);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga planta---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los campos del TVC
function transacionAjax_CargaPlanta(State, ID_Centro) {

    $.ajax({
        url: "CGA_TVC_InfAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID_Centro": ID_Centro
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayPlanta = [];
            }
            else {
                ArrayPlanta = JSON.parse(result);
                $("#lblPlanta").html(ArrayPlanta[0].Descripcion_Planta);
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
        url: "CGA_TVC_InfAjax.aspx",
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
                charge_CatalogList(ArrayMaquina, "DDLMaquina", 2);
            }
        },
        error: function () {
        }
    });

}

/*-------------------- carga centro planta---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los campos del TVC
function transacionAjax_Datos_TVC(State) {


    $.ajax({
        url: "CGA_TVC_InfAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "Centro": $("#DDLCentro").val(),
            "GprMaquina": $("#DDLGprMaquina").val(),
            "Maquina": $("#DDLMaquina").val(),
            "StartDate": $("#DateStart").val(),
            "EndDate": $("#DateEnd").val()
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayTVC = [];
            }
            else {
                ArrayTVC = JSON.parse(result);
                ValidaFiltros();
            }
        },
        error: function () {

        }
    });
}

