Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class CGA_TVC_OpSQLClass

#Region "CRUD"

    ''' <summary>
    ''' funcion que crea el query para la insercion de la tabla DETALLE_TVC_OP (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_TVCDeT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertTVC(ByVal vp_Obj_TVCDeT As CGA_TVC_OPDetClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""
        sql.AppendLine("INSERT DETALLE_TVC_OP (" & _
           "Centro_ID," & _
           "Puestotrabajo_ID," & _
           "Orden_ID," & _
           "Operacion_ID," & _
           "Turno_ID," & _
           "Operario_ID," & _
           "CausalSAP_ID," & _
           "Causal_ID," & _
           "Observacion_Ope," & _
           "Descripcion_Analis," & _
           "Accion_ID," & _
           "Fec_Ent_Accion," & _
           "Area_ID," & _
           "Fec_Creacion," & _
           "Estado," & _
           "FechaActualizacion," & _
           "Usuario" & _
           ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Centro_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Puestotrabajo_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Orden_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Operacion_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Turno_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Operario_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.CausalSAP_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Causal_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Observacion_Ope & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Descripcion_Analis & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Accion_ID & "',")
        sql.AppendLine("CONVERT(DATE,SUBSTRING(REPLACE('" & vp_Obj_TVCDeT.Fec_Ent_Accion & "','/','-'),1,10),103),")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Area_ID & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Fec_Creacion & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Estado & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.FechaActualizacion & "',")
        sql.AppendLine("'" & vp_Obj_TVCDeT.Usuario & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion de la tabla DETALLE_TVC_OP (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_TVCDeT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateTVC(ByVal vp_Obj_TVCDeT As CGA_TVC_OPDetClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine(" UPDATE DETALLE_TVC_OP SET " & _
                       " Descripcion_Analis ='" & vp_Obj_TVCDeT.Descripcion_Analis & "'," & _
                       " Accion_ID ='" & vp_Obj_TVCDeT.Accion_ID & "'," & _
                       " Fec_Ent_Accion =convert(date,'" & vp_Obj_TVCDeT.Fec_Ent_Accion & "',105)," & _
                       " Area_ID ='" & vp_Obj_TVCDeT.Area_ID & "'," & _
                       " Estado ='" & vp_Obj_TVCDeT.Estado & "'," & _
                       " FechaActualizacion ='" & vp_Obj_TVCDeT.FechaActualizacion & "'," & _
                       " Usuario ='" & vp_Obj_TVCDeT.Usuario & "'" & _
                       " WHERE Fec_Creacion = '" & vp_Obj_TVCDeT.Fec_Creacion & "'")

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

        sql.Append(" SELECT M_Maquina_ID As ID, M_Descripcion As descripcion FROM CGA_MAQUINA ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist


    End Function

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList_operario(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT O_Operario_ID As ID,O_Nombre As descripcion FROM CGA_OPERARIOS ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist


    End Function

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList_Causal(ByVal vp_S_Type As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT Ca_Causal_ID As ID,Ca_Descripcion As descripcion,Ca_Tipo FROM CGA_CAUSALES " & _
                   " WHERE Ca_Tipo = " & vp_S_Type)
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General_FLEX")

        Return ObjListDroplist


    End Function

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList_Turno(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT T_Turno_ID As ID,T_Descripcion As descripcion FROM CGA_TURNOS ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList_Accion(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT Ac_Accion_ID As ID, Ac_Descripcion As descripcion FROM CGA_ACCIONES ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList_Area(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT A_Area_ID As ID, A_Descripcion As descripcion FROM CGA_AREA ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist

    End Function

#End Region

#Region "OTRAS CONSULTAS"

    ''' <summary>
    ''' funcion que consulta el centro y planta del puesto de trabajo o maquina
    ''' </summary>
    ''' <param name="vp_S_ID_maquina"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchCentroPlanta(ByVal vp_S_ID_maquina As String)

        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT C_Centro_ID, C_Descripcion, C_Descripcion_Planta FROM CGA_CENTROS C " & _
                   " INNER JOIN CGA_MAQUINA M ON M.M_Centro_ID = C.C_Centro_ID " & _
                   " WHERE M_Maquina_ID = '" & vp_S_ID_maquina & "'")
        StrQuery = sql.ToString

        ObjlistTVC = conex.ObjLoad_All(StrQuery, "SearchCentroPlanta")

        Return ObjlistTVC

    End Function

    ''' <summary>
    ''' funcion que consulta las ordenes segun los fitros
    ''' </summary>
    ''' <param name="vp_S_ID_maquina"></param>
    ''' <param name="vp_S_FechaIni"></param>
    ''' <param name="vp_S_FechaFin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridTVC(ByVal vp_S_ID_maquina As String, ByVal vp_S_FechaIni As String, ByVal vp_S_FechaFin As String)

        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT Orden_ID, " & _
                   " Operacion_ID, " & _
                   " CONVERT(VARCHAR ,COOIS_P_FechaLiberacReal,103) AS F_Libe, " & _
                   " CONVERT(VARCHAR ,ZSD040_2_FechaCier,103) AS F_Cier, " & _
                   " CONVERT(VARCHAR ,ZCOMCLI_FechaRegEntrega,103) AS F_Despacho, " & _
                   " SE.Descripcion, " & _
                   " ZSD040_2_FecPre, " & _
                   " COOIS_O_StatusSistema, " & _
                   " COOIS_O_CantidadOperacion, " & _
                   " COOIS_O_ValorPrefijado_1, " & _
                   " COOIS_O_ValorPrefijado_2, " & _
                   " COOIS_O_ActivNotificada_1, " & _
                   " COOIS_O_ActivNotificada_2, " & _
                   " ZPP078_Clase " & _
                   " FROM S_CGA S" & _
                   " INNER JOIN TC_S_ESTADO SE ON SE.Estado_ID = SUBSTRING(S.COOIS_O_StatusSistema, 1, 4) " & _
                   " WHERE COOIS_O_StatusSistema LIKE '%LIB%' AND Puestotrabajo_ID = '" & vp_S_ID_maquina & "' " & _
                   " AND ZCOMCLI_FechaCreacion >= CONVERT(DATE,'" & vp_S_FechaIni & "',105) AND COOIS_P_Fechafinextrema <= CONVERT(DATE,'" & vp_S_FechaFin & "',105)" & _
                   " ORDER bY Orden_ID,Operacion_ID ASC ")
        StrQuery = sql.ToString

        ObjlistTVC = conex.ObjLoad_All(StrQuery, "GridTVC")

        Return ObjlistTVC

    End Function

    ''' <summary>
    ''' consulta el detalle de la orden seleccionada
    ''' </summary>
    ''' <param name="vp_S_Maq"></param>
    ''' <param name="vp_S_Orden"></param>
    ''' <param name="vp_S_Opera"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EncTVCDet(ByVal vp_S_Maq As String, ByVal vp_S_Orden As String, ByVal vp_S_Opera As String, ByVal vp_S_Centro As String)

        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT Orden_ID, " & _
                 " Operacion_ID, " & _
                 " CONVERT(VARCHAR ,COOIS_P_FechaLiberacReal,103) AS F_Libe, " & _
                 " CONVERT(VARCHAR ,ZSD040_2_FechaCier,103) AS F_Cier, " & _
                 " CONVERT(VARCHAR ,ZCOMCLI_FechaRegEntrega,103) AS F_Despacho, " & _
                 " SE.Descripcion, " & _
                 " COOIS_O_StatusSistema, " & _
                 " ZSD040_2_FecCre, " & _
                 " Puestotrabajo_ID " & _
                 " FROM S_CGA S" & _
                 " INNER JOIN TC_S_ESTADO SE ON SE.Estado_ID = SUBSTRING(S.COOIS_O_StatusSistema, 1, 4) " & _
                 " WHERE Puestotrabajo_ID ='" & vp_S_Maq & "' AND Centro_ID = '" & vp_S_Centro & "' " & _
                 " AND Orden_ID = '" & vp_S_Orden & "' AND Operacion_ID = '" & vp_S_Opera & "'")
        StrQuery = sql.ToString

        ObjlistTVC = conex.ObjLoad_All(StrQuery, "EncTVCDet")

        Return ObjlistTVC

    End Function

    ''' <summary>
    ''' consulta que trae los datos del grid de TVC_detalle
    ''' </summary>
    ''' <param name="vp_S_Maq"></param>
    ''' <param name="vp_S_Orden"></param>
    ''' <param name="vp_S_Opera"></param>
    ''' <param name="vp_S_Centro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridDetTVC(ByVal vp_S_Maq As String, ByVal vp_S_Orden As String, ByVal vp_S_Opera As String, ByVal vp_S_Centro As String)

        Dim ObjlistTVC As New List(Of CGA_TVC_OPDetClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT DTVC.Operario_ID, " & _
                   "	   O.O_Nombre, " & _
                   "	   DTVC.Causal_ID, " & _
                   "	   C.Ca_Descripcion, " & _
                   "	   DTVC.Observacion_Ope, " & _
                   "	   DTVC.Descripcion_Analis, " & _
                   "	   DTVC.Accion_ID, " & _
                   "	   A.Ac_Descripcion, " & _
                   "	   CONVERT(VARCHAR,Fec_Ent_Accion,103) AS Fec_Accion, " & _
                   "	   AR.A_Descripcion, " & _
                   "	   DTVC.Centro_ID, " & _
                   "	   DTVC.Puestotrabajo_ID, " & _
                   "	   DTVC.Orden_ID, " & _
                   "	   DTVC.Operacion_ID, " & _
                   "	   DTVC.Turno_ID, " & _
                   "	   DTVC.CausalSAP_ID, " & _
                   "	   DTVC.Fec_Creacion, " & _
                   "       DTVC.Estado, " & _
                   "	   TC.DDLL_Descripcion, " & _
                   "       DTVC.Area_ID " & _
                   " FROM DETALLE_TVC_OP DTVC " & _
                   " INNER JOIN CGA_OPERARIOS O ON O.O_Operario_ID = DTVC.Operario_ID " & _
                   " INNER JOIN CGA_CAUSALES C ON C.Ca_Causal_ID = DTVC.Causal_ID " & _
                   " LEFT JOIN CGA_ACCIONES A ON A.Ac_Accion_ID = DTVC.Accion_ID " & _
                   " LEFT JOIN CGA_AREA AR ON AR.A_Area_ID = DTVC.Area_ID " & _
                   " INNER JOIN TC_DDL_TIPO TC ON DTVC.Estado = TC.DDL_ID " & _
                " WHERE Puestotrabajo_ID ='" & vp_S_Maq & "' AND Centro_ID = '" & vp_S_Centro & "' " & _
                " AND Orden_ID = '" & vp_S_Orden & "' AND Operacion_ID = '" & vp_S_Opera & "'" & _
                " AND tc.DDL_Tabla ='CGA_TVC_DET' " & _
                " ORDER BY Fec_Creacion DESC ")
        StrQuery = sql.ToString

        ObjlistTVC = conex.ObjLoad_All(StrQuery, "GridTVCDet")

        Return ObjlistTVC


    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae los datos de centro y planta por puesto de trabajo o maquina
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListCentroMaquina(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read

            Dim objTVC As New CGA_TVC_OpClass
            'cargamos datos sobre el objeto de login
            objTVC.Centro_ID = ReadConsulta.GetValue(0)
            objTVC.Descripcion = ReadConsulta.GetString(1)
            objTVC.Descripcion_Planta = ReadConsulta.GetString(2)

            'agregamos a la lista
            ObjlistTVC.Add(objTVC)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistTVC

    End Function

    ''' <summary>
    ''' trae el listado de ordenes por puesto de trabajo
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListTVC(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        Try

            While ReadConsulta.Read

                Dim objTVC As New CGA_TVC_OpClass

                objTVC.Orden_ID = ReadConsulta.GetValue(0)
                objTVC.Operacion_ID = ReadConsulta.GetValue(1)

                If Not (IsDBNull(ReadConsulta.GetValue(2))) Then objTVC.FechaLiberacReal = ReadConsulta.GetValue(2) Else objTVC.FechaLiberacReal = ""
                If Not (IsDBNull(ReadConsulta.GetValue(3))) Then objTVC.FechaCier = ReadConsulta.GetValue(3) Else objTVC.FechaCier = ""
                If Not (IsDBNull(ReadConsulta.GetValue(4))) Then objTVC.FechaRegEntrega = ReadConsulta.GetValue(4) Else objTVC.FechaRegEntrega = ""
                If Not (IsDBNull(ReadConsulta.GetValue(5))) Then objTVC.DesStatusSistema = ReadConsulta.GetValue(5) Else objTVC.DesStatusSistema = ""
                If Not (IsDBNull(ReadConsulta.GetValue(6))) Then objTVC.FechaPreferenciaEntrega = ReadConsulta.GetValue(6) Else objTVC.FechaPreferenciaEntrega = ""
                If Not (IsDBNull(ReadConsulta.GetValue(7))) Then objTVC.StatusSistema = ReadConsulta.GetValue(7) Else objTVC.StatusSistema = ""

                If objTVC.FechaPreferenciaEntrega <> "1900-01-01" Then
                    objTVC.SEMAFORO = Semaforo(objTVC.FechaPreferenciaEntrega, objTVC.StatusSistema)
                End If

                If Not (IsDBNull(ReadConsulta.GetValue(8))) Then objTVC.CantidadOperacion = ReadConsulta.GetValue(8) Else objTVC.CantidadOperacion = "0"
                If Not (IsDBNull(ReadConsulta.GetValue(9))) Then objTVC.ValorPrefijado_1 = ReadConsulta.GetValue(9) Else objTVC.ValorPrefijado_1 = "0"
                If Not (IsDBNull(ReadConsulta.GetValue(10))) Then objTVC.ValorPrefijado_2 = ReadConsulta.GetValue(10) Else objTVC.ValorPrefijado_2 = "0"
                If Not (IsDBNull(ReadConsulta.GetValue(11))) Then objTVC.ActivNotificada_1 = ReadConsulta.GetValue(11) Else objTVC.ActivNotificada_1 = "0"
                If Not (IsDBNull(ReadConsulta.GetValue(12))) Then objTVC.ActivNotificada_2 = ReadConsulta.GetValue(12) Else objTVC.ActivNotificada_2 = "0"

                objTVC.Clase = ReadConsulta.GetValue(13)

                If objTVC.DesStatusSistema = "CERRADA TECNICAMENTE" Or objTVC.DesStatusSistema = "NOTIFICACION FINAL" Then
                    objTVC.TPlaneado = Calculo_TPlaneado(objTVC.ValorPrefijado_1, objTVC.ValorPrefijado_2, objTVC.CantidadOperacion)
                    objTVC.TReal = Calculo_TReal(objTVC.ActivNotificada_1, objTVC.ActivNotificada_2)

                    If objTVC.TPlaneado <> 0 And objTVC.TReal <> 0 Then
                        objTVC.TIEMPO = Convert.ToDecimal(objTVC.TReal) / Convert.ToDecimal(objTVC.TPlaneado)
                    Else
                        objTVC.TIEMPO = 0
                    End If

                End If


                'agregamos a la lista
                ObjlistTVC.Add(objTVC)

            End While
        Catch ex As Exception

        End Try

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistTVC


    End Function

    ''' <summary>
    ''' trae el listado de detalle de la orden seleccionada por operacion y puesto de trabajo
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListEncTVCDet(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read

            Dim objTVC As New CGA_TVC_OpClass

            objTVC.Orden_ID = ReadConsulta.GetValue(0)
            objTVC.Operacion_ID = ReadConsulta.GetValue(1)
            objTVC.FechaLiberacReal = ReadConsulta.GetValue(2)
            objTVC.FechaCier = ReadConsulta.GetValue(3)
            objTVC.FechaRegEntrega = ReadConsulta.GetValue(4)
            objTVC.DesStatusSistema = ReadConsulta.GetValue(5)
            objTVC.StatusSistema = ReadConsulta.GetValue(6)
            
            If Not (IsDBNull(ReadConsulta.GetValue(7))) Then objTVC.FechaPreferenciaEntrega = ReadConsulta.GetValue(7) Else objTVC.FechaPreferenciaEntrega = "01/01/1900"

            objTVC.Puestotrabajo_ID = ReadConsulta.GetValue(8)

            objTVC.SEMAFORO = Semaforo(objTVC.FechaPreferenciaEntrega, objTVC.StatusSistema)

            'agregamos a la lista
            ObjlistTVC.Add(objTVC)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistTVC

    End Function

    ''' <summary>
    ''' trae el listado de detalle de la orden seleccionada por operacion y puesto de trabajo
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListGridTVCDet(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjlistTVC As New List(Of CGA_TVC_OPDetClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        While ReadConsulta.Read

            Dim objTVC As New CGA_TVC_OPDetClass

            objTVC.Operario_ID = ReadConsulta.GetValue(0)
            objTVC.DESOperario = ReadConsulta.GetValue(1)
            objTVC.Causal_ID = ReadConsulta.GetValue(2)
            objTVC.DESCausal = ReadConsulta.GetValue(3)
            objTVC.Observacion_Ope = ReadConsulta.GetValue(4)
            objTVC.Descripcion_Analis = ReadConsulta.GetValue(5)

            If Not (IsDBNull(ReadConsulta.GetValue(6))) Then objTVC.Accion_ID = ReadConsulta.GetValue(6) Else objTVC.Accion_ID = 0
            If Not (IsDBNull(ReadConsulta.GetValue(7))) Then objTVC.DESAccion = ReadConsulta.GetValue(7) Else objTVC.DESAccion = ""
            If Not (IsDBNull(ReadConsulta.GetValue(8))) Then objTVC.Fec_Ent_Accion = ReadConsulta.GetValue(8) Else objTVC.Fec_Ent_Accion = ""
            If Not (IsDBNull(ReadConsulta.GetValue(9))) Then objTVC.DESArea = ReadConsulta.GetValue(9) Else objTVC.DESArea = ""

            objTVC.Centro_ID = ReadConsulta.GetValue(10)
            objTVC.Puestotrabajo_ID = ReadConsulta.GetValue(11)
            objTVC.Orden_ID = ReadConsulta.GetValue(12)
            objTVC.Operacion_ID = ReadConsulta.GetValue(13)
            objTVC.Turno_ID = ReadConsulta.GetValue(14)
            objTVC.CausalSAP_ID = ReadConsulta.GetValue(15)
            objTVC.Fec_Creacion = ReadConsulta.GetValue(16)
            objTVC.Estado_ID = ReadConsulta.GetValue(17)
            objTVC.Estado = ReadConsulta.GetValue(18)
            objTVC.Area_ID = ReadConsulta.GetValue(19)

            If objTVC.Fec_Ent_Accion = "01/01/1900" Then
                objTVC.Fec_Ent_Accion = ""
            End If
            'agregamos a la lista
            ObjlistTVC.Add(objTVC)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistTVC

    End Function

#End Region

#Region "FUNCIONES"

    ''' <summary>
    ''' FUNCION QUE TRAE EL RESULTADO PARA EL SEMAFORO
    ''' </summary>
    ''' <param name="vp_D_Fecha"></param>
    ''' <param name="vp_S_Estado"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Semaforo(ByVal vp_D_Fecha As Date, ByVal vp_S_Estado As String)
        '#222222 BL
        Dim color As String = "#222222"
        Dim c_Estado = vp_S_Estado.Split(New [Char]() {" "c})

        If vp_D_Fecha < Date.Now.Date Then
            '#CD0A0A rojo
            color = "#CD0A0A"
        End If
        If vp_D_Fecha = Date.Now.Date And c_Estado(0) = "NOTI" Then
            '#FAD42E amarillo
            color = "#FAD42E"
        End If
        If vp_D_Fecha = Date.Now.Date And c_Estado(0) = "NOTP" Then
            '#E17009 naranja
            color = "#E17009"
        End If
        If vp_D_Fecha >= Date.Now.Date And c_Estado(0) = "CTEC" Then
            '#4BD612 verde
            color = "#4BD612"
        End If

        Return color

    End Function

    ''' <summary>
    ''' calcula el tiempo planeado por registro
    ''' </summary>
    ''' <param name="vp_D_Preparacion"></param>
    ''' <param name="vp_D_Maquina"></param>
    ''' <param name="vp_I_Cantidad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Calculo_TPlaneado(ByVal vp_D_Preparacion As Decimal, ByVal vp_D_Maquina As Decimal, ByVal vp_I_Cantidad As Integer)

        Dim total As Decimal = 0
        Try
            total = (vp_D_Maquina * vp_I_Cantidad) + vp_D_Preparacion

        Catch ex As Exception
            total = 0
        End Try


        Return total

    End Function

    ''' <summary>
    ''' calcula el tiempo real por registro
    ''' </summary>
    ''' <param name="vp_D_Maquina"></param>
    ''' <param name="vp_D_Preparacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Calculo_TReal(ByVal vp_D_Preparacion As Decimal, ByVal vp_D_Maquina As Decimal)

        Dim total As Integer = 0

        total = vp_D_Maquina + vp_D_Preparacion

        Return total

    End Function

#End Region

End Class
