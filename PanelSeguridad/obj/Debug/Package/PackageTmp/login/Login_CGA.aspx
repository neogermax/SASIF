<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Sasif.Master"
    CodeBehind="Login_CGA.aspx.vb" Inherits="PanelSeguridad.Login_CGA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Login.js" type="text/javascript"></script>
    <script src="../SasifMaster.js" type="text/javascript"></script>
    <link href="../css/css_login.css" rel="stylesheet" type="text/css" />
      <script src="../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Scripts/Dialog/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/Dialog/jquery-ui.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="Container_title" >
        <h2 id="titulo_login">
            CUENTA DE USUARIOS</h2>
    </div>
    <div id="marco">
        <table id="TablaRegistro">
            <tr>
                <td id="Lbluser">
                    Nombre de Usuario
                </td>
            </tr>
            <tr>
                <td id="TdUser">
                    <input type="text" id="TxtUser" title="Digite Usuario" />
                    <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="EUser"
                        src="../images/error.png" />
                </td>
            </tr>
            <tr>
                <td id="TdHelpUser">
                </td>
            </tr>
            <tr>
                <td id="LblPassword">
                    Contraseña
                </td>
            </tr>
            <tr>
                <td id="TdPassword">
                    <input id="TxtPassword" type="password" title="Digite Contraseña" />
                    <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="EPassword"
                        src="../images/error.png" />
                </td>
            </tr>
            <tr>
                <td id="TdHelpPassword">
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td id="TdControl" style="text-align: center;">
                    <input id="BtnIngresar" type="button" value="Entrar" style="width: 40%;" class="BtnPerson" />
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
                    <img alt="error" id="DE" src="../images/alert.png" />
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
