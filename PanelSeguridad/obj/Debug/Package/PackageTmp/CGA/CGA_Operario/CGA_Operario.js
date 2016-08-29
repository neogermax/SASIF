/*--------------- region de variables globales --------------------*/
var ArrayOperario = [];
var ArrayComboCentro = [];
var ArrayComboCCosto = [];
var ArrayComboArea = [];

var ArrayCombo = [];
var estado;
var editID;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    transacionAjax_CargaCentro('Carga_Centro');
    transacionAjax_CargaCCosto('Centro_Costo');
    transacionAjax_CargaArea('Carga_Area');
   
    $("#ESelect").css("display", "none");
    $("#ImgID").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img5").css("display", "none");
    $("#Img6").css("display", "none");
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
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TOperario").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TOperario").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TOperario").html("");
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
        transacionAjax_Operario("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_Operario("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_Operario_create("crear");
        }
        else {
            transacionAjax_Operario_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_Operario_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var document = $("#TxtDocument").val();
    var nombre = $("#TxtNombre").val();
    var centro = $("#DDLCentro").val();
    var ccosto = $("#DDLCCosto").val();
    var area = $("#DDLArea").val();
    var validar = 0;

    if (area == "-1" || ccosto == "-1" || centro == "-1" || nombre == "" || document == "" || valID == "") {
        validar = 1;
        if (valID == "") {
            $("#ImgID").css("display", "inline-table");
        }
        else {
            $("#ImgID").css("display", "none");
        }
        if (document == "") {
            $("#Img1").css("display", "inline-table");
        }
        else {
            $("#Img1").css("display", "none");
        }
        if (nombre == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (centro == "-1") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }
        if (ccosto == "-1") {
            $("#Img5").css("display", "inline-table");
        }
        else {
            $("#Img5").css("display", "none");
        }
        if (area == "-1") {
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
function Table_Operario() {

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
    var html_Operario = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo Operario</th><th>Identificación</th><th>Nombre</th><th>Centro</th><th>Centro de costo</th><th>Area</th></tr></thead><tbody>";
    for (itemArray in ArrayOperario) {
        if (ArrayOperario[itemArray].Operario_ID != 0) {
            html_Operario += "<tr id= 'TOperario_" + ArrayOperario[itemArray].Operario_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayOperario[itemArray].Operario_ID + "')\"></input></td><td>" + ArrayOperario[itemArray].Operario_ID + "</td><td>" + ArrayOperario[itemArray].Identificacion + "</td><td>" + ArrayOperario[itemArray].Nombre + "</td><td>" + ArrayOperario[itemArray].DesCentro + "</td><td>" + ArrayOperario[itemArray].DesCCostos + "</td><td>" + ArrayOperario[itemArray].DesArea + "</td></tr>";
        }
    }
    html_Operario += "</tbody></table>";
    $("#container_TOperario").html("");
    $("#container_TOperario").html(html_Operario);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_Operario) {

    for (itemArray in ArrayOperario) {
        if (index_Operario == ArrayOperario[itemArray].Operario_ID) {
            editID = ArrayOperario[itemArray].Operario_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_Operario = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editar</th><th>Codigo Operario</th><th>Identificación</th><th>Nombre</th><th>Centro</th><th>Centro de costo</th><th>Area</th></tr></thead><tbody>";
    for (itemArray in ArrayOperario) {
        if (ArrayOperario[itemArray].Operario_ID != 0) {
            html_Operario += "<tr id= 'TOperario_" + ArrayOperario[itemArray].Operario_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayOperario[itemArray].Operario_ID + "')\"></input></td><td>" + ArrayOperario[itemArray].Operario_ID + "</td><td>" + ArrayOperario[itemArray].Identificacion + "</td><td>" + ArrayOperario[itemArray].Nombre + "</td><td>" + ArrayOperario[itemArray].DesCentro + "</td><td>" + ArrayOperario[itemArray].DesCCostos + "</td><td>" + ArrayOperario[itemArray].DesArea + "</td></tr>";
        }
    }
    html_Operario += "</tbody></table>";
    $("#container_TOperario").html("");
    $("#container_TOperario").html(html_Operario);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_Operario) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayOperario) {
        if (index_Operario == ArrayOperario[itemArray].Operario_ID) {
            $("#Txt_ID").val(ArrayOperario[itemArray].Operario_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDocument").val(ArrayOperario[itemArray].Identificacion);
            $("#TxtNombre").val(ArrayOperario[itemArray].Nombre);
            $("#DDLCentro").val(ArrayOperario[itemArray].Centro_ID);
            $("#DDLCCosto").val(ArrayOperario[itemArray].CentroCosto_ID);
            $("#DDLArea").val(ArrayOperario[itemArray].Area_ID);
            editID = ArrayOperario[itemArray].Operario_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_Operario = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo Operario</th><th>Identificación</th><th>Nombre</th><th>Centro</th><th>Centro de costo</th><th>Area</th></tr></thead><tbody>";
    for (itemArray in ArrayOperario) {
        if (ArrayOperario[itemArray].Operario_ID != 0) {
            html_Operario += "<tr id= 'TOperario_" + ArrayOperario[itemArray].Operario_ID + "'><td>" + ArrayOperario[itemArray].Operario_ID + "</td><td>" + ArrayOperario[itemArray].Identificacion + "</td><td>" + ArrayOperario[itemArray].Nombre + "</td><td>" + ArrayOperario[itemArray].DesCentro + "</td><td>" + ArrayOperario[itemArray].DesCCostos + "</td><td>" + ArrayOperario[itemArray].DesArea + "</td></tr>";
        }
    }
    html_Operario += "</tbody></table>";
    $("#container_TOperario").html("");
    $("#container_TOperario").html(html_Operario);

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtDocument").val();
    $("#TxtNombre").val();
    $("#DDLCentro").val("-1");
    $("#DDLCCosto").val("-1");
    $("#DDLArea").val("-1");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}