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

    //actualizamos el combo
    $("#" + nameList).trigger("liszt:updated");

}
