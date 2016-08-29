Imports Newtonsoft.Json

Public Class CGA_CentroCostoAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "consulta"
                    Consulta_CentroCostos()

                Case "crear"
                    InsertCentroCostos()

                Case "modificar"
                    UpdateCentroCostos()

                Case "elimina"
                    EraseCentroCostos()
            End Select

        End If
    End Sub


#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla CentroCostos (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_CentroCostos()

        Dim SQL_CentroCostos As New CGA_CentroCostosQLClass
        Dim ObjListCentroCostos As New List(Of CGA_CentroCostoClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListCentroCostos = SQL_CentroCostos.Read_AllCentroCosto(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListCentroCostos Is Nothing Then

            Dim objCentroCostos As New CGA_CentroCostoClass
            ObjListCentroCostos = New List(Of CGA_CentroCostoClass)

            objCentroCostos.Descripcion = ""
            objCentroCostos.FechaActualizacion = ""
            objCentroCostos.Usuario = ""

            ObjListCentroCostos.Add(objCentroCostos)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListCentroCostos.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla CentroCostos (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertCentroCostos()

        Dim objCentroCostos As New CGA_CentroCostoClass
        Dim SQL_CentroCostos As New CGA_CentroCostosQLClass
        Dim ObjListCentroCostos As New List(Of CGA_CentroCostoClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objCentroCostos.CentroCosto_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objCentroCostos.CentroCosto_ID)

        If vl_s_IDxiste = 0 Then

            objCentroCostos.Descripcion = Request.Form("descripcion")
            objCentroCostos.FechaActualizacion = Date.Now
            objCentroCostos.Usuario = Request.Form("user")

            ObjListCentroCostos.Add(objCentroCostos)

            result = SQL_CentroCostos.InsertCentroCosto(objCentroCostos)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla CentroCostos (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateCentroCostos()

        Dim objCentroCostos As New CGA_CentroCostoClass
        Dim SQL_CentroCostos As New CGA_CentroCostosQLClass
        Dim ObjListCentroCostos As New List(Of CGA_CentroCostoClass)

        Dim result As String

        objCentroCostos.CentroCosto_ID = Request.Form("ID")
        objCentroCostos.Descripcion = Request.Form("descripcion")
        objCentroCostos.FechaActualizacion = Date.Now
        objCentroCostos.Usuario = Request.Form("user")

        ObjListCentroCostos.Add(objCentroCostos)

        result = SQL_CentroCostos.UpdateCentroCosto(objCentroCostos)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla CentroCostos (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseCentroCostos()

        Dim objCentroCostos As New CGA_CentroCostoClass
        Dim SQL_CentroCostos As New CGA_CentroCostosQLClass
        Dim ObjListCentroCostos As New List(Of CGA_CentroCostoClass)

        Dim result As String

        objCentroCostos.CentroCosto_ID = Request.Form("ID")
        ObjListCentroCostos.Add(objCentroCostos)

        result = SQL_CentroCostos.EraseCentroCosto(objCentroCostos)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_CentroCostos As New CGA_CentroCostosQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_CentroCostos.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_CENTRO_COSTO", vp_S_ID, "CC_CentroCosto_ID", "")
        Return result

    End Function

#End Region

End Class