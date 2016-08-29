Imports Newtonsoft.Json

Public Class CGA_ParetoAjax
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
                    Consulta_Pareto()

                Case "crear"
                    InsertPareto()

                Case "modificar"
                    UpdatePareto()

                Case "elimina"
                    ErasePareto()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Pareto (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Pareto()

        Dim SQL_Pareto As New CGA_ParetoSQLClass
        Dim ObjListPareto As New List(Of CGA_ParetoClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListPareto = SQL_Pareto.Read_AllPareto(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListPareto Is Nothing Then

            Dim objPareto As New CGA_ParetoClass
            ObjListPareto = New List(Of CGA_ParetoClass)

            objPareto.Descripcion = ""
            objPareto.FechaActualizacion = ""
            objPareto.Usuario = ""

            ObjListPareto.Add(objPareto)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListPareto.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Pareto (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertPareto()

        Dim objPareto As New CGA_ParetoClass
        Dim SQL_Pareto As New CGA_ParetoSQLClass
        Dim ObjListPareto As New List(Of CGA_ParetoClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objPareto.Pareto_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objPareto.Pareto_ID)

        If vl_s_IDxiste = 0 Then

            objPareto.Descripcion = Request.Form("descripcion")
            objPareto.FechaActualizacion = Date.Now
            objPareto.Usuario = Request.Form("user")

            ObjListPareto.Add(objPareto)

            result = SQL_Pareto.InsertPareto(objPareto)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Pareto (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdatePareto()

        Dim objPareto As New CGA_ParetoClass
        Dim SQL_Pareto As New CGA_ParetoSQLClass
        Dim ObjListPareto As New List(Of CGA_ParetoClass)

        Dim result As String

        objPareto.Pareto_ID = Request.Form("ID")
        objPareto.Descripcion = Request.Form("descripcion")
        objPareto.FechaActualizacion = Date.Now
        objPareto.Usuario = Request.Form("user")

        ObjListPareto.Add(objPareto)

        result = SQL_Pareto.UpdatePareto(objPareto)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Pareto (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ErasePareto()

        Dim objPareto As New CGA_ParetoClass
        Dim SQL_Pareto As New CGA_ParetoSQLClass
        Dim ObjListPareto As New List(Of CGA_ParetoClass)

        Dim result As String

        objPareto.Pareto_ID = Request.Form("ID")
        ObjListPareto.Add(objPareto)

        result = SQL_Pareto.ErasePareto(objPareto)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Pareto As New CGA_ParetoSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Pareto.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_Pareto", vp_S_ID, "P_Pareto_ID", "")
        Return result

    End Function

#End Region

End Class