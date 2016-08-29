Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_AccionesSQLClass
#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Acciones parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllAcciones(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListAcciones As New List(Of CGA_AccionesClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT Ac_Accion_ID, Ac_Descripcion, Ac_FechaActualizacion, Ac_Usuario FROM CGA_ACCIONES")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT Ac_Accion_ID, Ac_Descripcion, Ac_FechaActualizacion, Ac_Usuario FROM CGA_ACCIONES")
            Else
                sql.Append("SELECT Ac_Accion_ID, Ac_Descripcion, Ac_FechaActualizacion, Ac_Usuario FROM CGA_ACCIONES " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListAcciones = conex.ObjLoad_All(StrQuery, "Acciones")

        Return ObjListAcciones

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo Acciones (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Acciones"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertAcciones(ByVal vp_Obj_Acciones As CGA_AccionesClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_ACCIONES (" & _
            "Ac_Accion_ID," & _
            "Ac_Descripcion," & _
            "Ac_FechaActualizacion," & _
            "Ac_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Acciones.Accion_ID & "',")
        sql.AppendLine("'" & vp_Obj_Acciones.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Acciones.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Acciones.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del Acciones (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Acciones"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateAcciones(ByVal vp_Obj_Acciones As CGA_AccionesClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_ACCIONES SET " & _
                       " Ac_Descripcion ='" & vp_Obj_Acciones.Descripcion & "', " & _
                       " Ac_FechaActualizacion ='" & vp_Obj_Acciones.FechaActualizacion & "', " & _
                       " Ac_Usuario ='" & vp_Obj_Acciones.Usuario & "' " & _
                       " WHERE Ac_Accion_ID = '" & vp_Obj_Acciones.Accion_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del Acciones (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Acciones"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseAcciones(ByVal vp_Obj_Acciones As CGA_AccionesClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
        'Dim ExistOperario As String

        'ExistOperario = SQL_general.ReadExist("CGA_OPERARIOS", vp_Obj_Acciones.Acciones_ID, "O_Acciones_ID", "")

        'If ExistOperario = "0" Then

        sql.AppendLine("DELETE CGA_ACCIONES WHERE Ac_Accion_ID = '" & vp_Obj_Acciones.Accion_ID & "'")
        StrQuery = sql.ToString
        Result = conex.StrInsert_and_Update_All(StrQuery)

        'Else
        'Result = "Exist_O"
        'End If

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
    ''' funcion que trae el listado de Acciones para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listAcciones(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListAcciones As New List(Of CGA_AccionesClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objAcciones As New CGA_AccionesClass
            'cargamos datos sobre el objeto de login
            objAcciones.Accion_ID = ReadConsulta.GetValue(0)
            objAcciones.Descripcion = ReadConsulta.GetString(1)
            objAcciones.FechaActualizacion = ReadConsulta.GetString(2)
            objAcciones.Usuario = ReadConsulta.GetString(3)

            'agregamos a la lista
            ObjListAcciones.Add(objAcciones)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListAcciones

    End Function

#End Region

End Class
