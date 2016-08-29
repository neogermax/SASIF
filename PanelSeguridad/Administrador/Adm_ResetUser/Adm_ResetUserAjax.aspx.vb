Public Class Adm_ResetUserAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "reset"
                    ResetUser()

            End Select

        End If
    End Sub


    Protected Sub ResetUser()
        Dim objReset As New LoginClass
        Dim ObjListReset As New List(Of LoginClass)
        Dim Encriptar As New EncriptarClass
        Dim SQL_Reset As New LoginSQLClass
        Dim vl_s_IDxiste, result As String

        objReset.Name = Request.Form("ID")
        objReset.Estado = Request.Form("estado")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Existe(UCase(objReset.Name))

        If vl_s_IDxiste = 1 Then

            objReset.Password = Encriptar.Encriptacion_MD5(UCase(objReset.Name))
            ObjListReset.Add(objReset)
            result = SQL_Reset.Update_PasswordADM(objReset)
            Response.Write(result)
        Else
            result = "NO"
            Response.Write(result)
        End If

    End Sub

#Region "FUNCIONES"

    ''' <summary>
    ''' funcion que valida si el id esta en la BD
    ''' </summary>
    ''' <param name="vp_S_exist"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function Consulta_Existe(ByVal vp_S_exist As String)

        Dim SQL_General As New GeneralSQLClass
        Dim result As String

        result = SQL_General.ReadExist("USUARIOS", vp_S_exist, "U_Usuario_ID", "")
        Return result

    End Function

#End Region

End Class