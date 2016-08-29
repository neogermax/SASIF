Imports Newtonsoft.Json

Public Class CGA_CausalesAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "consulta"
                    Consulta_Causales()

                Case "crear"
                    InsertCausales()

                Case "modificar"
                    UpdateCausales()

                Case "elimina"
                    EraseCausales()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Causales (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Causales()

        Dim SQL_Causales As New CGA_CausalesSQLClass
        Dim ObjListCausales As New List(Of CGA_CausalesClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListCausales = SQL_Causales.Read_AllCausales(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListCausales Is Nothing Then

            Dim objCausales As New CGA_CausalesClass
            ObjListCausales = New List(Of CGA_CausalesClass)

            objCausales.Descripcion = ""
            objCausales.FechaActualizacion = ""
            objCausales.Usuario = ""

            ObjListCausales.Add(objCausales)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListCausales.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Causales (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertCausales()

        Dim objCausales As New CGA_CausalesClass
        Dim SQL_Causales As New CGA_CausalesSQLClass
        Dim ObjListCausales As New List(Of CGA_CausalesClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objCausales.Causal_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objCausales.Causal_ID)

        If vl_s_IDxiste = 0 Then

            objCausales.Descripcion = Request.Form("descripcion")
            objCausales.Tipo = Request.Form("tipo")
            objCausales.FechaActualizacion = Date.Now
            objCausales.Usuario = Request.Form("user")

            ObjListCausales.Add(objCausales)

            result = SQL_Causales.InsertCausales(objCausales)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Causales (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateCausales()

        Dim objCausales As New CGA_CausalesClass
        Dim SQL_Causales As New CGA_CausalesSQLClass
        Dim ObjListCausales As New List(Of CGA_CausalesClass)

        Dim result As String

        objCausales.Causal_ID = Request.Form("ID")
        objCausales.Descripcion = Request.Form("descripcion")
        objCausales.Tipo = Request.Form("tipo")
        objCausales.FechaActualizacion = Date.Now
        objCausales.Usuario = Request.Form("user")

        ObjListCausales.Add(objCausales)

        result = SQL_Causales.UpdateCausales(objCausales)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Causales (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseCausales()

        Dim objCausales As New CGA_CausalesClass
        Dim SQL_Causales As New CGA_CausalesSQLClass
        Dim ObjListCausales As New List(Of CGA_CausalesClass)

        Dim result As String

        objCausales.Causal_ID = Request.Form("ID")
        ObjListCausales.Add(objCausales)

        result = SQL_Causales.EraseCausales(objCausales)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Causales As New CGA_CausalesSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Causales.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_CAUSALES", vp_S_ID, "Ca_Causal_ID", "")
        Return result

    End Function

#End Region


End Class