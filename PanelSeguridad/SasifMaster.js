$(document).ready(function () {

    fecha();

});


//funcion para capturar la fecha
function fecha() {
    var d = new Date();

    var month = d.getMonth() + 1;
    var day = d.getDate();

    var output = d.getFullYear() + '/' +
    (('' + month).length < 2 ? '0' : '') + month + '/' +
    (('' + day).length < 2 ? '0' : '') + day;
    $("#Hours").html(output);

}

//cargar combos
function charge_CatalogList(objCatalog, nameList, selector) {

    var objList = $('[id$=' + nameList + ']');
    //recorremos para llenar el combo de
    for (itemArray in objCatalog) {
        objList[0].options[itemArray] = new Option(objCatalog[itemArray].descripcion, objCatalog[itemArray].ID);
    };
    //validamos si el combo lleva seleccione y posicionamos en el
    if (selector == 1) {
        $("#" + nameList).append("<option value='-1'>Seleccione...</option>");
        $("#" + nameList + " option[value= '-1'] ").attr("selected", true);
    }

    if (selector == 2) {
        $("#" + nameList).append("<option value='-1'>Seleccione...</option>");
        $("#" + nameList).append("<option value='0'>Todos</option>");
        $("#" + nameList + " option[value= '-1'] ").attr("selected", true);
    }

    //actualizamos el combo
    $("#" + nameList).trigger("liszt:updated");

}


function carga_eventos(str_objeto) {

    //funcion para las ventanas emergentes
    $("#" + str_objeto).dialog({
        autoOpen: false,
        modal: true,
        width: 400,
        height: 400,
        overlay: {
            opacity: 0.5,
            background: "black"
        },
        show: {
            effect: 'fade',
            duration: 2000
        },
        hide: {
            effect: 'fade',
            duration: 1000
        },
        open: function (event, ui) { $(".ui-dialog-titlebar-close", ui.dialog).hide(); }
    });

    $(document).ajaxStart(function () {
        $("#" + str_objeto).dialog("open");
    }).ajaxStop(function () {
        $("#" + str_objeto).dialog("close");
    });
}

//formato de miles en cliente
function dinner_format(input) {
    var valida = 0;
    var num = input.value.replace(/\./g, "");
    if (!isNaN(num)) {
        num = num.toString().split("").reverse().join("").replace(/(?=\d*\.?)(\d{3})/g, "$1.");
        num = num.split("").reverse().join("").replace(/^[\.]/, "");
        input.value = num;
    }
    else {
        valida = 1;
        input.value = input.value.replace(/[^\d\.]*/g, "");
    }
    return valida;
}
