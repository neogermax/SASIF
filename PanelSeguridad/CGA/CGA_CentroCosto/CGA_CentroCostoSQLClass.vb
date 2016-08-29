Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_CentroCostoSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla CentroCosto parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllCentroCosto(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListCentroCosto As New List(Of CGA_CentroCostoClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT CC_CentroCosto_ID, CC_Descripcion, CC_FechaActualizacion, CC_Usuario FROM CGA_CENTRO_COSTO")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT CC_CentroCosto_ID, CC_Descripcion, CC_FechaActualizacion, CC_Usuario FROM CGA_CENTRO_COSTO")
            Else
                sql.Append("SELECT CC_CentroCosto_ID, CC_Descripcion, CC_FechaActualizacion, CC_Usuario FROM CGA_CENTRO_COSTO " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListCentroCosto = conex.ObjLoad_All(StrQuery, "CentroCosto")

        Return ObjListCentroCosto

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo CentroCosto (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_CentroCosto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertCentroCosto(ByVal vp_Obj_CentroCosto As CGA_CentroCostoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_CENTRO_COSTO (" & _
            "CC_CentroCosto_ID," & _
            "CC_Descripcion," & _
            "CC_FechaActualizacion," & _
            "CC_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_CentroCosto.CentroCosto_ID & "',")
        sql.AppendLine("'" & vp_Obj_CentroCosto.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_CentroCosto.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_CentroCosto.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del CentroCosto (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_CentroCosto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateCentroCosto(ByVal vp_Obj_CentroCosto As CGA_CentroCostoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_CENTRO_COSTO SET " & _
                       " CC_Descripcion ='" & vp_Obj_CentroCosto.Descripcion & "', " & _
                       " CC_FechaActualizacion ='" & vp_Obj_CentroCosto.FechaActualizacion & "', " & _
                       " CC_Usuario ='" & vp_Obj_CentroCosto.Usuario & "' " & _
                       " WHERE CC_CentroCosto_ID = '" & vp_Obj_CentroCosto.CentroCosto_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del CentroCosto (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_CentroCosto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseCentroCosto(ByVal vp_Obj_CentroCosto As CGA_CentroCostoClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
        Dim ExistOperario As String
        Dim ExistMaquina As String

        ExistOperario = SQL_general.ReadExist("CGA_OPERARIOS", vp_Obj_CentroCosto.CentroCosto_ID, "O_CentroCosto_ID", "")
        ExistMaquina = SQL_general.ReadExist("CGA_MAQUINA", vp_Obj_CentroCosto.CentroCosto_ID, "M_CentroCosto_ID", "")

        If ExistOperario = "0" And ExistMaquina = "0" Then

            sql.AppendLine("DELETE CGA_CENTRO_COSTO WHERE CC_CentroCosto_ID = '" & vp_Obj_CentroCosto.CentroCosto_ID & "'")
            StrQuery = sql.ToString
            Result = conex.StrInsert_and_Update_All(StrQuery)

        Else
            If ExistMaquina = "1" Then
                Result = "Exist_M"
            End If
            If ExistOperario = "1" Then
                Result = "Exist_O"
            End If
            If ExistMaquina = "1" And ExistOperario = "1" Then
                Result = "Exist_All"
            End If
        End If

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
    ''' funcion que trae el listado de CentroCosto para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listCentroCosto(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListCentroCosto As New List(Of CGA_CentroCostoClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objCentroCosto As New CGA_CentroCostoClass
            'cargamos datos sobre el objeto de login
            objCentroCosto.CentroCosto_ID = ReadConsulta.GetValue(0)
            objCentroCosto.Descripcion = ReadConsulta.GetString(1)
            objCentroCosto.FechaActualizacion = ReadConsulta.GetString(2)
            objCentroCosto.Usuario = ReadConsulta.GetString(3)

            'agregamos a la lista
            ObjListCentroCosto.Add(objCentroCosto)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListCentroCosto

    End Function

#End Region

End Class
