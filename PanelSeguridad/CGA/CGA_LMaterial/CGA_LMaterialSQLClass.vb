Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class CGA_LMaterialSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla LMaterial parametrizada (READ)
    ''' </summary>
    ''' <param name="vLI_S_Filtro"></param>
    ''' <param name="vLI_S_Opcion"></param>
    ''' <param name="vLI_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllLMaterial(ByVal vLI_S_Filtro As String, ByVal vLI_S_Opcion As String, ByVal vLI_S_Contenido As String)

        Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vLI_S_Filtro = "N" And vLI_S_Opcion = "ALL" Then
            sql.Append("SELECT LI_LMaterial_ID, LI_Descripcion, LI_FechaActualizacion, LI_Usuario FROM CGA_LINEA_MATERIAL")
        Else

            If vLI_S_Contenido = "ALL" Then
                sql.Append("SELECT LI_LMaterial_ID, LI_Descripcion, LI_FechaActualizacion, LI_Usuario FROM CGA_LINEA_MATERIAL")
            Else
                sql.Append("SELECT LI_LMaterial_ID, LI_Descripcion, LI_FechaActualizacion, LI_Usuario FROM CGA_LINEA_MATERIAL " & _
                      "WHERE " & vLI_S_Opcion & " like '%" & vLI_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListLMaterial = conex.ObjLoad_All(StrQuery, "LMaterial")

        Return ObjListLMaterial

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo LMaterial (INSERT)
    ''' </summary>
    ''' <param name="vLI_Obj_LMaterial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertLMaterial(ByVal vLI_Obj_LMaterial As CGA_LMaterialClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_LINEA_MATERIAL (" & _
            "LI_LMaterial_ID," & _
            "LI_Descripcion," & _
            "LI_FechaActualizacion," & _
            "LI_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vLI_Obj_LMaterial.LMaterial_ID & "',")
        sql.AppendLine("'" & vLI_Obj_LMaterial.Descripcion & "',")
        sql.AppendLine("'" & vLI_Obj_LMaterial.FechaActualizacion & "',")
        sql.AppendLine("'" & vLI_Obj_LMaterial.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del LMaterial (UPDATE)
    ''' </summary>
    ''' <param name="vLI_Obj_LMaterial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateLMaterial(ByVal vLI_Obj_LMaterial As CGA_LMaterialClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_LINEA_MATERIAL SET " & _
                       " LI_Descripcion ='" & vLI_Obj_LMaterial.Descripcion & "', " & _
                       " LI_FechaActualizacion ='" & vLI_Obj_LMaterial.FechaActualizacion & "', " & _
                       " LI_Usuario ='" & vLI_Obj_LMaterial.Usuario & "' " & _
                       " WHERE LI_LMaterial_ID = '" & vLI_Obj_LMaterial.LMaterial_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del LMaterial (DELETE)
    ''' </summary>
    ''' <param name="vLI_Obj_LMaterial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseLMaterial(ByVal vLI_Obj_LMaterial As CGA_LMaterialClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass
       

        'If ExistMaquina = "0" And ExistOperario = "0" Then

        sql.AppendLine("DELETE CGA_LINEA_MATERIAL WHERE LI_LMaterial_ID = '" & vLI_Obj_LMaterial.LMaterial_ID & "'")
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
    ''' <param name="vLI_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList(ByVal vLI_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT T_IndexColumna As ID, T_Traductor As descripcion FROM TC_TABLAS " & _
                   " WHERE T_Tabla = '" & vLI_S_Table & "' AND T_Param = '1' ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist


    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae el listado de LMaterial para armar la tabla
    ''' </summary>
    ''' <param name="vLI_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listLMaterial(ByVal vLI_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vLI_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objLMaterial As New CGA_LMaterialClass
            'cargamos datos sobre el objeto de login
            objLMaterial.LMaterial_ID = ReadConsulta.GetValue(0)
            objLMaterial.Descripcion = ReadConsulta.GetString(1)
            objLMaterial.FechaActualizacion = ReadConsulta.GetString(2)
            objLMaterial.Usuario = ReadConsulta.GetString(3)

            'agregamos a la lista
            ObjListLMaterial.Add(objLMaterial)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListLMaterial

    End Function


#End Region

End Class
