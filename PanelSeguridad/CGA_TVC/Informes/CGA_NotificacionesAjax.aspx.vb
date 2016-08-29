Imports Newtonsoft.Json

Public Class CGA_NotificacionesAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "Datos_Notificacion"
                    DatosNotificacion()

            End Select
        End If

    End Sub

#Region "FUNCIONES"

    ''' <summary>
    ''' funcion que trae los datos para las notificaciones
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DatosNotificacion()

        Dim SQL_Notificacion As New CGA_NotificacionesSQLClass
        Dim ObjlistNotificacion As New List(Of CGA_NotificacionesClass)
        Dim ID_Centro As String = Request.Form("Centro")
        Dim ID_GprMaquina As String = Request.Form("GprMaquina")
        Dim ID_Maquina As String = Request.Form("Maquina")
        Dim StartDate As String = Request.Form("StartDate")
        Dim EndDate As String = Request.Form("EndDate")

        ObjlistNotificacion = SQL_Notificacion.GridNotificaciones(ID_Centro, ID_GprMaquina, ID_Maquina, StartDate.Replace("/", "-"), EndDate.Replace("/", "-"))
        Response.Write(JsonConvert.SerializeObject(ObjlistNotificacion.ToArray()))

    End Sub

#End Region


End Class