Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Adm_RolesSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla roles parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllRoles(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListRoles As New List(Of Adm_RolesClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT R_Rol_ID, R_Descripcion, R_Sigla, R_Estado FROM ROLES")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT R_Rol_ID, R_Descripcion, R_Sigla, R_Estado FROM ROLES")
            Else
                sql.Append("SELECT R_Rol_ID, R_Descripcion, R_Sigla, R_Estado FROM ROLES " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListRoles = conex.ObjLoad_All(StrQuery, "Roles")

        Return ObjListRoles

    End Function

    ''' <summary>
    ''' funcion que crea el query para el estado del rol (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Rol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteRol(ByVal vp_Obj_Rol As Adm_RolesClass)
        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder

        Dim StrQuery As String = ""

        sql.AppendLine("UPDATE ROLES SET " & _
                       " R_Estado ='" & 2 & "' " & _
                       " WHERE R_Rol_ID = '" & vp_Obj_Rol.Rol_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del rol (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Rol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateRol(ByVal vp_Obj_Rol As Adm_RolesClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE ROLES SET " & _
                       " R_Descripcion ='" & vp_Obj_Rol.Descripcion & "', " & _
                       " R_Sigla ='" & vp_Obj_Rol.Sigla & "' " & _
                       " WHERE R_Rol_ID = '" & vp_Obj_Rol.Rol_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo rol (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_rol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertRol(ByVal vp_Obj_rol As Adm_RolesClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT ROLES (" & _
            "R_Rol_ID," & _
            "R_Descripcion," & _
            "R_Sigla," & _
            "R_Estado" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_rol.Rol_ID & "',")
        sql.AppendLine("'" & vp_Obj_rol.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_rol.Sigla & "', ")
        sql.AppendLine("'" & 1 & "' ) ")

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

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae el listado de ROLES para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listrol(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListRol As New List(Of Adm_RolesClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objRol As New Adm_RolesClass
            'cargamos datos sobre el objeto de login
            objRol.Rol_ID = ReadConsulta.GetString(0)
            objRol.Descripcion = ReadConsulta.GetString(1)
            objRol.Sigla = ReadConsulta.GetString(2)
            objRol.Estado = ReadConsulta.GetString(3)

            'agregamos a la lista
            ObjListRol.Add(objRol)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListRol

    End Function

#End Region

End Class
