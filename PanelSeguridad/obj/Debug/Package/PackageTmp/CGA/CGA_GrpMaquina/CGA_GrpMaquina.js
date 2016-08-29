/*--------------- region de variables globales --------------------*/
var ArrayGRPMaquinas = [];
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
            $("#container_TGrpMaqunas").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TGrpMaqunas").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TGrpMaqunas").html("");
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
        transacionAjax_GrpMaqunas("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_GrpMaqunas("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_GrpMaqunas_create("crear");
        }
        else {
            transacionAjax_GrpMaqunas_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_GrpMaqunas_delete("elimina");
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
function Table_GrpMaqunas() {

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
    var html_TGrpMaqunas = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayGRPMaquinas) {
        if (ArrayGRPMaquinas[itemArray].Maquina_ID != 0) {
            html_TGrpMaqunas += "<tr id= 'TGrpMaqunas_" + ArrayGRPMaquinas[itemArray].Maquina_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayGRPMaquinas[itemArray].Maquina_ID + "')\"></input></td><td>" + ArrayGRPMaquinas[itemArray].Maquina_ID + "</td><td>" + ArrayGRPMaquinas[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TGrpMaqunas += "</tbody></table>";
    $("#container_TGrpMaqunas").html("");
    $("#container_TGrpMaqunas").html(html_TGrpMaqunas);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_GrpMaqunas) {

    for (itemArray in ArrayGRPMaquinas) {
        if (index_GrpMaqunas == ArrayGRPMaquinas[itemArray].Maquina_ID) {
            editID = ArrayGRPMaquinas[itemArray].Maquina_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TGrpMaqunas = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editarr</th><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayGRPMaquinas) {
        if (ArrayGRPMaquinas[itemArray].Maquina_ID != 0) {
            html_TGrpMaqunas += "<tr id= 'TGrpMaqunas_" + ArrayGRPMaquinas[itemArray].Maquina_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayGRPMaquinas[itemArray].Maquina_ID + "')\"></input></td><td>" + ArrayGRPMaquinas[itemArray].Maquina_ID + "</td><td>" + ArrayGRPMaquinas[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TGrpMaqunas += "</tbody></table>";
    $("#container_TGrpMaqunas").html("");
    $("#container_TGrpMaqunas").html(html_TGrpMaqunas);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_GrpMaqunas) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayGRPMaquinas) {
        if (index_GrpMaqunas == ArrayGRPMaquinas[itemArray].Maquina_ID) {
            $("#Txt_ID").val(ArrayGRPMaquinas[itemArray].Maquina_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayGRPMaquinas[itemArray].Descripcion);
            editID = ArrayGRPMaquinas[itemArray].Maquina_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TGrpMaqunas = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo</th><th>Descripción</th></tr></thead><tbody>";
    for (itemArray in ArrayGRPMaquinas) {
        if (ArrayGRPMaquinas[itemArray].Maquina_ID != 0) {
            html_TGrpMaqunas += "<tr id= 'TGrpMaqunas_" + ArrayGRPMaquinas[itemArray].Maquina_ID + "'><td>" + ArrayGRPMaquinas[itemArray].Maquina_ID + "</td><td>" + ArrayGRPMaquinas[itemArray].Descripcion + "</td></tr>";
        }
    }
    html_TGrpMaqunas += "</tbody></table>";
    $("#container_TGrpMaqunas").html("");
    $("#container_TGrpMaqunas").html(html_TGrpMaqunas);

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