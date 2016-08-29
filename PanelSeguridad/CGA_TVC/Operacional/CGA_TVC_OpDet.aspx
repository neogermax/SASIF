<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA_TVC/Sasif_menu.Master"
    CodeBehind="CGA_TVC_OpDet.aspx.vb" Inherits="PanelSeguridad.CGA_TVC_OpDet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="CGA_TVC_OpDet.js" type="text/javascript"></script>
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
        <table id="TablaDatos_TVCDet">
            <tr>
                <td id="Orden">
                    Número Orden
                </td>
                <td id="LblOrden">
                </td>
                <td id="Operacion">
                    Operación
                </td>
                <td id="LblOperacion">
                </td>
                <td id="FLiber">
                    Fecha liberación
                </td>
                <td id="LblFLiber">
                </td>
                <td id="LblSemaforo">
                    <input type='text' id='Circulo' readonly='readonly' class='circulo' />
                </td>
            </tr>
            <tr>
                <td id="FCier">
                    Fecha Cierre
                </td>
                <td id="LblFCier">
                </td>
                <td id="FDespacho">
                    Fecha Ent. Despacho
                </td>
                <td id="LblFDespacho">
                </td>
                <td id="Estado">
                    Estado
                </td>
                <td id="LblEstado">
                </td>
                <td id="Td1">
                </td>
            </tr>
        </table>
        <br />
        <div id="container_TTVCDET">
        </div>
        <br />
        <div id="control" style="text-align: center;">
            <input id="BtnCreate" type="button" value="Nueva Causal" onclick="BtnNewCausal();" />
            <input id="BtnRetro" type="button" value="Regresar TVC" onclick="BtnRetry();" />
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
    <div id="dialog_NewCausal" title="Nueva Causal">
        <table id="TNewCausal">
            <tr>
                <td style="width: 170px;">
                    ID Operario
                </td>
                <td>
                    <select id="DDLOperario" class="select_large">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img1" src="../../images/error.png" />
                </td>
            </tr>
            <tr>
                <td>
                    Turno
                </td>
                <td>
                    <select id="DDLTurno">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img2" src="../../images/error.png" />
                </td>
            </tr>
            <tr>
                <td>
                    Causal SAP
                </td>
                <td>
                    <select id="DDLCausalSAP" class="select_medium">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img3" src="../../images/error.png" />
                </td>
            </tr>
            <tr>
                <td>
                    Causal
                </td>
                <td>
                    <select id="DDLCausal" class="select_medium">
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img5" src="../../images/error.png" />
                </td>
            </tr>
            <tr>
                <td>
                    Observación Operario
                </td>
                <td>
                    <textarea id='TxtObserOpe' rows="3" cols="60"></textarea>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img6" src="../../images/error.png" />
                </td>
            </tr>
            <tr>
                <td>
                    Descripción Del Analista
                </td>
                <td>
                    <textarea id='TxtDescripAnalis' rows="3" cols="60"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    Acción
                </td>
                <td>
                    <select id="DDLAccion" class="select_large">
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha de entrega de la acción
                </td>
                <td>
                    <input type="text" id="DateAccion" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Area Responsable
                </td>
                <td>
                    <select id="DDLArea">
                    </select>
                </td>
            </tr>
            <tr>
                <td id="P_Estado">
                    Estado
                </td>
                <td id="D_Estado">
                    <select id="DDLEstado">
                        <option value="-1">Seleccione...</option>
                        <option value="1">En Proceso</option>
                        <option value="2">Terminado</option>
                        <option value="3">Eliminado</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                    </p>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <input id="BtnSave" type="button" value="Guardar" onclick="BtnCrear();" />
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
