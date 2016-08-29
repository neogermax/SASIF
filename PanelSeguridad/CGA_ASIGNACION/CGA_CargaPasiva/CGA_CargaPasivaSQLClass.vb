Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_CargaPasivaSQLClass

#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla CargaPasiva parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllCargaPasiva(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append(" SELECT CP_ID, " & _
                              " CP_Maquina_ID, " & _
                              " CP_GRPMaquina_ID, " & _
                              " CP_Centro_ID,  " & _
                              " CP_Requerimiento, " & _
                              " CP_Orden_ID, " & _
                              " CP_HorasPlan, " & _
                              " CP_N_Ofertas, " & _
                              " CP_FechaActualizacion, " & _
                              " CP_Usuario, " & _
                              " M.M_Descripcion AS Descrip_maquina, " & _
                              " GR.GRP_Descripcion AS Descrip_GRPmaquina, " & _
                              " C.C_Descripcion AS Descrip_centro, " & _
                              " DDL.DDLL_Descripcion AS Descrip_Departamento " & _
                      " FROM CGA_CargaPasiva CP " & _
                        " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = CP.CP_Maquina_ID " & _
                        " INNER JOIN CGA_GRP_MAQUINAS GR ON GR.GRP_Maquina_ID = CP.CP_GRPMaquina_ID " & _
                        " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = CP.CP_Centro_ID " & _
                        " INNER JOIN TC_DDL_TIPO DDL ON DDL.DDL_ID = CP.CP_Requerimiento ")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append(" SELECT CP_ID, " & _
                              " CP_Maquina_ID, " & _
                              " CP_GRPMaquina_ID, " & _
                              " CP_Centro_ID,  " & _
                              " CP_Requerimiento, " & _
                              " CP_Orden_ID, " & _
                              " CP_HorasPlan, " & _
                              " CP_N_Ofertas, " & _
                              " CP_FechaActualizacion, " & _
                              " CP_Usuario, " & _
                              " M.M_Descripcion AS Descrip_maquina, " & _
                              " GR.GRP_Descripcion AS Descrip_GRPmaquina, " & _
                              " C.C_Descripcion AS Descrip_centro, " & _
                              " DDL.DDLL_Descripcion AS Descrip_Departamento " & _
                      " FROM CGA_CargaPasiva CP " & _
                        " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = CP.CP_Maquina_ID " & _
                        " INNER JOIN CGA_GRP_MAQUINAS GR ON GR.GRP_Maquina_ID = CP.CP_GRPMaquina_ID " & _
                        " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = CP.CP_Centro_ID " & _
                        " INNER JOIN TC_DDL_TIPO DDL ON DDL.DDL_ID = CP.CP_Requerimiento ")
            Else
                sql.Append(" SELECT CP_ID, " & _
                              " CP_Maquina_ID, " & _
                              " CP_GRPMaquina_ID, " & _
                              " CP_Centro_ID,  " & _
                              " CP_Requerimiento, " & _
                              " CP_Orden_ID, " & _
                              " CP_HorasPlan, " & _
                              " CP_N_Ofertas, " & _
                              " CP_FechaActualizacion, " & _
                              " CP_Usuario, " & _
                              " M.M_Descripcion AS Descrip_maquina, " & _
                              " GR.GRP_Descripcion AS Descrip_GRPmaquina, " & _
                              " C.C_Descripcion AS Descrip_centro, " & _
                              " DDL.DDLL_Descripcion AS Descrip_Departamento " & _
                      " FROM CGA_CargaPasiva CP " & _
                        " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = CP.CP_Maquina_ID " & _
                        " INNER JOIN CGA_GRP_MAQUINAS GR ON GR.GRP_Maquina_ID = CP.CP_GRPMaquina_ID " & _
                        " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = CP.CP_Centro_ID " & _
                        " INNER JOIN TC_DDL_TIPO DDL ON DDL.DDL_ID = CP.CP_Requerimiento " & _
                      " WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListCargaPasiva = conex.ObjLoad_All(StrQuery, "CargaPasiva")

        Return ObjListCargaPasiva

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo CargaPasiva (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_CargaPasiva"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertCargaPasiva(ByVal vp_Obj_CargaPasiva As CGA_CargaPasivaClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT INTO CGA_CARGAPASIVA (" & _
            "CP_Maquina_ID," & _
            "CP_GRPMaquina_ID," & _
            "CP_Centro_ID," & _
            "CP_Requerimiento," & _
            "CP_Orden_ID," & _
            "CP_HorasPlan," & _
            "CP_N_Ofertas," & _
            "CP_FechaActualizacion," & _
            "CP_Usuario" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.Puestotrabajo_ID & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.GRPMaquina_ID & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.Centro_ID & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.Departamento & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.Orden_ID & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.HPlan & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.N_Oferta & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_CargaPasiva.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del CargaPasiva (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_CargaPasiva"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateCargaPasiva(ByVal vp_Obj_CargaPasiva As CGA_CargaPasivaClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE CGA_CARGAPASIVA SET " & _
                       " CP_Maquina_ID ='" & vp_Obj_CargaPasiva.Puestotrabajo_ID & "', " & _
                       " CP_GRPMaquina_ID ='" & vp_Obj_CargaPasiva.GRPMaquina_ID & "', " & _
                       " CP_Orden_ID ='" & vp_Obj_CargaPasiva.Orden_ID & "', " & _
                       " CP_HorasPlan ='" & vp_Obj_CargaPasiva.HPlan & "', " & _
                       " CP_N_Ofertas ='" & vp_Obj_CargaPasiva.N_Oferta & "', " & _
                       " CP_FechaActualizacion ='" & vp_Obj_CargaPasiva.FechaActualizacion & "', " & _
                       " CP_Usuario ='" & vp_Obj_CargaPasiva.Usuario & "' " & _
                       " WHERE CP_ID = '" & vp_Obj_CargaPasiva.CP_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la eliminacion del CargaPasiva (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_CargaPasiva"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EraseCargaPasiva(ByVal vp_Obj_CargaPasiva As CGA_CargaPasivaClass)

        Dim conex As New Conector
        Dim Result As String = ""
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQuery As String
        Dim SQL_general As New GeneralSQLClass

        sql.AppendLine("DELETE CGA_CARGAPASIVA WHERE CP_ID = '" & vp_Obj_CargaPasiva.CP_ID & "'")
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
    ''' funcion que consulta la tabla centro para el DDL DEPARTAMENTO DE SOLICITUD
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DDL_Departamento(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT  DDL_ID AS ID,DDLL_Descripcion AS descripcion FROM  TC_DDL_TIPO " & _
                   " WHERE DDL_Tabla ='CGA_CARGAPASIVA' ")
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
    ''' funcion que trae el listado de CargaPasiva para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listCargaPasiva(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objCargaPasiva As New CGA_CargaPasivaClass
            'cargamos datos sobre el objeto de login
            objCargaPasiva.CP_ID = ReadConsulta.GetValue(0)
            objCargaPasiva.Puestotrabajo_ID = ReadConsulta.GetValue(1)
            objCargaPasiva.GRPMaquina_ID = ReadConsulta.GetValue(2)
            objCargaPasiva.Centro_ID = ReadConsulta.GetValue(3)

            objCargaPasiva.Departamento = ReadConsulta.GetValue(4)
            objCargaPasiva.Orden_ID = ReadConsulta.GetValue(5)
            objCargaPasiva.HPlan = ReadConsulta.GetValue(6)
            objCargaPasiva.N_Oferta = ReadConsulta.GetValue(7)
            objCargaPasiva.FechaActualizacion = ReadConsulta.GetValue(8)
            objCargaPasiva.Usuario = ReadConsulta.GetValue(9)

            objCargaPasiva.Descrip_Puestotrabajo = ReadConsulta.GetString(10)
            objCargaPasiva.Descrip_GRPMaquina = ReadConsulta.GetString(11)
            objCargaPasiva.Descrip_Centro = ReadConsulta.GetString(12)
            objCargaPasiva.Descrip_Departamento = ReadConsulta.GetString(13)

            'agregamos a la lista
            ObjListCargaPasiva.Add(objCargaPasiva)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListCargaPasiva

    End Function


#End Region

End Class
