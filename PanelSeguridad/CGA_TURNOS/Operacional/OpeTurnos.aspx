<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA_TURNOS/Sasif_menu.Master"
    CodeBehind="OpeTurnos.aspx.vb" Inherits="PanelSeguridad.OpeTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="OpeTurnos.js" type="text/javascript"></script>
    <script src="OpeTurnosTrasaccionsAjax.js" type="text/javascript"></script>
    <link href="../../css/css_login.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <link href="../../css/Dialog/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/Dialog/datepicker.js" type="text/javascript"></script>
    <link href="../../css/css_form.css" rel="stylesheet" type="text/css" />
    <link href="../../css/datatables/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="../../css/css_controles.css" rel="stylesheet" type="text/css" />
    <script src="OpeTurnos_Calc.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <style>
        .ui-datepicker-calendar
        {
            display: none;
        }
    </style>
    <div id="Container_title_TVC">
        <table id="Tabla_Title_form">
            <tr>
                <td id="Title_form">
                </td>
                <td id="image_exit">
                    <input id="BtnExit" type="button" value="X" onclick="btnSalir();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Marco_TVC">
        <table id="TablaDatos_TVC">
            <tr>
                <td id="TD_ID" style="width: 120px">
                    Maquina
                </td>
                <td id="TD1" colspan="4">
                    <select id="DDLMaquina" class="select_large">
                    </select>
                </td>
            </tr>
            <tr>
                <td id="Centro">
                    Centro
                </td>
                <td id="LblCentro" class="Label_bold" style="width: 250px">
                </td>
                <td id="Planta" style="width: 120px">
                    Planta
                </td>
                <td id="lblPlanta" class="Label_bold" style="width: 150px">
                </td>
            </tr>
            <tr>
                <td id="inicial">
                    Fecha Inicial
                </td>
                <td>
                    <input type="text" id="DateStart" readonly="readonly" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div id="container_TTVC">
        </div>
    </div>
    <div id="dialog" title="Basic dialog">
        <table>
            <tr>
                <td>
                    <p id="Mensaje_alert">
                    </p>
                </td>
                <td>
                    <img alt="error" id="DE" src="../../images/error_2.png" />
                    <img alt="success" id="SE" src="../../images/success.png" />
                    <img alt="Warning" id="WE" src="../../images/alert.png" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input id="BtnExitD" type="button" value="Salir" style="width: 40%;" onclick="x();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="dialog_eliminar" title="Basic dialog">
        <table>
            <tr>
                <td>
                    <p id="P1">
                        Desea eliminar el siguiente registro?
                    </p>
                </td>
                <td>
                    <img alt="Warning" id="Img4" src="../../images/alert.png" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input id="BtnElimin" type="button" value="Confirmar" onclick="BtnElimina();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Dialog_Grid">
        <table style="width: 100%;">
            <tr>
                <td>
                    Mes
                </td>
                <td id="L_Mes" class="Label_bold">
                </td>
                <td>
                    Año
                </td>
                <td id="L_Year" class="Label_bold">
                </td>
                <td id="L_Bisiesto" class="Label_bold">
                    Bisiesto
                </td>
                <td>
                    Nº dias habiles
                </td>
                <td id="L_habil" class="Label_bold">
                    Bisiesto
                </td>
            </tr>
        </table>
        <br />
        <div id="Container_OP_Turnos">
        </div>
        <br />
        <table style="width: 100%;">
            <tr>
                <td style="text-align: center;">
                    <input id="BtnSave" type="button" value="Guardar" onclick="BtnSave(State_Process);" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Dialog_Ope_turnos">
        <table>
            <tr>
                <th>
                    Turno
                </th>
                <th>
                    De
                </th>
                <th>
                    A
                </th>
                <th>
                    Hora de inicio
                </th>
                <th>
                    Hora final
                </th>
                <th>
                    Total Programado
                </th>
            </tr>
            <tr>
                <td style="width: 100px;">
                    <select id="DDLTurno_1">
                    </select>
                </td>
                <td id="L_I1" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td id="L_F1" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_I1" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_F1" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td id="L_1" class="Label_bold" style="width: 50px; text-align: center">
                    0
                </td>
            </tr>
            <tr>
                <td>
                    <select id="DDLTurno_2">
                    </select>
                </td>
                <td id="L_I2" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td id="L_F2" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_I2" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_F2" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td id="L_2" class="Label_bold" style="width: 50px; text-align: center">
                    0
                </td>
            </tr>
            <tr>
                <td>
                    <select id="DDLTurno_3">
                    </select>
                </td>
                <td id="L_I3" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td id="L_F3" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_I3" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_F3" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td id="L_3" class="Label_bold" style="width: 50px; text-align: center">
                    0
                </td>
            </tr>
            <tr>
                <td>
                    <select id="DDLTurno_4">
                    </select>
                </td>
                <td id="L_I4" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td id="L_F4" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_I4" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_F4" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td id="L_4" class="Label_bold" style="width: 50px; text-align: center">
                    0
                </td>
            </tr>
            <tr>
                <td>
                    <select id="DDLTurno_5">
                    </select>
                </td>
                <td id="L_I5" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td id="L_F5" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_I5" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_F5" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td id="L_5" class="Label_bold" style="width: 50px; text-align: center">
                    0
                </td>
            </tr>
            <tr>
                <td>
                    <select id="DDLTurno_6">
                    </select>
                </td>
                <td id="L_I6" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td id="L_F6" style="width: 50px; text-align: center" class="Label_bold">
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_I6" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td style="width: 50px; text-align: center">
                    <input type="text" id="Txt_F6" class="solo-numero" maxlength="2" style="width: 25px;" />
                </td>
                <td id="L_6" class="Label_bold" style="width: 50px; text-align: center">
                    0
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%; text-align: center;">
            <tr>
                <td id="TD_H_Prog">
                    Horas Programadas
                </td>
                <td id="L_horas" class="Label_bold">
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                    </p>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: center;">
                    <input id="BtnHoras" type="button" value="Guardar" onclick="BtnIngresar(State_Process);" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
