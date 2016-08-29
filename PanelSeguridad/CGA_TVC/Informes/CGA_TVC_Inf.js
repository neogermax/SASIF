/*--------------- region de variables globales --------------------*/
var ArrayTVC = [];
var ArrayCentro = [];
var ArrayGrpMaq = [];
var ArrayPlanta = [];
var ArrayMaquina = [];

var ArrayCantidad = [];
var Centro_ID;
var GprMaquina_ID;

var estado;
var FechaAct;
var TotalOrdenesCTEC;
var TotalOrdenesZRED;
var TotalOrdenesTiempo;
var VELOCIDAD;
var CALIDAD;
var TIEMPO;
var FINAL_TVC;
var flag = 0;

/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    carga_eventos("Dialog_Charge");
    transacionAjax_CargaCentro('cargar_droplist_Centro');
    Planta();
    Maquina();
    $("#ESelect").css("display", "none");
    $("#DE").css("display", "none");
    $("#SE").css("display", "none");
    $("#WE").css("display", "none");


    $("#TVC").css("display", "none");
    $("#TD_L_TVC").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img5").css("display", "none");
    $("#Img6").css("display", "none");


    $("#container_TTVC").css("display", "none");

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", ui.dialog).show(); }
    });

    //funcion para las ventanas emergentes
    $("#dialog_eliminar").dialog({
        autoOpen: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", ui.dialog).show(); }
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

    //funcion para las ventanas emergentes
    $("#Dialog_Grid").dialog({
        autoOpen: false,
        dialogClass: "Dialog_personal",
        modal: true,
        width: 700,
        height: 500,
        overlay: {
            opacity: 0.5,
            background: "black"
        },
        open: function (event, ui) { $(".ui-dialog-titlebar-close", ui.dialog).show(); }
    });
});

//salida del formulario
function btnSalir() {
    window.location = "../../Menu/menu.aspx?User=" + $("#User").html();
}

//fucion que carga desde ddl Centro la planta
function Planta() {
    $("#DDLCentro").change(function () {
        if ($("#DDLCentro").val() == 0) {
            $("#DDLGprMaquina").attr("disabled", "disabled");
            $("#DDLMaquina").attr("disabled", "disabled");
            $("#DDLGprMaquina").val("0");
            $("#DDLMaquina").val("0");
        }
        else {
            $("#DDLGprMaquina").removeAttr("disabled");
            $("#DDLMaquina").removeAttr("disabled");
            loadChildrenCentro($(this));
        }

    });
}

//fucion que carga desde ddl Grpmaquina carga la maquina
function Maquina() {
    $("#DDLGprMaquina").change(function () {
        if ($("#DDLGprMaquina").val() == 0) {
            $("#DDLMaquina").attr("disabled", "disabled");
            $("#DDLMaquina").val("0");
        }
        else {
            $("#DDLMaquina").removeAttr("disabled");
            loadChildrenMaquina($(this));
        }
    });
}

//fucion que carga desde ddl Centro la planta
function loadChildrenCentro(obj) {
    $("#DDLGprMaquina").empty();
    Centro_ID = $(obj).val();
    transacionAjax_CargaPlanta('cargarPlanta', Centro_ID);
    transacionAjax_CargaGrpMaq('cargar_droplist_GrpMaq', Centro_ID);
}

//fucion que carga desde ddl gprMaquina carga la maquina
function loadChildrenMaquina(obj) {
    $("#DDLMaquina").empty();
    GprMaquina_ID = $(obj).val();
    transacionAjax_Maquina('cargarMaquina', GprMaquina_ID, Centro_ID);
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

    var option = "0";
    //captura y validacion de centro opcion TODOS
    var Centro = $("#DDLCentro").val();
    if (Centro == "0") {
        option = 1;
    }
    else {
        if (Centro == "-1") {
            option = 2;
        }
        else {
            //captura y validacion de grupo de maquina opcion TODOS
            var GprM = $("#DDLGprMaquina").val();
            if (GprM == "0") {
                option = 1;
            }
            else {
                if (GprM == "-1") {
                    option = 3;
                }
                else {
                    //captura y validacion de maquina opcion TODOS
                    var M = $("#DDLMaquina").val();
                    if (M == "0") {
                        option = 1;
                    }
                    else {
                        option = 4;
                    }
                }
            }
        }
    }

    var StartDate = $("#DateStart").val();
    var EndDate = $("#DateEnd").val();
    var validar = 0;
    switch (option) {
        case 1:
            validar = valida_C(StartDate, EndDate, option, "0", "0", "0");

        case 2:
            validar = valida_C(StartDate, EndDate, option, Centro, "0", "0");

        case 3:
            validar = valida_C(StartDate, EndDate, option, Centro, GprM, "0");

        case 4:
            validar = valida_C(StartDate, EndDate, option, Centro, GprM, M);

    }
    return validar;
}

