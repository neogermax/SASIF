<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA_TVC/Sasif_menu.Master"
    CodeBehind="CGA_TVC_Op.aspx.vb" Inherits="PanelSeguridad.CGA_TVC_Op" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="CGA_TVC_Op.js" type="text/javascript"></script>
    <script src="CGA_TVC_OpTrasaccionsAjax.js" type="text/javascript"></script>
    <link href="../../css/css_login.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <link href="../../css/Dialog/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/Dialog/datepicker.js" type="text/javascript"></script>
    <link href="../../css/css_form.css" rel="stylesheet" type="text/css" />
    <link href="../../css/datatables/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
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
                <td id="LblCentro" style="width: 250px">
                </td>
                <td id="Planta" style="width: 120px">
                    Planta
                </td>
                <td id="lblPlanta" style="width: 150px">
                </td>
                <td id="TVC" style="width: 100px">
                    T.V.C
                </td>
                <td id="TD_L_TVC">
                </td>
            </tr>
            <tr>
                <td id="inicial">
                    Fecha Inicial
                </td>
                <td>
                    <input type="text" id="DateStart" readonly="readonly" />
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img1" src="../../images/error.png" />
                </td>
                <td id="final">
                    Fecha final
                </td>
                <td>
                    <input type="text" id="DateEnd" readonly="readonly" />
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img2" src="../../images/error.png" />
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
</asp:Content>
