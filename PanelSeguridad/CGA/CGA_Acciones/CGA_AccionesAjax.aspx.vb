Imports Newtonsoft.Json

Public Class CGA_AccionesAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "consulta"
                    Consulta_Acciones()

                Case "crear"
                    InsertAcciones()

                Case "modificar"
                    UpdateAcciones()

                Case "elimina"
                    EraseAcciones()
            End Select

        End If

    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Acciones (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Acciones()

        Dim SQL_Acciones As New CGA_AccionesSQLClass
        Dim ObjListAcciones As New List(Of CGA_AccionesClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListAcciones = SQL_Acciones.Read_AllAcciones(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListAcciones Is Nothing Then

            Dim objAcciones As New CGA_AccionesClass
            ObjListAcciones = New List(Of CGA_AccionesClass)

            objAcciones.Descripcion = ""
            objAcciones.FechaActualizacion = ""
            objAcciones.Usuario = ""

            ObjListAcciones.Add(objAcciones)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListAcciones.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Acciones (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertAcciones()

        Dim objAcciones As New CGA_AccionesClass
        Dim SQL_Acciones As New CGA_AccionesSQLClass
        Dim ObjListAcciones As New List(Of CGA_AccionesClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objAcciones.Accion_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objAcciones.Accion_ID)

        If vl_s_IDxiste = 0 Then

            objAcciones.Descripcion = Request.Form("descripcion")
            objAcciones.FechaActualizacion = Date.Now
            objAcciones.Usuario = Request.Form("user")

            ObjListAcciones.Add(objAcciones)

            result = SQL_Acciones.InsertAcciones(objAcciones)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Acciones (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateAcciones()

        Dim objAcciones As New CGA_AccionesClass
        Dim SQL_Acciones As New CGA_AccionesSQLClass
        Dim ObjListAcciones As New List(Of CGA_AccionesClass)

        Dim result As String

        objAcciones.Accion_ID = Request.Form("ID")
        objAcciones.Descripcion = Request.Form("descripcion")
        objAcciones.FechaActualizacion = Date.Now
        objAcciones.Usuario = Request.Form("user")

        ObjListAcciones.Add(objAcciones)

        result = SQL_Acciones.UpdateAcciones(objAcciones)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Acciones (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseAcciones()

        Dim objAcciones As New CGA_AccionesClass
        Dim SQL_Acciones As New CGA_AccionesSQLClass
        Dim ObjListAcciones As New List(Of CGA_AccionesClass)

        Dim result As String

        objAcciones.Accion_ID = Request.Form("ID")
        ObjListAcciones.Add(objAcciones)

        result = SQL_Acciones.EraseAcciones(objAcciones)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Acciones As New CGA_AccionesSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Acciones.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_ACCIONES", vp_S_ID, "Ac_Accion_ID", "")
        Return result

    End Function

#End Region

End Class