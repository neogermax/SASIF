Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class OpeTurnosSQLClass

#Region "CRUD"

    ''' <summary>
    ''' funcion que inserta en la BD el turno programado
    ''' </summary>
    ''' <param name="ObjTurno_Ope"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insert(ByVal ObjTurno_Ope As OpeTurnosClass)

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


#End Region

#Region "OTRAS CONSULTAS"

    ''' <summary>
    ''' funcion que consulta el centro y planta del puesto de trabajo o maquina
    ''' </summary>
    ''' <param name="vp_S_ID_maquina"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchCentroPlanta(ByVal vp_S_ID_maquina As String)

        Dim ObjlistOpeTurnos As New List(Of OpeTurnosClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector
        Dim ruta_conex As String = conex.typeConexion()

        Dim sql As New StringBuilder

        sql.Append(" SELECT C_Centro_ID, C_Descripcion, C_Descripcion_Planta FROM CGA_CENTROS C " & _
                   " INNER JOIN CGA_MAQUINA M ON M.M_Centro_ID = C.C_Centro_ID " & _
                   " WHERE M_Maquina_ID = '" & vp_S_ID_maquina & "'")
        StrQuery = sql.ToString


        ObjlistOpeTurnos = ListCentroMaquina(StrQuery, ruta_conex)

        Return ObjlistOpeTurnos

    End Function

    ''' <summary>
    ''' funcion que consulta todo los festivos del año
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AllFestivos()

        Dim ObjlistFestivos As New List(Of CGA_FestivosClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector
        Dim ruta_conex As String = conex.typeConexion()

        Dim sql As New StringBuilder

        sql.Append("SELECT F_Año, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 1, 2)as Mes, SUBSTRING(convert(nvarchar(4),F_Mes_Dia), 3, 4)as Dia  FROM CGA_Festivos ")

        StrQuery = sql.ToString

        ObjlistFestivos = listFestivos(StrQuery, ruta_conex)

        Return ObjlistFestivos
    End Function

    ''' <summary>
    ''' funcion que consulta los tiempos de los turnos en la BD
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Allturno()

        Dim ObjlistTurno As New List(Of CGA_TurnosClass)

        Dim StrQuery As String = ""
        Dim conex As New Conector
        Dim ruta_conex As String = conex.typeConexion()

        Dim sql As New StringBuilder

        sql.Append("SELECT T_Turno_ID,T_HoraInicio,T_Tiempo FROM CGA_TURNOS ")

        StrQuery = sql.ToString

        ObjlistTurno = listTurnos(StrQuery, ruta_conex)

        Return ObjlistTurno

    End Function

    ''' <summary>
    ''' funcion que consulta si eseditar o crear turnos
    ''' </summary>
    ''' <param name="ObjTurno_OP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ReadExist(ByVal ObjTurno_OP As OpeTurnosClass)

        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.AppendLine("SELECT COUNT(1) FROM CGA_TURNOS_OPERACIONAL" & _
                       " WHERE  TO_Maquina_ID = '" & ObjTurno_OP.PuestoTrabajo_ID & _
                       "' AND TO_Ano_Mes_ID ='" & ObjTurno_OP.Ano_Mes_ID & "'")

        StrQuery = sql.ToString

        Dim Result As String = conex.IDis(StrQuery)

        Return Result

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

        Dim ObjlistOpeTurnos As New List(Of OpeTurnosClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read

            Dim objOpeTurnos As New OpeTurnosClass
            'cargamos datos sobre el objeto de login
            objOpeTurnos.Centro_ID = ReadConsulta.GetValue(0)
            objOpeTurnos.Descripcion = ReadConsulta.GetString(1)
            objOpeTurnos.Descripcion_Planta = ReadConsulta.GetString(2)

            'agregamos a la lista
            ObjlistOpeTurnos.Add(objOpeTurnos)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjlistOpeTurnos

    End Function

    ''' <summary>
    ''' funcion que trae los datos de los festivos
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
            objFestivos.StrMes = ReadConsulta.GetValue(1)
            objFestivos.StrDia = ReadConsulta.GetValue(2)

            'agregamos a la lista
            ObjListFestivos.Add(objFestivos)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListFestivos

    End Function

    Public Function listTurnos(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListTurno As New List(Of CGA_TurnosClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objTurno As New CGA_TurnosClass
            'cargamos datos sobre el objeto de login
            objTurno.Turno_ID = ReadConsulta.GetValue(0)
            objTurno.HoraInicio = ReadConsulta.GetValue(1)
            objTurno.Tiempo = ReadConsulta.GetValue(2)

            'agregamos a la lista
            ObjListTurno.Add(objTurno)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListTurno

    End Function


#End Region


End Class
