/*--------------- region de variables globales --------------------*/
var ArrayLMaterial = [];
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
            $("#container_TLMaterial").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TLMaterial").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TLMaterial").html("");
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
        transacionAjax_LMaterial("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_LMaterial("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_LMaterial_create("crear");
        }
        else {
            transacionAjax_LMaterial_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_LMaterial_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var descrip = $("#TxtDescription").val();
    var Planta = $("#TxtPlanta").val();

    var validar = 0;

    if (Planta == "" || descrip == "" || valID == "") {
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
        if (Planta == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }

    }
    else {
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
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
function Table_LMaterial() {

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
    var html_TLMaterial = "<table id='TLMaterial' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayLMaterial) {
        if (ArrayLMaterial[itemArray].LMaterial_ID != 0) {
            html_TLMaterial += "<tr id= 'TLMaterial_" + ArrayLMaterial[itemArray].LMaterial_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayLMaterial[itemArray].LMaterial_ID + "')\"></input></td><td>" + ArrayLMaterial[itemArray].LMaterial_ID + "</td><td>" + ArrayLMaterial[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TLMaterial += "</tbody></table>";
    $("#container_TLMaterial").html("");
    $("#container_TLMaterial").html(html_TLMaterial);

    $(".Eliminar").click(function () {
    });

    $("#TLMaterial").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//muestra el registro a eliminar
function Eliminar(index_LMaterial) {

    for (itemArray in ArrayLMaterial) {
        if (index_LMaterial == ArrayLMaterial[itemArray].LMaterial_ID) {
            editID = ArrayLMaterial[itemArray].LMaterial_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TLMaterial = "<table id='TLMaterial' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Editarr</th><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayLMaterial) {
        if (ArrayLMaterial[itemArray].LMaterial_ID != 0) {
            html_TLMaterial += "<tr id= 'TLMaterial_" + ArrayLMaterial[itemArray].LMaterial_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayLMaterial[itemArray].LMaterial_ID + "')\"></input></td><td>" + ArrayLMaterial[itemArray].LMaterial_ID + "</td><td>" + ArrayLMaterial[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TLMaterial += "</tbody></table>";
    $("#container_TLMaterial").html("");
    $("#container_TLMaterial").html(html_TLMaterial);

    $(".Editar").click(function () {
    });

    $("#TLMaterial").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

// muestra el registro a editar
function Editar(index_LMaterial) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayLMaterial) {
        if (index_LMaterial == ArrayLMaterial[itemArray].LMaterial_ID) {
            $("#Txt_ID").val(ArrayLMaterial[itemArray].LMaterial_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayLMaterial[itemArray].Descripcion);
            editID = ArrayLMaterial[itemArray].LMaterial_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TLMaterial = "<table id='TLMaterial' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayLMaterial) {
        if (ArrayLMaterial[itemArray].LMaterial_ID != 0) {
            html_TLMaterial += "<tr id= 'TLMaterial_" + ArrayLMaterial[itemArray].LMaterial_ID + "'><td>" + ArrayLMaterial[itemArray].LMaterial_ID + "</td><td>" + ArrayLMaterial[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TLMaterial += "</tbody></table>";
    $("#container_TLMaterial").html("");
    $("#container_TLMaterial").html(html_TLMaterial);

    $("#TLMaterial").dataTable({
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
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}