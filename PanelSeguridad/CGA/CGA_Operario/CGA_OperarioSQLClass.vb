Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_OperarioSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla Operario parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllOperario(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListOperario As New List(Of CGA_OperarioClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append(" SELECT O_Operario_ID, O_Identificacion, " & _
                               "O_Nombre, O_Centro_ID, " & _
                               "O_CentroCosto_ID, O_Area_ID, " & _
                               "O_FechaActualizacion, O_Usuario, " & _
                               "C_Descripcion AS DesCentro, " & _
                               "CC_Descripcion AS DesCCosto, " & _
                               "A_Descripcion AS DesArea " & _
                       " FROM CGA_OPERARIOS O " & _
                       " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = O.O_Centro_ID " & _
                       " INNER JOIN CGA_CENTRO_COSTO CC ON CC.CC_CentroCosto_ID = O.O_CentroCosto_ID " & _
                       " INNER JOIN CGA_AREA A ON A.A_Area_ID = O.O_Area_ID")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append(" SELECT O_Operario_ID, O_Identificacion, " & _
                             "O_Nombre, O_Centro_ID, " & _
                             "O_CentroCosto_ID, O_Area_ID, " & _
                             "O_FechaActualizacion, O_Usuario, " & _
                             "C_Descripcion AS DesCentro, " & _
                             "CC_Descripcion AS DesCCosto, " & _
                             "A_Descripcion AS DesArea " & _
                     " FROM CGA_OPERARIOS O " & _
                     " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = O.O_Centro_ID " & _
                     " INNER JOIN CGA_CENTRO_COSTO CC ON CC.CC_CentroCosto_ID = O.O_CentroCosto_ID " & _
                     " INNER JOIN CGA_AREA A ON A.A_Area_ID = O.O_Area_ID")
            Else
                sql.Append(" SELECT O_Operario_ID, O_Identificacion, " & _
                             "O_Nombre, O_Centro_ID, " & _
                             "O_CentroCosto_ID, O_Area_ID, " & _
                             "O_FechaActualizacion, O_Usuario, " & _
                             "C_Descripcion AS DesCentro, " & _
                             "CC_Descripcion AS DesCCosto, " & _
                             "A_Descripcion AS DesArea " & _
                     " FROM CGA_OPERARIOS O " & _
                     " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = O.O_Centro_ID " & _
                     " INNER JOIN CGA_CENTRO_COSTO CC ON CC.CC_CentroCosto_ID = O.O_CentroCosto_ID " & _
                     " INNER JOIN CGA_AREA A ON A.A_Area_ID = O.O_Area_ID " & _
                     " WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListOperario = conex.ObjLoad_All(StrQuery, "Operario")

        Return ObjListOperario

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de la nueva Operario (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Operario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertOperario(ByVal vp_Obj_Operario As CGA_OperarioClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_OPERARIOS (" & _
            "O_Operario_ID," & _
            "O_Identificacion," & _
            "O_Nombre," & _
            "O_Centro_ID," & _
            "O_CentroCosto_ID," & _
            "O_Area_ID," & _
            "O_FechaActualizacion," & _
            "O_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Operario.Operario_ID & "',")
        sql.AppendLine("'" & vp_Obj_Operario.Identificacion & "',")
        sql.AppendLine("'" & vp_Obj_Operario.Nombre & "',")
        sql.AppendLine("'" & vp_Obj_Operario.Centro_ID & "',")
        sql.AppendLine("'" & vp_Obj_Operario.CentroCosto_ID & "',")
        sql.AppendLine("'" & vp_Obj_Operario.Area_ID & "',")
        sql.AppendLine("'" & vp_Obj_Operario.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_Operario.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion de la Operario  (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Operario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateOperario(ByVal vp_Obj_Operario As CGA_OperarioClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_OPERARIOS SET " & _
                       " O_Identificacion ='" & vp_Obj_Operario.Identificacion & "', " & _
                       " O_Nombre ='" & vp_Obj_Operario.Nombre & "', " & _
                       " O_Centro_ID =" & vp_Obj_Operario.Centro_ID & ", " & _
                       " O_CentroCosto_ID =" & vp_Obj_Operario.CentroCosto_ID & ", " & _
                       " O_Area_ID =" & vp_Obj_Operario.Area_ID & ", " & _
                       " O_FechaActualizacion ='" & vp_Obj_Operario.FechaActualizacion & "', " & _
                       " O_Usuario ='" & vp_Obj_Operario.Usuario & "' " & _
                       " WHERE O_Operario_ID = '" & vp_Obj_Operario.Operario_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion de la turno (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Operario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseOperario(ByVal vp_Obj_Operario As CGA_OperarioClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE CGA_OPERARIOS WHERE O_Operario_ID = '" & vp_Obj_Operario.Operario_ID & "'")
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

    ''' <summary>
    ''' funcion que consulta la tabla centro para el DDl Centro
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DDL_Centro()

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT C_Centro_ID AS ID, C_Descripcion AS descripcion FROM CGA_CENTROS ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' funcion que consulta la tabla Grupo de Operarios para el DDl CentroCosto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DDL_CentroCosto()

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT CC_CentroCosto_ID AS ID, CC_Descripcion AS descripcion FROM CGA_CENTRO_COSTO ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' funcion que consulta la tabla Grupo de Operarios para el DDl CentroCosto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DDL_Area()

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT A_Area_ID AS ID, A_Descripcion AS descripcion FROM CGA_AREA ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae el listado de Operario para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listOperario(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListOperario As New List(Of CGA_OperarioClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objOperario As New CGA_OperarioClass
            'cargamos datos sobre el objeto de login
            objOperario.Operario_ID = ReadConsulta.GetValue(0)
            objOperario.Identificacion = ReadConsulta.GetValue(1)
            objOperario.Nombre = ReadConsulta.GetString(2)
            objOperario.Centro_ID = ReadConsulta.GetValue(3)
            objOperario.CentroCosto_ID = ReadConsulta.GetValue(4)
            objOperario.Area_ID = ReadConsulta.GetValue(5)
            objOperario.FechaActualizacion = ReadConsulta.GetString(6)
            objOperario.Usuario = ReadConsulta.GetString(7)
            objOperario.DesCentro = ReadConsulta.GetString(8)
            objOperario.DesCCostos = ReadConsulta.GetString(9)
            objOperario.DesArea = ReadConsulta.GetString(10)
            'agregamos a la lista
            ObjListOperario.Add(objOperario)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListOperario

    End Function

#End Region


End Class
