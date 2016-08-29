Imports Newtonsoft.Json

Public Class CGA_OperarioAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "Carga_Centro"
                    Carga_Centro()

                Case "Centro_Costo"
                    Carga_CentroCosto()

                Case "Carga_Area"
                    Carga_Area()

                Case "consulta"
                    Consulta_Operario()

                Case "crear"
                    InsertOperario()

                Case "modificar"
                    UpdateOperario()

                Case "elimina"
                    EraseOperario()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Operario (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Operario()

        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListOperario As New List(Of CGA_OperarioClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListOperario = SQL_Operario.Read_AllOperario(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListOperario Is Nothing Then

            Dim objOperario As New CGA_OperarioClass
            ObjListOperario = New List(Of CGA_OperarioClass)

            objOperario.Nombre = ""
            objOperario.FechaActualizacion = ""
            objOperario.Usuario = ""

            ObjListOperario.Add(objOperario)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListOperario.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Operario (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertOperario()

        Dim objOperario As New CGA_OperarioClass
        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListOperario As New List(Of CGA_OperarioClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objOperario.Operario_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objOperario.Operario_ID)

        If vl_s_IDxiste = 0 Then

            objOperario.Identificacion = Request.Form("identificacion")
            objOperario.Nombre = Request.Form("nombre")
            objOperario.Centro_ID = Request.Form("centro")
            objOperario.CentroCosto_ID = Request.Form("centrocosto")
            objOperario.Area_ID = Request.Form("area")
            objOperario.FechaActualizacion = Date.Now
            objOperario.Usuario = Request.Form("user")

            ObjListOperario.Add(objOperario)

            result = SQL_Operario.InsertOperario(objOperario)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Operario (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateOperario()

        Dim objOperario As New CGA_OperarioClass
        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListOperario As New List(Of CGA_OperarioClass)

        Dim result As String

        objOperario.Operario_ID = Request.Form("ID")
        objOperario.Identificacion = Request.Form("identificacion")
        objOperario.Nombre = Request.Form("nombre")
        objOperario.Centro_ID = Request.Form("centro")
        objOperario.CentroCosto_ID = Request.Form("centrocosto")
        objOperario.Area_ID = Request.Form("area")
        objOperario.FechaActualizacion = Date.Now
        objOperario.Usuario = Request.Form("user")
       
        ObjListOperario.Add(objOperario)

        result = SQL_Operario.UpdateOperario(objOperario)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Operario (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseOperario()

        Dim objOperario As New CGA_OperarioClass
        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListOperario As New List(Of CGA_OperarioClass)

        Dim result As String

        objOperario.Operario_ID = Request.Form("ID")
        ObjListOperario.Add(objOperario)

        result = SQL_Operario.EraseOperario(objOperario)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL consulta
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Operario.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_Centro()

        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_Operario.ReadCharge_DDL_Centro()
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro De Costos
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_CentroCosto()

        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_Operario.ReadCharge_DDL_CentroCosto()
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro De Costos
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_Area()

        Dim SQL_Operario As New CGA_OperarioSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_Operario.ReadCharge_DDL_Area()
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

        result = SQL_General.ReadExist("CGA_OPERARIOS", vp_S_ID, "O_Operario_ID", "")
        Return result

    End Function

#End Region

End Class