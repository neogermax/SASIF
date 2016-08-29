Imports Newtonsoft.Json

Public Class SasifMasterAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "encabezado"
                    ListEncabezado()

            End Select
        End If

    End Sub

    ''' <summary>
    ''' funcion que trae los datos del aplicativo
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ListEncabezado()

        Dim SQLGeneral As New GeneralSQLClass
        Dim ObjListGeneral As New List(Of Droplist_Class)
        Dim vl_S_ID As String = Request.Form("ID")

        ObjListGeneral = SQLGeneral.ChargeEncabezado(vl_S_ID)
        Response.Write(JsonConvert.SerializeObject(ObjListGeneral.ToArray()))


    End Sub

End Class