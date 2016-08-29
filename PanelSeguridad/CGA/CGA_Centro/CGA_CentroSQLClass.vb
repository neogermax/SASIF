Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_CentroSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Centro parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllCentro(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListCentro As New List(Of CGA_CentroClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT C_Centro_ID, C_Descripcion, C_Descripcion_Planta, C_FechaActualizacion, C_Usuario FROM CGA_CENTROS")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT C_Centro_ID, C_Descripcion, C_Descripcion_Planta, C_FechaActualizacion, C_Usuario FROM CGA_CENTROS")
            Else
                sql.Append("SELECT C_Centro_ID, C_Descripcion, C_Descripcion_Planta, C_FechaActualizacion, C_Usuario FROM CGA_CENTROS " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListCentro = conex.ObjLoad_All(StrQuery, "Centro")

        Return ObjListCentro

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo Centro (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Centro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertCentro(ByVal vp_Obj_Centro As CGA_CentroClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_CENTROS (" & _
            "C_Centro_ID," & _
            "C_Descripcion," & _
            "C_Descripcion_Planta," & _
            "C_FechaActualizacion," & _
            "C_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Centro.Centro_ID & "',")
        sql.AppendLine("'" & vp_Obj_Centro.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Centro.Descripcion_Planta & "',")
        sql.AppendLine("'" & vp_Obj_Centro.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Centro.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del Centro (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Centro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateCentro(ByVal vp_Obj_Centro As CGA_CentroClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_CENTROS SET " & _
                       " C_Descripcion ='" & vp_Obj_Centro.Descripcion & "', " & _
                       " C_Descripcion_Planta ='" & vp_Obj_Centro.Descripcion_Planta & "', " & _
                       " C_FechaActualizacion ='" & vp_Obj_Centro.FechaActualizacion & "', " & _
                       " C_Usuario ='" & vp_Obj_Centro.Usuario & "' " & _
                       " WHERE C_Centro_ID = '" & vp_Obj_Centro.Centro_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del Centro (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Centro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseCentro(ByVal vp_Obj_Centro As CGA_CentroClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
        Dim ExistMaquina, ExistOperario As String

        ExistMaquina = SQL_general.ReadExist("CGA_MAQUINA", vp_Obj_Centro.Centro_ID, "M_Centro_ID", "")
        ExistOperario = SQL_general.ReadExist("CGA_OPERARIOS", vp_Obj_Centro.Centro_ID, "O_Centro_ID", "")

        If ExistMaquina = "0" And ExistOperario = "0" Then

            sql.AppendLine("DELETE CGA_CENTROS WHERE C_Centro_ID = '" & vp_Obj_Centro.Centro_ID & "'")
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
    ''' funcion que trae el listado de Centro para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listCentro(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListCentro As New List(Of CGA_CentroClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objCentro As New CGA_CentroClass
            'cargamos datos sobre el objeto de login
            objCentro.Centro_ID = ReadConsulta.GetValue(0)
            objCentro.Descripcion = ReadConsulta.GetString(1)
            objCentro.Descripcion_Planta = ReadConsulta.GetString(2)
            objCentro.FechaActualizacion = ReadConsulta.GetString(3)
            objCentro.Usuario = ReadConsulta.GetString(4)

            'agregamos a la lista
            ObjListCentro.Add(objCentro)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListCentro

    End Function


#End Region



End Class
