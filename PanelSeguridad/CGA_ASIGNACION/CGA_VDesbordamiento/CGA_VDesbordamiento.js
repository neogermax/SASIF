/*--------------- region de variables globales --------------------*/
var ArrayVDesbordamiento = [];
var ArrayCombo = [];
var ArrayCentro = [];
var ArrayGrpMaq = [];
var ArrayMaquina = [];

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

    Gpr_maq();
    Maquina();
    Des_1();
    Des_2();
    Des_3();
    Des_4();
    Des_5();
    Des_6();
    Des_7();

    $("#ESelect").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img5").css("display", "none");
    $("#Img6").css("display", "none");
    $("#Img7").css("display", "none");
    $("#Img8").css("display", "none");
    $("#DE").css("display", "none");
    $("#SE").css("display", "none");
    $("#WE").css("display", "none");

    $("#TablaDatos").css("display", "none");
    $("#TablaConsulta_DES").css("display", "none");

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

//funcion que carga desde ddl Centro la planta
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
            $("#TablaDatos").css("display", "inline-table");
            $("#TablaConsulta_DES").css("display", "none");
            $("#DDLCentro").removeAttr("disabled");
            $("#DDLGprMaquina").removeAttr("disabled");
            $("#Btnguardar").attr("value", "Guardar");
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta_DES").css("display", "inline-table");
            $("#container_TVDesbordamiento").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta_DES").css("display", "inline-table");
            $("#container_TVDesbordamiento").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta_DES").css("display", "inline-table");
            $("#container_TVDesbordamiento").html("");
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
        transacionAjax_VDesbordamiento("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_VDesbordamiento("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        var lineal = Desbordamiento_lineal();
        if (lineal != 0) {
            $("#dialog").dialog("option", "title", "Cuidado");
            $("#Mensaje_alert").text("el desbordamiento " + lineal + " debe estar en secuencia lineal, seleccione una maquina!");
            $("#dialog").dialog("open");
            $("#DE").css("display", "none");
            $("#SE").css("display", "none");
            $("#WE").css("display", "block");
    
        }
        else {
            if ($("#Btnguardar").val() == "Guardar") {

                transacionAjax_VDesbordamiento_create("crear");
            }
            else {
                transacionAjax_VDesbordamiento_create("modificar");
            }
        }

    }
}

