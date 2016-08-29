<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Sasif_menu.Master"
    CodeBehind="Adm_ResetUser.aspx.vb" Inherits="PanelSeguridad.Adm_ResetUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="Adm_ResetUser.js" type="text/javascript"></script>
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
    <div id="marco_RC">
        <table id="TablaContraseña">
            <tr>
                <td id="TD_ID">
                    Digite Usuario
                </td>
            </tr>
            <tr>
                <td id="TD_TID">
                    <input type="text" id="Txt_ID" title="Llave Primaria" />
                    <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ImgID"
                        src="../../images/error.png" />
                </td>
            </tr>
            <tr>
                <td id="TD_tipo">
                    Estado
                </td>
            </tr>
            <tr>
                <td id="TD_Ttipo">
                    <select id="DDLTipo" class="SelectPerson">
                        <option value="-1">Seleccione...</option>
                        <option value="1">Habilitado</option>
                        <option value="2">Deshabilitado</option>
                    </select>
                    <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img2"
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
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input id="BtnExitD" type="button" value="Salir" style="width: 40%;" onclick="x();" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
