/*--------------- region de variables globales --------------------*/
var ArrayCargaPasiva = [];
var ArrayCombo = [];
var ArrayCentro = [];
var ArrayGrpMaq = [];
var ArrayMaquina = [];
var ArrayDepto = [];

var estado;
var editID;
var Centro_ID;
var GprMaquina_ID;

/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    carga_eventos("Dialog_Charge");
    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    transacionAjax_CargaCentro('cargar_droplist_Centro');
    transacionAjax_CargaDepto('cargar_droplist_Depto');
    
    Gpr_maq();
    Maquina();

    $("#ESelect").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img5").css("display", "none");
    $("#Img6").css("display", "none");
    $("#Img7").css("display", "none");
    $("#Img8").css("display", "none");
    $("#DE").css("display", "none");
    $("#SE").css("display", "none");
    $("#WE").css("display", "none");

    $("#TablaDatos_CP").css("display", "none");
    $("#TablaConsulta").css("display", "none");

    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });

    $("#dialog_eliminar").dialog({
        autoOpen: false
    });

    $('.solo-numero').keyup(function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    });

});

//fucion que carga desde ddl Centro la planta
function Gpr_maq() {
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

//fucion que carga desde ddl Centro la planta
function loadChildrenCentro(obj) {
    $("#DDLGprMaquina").empty();
    Centro_ID = $(obj).val();
    transacionAjax_CargaGrpMaq('cargar_droplist_GrpMaq', Centro_ID);
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

//fucion que carga desde ddl gprMaquina carga la maquina
function loadChildrenMaquina(obj) {
    $("#DDLMaquina").empty();
    GprMaquina_ID = $(obj).val();
    transacionAjax_Maquina('cargarMaquina', GprMaquina_ID, Centro_ID);
}

//salida del formulario
function btnSalir() {
    window.location = "../../Menu/menu.aspx?User=" + $("#User").html();
}

//habilita el panel de crear o consulta
function HabilitarPanel(opcion) {

    switch (opcion) {

        case "crear":
            $("#TablaDatos_CP").css("display", "inline-table");
            $("#TablaConsulta").css("display", "none");
            $("#DDLSolicitud").removeAttr("disabled");
            $("#DDLCentro").removeAttr("disabled");
            $("#DDLGprMaquina").removeAttr("disabled");
            $("#Btnguardar").attr("value", "Guardar");
       
            
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos_CP").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCargaPasiva").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos_CP").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCargaPasiva").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos_CP").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCargaPasiva").html("");
            estado = opcion;
            Clear();
            break;

    }
}

