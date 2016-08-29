/*--------------- region de variables globales --------------------*/
var ArrayRoles = [];
var ArrayCombo = [];
var estado;
var editID;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    $("#ESelect").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#DE").css("display", "none");
    $("#DS").css("display", "none");
    $("#ImgID").css("display", "none");


    $("#TablaDatos").css("display", "none");
    $("#TablaConsulta").css("display", "none");


    //funcion para las ventanas emergentes
    $("#dialog").dialog({
        autoOpen: false
    });

    $("#dialog_eliminar").dialog({
        autoOpen: false
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
            $("#container_Trol").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_Trol").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_Trol").html("");
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
        transacionAjax_Rol("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_Rol("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_Rol_create("crear");
        }
        else {
            transacionAjax_Rol_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_Rol_delete("elimina");
}

//validamos campos para la creacion del rol
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var sigla = $("#TxtSigla").val();
    var descrip = $("#TxtDescription").val();
    var validar = 0;

    if (sigla == "" || descrip == "" || valID == "") {
        validar = 1;
        if (valID == "") {
            $("#ImgID").css("display", "inline-table");
        }
        else {
            $("#ImgID").css("display", "none");
        }

        if (sigla == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
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
function Table_rol() {

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
    var html_TRol = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Descripción</th><th>Sigla</th><th>Estado</th></tr></thead><tbody>";
    for (itemArray in ArrayRoles) {

        html_TRol += "<tr id= 'TRol_" + ArrayRoles[itemArray].Rol_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayRoles[itemArray].Rol_ID + "')\"></input></td><td>" + ArrayRoles[itemArray].Rol_ID + "</td><td>" + ArrayRoles[itemArray].Descripcion + "</td><td>" + ArrayRoles[itemArray].Sigla + "</td><td> " + ArrayRoles[itemArray].Estado + " </td></tr>";
    }
    html_TRol += "</tbody></table>";
    $("#container_Trol").html("");
    $("#container_Trol").html(html_TRol);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_rol) {

    for (itemArray in ArrayRoles) {
        if (index_rol == ArrayRoles[itemArray].Rol_ID) {
            editID = ArrayRoles[itemArray].Rol_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TRol = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editar</th><th>Codigo</th><th>Descripción</th><th>Sigla</th><th>Estado</th></tr></thead><tbody>";
    for (itemArray in ArrayRoles) {
        html_TRol += "<tr id= 'TRol_" + ArrayRoles[itemArray].Rol_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayRoles[itemArray].Rol_ID + "')\"></input></td><td>" + ArrayRoles[itemArray].Rol_ID + "</td><td>" + ArrayRoles[itemArray].Descripcion + "</td><td>" + ArrayRoles[itemArray].Sigla + "</td><td> " + ArrayRoles[itemArray].Estado + " </td></tr>";
    }
    html_TRol += "</tbody></table>";
    $("#container_Trol").html("");
    $("#container_Trol").html(html_TRol);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_rol) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayRoles) {
        if (index_rol == ArrayRoles[itemArray].Rol_ID) {
            $("#Txt_ID").val(ArrayRoles[itemArray].Rol_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayRoles[itemArray].Descripcion);
            $("#TxtSigla").val(ArrayRoles[itemArray].Sigla);
            editID = ArrayRoles[itemArray].Rol_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TRol = "<table id='matriz' border='1' class='BtnPerson' cellpadding='1' cellspacing='1' style='width: 100%'><thead><tr><th>Codigo</th><th>Descripción</th><th>Sigla</th><th>Estado</th></tr></thead><tbody>";
    for (itemArray in ArrayRoles) {
        html_TRol += "<tr id= 'TRol_" + ArrayRoles[itemArray].Rol_ID + "'><td>" + ArrayRoles[itemArray].Rol_ID + "</td><td>" + ArrayRoles[itemArray].Descripcion + "</td><td>" + ArrayRoles[itemArray].Sigla + "</td><td> " + ArrayRoles[itemArray].Estado + " </td></tr>";
    }
    html_TRol += "</tbody></table>";
    $("#container_Trol").html("");
    $("#container_Trol").html(html_TRol);

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtDescription").val("");
    $("#TxtSigla").val("");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}
