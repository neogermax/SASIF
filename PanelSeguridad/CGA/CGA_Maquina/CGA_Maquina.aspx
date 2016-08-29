<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA/Sasif_menu.Master"
    CodeBehind="CGA_Maquina.aspx.vb" Inherits="PanelSeguridad.CGA_Maquina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="CGA_Maquina.js" type="text/javascript"></script>
    <script src="CGA_MaquinaTrasaccionsAjax.js" type="text/javascript"></script>
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
    <div id="Container_title_Form">
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
    <div id="Marco_link">
        <div id="Marco_btn_Form">
            <input id="BtnShearh" type="button" value="Consulta" onclick="HabilitarPanel('buscar');" />
            <input id="BtnCreate" type="button" value="Crear" onclick="HabilitarPanel('crear');" />
            <input id="BtnUpdate" type="button" value="Actualizar" onclick="HabilitarPanel('modificar');" />
            <input id="BtnDelete" type="button" value="Eliminar" onclick="HabilitarPanel('eliminar');" />
        </div>
        <div id="Marco_trabajo_Form">
            <div id="Container_controls">
                <table id="TablaConsulta">
                    <tr>
                        <td id="TD1">
                            <select id="DDLColumns">
                            </select>
                        </td>
                        <td id="TD2">
                            <input id="TxtRead" type="text" />
                            <span class="cssToolTip">
                                <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ESelect"
                                    src="../../images/error.png" />
                                <span></span></span>
                        </td>
                        <td colspan="4" align="center" id="TD3">
                            <input id="BtnRead" type="button" value="Buscar" onclick="BtnConsulta();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="container_TMaquina">
                            </div>
                        </td>
                    </tr>
                </table>
                <div id="Tab_Maquina">
                    <ul>
                        <li><a href="#tabs_General">Datos Principales</a></li>
                        <li><a href="#tabs_Tiempos">Fechas de Mantenimiento y No Disponibilidad</a></li>
                        <li><a href="#tabs_Dimenciones">Dimenciones y Tarifa</a></li>
                    </ul>
                    <div id="tabs_General">
                        <table id="TablaDatos_2">
                            <tr>
                                <td id="TD_ID">
                                    Codigo Maquina
                                </td>
                                <td id="TD_TID" style="width: 210px;">
                                    <input type="text" id="Txt_ID" title="Llave Primaria" maxlength="8" />
                                    <span class="cssToolTip">
                                        <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ImgID"
                                            src="../../images/error.png" />
                                        <span>Codigo maquina es obligatorio </span></span>
                                </td>
                                <td id="TD_descrip">
                                    Descripción
                                </td>
                                <td id="TD_Tdescrip" style="width: 210px;">
                                    <input type="text" id="TxtDescription" maxlength="40" title="Descripción" />
                                    <span class="cssToolTip">
                                        <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img1"
                                            src="../../images/error.png" />
                                        <span>La descripción de la maquina es obligatoria </span></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="TD_Centro">
                                    Centro
                                </td>
                                <td id="TD_TCentro">
                                    <select id="DDLCentro">
                                    </select>
                                    <span class="cssToolTip">
                                        <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img2"
                                            src="../../images/error.png" />
                                        <span>La seleccion del centro es obligatorio </span></span>
                                </td>
                                <td id="TD_GrpMaquina">
                                    Grupo de Maquina
                                </td>
                                <td id="TD_TGrpMaquina">
                                    <select id="DDLGrpMaquina">
                                    </select>
                                    <span class="cssToolTip">
                                        <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img3"
                                            src="../../images/error.png" />
                                        <span>La seleccion del grupo de maquina es obligatorio </span></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="TD_CECO">
                                    Centro de Costo
                                </td>
                                <td id="TD_TCECO">
                                    <select id="DLLCCosto">
                                    </select>
                                    <span class="cssToolTip">
                                        <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img5"
                                            src="../../images/error.png" />
                                        <span>La seleccion del centro de costo es obligatorio </span></span>
                                </td>
                                <td id="Tarifa">
                                    Tarifa
                                </td>
                                <td id="TTarifa">
                                    <input type="text" id="TxtTarifa" title="dimencion 1" maxlength="6" onkeyup="var valida = dinner_format(this); if(valida == 1){ $('#dialog').dialog('option', 'title', 'Atención'); $('#Mensaje_alert').text('Solo se permiten numeros'); $('#dialog').dialog('open'); $('#DE').css('display', 'block'); }"
                                        onchange="var valida = dinner_format(this); if(valida == 1){ $('#dialog').dialog('option', 'title', 'Atención'); $('#Mensaje_alert').text('Solo se permiten numeros'); $('#dialog').dialog('open'); $('#DE').css('display', 'block'); }" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center" id="TD_Button">
                                    <input id="Btnguardar" type="button" value="Guardar" onclick="BtnCrear();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="tabs_Tiempos">
                        <div id="Aco_Datos">
                            <h3>
                                Mantenimiento</h3>
                            <div>
                                <table id="Mante">
                                    <tr>
                                        <td id="FI_Mantenimiento">
                                            Fecha inicial
                                        </td>
                                        <td id="TFI_Mantenimiento">
                                            <input type="text" id="DateStart_Matenimiento" readonly="readonly" />
                                        </td>
                                        <td id="FF_Mantenimiento">
                                            Fecha final
                                        </td>
                                        <td id="TFF_Mantenimiento">
                                            <input type="text" id="DateEnd_Matenimiento" readonly="readonly" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="HI_Mantenimiento">
                                            Hora inicial
                                        </td>
                                        <td id="THI_Mantenimiento">
                                            <input type="text" id="TxtHI_Mantenimiento" maxlength="40" title="Descripción" />
                                        </td>
                                        <td id="HF_Mantenimiento">
                                            Hora final
                                        </td>
                                        <td id="THF_Mantenimiento">
                                            <input type="text" id="TxtHF_Mantenimiento" maxlength="40" title="Descripción" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <h3>
                                NO Disponibilidad</h3>
                            <div>
                                <table id="T_NO_disp">
                                    <tr>
                                        <td id="FI_NODisponibilidad">
                                            Fecha inicial
                                        </td>
                                        <td id="TFI_NODisponibilidad">
                                            <input type="text" id="DateStart_NODisponibilidad" readonly="readonly" />
                                        </td>
                                        <td id="FF_NODisponibilidad">
                                            Fecha final
                                        </td>
                                        <td id="TFF_NODisponibilidad">
                                            <input type="text" id="DateEnd_NODisponibilidad" readonly="readonly" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="HI_NODisponibilidad">
                                            Hora inicial
                                        </td>
                                        <td id="THI_NODisponibilidad">
                                            <input type="text" id="TxtHI_NODisponibilidad" maxlength="40" title="Descripción" />
                                        </td>
                                        <td id="HF_NODisponibilidad">
                                            Hora final
                                        </td>
                                        <td id="THF_NODisponibilidad">
                                            <input type="text" id="TxtHF_NODisponibilidad" maxlength="40" title="Descripción" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <table id="C_guardar">
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" id="TD4">
                                    <input id="Btnguardar_2" type="button" value="Guardar" onclick="BtnCrear();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="tabs_Dimenciones">
                        <table id="TablaDatos_3">
                            <tr>
                                <td id="Largo">
                                    Largo
                                </td>
                                <td id="TLargo">
                                    <input type="text" id="TxtLargo" title="dimencion 1" maxlength="6" />
                                </td>
                                <td id="Ancho">
                                    Ancho
                                </td>
                                <td id="TAncho">
                                    <input type="text" id="TxtAncho" maxlength="6" title="Descripción" />
                                </td>
                                <td id="Espesor_Diametro">
                                    Espesor ó Diametro
                                </td>
                                <td id="TEspesor_Diametro">
                                    <input type="text" id="TxtEspesor_Diametro" maxlength="6" title="Descripción" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" id="TD5" colspan="6">
                                    <input id="Btnguardar_3" type="button" value="Guardar" onclick="BtnCrear();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dialog" title="Basic dialog">
        <table width="100%">
            <tr>
                <td>
                    <p id="Mensaje_alert">
                    </p>
                </td>
                <td>
                    <img alt="error" id="DE" src="../../images/error_2.png" />
                    <img alt="success" id="SE" src="../../images/success.png" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
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
    <div id="dialog_Ver">
        <table id="TV_General">
            <tr>
                <td>
                    Centro
                </td>
                <td id="V_centro" class="Label_bold">
                </td>
            </tr>
            <tr>
                <td>
                    Grupo de Maquina
                </td>
                <td id="V_GRPMaquina" class="Label_bold">
                </td>
            </tr>
            <tr>
                <td>
                    Centro de Costo
                </td>
                <td id="V_CC" class="Label_bold">
                </td>
            </tr>
            <tr>
                <td>
                    Tarifa
                </td>
                <td id="V_Tarifa" class="Label_bold">
                </td>
            </tr>
        </table>
        <div id="Aco_Datos_complemento">
            <h3>
                Dimenciones</h3>
            <div>
                <table id="T_V_dimenciones">
                    <tr>
                        <td>
                            Largo
                        </td>
                        <td id="V_largo" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ancho
                        </td>
                        <td id="V_ancho" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Espesor / Diametro
                        </td>
                        <td id="V_ED" class="Label_bold">
                        </td>
                    </tr>
                </table>
            </div>
            <h3>
                Mantenimiento</h3>
            <div>
                <table id="TD_V_Mantenimiento">
                    <tr>
                        <td>
                            Fecha inicial
                        </td>
                        <td id="V_FI_M" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha final
                        </td>
                        <td id="V_FF_M" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hora inicial
                        </td>
                        <td id="V_HI_M" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hora final
                        </td>
                        <td id="V_HF_M" class="Label_bold">
                        </td>
                    </tr>
                </table>
            </div>
            <h3>
                No disponible</h3>
            <div>
                <table id="TD_V_NoDis">
                    <tr>
                        <td>
                            Fecha inicial
                        </td>
                        <td id="V_FI_ND" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha final
                        </td>
                        <td id="V_FF_ND" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hora inicial
                        </td>
                        <td id="V_HI_ND" class="Label_bold">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hora final
                        </td>
                        <td id="V_HF_ND" class="Label_bold">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
