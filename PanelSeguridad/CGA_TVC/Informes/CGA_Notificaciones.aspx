<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CGA_TVC/Sasif_menu.Master"
    CodeBehind="CGA_Notificaciones.aspx.vb" Inherits="PanelSeguridad.CGA_Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../SasifMaster.js" type="text/javascript"></script>
    <script src="../SasifMaster_Cosult.js" type="text/javascript"></script>
    <script src="CGA_Notificaciones.js" type="text/javascript"></script>
    <script src="CGA_NotificacionesTrasaccionsAjax.js" type="text/javascript"></script>
    <link href="../../css/css_login.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-1.10.2.js" type="text/javascript"></script>
    <link href="../../css/Dialog/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Dialog/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/Dialog/datepicker.js" type="text/javascript"></script>
    <link href="../../css/css_form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="Container_title_TVC">
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
    <div id="Marco_TVC">
        <table id="TablaDatos_TVC">
            <tr>
                <td id="Centro" style="width: 130px;">
                    Centro
                </td>
                <td style="width: 185px;">
                    <select id="DDLCentro" >
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img1" src="../../images/error.png" />
                </td>
                <td id="Planta" style="width: 150px;">
                    Planta
                </td>
                <td id="lblPlanta">
                </td>
            </tr>
            <tr>
                <td id="TD4">
                    Grupo Maquina
                </td>
                <td id="TD5">
                    <select id="DDLGprMaquina" >
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img2" src="../../images/error.png" />
                </td>
                <td id="TD_ID">
                    Maquina
                </td>
                <td id="TD1">
                    <select id="DDLMaquina" >
                    </select>
                    <img alt="error" title="" style="height: 21px; width: 21px;" id="Img3" src="../../images/error.png" />
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
            </tr>
            <tr>
                <td colspan="4">
                    <p>
                    </p>
                </td>
            </tr>
            <tr>
                <td id="TD_btnConsuta" colspan="6">
                    <input id="BtnShearch" type="button"  value="Consultar" onclick="BtnConsulta();" />
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
    <div id="dialog_VerDetalle" title="Detalle">
        <table id="TNewCausal">
            <tr>
                <td>
                    Centro
                </td>
                <td id="D_Centro">
                </td>
            </tr>
            <tr>
                <td>
                    Puesto De trabajo
                </td>
                <td id="D_Maquina">
                </td>
            </tr>
          <tr>
                <td style="width: 170px;">
                    Orden
                </td>
                <td id="D_Orden">
                </td>
            </tr>
        </table>
      <br />
        <div id="BloqueConsult">
            <h3>
                Consulta ZPP078</h3>
            <div>
                <table id="TZPP078">
                    <tr>
                        <td style="width: 170px;">
                            Nº de Pedido
                        </td>
                        <td id="ZPP078_1">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Posicion
                        </td>
                        <td id="ZPP078_2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre
                        </td>
                        <td id="ZPP078_3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nº Personal
                        </td>
                        <td id="ZPP078_4">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre Personal
                        </td>
                        <td id="ZPP078_5">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            F. Inicio
                        </td>
                        <td id="ZPP078_6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Duración en Minutos
                        </td>
                        <td id="ZPP078_7">
                        </td>
                    </tr>
                </table>
            </div>
            <h3>
                Consulta ZPP079</h3>
            <div>
                <table id="TZPP079">
                    <tr>
                        <td style="width: 170px;">
                            Nº Personal
                        </td>
                        <td id="ZPP079_1">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre Personal
                        </td>
                        <td id="ZPP079_2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            F. Inicio
                        </td>
                        <td id="ZPP079_3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Duración en Minutos
                        </td>
                        <td id="ZPP079_4">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Motivo
                        </td>
                        <td id="ZPP079_5">
                        </td>
                    </tr>
                </table>
            </div>
            <h3>
                Consulta KSB1</h3>
            <div>
                 <table id="TKSB1">
                    <tr>
                        <td style="width: 170px;">
                            Centro De costo
                        </td>
                        <td id="KSB1_1">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nº Orden
                        </td>
                        <td id="KSB1_2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nº Personal
                        </td>
                        <td id="KSB1_3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            F. Contabilidad
                        </td>
                        <td id="KSB1_4">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ctd Registro
                        </td>
                        <td id="KSB1_5">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cl Actual
                        </td>
                        <td id="KSB1_6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario
                        </td>
                        <td id="KSB1_7">
                        </td>
                    </tr>
                </table>
           
            </div>
        </div>
    </div>
</asp:Content>
