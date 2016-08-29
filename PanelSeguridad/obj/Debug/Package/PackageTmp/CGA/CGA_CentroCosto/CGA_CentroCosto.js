/*--------------- region de variables globales --------------------*/
var ArrayCCostos = [];
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
            $("#container_TCentroCosto").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCentroCosto").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCentroCosto").html("");
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
        transacionAjax_CentroCosto("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_CentroCosto("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_CentroCosto_create("crear");
        }
        else {
            transacionAjax_CentroCosto_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_CentroCosto_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var descrip = $("#TxtDescription").val();

    var validar = 0;

    if (descrip == "" || valID == "") {
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
    }
    else {
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
function Table_CentroCosto() {

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
    var html_TCCostos = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayCCostos) {
        if (ArrayCCostos[itemArray].CentroCosto_ID != 0) {
            html_TCCostos += "<tr id= 'TCCosto_" + ArrayCCostos[itemArray].CentroCosto_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayCCostos[itemArray].CentroCosto_ID + "')\"></input></td><td>" + ArrayCCostos[itemArray].CentroCosto_ID + "</td><td>" + ArrayCCostos[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TCCostos += "</tbody></table>";
    $("#container_TCentroCosto").html("");
    $("#container_TCentroCosto").html(html_TCCostos);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_CentroCosto) {

    for (itemArray in ArrayCCostos) {
        if (index_CentroCosto == ArrayCCostos[itemArray].CentroCosto_ID) {
            editID = ArrayCCostos[itemArray].CentroCosto_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TCCostos = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editarr</th><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayCCostos) {
        if (ArrayCCostos[itemArray].CentroCosto_ID != 0) {
            html_TCCostos += "<tr id= 'TCCosto_" + ArrayCCostos[itemArray].CentroCosto_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayCCostos[itemArray].CentroCosto_ID + "')\"></input></td><td>" + ArrayCCostos[itemArray].CentroCosto_ID + "</td><td>" + ArrayCCostos[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TCCostos += "</tbody></table>";
    $("#container_TCentroCosto").html("");
    $("#container_TCentroCosto").html(html_TCCostos);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_CentroCosto) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayCCostos) {
        if (index_CentroCosto == ArrayCCostos[itemArray].CentroCosto_ID) {
            $("#Txt_ID").val(ArrayCCostos[itemArray].CentroCosto_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayCCostos[itemArray].Descripcion);
            editID = ArrayCCostos[itemArray].CentroCosto_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TCCostos = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayCCostos) {
        if (ArrayCCostos[itemArray].CentroCosto_ID != 0) {
            html_TCCostos += "<tr id= 'TCCosto_" + ArrayCCostos[itemArray].CentroCosto_ID + "'><td>" + ArrayCCostos[itemArray].CentroCosto_ID + "</td><td>" + ArrayCCostos[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TCCostos += "</tbody></table>";
    $("#container_TCentroCosto").html("");
    $("#container_TCentroCosto").html(html_TCCostos);

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