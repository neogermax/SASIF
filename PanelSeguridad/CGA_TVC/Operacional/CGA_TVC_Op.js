/*--------------- region de variables globales --------------------*/
var ArrayTVC = [];
var ArrayCentroPlanta = [];
var estado;
var Centro_ID;
var FechaAct;
var ID_Maquina;
var TotalOrdenesCTEC;
var TotalOrdenesZRED;
var TotalOrdenesTiempo;
var VELOCIDAD;
var CALIDAD;
var TIEMPO;
var FINAL_TVC;

/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    transacionAjax_CargaOperario('cargar_droplist_operario');
    CCentro_Planta();
    $("#ESelect").css("display", "none");
    $("#DE").css("display", "none");
    $("#SE").css("display", "none");
    $("#WE").css("display", "none");

    $("#Centro").css("display", "none");
    $("#Planta").css("display", "none");
    $("#LblCentro").css("display", "none");
    $("#lblPlanta").css("display", "none");

    $("#inicial").css("display", "none");
    $("#final").css("display", "none");
    $("#TVC").css("display", "none");
    $("#DateStart").css("display", "none");
    $("#DateEnd").css("display", "none");
    $("#TD_L_TVC").css("display", "none");
    $("#BtnShearch").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");

    $("#container_TTVC").css("display", "none");

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });

    //funcion para las ventanas emergentes
    $("#dialog_eliminar").dialog({
        autoOpen: false
    });

    //funcion para campos numericos
    $('.solo-numero').keyup(function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    });

    //funcion para agregar el calendario
    $(function () {
        $("#DateStart").datepicker();
        $("#DateEnd").datepicker();
    });
});

//salida del formulario
function btnSalir() {
    window.location = "../../Menu/menu.aspx?User=" + $("#User").html();
}

//funcion que dispara elcombo del tipo
function CCentro_Planta() {

    $("#DDLMaquina").change(function () {
        loadChildrenMaquina($(this));
    });

}

//fucion que carga desde ddl MAQUINA el centro y la planta
function loadChildrenMaquina(obj) {
    ID_Maquina = $(obj).val();
    transacionAjax_CargaCentroPlanta('cargar_CentroPlanta', ID_Maquina);
}

//funcion que ejecuta la busqueda
function BtnConsulta() {

    var validate;
    validate = validarCampos();
    if (validate == 0) {
        validarFecha();
    }

}

//validamos campos para la creacion del link
function validarCampos() {

    var StartDate = $("#DateStart").val();
    var EndDate = $("#DateEnd").val();
    var validar = 0;

    if (StartDate == "" || EndDate == "") {
        validar = 1;
        if (StartDate == "") {
            $("#Img1").css("display", "inline-table");
        }
        else {
            $("#Img1").css("display", "none");
        }
        if (EndDate == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
    }
    else {
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
    }
    return validar;
}

//funcion que valida la fecha fin nosea mayor que la inicial
function validarFecha() {

    var StartDate = $("#DateStart").val();
    var EndDate = $("#DateEnd").val();

    if (StartDate > EndDate) {
        $("#dialog").dialog("option", "title", "Atención");
        $("#Mensaje_alert").text("La fecha final NO debe ser mayor que la fecha Inicial!");
        $("#dialog").dialog("open");
        $("#DE").css("display", "none");
        $("#SE").css("display", "none");
        $("#WE").css("display", "Block");
    }
    else {
        transacionAjax_Datos_TVC('Datos_TVC');
        $("#container_TTVC").css("display", "block");
    }

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//CREA La tabla TVC
function Table_TVC() {

    var html_TTVC = "<table id='TTVC' border='1' cellpadding='1' cellspacing='1'  style='width: 100%; text-align: center;'><thead><tr><th>Detalle</th><th>Orden</th><th>Operacion</th><th>F. liberacion</th><th>F. Cierre</th><th>F. Entrega Despacho</th><th>Estado</th><th>Semaforo</th></tr></thead><tbody>";
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].Orden_ID != 0) {
            html_TTVC += "<tr id= 'TTVC_" + ArrayTVC[itemArray].Orden_ID + "'><td><input type ='radio' class= 'Det' name='detalle' onclick=\"Detalle('" + ID_Maquina + "','" + ArrayTVC[itemArray].Orden_ID + "','" + ArrayTVC[itemArray].Operacion_ID + "')\"></input></td><td>" + ArrayTVC[itemArray].Orden_ID + "</td><td>" + ArrayTVC[itemArray].Operacion_ID + "</td><td>" + ArrayTVC[itemArray].FechaLiberacReal + "</td><td>" + ArrayTVC[itemArray].FechaCier + "</td><td>" + ArrayTVC[itemArray].FechaRegEntrega + "</td><td>" + ArrayTVC[itemArray].DesStatusSistema + "</td><td><input type='text' id='Circulo' readonly='readonly' class='circulo' style=' background:" + ArrayTVC[itemArray].SEMAFORO + ";' /></td></tr>";
        }
    }
    html_TTVC += "</tbody></table>";
    $("#container_TTVC").html("");
    $("#container_TTVC").html(html_TTVC);

    $(".Det").click(function () {
    });

    $("#TTVC").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });

}

function Detalle(Maquina, Orden, Operacion) {
    window.location = "../../CGA_TVC/Operacional/CGA_TVC_OpDet.aspx?User=" + $("#User").html() + "&Orden=" + Orden + "&Opera=" + Operacion + "&Maq=" + Maquina + "&C=" + Centro_ID;
}

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

//averiguamos el tiempo del puesto de trabajo
function ResulTTiempo() {
    TIEMPO = parseFloat(TotalOrdenesCTEC) / parseFloat(TotalOrdenesTiempo);
}

//averiguamos la velocidad del puesto de trabajo
function ResulTVelocidad() {
    VELOCIDAD = parseFloat(TotalOrdenesCTEC) / parseFloat(ArrayTVC.length);
}

//averiguamos la calidad del puesto de trabajo
function ResulTCalidad() {
    CALIDAD = (parseFloat(TotalOrdenesCTEC) - parseFloat(TotalOrdenesZRED)) / parseFloat(TotalOrdenesCTEC);
}

//averiguamos EL TVC puesto de trabajo
function ResultTVC() {
    FINAL_TVC = parseFloat(TIEMPO) * parseFloat(VELOCIDAD) * parseFloat(CALIDAD);
    FINAL_TVC = FINAL_TVC * 100;
    var StrTVC = FINAL_TVC.toString();
    $("#TVC").css("display", "table-cell");
    $("#TVC").css("display", "-webkit-inline-box");
    $("#TD_L_TVC").css("display", "table-cell");
    $("#TD_L_TVC").css("display", "-webkit-inline-box");
    $("#TD_L_TVC").html(StrTVC.substring(0, 5) + " %");
}
