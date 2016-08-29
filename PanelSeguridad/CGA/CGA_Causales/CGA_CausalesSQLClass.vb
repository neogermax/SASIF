Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_CausalesSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Causales parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllCausales(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListCausales As New List(Of CGA_CausalesClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT Ca_Causal_ID, Ca_Descripcion, Ca_Tipo, Ca_FechaActualizacion, Ca_Usuario, DDLL_Descripcion AS DesTipo FROM CGA_CAUSALES C " & _
                       " INNER JOIN TC_DDL_TIPO DDL ON DDL.DDL_ID = C.Ca_Tipo " & _
                       " WHERE DDL_Tabla = 'CGA_CAUSALES' ")
        Else
            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT Ca_Causal_ID, Ca_Descripcion, Ca_Tipo, Ca_FechaActualizacion, Ca_Usuario, DDLL_Descripcion AS DesTipo FROM CGA_CAUSALES C " & _
                           " INNER JOIN TC_DDL_TIPO DDL ON DDL.DDL_ID = C.Ca_Tipo " & _
                           " WHERE DDL_Tabla = 'CGA_CAUSALES' ")
            Else
                sql.Append("SELECT Ca_Causal_ID, Ca_Descripcion, Ca_Tipo, Ca_FechaActualizacion, Ca_Usuario, DDLL_Descripcion AS DesTipo FROM CGA_CAUSALES C " & _
                           " INNER JOIN TC_DDL_TIPO DDL ON DDL.DDL_ID = C.Ca_Tipo " & _
                           " WHERE DDL_Tabla = 'CGA_CAUSALES' " & _
                           "AND " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListCausales = conex.ObjLoad_All(StrQuery, "Causales")

        Return ObjListCausales

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo Causales (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Causales"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertCausales(ByVal vp_Obj_Causales As CGA_CausalesClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_CAUSALES (" & _
            "Ca_Causal_ID," & _
            "Ca_Descripcion," & _
            "Ca_Tipo," & _
            "Ca_FechaActualizacion," & _
            "Ca_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Causales.Causal_ID & "',")
        sql.AppendLine("'" & vp_Obj_Causales.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Causales.Tipo & "',")
        sql.AppendLine("'" & vp_Obj_Causales.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Causales.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del Causales (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Causales"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateCausales(ByVal vp_Obj_Causales As CGA_CausalesClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_CAUSALES SET " & _
                       " Ca_Descripcion ='" & vp_Obj_Causales.Descripcion & "', " & _
                       " Ca_Tipo ='" & vp_Obj_Causales.Tipo & "', " & _
                       " Ca_FechaActualizacion ='" & vp_Obj_Causales.FechaActualizacion & "', " & _
                       " Ca_Usuario ='" & vp_Obj_Causales.Usuario & "' " & _
                       " WHERE Ca_Causal_ID = '" & vp_Obj_Causales.Causal_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del Causales (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Causales"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseCausales(ByVal vp_Obj_Causales As CGA_CausalesClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
        'Dim ExistOperario As String

        'ExistOperario = SQL_general.ReadExist("CGA_OPERARIOS", vp_Obj_Causales.Causal_ID, "O_Causales_ID", "")

        'If ExistOperario = "0" Then

        sql.AppendLine("DELETE CGA_CAUSALES WHERE Ca_Causal_ID = '" & vp_Obj_Causales.Causal_ID & "'")
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
    ''' funcion que trae el listado de Causales para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listCausales(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListCausales As New List(Of CGA_CausalesClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objCausales As New CGA_CausalesClass
            'cargamos datos sobre el objeto de login
            objCausales.Causal_ID = ReadConsulta.GetValue(0)
            objCausales.Descripcion = ReadConsulta.GetString(1)
            objCausales.Tipo = ReadConsulta.GetString(2)
            objCausales.FechaActualizacion = ReadConsulta.GetString(3)
            objCausales.Usuario = ReadConsulta.GetString(4)
            objCausales.DesTipo = ReadConsulta.GetString(5)
            'agregamos a la lista
            ObjListCausales.Add(objCausales)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListCausales

    End Function

#End Region

End Class
