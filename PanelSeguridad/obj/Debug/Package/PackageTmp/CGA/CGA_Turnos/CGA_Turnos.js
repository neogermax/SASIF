/*--------------- region de variables globales --------------------*/
var ArrayTurnos = [];
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
            $("#container_TTurnos").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TTurnos").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TTurnos").html("");
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
        transacionAjax_Turnos("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_Turnos("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_Turnos_create("crear");
        }
        else {
            transacionAjax_Turnos_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_Turnos_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var descrip = $("#TxtDescription").val();
    var HoraI = $("#TxtHoraIni").val();
    var Tiempo = $("#TxtTiempo").val();

    var validar = 0;

    if (Tiempo == "" || HoraI == "" || descrip == "" || valID == "") {
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
        if (HoraI == "") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (Tiempo == "") {
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
function Table_Turnos() {

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
    var html_TTurnos = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo</th><th>Descripción</th><th>Hora de Inicio<</th><th>Tiempo</th></tr></thead><tbody>";
    for (itemArray in ArrayTurnos) {
        if (ArrayTurnos[itemArray].Turno_ID != 0) {
            html_TTurnos += "<tr id= 'TTurnos_" + ArrayTurnos[itemArray].Turno_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayTurnos[itemArray].Turno_ID + "')\"></input></td><td>" + ArrayTurnos[itemArray].Turno_ID + "</td><td>" + ArrayTurnos[itemArray].Descripcion + "</td><td>" + ArrayTurnos[itemArray].HoraInicio + "</td><td>" + ArrayTurnos[itemArray].Tiempo + "</td></tr>";
        }
    }
    html_TTurnos += "</tbody></table>";
    $("#container_TTurnos").html("");
    $("#container_TTurnos").html(html_TTurnos);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_Turno) {

    for (itemArray in ArrayTurnos) {
        if (index_Turno == ArrayTurnos[itemArray].Turno_ID) {
            editID = ArrayTurnos[itemArray].Turno_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TTurnos = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editar</th><th>Codigo</th><th>Descripción</th><th>Hora de Inicio</th><th>Tiempo</th></tr></thead><tbody>";
    for (itemArray in ArrayTurnos) {
        if (ArrayTurnos[itemArray].Turno_ID != 0) {
            html_TTurnos += "<tr id= 'TTurnos_" + ArrayTurnos[itemArray].Turno_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayTurnos[itemArray].Turno_ID + "')\"></input></td><td>" + ArrayTurnos[itemArray].Turno_ID + "</td><td>" + ArrayTurnos[itemArray].Descripcion + "</td><td>" + ArrayTurnos[itemArray].HoraInicio + "</td><td>" + ArrayTurnos[itemArray].Tiempo + "</td></tr>";
        }
    }
    html_TTurnos += "</tbody></table>";
    $("#container_TTurnos").html("");
    $("#container_TTurnos").html(html_TTurnos);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_Turno) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayTurnos) {
        if (index_Turno == ArrayTurnos[itemArray].Turno_ID) {
            $("#Txt_ID").val(ArrayTurnos[itemArray].Turno_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayTurnos[itemArray].Descripcion);
            $("#TxtHoraIni").val(ArrayTurnos[itemArray].HoraInicio);
            $("#TxtTiempo").val(ArrayTurnos[itemArray].Tiempo);
            editID = ArrayTurnos[itemArray].Turno_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TTurnos = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo</th><th>Descripción</th><th>Hora de Inicio</th><th>Tiempo</th></tr></thead><tbody>";
    for (itemArray in ArrayTurnos) {
        if (ArrayTurnos[itemArray].Turno_ID != 0) {
            html_TTurnos += "<tr id= 'TTurnos_" + ArrayTurnos[itemArray].Turno_ID + "'><td>" + ArrayTurnos[itemArray].Turno_ID + "</td><td>" + ArrayTurnos[itemArray].Descripcion + "</td><td>" + ArrayTurnos[itemArray].HoraInicio + "</td><td>" + ArrayTurnos[itemArray].Tiempo + "</td></tr>";
        }
    }
    html_TTurnos += "</tbody></table>";
    $("#container_TTurnos").html("");
    $("#container_TTurnos").html(html_TTurnos);

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtDescription").val("");
    $("#TxtHoraIni").val("");
    $("#TxtTiempo").val("");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}