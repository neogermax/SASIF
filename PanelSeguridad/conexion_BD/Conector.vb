Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Conector
#Region "variables globales"

    Dim vg_S_Servidor_SQL_express As String = System.Web.Configuration.WebConfigurationManager.AppSettings("SerCGA").ToString
    Dim vg_S_TypeBD As String = System.Web.Configuration.WebConfigurationManager.AppSettings("Type").ToString
    Dim vg_S_Ruta_SLQCOMPACT As String = System.Web.Configuration.WebConfigurationManager.AppSettings("RutaSerCompact").ToString
    Dim vg_S_Pass_SLQCOMPACT As String = System.Web.Configuration.WebConfigurationManager.AppSettings("PDWCGACompact").ToString
    Dim vg_S_PWD_SQL_express As String = System.Web.Configuration.WebConfigurationManager.AppSettings("PDWCGA").ToString
    Dim vg_S_User_SQL_express As String = System.Web.Configuration.WebConfigurationManager.AppSettings("USERCGA").ToString
    Dim vg_S_BD_SQL_express As String = System.Web.Configuration.WebConfigurationManager.AppSettings("BDCGA").ToString
    
    Dim vg_S_StrConexion As String = typeConexion()

#End Region

    ''' <summary>
    ''' funcion generica para la consulta de cualquier tabla con o sin condiciones 
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObjLoad_All(ByVal vp_S_StrQuery As String, ByVal vp_S_Proccess As String)

        Dim SQLlogin As New LoginSQLClass
        Dim SQLMenu As New MenuSQLClass
        Dim SQLlinks As New Adm_LinksSQLClass
        Dim SQLRoles As New Adm_RolesSQLClass
        Dim SQLOPRol As New Adm_OpcRolSQLClass
        Dim SQLUser As New Adm_UsuarioSQLClass
        Dim SQLTurnos As New CGA_TurnosSQLClass
        Dim SQLCentro As New CGA_CentroSQLClass
        Dim SQLGprMaquinas As New CGA_GrpMaquinaSQLClass
        Dim SQLMaquina As New CGA_MaquinaSQLClass
        Dim SQLCCostos As New CGA_CentroCostoSQLClass
        Dim SQLArea As New CGA_AreaSQLClass
        Dim SQLOperario As New CGA_OperarioSQLClass
        Dim SQlCausales As New CGA_CausalesSQLClass
        Dim SQLAcciones As New CGA_AccionesSQLClass
        Dim SQlPareto As New CGA_ParetoSQLClass
        Dim SQLLMaterial As New CGA_LMaterialSQLClass
        Dim SQLCausalesAtrazo As New CGA_CausalesAtrazoSQLClass

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim SQL_TVCInf As New CGA_TVC_InfSQLClass
        Dim SQLNotificacion As New CGA_NotificacionesSQLClass
        Dim SQLGeneral As New GeneralSQLClass
        Dim SQLCargaPasiva As New CGA_CargaPasivaSQLClass
        Dim SQLDesbordaniento As New CGA_VDesbordamientoSQLClass
        Dim SQLFestivos As New CGA_FestivosSQLClass

        Try
            Select Case vp_S_Proccess

                Case "encabezado"

                    Dim ObjListGeneral As New List(Of Droplist_Class)
                    ObjListGeneral = SQLGeneral.ListEncabezado(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListGeneral

                Case "Login"

                    Dim ObjListLogin As New List(Of LoginClass)
                    ObjListLogin = SQLlogin.ListLogin(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListLogin

                Case "Menu"

                    Dim ObjListMenu As New List(Of MenuClass)
                    ObjListMenu = SQLMenu.listMenu(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListMenu

                Case "Links"

                    Dim ObjListLinks As New List(Of Adm_LinksClass)
                    ObjListLinks = SQLlinks.listLinks(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListLinks

                Case "Roles"
                    Dim ObjListRoles As New List(Of Adm_RolesClass)
                    ObjListRoles = SQLRoles.listrol(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListRoles

                Case "OpcRol"
                    Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)
                    ObjListOpcRol = SQLOPRol.listOpcRol(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListOpcRol

                Case "User"
                    Dim ObjListUser As New List(Of Adm_UsuarioClass)
                    ObjListUser = SQLUser.listUSer(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListUser

                Case "Turnos"
                    Dim ObjListTurno As New List(Of CGA_TurnosClass)
                    ObjListTurno = SQLTurnos.listTurnos(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListTurno

                Case "Centro"
                    Dim ObjListCentro As New List(Of CGA_CentroClass)
                    ObjListCentro = SQLCentro.listCentro(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListCentro

                Case "GrpMaquina"
                    Dim ObjListGrpMaquina As New List(Of CGA_GrpMaquinaClass)
                    ObjListGrpMaquina = SQLGprMaquinas.listGrpMaquina(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListGrpMaquina

                Case "Maquina"
                    Dim ObjListMaquina As New List(Of CGA_MaquinaClass)
                    ObjListMaquina = SQLMaquina.listMaquina(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListMaquina

                Case "CentroCosto"
                    Dim ObjListCentroCosto As New List(Of CGA_CentroCostoClass)
                    ObjListCentroCosto = SQLCCostos.listCentroCosto(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListCentroCosto

                Case "Area"
                    Dim ObjListArea As New List(Of CGA_AreaClass)
                    ObjListArea = SQLArea.listArea(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListArea

                Case "Operario"
                    Dim ObjListOperario As New List(Of CGA_OperarioClass)
                    ObjListOperario = SQLOperario.listOperario(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListOperario

                Case "Causales"
                    Dim ObjListCausales As New List(Of CGA_CausalesClass)
                    ObjListCausales = SQlCausales.listCausales(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListCausales

                Case "Acciones"
                    Dim ObjListAcciones As New List(Of CGA_AccionesClass)
                    ObjListAcciones = SQLAcciones.listAcciones(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListAcciones

                Case "Pareto"
                    Dim ObjListPareto As New List(Of CGA_ParetoClass)
                    ObjListPareto = SQlPareto.listPareto(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListPareto

                Case "LMaterial"
                    Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)
                    ObjListLMaterial = SQLLMaterial.listLMaterial(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListLMaterial

                Case "CausalesAtrazo"
                    Dim ObjListCausalesAtrazo As New List(Of CGA_CausalesAtrazoClass)
                    ObjListCausalesAtrazo = SQLCausalesAtrazo.listCausalesAtrazo(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListCausalesAtrazo

                Case "Festivos"
                    Dim ObjListFestivos As New List(Of CGA_FestivosClass)
                    ObjListFestivos = SQLFestivos.listFestivos(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListFestivos

                Case "Droplist_General"

                    Dim ObjListDroplist As New List(Of Droplist_Class)
                    ObjListDroplist = SQLGeneral.listdrop(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListDroplist

                Case "Droplist_General_FLEX"

                    Dim ObjListDroplist As New List(Of Droplist_Class)
                    ObjListDroplist = SQLGeneral.listdropFlex(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListDroplist

                Case "CreateID"
                    Dim ID As String
                    ID = IDis(vp_S_StrQuery)
                    Return ID

                Case "SearchCentroPlanta"
                    Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
                    ObjlistTVC = SQL_TVC.ListCentroMaquina(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistTVC

                Case "GridTVC"
                    Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
                    ObjlistTVC = SQL_TVC.ListTVC(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistTVC

                Case "EncTVCDet"
                    Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
                    ObjlistTVC = SQL_TVC.ListEncTVCDet(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistTVC

                Case "GridTVCDet"
                    Dim ObjlistTVC As New List(Of CGA_TVC_OPDetClass)
                    ObjlistTVC = SQL_TVC.ListGridTVCDet(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistTVC

                Case "SearchPlanta"
                    Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)
                    ObjlistTVCInf = SQL_TVCInf.ListCentro(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistTVCInf

                Case "GridTVC_Inf"
                    Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)
                    ObjlistTVCInf = SQL_TVCInf.ListTVC(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistTVCInf

                Case "GridNotificacion"
                    Dim ObjlistNotificacion As New List(Of CGA_NotificacionesClass)
                    ObjlistNotificacion = SQLNotificacion.ListNotificacion(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjlistNotificacion

                Case "CargaPasiva"
                    Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)
                    ObjListCargaPasiva = SQLCargaPasiva.listCargaPasiva(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListCargaPasiva

                Case "Desbordamiento"
                    Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)
                    ObjListVDesbordamiento = SQLDesbordaniento.listVDesbordamiento(vp_S_StrQuery, vg_S_StrConexion)
                    Return ObjListVDesbordamiento

            End Select

        Catch ex As Exception

            Select Case vp_S_Proccess

                Case "Login"

                    Dim ObjListLogin As New List(Of LoginClass)
                    Dim objUser As New LoginClass
                    objUser.Name = "Error consulta"
                    ObjListLogin.Add(objUser)
                    'retornamos el error 
                    Return ObjListLogin

                Case "Menu"

                    Dim ObjListMenu As New List(Of MenuClass)
                    Dim objUser As New MenuClass
                    objUser.Nombre = "Error consulta"
                    ObjListMenu.Add(objUser)
                    Return ObjListMenu

                Case "Links"

                    Dim ObjListLinks As New List(Of Adm_LinksClass)
                    Dim objLinks As New Adm_LinksClass
                    objLinks.Descripcion = "Error consulta"
                    ObjListLinks.Add(objLinks)
                    Return ObjListLinks

                Case "Links_droplist"
                    Dim ObjListDroplist As New List(Of Droplist_Class)
                    Dim objDropList As New Droplist_Class
                    objDropList.descripcion = "Error consulta"
                    ObjListDroplist.Add(objDropList)
                    Return ObjListDroplist

            End Select

        End Try

    End Function

    ''' <summary>
    ''' funcion generica para la insercion, actualizacion o eliminar de datos en la BD
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StrInsert_and_Update_All(ByVal vp_S_StrQuery As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        Dim vl_S_processUpdate As String

        Try
            objConexBD = New OleDbConnection(vg_S_StrConexion)
            objConexBD.ConnectionString = vg_S_StrConexion

            'abrimos conexion
            objConexBD.Open()
            'cargamos la carga y la conexion
            objcmd = New OleDbCommand(vp_S_StrQuery, objConexBD)
            'ejecutamos la carga
            objcmd.ExecuteNonQuery()
            'cerramos conexiones
            objConexBD.Close()

            vl_S_processUpdate = "Exito"

        Catch ex As Exception
            vl_S_processUpdate = "Error"
        End Try
        Return vl_S_processUpdate

    End Function

    ''' <summary>
    ''' funcion generica para consultas de un solo resultado tipo integer
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IDis(ByVal vp_S_StrQuery As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand
        Dim resultQuery As String = ""

        objConexBD.Open()
        objcmd.CommandText = vp_S_StrQuery

        ReadConsulta = objcmd.ExecuteReader()


        While ReadConsulta.Read
            resultQuery = ReadConsulta.GetValue(0)
        End While

        ReadConsulta.Close()
        objConexBD.Close()

        Return resultQuery

    End Function

    ''' <summary>
    ''' funcion de swicheo de conexion a BD por medio de vlores del web config
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function typeConexion()

        Dim conection As String=""
        '----------------------------------------------------------------------------------------------------------------------------------------------'
        '                                                                conexiones a la BD                                                            '
        '----------------------------------------------------------------------------------------------------------------------------------------------'

        'Conexion SQL Compact
        Dim vg_S_StrConexion_Compact As String = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;Data Source=" & vg_S_Ruta_SLQCOMPACT & _
                                                 ";SSCE:Database Password=" & vg_S_Pass_SLQCOMPACT & ";"

        'Conexion SQL SERVER Express con usuario
        Dim vg_S_StrConexion_SQLSERVER_USER As String = "provider=SQLOLEDB;Data source=" & vg_S_Servidor_SQL_express & _
                                                        ";database=" & vg_S_BD_SQL_express & _
                                                        ";User ID=" & vg_S_User_SQL_express & _
                                                        ";password=" & vg_S_PWD_SQL_express & ";"

        'Conexion SQL SERVER Express con Windows Autentication
        Dim vg_S_StrConexion_SQLSERVER_WA As String = "Provider=SQLOLEDB;Server=" & vg_S_Servidor_SQL_express & _
                                                      ";Database=" & vg_S_BD_SQL_express & _
                                                      ";Trusted_Connection=yes;"


        Select Case vg_S_TypeBD

            Case "Compact"
                conection = vg_S_StrConexion_Compact
            Case "SQL_User"
                conection = vg_S_StrConexion_SQLSERVER_USER
            Case "SQL_WA"
                conection = vg_S_StrConexion_SQLSERVER_WA
        End Select

        Return conection

    End Function

End Class
