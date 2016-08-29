<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Sasif.Master"
    CodeBehind="CambioPassword.aspx.vb" Inherits="PanelSeguridad.CambioPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Scripts/Dialog/jquery-ui.js" type="text/javascript"></script>
    <script src="CambioPassword.js" type="text/javascript"></script>
    <script src="../SasifMaster.js" type="text/javascript"></script>
    <link href="../css/css_login.css" rel="stylesheet" type="text/css" />
    <link href="../css/Dialog/jquery-ui.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="Container_title">
        <h2 id="titulo_login">
            CAMBIO DE CONTRASEÑA</h2>
    </div>
    <div id="marco_CC">
        <table id="TablaContraseña">
            <tr>
                <td id="Lbluser">
                    Nombre de Usuario
                </td>
            </tr>
            <tr>
                <td id="TdUser">
                </td>
            </tr>
            <tr>
                <td id="LblPassword">
                    Digite Contraseña
                </td>
            </tr>
            <tr>
                <td id="TdPassword">
                    <input id="TxtPassword" title="Digite Contraseña" type="password" name="password"
                        style="width: 80%;" /><img alt="error" title="" style="padding-left: 1em; height: 21px;
                            width: 21px;" id="E1" src="../images/error.png" /><img alt="sucess" title="" style="padding-left: 1em;
                                height: 21px; width: 21px;" id="S1" src="../images/success.png" />
                </td>
            </tr>
            <tr>
                <td id="TdHelpPassword">
                </td>
            </tr>
            <tr>
                <td id="lblConfirmPassword">
                    Confirme Contraseña
                </td>
            </tr>
            <tr>
                <td id="TdConfirmPassword">
                    <input id="txtConfirmPassword" title="Digite Nuevamente la Contraseña" type="password" />
                    <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="E2"
                        src="../images/error.png" />
                    <img alt="sucess" title="" style="padding-left: 1em; height: 21px; width: 21px;"
                        id="S2" src="../images/success.png" />
                </td>
            </tr>
            <tr>
                <td id="TdHelpConfirmPassword">
                </td>
            </tr>
            <%--<tr>
                    <td id="TdCheck">
                        <input type="checkbox" id="show" />
                        <label id="LblShow" for="show">
                            Mostrar password.</label>
                    </td>
                </tr>--%>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td id="TdControl" colspan="2" style="text-align: center;">
                    <input id="BtnCambiar" type="button" value="Cambiar" style="width: 40%;" class="BtnPerson" />
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
                    <img alt="error" id="DE" src="../images/error.png" />
                    <img alt="success" id="SE" src="../images/success.png" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input id="BtnExit" type="button" value="Salir" style="width: 40%;" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
