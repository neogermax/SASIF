Imports Newtonsoft.Json

Public Class CGA_TurnosAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "consulta"
                    Consulta_turno()

                Case "crear"
                    InsertTurnos()

                Case "modificar"
                    UpdateTurnos()

                Case "elimina"
                    EraseTurnos()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla turno (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Turno()

        Dim SQL_Turno As New CGA_TurnosSQLClass
        Dim ObjListTurno As New List(Of CGA_TurnosClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListTurno = SQL_Turno.Read_AllTurnos(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListTurno Is Nothing Then

            Dim objturno As New CGA_TurnosClass
            ObjListTurno = New List(Of CGA_TurnosClass)

            objturno.Descripcion = ""
            objturno.HoraInicio = ""
            objturno.Tiempo = ""
            objturno.FechaActualizacion = ""
            objturno.Usuario = ""

            ObjListTurno.Add(objturno)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListTurno.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla turnos (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertTurnos()

        Dim objturno As New CGA_TurnosClass
        Dim SQL_Turno As New CGA_TurnosSQLClass
        Dim ObjListTurno As New List(Of CGA_TurnosClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objturno.Turno_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objturno.Turno_ID)

        If vl_s_IDxiste = 0 Then

            objturno.Descripcion = Request.Form("descripcion")
            objturno.HoraInicio = Request.Form("hora_inicio")
            objturno.Tiempo = Request.Form("tiempo")
            objturno.FechaActualizacion = Date.Now
            objturno.Usuario = Request.Form("user")

            ObjListTurno.Add(objturno)

            result = SQL_Turno.InsertTurnos(objturno)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla turnos (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateTurnos()

        Dim objturno As New CGA_TurnosClass
        Dim SQL_Turno As New CGA_TurnosSQLClass
        Dim ObjListTurno As New List(Of CGA_TurnosClass)

        Dim result As String

        objturno.Turno_ID = Request.Form("ID")
        objturno.Descripcion = Request.Form("descripcion")
        objturno.HoraInicio = Request.Form("hora_inicio")
        objturno.Tiempo = Request.Form("tiempo")
        objturno.FechaActualizacion = Date.Now
        objturno.Usuario = Request.Form("user")

        ObjListTurno.Add(objturno)

        result = SQL_Turno.UpdateTurnos(objturno)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla turnos (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseTurnos()

        Dim objturno As New CGA_TurnosClass
        Dim SQL_Turno As New CGA_TurnosSQLClass
        Dim ObjListTurno As New List(Of CGA_TurnosClass)

        Dim result As String

        objturno.Turno_ID = Request.Form("ID")
        ObjListTurno.Add(objturno)

        result = SQL_Turno.EraseTurnos(objturno)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Turnos As New CGA_TurnosSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Turnos.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

#End Region

#Region "FUNCIONES"

    ''' <summary>
    ''' funcion que valida si el id esta en la BD
    ''' </summary>
    ''' <param name="vp_S_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function Consulta_Repetido(ByVal vp_S_ID As String)

        Dim SQL_General As New GeneralSQLClass
        Dim result As String

        result = SQL_General.ReadExist("CGA_TURNOS", vp_S_ID, "T_Turno_ID", "")
        Return result

    End Function

#End Region

End Class