//revisa q el desbordamiento sea en linea no halla huecos en la seleccion
function Desbordamiento_lineal() {
    var lineal_pri;
    var lineal_Vacio = 0;

    for (var num = 7; num >= 1; num--) {
        if ($("#DDLD" + num).val() != "-1") {
            lineal_pri = num;
            break;
        }
        console.log(num);
    }

    for (var num2 = lineal_pri; num2 >= 1; num2--) {
        if ($("#DDLD" + num2).val() == "-1") {
            lineal_Vacio = num2;
            break;
        }
        console.log(num2);
    }

    return lineal_Vacio;
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_VDesbordamiento_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var centro = $("#DDLCentro").val();
    var gmaq = $("#DDLGprMaquina").val();
    var maquina = $("#DDLMaquina").val();
    var des1 = $("#DDLD1").val();
    var des2 = $("#DDLD2").val();
    var des3 = $("#DDLD3").val();

    var validar = 0;

    if (centro == "-1" || gmaq == "-1" || maquina == "-1" || des1 == "-1" || des2 == "-1" || des3 == "-1") {
        validar = 1;
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
        if (des1 == "-1") {
            $("#Img6").css("display", "inline-table");
        }
        else {
            $("#Img6").css("display", "none");
        }
        if (des2 == "-1") {
            $("#Img7").css("display", "inline-table");
        }
        else {
            $("#Img7").css("display", "none");
        }
        if (des3 == "-1") {
            $("#Img8").css("display", "inline-table");
        }
        else {
            $("#Img8").css("display", "none");
        }
    }
    else {
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
function Table_VDesbordamiento() {

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
    var html_TVDesbordamiento = "<table id='TVDesbordamiento' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Eliminar</th><th>Centro</th><th>Grupo Maquina</th><th>Maquina</th><th>Desbordamiento 1</th><th>Desbordamiento 2</th><th>Desbordamiento 3</th><th>Desbordamiento 4</th><th>Desbordamiento 5</th><th>Desbordamiento 6</th><th>Desbordamiento 7</th></tr></thead><tbody>";
    for (itemArray in ArrayVDesbordamiento) {
        if (ArrayVDesbordamiento[itemArray].Puestotrabajo_ID != 0) {
            html_TVDesbordamiento += "<tr id= 'TVDesbordamiento_" + ArrayVDesbordamiento[itemArray].Puestotrabajo_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayVDesbordamiento[itemArray].Puestotrabajo_ID + "')\"></input></td><td>" + ArrayVDesbordamiento[itemArray].Centro_ID + " " + ArrayVDesbordamiento[itemArray].Descrip_Centro + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_GRPMaquina + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Puestotrabajo + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_1 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_2 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_3 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_4 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_5 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_6 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_7 + "</td></tr>";
        }
    }
    html_TVDesbordamiento += "</tbody></table>";
    $("#container_TVDesbordamiento").html("");
    $("#container_TVDesbordamiento").html(html_TVDesbordamiento);

    $(".Eliminar").click(function () {
    });

    $("#TVDesbordamiento").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//muestra el registro a eliminar
function Eliminar(index_VDesbordamiento) {

    for (itemArray in ArrayVDesbordamiento) {
        if (index_VDesbordamiento == ArrayVDesbordamiento[itemArray].Puestotrabajo_ID) {
            editID = ArrayVDesbordamiento[itemArray].Puestotrabajo_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TVDesbordamiento = "<table id='TVDesbordamiento' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Editarr</th><th>Centro</th><th>Grupo Maquina</th><th>Maquina</th><th>Desbordamiento 1</th><th>Desbordamiento 2</th><th>Desbordamiento 3</th><th>Desbordamiento 4</th><th>Desbordamiento 5</th><th>Desbordamiento 6</th><th>Desbordamiento 7</th></tr></thead><tbody>";
    for (itemArray in ArrayVDesbordamiento) {
        if (ArrayVDesbordamiento[itemArray].Puestotrabajo_ID != 0) {
            html_TVDesbordamiento += "<tr id= 'TVDesbordamiento_" + ArrayVDesbordamiento[itemArray].Puestotrabajo_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayVDesbordamiento[itemArray].Puestotrabajo_ID + "')\"></input></td><td>" + ArrayVDesbordamiento[itemArray].Centro_ID + " " + ArrayVDesbordamiento[itemArray].Descrip_Centro + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_GRPMaquina + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Puestotrabajo + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_1 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_2 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_3 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_4 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_5 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_6 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_7 + "</td></tr>";
        }
    }
    html_TVDesbordamiento += "</tbody></table>";
    $("#container_TVDesbordamiento").html("");
    $("#container_TVDesbordamiento").html(html_TVDesbordamiento);

    $(".Editar").click(function () {
    });

    $("#TVDesbordamiento").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

var Grp_Edit;
var M_Edit;
var DDLD1;
var DDLD2;
var DDLD3;
var DDLD4;
var DDLD5;
var DDLD6;
var DDLD7;

// muestra el registro a editar
function Editar(index_VDesbordamiento) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta_DES").css("display", "none");

    for (itemArray in ArrayVDesbordamiento) {
        if (index_VDesbordamiento == ArrayVDesbordamiento[itemArray].Puestotrabajo_ID) {

            $("#DDLCentro").val(ArrayVDesbordamiento[itemArray].Centro_ID);

            $("#DDLCentro").attr("disabled", "disabled");
            $("#DDLGprMaquina").attr("disabled", "disabled");

            Grp_Edit = ArrayVDesbordamiento[itemArray].GRPMaquina_ID;
            M_Edit = ArrayVDesbordamiento[itemArray].Puestotrabajo_ID;
            editID = ArrayVDesbordamiento[itemArray].Puestotrabajo_ID;

            transacionAjax_CargaGrpMaq('cargar_droplist_GrpMaq', ArrayVDesbordamiento[itemArray].Centro_ID);
            var timer_GrpMaq = setTimeout("$('#DDLGprMaquina').val(Grp_Edit);", 2000);

            DDLD1 = ArrayVDesbordamiento[itemArray].Desboramiento_1;
            DDLD2 = ArrayVDesbordamiento[itemArray].Desboramiento_2;
            DDLD3 = ArrayVDesbordamiento[itemArray].Desboramiento_3;
            if (ArrayVDesbordamiento[itemArray].Desboramiento_4 == "")
                DDLD4 = "-1";
            else
                DDLD4 = ArrayVDesbordamiento[itemArray].Desboramiento_4;

            if (ArrayVDesbordamiento[itemArray].Desboramiento_5 == "")
                DDLD5 = "-1";
            else
                DDLD5 = ArrayVDesbordamiento[itemArray].Desboramiento_5;

            if (ArrayVDesbordamiento[itemArray].Desboramiento_6 == "")
                DDLD6 = "-1";
            else
                DDLD6 = ArrayVDesbordamiento[itemArray].Desboramiento_6;

            if (ArrayVDesbordamiento[itemArray].Desboramiento_7 == "")
                DDLD7 = "-1";
            else
                DDLD7 = ArrayVDesbordamiento[itemArray].Desboramiento_7;

            transacionAjax_Maquina('cargarMaquina', Grp_Edit, ArrayVDesbordamiento[itemArray].Centro_ID);
            var timer_Maq = setTimeout("$('#DDLMaquina').val(M_Edit);", 2000);
            var timer_DDLD1 = setTimeout("$('#DDLD1').val(DDLD1);", 2000);
            var timer_DDLD2 = setTimeout("$('#DDLD2').val(DDLD2);", 2000);
            var timer_DDLD3 = setTimeout("$('#DDLD3').val(DDLD3);", 2000);
            var timer_DDLD4 = setTimeout("$('#DDLD4').val(DDLD4);", 2000);
            var timer_DDLD5 = setTimeout("$('#DDLD5').val(DDLD5);", 2000);
            var timer_DDLD6 = setTimeout("$('#DDLD6').val(DDLD6);", 2000);
            var timer_DDLD7 = setTimeout("$('#DDLD7').val(DDLD7);", 2000);

            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TVDesbordamiento = "<table id='TVDesbordamiento' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Centro</th><th>Grupo Maquina</th><th>Maquina</th><th>Desbordamiento 1</th><th>Desbordamiento 2</th><th>Desbordamiento 3</th><th>Desbordamiento 4</th><th>Desbordamiento 5</th><th>Desbordamiento 6</th><th>Desbordamiento 7</th></tr></thead><tbody>";
    for (itemArray in ArrayVDesbordamiento) {
        if (ArrayVDesbordamiento[itemArray].Puestotrabajo_ID != 0) {
            html_TVDesbordamiento += "<tr id= 'TVDesbordamiento_" + ArrayVDesbordamiento[itemArray].Puestotrabajo_ID + "'><td>" + ArrayVDesbordamiento[itemArray].Centro_ID + " " + ArrayVDesbordamiento[itemArray].Descrip_Centro + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_GRPMaquina + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Puestotrabajo + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_1 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_2 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_3 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_4 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_5 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_6 + "</td><td>" + ArrayVDesbordamiento[itemArray].Descrip_Desboramiento_7 + "</td></tr>";
        }
    }
    html_TVDesbordamiento += "</tbody></table>";
    $("#container_TVDesbordamiento").html("");
    $("#container_TVDesbordamiento").html(html_TVDesbordamiento);

    $("#TVDesbordamiento").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}


//valida repetidos en los desbordamientos
function Des_1() {
    $("#DDLD1").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD1");
        Val_Desborde_Rep($(this), "DDLD1");
    });
}

//valida repetidos en los desbordamientos
function Des_2() {
    $("#DDLD2").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD2");
        Val_Desborde_Rep($(this), "DDLD2");
    });
}

//valida repetidos en los desbordamientos
function Des_3() {
    $("#DDLD3").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD3");
        Val_Desborde_Rep($(this), "DDLD3");
    });
}

//valida repetidos en los desbordamientos
function Des_4() {
    $("#DDLD4").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD4");
        Val_Desborde_Rep($(this), "DDLD4");
    });
}

