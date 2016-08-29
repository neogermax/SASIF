Imports Newtonsoft.Json

Public Class Adm_LinksAjax
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
                    Consulta_Links()

                Case "crear"
                    InsertLInk()

                Case "modificar"
                    UpdateLInk()

                Case "elimina"
                    DeleteLInk()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla links (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Links()

        Dim SQL_links As New Adm_LinksSQLClass
        Dim ObjListLinks As New List(Of Adm_LinksClass)

        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListLinks = SQL_links.Read_AllLinks(vl_S_filtro, vl_S_opcion, vl_S_contenido)
        Response.Write(JsonConvert.SerializeObject(ObjListLinks.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla links (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertLInk()

        Dim objLink As New Adm_LinksClass
        Dim SQL_links As New Adm_LinksSQLClass
        Dim ObjListLink As New List(Of Adm_LinksClass)
        Dim result As String
        Dim vl_s_IDxiste As String

        objLink.Link_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objLink.Link_ID)

        If vl_s_IDxiste = 0 Then

            objLink.Descripcion = Request.Form("descripcion")
            objLink.Param1 = Request.Form("param1")
            objLink.Param2 = Request.Form("paran2")
            objLink.Img = Request.Form("image")
            objLink.LinkPag = Request.Form("link")

            ObjListLink.Add(objLink)

            result = SQL_links.InsertLinks(objLink)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla links (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateLInk()

        Dim objLink As New Adm_LinksClass
        Dim SQL_links As New Adm_LinksSQLClass
        Dim ObjListLink As New List(Of Adm_LinksClass)
        Dim result As String

        objLink.Link_ID = Request.Form("ID")
        objLink.Descripcion = Request.Form("descripcion")
        objLink.Param1 = Request.Form("param1")
        objLink.Param2 = Request.Form("paran2")
        objLink.Img = Request.Form("image")
        objLink.LinkPag = Request.Form("link")

        ObjListLink.Add(objLink)

        result = SQL_links.UpdateLinks(objLink)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que cambia el estado a inhabilitado en la tabla links (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DeleteLInk()

        Dim objLink As New Adm_LinksClass
        Dim SQL_links As New Adm_LinksSQLClass
        Dim ObjListLink As New List(Of Adm_LinksClass)
        Dim result As String

        objLink.Link_ID = Request.Form("ID")

        ObjListLink.Add(objLink)

        result = SQL_links.DeleteLinks(objLink)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_links As New Adm_LinksSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_links.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("LINKS", vp_S_ID, "L_Link_ID", "")
        Return result

    End Function

#End Region

End Class

