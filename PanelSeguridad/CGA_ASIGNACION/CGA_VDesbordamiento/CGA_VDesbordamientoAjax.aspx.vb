Imports Newtonsoft.Json

Public Class CGA_VDesbordamientoAjax
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

                Case "cargar_droplist_GrpMaq"
                    CargarDDL_GprMaq()

                Case "cargarMaquina"
                    CargarDDL_Maq()

                Case "consulta"
                    Consulta_VDesbordamiento()

                Case "crear"
                    InsertVDesbordamiento()

                Case "modificar"
                    UpdateVDesbordamiento()

                Case "elimina"
                    EraseVDesbordamiento()
            End Select
        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla VDesbordamiento (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_VDesbordamiento()

        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListVDesbordamiento = SQL_VDesbordamiento.Read_AllVDesbordamiento(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListVDesbordamiento Is Nothing Then

            Dim objVDesbordamiento As New CGA_VDesbordamientoClass
            ObjListVDesbordamiento = New List(Of CGA_VDesbordamientoClass)

            objVDesbordamiento.Puestotrabajo_ID = ""
            objVDesbordamiento.Centro_ID = 0

            ObjListVDesbordamiento.Add(objVDesbordamiento)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListVDesbordamiento.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla VDesbordamiento (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertVDesbordamiento()

        Dim objVDesbordamiento As New CGA_VDesbordamientoClass
        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objVDesbordamiento.Puestotrabajo_ID = Request.Form("maq")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objVDesbordamiento.Puestotrabajo_ID)

        If vl_s_IDxiste = 0 Then

            objVDesbordamiento.Centro_ID = Request.Form("centro")
            objVDesbordamiento.GRPMaquina_ID = Request.Form("g_maq")
            objVDesbordamiento.Desboramiento_1 = Request.Form("des_1")
            objVDesbordamiento.Desboramiento_2 = Request.Form("des_2")
            objVDesbordamiento.Desboramiento_3 = Request.Form("des_3")
            objVDesbordamiento.Desboramiento_4 = Request.Form("des_4")
            objVDesbordamiento.Desboramiento_5 = Request.Form("des_5")
            objVDesbordamiento.Desboramiento_6 = Request.Form("des_6")
            objVDesbordamiento.Desboramiento_7 = Request.Form("des_7")

            objVDesbordamiento.FechaActualizacion = Date.Now
            objVDesbordamiento.Usuario = Request.Form("user")

            ObjListVDesbordamiento.Add(objVDesbordamiento)

            result = SQL_VDesbordamiento.InsertVDesbordamiento(objVDesbordamiento)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla VDesbordamiento (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateVDesbordamiento()

        Dim objVDesbordamiento As New CGA_VDesbordamientoClass
        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)

        Dim result As String

        objVDesbordamiento.Puestotrabajo_ID = Request.Form("maq")
        objVDesbordamiento.Centro_ID = Request.Form("centro")
        objVDesbordamiento.GRPMaquina_ID = Request.Form("g_maq")
        objVDesbordamiento.Desboramiento_1 = Request.Form("des_1")
        objVDesbordamiento.Desboramiento_2 = Request.Form("des_2")
        objVDesbordamiento.Desboramiento_3 = Request.Form("des_3")
        objVDesbordamiento.Desboramiento_4 = Request.Form("des_4")
        objVDesbordamiento.Desboramiento_5 = Request.Form("des_5")
        objVDesbordamiento.Desboramiento_6 = Request.Form("des_6")
        objVDesbordamiento.Desboramiento_7 = Request.Form("des_7")

        objVDesbordamiento.FechaActualizacion = Date.Now
        objVDesbordamiento.Usuario = Request.Form("user")

        ObjListVDesbordamiento.Add(objVDesbordamiento)

        result = SQL_VDesbordamiento.UpdateVDesbordamiento(objVDesbordamiento)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla VDesbordamiento (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseVDesbordamiento()

        Dim objVDesbordamiento As New CGA_VDesbordamientoClass
        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListVDesbordamiento As New List(Of CGA_VDesbordamientoClass)

        Dim result As String

        objVDesbordamiento.Puestotrabajo_ID = Request.Form("ID")
        ObjListVDesbordamiento.Add(objVDesbordamiento)

        result = SQL_VDesbordamiento.EraseVDesbordamiento(objVDesbordamiento)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL Links
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_VDesbordamiento.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Centro()

        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_VDesbordamiento.ReadCharge_DDL_Centro(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Grupo de maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_GprMaq()

        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")
        Dim vl_S_Id_Centro As String = Request.Form("ID_Centro")

        ObjListDroplist = SQL_VDesbordamiento.ReadCharge_DDL_GrpMaquinas(vl_S_Tabla, vl_S_Id_Centro)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Grupo de maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Maq()

        Dim SQL_VDesbordamiento As New CGA_VDesbordamientoSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")
        Dim vl_S_GprMaq As String = Request.Form("ID_Maquina")
        Dim vl_S_Id_Centro As String = Request.Form("ID_Centro")

        ObjListDroplist = SQL_VDesbordamiento.ReadCharge_DDL_Maquinas(vl_S_Tabla, vl_S_GprMaq, vl_S_Id_Centro)
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

        result = SQL_General.ReadExist("CGA_VALIDACION_DESBORDAMIENTO", vp_S_ID, "VD_Maquina_ID", "")
        Return result

    End Function

#End Region


End Class