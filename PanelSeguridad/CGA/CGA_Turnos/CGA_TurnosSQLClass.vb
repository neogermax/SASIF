Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_TurnosSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla turnos parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllTurnos(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListTurno As New List(Of CGA_TurnosClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT T_Turno_ID, T_Descripcion, T_HoraInicio, T_Tiempo, T_FechaActualizacion, T_Usuario FROM CGA_TURNOS")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT T_Turno_ID, T_Descripcion, T_HoraInicio, T_Tiempo, T_FechaActualizacion, T_Usuario FROM CGA_TURNOS")
            Else
                sql.Append("SELECT T_Turno_ID, T_Descripcion, T_HoraInicio, T_Tiempo, T_FechaActualizacion, T_Usuario FROM CGA_TURNOS " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListTurno = conex.ObjLoad_All(StrQuery, "Turnos")

        Return ObjListTurno

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo TURNO (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Turno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertTurnos(ByVal vp_Obj_Turno As CGA_TurnosClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_TURNOS (" & _
            "T_Turno_ID," & _
            "T_Descripcion," & _
            "T_HoraInicio," & _
            "T_Tiempo," & _
            "T_FechaActualizacion," & _
            "T_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Turno.Turno_ID & "',")
        sql.AppendLine("'" & vp_Obj_Turno.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Turno.HoraInicio & "',")
        sql.AppendLine("'" & vp_Obj_Turno.Tiempo & "',")
        sql.AppendLine("'" & vp_Obj_Turno.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Turno.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del turno (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Turno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateTurnos(ByVal vp_Obj_Turno As CGA_TurnosClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_TURNOS SET " & _
                       " T_Descripcion ='" & vp_Obj_Turno.Descripcion & "', " & _
                       " T_HoraInicio =" & vp_Obj_Turno.HoraInicio & ", " & _
                       " T_Tiempo ='" & vp_Obj_Turno.Tiempo & "', " & _
                       " T_FechaActualizacion ='" & vp_Obj_Turno.FechaActualizacion & "', " & _
                       " T_Usuario ='" & vp_Obj_Turno.Usuario & "' " & _
                       " WHERE T_Turno_ID = '" & vp_Obj_Turno.Turno_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion de la turno (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Turno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseTurnos(ByVal vp_Obj_Turno As CGA_TurnosClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE CGA_TURNOS WHERE T_Turno_ID = '" & vp_Obj_Turno.Turno_ID & "'")
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
    ''' funcion que trae el listado de turnos para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listTurnos(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListTurno As New List(Of CGA_TurnosClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objTurno As New CGA_TurnosClass
            'cargamos datos sobre el objeto de login
            objTurno.Turno_ID = ReadConsulta.GetValue(0)
            objTurno.Descripcion = ReadConsulta.GetString(1)
            objTurno.HoraInicio = ReadConsulta.GetValue(2)
            objTurno.Tiempo = ReadConsulta.GetValue(3)
            objTurno.FechaActualizacion = ReadConsulta.GetString(4)
            objTurno.Usuario = ReadConsulta.GetString(5)

            'agregamos a la lista
            ObjListTurno.Add(objTurno)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListTurno

    End Function

#End Region

End Class
