//funcion que valida si es año bisiesto o no
function Valida_Bisiesto() {

    var Fecha = $("#DateStart").val();
    var valida = "N";

    Array_Date = Fecha.split(" ");

    Mes = Array_Date[0];
    Year = Array_Date[1];

    var R_4 = parseInt(Year) % 4;
    var R_100 = parseInt(Year) % 100;
    var M_100 = R_100 % 4;

    var R_400 = parseInt(Year) % 400;
    var M_400 = R_400 % 4;

    if (R_4 == 0) {
        if (M_100 == 0) {
            if (M_400 == 0) {
                valida = "Y";
            }
        }
    }
    return valida;
}

var TES = 0;

//valida repetidos en los turnos
function T_Val(pos) {
    $("#DDLTurno_" + pos).change(function () {
        var flag_R;
        var value = $(this).val();
        flag_R = Val_Rep($(this), "T" + pos);
        if (flag_R == 0) {
            for (IT in ArrayTTurnos) {
                if (value == ArrayTTurnos[IT].Turno_ID) {

                    $("#L_I" + pos).html(ArrayTTurnos[IT].HoraInicio);

                    var CalcHora;
                    var HI = parseInt(ArrayTTurnos[IT].HoraInicio);
                    TES = parseInt(ArrayTTurnos[IT].Tiempo);

                    var Hora_1 = 0;
                    var Hora_2 = 0;
                    var Flag_type = 0;

                    if (HI > 16) {
                        Flag_type = 1;
                        for (I = HI; I < 24; I++) {
                            Hora_1 = Hora_1 + 1;
                        }

                        var C_for = TES - Hora_1;

                        for (I = 1; I <= C_for; I++) {
                            Hora_2 = Hora_2 + 1;
                        }

                        CalcHora = Hora_2;

                    }
                    else {
                        CalcHora = parseInt(ArrayTTurnos[IT].Tiempo) + HI;
                    }


                    $("#L_F" + pos).html(CalcHora);
                    $("#Txt_I" + pos).val(ArrayTTurnos[IT].HoraInicio);
                    $("#Txt_F" + pos).val(CalcHora);
                    $("#L_" + pos).html(ArrayTTurnos[IT].Tiempo);
                    SumHorasProg(pos);

                    TxT_val_I(pos, Flag_type);
                    TxT_val_F(pos, Flag_type);
                }
                else {
                    if (value == "-1") {
                        $("#L_" + pos).html(0);
                        $("#Txt_I" + pos).val("");
                        $("#Txt_F" + pos).val("");
                        SumHorasProg(pos);
                    }
                }
            }
        }
    });
}

function TxT_val_I(pos, type) {

    $("#Txt_I" + pos).focusout(function () {
        var C = $(this).val();
        var V_I = $("#L_I" + pos).html();
        var V_F = $("#L_F" + pos).html();

        var captura = parseInt(C);
        var validar_inicio = parseInt(V_I);
        var validar_final = parseInt(V_F);
        if (type != 1) {
            if (captura < validar_inicio || captura > validar_final) {
                $("#dialog").dialog("option", "title", "Atencion");
                $("#Mensaje_alert").text("Debe estar entre " + validar_inicio + " y las " + validar_final + " horas");
                $("#dialog").dialog("open");
                $("#DE").css("display", "none");
                $("#SE").css("display", "none");
                $("#WE").css("display", "block");
            }
            else {
                var exist = $("#Txt_F" + pos).val();
                if (exist != "") {
                    Count_Tiempo_Prog(pos, type);
                }
            }
        }
        else {

            if ((captura < validar_inicio || captura > 24) && (captura < 1 || captura > validar_final)) {
                $("#dialog").dialog("option", "title", "Atencion");
                $("#Mensaje_alert").text("Debe estar entre " + validar_inicio + " y las " + 24 + " horas");
                $("#dialog").dialog("open");
                $("#DE").css("display", "none");
                $("#SE").css("display", "none");
                $("#WE").css("display", "block");
            }
            else {
                var exist = $("#Txt_F" + pos).val();
                if (exist != "") {
                    Count_Tiempo_Prog(pos, type);
                }
            }
        }
    });
}

