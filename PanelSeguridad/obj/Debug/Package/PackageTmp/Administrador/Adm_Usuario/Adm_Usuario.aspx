<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Sasif_menu.Master"
    CodeBehind="Adm_Usuario.aspx.vb" Inherits="PanelSeguridad.Adm_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Adm_Usuario.js" type="text/javascript"></script>
    <script src="Adm_UsuarioTrasaccionsAjax.js" type="text/javascript"></script>
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
                            <div id="container_TUser">
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="TablaDatos">
                    <tr>
                        <td id="TD_ID">
                            Usuario
                        </td>
                        <td id="TD_TID">
                            <input type="text" id="Txt_ID" title="Llave Primaria" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="ImgID"
                                src="../../images/error.png" />
                        </td>
                        <td id="TD_name">
                            Nombre
                        </td>
                        <td id="TD_Tname">
                            <input type="text" id="TxtName" title="Nombre" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img1"
                                src="../../images/error.png" />
                        </td>
                    </tr>
                    <tr>
                        <td id="TD_document">
                            Documento
                        </td>
                        <td id="TD_Tdocument">
                            <input type="text" id="TxtDocument" title="Documento" class="solo-numero" />
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img2"
                                src="../../images/error.png" />
                        </td>
                        <td id="TD_rol">
                            Rol
                        </td>
                        <td id="TD_Trol">
                            <select id="DDLRol" class="SelectPerson" title="Rol">
                            </select>
                            <img alt="error" title="" style="padding-left: 1em; height: 21px; width: 21px;" id="Img3"
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
