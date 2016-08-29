Imports Newtonsoft.Json

Public Class Adm_OpcRolAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "cargar_Sub_Rol"
                    Cargar_Sub_Rol()

                Case "Carga_Rol"
                    Carga_Rol()

                Case "cargar_Links"
                    Cargar_Links()

                Case "consulta"
                    Consulta_OpcRol()

                Case "crear"
                    InsertOpcRol()

                Case "modificar"
                    UpdateOpcRol()

                Case "elimina"
                    EraseOpcRol()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla opcion roles (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_OpcRol()

        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)

        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListOpcRol = SQL_OpcRol.Read_AllOpcRol(vl_S_filtro, vl_S_opcion, vl_S_contenido)
        Response.Write(JsonConvert.SerializeObject(ObjListOpcRol.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla opcion roles (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertOpcRol()

        Dim objOpcRol As New Adm_OpcRolClass
        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)
        Dim result As String
        Dim vl_s_IDxiste As String

        objOpcRol.OPRol_ID = Request.Form("ID")
        objOpcRol.Consecutivo = Request.Form("consecutivo")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objOpcRol.OPRol_ID, objOpcRol.Consecutivo)

        If vl_s_IDxiste = 0 Then

            objOpcRol.Tipo = Request.Form("tipo")
            objOpcRol.Subrol_rol = Request.Form("subrol_rol")
            objOpcRol.Link_ID = Request.Form("link_ID")

            ObjListOpcRol.Add(objOpcRol)

            result = SQL_OpcRol.InsertOpcRol(objOpcRol)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla opcion roles (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateOpcRol()

        Dim objOpcRol As New Adm_OpcRolClass
        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)
        Dim result As String

        objOpcRol.OPRol_ID = Request.Form("ID")
        objOpcRol.Consecutivo = Request.Form("consecutivo")
        objOpcRol.Tipo = Request.Form("tipo")
        objOpcRol.Subrol_rol = Request.Form("subrol_rol")
        objOpcRol.Link_ID = Request.Form("link_ID")

        ObjListOpcRol.Add(objOpcRol)

        result = SQL_OpcRol.UpdateOpcRol(objOpcRol)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla opcion roles (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseOpcRol()

        Dim objOpcRol As New Adm_OpcRolClass
        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListOpcRol As New List(Of Adm_OpcRolClass)
        Dim result As String

        objOpcRol.OPRol_ID = Request.Form("ID")
        objOpcRol.Consecutivo = Request.Form("DeleteConsecutivo")

        ObjListOpcRol.Add(objOpcRol)

        result = SQL_OpcRol.EraseOpcRol(objOpcRol)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL opcion rol
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_OpcRol.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))


    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL subtipo
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cargar_Sub_Rol()

        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_OpcRol.ReadCharge_DL_Subrol()
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL ID
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_Rol()

        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_OpcRol.ReadCharge_DL_Rol()
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cargar_Links()

        Dim SQL_OpcRol As New Adm_OpcRolSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        Dim vl_S_tipo = Request.Form("tipo_link")

        ObjListDroplist = SQL_OpcRol.ReadCharge_DL_Links(vl_S_tipo)
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
    Protected Function Consulta_Repetido(ByVal vp_S_ID As String, ByVal vp_S_Consecutivo As String)

        Dim SQL_General As New GeneralSQLClass
        Dim result As String

        result = SQL_General.ReadExist("OPTION_ROL", vp_S_ID, "OR_OPRol_ID", vp_S_Consecutivo)
        Return result

    End Function

#End Region

End Class