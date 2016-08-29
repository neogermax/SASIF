/*--------------- region de variables globales --------------------*/
var ArrayCentro = [];
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
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCentro").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCentro").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TCentro").html("");
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
        transacionAjax_Centro("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_Centro("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_Centro_create("crear");
        }
        else {
            transacionAjax_Centro_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_Centro_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var descrip = $("#TxtDescription").val();
    var Planta = $("#TxtPlanta").val();
    
    var validar = 0;

    if ( Planta == "" || descrip == "" || valID == "") {
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
function Table_Centro() {

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
    var html_TCentro = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Descripción</th><th>Descripción de la Planta</th></tr></thead><tbody>";
    for (itemArray in ArrayCentro) {
        if (ArrayCentro[itemArray].Centro_ID != 0) {
            html_TCentro += "<tr id= 'TCentro_" + ArrayCentro[itemArray].Centro_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayCentro[itemArray].Centro_ID + "')\"></input></td><td>" + ArrayCentro[itemArray].Centro_ID + "</td><td>" + ArrayCentro[itemArray].Descripcion + "</td><td>" + ArrayCentro[itemArray].Descripcion_Planta + "</td></tr>";
        }
    }
    html_TCentro += "</tbody></table>";
    $("#container_TCentro").html("");
    $("#container_TCentro").html(html_TCentro);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_Centro) {

    for (itemArray in ArrayCentro) {
        if (index_Centro == ArrayCentro[itemArray].Centro_ID) {
            editID = ArrayCentro[itemArray].Centro_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TCentro = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editarr</th><th>Codigo</th><th>Descripción</th><th>Descripción de la Planta</th></tr></thead><tbody>";
    for (itemArray in ArrayCentro) {
        if (ArrayCentro[itemArray].Centro_ID != 0) {
            html_TCentro += "<tr id= 'TCentro_" + ArrayCentro[itemArray].Centro_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayCentro[itemArray].Centro_ID + "')\"></input></td><td>" + ArrayCentro[itemArray].Centro_ID + "</td><td>" + ArrayCentro[itemArray].Descripcion + "</td><td>" + ArrayCentro[itemArray].Descripcion_Planta + "</td></tr>";
        }
    }
    html_TCentro += "</tbody></table>";
    $("#container_TCentro").html("");
    $("#container_TCentro").html(html_TCentro);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_Centro) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayCentro) {
        if (index_Centro == ArrayCentro[itemArray].Centro_ID) {
            $("#Txt_ID").val(ArrayCentro[itemArray].Centro_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayCentro[itemArray].Descripcion);
            $("#TxtPlanta").val(ArrayCentro[itemArray].Descripcion_Planta);
            editID = ArrayCentro[itemArray].Centro_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TCentro = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo</th><th>Descripción</th><th>Descripción de la Planta</th></tr></thead><tbody>";
    for (itemArray in ArrayCentro) {
        if (ArrayCentro[itemArray].Centro_ID != 0) {
            html_TCentro += "<tr id= 'TCentro_" + ArrayCentro[itemArray].Centro_ID + "'><td>" + ArrayCentro[itemArray].Centro_ID + "</td><td>" + ArrayCentro[itemArray].Descripcion + "</td><td>" + ArrayCentro[itemArray].Descripcion_Planta + "</td></tr>";
        }
    }
    html_TCentro += "</tbody></table>";
    $("#container_TCentro").html("");
    $("#container_TCentro").html(html_TCentro);

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtDescription").val("");
    $("#TxtPlanta").val("");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}