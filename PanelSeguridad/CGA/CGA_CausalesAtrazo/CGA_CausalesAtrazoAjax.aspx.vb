Imports Newtonsoft.Json

Public Class CGA_CausalesAtrazoAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "consulta"
                    Consulta_CausalesAtrazo()

                Case "crear"
                    InsertCausalesAtrazo()

                Case "modificar"
                    UpdateCausalesAtrazo()

                Case "elimina"
                    EraseCausalesAtrazo()
            End Select

        End If
    End Sub


#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla CausalesAtrazo (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_CausalesAtrazo()

        Dim SQL_CausalesAtrazo As New CGA_CausalesAtrazoSQLClass
        Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListCausalesAtrazo = SQL_CausalesAtrazo.Read_AllCausalesAtrazo(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListCausalesAtrazo Is Nothing Then

            Dim objCausalesAtrazo As New CGA_CausalesAtrazoClass
            ObjListCausalesAtrazo = New List(Of CGA_CausalesAtrazoClass)

            objCausalesAtrazo.CausalRaiz = ""
            objCausalesAtrazo.FechaActualizacion = ""
            objCausalesAtrazo.Usuario = ""

            ObjListCausalesAtrazo.Add(objCausalesAtrazo)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListCausalesAtrazo.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla CausalesAtrazo (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertCausalesAtrazo()

        Dim objCausalesAtrazo As New CGA_CausalesAtrazoClass
        Dim SQL_CausalesAtrazo As New CGA_CausalesAtrazoSQLClass
        Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objCausalesAtrazo.Causal_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objCausalesAtrazo.Causal_ID)

        If vl_s_IDxiste = 0 Then

            objCausalesAtrazo.CausalRaiz = Request.Form("causal")
            objCausalesAtrazo.Area_Responsable = Request.Form("area")
            objCausalesAtrazo.GerenciaResponsable = Request.Form("gerencia")
            objCausalesAtrazo.Comentario = Request.Form("comentario")

            objCausalesAtrazo.FechaActualizacion = Date.Now
            objCausalesAtrazo.Usuario = Request.Form("user")

            ObjListCausalesAtrazo.Add(objCausalesAtrazo)

            result = SQL_CausalesAtrazo.InsertCausalesAtrazo(objCausalesAtrazo)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla CausalesAtrazo (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateCausalesAtrazo()

        Dim objCausalesAtrazo As New CGA_CausalesAtrazoClass
        Dim SQL_CausalesAtrazo As New CGA_CausalesAtrazoSQLClass
        Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)

        Dim result As String

        objCausalesAtrazo.Causal_ID = Request.Form("ID")
        objCausalesAtrazo.CausalRaiz = Request.Form("causal")
        objCausalesAtrazo.Area_Responsable = Request.Form("area")
        objCausalesAtrazo.GerenciaResponsable = Request.Form("gerencia")
        objCausalesAtrazo.Comentario = Request.Form("comentario")
        objCausalesAtrazo.FechaActualizacion = Date.Now
        objCausalesAtrazo.Usuario = Request.Form("user")

        ObjListCausalesAtrazo.Add(objCausalesAtrazo)

        result = SQL_CausalesAtrazo.UpdateCausalesAtrazo(objCausalesAtrazo)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla CausalesAtrazo (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseCausalesAtrazo()

        Dim objCausalesAtrazo As New CGA_CausalesAtrazoClass
        Dim SQL_CausalesAtrazo As New CGA_CausalesAtrazoSQLClass
        Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)

        Dim result As String

        objCausalesAtrazo.Causal_ID = Request.Form("ID")
        ObjListCausalesAtrazo.Add(objCausalesAtrazo)

        result = SQL_CausalesAtrazo.EraseCausalesAtrazo(objCausalesAtrazo)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_CausalesAtrazo As New CGA_CausalesAtrazoSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_CausalesAtrazo.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

#End Region

#Region "FUNCIONES"

    ''' <summary>
    ''' funcion que valida si el id esta en la BD
    ''' </summary>
    ''' <param name="vp_S_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function Consulta_Repetido(ByVal vp_S_ID As String)

        Dim SQL_General As New GeneralSQLClass
        Dim result As String

        result = SQL_General.ReadExist("CGA_CAUSALES_ATRAZO", vp_S_ID, "CA_Causal_ID", "")
        Return result

    End Function

#End Region

End Class