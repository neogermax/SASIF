Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CGA_TVC_InfSQLClass

#Region "CONSULTAS DROP LIST"

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

#Region "OTRAS CONSULTAS"

    ''' <summary>
    ''' funcion que consulta planta del centro
    ''' </summary>
    ''' <param name="vp_S_ID_Centro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchPlanta(ByVal vp_S_ID_Centro As String)

        Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT C_Descripcion_Planta FROM CGA_CENTROS C " & _
                   " WHERE C_Centro_ID = '" & vp_S_ID_Centro & "'")

        StrQuery = sql.ToString

        ObjlistTVCInf = conex.ObjLoad_All(StrQuery, "SearchPlanta")

        Return ObjlistTVCInf

    End Function

    ''' <summary>
    ''' funcion que consulta las ordenes segun los fitros
    ''' </summary>
    ''' <param name="vp_S_ID_maquina"></param>
    ''' <param name="vp_S_FechaIni"></param>
    ''' <param name="vp_S_FechaFin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridTVC(ByVal vp_S_ID_Centro As String, ByVal vp_S_ID_GRPmaquina As String, ByVal vp_S_ID_maquina As String, ByVal vp_S_FechaIni As String, ByVal vp_S_FechaFin As String)

        Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)
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
                   " ZPP078_Clase, " & _
                   " Centro_ID, " & _
                   " GRPMaquina_ID, " & _
                   " Puestotrabajo_ID, " & _
                   " C.C_Descripcion, " & _
                   " GRP.GRP_Descripcion, " & _
                   " M.M_Descripcion " & _
                   " FROM S_CGA S " & _
                   " INNER JOIN TC_S_ESTADO SE ON SE.Estado_ID = SUBSTRING(S.COOIS_O_StatusSistema, 1, 4) " & _
                   " INNER JOIN CGA_CENTROS C ON C.C_Centro_ID = S.Centro_ID " & _
                   " INNER JOIN  CGA_GRP_MAQUINAS GRP ON GRP.GRP_Maquina_ID = S.GRPMaquina_ID " & _
                   " INNER JOIN CGA_MAQUINA M ON M.M_Maquina_ID =S.Puestotrabajo_ID " & _
                   " WHERE COOIS_O_StatusSistema LIKE '%LIB%' " & _
                   " AND ZCOMCLI_FechaCreacion >= CONVERT(DATE,'" & vp_S_FechaIni & "',105) AND COOIS_P_Fechafinextrema <= CONVERT(DATE,'" & vp_S_FechaFin & "',105)")

        If vp_S_ID_Centro <> 0 Then
            sql.Append(" AND Centro_ID = '" & vp_S_ID_Centro & "' ")
            If vp_S_ID_GRPmaquina <> 0 Then
                sql.Append(" AND GRPMaquina_ID = '" & vp_S_ID_GRPmaquina & "' ")
                If vp_S_ID_maquina <> "0" Then
                    sql.Append(" AND Puestotrabajo_ID = '" & vp_S_ID_maquina & "' ")
                End If
            End If
        End If

        sql.Append(" ORDER bY Centro_ID, GRPMaquina_ID, Puestotrabajo_ID, Orden_ID, Operacion_ID ASC ")
        StrQuery = sql.ToString

        ObjlistTVCInf = conex.ObjLoad_All(StrQuery, "GridTVC_Inf")

        Return ObjlistTVCInf

    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae los datos planta por Centro
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListCentro(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read

            Dim objTVC_InfInf As New CGA_TVC_InfClass
            'cargamos datos sobre el objeto de login
            objTVC_InfInf.Descripcion_Planta = ReadConsulta.GetString(0)

            'agregamos a la lista
            ObjlistTVCInf.Add(objTVC_InfInf)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistTVCInf

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

        Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read

            Dim objTVC_Inf As New CGA_TVC_InfClass

            objTVC_Inf.Orden_ID = ReadConsulta.GetValue(0)
            objTVC_Inf.Operacion_ID = ReadConsulta.GetValue(1)

            If Not (IsDBNull(ReadConsulta.GetValue(2))) Then objTVC_Inf.FechaLiberacReal = ReadConsulta.GetValue(2) Else objTVC_Inf.FechaLiberacReal = ""
            If Not (IsDBNull(ReadConsulta.GetValue(3))) Then objTVC_Inf.FechaCier = ReadConsulta.GetValue(3) Else objTVC_Inf.FechaCier = ""
            If Not (IsDBNull(ReadConsulta.GetValue(4))) Then objTVC_Inf.FechaRegEntrega = ReadConsulta.GetValue(4) Else objTVC_Inf.FechaRegEntrega = ""
            If Not (IsDBNull(ReadConsulta.GetValue(5))) Then objTVC_Inf.DesStatusSistema = ReadConsulta.GetValue(5) Else objTVC_Inf.DesStatusSistema = ""
            If Not (IsDBNull(ReadConsulta.GetValue(6))) Then objTVC_Inf.FechaPreferenciaEntrega = ReadConsulta.GetValue(6) Else objTVC_Inf.FechaPreferenciaEntrega = ""
            If Not (IsDBNull(ReadConsulta.GetValue(7))) Then objTVC_Inf.StatusSistema = ReadConsulta.GetValue(7) Else objTVC_Inf.StatusSistema = ""

            If objTVC_Inf.FechaPreferenciaEntrega <> "1900-01-01" Then
                objTVC_Inf.SEMAFORO = Semaforo(objTVC_Inf.FechaPreferenciaEntrega, objTVC_Inf.StatusSistema)
            End If

            If Not (IsDBNull(ReadConsulta.GetValue(8))) Then objTVC_Inf.CantidadOperacion = ReadConsulta.GetValue(8) Else objTVC_Inf.CantidadOperacion = "0"
            If Not (IsDBNull(ReadConsulta.GetValue(9))) Then objTVC_Inf.ValorPrefijado_1 = ReadConsulta.GetValue(9) Else objTVC_Inf.ValorPrefijado_1 = "0"
            If Not (IsDBNull(ReadConsulta.GetValue(10))) Then objTVC_Inf.ValorPrefijado_2 = ReadConsulta.GetValue(10) Else objTVC_Inf.ValorPrefijado_2 = "0"
            If Not (IsDBNull(ReadConsulta.GetValue(11))) Then objTVC_Inf.ActivNotificada_1 = ReadConsulta.GetValue(11) Else objTVC_Inf.ActivNotificada_1 = "0"
            If Not (IsDBNull(ReadConsulta.GetValue(12))) Then objTVC_Inf.ActivNotificada_2 = ReadConsulta.GetValue(12) Else objTVC_Inf.ActivNotificada_2 = "0"

            objTVC_Inf.Clase = ReadConsulta.GetValue(13)

            objTVC_Inf.Centro_ID = ReadConsulta.GetValue(14)
            objTVC_Inf.GRPMaquina_ID = ReadConsulta.GetValue(15)
            objTVC_Inf.Puestotrabajo_ID = ReadConsulta.GetValue(16)

            objTVC_Inf.Descrip_Centro = ReadConsulta.GetValue(17)
            objTVC_Inf.Descrip_GRPMaquina = ReadConsulta.GetValue(18)
            objTVC_Inf.Descrip_Puestotrabajo = ReadConsulta.GetValue(19)


            If objTVC_Inf.DesStatusSistema = "CERRADA TECNICAMENTE" Or objTVC_Inf.DesStatusSistema = "NOTIFICACION FINAL" Then
                objTVC_Inf.TPlaneado = Calculo_TPlaneado(objTVC_Inf.ValorPrefijado_1, objTVC_Inf.ValorPrefijado_2, objTVC_Inf.CantidadOperacion)
                objTVC_Inf.TReal = Calculo_TReal(objTVC_Inf.ActivNotificada_1, objTVC_Inf.ActivNotificada_2)

                If objTVC_Inf.TPlaneado <> 0 And objTVC_Inf.TReal <> 0 Then
                    objTVC_Inf.TIEMPO = Convert.ToDecimal(objTVC_Inf.TReal) / Convert.ToDecimal(objTVC_Inf.TPlaneado)
                Else
                    objTVC_Inf.TIEMPO = 0
                End If

            End If

            'agregamos a la lista
            ObjlistTVCInf.Add(objTVC_Inf)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistTVCInf

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

        Dim total As Integer = 0

        total = (vp_D_Maquina * vp_I_Cantidad) + vp_D_Preparacion

        Return total

    End Function

    ''' <summary>
    ''' calcula el tiempo real por registro
    ''' </summary>
    ''' <param name="vp_D_Preparacion"></param>
    ''' <param name="vp_D_Maquina"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Calculo_TReal(ByVal vp_D_Preparacion As Decimal, ByVal vp_D_Maquina As Decimal)

        Dim total As Integer = 0

        total = vp_D_Maquina + vp_D_Preparacion

        Return total

    End Function

#End Region


End Class
