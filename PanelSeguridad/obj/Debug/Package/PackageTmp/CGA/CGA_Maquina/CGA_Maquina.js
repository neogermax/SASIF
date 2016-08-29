/*--------------- region de variables globales --------------------*/
var ArrayMaquina = [];
var ArrayCombo = [];
var ArrayComboCentro = [];
var ArrayComboGrpMaquina = [];
var estado;
var editID;
/*--------------- region de variables globales --------------------*/

//evento load de los Links
$(document).ready(function () {
    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    transacionAjax_CargaCentro('Carga_Centro');
    transacionAjax_CargaGrpMaquinas('Carga_GrpMaquinas');
   
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
            $("#container_TMaquina").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TMaquina").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#container_TMaquina").html("");
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
        transacionAjax_Maquina("consulta", filtro, opcion);
    }
    else {
        filtro = "S";
        opcion = $("#DDLColumns").val();
        transacionAjax_Maquina("consulta", filtro, opcion);
    }

}

//crear link en la BD
function BtnCrear() {

    var validate;
    validate = validarCamposCrear();

    if (validate == 0) {
        if ($("#Btnguardar").val() == "Guardar") {
            transacionAjax_Maquina_create("crear");
        }
        else {
            transacionAjax_Maquina_create("modificar");
        }
    }
}

//elimina de la BD
function BtnElimina() {
    transacionAjax_Maquina_delete("elimina");
}


//validamos campos para la creacion del link
function validarCamposCrear() {

    var valID = $("#Txt_ID").val();
    var descrip = $("#TxtDescription").val();
    var Centro = $("#DDLCentro").val();
    var GrpMaquina = $("#DDLGrpMaquina").val();
    var CECO = $("#TxtCECO").val();
    

    var validar = 0;

    if (CECO == '' || GrpMaquina == "-1" || Centro == "-1" || descrip == "" || valID == "") {
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
        if (Centro == "-1") {
            $("#Img2").css("display", "inline-table");
        }
        else {
            $("#Img2").css("display", "none");
        }
        if (GrpMaquina == "-1") {
            $("#Img3").css("display", "inline-table");
        }
        else {
            $("#Img3").css("display", "none");
        }
        if (CECO == "") {
            $("#Img5").css("display", "inline-table");
        }
        else {
            $("#Img5").css("display", "none");
        }
    }
    else {
        $("#Img1").css("display", "none");
        $("#Img2").css("display", "none");
        $("#Img3").css("display", "none");
        $("#Img5").css("display", "none");
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
function Table_Maquina() {

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
    var html_TMaquina = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Eliminar</th><th>Codigo Maquina</th><th>Descripción</th><th>Centro</th><th>Grupo de Maquinas</th><th>CECO</th></tr></thead><tbody>";
    for (itemArray in ArrayMaquina) {
        if (ArrayMaquina[itemArray].Maquina_ID != 0) {
            html_TMaquina += "<tr id= 'TMaquina_" + ArrayMaquina[itemArray].Maquina_ID + "'><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input></td><td>" + ArrayMaquina[itemArray].Maquina_ID + "</td><td>" + ArrayMaquina[itemArray].Descripcion + "</td><td>" + ArrayMaquina[itemArray].DesCentro + "</td><td>" + ArrayMaquina[itemArray].DesGRPMaquina + "</td><td>" + ArrayMaquina[itemArray].CECO + "</td></tr>";
        }
    }
    html_TMaquina += "</tbody></table>";
    $("#container_TMaquina").html("");
    $("#container_TMaquina").html(html_TMaquina);

    $(".Eliminar").click(function () {
    });
}

//muestra el registro a eliminar
function Eliminar(index_Maquina) {

    for (itemArray in ArrayMaquina) {
        if (index_Maquina == ArrayMaquina[itemArray].Maquina_ID) {
            editID = ArrayMaquina[itemArray].Maquina_ID;
            $("#dialog_eliminar").dialog("option", "title", "Eliminar?");
            $("#dialog_eliminar").dialog("open");
        }
    }

}

//grid con el boton editar
function Tabla_modificar() {
    var html_TMaquina = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Editar</th><th>Codigo Maquina</th><th>Descripción</th><th>Centro</th><th>Grupo de Maquinas</th><th>CECO</th></tr></thead><tbody>";
    for (itemArray in ArrayMaquina) {
        if (ArrayMaquina[itemArray].Maquina_ID != 0) {
            html_TMaquina += "<tr id= 'TMaquina_" + ArrayMaquina[itemArray].Maquina_ID + "'><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input></td><td>" + ArrayMaquina[itemArray].Maquina_ID + "</td><td>" + ArrayMaquina[itemArray].Descripcion + "</td><td>" + ArrayMaquina[itemArray].DesCentro + "</td><td>" + ArrayMaquina[itemArray].DesGRPMaquina + "</td><td>" + ArrayMaquina[itemArray].CECO + "</td></tr>";
        }
    }
    html_TMaquina += "</tbody></table>";
    $("#container_TMaquina").html("");
    $("#container_TMaquina").html(html_TMaquina);

    $(".Editar").click(function () {
    });
}

// muestra el registro a editar
function Editar(index_Maquina) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");

    for (itemArray in ArrayMaquina) {
        if (index_Maquina == ArrayMaquina[itemArray].Maquina_ID) {
            $("#Txt_ID").val(ArrayMaquina[itemArray].Maquina_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayMaquina[itemArray].Descripcion);
            $("#DDLCentro").val(ArrayMaquina[itemArray].Centro_ID);
            $("#DDLGrpMaquina").val(ArrayMaquina[itemArray].GRPMaquina_ID);
            $("#TxtCECO").val(ArrayMaquina[itemArray].CECO);
            editID = ArrayMaquina[itemArray].Maquina_ID;
            $("#Btnguardar").attr("value", "Actualizar");
        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TMaquina = "<table id='matriz' border='1' cellpadding='1' cellspacing='1' class='BtnPerson' style='width: 100%'><thead><tr><th>Codigo Maquina</th><th>Descripción</th><th>Centro</th><th>Grupo de Maquinas</th><th>CECO</th></tr></thead><tbody>";
    for (itemArray in ArrayMaquina) {
        if (ArrayMaquina[itemArray].Maquina_ID != 0) {
            html_TMaquina += "<tr id= 'TMaquina_" + ArrayMaquina[itemArray].Maquina_ID + "'><td>" + ArrayMaquina[itemArray].Maquina_ID + "</td><td>" + ArrayMaquina[itemArray].Descripcion + "</td><td>" + ArrayMaquina[itemArray].DesCentro + "</td><td>" + ArrayMaquina[itemArray].DesGRPMaquina + "</td><td>" + ArrayMaquina[itemArray].CECO + "</td></tr>";
        }
    }
    html_TMaquina += "</tbody></table>";
    $("#container_TMaquina").html("");
    $("#container_TMaquina").html(html_TMaquina);

}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtDescription").val("");
    $("#DDLCentro").val("-1");
    $("#DDLGrpMaquina").val("-1");
    $("#TxtCECO").val("");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
}