Imports Newtonsoft.Json

Public Class CGA_LMaterialAjax
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
                    Consulta_LMaterial()

                Case "crear"
                    InsertLMaterial()

                Case "modificar"
                    UpdateLMaterial()

                Case "elimina"
                    EraseLMaterial()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla LMaterial (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_LMaterial()

        Dim SQL_LMaterial As New CGA_LMaterialSQLClass
        Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListLMaterial = SQL_LMaterial.Read_AllLMaterial(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListLMaterial Is Nothing Then

            Dim objLMaterial As New CGA_LMaterialClass
            ObjListLMaterial = New List(Of CGA_LMaterialClass)

            objLMaterial.Descripcion = ""
            objLMaterial.FechaActualizacion = ""
            objLMaterial.Usuario = ""

            ObjListLMaterial.Add(objLMaterial)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListLMaterial.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla LMaterial (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertLMaterial()

        Dim objLMaterial As New CGA_LMaterialClass
        Dim SQL_LMaterial As New CGA_LMaterialSQLClass
        Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objLMaterial.LMaterial_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objLMaterial.LMaterial_ID)

        If vl_s_IDxiste = 0 Then

            objLMaterial.Descripcion = Request.Form("descripcion")
            objLMaterial.FechaActualizacion = Date.Now
            objLMaterial.Usuario = Request.Form("user")

            ObjListLMaterial.Add(objLMaterial)

            result = SQL_LMaterial.InsertLMaterial(objLMaterial)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla LMaterial (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateLMaterial()

        Dim objLMaterial As New CGA_LMaterialClass
        Dim SQL_LMaterial As New CGA_LMaterialSQLClass
        Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)

        Dim result As String

        objLMaterial.LMaterial_ID = Request.Form("ID")
        objLMaterial.Descripcion = Request.Form("descripcion")
        objLMaterial.FechaActualizacion = Date.Now
        objLMaterial.Usuario = Request.Form("user")

        ObjListLMaterial.Add(objLMaterial)

        result = SQL_LMaterial.UpdateLMaterial(objLMaterial)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla LMaterial (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseLMaterial()

        Dim objLMaterial As New CGA_LMaterialClass
        Dim SQL_LMaterial As New CGA_LMaterialSQLClass
        Dim ObjListLMaterial As New List(Of CGA_LMaterialClass)

        Dim result As String

        objLMaterial.LMaterial_ID = Request.Form("ID")
        ObjListLMaterial.Add(objLMaterial)

        result = SQL_LMaterial.EraseLMaterial(objLMaterial)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_LMaterial As New CGA_LMaterialSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_LMaterial.ReadCharge_DropList(vl_S_Tabla)
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

        result = SQL_General.ReadExist("CGA_LINEA_MATERIAL", vp_S_ID, "LI_LMaterial_ID", "")
        Return result

    End Function

#End Region

End Class