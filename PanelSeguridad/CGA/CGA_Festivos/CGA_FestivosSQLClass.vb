Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_FestivosSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Festivos parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllFestivos(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListFestivos As New List(Of CGA_FestivosClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT F_Año, F_Mes_Dia, F_FechaActualizacion, F_Usuario, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 1, 2)as Mes, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 3, 4)as Dia FROM CGA_Festivos")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT F_Año, F_Mes_Dia, F_FechaActualizacion, F_Usuario, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 1, 2)as Mes, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 3, 4)as Dia FROM CGA_Festivos")
            Else
                sql.Append("SELECT F_Año, F_Mes_Dia, F_FechaActualizacion, F_Usuario, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 1, 2)as Mes, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 3, 4)as Dia FROM CGA_Festivos " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListFestivos = conex.ObjLoad_All(StrQuery, "Festivos")

        Return ObjListFestivos

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo Festivos (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Festivos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertFestivos(ByVal vp_Obj_Festivos As CGA_FestivosClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_Festivos (" & _
            "F_Año," & _
            "F_Mes_Dia," & _
            "F_FechaActualizacion," & _
            "F_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Festivos.Year & "',")
        sql.AppendLine("'" & vp_Obj_Festivos.Mes_Dia & "',")
        sql.AppendLine("'" & vp_Obj_Festivos.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Festivos.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del Festivos (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Festivos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseFestivos(ByVal vp_Obj_Festivos As CGA_FestivosClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE CGA_Festivos WHERE F_Año = " & vp_Obj_Festivos.Year & " AND F_Mes_Dia =" & vp_Obj_Festivos.Mes_Dia)
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
    ''' funcion que trae el listado de Festivos para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listFestivos(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListFestivos As New List(Of CGA_FestivosClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objFestivos As New CGA_FestivosClass
            'cargamos datos sobre el objeto de login
            objFestivos.Year = ReadConsulta.GetValue(0)
            objFestivos.Mes_Dia = ReadConsulta.GetValue(1)
            objFestivos.FechaActualizacion = ReadConsulta.GetString(2)
            objFestivos.Usuario = ReadConsulta.GetString(3)
            objFestivos.StrMes = ReadConsulta.GetValue(4)
            objFestivos.StrDia = ReadConsulta.GetValue(5)

            'agregamos a la lista
            ObjListFestivos.Add(objFestivos)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListFestivos

    End Function


#End Region

End Class
