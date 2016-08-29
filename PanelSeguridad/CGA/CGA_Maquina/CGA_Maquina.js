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

    carga_eventos("Dialog_Charge");
    transacionAjax_CargaBusqueda('cargar_droplist_busqueda');
    transacionAjax_CargaCentro('Carga_Centro');
    transacionAjax_CargaGrpMaquinas('Carga_GrpMaquinas');
    transacionAjax_CargaCCosto('Carga_CCosto');

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
    $("#Tab_Maquina").css("display", "none");


    $('.solo-numero').keyup(function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    });

    /*  -----------------------------------------------------------------------  */
    /*                      funcion para las ventanas emergentes                 */
    /*  -----------------------------------------------------------------------  */

    $("#dialog").dialog({
        autoOpen: false,
        modal: true
    });

    $("#dialog_eliminar").dialog({
        autoOpen: false,
        modal: true
    });

    $("#dialog_Ver").dialog({
        autoOpen: false,
        dialogClass: "Dialog_personal",
        modal: true,
        width: 500,
        height: 550,
        overlay: {
            opacity: 0.5,
            background: "black"
        },
        open: function (event, ui) { $(".ui-dialog-titlebar-close", ui.dialog).show(); }
    });

    /*  -----------------------------------------------------------------------  */
    /*                      funcion para la pestaña                              */
    /*  -----------------------------------------------------------------------  */

    $(function () {
        $("#Tab_Maquina").tabs({
    });

    /*  -----------------------------------------------------------------------  */
    /*                      funcion para el acordeon                             */
    /*  -----------------------------------------------------------------------  */

    $(function () {
        $("#Aco_Datos").accordion({
            heightStyle: "content"
        });
        $("#Aco_Datos_complemento").accordion({
            heightStyle: "content"
        });
    });

    /*  -----------------------------------------------------------------------  */
    /*                      funcion para el calendario                            */
    /*  -----------------------------------------------------------------------  */
    $(function () {
        $("#DateStart_Matenimiento").datepicker();
        $("#DateEnd_Matenimiento").datepicker();
        $("#DateStart_NODisponibilidad").datepicker();
        $("#DateEnd_NODisponibilidad").datepicker();

    });

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
            $("#Tab_Maquina").css("display", "inline-table");
            $("#Txt_ID").removeAttr("disabled");
            $("#Btnguardar").attr("value", "Guardar");
            $("#Btnguardar_2").attr("value", "Guardar");
            $("#Btnguardar_3").attr("value", "Guardar");
            Clear();
            estado = opcion;
            break;

        case "buscar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#Tab_Maquina").css("display", "none");

            $("#container_TMaquina").html("");
            estado = opcion;
            Clear();
            break;

        case "modificar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#Tab_Maquina").css("display", "none");

            $("#container_TMaquina").html("");
            estado = opcion;
            Clear();
            break;

        case "eliminar":
            $("#TablaDatos").css("display", "none");
            $("#TablaConsulta").css("display", "inline-table");
            $("#Tab_Maquina").css("display", "none");

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
    var validate_F;
    validate = validarCamposCrear();

    if (validate == 0) {

        validate_F = fechas_mantenimiento_disponibilidad();

        if (validate_F == "") {

            if ($("#Btnguardar").val() == "Guardar" || $("#Btnguardar_2").val() == "Guardar" || $("#Btnguardar_3").val() == "Guardar") {
                transacionAjax_Maquina_create("crear");
            }
            else {
                transacionAjax_Maquina_create("modificar");
            }
        }

        else {
            $("#dialog").dialog("option", "title", "Atención");
            $("#Mensaje_alert").text(validate_F);
            $("#dialog").dialog("open");
            $("#DE").css("display", "Block");
            $("#SE").css("display", "none");
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
    var CECO = $("#DLLCCosto").val();


    var validar = 0;

    if (CECO == '-1' || GrpMaquina == "-1" || Centro == "-1" || descrip == "" || valID == "") {
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
        if (CECO == "-1") {
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
    var html_TMaquina = "<table id='TMaquina' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Ver Registro</th><th>Eliminar</th><th>Codigo Maquina</th><th>Descripción</th><th>Centro</th><th>Grupo de Maquinas</th><th>Centro de Costos</th><th>Largo</th><th>Ancho</th><th>Espesor / Diametro</th><th>Fec. Inicial Mantenimiento</th><th>Fec. Final Mantenimiento</th><th>H. Inicial Mantenimiento</th><th>H. Final Mantenimiento</th><th>Fec. Inicial NO disponible</th><th>Fec. Final NO disponible</th><th>H. Inicial NO disponible</th><th>H. Final NO disponible</th><th>Tarifa</th></tr></thead><tbody>";
    for (itemArray in ArrayMaquina) {
        if (ArrayMaquina[itemArray].Maquina_ID != 0) {
            html_TMaquina += "<tr id= 'TMaquina_" + ArrayMaquina[itemArray].Maquina_ID + "'><td><input type ='radio' class= 'Ver' name='ver' onclick=\"Ver('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input></td><td><input type ='radio' class= 'Eliminar' name='eliminar' onclick=\"Eliminar('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input></td><td>" + ArrayMaquina[itemArray].Maquina_ID + "</td><td>" + ArrayMaquina[itemArray].Descripcion + "</td><td>" + ArrayMaquina[itemArray].DesCentro + "</td><td>" + ArrayMaquina[itemArray].DesGRPMaquina + "</td><td>" + ArrayMaquina[itemArray].DesCentroCosto + "</td><td>" + ArrayMaquina[itemArray].Largo + "</td><td>" + ArrayMaquina[itemArray].Ancho + "</td><td>" + ArrayMaquina[itemArray].Espesor_Diametro + "</td><td>" + ArrayMaquina[itemArray].Fec_Inicial_Mant + "</td><td>" + ArrayMaquina[itemArray].Fec_Final_Mant + "</td><td>" + ArrayMaquina[itemArray].H_Inicial_Mant + "</td><td>" + ArrayMaquina[itemArray].H_Final_Mant + "</td><td>" + ArrayMaquina[itemArray].Fec_Inicial_NDisp + "</td><td>" + ArrayMaquina[itemArray].Fec_Final_NDisp + "</td><td>" + ArrayMaquina[itemArray].H_Inicial_NDisp + "</td><td>" + ArrayMaquina[itemArray].H_Final_NDisp + "</td><td>" + ArrayMaquina[itemArray].Tarifa + "</td></tr>";
        }
    }
    html_TMaquina += "</tbody></table>";
    $("#container_TMaquina").html("");
    $("#container_TMaquina").html(html_TMaquina);

    $(".Ver").click(function () {
    });

    $(".Eliminar").click(function () {
    });

    $("#TMaquina").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
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
    var html_TMaquina = "<table id='TMaquina' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Ver Registro</th><th>Editar</th><th>Codigo Maquina</th><th>Descripción</th><th>Centro</th><th>Grupo de Maquinas</th><th>Centro de Costos</th><th>Largo</th><th>Ancho</th><th>Espesor / Diametro</th><th>Fec. Inicial Mantenimiento</th><th>Fec. Final Mantenimiento</th><th>H. Inicial Mantenimiento</th><th>H. Final Mantenimiento</th><th>Fec. Inicial NO disponible</th><th>Fec. Final NO disponible</th><th>H. Inicial NO disponible</th><th>H. Final NO disponible</th><th>Tarifa</th></tr></thead><tbody>";
    for (itemArray in ArrayMaquina) {
        if (ArrayMaquina[itemArray].Maquina_ID != 0) {
            html_TMaquina += "<tr id= 'TMaquina_" + ArrayMaquina[itemArray].Maquina_ID + "'><td><input type ='radio' class= 'Ver' name='ver' onclick=\"Ver('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input></td><td><input type ='radio' class= 'Editar' name='editar' onclick=\"Editar('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input></td><td>" + ArrayMaquina[itemArray].Maquina_ID + "</td><td>" + ArrayMaquina[itemArray].Descripcion + "</td><td>" + ArrayMaquina[itemArray].DesCentro + "</td><td>" + ArrayMaquina[itemArray].DesGRPMaquina + "</td><td>" + ArrayMaquina[itemArray].DesCentroCosto + "</td><td>" + ArrayMaquina[itemArray].Largo + "</td><td>" + ArrayMaquina[itemArray].Ancho + "</td><td>" + ArrayMaquina[itemArray].Espesor_Diametro + "</td><td>" + ArrayMaquina[itemArray].Fec_Inicial_Mant + "</td><td>" + ArrayMaquina[itemArray].Fec_Final_Mant + "</td><td>" + ArrayMaquina[itemArray].H_Inicial_Mant + "</td><td>" + ArrayMaquina[itemArray].H_Final_Mant + "</td><td>" + ArrayMaquina[itemArray].Fec_Inicial_NDisp + "</td><td>" + ArrayMaquina[itemArray].Fec_Final_NDisp + "</td><td>" + ArrayMaquina[itemArray].H_Inicial_NDisp + "</td><td>" + ArrayMaquina[itemArray].H_Final_NDisp + "</td><td>" + ArrayMaquina[itemArray].Tarifa + "</td></tr>";
        }
    }
    html_TMaquina += "</tbody></table>";
    $("#container_TMaquina").html("");
    $("#container_TMaquina").html(html_TMaquina);

    $(".Editar").click(function () {
    });

    $(".Ver").click(function () {
    });

    $("#TMaquina").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

// muestra el registro a editar
function Editar(index_Maquina) {

    $("#TablaDatos").css("display", "inline-table");
    $("#TablaConsulta").css("display", "none");
    $("#Tab_Maquina").css("display", "inline-table");

    for (itemArray in ArrayMaquina) {
        if (index_Maquina == ArrayMaquina[itemArray].Maquina_ID) {
            $("#Txt_ID").val(ArrayMaquina[itemArray].Maquina_ID);
            $("#Txt_ID").attr("disabled", "disabled");
            $("#TxtDescription").val(ArrayMaquina[itemArray].Descripcion);
            $("#DDLCentro").val(ArrayMaquina[itemArray].Centro_ID);
            $("#DDLGrpMaquina").val(ArrayMaquina[itemArray].GRPMaquina_ID);
            $("#DLLCCosto").val(ArrayMaquina[itemArray].CentroCosto_ID);

            $("#DateStart_Matenimiento").val(ArrayMaquina[itemArray].Fec_Inicial_Mant);
            $("#DateEnd_Matenimiento").val(ArrayMaquina[itemArray].Fec_Final_Mant);
            $("#TxtHI_Mantenimiento").val(ArrayMaquina[itemArray].H_Inicial_Mant);
            $("#TxtHF_Mantenimiento").val(ArrayMaquina[itemArray].H_Final_Mant);
            $("#DateStart_NODisponibilidad").val(ArrayMaquina[itemArray].Fec_Inicial_NDisp);
            $("#DateEnd_NODisponibilidad").val(ArrayMaquina[itemArray].Fec_Final_NDisp);
            $("#TxtHI_NODisponibilidad").val(ArrayMaquina[itemArray].H_Inicial_NDisp);
            $("#TxtHF_NODisponibilidad").val(ArrayMaquina[itemArray].H_Final_NDisp);
            $("#TxtLargo").val(ArrayMaquina[itemArray].Largo);
            $("#TxtAncho").val(ArrayMaquina[itemArray].Ancho);
            $("#TxtEspesor_Diametro").val(ArrayMaquina[itemArray].Espesor_Diametro);
            $("#TxtTarifa").val(ArrayMaquina[itemArray].Tarifa);

            editID = ArrayMaquina[itemArray].Maquina_ID;
            $("#Btnguardar").attr("value", "Actualizar");
            $("#Btnguardar_2").attr("value", "Actualizar");
            $("#Btnguardar_3").attr("value", "Actualizar");

        }
    }
}

//grid sin botones para ver resultado
function Tabla_consulta() {
    var html_TMaquina = "<table id='TMaquina' border='1' cellpadding='1' cellspacing='1'  style='width: 100%'><thead><tr><th>Ver Registro</th><th>Codigo Maquina</th><th>Descripción</th><th>Centro</th><th>Grupo de Maquinas</th><th>Centro de Costos</th><th>Largo</th><th>Ancho</th><th>Espesor / Diametro</th><th>Fec. Inicial Mantenimiento</th><th>Fec. Final Mantenimiento</th><th>H. Inicial Mantenimiento</th><th>H. Final Mantenimiento</th><th>Fec. Inicial NO disponible</th><th>Fec. Final NO disponible</th><th>H. Inicial NO disponible</th><th>H. Final NO disponible</th><th>Tarifa</th></tr></thead><tbody>";
    for (itemArray in ArrayMaquina) {
        if (ArrayMaquina[itemArray].Maquina_ID != 0) {
            html_TMaquina += "<tr id= 'TMaquina_" + ArrayMaquina[itemArray].Maquina_ID + "'><td><span class='cssToolTip_ver'><input type ='radio' class= 'Ver' name='ver' onclick=\"Ver('" + ArrayMaquina[itemArray].Maquina_ID + "')\"></input><span>Al precionar vera la consulta en una ventana emergente</span></span></td><td>" + ArrayMaquina[itemArray].Maquina_ID + "</td><td>" + ArrayMaquina[itemArray].Descripcion + "</td><td>" + ArrayMaquina[itemArray].DesCentro + "</td><td>" + ArrayMaquina[itemArray].DesGRPMaquina + "</td><td>" + ArrayMaquina[itemArray].DesCentroCosto + "</td><td>" + ArrayMaquina[itemArray].Largo + "</td><td>" + ArrayMaquina[itemArray].Ancho + "</td><td>" + ArrayMaquina[itemArray].Espesor_Diametro + "</td><td>" + ArrayMaquina[itemArray].Fec_Inicial_Mant + "</td><td>" + ArrayMaquina[itemArray].Fec_Final_Mant + "</td><td>" + ArrayMaquina[itemArray].H_Inicial_Mant + "</td><td>" + ArrayMaquina[itemArray].H_Final_Mant + "</td><td>" + ArrayMaquina[itemArray].Fec_Inicial_NDisp + "</td><td>" + ArrayMaquina[itemArray].Fec_Final_NDisp + "</td><td>" + ArrayMaquina[itemArray].H_Inicial_NDisp + "</td><td>" + ArrayMaquina[itemArray].H_Final_NDisp + "</td><td>" + ArrayMaquina[itemArray].Tarifa + "</td></tr>";
        }
    }
    html_TMaquina += "</tbody></table>";
    $("#container_TMaquina").html("");
    $("#container_TMaquina").html(html_TMaquina);

    $(".Ver").click(function () {
    });

    $("#TMaquina").dataTable({
        "bJQueryUI": true,
        "bDestroy": true
    });
}

//evento del boton salir
function x() {
    $("#dialog").dialog("close");
}

//funcion para una mejor visualizacion del registro seleccionando
function Ver(index_Maquina) {

    var Nombre_maq;

    for (itemArray in ArrayMaquina) {
        if (index_Maquina == ArrayMaquina[itemArray].Maquina_ID) {

            $("#V_centro").html(ArrayMaquina[itemArray].Centro_ID + " " + ArrayMaquina[itemArray].DesCentro);
            $("#V_GRPMaquina").html(ArrayMaquina[itemArray].DesGRPMaquina);
            $("#V_CC").html(ArrayMaquina[itemArray].DesCentroCosto);

            Nombre_maq = ArrayMaquina[itemArray].Descripcion;
            $("#V_FI_M").html(ArrayMaquina[itemArray].Fec_Inicial_Mant);
            $("#V_FF_M").html(ArrayMaquina[itemArray].Fec_Final_Mant);
            $("#V_HI_M").html(ArrayMaquina[itemArray].H_Inicial_Mant);
            $("#V_HF_M").html(ArrayMaquina[itemArray].H_Final_Mant);
            $("#V_FI_ND").html(ArrayMaquina[itemArray].Fec_Inicial_NDisp);
            $("#V_FF_ND").html(ArrayMaquina[itemArray].Fec_Final_NDisp);
            $("#V_HI_ND").html(ArrayMaquina[itemArray].H_Inicial_NDisp);
            $("#V_HF_ND").html(ArrayMaquina[itemArray].H_Final_NDisp);

            $("#V_largo").html(ArrayMaquina[itemArray].Largo);
            $("#V_ancho").html(ArrayMaquina[itemArray].Ancho);
            $("#V_ED").html(ArrayMaquina[itemArray].Espesor_Diametro);
            $("#V_Tarifa").html(ArrayMaquina[itemArray].Tarifa);

        }
    }
    $("#dialog_Ver").dialog("option", "title", "Maquina: " + index_Maquina + " " + Nombre_maq);
    $("#dialog_Ver").dialog("open");


}

//para controlar que la fecha fin nosea mayor que la inicial
function fechas_mantenimiento_disponibilidad() {

    var Fecha_val_i_M = $("#DateStart_Matenimiento").val();
    var Fecha_val_f_M = $("#DateEnd_Matenimiento").val();
    var Fecha_val_i_D = $("#DateStart_NODisponibilidad").val();
    var Fecha_val_f_D = $("#DateEnd_NODisponibilidad").val();

    var MSN = "";

    if (Fecha_val_i_M != "" || Fecha_val_f_M != "") {
        if (Fecha_val_i_M == "") {
            MSN = "La fecha inicial de mantenimiento debe estar diligenciada!";
        }
        else {
            MSN = validarFecha(Fecha_val_i_M, Fecha_val_f_M, 'M');
        }
    }

    if (Fecha_val_i_D != "" || Fecha_val_f_D != "") {
        if (Fecha_val_i_D == "") {

            if (MSN != "") {
                MSN = MSN + ", ademas la fecha inicial de no disponibilidad debe estar diligenciada!";
            }
            else {
                MSN = "La fecha Inicial no disponibilidad debe estar diligenciada!";
            }

        }
        else {
            if (MSN != "") {
                var valf = validarFecha(Fecha_val_i_D, Fecha_val_f_D, 'ND');
                MSN = MSN + valf;
            }
            else {
                MSN = validarFecha(Fecha_val_i_D, Fecha_val_f_D, 'ND');
            }

        }
    }

    return MSN;
}

//funcion que valida la fecha fin nosea mayor que la inicial
function validarFecha(DateStart, DateEnd, type) {

    var valida = "";

    if (DateStart > DateEnd) {
        $("#dialog").dialog("option", "title", "Atención");
        if (type == "M") {
            valida = "La fecha final NO debe ser mayor que la fecha Inicial del matenimiento!";
        }
        else {
            valida = "La fecha final NO debe ser mayor que la fecha Inicial de la NO disponibilidad!";

        }
    }
    return valida;
}

//limpiar campos
function Clear() {
    $("#Txt_ID").val("");
    $("#TxtDescription").val("");
    $("#DDLCentro").val("-1");
    $("#DDLGrpMaquina").val("-1");
    $("#DLLCCosto").val("-1");
    $("#TxtRead").val("");
    $("#DDLColumns").val("-1");
    $("#DateStart_Matenimiento").val("");
    $("#DateEnd_Matenimiento").val("");
    $("#TxtHI_Mantenimiento").val("");
    $("#TxtHF_Mantenimiento").val("");
    $("#DateStart_NODisponibilidad").val("");
    $("#DateEnd_NODisponibilidad").val("");
    $("#TxtHI_NODisponibilidad").val("");
    $("#TxtHF_NODisponibilidad").val("");
    $("#TxtLargo").val("");
    $("#TxtAncho").val("");
    $("#TxtEspesor_Diametro").val("");
    $("#TxtTarifa").val("");
}