//consulta del del crud(READ)
function BtnConsulta() {

    var filtro;
    var ValidateSelect = ValidarDroplist();
    var opcion;

    if (ValidateSelect == 1) {
        filtro = "N";
        opcion = "ALL";
        transacionAjax_CargaPasiva("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_CargaPasiva("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_CargaPasiva_create("crear");
        }
        else {
            transacionAjax_CargaPasiva_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_CargaPasiva_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var solicitud = $("#DDLSolicitud").val();
    var centro = $("#DDLCentro").val();
    var gmaq = $("#DDLGprMaquina").val();
    var maquina = $("#DDLMaquina").val();
    var horasp = $("#TxtHorasPlan").val();
    var oferta = $("#TxtNOfertas").val();
    var orden = $("#TxtOrden").val();

    var validar = 0;

    if (solicitud == "-1" || centro == "-1" || gmaq == "-1" || maquina == "-1" || horasp == "" || oferta == "" || orden == "") {
        validar = 1;
        if (solicitud == "-1") {
            $("#Img1").css("display", "inline-table");
        }
        else {
            $("#Img1").css("display", "none");
        }
        if (centro == "-1") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (gmaq == "-1") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }
        if (maquina == "-1") {
            $("#Img5").css("display", "inline-table");
        }
        else {
            $("#Img5").css("display", "none");
        }
        if (horasp == "") {
            $("#Img6").css("display", "inline-table");
        }
        else {
            $("#Img6").css("display", "none");
        }
        if (oferta == "") {
            $("#Img7").css("display", "inline-table");
        }
        else {
            $("#Img7").css("display", "none");
        }
        if (orden == "") {
            $("#Img8").css("display", "inline-table");
        }
        else {
            $("#Img8").css("display", "none");
        }
    }
    else {
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
        $("#Img3").css("display", "none");
        $("#Img5").css("display", "none");
        $("#Img6").css("display", "none");
        $("#Img7").css("display", "none");
        $("#Img8").css("display", "none");
    }
    return validar;
}

//validamos si han escogido una columna
function ValidarDroplist() {
    var flag;
    var contenido = $("#DDLColumns").val();

    if (contenido == '-1') {
        flag = 1;
    }
    else {
        flag = 0;
    }
    return flag;
}

// crea la tabla en el cliente
function Table_CargaPasiva() {

    switch (estado) {

        case "buscar":
            Tabla_consulta();
            break;

        case "modificar":
            Tabla_modificar();
            break;

        case "eliminar":
            Tabla_eliminar();
            break;
    }

}

//grid con el boton eliminar
function Tabla_eliminar() {
    var html_TCargaPasiva = "<table id='TCargaPasiva' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Eliminar</th><th>Departamento</th><th>Centro</th><th>Grupo Maquina</th><th>Maquina</th><th>Nº Horas Plan</th><th>Nº de Ofertas</th><th>Orden</th></tr></thead><tbody>";
    for (itemArray in ArrayCargaPasiva) {
        if (ArrayCargaPasiva[itemArray].CP_ID != 0) {
            html_TCargaPasiva += "<tr id= 'TCargaPasiva_" + ArrayCargaPasiva[itemArray].CP_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayCargaPasiva[itemArray].CP_ID + "')\"></input></td><td>" + ArrayCargaPasiva[itemArray].Descrip_Departamento + "</td><td>" + ArrayCargaPasiva[itemArray].Centro_ID + " " + ArrayCargaPasiva[itemArray].Descrip_Centro + "</td><td>" + ArrayCargaPasiva[itemArray].Descrip_GRPMaquina + "</td><td>" + ArrayCargaPasiva[itemArray].Descrip_Puestotrabajo + "</td><td>" + ArrayCargaPasiva[itemArray].HPlan + "</td><td>" + ArrayCargaPasiva[itemArray].N_Oferta + "</td><td>" + ArrayCargaPasiva[itemArray].Orden_ID + "</td></tr>";
        }
    }
    html_TCargaPasiva += "</tbody></table>";
    $("#container_TCargaPasiva").html("");
    $("#container_TCargaPasiva").html(html_TCargaPasiva);

    $(".Eliminar").click(function () {
    });

    $("#TCargaPasiva").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//muestra el registro a eliminar
function Eliminar(index_CargaPasiva) {

    for (itemArray in ArrayCargaPasiva) {
        if (index_CargaPasiva == ArrayCargaPasiva[itemArray].CP_ID) {
            editID = ArrayCargaPasiva[itemArray].CP_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TCargaPasiva = "<table id='TCargaPasiva' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Editarr</th><th>Departamento</th><th>Centro</th><th>Grupo Maquina</th><th>Maquina</th><th>Nº Horas Plan</th><th>Nº de Ofertas</th><th>Orden</th></tr></thead><tbody>";
    for (itemArray in ArrayCargaPasiva) {
        if (ArrayCargaPasiva[itemArray].CP_ID != 0) {
            html_TCargaPasiva += "<tr id= 'TCargaPasiva_" + ArrayCargaPasiva[itemArray].CP_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayCargaPasiva[itemArray].CP_ID + "')\"></input></td><td>" + ArrayCargaPasiva[itemArray].Descrip_Departamento + "</td><td>" + ArrayCargaPasiva[itemArray].Centro_ID + " " + ArrayCargaPasiva[itemArray].Descrip_Centro + "</td><td>" + ArrayCargaPasiva[itemArray].Descrip_GRPMaquina + "</td><td>" + ArrayCargaPasiva[itemArray].Descrip_Puestotrabajo + "</td><td>" + ArrayCargaPasiva[itemArray].HPlan + "</td><td>" + ArrayCargaPasiva[itemArray].N_Oferta + "</td><td>" + ArrayCargaPasiva[itemArray].Orden_ID + "</td></tr>";
        }
    }
    html_TCargaPasiva += "</tbody></table>";
    $("#container_TCargaPasiva").html("");
    $("#container_TCargaPasiva").html(html_TCargaPasiva);

    $(".Editar").click(function () {
    });

    $("#TCargaPasiva").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

var Grp_Edit;
var M_Edit;


// muestra el registro a editar
function Editar(index_CargaPasiva) {

    $("#TablaDatos_CP").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");
    
    for (itemArray in ArrayCargaPasiva) {
        if (index_CargaPasiva == ArrayCargaPasiva[itemArray].CP_ID) {

            $("#DDLSolicitud").val(ArrayCargaPasiva[itemArray].Departamento);
            $("#DDLCentro").val(ArrayCargaPasiva[itemArray].Centro_ID);

            $("#DDLSolicitud").attr("disabled", "disabled");
            $("#DDLCentro").attr("disabled", "disabled");
            $("#DDLGprMaquina").attr("disabled", "disabled");
           
            Grp_Edit = ArrayCargaPasiva[itemArray].GRPMaquina_ID;
            M_Edit = ArrayCargaPasiva[itemArray].Puestotrabajo_ID;
            
            transacionAjax_CargaGrpMaq('cargar_droplist_GrpMaq', ArrayCargaPasiva[itemArray].Centro_ID);
            var timer_GrpMaq = setTimeout("$('#DDLGprMaquina').val(Grp_Edit);", 2000);

            transacionAjax_Maquina('cargarMaquina', Grp_Edit, ArrayCargaPasiva[itemArray].Centro_ID);
            var timer_Maq = setTimeout("$('#DDLMaquina').val(M_Edit);", 2000);
                        
            $("#TxtHorasPlan").val(ArrayCargaPasiva[itemArray].HPlan);
            $("#TxtNOfertas").val(ArrayCargaPasiva[itemArray].N_Oferta);
            $("#TxtOrden").val(ArrayCargaPasiva[itemArray].Orden_ID);
           
            editID = ArrayCargaPasiva[itemArray].CP_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TCargaPasiva = "<table id='TCargaPasiva' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Departamento</th><th>Centro</th><th>Grupo Maquina</th><th>Maquina</th><th>Nº Horas Plan</th><th>Nº de Ofertas</th><th>Orden</th></tr></thead><tbody>";
    for (itemArray in ArrayCargaPasiva) {
        if (ArrayCargaPasiva[itemArray].CP_ID != 0) {
            html_TCargaPasiva += "<tr id= 'TCargaPasiva_" + ArrayCargaPasiva[itemArray].CP_ID + "'><td>" + ArrayCargaPasiva[itemArray].Descrip_Departamento + "</td><td>" + ArrayCargaPasiva[itemArray].Centro_ID + " " + ArrayCargaPasiva[itemArray].Descrip_Centro + "</td><td>" + ArrayCargaPasiva[itemArray].Descrip_GRPMaquina + "</td><td>" + ArrayCargaPasiva[itemArray].Descrip_Puestotrabajo + "</td><td>" + ArrayCargaPasiva[itemArray].HPlan + "</td><td>" + ArrayCargaPasiva[itemArray].N_Oferta + "</td><td>" + ArrayCargaPasiva[itemArray].Orden_ID + "</td></tr>";
        }
    }
    html_TCargaPasiva += "</tbody></table>";
    $("#container_TCargaPasiva").html("");
    $("#container_TCargaPasiva").html(html_TCargaPasiva);

    $("#TCargaPasiva").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
    $("#DDLSolicitud").val("-1");
    $("#DDLCentro").val("-1");
    $("#DDLGprMaquina").val("-1");
    $("#DDLMaquina").val("-1");
    $("#TxtHorasPlan").val("");
    $("#TxtNOfertas").val("");
    $("#TxtOrden").val("");
}