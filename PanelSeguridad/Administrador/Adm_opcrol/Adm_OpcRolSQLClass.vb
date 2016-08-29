Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Adm_OpcRolSQLClass

#Region "CRUD"

    ''' <summary>
    ''' crea la consulta para la tabla opcion perfil parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllOpcRol(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT OR_OPRol_ID,OR_Consecutivo, OR_Tipo, [OR_Subrol/rol], OR_Link_ID  FROM OPTION_ROL")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT OR_OPRol_ID,OR_Consecutivo, OR_Tipo, [OR_Subrol/rol], OR_Link_ID  FROM OPTION_ROL")
            Else
                sql.Append("SELECT OR_OPRol_ID,OR_Consecutivo, OR_Tipo, [OR_Subrol/rol], OR_Link_ID  FROM OPTION_ROL " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListOpcRol = conex.ObjLoad_All(StrQuery, "OpcRol")

        Return ObjListOpcRol

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de la nueva opcion rol (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_OpcRol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertOpcRol(ByVal vp_Obj_OpcRol As Adm_OpcRolClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT OPTION_ROL (" & _
            "OR_OPRol_ID," & _
            "OR_Consecutivo," & _
            "OR_Tipo," & _
            "[OR_Subrol/rol]," & _
            "OR_Link_ID" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_OpcRol.OPRol_ID & "',")
        sql.AppendLine("'" & vp_Obj_OpcRol.Consecutivo & "',")
        sql.AppendLine("'" & vp_Obj_OpcRol.Tipo & "',")
        sql.AppendLine("'" & vp_Obj_OpcRol.Subrol_rol & "',")
        sql.AppendLine("'" & vp_Obj_OpcRol.Link_ID & "')")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del opcion rol (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_OpcRol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateOpcRol(ByVal vp_Obj_OpcRol As Adm_OpcRolClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE OPTION_ROL SET " & _
                       " OR_Tipo ='" & vp_Obj_OpcRol.Tipo & "', " & _
                       " [OR_Subrol/rol] ='" & vp_Obj_OpcRol.Subrol_rol & "', " & _
                       " OR_Link_ID ='" & vp_Obj_OpcRol.Link_ID & "' " & _
                       " WHERE OR_OPRol_ID = '" & vp_Obj_OpcRol.OPRol_ID & "' AND OR_Consecutivo ='" & vp_Obj_OpcRol.Consecutivo & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion de la opcion rol (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_OpcRol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseOpcRol(ByVal vp_Obj_OpcRol As Adm_OpcRolClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE OPTION_ROL WHERE OR_OPRol_ID = '" & vp_Obj_OpcRol.OPRol_ID & "' AND OR_Consecutivo ='" & vp_Obj_OpcRol.Consecutivo & "'")
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
    ''' funcion que consulta el rol para el id de la tabla
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

    ''' <summary>
    ''' funcion que consulta el subrol
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DL_Subrol()

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT OR_Link_ID AS ID, L_Descripcion AS descripcion FROM OPTION_ROL OPR " & _
                   " INNER JOIN LINKS L ON L.L_Link_ID = OPR.OR_Link_ID " & _
                   " WHERE OR_Tipo = '1'")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' funcion que consulta los links existentes
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DL_Links(ByVal vp_S_tipo As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT L_Link_ID AS ID, L_Descripcion AS descripcion FROM LINKS ")

        If vp_S_tipo = 1 Then
            sql.Append(" WHERE l_LinkPag = '' ")
        Else
            sql.Append(" WHERE l_LinkPag <> '' ")
        End If


        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae el listado de opcion roles para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listOpcRol(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objOpcRol As New Adm_OpcRolClass
            'cargamos datos sobre el objeto de login
            objOpcRol.OPRol_ID = ReadConsulta.GetString(0)
            objOpcRol.Consecutivo = ReadConsulta.GetValue(1)
            objOpcRol.Tipo = ReadConsulta.GetString(2)
            objOpcRol.Subrol_rol = ReadConsulta.GetString(3)
            objOpcRol.Link_ID = ReadConsulta.GetString(4)

            'agregamos a la lista
            ObjListOpcRol.Add(objOpcRol)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListOpcRol

    End Function

#End Region

End Class
