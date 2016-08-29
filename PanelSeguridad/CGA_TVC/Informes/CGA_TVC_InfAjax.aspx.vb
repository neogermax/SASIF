Imports Newtonsoft.Json

Public Class CGA_TVC_InfAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_Centro"
                    CargarDDL_Centro()

                Case "cargar_droplist_GrpMaq"
                    CargarDDL_GprMaq()

                Case "cargarPlanta"
                    CargarPlanta()

                Case "cargarMaquina"
                    CargarDDL_Maq()

                Case "Datos_TVC"
                    DatosTVC()


            End Select
        End If

    End Sub

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Centro()

        Dim SQL_TVC_Inf As New CGA_TVC_InfSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_TVC_Inf.ReadCharge_DDL_Centro(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Grupo de maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_GprMaq()

        Dim SQL_TVC_Inf As New CGA_TVC_InfSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")
        Dim vl_S_Id_Centro As String = Request.Form("ID_Centro")

        ObjListDroplist = SQL_TVC_Inf.ReadCharge_DDL_GrpMaquinas(vl_S_Tabla, vl_S_Id_Centro)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Grupo de maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Maq()

        Dim SQL_TVC_Inf As New CGA_TVC_InfSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")
        Dim vl_S_GprMaq As String = Request.Form("ID_Maquina")
        Dim vl_S_Id_Centro As String = Request.Form("ID_Centro")

        ObjListDroplist = SQL_TVC_Inf.ReadCharge_DDL_Maquinas(vl_S_Tabla, vl_S_GprMaq, vl_S_Id_Centro)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

#End Region

#Region "FUNCIONES"

    ''' <summary>
    ''' Funcion que trae la planta del centro deseado 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarPlanta()

        Dim SQL_TVCInf As New CGA_TVC_InfSQLClass
        Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)
        Dim ID_Centro As String = Request.Form("ID_Centro")

        ObjlistTVCInf = SQL_TVCInf.SearchPlanta(ID_Centro)
        Response.Write(JsonConvert.SerializeObject(ObjlistTVCInf.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que trae los datos para las ordenes
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DatosTVC()

        Dim SQL_TVCInf As New CGA_TVC_InfSQLClass
        Dim ObjlistTVCInf As New List(Of CGA_TVC_InfClass)
        Dim ID_Centro As String = Request.Form("Centro")
        Dim ID_GprMaquina As String = Request.Form("GprMaquina")
        Dim ID_Maquina As String = Request.Form("Maquina")
        Dim StartDate As String = Request.Form("StartDate")
        Dim EndDate As String = Request.Form("EndDate")

        ObjlistTVCInf = SQL_TVCInf.GridTVC(ID_Centro, ID_GprMaquina, ID_Maquina, StartDate.Replace("/", "-"), EndDate.Replace("/", "-"))
        Response.Write(JsonConvert.SerializeObject(ObjlistTVCInf.ToArray()))

    End Sub

#End Region


End Class