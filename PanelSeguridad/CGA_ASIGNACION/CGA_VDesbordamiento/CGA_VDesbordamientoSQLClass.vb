Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_VDesbordamientoSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla VDesbordamiento parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllVDesbordamiento(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append(" SELECT VD_Centro_ID, " & _
                              " VD_Maquina_ID, " & _
                              " VD_GRPMaquina_ID, " & _
                              " VD_Desbor_1,  " & _
                              " VD_Desbor_2, " & _
                              " VD_Desbor_3, " & _
                              " VD_Desbor_4, " & _
                              " VD_Desbor_5, " & _
                              " VD_Desbor_6, " & _
                              " VD_Desbor_7, " & _
                              " VD_FechaActualizacion, " & _
                              " VD_Usuario, " & _
                              " M.M_Descripcion AS Descrip_maquina, " & _
                              " GR.GRP_Descripcion AS Descrip_GRPmaquina, " & _
                              " C.C_Descripcion AS Descrip_centro, " & _
                              " M_1.M_Descripcion AS Descrip_Des_1, " & _
                              " M_2.M_Descripcion AS Descrip_Des_2, " & _
                              " M_3.M_Descripcion AS Descrip_Des_3, " & _
                              " M_4.M_Descripcion AS Descrip_Des_4, " & _
                              " M_5.M_Descripcion AS Descrip_Des_5, " & _
                              " M_6.M_Descripcion AS Descrip_Des_6, " & _
                              " M_7.M_Descripcion AS Descrip_Des_7 " & _
                      " FROM CGA_VALIDACION_DESBORDAMIENTO VD " & _
                        " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = VD.VD_Maquina_ID " & _
                        " INNER JOIN CGA_GRP_MAQUINAS GR ON GR.GRP_Maquina_ID = VD.VD_GRPMaquina_ID " & _
                        " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = VD.VD_Centro_ID " & _
                        " LEFT JOIN CGA_MAQUINA M_1 ON M_1.M_Maquina_ID = VD.VD_Desbor_1 " & _
                        " LEFT JOIN CGA_MAQUINA M_2 ON M_2.M_Maquina_ID = VD.VD_Desbor_2 " & _
                        " LEFT JOIN CGA_MAQUINA M_3 ON M_3.M_Maquina_ID = VD.VD_Desbor_3 " & _
                        " LEFT JOIN CGA_MAQUINA M_4 ON M_4.M_Maquina_ID = VD.VD_Desbor_4 " & _
                        " LEFT JOIN CGA_MAQUINA M_5 ON M_5.M_Maquina_ID = VD.VD_Desbor_5 " & _
                        " LEFT JOIN CGA_MAQUINA M_6 ON M_6.M_Maquina_ID = VD.VD_Desbor_6 " & _
                        " LEFT JOIN CGA_MAQUINA M_7 ON M_7.M_Maquina_ID = VD.VD_Desbor_7 ")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append(" SELECT VD_Centro_ID, " & _
                              " VD_Maquina_ID, " & _
                              " VD_GRPMaquina_ID, " & _
                              " VD_Desbor_1,  " & _
                              " VD_Desbor_2, " & _
                              " VD_Desbor_3, " & _
                              " VD_Desbor_4, " & _
                              " VD_Desbor_5, " & _
                              " VD_Desbor_6, " & _
                              " VD_Desbor_7, " & _
                              " VD_FechaActualizacion, " & _
                              " VD_Usuario, " & _
                              " M.M_Descripcion AS Descrip_maquina, " & _
                              " GR.GRP_Descripcion AS Descrip_GRPmaquina, " & _
                              " C.C_Descripcion AS Descrip_centro, " & _
                              " M_1.M_Descripcion AS Descrip_Des_1, " & _
                              " M_2.M_Descripcion AS Descrip_Des_2, " & _
                              " M_3.M_Descripcion AS Descrip_Des_3, " & _
                              " M_4.M_Descripcion AS Descrip_Des_4, " & _
                              " M_5.M_Descripcion AS Descrip_Des_5, " & _
                              " M_6.M_Descripcion AS Descrip_Des_6, " & _
                              " M_7.M_Descripcion AS Descrip_Des_7 " & _
                      " FROM CGA_VALIDACION_DESBORDAMIENTO VD " & _
                        " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = VD.VD_Maquina_ID " & _
                        " INNER JOIN CGA_GRP_MAQUINAS GR ON GR.GRP_Maquina_ID = VD.VD_GRPMaquina_ID " & _
                        " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = VD.VD_Centro_ID " & _
                        " LEFT JOIN CGA_MAQUINA M_1 ON M_1.M_Maquina_ID = VD.VD_Desbor_1 " & _
                        " LEFT JOIN CGA_MAQUINA M_2 ON M_2.M_Maquina_ID = VD.VD_Desbor_2 " & _
                        " LEFT JOIN CGA_MAQUINA M_3 ON M_3.M_Maquina_ID = VD.VD_Desbor_3 " & _
                        " LEFT JOIN CGA_MAQUINA M_4 ON M_4.M_Maquina_ID = VD.VD_Desbor_4 " & _
                        " LEFT JOIN CGA_MAQUINA M_5 ON M_5.M_Maquina_ID = VD.VD_Desbor_5 " & _
                        " LEFT JOIN CGA_MAQUINA M_6 ON M_6.M_Maquina_ID = VD.VD_Desbor_6 " & _
                        " LEFT JOIN CGA_MAQUINA M_7 ON M_7.M_Maquina_ID = VD.VD_Desbor_7 ")
            Else
                sql.Append(" SELECT VD_Centro_ID, " & _
                              " VD_Maquina_ID, " & _
                              " VD_GRPMaquina_ID, " & _
                              " VD_Desbor_1,  " & _
                              " VD_Desbor_2, " & _
                              " VD_Desbor_3, " & _
                              " VD_Desbor_4, " & _
                              " VD_Desbor_5, " & _
                              " VD_Desbor_6, " & _
                              " VD_Desbor_7, " & _
                              " VD_FechaActualizacion, " & _
                              " VD_Usuario, " & _
                              " M.M_Descripcion AS Descrip_maquina, " & _
                              " GR.GRP_Descripcion AS Descrip_GRPmaquina, " & _
                              " C.C_Descripcion AS Descrip_centro, " & _
                              " M_1.M_Descripcion AS Descrip_Des_1, " & _
                              " M_2.M_Descripcion AS Descrip_Des_2, " & _
                              " M_3.M_Descripcion AS Descrip_Des_3, " & _
                              " M_4.M_Descripcion AS Descrip_Des_4, " & _
                              " M_5.M_Descripcion AS Descrip_Des_5, " & _
                              " M_6.M_Descripcion AS Descrip_Des_6, " & _
                              " M_7.M_Descripcion AS Descrip_Des_7 " & _
                      " FROM CGA_VALIDACION_DESBORDAMIENTO VD " & _
                        " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = VD.VD_Maquina_ID " & _
                        " INNER JOIN CGA_GRP_MAQUINAS GR ON GR.GRP_Maquina_ID = VD.VD_GRPMaquina_ID " & _
                        " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = VD.VD_Centro_ID " & _
                        " LEFT JOIN CGA_MAQUINA M_1 ON M_1.M_Maquina_ID = VD.VD_Desbor_1 " & _
                        " LEFT JOIN CGA_MAQUINA M_2 ON M_2.M_Maquina_ID = VD.VD_Desbor_2 " & _
                        " LEFT JOIN CGA_MAQUINA M_3 ON M_3.M_Maquina_ID = VD.VD_Desbor_3 " & _
                        " LEFT JOIN CGA_MAQUINA M_4 ON M_4.M_Maquina_ID = VD.VD_Desbor_4 " & _
                        " LEFT JOIN CGA_MAQUINA M_5 ON M_5.M_Maquina_ID = VD.VD_Desbor_5 " & _
                        " LEFT JOIN CGA_MAQUINA M_6 ON M_6.M_Maquina_ID = VD.VD_Desbor_6 " & _
                        " LEFT JOIN CGA_MAQUINA M_7 ON M_7.M_Maquina_ID = VD.VD_Desbor_7 " & _
                      " WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListVDesbordamiento = conex.ObjLoad_All(StrQuery, "Desbordamiento")

        Return ObjListVDesbordamiento

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo VDesbordamiento (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_VDesbordamiento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertVDesbordamiento(ByVal vp_Obj_VDesbordamiento As CGA_VDesbordamientoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT CGA_VALIDACION_DESBORDAMIENTO (" & _
            "VD_Maquina_ID," & _
            "VD_GRPMaquina_ID," & _
            "VD_Centro_ID," & _
            "VD_Desbor_1," & _
            "VD_Desbor_2," & _
            "VD_Desbor_3," & _
            "VD_Desbor_4," & _
            "VD_Desbor_5," & _
            "VD_Desbor_6," & _
            "VD_Desbor_7," & _
            "VD_FechaActualizacion," & _
            "VD_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Puestotrabajo_ID & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.GRPMaquina_ID & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Centro_ID & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_1 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_2 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_3 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_4 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_5 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_6 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Desboramiento_7 & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_VDesbordamiento.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del VDesbordamiento (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_VDesbordamiento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateVDesbordamiento(ByVal vp_Obj_VDesbordamiento As CGA_VDesbordamientoClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_VALIDACION_DESBORDAMIENTO SET " & _
                       " VD_Desbor_1 ='" & vp_Obj_VDesbordamiento.Desboramiento_1 & "', " & _
                       " VD_Desbor_2 ='" & vp_Obj_VDesbordamiento.Desboramiento_2 & "', " & _
                       " VD_Desbor_3 ='" & vp_Obj_VDesbordamiento.Desboramiento_3 & "', " & _
                       " VD_Desbor_4 ='" & vp_Obj_VDesbordamiento.Desboramiento_4 & "', " & _
                       " VD_Desbor_5 ='" & vp_Obj_VDesbordamiento.Desboramiento_5 & "', " & _
                       " VD_Desbor_6 ='" & vp_Obj_VDesbordamiento.Desboramiento_6 & "', " & _
                       " VD_Desbor_7 ='" & vp_Obj_VDesbordamiento.Desboramiento_7 & "', " & _
                       " VD_FechaActualizacion ='" & vp_Obj_VDesbordamiento.FechaActualizacion & "', " & _
                       " VD_Usuario ='" & vp_Obj_VDesbordamiento.Usuario & "' " & _
                       " WHERE VD_Maquina_ID = '" & vp_Obj_VDesbordamiento.Puestotrabajo_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del VDesbordamiento (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_VDesbordamiento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseVDesbordamiento(ByVal vp_Obj_VDesbordamiento As CGA_VDesbordamientoClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE CGA_VALIDACION_DESBORDAMIENTO WHERE VD_Maquina_ID = '" & vp_Obj_VDesbordamiento.Puestotrabajo_ID & "'")
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
    Public Function ReadCharge_DDL_Centro(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT C_Centro_ID AS ID, CONVERT(VARCHAR(10),C_Centro_ID) + ' ' + C_Descripcion AS descripcion FROM CGA_CENTROS ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    
    ''' <summary>
    ''' funcion que consulta la tabla Grupo de maquinas para el DDl GrpMaquinas
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DDL_GrpMaquinas(ByVal vp_S_Table As String, ByVal vp_S_Id_Centro As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT GRP_Maquina_ID AS ID, GRP_Descripcion AS descripcion FROM CGA_GRP_MAQUINAS GR " & _
                   " INNER JOIN CGA_MAQUINA M ON M.M_GRPMaquina_ID = GR.GRP_Maquina_ID " & _
                   " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = M.M_Centro_ID " & _
                   " WHERE M_Centro_ID = '" & vp_S_Id_Centro & "'" & _
                   " GROUP BY GRP_Maquina_ID,GRP_Descripcion " & _
                   " ORDER BY GRP_Descripcion ASC ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' funcion que consulta la tabla  maquinas para el DDl Maquinas
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DDL_Maquinas(ByVal vp_S_Table As String, ByVal vp_S_GrpMaq As String, ByVal vp_S_Id_Centro As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT M_Maquina_ID AS ID, M_Descripcion AS descripcion FROM CGA_MAQUINA " & _
                   " WHERE M_GRPMaquina_ID ='" & vp_S_GrpMaq & "'AND M_Centro_ID = '" & vp_S_Id_Centro & "'")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae el listado de VDesbordamiento para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listVDesbordamiento(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objVDesbordamiento As New CGA_VDesbordamientoClass
            'cargamos datos sobre el objeto de login
            objVDesbordamiento.Centro_ID = ReadConsulta.GetValue(0)
            objVDesbordamiento.Puestotrabajo_ID = ReadConsulta.GetValue(1)
            objVDesbordamiento.GRPMaquina_ID = ReadConsulta.GetValue(2)

            objVDesbordamiento.Desboramiento_1 = ReadConsulta.GetValue(3)
            objVDesbordamiento.Desboramiento_2 = ReadConsulta.GetValue(4)
            objVDesbordamiento.Desboramiento_3 = ReadConsulta.GetValue(5)
            objVDesbordamiento.Desboramiento_4 = ReadConsulta.GetValue(6)
            objVDesbordamiento.Desboramiento_5 = ReadConsulta.GetValue(7)
            objVDesbordamiento.Desboramiento_6 = ReadConsulta.GetValue(8)
            objVDesbordamiento.Desboramiento_7 = ReadConsulta.GetValue(9)
            objVDesbordamiento.FechaActualizacion = ReadConsulta.GetValue(10)
            objVDesbordamiento.Usuario = ReadConsulta.GetValue(11)

            objVDesbordamiento.Descrip_Puestotrabajo = ReadConsulta.GetString(12)
            objVDesbordamiento.Descrip_GRPMaquina = ReadConsulta.GetString(13)
            objVDesbordamiento.Descrip_Centro = ReadConsulta.GetString(14)

            If Not (IsDBNull(ReadConsulta.GetValue(15))) Then objVDesbordamiento.Descrip_Desboramiento_1 = ReadConsulta.GetValue(15) Else objVDesbordamiento.Descrip_Desboramiento_1 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(16))) Then objVDesbordamiento.Descrip_Desboramiento_2 = ReadConsulta.GetValue(16) Else objVDesbordamiento.Descrip_Desboramiento_2 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(17))) Then objVDesbordamiento.Descrip_Desboramiento_3 = ReadConsulta.GetValue(17) Else objVDesbordamiento.Descrip_Desboramiento_3 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(18))) Then objVDesbordamiento.Descrip_Desboramiento_4 = ReadConsulta.GetValue(18) Else objVDesbordamiento.Descrip_Desboramiento_4 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(19))) Then objVDesbordamiento.Descrip_Desboramiento_5 = ReadConsulta.GetValue(19) Else objVDesbordamiento.Descrip_Desboramiento_5 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(20))) Then objVDesbordamiento.Descrip_Desboramiento_6 = ReadConsulta.GetValue(20) Else objVDesbordamiento.Descrip_Desboramiento_6 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(21))) Then objVDesbordamiento.Descrip_Desboramiento_7 = ReadConsulta.GetValue(21) Else objVDesbordamiento.Descrip_Desboramiento_7 = ""

            'agregamos a la lista
            ObjListVDesbordamiento.Add(objVDesbordamiento)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListVDesbordamiento

    End Function


#End Region

End Class
