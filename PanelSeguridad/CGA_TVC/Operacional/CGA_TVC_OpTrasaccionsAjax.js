/*-------------------- carga ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para cargar el droplist
function transacionAjax_CargaOperario(State) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "tabla": 'CGA_OPERARIOS'
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayCombo = [];
            }
            else {
                ArrayCombo = JSON.parse(result);
                charge_CatalogList(ArrayCombo, "DDLMaquina", 1);
            }
        },
        error: function () {

        }
    });
}


/*-------------------- carga centro planta---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los campos del TVC
function transacionAjax_CargaCentroPlanta(State, ID_Maquina) {

    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID_Maquina": ID_Maquina

        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayCentroPlanta = [];
            }
            else {
                ArrayCentroPlanta = JSON.parse(result);
                Centro_ID = ArrayCentroPlanta[0].Centro_ID;
                $("#LblCentro").html(ArrayCentroPlanta[0].Centro_ID + " " + ArrayCentroPlanta[0].Descripcion);
                $("#lblPlanta").html(ArrayCentroPlanta[0].Descripcion_Planta);
                $("#LblCentro").css("font-weight", "bold");
                $("#lblPlanta").css("font-weight", "bold");
                $("#Centro").css("display", "-webkit-inline-box");
                $("#Planta").css("display", "-webkit-inline-box");
                $("#LblCentro").css("display", "-webkit-inline-box");
                $("#lblPlanta").css("display", "-webkit-inline-box");
                $("#Centro").css("display", "table-cell");
                $("#Planta").css("display", "table-cell");
                $("#LblCentro").css("display", "table-cell");
                $("#lblPlanta").css("display", "table-cell");

                $("#inicial").css("display", "-webkit-inline-box");
                $("#final").css("display", "-webkit-inline-box");
                $("#DateStart").css("display", "-webkit-inline-box");
                $("#DateEnd").css("display", "-webkit-inline-box");
                $("#inicial").css("display", "table-cell");
                $("#final").css("display", "table-cell");
                $("#DateStart").css("display", "table-cell");
                $("#DateEnd").css("display", "table-cell");

                $("#BtnShearch").css("display", "-webkit-inline-box");
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
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "ID_Maquina": ID_Maquina,
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
                Table_TVC();
                ResultEstadoCTEC();
                ResultEstadoZRED();
                ResulTVelocidad();
                ResulTCalidad();
                ResulTTiempo();
                ResultTVC();
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga detalle tvc---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los campos del TVC detalle
function transacionAjax_TVCEncabezadoDet(State) {

    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "Maq": Maq,
            "Orden": Orden,
            "Opera": Opera,
            "Centro": Centro
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayTVCDET = [];
            }
            else {
                ArrayTVCDET = JSON.parse(result);
                $("#LblOrden").html(ArrayTVCDET[0].Orden_ID);
                $("#LblOperacion").html(ArrayTVCDET[0].Operacion_ID);
                $("#LblFLiber").html(ArrayTVCDET[0].FechaLiberacReal);
                $("#LblFCier").html(ArrayTVCDET[0].FechaCier);
                $("#LblFDespacho").html(ArrayTVCDET[0].FechaRegEntrega);
                $("#LblEstado").html(ArrayTVCDET[0].DesStatusSistema);
                $("#Circulo").css("background", "" + ArrayTVCDET[0].SEMAFORO + "");
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga detalle tvc grid ---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los campos del TVC detalle
function transacionAjax_TVCGridDet(State) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "Maq": Maq,
            "Orden": Orden,
            "Opera": Opera,
            "Centro": Centro
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayTVCDET_Grid = [];
            }
            else {
                ArrayTVCDET_Grid = JSON.parse(result);
                Table_TVCDet();
            }
        },
        error: function () {

        }
    });

}

/*-------------------- carga Causales nueva causal---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los DDl caulsasap y causal
function transacionAjax_CCausal(State, Type) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "Type": Type
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayCausal = [];
            }
            else {
                ArrayCausal = JSON.parse(result);

                if (ArrayCausal[0].tipo == 1) {
                    charge_CatalogList(ArrayCausal, "DDLCausalSAP", 1);
                }
                else {
                    charge_CatalogList(ArrayCausal, "DDLCausal", 1);
                }
            }
        },
        error: function () {

        }
    });
}


/*-------------------- carga turno nueva causal---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los DDl Turno
function transacionAjax_CTurno(State) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayTurno = [];
            }
            else {
                ArrayTurno = JSON.parse(result);

                charge_CatalogList(ArrayTurno, "DDLTurno", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga operador nueva causal---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los DDl operador
function transacionAjax_COperarioDet(State) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayOpeDet = [];
            }
            else {
                ArrayOpeDet = JSON.parse(result);

                charge_CatalogList(ArrayOpeDet, "DDLOperario", 1);
            }
        },
        error: function () {

        }
    });
}


/*-------------------- carga accion nueva causal---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los DDl accion
function transacionAjax_CAccion(State) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayAccion = [];
            }
            else {
                ArrayAccion = JSON.parse(result);

                charge_CatalogList(ArrayAccion, "DDLAccion", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- carga area nueva causal---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para los DDl area
function transacionAjax_CArea(State) {
    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            if (result == "") {
                ArrayArea = [];
            }
            else {
                ArrayArea = JSON.parse(result);

                charge_CatalogList(ArrayArea, "DDLArea", 1);
            }
        },
        error: function () {

        }
    });
}

/*-------------------- Crear nueva causal---------------------------*/
//hacemos la transaccion al code behind por medio de Ajax para crear la nueva causal
function transacionAjax_NuevaCausal(State) {

    var fechac;
    if (State == "modificar") {
        fechac = VG_FECHA_CRE;
    }
    else {
        fechac = "";
    }

    $.ajax({
        url: "CGA_TVC_OpAjax.aspx",
        type: "POST",
        //crear json
        data: { "action": State,
            "centro": Centro,
            "Maq": Maq,
            "Orden": Orden,
            "Opera": Opera,
            "turno": $("#DDLTurno").val(),
            "operario": $("#DDLOperario").val(),
            "causalSAP": $("#DDLCausalSAP").val(),
            "causal": $("#DDLCausal").val(),
            "obserope": $("#TxtObserOpe").val(),
            "descrip": $("#TxtDescripAnalis").val(),
            "accion": $("#DDLAccion").val(),
            "dateaccion": $("#DateAccion").val(),
            "area": $("#DDLArea").val(),
            "fechac": fechac,
            "estado": $("#DDLEstado").val(),
            "user": User
        },
        //Transaccion Ajax en proceso
        success: function (result) {
            switch (result) {

                case "Error":
                    $("#dialog").dialog("option", "title", "Disculpenos :(");
                    $("#Mensaje_alert").text("No se realizo el ingreso de la nueva causal");
                    $("#dialog").dialog("open");
                    $("#DE").css("display", "block");
                    $("#SE").css("display", "none");
                    $("#WE").css("display", "none");
                    break;

                case "Exito":
                    if (estado == "modificar") {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("La nueva causal fue modificada exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        $("#WE").css("display", "none");
                        transacionAjax_TVCGridDet('GridDet');

                    }
                    else {
                        $("#dialog").dialog("option", "title", "Exito");
                        $("#Mensaje_alert").text("La nueva causal fue creada exitosamente! ");
                        $("#dialog").dialog("open");
                        $("#DE").css("display", "none");
                        $("#SE").css("display", "block");
                        $("#WE").css("display", "none");
                        transacionAjax_TVCGridDet('GridDet');
                    }
                    break;
            }

        },
        error: function () {

        }
    });
}