function TxT_val_F(pos, type) {
    $("#Txt_F" + pos).focusout(function () {

        var C = $(this).val();
        var V_I = $("#Txt_I" + pos).val();
        var V_F = $("#L_F" + pos).html();

        var captura = parseInt(C);
        var validar_inicio = parseInt(V_I);
        var validar_final = parseInt(V_F);

        if (type != 1) {
            if (captura < validar_inicio || captura > validar_final) {
                $("#dialog").dialog("option", "title", "Atencion");
                $("#Mensaje_alert").text("Debe estar entre " + validar_inicio + " y las " + validar_final + " horas");
                $("#dialog").dialog("open");
                $("#DE").css("display", "none");
                $("#SE").css("display", "none");
                $("#WE").css("display", "block");
            }
            else {
                Count_Tiempo_Prog(pos, type);
            }
        }
        else {
            if ((captura < validar_inicio || captura > 24) && (captura < 1 || captura > validar_final)) {
                $("#dialog").dialog("option", "title", "Atencion");
                $("#Mensaje_alert").text("Debe estar entre " + validar_inicio + " y las " + validar_final + " horas");
                $("#dialog").dialog("open");
                $("#DE").css("display", "none");
                $("#SE").css("display", "none");
                $("#WE").css("display", "block");
            }
            else {
                var exist = $("#Txt_F" + pos).val();
                if (exist != "") {
                    Count_Tiempo_Prog(pos, type);
                }
            }
        }
    });
}

function Count_Tiempo_Prog(pos, type) {

    var V_I = $("#Txt_I" + pos).val();
    var V_F = $("#Txt_F" + pos).val();
    var total_horas = 0;
    var F = parseInt(V_F);
    var Hora_1 = 0;
    var Hora_2 = 0;

    if (type != 1) {
        for (I = V_I; I < F; I++) {
            total_horas = total_horas + 1;
        }
    }
    else {

        for (I = V_I; I < 24; I++) {
            Hora_1 = Hora_1 + 1;
        }

        for (I = 1; I <= F; I++) {
            Hora_2 = Hora_2 + 1;
        }
      
        total_horas = Hora_1 + Hora_2;
    }

    $("#L_" + pos).html(total_horas);
    SumHorasProg(pos);
}


//valida repetidos en los desbordamientos
function Val_Rep(Obj, validando) {

    var padre = $(Obj).val();
    var hijo;
    var strhijo;
    var flag_R = 0;
    var cont = validando.substring(1, 2);
    for (var num = 1; num < 6; num++) {

        hijo = $("#DDLTurno_" + num).val();
        strhijo = "T" + num;
        if (padre != "-1") {
            if (padre == hijo && strhijo != validando) {
                flag_R = 1;
                $("#dialog").dialog("option", "title", "Cuidado");
                $("#Mensaje_alert").text("el Turno " + cont + " ya fue ingresado!");
                $("#dialog").dialog("open");
                $("#DE").css("display", "none");
                $("#SE").css("display", "none");
                $("#WE").css("display", "block");
            }
        }
    }
    return flag_R;
}


function SumHorasProg(pos) {

    var V1 = $("#L_1").html();
    var V2 = $("#L_2").html();
    var V3 = $("#L_3").html();
    var V4 = $("#L_4").html();
    var V5 = $("#L_5").html();
    var V6 = $("#L_6").html();

    HorasProgramadas = parseInt(V1) + parseInt(V2) + parseInt(V3) + parseInt(V4) + parseInt(V5) + parseInt(V6);

    if (HorasProgramadas > 24) {
        $("#dialog").dialog("option", "title", "Cuidado");
        $("#Mensaje_alert").text("solo se pueden 24 horas por dia!!");
        $("#dialog").dialog("open");
        $("#DE").css("display", "none");
        $("#SE").css("display", "none");
        $("#WE").css("display", "block");

        $("#Txt_I" + pos).val("");
        $("#Txt_F" + pos).val("");
        $("#L_I" + pos).html("");
        $("#L_F" + pos).html("");
        $("#DDLTurno_" + pos).val("-1");

        $("#L_" + pos).html(0);

        V1 = $("#L_1").html();
        V2 = $("#L_2").html();
        V3 = $("#L_3").html();
        V4 = $("#L_4").html();
        V5 = $("#L_5").html();
        V6 = $("#L_6").html();

        HorasProgramadas = parseInt(V1) + parseInt(V2) + parseInt(V3) + parseInt(V4) + parseInt(V5) + parseInt(V6);
    }

    $("#L_horas").html(HorasProgramadas);

}
