Imports Newtonsoft.Json

Public Class Adm_RolesAjax
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
                    Consulta_Roles()

                Case "crear"
                    InsertRol()

                Case "modificar"
                    UpdateLRol()

                Case "elimina"
                    DeleteRol()
            End Select

        End If

    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla ROLES (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Roles()

        Dim SQL_Rol As New Adm_RolesSQLClass
        Dim ObjListRol As New List(Of Adm_RolesClass)

        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListRol = SQL_Rol.Read_AllRoles(vl_S_filtro, vl_S_opcion, vl_S_contenido)
        Response.Write(JsonConvert.SerializeObject(ObjListRol.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Roles (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertRol()

        Dim objRol As New Adm_RolesClass
        Dim SQL_Rol As New Adm_RolesSQLClass
        

        Dim ObjListRol As New List(Of Adm_RolesClass)
        Dim result As String
        Dim vl_s_IDxiste As String

        objRol.Rol_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objRol.Rol_ID)

        If vl_s_IDxiste = 0 Then

            objRol.Descripcion = Request.Form("descripcion")
            objRol.Sigla = Request.Form("sigla")

            ObjListRol.Add(objRol)

            result = SQL_Rol.InsertRol(objRol)

            Dim SQL_link As New Adm_LinksSQLClass
            Dim objLink As New Adm_LinksClass
            Dim objListLink As New List(Of Adm_LinksClass)
            Dim resultLink As String

            objLink.Link_ID = Request.Form("ID")
            objLink.Descripcion = Request.Form("descripcion")
            objLink.Estado = "1"

            objListLink.Add(objLink)

            resultLink = SQL_link.InsertLinks(objLink)

            If resultLink <> "Exito" Then
                result = "Error"
            End If

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que cambia el estado a inhabilitado en la tabla ROLES (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DeleteRol()

        Dim objRol As New Adm_RolesClass
        Dim SQL_Rol As New Adm_RolesSQLClass
        Dim ObjListRol As New List(Of Adm_RolesClass)
        Dim result As String

        objRol.Rol_ID = Request.Form("ID")

        ObjListRol.Add(objRol)

        result = SQL_Rol.DeleteRol(objRol)
        Response.Write(result)
    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla ROLES (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateLRol()

        Dim objRol As New Adm_RolesClass
        Dim SQL_Rol As New Adm_RolesSQLClass
        Dim ObjListRol As New List(Of Adm_RolesClass)
        Dim result As String

        objRol.Rol_ID = Request.Form("ID")
        objRol.Descripcion = Request.Form("descripcion")
        objRol.Sigla = Request.Form("sigla")

        ObjListRol.Add(objRol)

        result = SQL_Rol.UpdateRol(objRol)

        Response.Write(result)

    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_links As New Adm_LinksSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_links.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("ROLES", vp_S_ID, "R_Rol_ID", "")
        Return result

    End Function

#End Region

End Class