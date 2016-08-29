/*--------------- region de variables globales --------------------*/
var ArrayTVCDET = [];
var ArrayTVCDET_Grid = [];
var ArrayOpeDet = [];
var ArrayCausal = [];
var ArrayTurno = [];
var ArrayAccion = [];
var ArrayArea = [];

var VG_FECHA_CRE;
var estado;
var FechaAct;
var ID_Orden;
var Variables;
var Orden;
var Opera;
var Maq;
var Centro;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {

    var URLPage = window.location.search.substring(1);
    Variables = URLPage.split('&');
    Orden = Variables[1].replace("Orden=", "");
    Opera = Variables[2].replace("Opera=", "");
    Maq = Variables[3].replace("Maq=", "");
    Centro = Variables[4].replace("C=", "");

    transacionAjax_COperarioDet('COperario_Det');
    transacionAjax_CCausal('Ccausal', '1');
    transacionAjax_CCausal('Ccausal', '2');
    transacionAjax_CTurno('CTurno');
    transacionAjax_CAccion('CAccion');
    transacionAjax_CArea('CArea');

    transacionAjax_TVCEncabezadoDet('EncabezadoDet');
    transacionAjax_TVCGridDet('GridDet');

    $("#ESelect").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img5").css("display", "none");
    $("#Img6").css("display", "none");
    $("#DE").css("display", "none");
    $("#SE").css("display", "none");
    $("#WE").css("display", "none");
    $("#P_Estado").css("display", "none");
    $("#D_Estado").css("display", "none");


    $("#Title_form").html("DETALLE DE LA ORDEN: " + Orden);

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });

    //funcion para las ventanas emergentes
    $("#dialog_eliminar").dialog({
        autoOpen: false
    });

    //funcion para las ventanas emergentes
    $("#dialog_NewCausal").dialog({
        autoOpen: false,
        dialogClass: "Dialog_personal",
        modal: true,
        width: 500,
        height: 530,
        overlay: {
            opacity: 0.5,
            background: "black"
        },
        open: function (event, ui) { $(".ui-dialog-titlebar-close", ui.dialog).show(); }
    });

    //funcion para campos numericos
    $('.solo-numero').keyup(function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    });

    //funcion para agregar el calendario
    $(function () {
        $("#DateAccion").datepicker();
    });
});

//salida del formulario
function btnSalir() {
    window.location = "../../Menu/menu.aspx?User=" + $("#User").html();
}

function BtnRetry() {
    window.location = "../../CGA_TVC/Operacional/CGA_TVC_Op.aspx?User=" + $("#User").html() + "&LINK=TVCOPERA"; 
}

//crea la tabla de detalles
function Table_TVCDet() {

    var html_TTVC = "<table id='TTVCDET' border='1' cellpadding='1' cellspacing='1'  style='width: 100%; text-align: center;'><thead><tr><th>Ver</th><th>Operario</th><th>Causal</th><th>Observación</th><th>Descripción</th><th>Acción</th><th>F. Entrega</th><th>Area Responsable</th><th>Estado Causal</th></tr></thead><tbody>";
    for (itemArray in ArrayTVCDET_Grid) {
        if (ArrayTVCDET_Grid[itemArray].Operario_ID != 0) {
            html_TTVC += "<tr id= 'TTVC_" + ArrayTVCDET_Grid[itemArray].Operario_ID + "'><td><input type ='radio' class= 'Mod' name='actualizar' onclick=\"Actualizar('" + ArrayTVCDET_Grid[itemArray].Fec_Creacion + "')\"></input></td><td>" + ArrayTVCDET_Grid[itemArray].DESOperario + "</td><td>" + ArrayTVCDET_Grid[itemArray].DESCausal + "</td><td>" + ArrayTVCDET_Grid[itemArray].Observacion_Ope + "</td><td>" + ArrayTVCDET_Grid[itemArray].Descripcion_Analis + "</td><td>" + ArrayTVCDET_Grid[itemArray].DESAccion + "</td><td>" + ArrayTVCDET_Grid[itemArray].Fec_Ent_Accion + "</td><td>" + ArrayTVCDET_Grid[itemArray].DESArea + "</td><td>" + ArrayTVCDET_Grid[itemArray].Estado + "</td></tr>";
        }
    }
    html_TTVC += "</tbody></table>";
    $("#container_TTVCDET").html("");
    $("#container_TTVCDET").html(html_TTVC);

    $(".Mod").click(function () {
    });

    $("#TTVCDET").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });

}

