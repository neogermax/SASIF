Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_CausalesAtrazoSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla CausalesAtrazo parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllCausalesAtrazo(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT CA_Causal_ID, CA_CausalRaiz, CA_GerenciaResponsable, CA_Area_Responsable, CA_Comentario, CA_FechaActualizacion, CA_Usuario FROM CGA_CAUSALES_ATRAZO")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT CA_Causal_ID, CA_CausalRaiz, CA_GerenciaResponsable, CA_Area_Responsable, CA_Comentario, CA_FechaActualizacion, CA_Usuario FROM CGA_CAUSALES_ATRAZO")
            Else
                sql.Append("SELECT CA_Causal_ID, CA_CausalRaiz, CA_GerenciaResponsable, CA_Area_Responsable, CA_Comentario, CA_FechaActualizacion, CA_Usuario FROM CGA_CAUSALES_ATRAZO " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListCausalesAtrazo = conex.ObjLoad_All(StrQuery, "CausalesAtrazo")

        Return ObjListCausalesAtrazo

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo CausalesAtrazo (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_CausalesAtrazo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertCausalesAtrazo(ByVal vp_Obj_CausalesAtrazo As CGA_CausalesAtrazoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_CAUSALES_ATRAZO (" & _
            "CA_Causal_ID," & _
            "CA_CausalRaiz," & _
            "CA_GerenciaResponsable," & _
            "CA_Area_Responsable," & _
            "CA_Comentario," & _
            "CA_FechaActualizacion," & _
            "CA_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.Causal_ID & "',")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.CausalRaiz & "',")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.GerenciaResponsable & "',")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.Area_Responsable & "',")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.Comentario & "',")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_CausalesAtrazo.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del CausalesAtrazo (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_CausalesAtrazo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateCausalesAtrazo(ByVal vp_Obj_CausalesAtrazo As CGA_CausalesAtrazoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_CAUSALES_ATRAZO SET " & _
                       " CA_CausalRaiz ='" & vp_Obj_CausalesAtrazo.CausalRaiz & "', " & _
                       " CA_GerenciaResponsable ='" & vp_Obj_CausalesAtrazo.GerenciaResponsable & "', " & _
                       " CA_Area_Responsable ='" & vp_Obj_CausalesAtrazo.Area_Responsable & "', " & _
                       " CA_Comentario ='" & vp_Obj_CausalesAtrazo.Comentario & "', " & _
                       " CA_FechaActualizacion ='" & vp_Obj_CausalesAtrazo.FechaActualizacion & "', " & _
                       " CA_Usuario ='" & vp_Obj_CausalesAtrazo.Usuario & "' " & _
                       " WHERE CA_Causal_ID = '" & vp_Obj_CausalesAtrazo.Causal_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del CausalesAtrazo (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_CausalesAtrazo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseCausalesAtrazo(ByVal vp_Obj_CausalesAtrazo As CGA_CausalesAtrazoClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
    
        sql.AppendLine("DELETE CGA_CAUSALES_ATRAZO WHERE CA_Causal_ID = '" & vp_Obj_CausalesAtrazo.Causal_ID & "'")
        StrQuery = sql.ToString
        Result = conex.StrInsert_and_Update_All(StrQuery)

        'Else
        ' If ExistMaquina = "1" Then
        ' Result = "Exist_M"
        'End If
        'If ExistOperario = "1" Then
        'Result = "Exist_O"
        'End If
        'If ExistMaquina = "1" And ExistOperario = "1" Then
        'Result = "Exist_All"
        'End If
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
    ''' funcion que trae el listado de CausalesAtrazo para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listCausalesAtrazo(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objCausalesAtrazo As New CGA_CausalesAtrazoClass
            'cargamos datos sobre el objeto de login
            objCausalesAtrazo.Causal_ID = ReadConsulta.GetValue(0)
            objCausalesAtrazo.CausalRaiz = ReadConsulta.GetString(1)
            objCausalesAtrazo.GerenciaResponsable = ReadConsulta.GetString(2)
            objCausalesAtrazo.Area_Responsable = ReadConsulta.GetString(3)
            objCausalesAtrazo.Comentario = ReadConsulta.GetString(4)
            objCausalesAtrazo.FechaActualizacion = ReadConsulta.GetString(5)
            objCausalesAtrazo.Usuario = ReadConsulta.GetString(6)

            'agregamos a la lista
            ObjListCausalesAtrazo.Add(objCausalesAtrazo)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListCausalesAtrazo

    End Function

#End Region

End Class
