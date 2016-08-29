/*--------------- region de variables globales --------------------*/
var ArrayNotificacion = [];
var ArrayCentro = [];
var ArrayGrpMaq = [];
var ArrayPlanta = [];
var ArrayMaquina = [];

var Centro_ID;
var GprMaquina_ID;

var estado;
var FechaAct;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    transacionAjax_CargaCentro('cargar_droplist_Centro');
    transacionAjax_CargaGrpMaq('cargar_droplist_GrpMaq');
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
        autoOpen: false
    });

    //funcion para las ventanas emergentes
    $("#dialog_eliminar").dialog({
        autoOpen: false
    });

    //funcion para las ventanas emergentes
    $("#dialog_VerDetalle").dialog({
        autoOpen: false,
        dialogClass: "NewCausal",
        modal: true,
        width: 500,
        height: 550,
        overlay: {
            opacity: 0.5,
            background: "black"
        }
    });

    //funcionalidad del acordeon
    $(function () {
        $("#BloqueConsult").accordion({
            heightStyle: "content"
        });
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

//fucion que carga desde ddl Centro la planta
function Planta() {
    $("#DDLCentro").change(function () {
        loadChildrenCentro($(this));
    });
}

//fucion que carga desde ddl Grpmaquina carga la maquina
function Maquina() {
    $("#DDLGprMaquina").change(function () {
        loadChildrenMaquina($(this));
    });
}

//fucion que carga desde ddl Centro la planta
function loadChildrenCentro(obj) {
    Centro_ID = $(obj).val();
    transacionAjax_CargaPlanta('cargarPlanta', Centro_ID);
}

//fucion que carga desde ddl gprMaquina carga la maquina
function loadChildrenMaquina(obj) {
    GprMaquina_ID = $(obj).val();
    transacionAjax_Maquina('cargarMaquina', GprMaquina_ID);
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

    var Centro = $("#DDLCentro").val();
    var GprM = $("#DDLGprMaquina").val();
    var M = $("#DDLMaquina").val();
    var StartDate = $("#DateStart").val();
    var EndDate = $("#DateEnd").val();

    var validar = 0;

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
        transacionAjax_Notificacion('Datos_Notificacion');
        $("#container_TTVC").css("display", "block");
    }

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}


//CREA La tabla notificacion
function Table_Notif() {

    var html_notif = "<table id='matriz' border='1' cellpadding='1' cellspacing='1'  style='width: 100%; text-align: center;'>" +
                     "<thead><tr><th colspan='4'>llaves</th><th colspan='7'>Consulta ZPP078</th><th colspan='5'>Consulta ZPP079</th></th><th colspan='7'>Consulta KSB1</th></tr>" +
                     "<tr><th>Ver</th><th>Centro</th><th>Puesto de Trabajo</th><th>Orden</th>" +
                     "<th>Nº de Pedido</th><th>Posicion</th><th>Nombre</th><th>Nº Personal</th><th>Nombre Personal</th><th>F. Inicio</th><th>Duración en Minutos</th>" +
                     "<th>Nº Personal</th><th>Nombre Personal</th><th>F. Inicio</th><th>Duración en Minutos</th><th>Motivo</th>" +
                     "<th>Centro De costo</th><th>Nº Orden</th><th>Nº Personal</th><th>F. Contabilidad</th><th>Ctd Registro</th><th>Cl Actual</th><th>Usuario</th></tr></thead><tbody>";
    for (itemArray in ArrayNotificacion) {
        if (ArrayNotificacion[itemArray].Orden_ID != 0) {
            html_notif += "<tr id= 'TTVC_" + ArrayNotificacion[itemArray].Orden_ID + "'><td><input type ='radio' class= 'Ver' name='detalle' onclick=\"VerDet('" + ArrayNotificacion[itemArray].Centro_ID + "','" + ArrayNotificacion[itemArray].Orden_ID + "','" + ArrayNotificacion[itemArray].Puestotrabajo_ID + "');\"></input></td><td>" + ArrayNotificacion[itemArray].DescripCentro + "</td><td>" + ArrayNotificacion[itemArray].DescripMaquina + "</td><td>" + ArrayNotificacion[itemArray].Orden_ID +
            "</td><td>" + ArrayNotificacion[itemArray].ZPP078_N_Pedido + "</td><td>" + ArrayNotificacion[itemArray].ZPP078_Posicion + "</td><td>" + ArrayNotificacion[itemArray].ZPP078_Nombre + "</td><td>" + ArrayNotificacion[itemArray].ZPP078_N_Personal + "</td><td>" + ArrayNotificacion[itemArray].ZPP078_NombrePersonal + "</td><td>" + ArrayNotificacion[itemArray].ZPP078_FechaIni + "</td><td>" + ArrayNotificacion[itemArray].ZPP078_Duracmin +
            "</td><td>" + ArrayNotificacion[itemArray].ZPP079_N_Personal + "</td><td>" + ArrayNotificacion[itemArray].ZPP079_NombrePersonal + "</td><td>" + ArrayNotificacion[itemArray].ZPP079_FechaIni + "</td><td>" + ArrayNotificacion[itemArray].ZPP079_Duracmin + "</td><td>" + ArrayNotificacion[itemArray].ZPP079_DescMotivo +
            "</td><td>" + ArrayNotificacion[itemArray].KSB1_Cccoste + "</td><td>" + ArrayNotificacion[itemArray].KSB1_OrdPartner + "</td><td>" + ArrayNotificacion[itemArray].KSB1_N_pers + "</td><td>" + ArrayNotificacion[itemArray].KSB1_FeContab + "</td><td>" + ArrayNotificacion[itemArray].KSB1_CtdReg + "</td><td>" + ArrayNotificacion[itemArray].KSB1_ClAct + "</td><td>" + ArrayNotificacion[itemArray].KSB1_Usuario + "</td></tr>";
        }
    }
    html_notif += "</tbody></table>";
    $("#container_TTVC").html("");
    $("#container_TTVC").html(html_notif);

    $(".Ver").click(function () {
    });

}

//llama ventana emergente
function VerDet(C, O, PT) {

    for (item in ArrayNotificacion) {
        if (ArrayNotificacion[item].Centro_ID == C && ArrayNotificacion[item].Orden_ID == O && ArrayNotificacion[item].Puestotrabajo_ID == PT) {
            $("#D_Orden").html(ArrayNotificacion[item].Orden_ID);
            $("#D_Centro").html(ArrayNotificacion[item].DescripCentro);
            $("#D_Maquina").html(ArrayNotificacion[item].DescripMaquina);

            $("#ZPP078_1").html(ArrayNotificacion[item].ZPP078_N_Pedido);
            $("#ZPP078_2").html(ArrayNotificacion[item].ZPP078_Posicion);
            $("#ZPP078_3").html(ArrayNotificacion[item].ZPP078_Nombre);
            $("#ZPP078_4").html(ArrayNotificacion[item].ZPP078_N_Personal);
            $("#ZPP078_5").html(ArrayNotificacion[item].ZPP078_NombrePersonal);
            $("#ZPP078_6").html(ArrayNotificacion[item].ZPP078_FechaIni);
            $("#ZPP078_7").html(ArrayNotificacion[item].ZPP078_Duracmin);

            $("#ZPP079_1").html(ArrayNotificacion[item].ZPP079_N_Personal);
            $("#ZPP079_2").html(ArrayNotificacion[item].ZPP079_NombrePersonal);
            $("#ZPP079_3").html(ArrayNotificacion[item].ZPP079_FechaIni);
            $("#ZPP079_4").html(ArrayNotificacion[item].ZPP079_Duracmin);
            $("#ZPP079_5").html(ArrayNotificacion[item].ZPP079_DescMotivo);

            $("#KSB1_1").html(ArrayNotificacion[item].KSB1_Cccoste);
            $("#KSB1_2").html(ArrayNotificacion[item].KSB1_OrdPartner);
            $("#KSB1_3").html(ArrayNotificacion[item].KSB1_N_pers);
            $("#KSB1_4").html(ArrayNotificacion[item].KSB1_FeContab);
            $("#KSB1_5").html(ArrayNotificacion[item].KSB1_CtdReg);
            $("#KSB1_6").html(ArrayNotificacion[item].KSB1_ClAct);
            $("#KSB1_7").html(ArrayNotificacion[item].KSB1_Usuario);
  
        }
    }

    $("#dialog_VerDetalle").dialog("option", "title", "Visualización de la Orden: " + O);
    $("#dialog_VerDetalle").dialog("open");

}