//llama la ventana emergente para la modificion de la causal
function Actualizar(fechaCreacion) {
    $("#P_Estado").css("display", "table-cell");
    $("#P_Estado").css("display", "-webkit-inline-box");
    $("#D_Estado").css("display", "table-cell");

    $("#DDLOperario").attr("disabled", "disabled");
    $("#DDLTurno").attr("disabled", "disabled");
    $("#DDLCausalSAP").attr("disabled", "disabled");
    $("#DDLCausal").attr("disabled", "disabled");
    $("#TxtObserOpe").attr("disabled", "disabled");
    $("#BtnSave").attr("value", "Actualizar");

    for (item in ArrayTVCDET_Grid) {

        if (ArrayTVCDET_Grid[item].Fec_Creacion === fechaCreacion) {
            VG_FECHA_CRE = ArrayTVCDET_Grid[item].Fec_Creacion;
            $("#DDLOperario").val(ArrayTVCDET_Grid[item].Operario_ID);
            $("#DDLTurno").val(ArrayTVCDET_Grid[item].Turno_ID);
            $("#DDLCausalSAP").val(ArrayTVCDET_Grid[item].CausalSAP_ID);
            $("#DDLCausal").val(ArrayTVCDET_Grid[item].Causal_ID);
            $("#TxtObserOpe").val(ArrayTVCDET_Grid[item].Observacion_Ope);
            $("#TxtDescripAnalis").val(ArrayTVCDET_Grid[item].Descripcion_Analis);
            $("#DateAccion").val(ArrayTVCDET_Grid[item].Fec_Ent_Accion);
            $("#DDLEstado").val(ArrayTVCDET_Grid[item].Estado_ID);

            if (ArrayTVCDET_Grid[item].Accion_ID == 0) {
                $("#DDLAccion").val("-1");
            }
            else {
                $("#DDLAccion").val(ArrayTVCDET_Grid[item].Accion_ID);
            }
            
            if (ArrayTVCDET_Grid[item].Area_ID == 0) {
                $("#DDLArea").val("-1");
            }
            else {
                $("#DDLArea").val(ArrayTVCDET_Grid[item].Area_ID);
            }
        }
    }

    $("#dialog_NewCausal").dialog("option", "title", "Actualizar Causal");
    $("#dialog_NewCausal").dialog("open");

}

//llama ventana emergente para nueva causal
function BtnNewCausal() {
    clear();
    $("#DDLOperario").removeAttr("disabled");
    $("#DDLTurno").removeAttr("disabled");
    $("#DDLCausalSAP").removeAttr("disabled");
    $("#DDLCausal").removeAttr("disabled");
    $("#TxtObserOpe").removeAttr("disabled");
    $("#BtnSave").attr("value", "Guardar");

    $("#P_Estado").css("display", "none");
    $("#D_Estado").css("display", "none");

    $("#dialog_NewCausal").dialog("option", "title", "Nueva Causal");
    $("#dialog_NewCausal").dialog("open");
}

//limpia los campos de causal
function clear() {

    $("#DDLOperario").val("-1");
    $("#DDLTurno").val("-1");
    $("#DDLCausalSAP").val("-1");
    $("#DDLCausal").val("-1");
    $("#TxtObserOpe").val("");
    $("#TxtDescripAnalis").val("");
    $("#DateAccion").val("");
    $("#DDLAccion").val("-1");
    $("#DDLArea").val("-1");
}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#BtnSave").val() == "Guardar") {
            estado = "crear";
            transacionAjax_NuevaCausal("crear");
        }
        else {
            estado = "modificar";
            transacionAjax_NuevaCausal("modificar");
        }
    }
}

//validamos campos para la creacion del link
function validarCamposCrear() {

    var operario = $("#DDLOperario").val();
    var turno = $("#DDLTurno").val();
    var causalsap = $("#DDLCausalSAP").val();
    var causal = $("#DDLCausal").val();
    var obser_ope = $("#TxtObserOpe").val();

    var validar = 0;

    if (operario == "-1" || turno == "-1" || causalsap == "-1" || causal == "-1" || obser_ope == "") {
        validar = 1;
        if (operario == "-1") {
            $("#Img1").css("display", "inline-table");
        }
        else {
            $("#Img1").css("display", "none");
        }
        if (turno == "-1") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (causalsap == "-1") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }
        if (causal == "-1") {
            $("#Img5").css("display", "inline-table");
        }
        else {
            $("#Img5").css("display", "none");
        }
        if (obser_ope == "") {
            $("#Img6").css("display", "inline-table");
        }
        else {
            $("#Img6").css("display", "none");
        }
    }
    else {
        $("#Img6").css("display", "none");
        $("#Img5").css("display", "none");
        $("#Img3").css("display", "none");
        $("#Img2").css("display", "none");
        $("#Img1").css("display", "none");
    }
    return validar;
}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
    $("#dialog_NewCausal").dialog("close");
}
