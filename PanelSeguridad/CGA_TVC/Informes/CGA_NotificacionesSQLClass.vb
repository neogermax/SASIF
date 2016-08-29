Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_NotificacionesSQLClass

#Region "OTRAS CONSULTAS"

    ''' <summary>
    ''' funcion que consulta las ordenes segun los fitros
    ''' </summary>
    ''' <param name="vp_S_ID_maquina"></param>
    ''' <param name="vp_S_FechaIni"></param>
    ''' <param name="vp_S_FechaFin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridNotificaciones(ByVal vp_S_ID_Centro As String, ByVal vp_S_ID_GRPmaquina As String, ByVal vp_S_ID_maquina As String, ByVal vp_S_FechaIni As String, ByVal vp_S_FechaFin As String)

        Dim ObjlistNotificacion As New List(Of CGA_NotificacionesClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append("SELECT 	Centro_ID,	 " & _
                    " 	Orden_ID,	 " & _
                    " 	Puestotrabajo_ID,	 " & _
                    " 	ZPP078_N_Pedido,	 " & _
                    " 	ZPP078_Posicion,	 " & _
                    " 	ZPP078_Nombre,	 " & _
                    " 	ZPP078_N_Personal,	 " & _
                    " 	ZPP078_NombrePersonal,	 " & _
                    " 	ZPP078_FechaIni,	 " & _
                    " 	ZPP078_Duracmin,	 " & _
                    " 	ZPP079_N_Personal,	 " & _
                    " 	ZPP079_NombrePersonal,	 " & _
                    " 	ZPP079_FechaIni,	 " & _
                    " 	ZPP079_Duracmin,	 " & _
                    " 	ZPP079_DescMotivo,	 " & _
                    " 	KSB1_Cccoste,	 " & _
                    " 	KSB1_OrdPartner,	 " & _
                    " 	KSB1_N_pers,	 " & _
                    " 	KSB1_FeContab,	 " & _
                    " 	KSB1_CtdReg,	 " & _
                    " 	KSB1_ClAct,	 " & _
                    " 	KSB1_Usuario,	 " & _
                    "   C_Descripcion, " & _
                    "   M_Descripcion " & _
                   " FROM S_CGA S	 " & _
                   " INNER JOIN TC_S_ESTADO SE ON SE.Estado_ID = SUBSTRING(S.COOIS_O_StatusSistema, 1, 4) " & _
                   " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = S.Centro_ID " & _
                   " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID = S.Puestotrabajo_ID " & _
                   " WHERE COOIS_O_StatusSistema LIKE '%LIB%' " & _
                   " AND ZCOMCLI_FechaCreacion >= CONVERT(DATE,'" & vp_S_FechaIni & "',105) AND COOIS_O_FechaFinMasTardia <= CONVERT(DATE,'" & vp_S_FechaFin & "',105)")

        If vp_S_ID_Centro <> 0 Then
            sql.Append(" AND Centro_ID = '" & vp_S_ID_Centro & "' ")
            If vp_S_ID_GRPmaquina <> 0 Then
                sql.Append(" AND GRPMaquina_ID = '" & vp_S_ID_GRPmaquina & "' ")
                If vp_S_ID_maquina <> "0" Then
                    sql.Append(" AND Puestotrabajo_ID = '" & vp_S_ID_maquina & "' ")
                End If
            End If
        End If

        sql.Append(" ORDER bY Orden_ID ASC ")
        StrQuery = sql.ToString

        ObjlistNotificacion = conex.ObjLoad_All(StrQuery, "GridNotificacion")

        Return ObjlistNotificacion

    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' trae el listado de ordenes por puesto de trabajo
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListNotificacion(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjlistNotificacion As New List(Of CGA_NotificacionesClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read

            Dim objNotif As New CGA_NotificacionesClass

            objNotif.Centro_ID = ReadConsulta.GetValue(0)
            objNotif.Orden_ID = ReadConsulta.GetValue(1)
            objNotif.Puestotrabajo_ID = ReadConsulta.GetValue(2)

            If Not (IsDBNull(ReadConsulta.GetValue(3))) Then objNotif.ZPP078_N_Pedido = ReadConsulta.GetValue(3) Else objNotif.ZPP078_N_Pedido = ""
            If Not (IsDBNull(ReadConsulta.GetValue(4))) Then objNotif.ZPP078_Posicion = ReadConsulta.GetValue(4) Else objNotif.ZPP078_Posicion = ""
            If Not (IsDBNull(ReadConsulta.GetValue(5))) Then objNotif.ZPP078_Nombre = ReadConsulta.GetValue(5) Else objNotif.ZPP078_Nombre = ""
            If Not (IsDBNull(ReadConsulta.GetValue(6))) Then objNotif.ZPP078_N_Personal = ReadConsulta.GetValue(6) Else objNotif.ZPP078_N_Personal = ""
            If Not (IsDBNull(ReadConsulta.GetValue(7))) Then objNotif.ZPP078_NombrePersonal = ReadConsulta.GetValue(7) Else objNotif.ZPP078_NombrePersonal = ""
            If Not (IsDBNull(ReadConsulta.GetValue(8))) Then objNotif.ZPP078_FechaIni = ReadConsulta.GetValue(8) Else objNotif.ZPP078_FechaIni = ""
            If Not (IsDBNull(ReadConsulta.GetValue(9))) Then objNotif.ZPP078_Duracmin = ReadConsulta.GetValue(9) Else objNotif.ZPP078_Duracmin = ""

            If Not (IsDBNull(ReadConsulta.GetValue(10))) Then objNotif.ZPP079_N_Personal = ReadConsulta.GetValue(10) Else objNotif.ZPP079_N_Personal = ""
            If Not (IsDBNull(ReadConsulta.GetValue(11))) Then objNotif.ZPP079_NombrePersonal = ReadConsulta.GetValue(11) Else objNotif.ZPP079_NombrePersonal = ""
            If Not (IsDBNull(ReadConsulta.GetValue(12))) Then objNotif.ZPP079_FechaIni = ReadConsulta.GetValue(12) Else objNotif.ZPP079_FechaIni = ""
            If Not (IsDBNull(ReadConsulta.GetValue(13))) Then objNotif.ZPP079_Duracmin = ReadConsulta.GetValue(13) Else objNotif.ZPP079_Duracmin = ""
            If Not (IsDBNull(ReadConsulta.GetValue(14))) Then objNotif.ZPP079_DescMotivo = ReadConsulta.GetValue(14) Else objNotif.ZPP079_DescMotivo = ""

            If Not (IsDBNull(ReadConsulta.GetValue(15))) Then objNotif.KSB1_Cccoste = ReadConsulta.GetValue(15) Else objNotif.KSB1_Cccoste = ""
            If Not (IsDBNull(ReadConsulta.GetValue(16))) Then objNotif.KSB1_OrdPartner = ReadConsulta.GetValue(16) Else objNotif.KSB1_OrdPartner = ""
            If Not (IsDBNull(ReadConsulta.GetValue(17))) Then objNotif.KSB1_N_pers = ReadConsulta.GetValue(17) Else objNotif.KSB1_N_pers = ""
            If Not (IsDBNull(ReadConsulta.GetValue(18))) Then objNotif.KSB1_FeContab = ReadConsulta.GetValue(18) Else objNotif.KSB1_FeContab = ""
            If Not (IsDBNull(ReadConsulta.GetValue(19))) Then objNotif.KSB1_CtdReg = ReadConsulta.GetValue(19) Else objNotif.KSB1_CtdReg = ""
            If Not (IsDBNull(ReadConsulta.GetValue(20))) Then objNotif.KSB1_ClAct = ReadConsulta.GetValue(20) Else objNotif.KSB1_ClAct = ""
            If Not (IsDBNull(ReadConsulta.GetValue(21))) Then objNotif.KSB1_Usuario = ReadConsulta.GetValue(21) Else objNotif.KSB1_Usuario = ""

            If Not (IsDBNull(ReadConsulta.GetValue(22))) Then objNotif.DescripCentro = ReadConsulta.GetValue(22) Else objNotif.DescripCentro = ""
            If Not (IsDBNull(ReadConsulta.GetValue(23))) Then objNotif.DescripMaquina = ReadConsulta.GetValue(23) Else objNotif.DescripMaquina = ""

            'agregamos a la lista
            ObjlistNotificacion.Add(objNotif)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistNotificacion

    End Function

#End Region


End Class
