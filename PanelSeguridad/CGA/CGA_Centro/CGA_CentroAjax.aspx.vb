Imports Newtonsoft.Json

Public Class CGA_CentroAjax
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
                    Consulta_Centro()

                Case "crear"
                    InsertCentro()

                Case "modificar"
                    UpdateCentro()

                Case "elimina"
                    EraseCentro()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla centro (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Centro()

        Dim SQL_Centro As New CGA_CentroSQLClass
        Dim ObjListCentro As New List(Of CGA_CentroClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListCentro = SQL_Centro.Read_AllCentro(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListCentro Is Nothing Then

            Dim objCentro As New CGA_CentroClass
            ObjListCentro = New List(Of CGA_CentroClass)

            objCentro.Descripcion = ""
            objCentro.Descripcion_Planta = ""
            objCentro.FechaActualizacion = ""
            objCentro.Usuario = ""

            ObjListCentro.Add(objCentro)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListCentro.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Centro (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertCentro()

        Dim objCentro As New CGA_CentroClass
        Dim SQL_Centro As New CGA_CentroSQLClass
        Dim ObjListCentro As New List(Of CGA_CentroClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objCentro.Centro_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objCentro.Centro_ID)

        If vl_s_IDxiste = 0 Then

            objCentro.Descripcion = Request.Form("descripcion")
            objCentro.Descripcion_Planta = Request.Form("descripcionPlanta")
            objCentro.FechaActualizacion = Date.Now
            objCentro.Usuario = Request.Form("user")

            ObjListCentro.Add(objCentro)

            result = SQL_Centro.InsertCentro(objCentro)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Centro (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateCentro()

        Dim objCentro As New CGA_CentroClass
        Dim SQL_Centro As New CGA_CentroSQLClass
        Dim ObjListCentro As New List(Of CGA_CentroClass)

        Dim result As String

        objCentro.Centro_ID = Request.Form("ID")
        objCentro.Descripcion = Request.Form("descripcion")
        objCentro.Descripcion_Planta = Request.Form("descripcionPlanta")
        objCentro.FechaActualizacion = Date.Now
        objCentro.Usuario = Request.Form("user")

        ObjListCentro.Add(objCentro)

        result = SQL_Centro.UpdateCentro(objCentro)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Centro (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseCentro()

        Dim objCentro As New CGA_CentroClass
        Dim SQL_Centro As New CGA_CentroSQLClass
        Dim ObjListCentro As New List(Of CGA_CentroClass)

        Dim result As String

        objCentro.Centro_ID = Request.Form("ID")
        ObjListCentro.Add(objCentro)

        result = SQL_Centro.EraseCentro(objCentro)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Centro As New CGA_CentroSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Centro.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_CENTROS", vp_S_ID, "C_Centro_ID", "")
        Return result

    End Function

#End Region

End Class