//funcion que controla la validacion de los campos
function valida_C(StartDate, EndDate, option, Centro, GprM, M) {

    var validar = 0;

    //validacion por fechas y TODOS
    if (option == "1") {
        if (StartDate == "" || EndDate == "") {
            validar = 1;
            if (StartDate == "") {
                $("#Img5").css("display", "inline-table");
            }
            else {
                $("#Img5").css("display", "none");
            }
            if (EndDate == "") {
                $("#Img6").css("display", "inline-table");
            }
            else {
                $("#Img6").css("display", "none");
            }
        }
        else {
            $("#Img5").css("display", "none");
            $("#Img6").css("display", "none");
        }
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
        $("#Img3").css("display", "none");
    }


    //validacion por fechas y centro
    if (option == "2") {
        if (StartDate == "" || EndDate == "" || Centro == "-1") {
            validar = 1;
            if (Centro == "-1") {
                $("#Img1").css("display", "inline-table");
            }
            else {
                $("#Img1").css("display", "none");
            }
            if (StartDate == "") {
                $("#Img5").css("display", "inline-table");
            }
            else {
                $("#Img5").css("display", "none");
            }
            if (EndDate == "") {
                $("#Img6").css("display", "inline-table");
            }
            else {
                $("#Img6").css("display", "none");
            }
        }
        else {
            $("#Img1").css("display", "none");
            $("#Img5").css("display", "none");
            $("#Img6").css("display", "none");
        }
        $("#Img2").css("display", "none");
        $("#Img3").css("display", "none");
    }

    //validacion por fechas ,centro y grupo de maquina
    if (option == "3") {
        if (StartDate == "" || EndDate == "" || Centro == "-1" || GprM == "-1") {
            validar = 1;
            if (Centro == "-1") {
                $("#Img1").css("display", "inline-table");
            }
            else {
                $("#Img1").css("display", "none");
            }
            if (GprM == "-1") {
                $("#Img2").css("display", "inline-table");
            }
            else {
                $("#Img2").css("display", "none");
            }
            if (StartDate == "") {
                $("#Img5").css("display", "inline-table");
            }
            else {
                $("#Img5").css("display", "none");
            }
            if (EndDate == "") {
                $("#Img6").css("display", "inline-table");
            }
            else {
                $("#Img6").css("display", "none");
            }
        }
        else {
            $("#Img1").css("display", "none");
            $("#Img2").css("display", "none");
            $("#Img5").css("display", "none");
            $("#Img6").css("display", "none");
        }
    }

    //validacion por fechas ,centro, grupo de maquina y maquina
    if (option == "4") {

        if (StartDate == "" || EndDate == "" || Centro == "-1" || GprM == "-1" || M == "-1") {
            validar = 1;
            if (Centro == "-1") {
                $("#Img1").css("display", "inline-table");
            }
            else {
                $("#Img1").css("display", "none");
            }
            if (GprM == "-1") {
                $("#Img2").css("display", "inline-table");
            }
            else {
                $("#Img2").css("display", "none");
            }
            if (M == "-1") {
                $("#Img3").css("display", "inline-table");
            }
            else {
                $("#Img3").css("display", "none");
            }
            if (StartDate == "") {
                $("#Img5").css("display", "inline-table");
            }
            else {
                $("#Img5").css("display", "none");
            }
            if (EndDate == "") {
                $("#Img6").css("display", "inline-table");
            }
            else {
                $("#Img6").css("display", "none");
            }
        }
        else {
            $("#Img1").css("display", "none");
            $("#Img2").css("display", "none");
            $("#Img3").css("display", "none");
            $("#Img5").css("display", "none");
            $("#Img6").css("display", "none");
        }
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



function ValidaFiltros() {

    $("#container_TTVC_INFO").html("");
    $("#Dialog_Grid").dialog("option", "width", 900);
    $("#Dialog_Grid").dialog("option", "height", 500);

    if ($("#DDLCentro").val() == "0") {
        //tabla centro 
        $("#Dialog_Grid").dialog("option", "title", "CGA");
        $("#Dialog_Grid").dialog("open");
        DetEncabezado();
        ArrayCantidad = [];
        VELOCIDAD = 0;
        CALIDAD = 0;
        TIEMPO = 0;
        Table_TVC_Centro();
        CalcTVC_centro("Centro");
    }
    else {
        if ($("#DDLGprMaquina").val() == "0") {
            //tabla grupo de maquina 
            $("#Dialog_Grid").dialog("option", "title", "Centro: " + $("#DDLCentro :selected").text());
            $("#Dialog_Grid").dialog("open");
            DetEncabezado();
            ArrayCantidad = [];
            VELOCIDAD = 0;
            CALIDAD = 0;
            TIEMPO = 0;
            Table_TVC_GRPMaquina();
            CalcTVC_centro("GrpMaq");
        }
        else {
            if ($("#DDLMaquina").val() == "0") {
                //tabla maquina
                $("#Dialog_Grid").dialog("option", "title", "Grupo de Maquina: " + $("#DDLGprMaquina :selected").text());
                $("#Dialog_Grid").dialog("open");
                DetEncabezado();
                ArrayCantidad = [];
                VELOCIDAD = 0;
                CALIDAD = 0;
                TIEMPO = 0;
                Table_TVC_Maquina();
                CalcTVC_centro("Maq");
            }
            else {
                if ($("#DDLMaquina").val() != "0") {
                    //tabla orden
                    $("#Dialog_Grid").dialog("option", "title", "Maquina: " + $("#DDLMaquina :selected").text());
                    $("#Dialog_Grid").dialog("open");
                    $("#Dialog_Grid").dialog("option", "height", 550);
                    VELOCIDAD = 0;
                    CALIDAD = 0;
                    TIEMPO = 0;
                    DetEncabezado();
                    Table_TVC_Orden();
                }
            }
        }
    }
    ResultEstadoCTEC();
    ResultEstadoZRED();
    ResulTVelocidad();
    ResulTCalidad();
    ResulTTiempo();
    ResultTVC();
}


//crea la tabla de TVC INFORMES a nivel de Centros (CGA)
function Table_TVC_Centro() {

    var html_TTVC = "";
    var I_Centro;
    flag = 0;

    if (ArrayTVC.length == 0) {
        I_Centro = 0;
    }
    else {
        I_Centro = ArrayTVC[0].Centro_ID;
    }

    html_TTVC = "<table id='T_Centro'  border='1' cellpadding='1' cellspacing='1' style='width: 100%; text-align: center;'><thead><tr><th>Ver</th><th>Centro</th><th>T.V.C</th></tr></thead><tbody>";
    for (itemArray in ArrayTVC) {

        if (ArrayTVC[itemArray].Orden_ID != 0) {

            if (I_Centro == ArrayTVC[itemArray].Centro_ID) {
                if (flag == 0) {
                    html_TTVC += "<tr id= 'TTVC_" + ArrayTVC[itemArray].Centro_ID + "'><td><input type ='radio' class= 'VerC' name='verC' onclick=\"Visualizacion_Cascada('" + ArrayTVC[itemArray].Centro_ID + "','" + ArrayTVC[itemArray].GRPMaquina_ID + "','" + ArrayTVC[itemArray].Puestotrabajo_ID + "','Centro')\"></input></td><td>" + ArrayTVC[itemArray].Centro_ID + " " + ArrayTVC[itemArray].Descrip_Centro + "</td><td id='C_" + ArrayTVC[itemArray].Centro_ID + "'></td></tr>";
                    ArrayCantidad.push(ArrayTVC[itemArray].Centro_ID);
                    flag = 1;
                }

            }
            else {
                I_Centro = ArrayTVC[itemArray].Centro_ID;
                flag = 0;
            }

        }
    }
    html_TTVC += "</tbody></table>";
    $("#container_TTVC_INFO").html(html_TTVC);

    $(".VerC").click(function () {
    });

    $("#T_Centro").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });

}


