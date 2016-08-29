Public Class CambioPasswordAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "Cambiar"
                    CambioContraseña()
            End Select

        End If
    End Sub
    ''' <summary>
    ''' funcion que ejecuta el proceso de cambio de clave
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CambioContraseña()

        Dim vl_S_user, vl_S_password, vl_S_processUpdate As String
        Dim Encrip As New EncriptarClass
        Dim SQL_Login As New LoginSQLClass

        vl_S_user = Request.Form("user").ToString()
        vl_S_password = Request.Form("password").ToString()
        'llamamos al procedimiento de encripcion
        vl_S_password = Encrip.Encriptacion_MD5(vl_S_password)

        vl_S_processUpdate = SQL_Login.Update_ChagePassword(vl_S_user, vl_S_password)

        Response.Write(vl_S_processUpdate)
    End Sub

End Class