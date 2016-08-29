Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Adm_UsuarioSQLClass

#Region "CRUD"

    ''' <summary>
    ''' crea la consulta para la tabla Usuarios parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllUser(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListUser As New List(Of Adm_UsuarioClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT U_Usuario_ID, U_Documento, U_Nombre, U_Rol_ID, U_Estado FROM USUARIOS")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT U_Usuario_ID, U_Documento, U_Nombre, U_Rol_ID, U_Estado FROM USUARIOS")
            Else
                sql.Append("SELECT U_Usuario_ID, U_Documento, U_Nombre, U_Rol_ID, U_Estado FROM USUARIOS " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListUser = conex.ObjLoad_All(StrQuery, "User")

        Return ObjListUser

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion del nuevo usuario (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_User"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertUser(ByVal vp_Obj_User As Adm_UsuarioClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT USUARIOS (" & _
            "U_Usuario_ID," & _
            "U_Documento," & _
            "U_Nombre," & _
            "U_Rol_ID," & _
            "U_password," & _
            "U_Estado" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & UCase(vp_Obj_User.Usuario_ID) & "',")
        sql.AppendLine("'" & vp_Obj_User.Documento & "',")
        sql.AppendLine("'" & vp_Obj_User.Nombre & "',")
        sql.AppendLine("'" & vp_Obj_User.Rol_ID & "',")
        sql.AppendLine("'" & vp_Obj_User.Password & "',")
        sql.AppendLine("'" & 1 & "')")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del usuario (UPDATE)
    ''' </summary>
    ''' <param name="vp_ObjUser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateUser(ByVal vp_ObjUser As Adm_UsuarioClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE USUARIOS SET " & _
                       " U_Documento ='" & vp_ObjUser.Documento & "', " & _
                       " U_Nombre ='" & vp_ObjUser.Nombre & "', " & _
                       " U_Rol_ID ='" & vp_ObjUser.Rol_ID & "' " & _
                        " WHERE U_Usuario_ID = '" & vp_ObjUser.Usuario_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para el estado del Usuario(DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_User"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteUser(ByVal vp_Obj_User As Adm_UsuarioClass)
        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder

        Dim StrQuery As String = ""

        sql.AppendLine("UPDATE USUARIOS SET " & _
                       " U_Estado = '" & 2 & "' " & _
                       " WHERE U_Usuario_ID = '" & vp_Obj_User.Usuario_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

#End Region

#Region "CONSULTAS DROP LIST"

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT T_IndexColumna As ID, T_Traductor As descripcion FROM TC_TABLAS " & _
                   " WHERE T_Tabla = '" & vp_S_Table & "' AND T_Param = '1' ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist


    End Function

    ''' <summary>
    ''' funcion que consulta el rol
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DL_Rol()

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT R_Rol_ID AS ID, R_Descripcion AS descripcion FROM ROLES ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

#End Region

#Region "CARGAR LISTAS"

  
    ''' <summary>
    ''' funcion que trae el listado de Usuarios para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listUSer(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListUser As New List(Of Adm_UsuarioClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objUser As New Adm_UsuarioClass
            'cargamos datos sobre el objeto de login
            objUser.Usuario_ID = ReadConsulta.GetString(0)
            objUser.Documento = ReadConsulta.GetValue(1)
            objUser.Nombre = ReadConsulta.GetString(2)
            objUser.Rol_ID = ReadConsulta.GetString(3)
            objUser.Estado = ReadConsulta.GetString(4)

            'agregamos a la lista
            ObjListUser.Add(objUser)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListUser

    End Function

#End Region

End Class
