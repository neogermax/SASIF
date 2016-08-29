Imports Newtonsoft.Json

Public Class CGA_CargaPasivaAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "cargar_droplist_Centro"
                    CargarDDL_Centro()

                Case "cargar_droplist_Depto"
                    CargarDDL_Departamento()

                Case "cargar_droplist_GrpMaq"
                    CargarDDL_GprMaq()

                Case "cargarMaquina"
                    CargarDDL_Maq()

                Case "consulta"
                    Consulta_CargaPasiva()

                Case "crear"
                    InsertCargaPasiva()

                Case "modificar"
                    UpdateCargaPasiva()

                Case "elimina"
                    EraseCargaPasiva()
            End Select

        End If

    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla CargaPasiva (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_CargaPasiva()

        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListCargaPasiva = SQL_CargaPasiva.Read_AllCargaPasiva(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListCargaPasiva Is Nothing Then

            Dim objCargaPasiva As New CGA_CargaPasivaClass
            ObjListCargaPasiva = New List(Of CGA_CargaPasivaClass)

            objCargaPasiva.CP_ID = 0
            objCargaPasiva.Centro_ID = 0
            objCargaPasiva.Departamento = ""

            ObjListCargaPasiva.Add(objCargaPasiva)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListCargaPasiva.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla CargaPasiva (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertCargaPasiva()

        Dim objCargaPasiva As New CGA_CargaPasivaClass
        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objCargaPasiva.CP_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objCargaPasiva.CP_ID)

        If vl_s_IDxiste = 0 Then

            objCargaPasiva.Departamento = Request.Form("departamento")
            objCargaPasiva.Centro_ID = Request.Form("centro")
            objCargaPasiva.GRPMaquina_ID = Request.Form("g_maq")
            objCargaPasiva.Puestotrabajo_ID = Request.Form("maq")
            objCargaPasiva.HPlan = Request.Form("horasplan")
            objCargaPasiva.N_Oferta = Request.Form("n_ofertas")
            objCargaPasiva.Orden_ID = Request.Form("orden")

            objCargaPasiva.FechaActualizacion = Date.Now
            objCargaPasiva.Usuario = Request.Form("user")

            ObjListCargaPasiva.Add(objCargaPasiva)

            result = SQL_CargaPasiva.InsertCargaPasiva(objCargaPasiva)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla CargaPasiva (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateCargaPasiva()

        Dim objCargaPasiva As New CGA_CargaPasivaClass
        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)

        Dim result As String

        objCargaPasiva.CP_ID = Request.Form("ID")
        objCargaPasiva.Departamento = Request.Form("departamento")
        objCargaPasiva.Centro_ID = Request.Form("centro")
        objCargaPasiva.GRPMaquina_ID = Request.Form("g_maq")
        objCargaPasiva.Puestotrabajo_ID = Request.Form("maq")
        objCargaPasiva.HPlan = Request.Form("horasplan")
        objCargaPasiva.N_Oferta = Request.Form("n_ofertas")
        objCargaPasiva.Orden_ID = Request.Form("orden")

        objCargaPasiva.FechaActualizacion = Date.Now
        objCargaPasiva.Usuario = Request.Form("user")

        ObjListCargaPasiva.Add(objCargaPasiva)

        result = SQL_CargaPasiva.UpdateCargaPasiva(objCargaPasiva)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla CargaPasiva (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseCargaPasiva()

        Dim objCargaPasiva As New CGA_CargaPasivaClass
        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListCargaPasiva As New List(Of CGA_CargaPasivaClass)

        Dim result As String

        objCargaPasiva.CP_ID = Request.Form("ID")
        ObjListCargaPasiva.Add(objCargaPasiva)

        result = SQL_CargaPasiva.EraseCargaPasiva(objCargaPasiva)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_CargaPasiva.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Centro()

        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_CargaPasiva.ReadCharge_DDL_Centro(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL DEPARTAMENTO DE SOLICITUD
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Departamento()

        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_CargaPasiva.ReadCharge_DDL_Departamento(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Grupo de maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_GprMaq()

        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")
        Dim vl_S_Id_Centro As String = Request.Form("ID_Centro")

        ObjListDroplist = SQL_CargaPasiva.ReadCharge_DDL_GrpMaquinas(vl_S_Tabla, vl_S_Id_Centro)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Grupo de maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Maq()

        Dim SQL_CargaPasiva As New CGA_CargaPasivaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")
        Dim vl_S_GprMaq As String = Request.Form("ID_Maquina")
        Dim vl_S_Id_Centro As String = Request.Form("ID_Centro")

        ObjListDroplist = SQL_CargaPasiva.ReadCharge_DDL_Maquinas(vl_S_Tabla, vl_S_GprMaq, vl_S_Id_Centro)
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

        result = SQL_General.ReadExist("CGA_CargaPasiva", vp_S_ID, "CP_ID", "")
        Return result

    End Function

#End Region

End Class