//crea la tabla de TVC INFORMES a nivel de Grupo de maquina (CGA)
function Table_TVC_GRPMaquina() {

    var html_TTVC = "";
    var I_GRPMaquina_ID;
    flag = 0;

    if (ArrayTVC.length == 0) {
        I_GRPMaquina_ID = 0;
    }
    else {
        I_GRPMaquina_ID = ArrayTVC[0].GRPMaquina_ID;
    }

    html_TTVC = "<table id='T_GrpMaq'  border='1' cellpadding='1' cellspacing='1' style='width: 100%; text-align: center;'><thead><tr><th>Ver</th><th>Grupo de Maquina</th><th>T.V.C</th></tr></thead><tbody>";
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].Orden_ID != 0) {
            if (I_GRPMaquina_ID == ArrayTVC[itemArray].GRPMaquina_ID) {
                if (flag == 0) {
                    html_TTVC += "<tr id= 'TTVC_" + ArrayTVC[itemArray].GRPMaquina_ID + "'><td><input type ='radio' class= 'VerG' name='verG' onclick=\"Visualizacion_Cascada('" + ArrayTVC[itemArray].Centro_ID + "','" + ArrayTVC[itemArray].GRPMaquina_ID + "','" + ArrayTVC[itemArray].Puestotrabajo_ID + "','GrpMaq')\"></input></td><td>" + ArrayTVC[itemArray].Descrip_GRPMaquina + "</td><td id='GM_" + ArrayTVC[itemArray].GRPMaquina_ID + "'></td></tr>";
                    ArrayCantidad.push(ArrayTVC[itemArray].GRPMaquina_ID);
                    flag = 1;
                }
            }
            else {
                I_GRPMaquina_ID = ArrayTVC[itemArray].GRPMaquina_ID;
                flag = 0;
            }
        }
    }
    html_TTVC += "</tbody></table>";
    $("#container_TTVC_INFO").html(html_TTVC);

    $(".VerG").click(function () {
    });

    $("#T_GrpMaq").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });

}

