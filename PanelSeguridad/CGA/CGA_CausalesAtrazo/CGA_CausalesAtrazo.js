/*--------------- region de variables globales --------------------*/
var ArrayCausalesAtrazo = [];
var ArrayCombo = [];
var estado;
var editID;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    $("#ESelect").css("display", "none");
    $("#ImgID").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#DE").css("display", "none");
    $("#SE").css("display", "none");
    $("#WE").css("display", "none");

    $("#TablaDatos").css("display", "none");
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

//salida del formulario
function btnSalir() {
    window.location = "../../Menu/menu.aspx?User=" + $("#User").html();
}

//habilita el panel de crear o consulta
function HabilitarPanel(opcion) {

    switch (opcion) {

        case "crear":
            $("#TablaDatos").css("display", "inline-table");
            $("#TablaConsulta").css("display", "none");
            $("#Txt_ID").removeAttr("disabled");
            $("#Btnguardar").attr("value", "Guardar");
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCausalesAtrazo").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCausalesAtrazo").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCausalesAtrazo").html("");
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
        transacionAjax_CausalesAtrazo("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_CausalesAtrazo("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_CausalesAtrazo_create("crear");
        }
        else {
            transacionAjax_CausalesAtrazo_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_CausalesAtrazo_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var descrip = $("#TxtDescription").val();
    var Area = $("#TxtTxtArea").val();
    var Gerencia = $("#TxtGerencia").val();

    var validar = 0;

    if (Gerencia == "" || Area == "" || descrip == "" || valID == "") {
        validar = 1;
        if (valID == "") {
            $("#ImgID").css("display", "inline-table");
        }
        else {
            $("#ImgID").css("display", "none");
        }
        if (descrip == "") {
            $("#Img1").css("display", "inline-table");
        }
        else {
            $("#Img1").css("display", "none");
        }
        if (Area == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (Gerencia == "") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }

    }
    else {
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
        $("#Img3").css("display", "none");
        $("#ImgID").css("display", "none");
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
function Table_CausalesAtrazo() {

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
    var html_TCausalesAtrazo = "<table id='TCausalesAtrazo' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Causal Raiz</th><th>Area ó Proceso Responsable</th><th>Gerencia Responsable</th><th>Comentarios</th></tr></thead><tbody>";
    for (itemArray in ArrayCausalesAtrazo) {
        if (ArrayCausalesAtrazo[itemArray].Causal_ID != 0) {
            html_TCausalesAtrazo += "<tr id= 'TCausalesAtrazo_" + ArrayCausalesAtrazo[itemArray].Causal_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayCausalesAtrazo[itemArray].Causal_ID + "')\"></input></td><td>" + ArrayCausalesAtrazo[itemArray].Causal_ID + "</td><td>" + ArrayCausalesAtrazo[itemArray].CausalRaiz + "</td><td>" + ArrayCausalesAtrazo[itemArray].Area_Responsable + "</td><td>" + ArrayCausalesAtrazo[itemArray].GerenciaResponsable + "</td><td>" + ArrayCausalesAtrazo[itemArray].Comentario + "</td></tr>";
        }
    }
    html_TCausalesAtrazo += "</tbody></table>";
    $("#container_TCausalesAtrazo").html("");
    $("#container_TCausalesAtrazo").html(html_TCausalesAtrazo);

    $(".Eliminar").click(function () {
    });

    $("#TCausalesAtrazo").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//muestra el registro a eliminar
function Eliminar(index_CausalesAtrazo) {

    for (itemArray in ArrayCausalesAtrazo) {
        if (index_CausalesAtrazo == ArrayCausalesAtrazo[itemArray].Causal_ID) {
            editID = ArrayCausalesAtrazo[itemArray].Causal_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TCausalesAtrazo = "<table id='TCausalesAtrazo' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Editarr</th><th>Codigo</th><th>Causal Raiz</th><th>Area ó Proceso Responsable</th><th>Gerencia Responsable</th><th>Comentarios</th></tr></thead><tbody>";
    for (itemArray in ArrayCausalesAtrazo) {
        if (ArrayCausalesAtrazo[itemArray].Causal_ID != 0) {
            html_TCausalesAtrazo += "<tr id= 'TCausalesAtrazo_" + ArrayCausalesAtrazo[itemArray].Causal_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayCausalesAtrazo[itemArray].Causal_ID + "')\"></input></td><td>" + ArrayCausalesAtrazo[itemArray].Causal_ID + "</td><td>" + ArrayCausalesAtrazo[itemArray].CausalRaiz + "</td><td>" + ArrayCausalesAtrazo[itemArray].Area_Responsable + "</td><td>" + ArrayCausalesAtrazo[itemArray].GerenciaResponsable + "</td><td>" + ArrayCausalesAtrazo[itemArray].Comentario + "</td></tr>";
        }
    }
    html_TCausalesAtrazo += "</tbody></table>";
    $("#container_TCausalesAtrazo").html("");
    $("#container_TCausalesAtrazo").html(html_TCausalesAtrazo);

    $(".Editar").click(function () {
    });

    $("#TCausalesAtrazo").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

// muestra el registro a editar
function Editar(index_CausalesAtrazo) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayCausalesAtrazo) {
        if (index_CausalesAtrazo == ArrayCausalesAtrazo[itemArray].Causal_ID) {
            $("#Txt_ID").val(ArrayCausalesAtrazo[itemArray].Causal_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayCausalesAtrazo[itemArray].CausalRaiz);
            $("#TxtArea").val(ArrayCausalesAtrazo[itemArray].Area_Responsable);
            $("#TxtGerencia").val(ArrayCausalesAtrazo[itemArray].GerenciaResponsable);
            $("#TxtComentario").val(ArrayCausalesAtrazo[itemArray].Comentario);
    
            editID = ArrayCausalesAtrazo[itemArray].Causal_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TCausalesAtrazo = "<table id='TCausalesAtrazo' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Codigo</th><th>Causal Raiz</th><th>Area ó Proceso Responsable</th><th>Gerencia Responsable</th><th>Comentarios</th></tr></thead><tbody>";
    for (itemArray in ArrayCausalesAtrazo) {
        if (ArrayCausalesAtrazo[itemArray].Causal_ID != 0) {
            html_TCausalesAtrazo += "<tr id= 'TCausalesAtrazo_" + ArrayCausalesAtrazo[itemArray].Causal_ID + "'><td>" + ArrayCausalesAtrazo[itemArray].Causal_ID + "</td><td>" + ArrayCausalesAtrazo[itemArray].CausalRaiz + "</td><td>" + ArrayCausalesAtrazo[itemArray].Area_Responsable + "</td><td>" + ArrayCausalesAtrazo[itemArray].GerenciaResponsable + "</td><td>" + ArrayCausalesAtrazo[itemArray].Comentario + "</td></tr>";
        }
    }
    html_TCausalesAtrazo += "</tbody></table>";
    $("#container_TCausalesAtrazo").html("");
    $("#container_TCausalesAtrazo").html(html_TCausalesAtrazo);

    $("#TCausalesAtrazo").dataTable({
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
    $("#Txt_ID").val("");
    $("#TxtDescription").val("");
    $("#TxtArea").val("");
    $("#TxtGerencia").val("");
    $("#TxtComentario").val("");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}