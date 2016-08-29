Imports Newtonsoft.Json

Public Class CGA_GrpMaquinaAjax
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
                    Consulta_GRPMaquinas()

                Case "crear"
                    InsertGRPMaquinas()

                Case "modificar"
                    UpdateGRPMaquinas()

                Case "elimina"
                    EraseGRPMaquinas()
            End Select

        End If

    End Sub


#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla GRPMaquinas (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_GRPMaquinas()

        Dim SQL_GRPMaquinas As New CGA_GrpMaquinaSQLClass
        Dim ObjListGRPMaquinas As New List(Of CGA_GrpMaquinaClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListGRPMaquinas = SQL_GRPMaquinas.Read_AllGrpMaquina(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListGRPMaquinas Is Nothing Then

            Dim objGRPMaquinas As New CGA_GrpMaquinaClass
            ObjListGRPMaquinas = New List(Of CGA_GrpMaquinaClass)

            objGRPMaquinas.Descripcion = ""
            objGRPMaquinas.FechaActualizacion = ""
            objGRPMaquinas.Usuario = ""

            ObjListGRPMaquinas.Add(objGRPMaquinas)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListGRPMaquinas.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla GRPMaquinas (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertGRPMaquinas()

        Dim objGRPMaquinas As New CGA_GrpMaquinaClass
        Dim SQL_GRPMaquinas As New CGA_GrpMaquinaSQLClass
        Dim ObjListGRPMaquinas As New List(Of CGA_GrpMaquinaClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objGRPMaquinas.Maquina_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objGRPMaquinas.Maquina_ID)

        If vl_s_IDxiste = 0 Then

            objGRPMaquinas.Descripcion = Request.Form("descripcion")
            objGRPMaquinas.FechaActualizacion = Date.Now
            objGRPMaquinas.Usuario = Request.Form("user")

            ObjListGRPMaquinas.Add(objGRPMaquinas)

            result = SQL_GRPMaquinas.InsertGrpMaquina(objGRPMaquinas)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla GRPMaquinas (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateGRPMaquinas()

        Dim objGRPMaquinas As New CGA_GrpMaquinaClass
        Dim SQL_GRPMaquinas As New CGA_GrpMaquinaSQLClass
        Dim ObjListGRPMaquinas As New List(Of CGA_GrpMaquinaClass)

        Dim result As String

        objGRPMaquinas.Maquina_ID = Request.Form("ID")
        objGRPMaquinas.Descripcion = Request.Form("descripcion")
        objGRPMaquinas.FechaActualizacion = Date.Now
        objGRPMaquinas.Usuario = Request.Form("user")

        ObjListGRPMaquinas.Add(objGRPMaquinas)

        result = SQL_GRPMaquinas.UpdateGrpMaquina(objGRPMaquinas)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla GRPMaquinas (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseGRPMaquinas()

        Dim objGRPMaquinas As New CGA_GrpMaquinaClass
        Dim SQL_GRPMaquinas As New CGA_GrpMaquinaSQLClass
        Dim ObjListGRPMaquinas As New List(Of CGA_GrpMaquinaClass)

        Dim result As String

        objGRPMaquinas.Maquina_ID = Request.Form("ID")
        ObjListGRPMaquinas.Add(objGRPMaquinas)

        result = SQL_GRPMaquinas.EraseGrpMaquina(objGRPMaquinas)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_GRPMaquinas As New CGA_GrpMaquinaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_GRPMaquinas.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_GRP_MAQUINAS", vp_S_ID, "GRP_Maquina_ID", "")
        Return result

    End Function

#End Region

End Class