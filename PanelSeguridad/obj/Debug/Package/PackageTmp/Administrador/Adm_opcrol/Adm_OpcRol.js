/*--------------- region de variables globales --------------------*/
var ArrayOpcRol = [];
var ArrayCombo = [];
var ArrayComboSubRol = [];
var ArrayComboLinks = [];
var estado;
var editID;
var EditLink;
var DeleteConsecutivo;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {

    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    transacionAjax_CargaRol('Carga_Rol');
    Ctipo();

    $("#ESelect").css("display", "none");
    $("#ImgID").css("display", "none");
    $("#Img1").css("display", "none");
    $("#Img2").css("display", "none");
    $("#Img3").css("display", "none");
    $("#Img5").css("display", "none");
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

//funcion que dispara elcombo del tipo
function Ctipo() {

    $("#DDLTipo").change(function () {
        loadChildrenlinks($(this));
    });
}

//fucion que carga desde ddl tipo que tipo es(carpeta o link)
function loadChildrenlinks(obj) {

    var tipo_link = $(obj).val();
    $("#DDLLink_ID").empty();
    transacionAjax_CargaLinks('cargar_Links', tipo_link);

}


function View_loadChildrenlinks(ID) {
    $("#DDLLink_ID").empty();
    transacionAjax_CargaLinks('cargar_Links', ID);
    var timer_program_edit = setTimeout("$('#DDLLink_ID').val(EditLink);", 2000);
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
            $("#TablaConsulta").css("display", "none");
            $("#DDL_ID").removeAttr("disabled");
            $("#TxtConsecutivo").removeAttr("disabled");
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TopcRol").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TopcRol").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TopcRol").html("");
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
        transacionAjax_opcRol("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_opcRol("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_opcRol_create("crear");
        }
        else {
            transacionAjax_opcRol_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_opcRol_delete("elimina");
}

//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#DDL_ID").val();
    var consecutivo = $("#TxtConsecutivo").val();
    var tipo = $("#DDLTipo").val();
    var sub_rol = $("#DDLSubRol_Rol").val();
    var link = $("#DDLLink_ID").val();

    var validar = 0;

    if (tipo == "-1" || sub_rol == "-1" || link == "-1" || consecutivo == "" || valID == "-1") {
        validar = 1;
        if (valID == "-1") {
            $("#ImgID").css("display", "inline-table");
        }
        else {
            $("#ImgID").css("display", "none");
        }
        if (tipo == "-1") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (sub_rol == "-1") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }
        if (link == "-1") {
            $("#Img5").css("display", "inline-table");
        }
        else {
            $("#Img5").css("display", "none");
        }
        if (consecutivo == "") {
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
        $("#Img3").css("display", "none");
        $("#Img5").css("display", "none");
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
function Table_opcRol() {

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
    var html_Topcrol = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Consecutivo</th><th>Tipo</th><th>Sub-Rol o Rol</th><th>llave tabla Links</th></tr></thead><tbody>";
    for (itemArray in ArrayOpcRol) {

        html_Topcrol += "<tr id= 'TOpcRol_" + ArrayOpcRol[itemArray].OPRol_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayOpcRol[itemArray].OPRol_ID + "','" + ArrayOpcRol[itemArray].Consecutivo + "')\"></input></td><td>" + ArrayOpcRol[itemArray].OPRol_ID + "</td><td>" + ArrayOpcRol[itemArray].Consecutivo + "</td><td>" + ArrayOpcRol[itemArray].Tipo + "</td><td>" + ArrayOpcRol[itemArray].Subrol_rol + "</td><td> " + ArrayOpcRol[itemArray].Link_ID + " </td></tr>";
    }
    html_Topcrol += "</tbody></table>";
    $("#container_TopcRol").html("");
    $("#container_TopcRol").html(html_Topcrol);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_opcrol, index_consecutivo) {


    for (itemArray in ArrayOpcRol) {
        if (index_opcrol == ArrayOpcRol[itemArray].OPRol_ID && index_consecutivo == ArrayOpcRol[itemArray].Consecutivo) {
            editID = ArrayOpcRol[itemArray].OPRol_ID;
            DeleteConsecutivo = ArrayOpcRol[itemArray].Consecutivo
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_Topcrol = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editar</th><th>Codigo</th><th>Consecutivo</th><th>Tipo</th><th>Sub-Rol o Rol</th><th>llave tabla Links</th></tr></thead><tbody>";
    for (itemArray in ArrayOpcRol) {
        html_Topcrol += "<tr id= 'TOpcRol_" + ArrayOpcRol[itemArray].OPRol_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayOpcRol[itemArray].OPRol_ID + "','" + ArrayOpcRol[itemArray].Consecutivo + "')\"></input></td><td>" + ArrayOpcRol[itemArray].OPRol_ID + "</td><td>" + ArrayOpcRol[itemArray].Consecutivo + "</td><td>" + ArrayOpcRol[itemArray].Tipo + "</td><td>" + ArrayOpcRol[itemArray].Subrol_rol + "</td><td> " + ArrayOpcRol[itemArray].Link_ID + " </td></tr>";
    }
    html_Topcrol += "</tbody></table>";
    $("#container_TopcRol").html("");
    $("#container_TopcRol").html(html_Topcrol);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_opcrol, index_consecutivo) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayOpcRol) {
        if (index_opcrol == ArrayOpcRol[itemArray].OPRol_ID && index_consecutivo == ArrayOpcRol[itemArray].Consecutivo) {
            $("#DDL_ID").val(ArrayOpcRol[itemArray].OPRol_ID);
            $("#DDL_ID").attr("disabled", "disabled");
            $("#TxtConsecutivo").val(ArrayOpcRol[itemArray].Consecutivo);
            $("#TxtConsecutivo").attr("disabled", "disabled");
            $("#DDLTipo").val(ArrayOpcRol[itemArray].Tipo);
            $("#DDLSubRol_Rol").val(ArrayOpcRol[itemArray].Subrol_rol);
            editID = ArrayOpcRol[itemArray].OPRol_ID;
            $("#Btnguardar").attr("value", "Actualizar");

            for (item in ArrayMenu) {
                if (index_opcrol == ArrayMenu[item].IDOpcionRol && index_consecutivo == ArrayMenu[item].Consecutivo) {
                    EditLink = ArrayMenu[item].IDlink;
                }
            }

            View_loadChildrenlinks(ArrayOpcRol[itemArray].Tipo);
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_Topcrol = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo</th><th>Consecutivo</th><th>Tipo</th><th>Sub-Rol o Rol</th><th>llave tabla Links</th></tr></thead><tbody>";
    for (itemArray in ArrayOpcRol) {
        html_Topcrol += "<tr id= 'TOpcRol_" + ArrayOpcRol[itemArray].OPRol_ID + "'><td>" + ArrayOpcRol[itemArray].OPRol_ID + "</td><td>" + ArrayOpcRol[itemArray].Consecutivo + "</td><td>" + ArrayOpcRol[itemArray].Tipo + "</td><td>" + ArrayOpcRol[itemArray].Subrol_rol + "</td><td> " + ArrayOpcRol[itemArray].Link_ID + " </td></tr>";
    }
    html_Topcrol += "</tbody></table>";
    $("#container_TopcRol").html("");
    $("#container_TopcRol").html(html_Topcrol);

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#DDL_ID").val("-1");
    $("#TxtConsecutivo").val("");
    $("#DDLTipo").val("-1");
    $("#DDLSubRol_Rol").val("-1");
    $("#DDLLink_ID").val("-1");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}