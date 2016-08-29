<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA_ASIGNACION/Sasif_menu.Master"
    CodeBehind="CGA_VDesbordamiento.aspx.vb" Inherits="PanelSeguridad.CGA_VDesbordamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="CGA_VDesbordamiento.js" type="text/javascript"></script>
    <script src="CGA_VDesbordamientoTrasaccionsAjax.js" type="text/javascript"></script>
    <link href="../../css/css_login.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <link href="../../css/Dialog/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <link href="../../css/css_form.css" rel="stylesheet" type="text/css" />
    <link href="../../css/datatables/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="../../css/custom/charge.css" rel="stylesheet" type="text/css" />
        <link href="../../css/css_controles.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="Container_title_Form">
        <table id="Tabla_Title_form">
            <tr>
                <td id="Title_form">
                </td>
                <td id="image_exit">
                    <input id="BtnExit" type="button"  value="X" onclick="btnSalir();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Marco_DES">
        <div id="Marco_btn_Form">
            <input id="BtnShearh" type="button"  value="Consulta" onclick="HabilitarPanel('buscar');" />
            <input id="BtnCreate" type="button"  value="Crear" onclick="HabilitarPanel('crear');" />
            <input id="BtnUpdate" type="button"  value="Actualizar" onclick="HabilitarPanel('modificar');" />
            <input id="BtnDelete" type="button"  value="Eliminar" onclick="HabilitarPanel('eliminar');" />
        </div>
        <div id="Marco_trabajo_Form">
            <div id="Container_controls">
                <table id="TablaConsulta_DES">
                    <tr>
                        <td id="TD1">
                            <select id="DDLColumns" >
                            </select>
                        </td>
                        <td id="TD2">
                            <input id="TxtRead" type="text" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ESelect"
                                src="../../images/error.png" />
                        </td>
                        <td colspan="4" align="center" id="TD3">
                            <input id="BtnRead" type="button"  value="Buscar" onclick="BtnConsulta();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="container_TVDesbordamiento">
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="TablaDatos">
                    <tr>
                        <td id="Centro" style="width: 130px;">
                            Centro
                        </td>
                        <td style="width: 185px;">
                            <select id="DDLCentro" >
                            </select>
                            <img alt="error" title="" style="height: 21px; width: 21px;" id="Img2" src="../../images/error.png" />
                        </td>
                        <td id="TD6">
                            Grupo Maquina
                        </td>
                        <td id="TD7">
                            <select id="DDLGprMaquina" >
                            </select>
                            <img alt="error" title="" style="height: 21px; width: 21px;" id="Img3" src="../../images/error.png" />
                        </td>
                        <td id="TD8">
                            Maquina
                        </td>
                        <td id="TD9">
                            <select id="DDLMaquina" >
                            </select>
                            <img alt="error" title="" style="height: 21px; width: 21px;" id="Img5" src="../../images/error.png" />
                        </td>
                    </tr>
                    <tr>
                        <td id="Td4" style="width: 130px;">
                            Desbordamiento 1
                        </td>
                        <td style="width: 185px;">
                            <select id="DDLD1" >
                            </select>
                            <img alt="error" title="" style="height: 21px; width: 21px;" id="Img6" src="../../images/error.png" />
                        </td>
                        <td id="TD5">
                            Desbordamiento 2
                        </td>
                        <td id="TD10">
                            <select id="DDLD2" >
                            </select>
                            <img alt="error" title="" style="height: 21px; width: 21px;" id="Img7" src="../../images/error.png" />
                        </td>
                        <td id="TD11">
                            Desbordamiento 3
                        </td>
                        <td id="TD12">
                            <select id="DDLD3" >
                            </select>
                            <img alt="error" title="" style="height: 21px; width: 21px;" id="Img8" src="../../images/error.png" />
                        </td>
                    </tr>
                    <tr>
                        <td id="Td13" style="width: 130px;">
                            Desbordamiento 4
                        </td>
                        <td style="width: 185px;">
                            <select id="DDLD4" >
                            </select>
                        </td>
                        <td id="TD14">
                            Desbordamiento 5
                        </td>
                        <td id="TD15">
                            <select id="DDLD5" >
                            </select>
                        </td>
                        <td id="TD16">
                            Desbordamiento 6
                        </td>
                        <td id="TD17">
                            <select id="DDLD6" >
                            </select>
                        </td>
                    </tr>
                    <tr>
                         <td id="TD18">
                            Desbordamiento 7
                        </td>
                        <td id="TD19" colspan="5">
                            <select id="DDLD7" >
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" id="TD_Button">
                            <input id="Btnguardar" type="button"  value="Guardar" onclick="BtnCrear();" />
                        </td>
                    </tr>
                </table>
            </div>
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
                    <input id="BtnExitD" type="button" value="Salir" style="width: 40%;" onclick="x();"
                         />
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
                    <input id="BtnElimin" type="button"  value="Confirmar" onclick="BtnElimina();" />
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
</asp:Content>
