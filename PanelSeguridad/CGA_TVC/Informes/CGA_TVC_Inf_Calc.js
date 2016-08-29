var Calc_TotalOrdenesCTEC = 0;
var Calc_TotalOrdenesTiempo = 0;
var Calc_TotalOrdenesZRED = 0;
var CALC_TIEMPO;
var CALC_VELOCIDAD;
var CALC_CALIDAD;
var CALC_FINAL_TVC;

//averiguamos el total de registros CTEC
function ResultEstadoCTEC() {
    TotalOrdenesCTEC = 0;
    TotalOrdenesTiempo = 0;
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].DesStatusSistema == "CERRADA TECNICAMENTE" || ArrayTVC[itemArray].DesStatusSistema == "NOTIFICACION FINAL") {
            TotalOrdenesCTEC = TotalOrdenesCTEC + 1;
            TotalOrdenesTiempo = parseFloat(TotalOrdenesTiempo) + parseFloat(ArrayTVC[itemArray].TIEMPO);
        }
    }
}

//averiguamos el total de registros CTEC
function ResultEstadoZRED() {
    TotalOrdenesZRED = 0;
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].Clase == "ZRED") {
            TotalOrdenesZRED = TotalOrdenesZRED + 1;
        }
    }
}

//averiguamos la velocidad del puesto de trabajo
function ResulTVelocidad() {
    VELOCIDAD = parseFloat(TotalOrdenesCTEC) / parseFloat(ArrayTVC.length);
}

//averiguamos la calidad del puesto de trabajo
function ResulTCalidad() {
    CALIDAD = (parseFloat(TotalOrdenesCTEC) - parseFloat(TotalOrdenesZRED)) / parseFloat(TotalOrdenesCTEC);
}

//averiguamos el tiempo del puesto de trabajo
function ResulTTiempo() {
    TIEMPO = parseFloat(TotalOrdenesCTEC) / parseFloat(TotalOrdenesTiempo);
}

//averiguamos EL TVC puesto de trabajo
function ResultTVC() {
    FINAL_TVC = parseFloat(TIEMPO) * parseFloat(VELOCIDAD) * parseFloat(CALIDAD);
    FINAL_TVC = FINAL_TVC * 100;
    var StrTVC = FINAL_TVC.toString();
    $("#D_TVC").html(StrTVC.substring(0, 5) + " %");
}

/*--------------------------------------------------------------------------------------------------------------------------------*/
/*---------------------------------------------  TVC por fila para informe  ------------------------------------------------------*/
/*--------------------------------------------------------------------------------------------------------------------------------*/

// funcion de calculo tvc por registro en informe de gerarq
function CalcTVC_centro(Type) {

    var I_Centro;

    if (ArrayCantidad.length == 0) {
        I_Centro = 0;
    }
    else {
        I_Centro = ArrayCantidad[0];
    }

    var control;

    for (itemCant in ArrayCantidad) {

        var ObjComparar;
  
        for (itemArray in ArrayTVC) {

            if (Type == "Centro") { ObjComparar = ArrayTVC[itemArray].Centro_ID; }
            if (Type == "GrpMaq") { ObjComparar = ArrayTVC[itemArray].GRPMaquina_ID; }
            if (Type == "Maq") { ObjComparar = ArrayTVC[itemArray].Puestotrabajo_ID; }

            console.log(ArrayCantidad[itemCant] + " == " + ObjComparar);
            if (ArrayCantidad[itemCant] == ObjComparar) {
                if (ArrayTVC[itemArray].DesStatusSistema == "CERRADA TECNICAMENTE" || ArrayTVC[itemArray].DesStatusSistema == "NOTIFICACION FINAL") {
                    Calc_TotalOrdenesCTEC = Calc_TotalOrdenesCTEC + 1;
                    Calc_TotalOrdenesTiempo = parseFloat(Calc_TotalOrdenesTiempo) + parseFloat(ArrayTVC[itemArray].TIEMPO);
                }
            }
        }

        Calc_ResultEstadoZRED();
        Calc_ResulTVelocidad();
        Calc_ResulTCalidad();
        Calc_ResulTTiempo();


        switch (Type) {

            case "Centro":
                control = "C_";
                break;

            case "GrpMaq":
                control = "GM_";
                break;

            case "Maq":
                control = "M_";
                break;

        }

        Calc_ResultTVC(control + ArrayCantidad[itemCant]);

        Calc_TotalOrdenesCTEC = 0;
        Calc_TotalOrdenesTiempo = 0;
        CALC_VELOCIDAD = 0;
        CALC_CALIDAD = 0;
        CALC_TIEMPO = 0;
        CALC_FINAL_TVC = 0;
    }
}


//averiguamos el total de registros CTEC
function Calc_ResultEstadoZRED() {
    Calc_TotalOrdenesZRED = 0;
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].Clase == "ZRED") {
            Calc_TotalOrdenesZRED = Calc_TotalOrdenesZRED + 1;
        }
    }
}

//averiguamos la velocidad del puesto de trabajo
function Calc_ResulTVelocidad(FILA) {
    CALC_VELOCIDAD = parseFloat(Calc_TotalOrdenesCTEC) / parseFloat(ArrayTVC.length);
}

//averiguamos la calidad del puesto de trabajo
function Calc_ResulTCalidad() {
    CALC_CALIDAD = (parseFloat(Calc_TotalOrdenesCTEC) - parseFloat(Calc_TotalOrdenesZRED)) / parseFloat(Calc_TotalOrdenesCTEC);
}

//averiguamos el tiempo del puesto de trabajo
function Calc_ResulTTiempo() {
    CALC_TIEMPO = parseFloat(Calc_TotalOrdenesCTEC) / parseFloat(Calc_TotalOrdenesTiempo);
}

//averiguamos EL TVC POR SELECCION
function Calc_ResultTVC(FILA) {
    CALC_FINAL_TVC = parseFloat(CALC_TIEMPO) * parseFloat(CALC_VELOCIDAD) * parseFloat(CALC_CALIDAD);
    CALC_FINAL_TVC = CALC_FINAL_TVC * 100;
    var StrTVC = CALC_FINAL_TVC.toString();
    $("#" + FILA).html(StrTVC.substring(0, 5) + " %");
}
