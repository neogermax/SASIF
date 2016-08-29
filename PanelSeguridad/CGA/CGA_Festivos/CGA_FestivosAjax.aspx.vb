Imports Newtonsoft.Json

Public Class CGA_FestivosAjax
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
                    Consulta_Festivos()

                Case "crear"
                    InsertFestivos()

                Case "elimina"
                    EraseFestivos()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Festivos (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Festivos()

        Dim SQL_Festivos As New CGA_FestivosSQLClass
        Dim ObjListFestivos As New List(Of CGA_FestivosClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListFestivos = SQL_Festivos.Read_AllFestivos(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListFestivos Is Nothing Then

            Dim objFestivos As New CGA_FestivosClass
            ObjListFestivos = New List(Of CGA_FestivosClass)

            objFestivos.Year = 0
            objFestivos.Mes_Dia = 0
            objFestivos.Usuario = ""

            ObjListFestivos.Add(objFestivos)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListFestivos.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Festivos (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertFestivos()

        Dim objFestivos As New CGA_FestivosClass
        Dim SQL_Festivos As New CGA_FestivosSQLClass
        Dim ObjListFestivos As New List(Of CGA_FestivosClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objFestivos.Year = Request.Form("ID")
        objFestivos.Mes_Dia = Request.Form("mes_dia")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objFestivos.Year, objFestivos.Mes_Dia)

        If vl_s_IDxiste = 0 Then

            objFestivos.FechaActualizacion = Date.Now
            objFestivos.Usuario = Request.Form("user")

            ObjListFestivos.Add(objFestivos)

            result = SQL_Festivos.InsertFestivos(objFestivos)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Festivos (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseFestivos()

        Dim objFestivos As New CGA_FestivosClass
        Dim SQL_Festivos As New CGA_FestivosSQLClass
        Dim ObjListFestivos As New List(Of CGA_FestivosClass)

        Dim result As String

        objFestivos.Year = Request.Form("ID")
        objFestivos.Mes_Dia = Request.Form("mes_dia")

        ObjListFestivos.Add(objFestivos)

        result = SQL_Festivos.EraseFestivos(objFestivos)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Festivos As New CGA_FestivosSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Festivos.ReadCharge_DropList(vl_S_Tabla)
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
    Protected Function Consulta_Repetido(ByVal vp_S_ID As String, ByVal vp_S_ID_2 As String)

        Dim SQL_General As New GeneralSQLClass
        Dim result As String

        result = SQL_General.ReadExist_VariantKeys("CGA_Festivos", "F_Año", "F_Mes_Dia", "", vp_S_ID, vp_S_ID_2, "")
        

        Return result

    End Function

#End Region


End Class