<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA_TVC/Sasif_menu.Master"
    CodeBehind="CGA_TVC_Inf.aspx.vb" Inherits="PanelSeguridad.CGA_TVC_Inf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="CGA_TVC_Inf.js" type="text/javascript"></script>
    <script src="CGA_TVC_InfTrasaccionsAjax.js" type="text/javascript"></script>
    <link href="../../css/css_login.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <link href="../../css/Dialog/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/Dialog/datepicker.js" type="text/javascript"></script>
    <link href="../../css/css_form.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="../../css/datatables/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script src="CGA_TVC_Inf_Calc.js" type="text/javascript"></script>
    <link href="../../css/custom/charge.css" rel="stylesheet" type="text/css" />
    <link href="../../css/css_controles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
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
                <td id="Centro" style="width: 130px;">
                    Centro
                </td>
                <td style="width: 185px;">
                    <select id="DDLCentro">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img1" src="../../images/error.png" />
                </td>
                <td id="Planta" style="width: 150px;">
                    Planta
                </td>
                <td id="lblPlanta">
                </td>
                <td id="TVC" style="width: 80px;">
                </td>
                <td id="TD_L_TVC">
                </td>
            </tr>
            <tr>
                <td id="TD4">
                    Grupo Maquina
                </td>
                <td id="TD5">
                    <select id="DDLGprMaquina">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img2" src="../../images/error.png" />
                </td>
                <td id="TD_ID">
                    Maquina
                </td>
                <td id="TD1">
                    <select id="DDLMaquina">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img3" src="../../images/error.png" />
                </td>
                <td id="TD6">
                </td>
                <td id="TD7">
                </td>
            </tr>
            <tr>
                <td id="inicial">
                    Fecha Inicial
                </td>
                <td>
                    <input type="text" id="DateStart" readonly="readonly" />
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img5" src="../../images/error.png" />
                </td>
                <td id="final">
                    Fecha final
                </td>
                <td>
                    <input type="text" id="DateEnd" readonly="readonly" />
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img6" src="../../images/error.png" />
                </td>
                <td id="TD2">
                </td>
                <td id="TD3">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <p>
                    </p>
                </td>
            </tr>
            <tr>
                <td id="TD_btnConsuta" colspan="6">
                    <input id="BtnShearch" type="button" value="Consultar" onclick="BtnConsulta();" />
                </td>
            </tr>
        </table>
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
    <div id="Dialog_Charge">
        <div class="cssload-circle">
            <div class="cssload-up">
                <div class="cssload-innera">
                </div>
            </div>
            <div class="cssload-down">
                <div class="cssload-innerb">
                </div>
            </div>
        </div>
        <h5>
            Procesando información espere un momento...</h5>
    </div>
    <div id="Dialog_Grid" title="xxxx">
        <table>
            <tr>
                <td style="width: 130px;">
                    Centro
                </td>
                <td id="D_Centro" style="width: 185px;">
                </td>
                <td style="width: 150px;">
                    Planta
                </td>
                <td id="D_Planta">
                </td>
                <td style="width: 80px; text-align: center">
                    T.V.C
                </td>
                <td id="D_TVC" style="text-align: center">
                </td>
            </tr>
            <tr>
                <td>
                    Grupo Maquina
                </td>
                <td id="D_GrpMaq">
                </td>
                <td>
                    Maquina
                </td>
                <td id="D_Maq">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div id="container_TTVC_INFO">
        </div>
    </div>
</asp:Content>
