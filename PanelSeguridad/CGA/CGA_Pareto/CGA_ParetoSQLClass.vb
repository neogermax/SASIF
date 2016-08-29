Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_ParetoSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Pareto parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllPareto(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListPareto As New List(Of CGA_ParetoClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT P_Pareto_ID, P_Descripcion, P_FechaActualizacion, P_Usuario FROM CGA_Pareto")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT P_Pareto_ID, P_Descripcion, P_FechaActualizacion, P_Usuario FROM CGA_Pareto")
            Else
                sql.Append("SELECT P_Pareto_ID, P_Descripcion, P_FechaActualizacion, P_Usuario FROM CGA_Pareto " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListPareto = conex.ObjLoad_All(StrQuery, "Pareto")

        Return ObjListPareto

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo Pareto (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Pareto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertPareto(ByVal vp_Obj_Pareto As CGA_ParetoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_Pareto (" & _
            "P_Pareto_ID," & _
            "P_Descripcion," & _
            "P_FechaActualizacion," & _
            "P_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Pareto.Pareto_ID & "',")
        sql.AppendLine("'" & vp_Obj_Pareto.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Pareto.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Pareto.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del Pareto (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Pareto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdatePareto(ByVal vp_Obj_Pareto As CGA_ParetoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_Pareto SET " & _
                       " P_Descripcion ='" & vp_Obj_Pareto.Descripcion & "', " & _
                       " P_FechaActualizacion ='" & vp_Obj_Pareto.FechaActualizacion & "', " & _
                       " P_Usuario ='" & vp_Obj_Pareto.Usuario & "' " & _
                       " WHERE P_Pareto_ID = '" & vp_Obj_Pareto.Pareto_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del Pareto (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Pareto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ErasePareto(ByVal vp_Obj_Pareto As CGA_ParetoClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE CGA_Pareto WHERE P_Pareto_ID = '" & vp_Obj_Pareto.Pareto_ID & "'")
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
    ''' funcion que trae el listado de Pareto para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listPareto(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListPareto As New List(Of CGA_ParetoClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objPareto As New CGA_ParetoClass
            'cargamos datos sobre el objeto de login
            objPareto.Pareto_ID = ReadConsulta.GetValue(0)
            objPareto.Descripcion = ReadConsulta.GetString(1)
            objPareto.FechaActualizacion = ReadConsulta.GetString(2)
            objPareto.Usuario = ReadConsulta.GetString(3)

            'agregamos a la lista
            ObjListPareto.Add(objPareto)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListPareto

    End Function


#End Region

End Class
