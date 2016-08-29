Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_AreaSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Area parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllArea(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListArea As New List(Of CGA_AreaClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT A_Area_ID, A_Descripcion, A_FechaActualizacion, A_Usuario FROM CGA_AREA")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT A_Area_ID, A_Descripcion, A_FechaActualizacion, A_Usuario FROM CGA_AREA")
            Else
                sql.Append("SELECT A_Area_ID, A_Descripcion, A_FechaActualizacion, A_Usuario FROM CGA_AREA " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListArea = conex.ObjLoad_All(StrQuery, "Area")

        Return ObjListArea

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo Area (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Area"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertArea(ByVal vp_Obj_Area As CGA_AreaClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_AREA (" & _
            "A_Area_ID," & _
            "A_Descripcion," & _
            "A_FechaActualizacion," & _
            "A_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Area.Area_ID & "',")
        sql.AppendLine("'" & vp_Obj_Area.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Area.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Area.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del Area (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Area"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateArea(ByVal vp_Obj_Area As CGA_AreaClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_AREA SET " & _
                       " A_Descripcion ='" & vp_Obj_Area.Descripcion & "', " & _
                       " A_FechaActualizacion ='" & vp_Obj_Area.FechaActualizacion & "', " & _
                       " A_Usuario ='" & vp_Obj_Area.Usuario & "' " & _
                       " WHERE A_Area_ID = '" & vp_Obj_Area.Area_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del Area (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Area"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseArea(ByVal vp_Obj_Area As CGA_AreaClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
        Dim ExistOperario As String

        ExistOperario = SQL_general.ReadExist("CGA_OPERARIOS", vp_Obj_Area.Area_ID, "O_Area_ID", "")

        If ExistOperario = "0" Then

            sql.AppendLine("DELETE CGA_AREA WHERE A_Area_ID = '" & vp_Obj_Area.Area_ID & "'")
            StrQuery = sql.ToString
            Result = conex.StrInsert_and_Update_All(StrQuery)

        Else
            Result = "Exist_O"

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
    ''' funcion que trae el listado de Area para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listArea(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListArea As New List(Of CGA_AreaClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objArea As New CGA_AreaClass
            'cargamos datos sobre el objeto de login
            objArea.Area_ID = ReadConsulta.GetValue(0)
            objArea.Descripcion = ReadConsulta.GetString(1)
            objArea.FechaActualizacion = ReadConsulta.GetString(2)
            objArea.Usuario = ReadConsulta.GetString(3)

            'agregamos a la lista
            ObjListArea.Add(objArea)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListArea

    End Function

#End Region

End Class
