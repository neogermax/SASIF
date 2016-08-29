Imports Newtonsoft.Json

Public Class CGA_MaquinaAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "cargar_droplist_busqueda"
                    CargarDroplist()

                Case "Carga_Centro"
                    Carga_Centro()

                Case "Carga_GrpMaquinas"
                    Carga_GrpMaquinas()

                Case "Carga_CCosto"
                    Carga_CCosto()

                Case "consulta"
                    Consulta_Maquina()

                Case "crear"
                    InsertMaquina()

                Case "modificar"
                    UpdateMaquina()

                Case "elimina"
                    EraseMaquina()
            End Select

        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' traemos todos los datos para tabla Maquina (READ)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Consulta_Maquina()

        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListMaquina As New List(Of CGA_MaquinaClass)


        Dim vl_S_filtro As String = Request.Form("filtro")
        Dim vl_S_opcion As String = Request.Form("opcion")
        Dim vl_S_contenido As String = Request.Form("contenido")

        ObjListMaquina = SQL_Maquina.Read_AllMaquina(vl_S_filtro, vl_S_opcion, vl_S_contenido)

        If ObjListMaquina Is Nothing Then

            Dim objMaquina As New CGA_MaquinaClass
            ObjListMaquina = New List(Of CGA_MaquinaClass)

            objMaquina.Descripcion = ""
            objMaquina.FechaActualizacion = ""
            objMaquina.Usuario = ""

            ObjListMaquina.Add(objMaquina)
        End If

        Response.Write(JsonConvert.SerializeObject(ObjListMaquina.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que inserta en la tabla Maquina (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertMaquina()

        Dim objMaquina As New CGA_MaquinaClass
        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListMaquina As New List(Of CGA_MaquinaClass)

        Dim result As String
        Dim vl_s_IDxiste As String

        objMaquina.Maquina_ID = Request.Form("ID")

        'validamos si la llave existe
        vl_s_IDxiste = Consulta_Repetido(objMaquina.Maquina_ID)

        If vl_s_IDxiste = 0 Then

            objMaquina.Descripcion = Request.Form("descripcion")
            objMaquina.Centro_ID = Request.Form("centro")
            objMaquina.GRPMaquina_ID = Request.Form("grpMaquina")
            objMaquina.CentroCosto_ID = Request.Form("CCosto")

            objMaquina.Fec_Inicial_Mant = Request.Form("Mfi")
            objMaquina.Fec_Final_Mant = Request.Form("Mff")
            objMaquina.H_Inicial_Mant = Request.Form("Mhi")
            objMaquina.H_Final_Mant = Request.Form("Mhf")
            objMaquina.Fec_Inicial_NDisp = Request.Form("NDfi")
            objMaquina.Fec_Final_NDisp = Request.Form("NDff")
            objMaquina.H_Inicial_NDisp = Request.Form("NDhi")
            objMaquina.H_Final_NDisp = Request.Form("NDhf")
            objMaquina.Largo = Request.Form("largo")
            objMaquina.Ancho = Request.Form("ancho")
            objMaquina.Espesor_Diametro = Request.Form("ED")
            objMaquina.Tarifa = Request.Form("tarifa")

            objMaquina.FechaActualizacion = Date.Now
            objMaquina.Usuario = Request.Form("user")

            ObjListMaquina.Add(objMaquina)

            result = SQL_Maquina.InsertMaquina(objMaquina)

            Response.Write(result)
        Else
            result = "Existe"
            Response.Write(result)
        End If

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla Maquina (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateMaquina()

        Dim objMaquina As New CGA_MaquinaClass
        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListMaquina As New List(Of CGA_MaquinaClass)

        Dim result As String

        objMaquina.Maquina_ID = Request.Form("ID")
        objMaquina.Descripcion = Request.Form("descripcion")
        objMaquina.Centro_ID = Request.Form("centro")
        objMaquina.GRPMaquina_ID = Request.Form("grpMaquina")
        objMaquina.CentroCosto_ID = Request.Form("CCosto")

        objMaquina.Fec_Inicial_Mant = Request.Form("Mfi")
        objMaquina.Fec_Final_Mant = Request.Form("Mff")
        objMaquina.H_Inicial_Mant = Request.Form("Mhi")
        objMaquina.H_Final_Mant = Request.Form("Mhf")
        objMaquina.Fec_Inicial_NDisp = Request.Form("NDfi")
        objMaquina.Fec_Final_NDisp = Request.Form("NDff")
        objMaquina.H_Inicial_NDisp = Request.Form("NDhi")
        objMaquina.H_Final_NDisp = Request.Form("NDhf")
        objMaquina.Largo = Request.Form("largo")
        objMaquina.Ancho = Request.Form("ancho")
        objMaquina.Espesor_Diametro = Request.Form("ED")
        objMaquina.Tarifa = Request.Form("tarifa")

        objMaquina.FechaActualizacion = Date.Now
        objMaquina.Usuario = Request.Form("user")

        ObjListMaquina.Add(objMaquina)

        result = SQL_Maquina.UpdateMaquina(objMaquina)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que elimina en la tabla Maquina (DELETE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EraseMaquina()

        Dim objMaquina As New CGA_MaquinaClass
        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListMaquina As New List(Of CGA_MaquinaClass)

        Dim result As String

        objMaquina.Maquina_ID = Request.Form("ID")
        ObjListMaquina.Add(objMaquina)

        result = SQL_Maquina.EraseMaquina(objMaquina)
        Response.Write(result)
    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL consulta
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDroplist()

        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_Maquina.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Centro
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_Centro()

        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_Maquina.ReadCharge_DDL_Centro()
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL grupo de maquinas
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_GrpMaquinas()

        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_Maquina.ReadCharge_DDL_GrpMaquinas()
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto  DDL centro de costo
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Carga_CCosto()

        Dim SQL_Maquina As New CGA_MaquinaSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)

        ObjListDroplist = SQL_Maquina.ReadCharge_DDL_CCosto()
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

        result = SQL_General.ReadExist("CGA_MAQUINA", vp_S_ID, "M_Maquina_ID", "")
        Return result

    End Function

#End Region

End Class