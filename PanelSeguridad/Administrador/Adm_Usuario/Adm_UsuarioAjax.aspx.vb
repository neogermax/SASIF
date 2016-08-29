Imports Newtonsoft.Json

Public Class Adm_UsuarioAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "cargar_Rol"
                    Cargar_Rol()

                Case "consulta"
                    Consulta_User()

                Case "crear"
                    InsertUser()

                Case "modificar"
                    UpdateUser()

                Case "elimina"
                    DeleteUser()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Usuarios (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_User()

        Dim SQL_User As New Adm_UsuarioSQLClass
        Dim ObjListUser As New List(Of Adm_UsuarioClass)

        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListUser = SQL_User.Read_AllUser(vl_S_filtro, vl_S_opcion, vl_S_contenido)
        Response.Write(JsonConvert.SerializeObject(ObjListUser.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Usuarios (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertUser()

        Dim objUser As New Adm_UsuarioClass
        Dim SQL_User As New Adm_UsuarioSQLClass
        Dim ObjListUser As New List(Of Adm_UsuarioClass)
        Dim encriptar As New EncriptarClass

        Dim result As String
        Dim vl_s_IDxiste As String
        Dim vl_S_passEncrip As String


        objUser.Usuario_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objUser.Usuario_ID)

        If vl_s_IDxiste = 0 Then

            objUser.Nombre = UCase(Request.Form("nombre"))
            objUser.Documento = Request.Form("documento")
            objUser.Rol_ID = Request.Form("rolID")
          
            vl_S_passEncrip = UCase(Request.Form("ID"))
            vl_S_passEncrip = encriptar.Encriptacion_MD5(vl_S_passEncrip)
            objUser.Password = vl_S_passEncrip

            ObjListUser.Add(objUser)

            result = SQL_User.InsertUser(objUser)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Usuarios (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateUser()

        Dim objUser As New Adm_UsuarioClass
        Dim SQL_User As New Adm_UsuarioSQLClass
        Dim ObjListUser As New List(Of Adm_UsuarioClass)
        Dim encriptar As New EncriptarClass

        Dim result As String

        objUser.Usuario_ID = Request.Form("ID")
        objUser.Nombre = UCase(Request.Form("nombre"))
        objUser.Documento = Request.Form("documento")
        objUser.Rol_ID = Request.Form("rolID")
        ObjListUser.Add(objUser)

        result = SQL_User.UpdateUser(objUser)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla opcion roles (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DeleteUser()

        Dim objUser As New Adm_UsuarioClass
        Dim SQL_User As New Adm_UsuarioSQLClass
        Dim ObjListUser As New List(Of Adm_UsuarioClass)
        Dim result As String

        objUser.Usuario_ID = Request.Form("ID")

        ObjListUser.Add(objUser)

        result = SQL_User.DeleteUser(objUser)
        Response.Write(result)

    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL opcion rol
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_User As New Adm_UsuarioSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_User.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL rol
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cargar_Rol()

        Dim SQL_User As New Adm_UsuarioSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_User.ReadCharge_DL_Rol()
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

        result = SQL_General.ReadExist("USUARIOS", vp_S_ID, "U_Usuario_ID", "")
        Return result

    End Function

#End Region

End Class