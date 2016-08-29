Imports Newtonsoft.Json
Imports System.Runtime.Serialization.Json

Public Class OpeTurnosAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_operario"
                    CargarDDL_Operario()

                Case "cargar_CentroPlanta"
                    Cargar_Centro_planta()

                Case "Cargar_Festivos"
                    Cargar_Festivo()

                Case "CTurno"
                    CargarDDL_Turno()

                Case "TTurno"
                    CargarVector_Turno()

                Case "Consulta_Proceso"
                    Consulta_Tabla()

                Case "CREAR"
                    CreateTurnos_Operacional()

            End Select
        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' fucion para elguardado en bloque
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CreateTurnos_Operacional()

        Dim SQLTurno_Op As New OpeTurnosSQLClass
        Dim ListTurnos_Op As New List(Of OpeTurnosClass)

        ListTurnos_Op = InsertList()

        For Each ObjTurno_ope As OpeTurnosClass In ListTurnos_Op

            SQLTurno_Op.Insert(ObjTurno_ope)

        Next

    End Sub

    ''' <summary>
    ''' creamos lista para ingreso a la BD
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertList()

        Dim S_listTurnos As String = Request.Form("listCalendar").ToString
        Dim NewListTurnos = JsonConvert.DeserializeObject(Of List(Of OpeTurnosClass))(S_listTurnos)
        Dim ListTurnos_Op As New List(Of OpeTurnosClass)

        For Each item_Turno As OpeTurnosClass In NewListTurnos

            Dim ObjTurnos_Op As New OpeTurnosClass

            ObjTurnos_Op.PuestoTrabajo_ID = item_Turno.PuestoTrabajo_ID
            ObjTurnos_Op.Ano_Mes_ID = item_Turno.Ano_Mes_ID
            ObjTurnos_Op.Dia = item_Turno.Dia
            ObjTurnos_Op.Mes = item_Turno.Mes
            ObjTurnos_Op.Year = item_Turno.Year
            ObjTurnos_Op.StrDia = item_Turno.StrDia
            ObjTurnos_Op.StrMes = item_Turno.StrMes
            ObjTurnos_Op.Day_Type = item_Turno.Day_Type

            ObjTurnos_Op.T_1 = item_Turno.T_1
            ObjTurnos_Op.T_1_HF = item_Turno.T_1_HF
            ObjTurnos_Op.T_1_HI = item_Turno.T_1_HI

            ObjTurnos_Op.T_2 = item_Turno.T_2
            ObjTurnos_Op.T_2_HF = item_Turno.T_2_HF
            ObjTurnos_Op.T_2_HI = item_Turno.T_2_HI

            ObjTurnos_Op.T_3 = item_Turno.T_3
            ObjTurnos_Op.T_3_HF = item_Turno.T_3_HF
            ObjTurnos_Op.T_3_HI = item_Turno.T_3_HI

            ObjTurnos_Op.T_4 = item_Turno.T_4
            ObjTurnos_Op.T_4_HF = item_Turno.T_4_HF
            ObjTurnos_Op.T_4_HI = item_Turno.T_4_HI

            ObjTurnos_Op.T_5 = item_Turno.T_5
            ObjTurnos_Op.T_5_HF = item_Turno.T_5_HF
            ObjTurnos_Op.T_5_HI = item_Turno.T_5_HI

            ObjTurnos_Op.T_6 = item_Turno.T_6
            ObjTurnos_Op.T_6_HF = item_Turno.T_6_HF
            ObjTurnos_Op.T_6_HI = item_Turno.T_6_HI

            ObjTurnos_Op.Presupuesto = item_Turno.Presupuesto
            ObjTurnos_Op.Programado = item_Turno.Programado

            ListTurnos_Op.Add(ObjTurnos_Op)

        Next

        Return ListTurnos_Op

    End Function

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL operario
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Operario()

        Dim SQL_OpeTurnos As New OpeTurnosSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_OpeTurnos.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Turno
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Turno()

        Dim SQL_OpeTurnos As New OpeTurnosSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = ""

        ObjListDroplist = SQL_OpeTurnos.ReadCharge_DropList_Turno(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

#End Region

#Region "OTRAS CONSULTAS"

    Protected Sub Consulta_Tabla()


        Dim Mes As String = Request.Form("Mes")
        Dim Year As String = Request.Form("Year")
        Dim Maquina As String = Request.Form("Maq")
        Dim KeyYear_mes As String
        Dim Estado As String

        Dim ObjTurno_Op As New OpeTurnosClass
        Dim ListObjTurno_Op As New List(Of OpeTurnosClass)

        Dim N_mes As String = ConvertMes(Mes)
        Dim L_mes As Integer = Len(N_mes)

        If L_mes = 1 Then
            N_mes = "0" & N_mes
        End If

        KeyYear_mes = Year & N_mes

        ObjTurno_Op.Ano_Mes_ID = KeyYear_mes
        ObjTurno_Op.PuestoTrabajo_ID = Maquina

        ListObjTurno_Op.Add(ObjTurno_Op)

        Dim Result = ConsultaExiste(ObjTurno_Op)

        If Result <> 0 Then
            Estado = "EDITAR"
        Else
            Estado = "CREAR"
        End If

        Response.Write(Estado)

    End Sub

#End Region

#Region "FUNCIONES"

    ''' <summary>
    ''' funcion que trae el centro y planta del puesto de trabajo o maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cargar_Centro_planta()

        Dim SQL_OpeTurnos As New OpeTurnosSQLClass
        Dim ObjlistOpeTurnos As New List(Of OpeTurnosClass)
        Dim ID_Maquina As String = Request.Form("ID_Maquina")

        ObjlistOpeTurnos = SQL_OpeTurnos.SearchCentroPlanta(ID_Maquina)
        Response.Write(JsonConvert.SerializeObject(ObjlistOpeTurnos.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que trae todos los festivos del año
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cargar_Festivo()

        Dim SQL_OpeTurnos As New OpeTurnosSQLClass
        Dim ObjlistFestivos As New List(Of CGA_FestivosClass)

        ObjlistFestivos = SQL_OpeTurnos.AllFestivos()
        Response.Write(JsonConvert.SerializeObject(ObjlistFestivos.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que trae los tiempos de cada turno
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarVector_Turno()

        Dim SQL_OpeTurnos As New OpeTurnosSQLClass
        Dim ObjListTurno As New List(Of CGA_TurnosClass)

        ObjListTurno = SQL_OpeTurnos.Allturno()
        Response.Write(JsonConvert.SerializeObject(ObjListTurno.ToArray()))

    End Sub

    Function ConvertMes(ByVal vp_S_Mes As String)

        Dim Meses As String() = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

        Dim Num As Integer = Array.IndexOf(Meses, vp_S_Mes)
        Num = Num + 1

        Return Num

    End Function

    Function ConsultaExiste(ByVal ObjTurno_OP As OpeTurnosClass)

        Dim SQLTurno_Op As New OpeTurnosSQLClass
        Dim result As String = SQLTurno_Op.ReadExist(ObjTurno_OP)
        Return result

    End Function

#End Region


End Class