//valida repetidos en los desbordamientos
function Des_5() {
    $("#DDLD5").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD5");
        Val_Desborde_Rep($(this), "DDLD5");
    });
}

//valida repetidos en los desbordamientos
function Des_6() {
    $("#DDLD6").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD6");
        Val_Desborde_Rep($(this), "DDLD6");
    });
}

//valida repetidos en los desbordamientos
function Des_7() {
    $("#DDLD7").change(function () {
        Val_primaria_desbordamiento($(this), "DDLD7");
        Val_Desborde_Rep($(this), "DDLD7");
    });
}

//valida repetidos en los desbordamientos
function Val_Desborde_Rep(Obj, validando) {

    var padre = $(Obj).val();
    var hijo;
    var strhijo;
    var cont = validando.substring(4, 5);

    for (var num = 1; num < 7; num++) {

        hijo = $("#DDLD" + num).val();
        strhijo = "DDLD" + num;


        if (padre == hijo && strhijo != validando) {

            $("#dialog").dialog("option", "title", "Cuidado");
            $("#Mensaje_alert").text("el desbordamiento " + cont + " ya fue ingresado!");
            $("#dialog").dialog("open");
            $("#DE").css("display", "none");
            $("#SE").css("display", "none");
            $("#WE").css("display", "block");
            $("#DDLD" + cont).val("-1");
        }
    }

}

//funcion que valda que el desbordamiento no sea igual a la maquina seleccionada
function Val_primaria_desbordamiento(Obj, validando) {

    var hijo = $(Obj).val();
    var primario = $("#DDLMaquina").val();
    var cont = validando.substring(4, 5);

    if (hijo == primario) {
        $("#dialog").dialog("option", "title", "Cuidado");
        $("#Mensaje_alert").text("el desbordamiento " + cont + " no puede ser igual a la maquina seleccionada");
        $("#dialog").dialog("open");
        $("#DE").css("display", "none");
        $("#SE").css("display", "none");
        $("#WE").css("display", "block");
        $("#DDLD" + cont).val("-1");

    }
}

//limpiar campos
function Clear() {
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
    $("#DDLCentro").val("-1");
    $("#DDLGprMaquina").val("-1");
    $("#DDLMaquina").val("-1");
    $("#DDLD1").val("-1");
    $("#DDLD2").val("-1");
    $("#DDLD3").val("-1");
    $("#DDLD4").val("-1");
    $("#DDLD5").val("-1");
    $("#DDLD6").val("-1");
    $("#DDLD7").val("-1");
}
