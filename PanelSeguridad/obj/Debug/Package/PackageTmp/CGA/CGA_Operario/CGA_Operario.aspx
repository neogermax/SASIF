<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA/Sasif_menu.Master"
    CodeBehind="CGA_Operario.aspx.vb" Inherits="PanelSeguridad.CGA_Operario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="CGA_Operario.js" type="text/javascript"></script>
    <script src="CGA_OperarioTrasaccionsAjax.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <link href="../../css/css_login.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../../Scripts/Dialog/jquery-ui.js" type="text/javascript"></script>
    <link href="../../css/Dialog/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../css/css_form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="Container_title_Form">
        <table id="Tabla_Title_form">
            <tr>
                <td id="Title_form">
                    Gestion Paginas
                </td>
                <td id="image_exit">
                    <input id="BtnExit" type="button" class="BtnPerson_x" value="X" onclick="btnSalir();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Marco_link">
        <div id="Marco_btn_Form">
            <input id="BtnShearh" type="button" class="BtnPerson" value="Consulta" onclick="HabilitarPanel('buscar');" />
            <input id="BtnCreate" type="button" class="BtnPerson" value="Crear" onclick="HabilitarPanel('crear');" />
            <input id="BtnUpdate" type="button" class="BtnPerson" value="Actualizar" onclick="HabilitarPanel('modificar');" />
            <input id="BtnDelete" type="button" class="BtnPerson" value="Eliminar" onclick="HabilitarPanel('eliminar');" />
        </div>
        <div id="Marco_trabajo_Form">
            <div id="Container_controls">
                <table id="TablaConsulta">
                    <tr>
                        <td id="TD1">
                            <select id="DDLColumns" class="SelectPerson">
                            </select>
                        </td>
                        <td id="TD2">
                            <input id="TxtRead" type="text" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ESelect"
                                src="../../images/error.png" />
                        </td>
                        <td colspan="4" align="center" id="TD3">
                            <input id="BtnRead" type="button" class="BtnPerson" value="Buscar" onclick="BtnConsulta();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="container_TOperario">
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="TablaDatos">
                    <tr>
                        <td id="TD_ID">
                            Codigo Operario
                        </td>
                        <td id="TD_TID">
                            <input type="text" id="Txt_ID" title="Llave Primaria" maxlength="4" class="solo-numero" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ImgID"
                                src="../../images/error.png" />
                        </td>
                        <td id="TD_Document">
                            Identificación
                        </td>
                        <td id="TD_TDocument">
                            <input type="text" id="TxtDocument" maxlength="17" title="Identificación" class="solo-numero" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img1"
                                src="../../images/error.png" />
                        </td>
                    </tr>
                    <tr>
                        <td id="TD_Nombre">
                            Nombre
                        </td>
                        <td id="TD_TNombre">
                            <input type="text" id="TxtNombre" maxlength="40" title="Nombre del operario" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img2"
                                src="../../images/error.png" />
                        </td>
                        <td id="TD_Centro">
                            Centro
                        </td>
                        <td id="TD_TCentro">
                            <select id="DDLCentro" class="SelectPerson">
                            </select>
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img3"
                                src="../../images/error.png" />
                        </td>
                    </tr>
                    <tr>
                        <td id="TD_CCosto">
                            Centro de Costo
                        </td>
                        <td id="TD_TCCosto">
                            <select id="DDLCCosto" class="SelectPerson">
                            </select>
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img5"
                                src="../../images/error.png" />
                        </td>
                        <td id="TD_Area">
                            Area
                        </td>
                        <td id="TD_TArea">
                            <select id="DDLArea" class="SelectPerson">
                            </select>
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img6"
                                src="../../images/error.png" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" id="TD_Button">
                            <input id="Btnguardar" type="button" class="BtnPerson" value="Guardar" onclick="BtnCrear();" />
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
                    <img alt="error" id="DE" src="../../images/error.png" />
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
                    <input id="BtnElimin" type="button" class="BtnPerson" value="Confirmar" onclick="BtnElimina();" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
