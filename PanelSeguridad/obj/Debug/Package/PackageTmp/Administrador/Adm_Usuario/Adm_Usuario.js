/*--------------- region de variables globales --------------------*/
var ArrayUser = [];
var ArrayCombo = [];
var ArrayComboRol = [];
var ArrayComboOpcRol = [];
var estado;
var editID;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {

    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    transacionAjax_CargaRol('cargar_Rol');
   
    $("#ESelect").css("display", "none");
    $("#ImgID").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img7").css("display", "none");

    $("#DE").css("display", "none");
    $("#SE").css("display", "none");

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
            $("#container_TUser").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TUser").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TUser").html("");
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
        transacionAjax_User("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_User("consulta", filtro, opcion);
    }

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

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_User_create("crear");
        }
        else {
            transacionAjax_User_create("modificar");
        }
    }
}

//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var nombre = $("#TxtName").val();
    var documento = $("#TxtDocument").val();

    var rol = $("#DDLRol").val();

    var validar = 0;

    if (rol == "-1" || nombre == "" || documento == "" || valID == "") {
        validar = 1;
        if (valID == "") {
            $("#ImgID").css("display", "inline-table");
        }
        else {
            $("#ImgID").css("display", "none");
        }
        if (nombre == "") {
            $("#Img1").css("display", "inline-table");
        }
        else {
            $("#Img1").css("display", "none");
        }
        if (documento == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (rol == "-1") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }
    }
    else {
        $("#ImgID").css("display", "none");
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
        $("#Img3").css("display", "none");
    }
    return validar;
}

// crea la tabla en el cliente
function Table_User() {

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
    var html_TUser = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Usuario</th><th>Documento</th><th>Nombre</th><th>Rol</th></th></th><th>Estado</th></tr></thead><tbody>";
    for (itemArray in ArrayUser) {
        html_TUser += "<tr id= 'TUser_" + ArrayUser[itemArray].Usuario_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayUser[itemArray].Usuario_ID + "')\"></input></td><td>" + ArrayUser[itemArray].Usuario_ID + "</td><td>" + ArrayUser[itemArray].Documento + "</td><td>" + ArrayUser[itemArray].Nombre + "</td><td>" + ArrayUser[itemArray].Rol_ID + "</td><td> " + ArrayUser[itemArray].Estado + " </td></tr>";
    }
    html_TUser += "</tbody></table>";
    $("#container_TUser").html("");
    $("#container_TUser").html(html_TUser);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_User) {


    for (itemArray in ArrayUser) {
        if (index_User == ArrayUser[itemArray].Usuario_ID) {
            editID = ArrayUser[itemArray].Usuario_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TUser = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editar</th><th>Usuario</th><th>Documento</th><th>Nombre</th><th>Rol</th></th></th><th>Estado</th></tr></thead><tbody>";
    for (itemArray in ArrayUser) {
        html_TUser += "<tr id= 'TUser_" + ArrayUser[itemArray].Usuario_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayUser[itemArray].Usuario_ID + "')\"></input></td><td>" + ArrayUser[itemArray].Usuario_ID + "</td><td>" + ArrayUser[itemArray].Documento + "</td><td>" + ArrayUser[itemArray].Nombre + "</td><td>" + ArrayUser[itemArray].Rol_ID + "</td><td> " + ArrayUser[itemArray].Estado + " </td></tr>";
    }
    html_TUser += "</tbody></table>";
    $("#container_TUser").html("");
    $("#container_TUser").html(html_TUser);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_User) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayUser) {
        if (index_User == ArrayUser[itemArray].Usuario_ID) {
            $("#Txt_ID").val(ArrayUser[itemArray].Usuario_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtName").val(ArrayUser[itemArray].Nombre);
            $("#TxtDocument").val(ArrayUser[itemArray].Documento);
            $("#DDLRol").val(ArrayUser[itemArray].Rol_ID);
            $("#TxtUser").val(ArrayUser[itemArray].Nick);
            editID = ArrayUser[itemArray].Usuario_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TUser = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Usuario</th><th>Documento</th><th>Nombre</th><th>Rol</th></th></th><th>Estado</th></tr></thead><tbody>";
    for (itemArray in ArrayUser) {
        html_TUser += "<tr id= 'TUser_" + ArrayUser[itemArray].Usuario_ID + "'><td>" + ArrayUser[itemArray].Usuario_ID + "</td><td>" + ArrayUser[itemArray].Documento + "</td><td>" + ArrayUser[itemArray].Nombre + "</td><td>" + ArrayUser[itemArray].Rol_ID + "</td><td> " + ArrayUser[itemArray].Estado + " </td></tr>";
    }
    html_TUser += "</tbody></table>";
    $("#container_TUser").html("");
    $("#container_TUser").html(html_TUser);

}


//elimina de la BD
function BtnElimina() {
    transacionAjax_User_delete("elimina");
}


//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtName").val("");
    $("#TxtDocument").val("");
    $("#DDLRol").val("-1");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}