//crea la tabla de TVC INFORMES a nivel de maquina (CGA)
function Table_TVC_Maquina() {

    var html_TTVC = "";
    flag = 0;
    var I_Maquina_ID;

    if (ArrayTVC.length == 0) {
        I_Maquina_ID = 0;
    }
    else {
        I_Maquina_ID = ArrayTVC[0].Puestotrabajo_ID;
    }

    html_TTVC = "<table id='T_Maq'  border='1' cellpadding='1' cellspacing='1' style='width: 100%; text-align: center;'><thead><tr><th>Ver</th><th>Maquina</th><th>T.V.C</th></tr></thead><tbody>";
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].Orden_ID != 0) {
            if (I_Maquina_ID == ArrayTVC[itemArray].Puestotrabajo_ID) {
                if (flag == 0) {
                    html_TTVC += "<tr id= 'TTVC_" + ArrayTVC[itemArray].Puestotrabajo_ID + "'><td><input type ='radio' class= 'VerM' name='verM' onclick=\"Visualizacion_Cascada('" + ArrayTVC[itemArray].Centro_ID + "','" + ArrayTVC[itemArray].GRPMaquina_ID + "','" + ArrayTVC[itemArray].Puestotrabajo_ID + "','Maq')\"></input></td><td>" + ArrayTVC[itemArray].Descrip_Puestotrabajo + "</td><td id='M_" + ArrayTVC[itemArray].Puestotrabajo_ID + "'></td></tr>";
                    ArrayCantidad.push(ArrayTVC[itemArray].Puestotrabajo_ID);
                    flag = 1;
                }
            }
            else {
                I_Maquina_ID = ArrayTVC[itemArray].Puestotrabajo_ID;
                flag = 0;
            }
        }
    }
    html_TTVC += "</tbody></table>";
    $("#container_TTVC_INFO").html(html_TTVC);

    $(".VerM").click(function () {
    });

    $("#T_Maq").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });

}


//llama la ventana emergente dependiendo de la opcion del grid Escogido
function Visualizacion_Cascada(C, GM, M, Grid) {

    $("#Dialog_Grid").dialog("close");

    switch (Grid) {

        case "Centro":

            $("#DDLCentro").val(C);
            transacionAjax_CargaGrpMaq('cargar_droplist_GrpMaq', C);
            var timer_GrpMaq = setTimeout("$('#DDLGprMaquina').val(0);", 2000);
            $("#DDLGprMaquina").removeAttr("disabled");

        case "GrpMaq":


            $("#DDLCentro").val(C);
            $("#DDLGprMaquina").val(GM);
            transacionAjax_Maquina('cargarMaquina', GM, C);
            var timer_Maq = setTimeout("$('#DDLMaquina').val(0);", 2000);
            $("#DDLMaquina").removeAttr("disabled");

        case "Maq":

            $("#DDLCentro").val(C);
            $("#DDLGprMaquina").val(GM);
            $("#DDLMaquina").val(M);
    }

    var timer_ajax = setTimeout("transacionAjax_Datos_TVC('Datos_TVC');", 2000);

}


//crea la tabla de TVC INFORMES a nivel de Ordenes
function Table_TVC_Orden() {

    var html_TTVC = "<table id='T_Orden' border='1' cellpadding='1' cellspacing='1'  style='width: 100%; text-align: center;'><thead><tr><th>Orden</th><th>Operacion</th><th>F. liberacion</th><th>F. Cierre</th><th>F. Entrega Despacho</th><th>Estado</th><th>Semaforo</th></tr></thead><tbody>";
    for (itemArray in ArrayTVC) {
        if (ArrayTVC[itemArray].Orden_ID != 0) {
            html_TTVC += "<tr id= 'TTVC_" + ArrayTVC[itemArray].Orden_ID + "'><td>" + ArrayTVC[itemArray].Orden_ID + "</td><td>" + ArrayTVC[itemArray].Operacion_ID + "</td><td>" + ArrayTVC[itemArray].FechaLiberacReal + "</td><td>" + ArrayTVC[itemArray].FechaCier + "</td><td>" + ArrayTVC[itemArray].FechaRegEntrega + "</td><td>" + ArrayTVC[itemArray].DesStatusSistema + "</td><td><input type='text' id='Circulo' readonly='readonly' class='circulo' style=' background:" + ArrayTVC[itemArray].SEMAFORO + ";' /></td></tr>";
        }
    }
    html_TTVC += "</tbody></table>";
    $("#container_TTVC_INFO").html(html_TTVC);

    $(".Det").click(function () {
    });

    $("#T_Orden").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//ajusta los filtros visualmente
function DetEncabezado() {

    var selection = $("#DDLCentro :selected").text();

    if (selection == "Todos") {
        $("#D_Centro").html("Todos");
        $("#D_Planta").html("Todos");
        $("#D_GrpMaq").html("Todos");
        $("#D_Maq").html("Todos");
    }
    else {
        $("#D_Centro").html($("#DDLCentro :selected").text());
        $("#D_Planta").html($("#lblPlanta").html());

        selection = $("#DDLGprMaquina :selected").text();

        if (selection == "Todos") {
            $("#D_GrpMaq").html("Todos");
            $("#D_Maq").html("Todos");
        }
        else {
            $("#D_GrpMaq").html($("#DDLGprMaquina :selected").text());

            selection = $("#DDLMaquina :selected").text();

            if (selection == "Todos") {
                $("#D_Maq").html("Todos");
            }
            else {
                $("#D_Maq").html($("#DDLMaquina :selected").text());
            }
        }
    }
}

