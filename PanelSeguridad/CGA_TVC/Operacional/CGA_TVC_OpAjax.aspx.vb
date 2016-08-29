Imports Newtonsoft.Json

Public Class CGA_TVC_OpAjax
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

                Case "Datos_TVC"
                    DatosTVC()

                Case "EncabezadoDet"
                    TVCEncabezadoDet()

                Case "GridDet"
                    TVCGridDet()

                Case "Ccausal"
                    CargarDDL_Causal()

                Case "CTurno"
                    CargarDDL_Turno()

                Case "COperario_Det"
                    CargarDDL_Operario_Det()

                Case "CAccion"
                    CargarDDL_Accion()

                Case "CArea"
                    CargarDDL_Area()

                Case "crear"
                    InsertDETALLE_TVC_OP()

                Case "modificar"
                    UpdateDETALLE_TVC_OP()
            End Select
        End If
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' funcion que inserta en la tabla DETALLE_TVC_OP (INSERT)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InsertDETALLE_TVC_OP()

        Dim objTVCDet As New CGA_TVC_OPDetClass
        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListTVCDet As New List(Of CGA_TVC_OPDetClass)

        Dim result As String = ""
      
        objTVCDet.Centro_ID = Request.Form("centro")
        objTVCDet.Puestotrabajo_ID = Request.Form("Maq")
        objTVCDet.Orden_ID = Request.Form("Orden")
        objTVCDet.Operacion_ID = Request.Form("Opera")
        objTVCDet.Turno_ID = Request.Form("turno")
        objTVCDet.Operario_ID = Request.Form("operario")
        objTVCDet.CausalSAP_ID = Request.Form("causalSAP")
        objTVCDet.Causal_ID = Request.Form("causal")
        objTVCDet.Observacion_Ope = Request.Form("obserope")
        objTVCDet.Descripcion_Analis = Request.Form("descrip")

        objTVCDet.Accion_ID = Request.Form("accion")
        objTVCDet.Fec_Ent_Accion = Request.Form("dateaccion")
        objTVCDet.Area_ID = Request.Form("area")

        objTVCDet.Fec_Creacion = Date.Now
        objTVCDet.FechaActualizacion = Date.Now
        objTVCDet.Usuario = Request.Form("user")
        objTVCDet.Estado = "1"


        ObjListTVCDet.Add(objTVCDet)

        result = SQL_TVC.InsertTVC(objTVCDet)

        Response.Write(result)

    End Sub

    ''' <summary>
    ''' funcion que actualiza en la tabla DETALLE_TVC_OP (UPDATE)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateDETALLE_TVC_OP()

        Dim objTVCDet As New CGA_TVC_OPDetClass
        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListTVCDet As New List(Of CGA_TVC_OPDetClass)

        Dim result As String = ""

        objTVCDet.Centro_ID = Request.Form("centro")
        objTVCDet.Puestotrabajo_ID = Request.Form("Maq")
        objTVCDet.Orden_ID = Request.Form("Orden")
        objTVCDet.Operacion_ID = Request.Form("Opera")
        objTVCDet.Turno_ID = Request.Form("turno")
        objTVCDet.Operario_ID = Request.Form("operario")
        objTVCDet.CausalSAP_ID = Request.Form("causalSAP")
        objTVCDet.Causal_ID = Request.Form("causal")
        objTVCDet.Observacion_Ope = Request.Form("obserope")
        objTVCDet.Descripcion_Analis = Request.Form("descrip")

        objTVCDet.Accion_ID = Request.Form("accion")
        objTVCDet.Fec_Ent_Accion = Request.Form("dateaccion")
        objTVCDet.Area_ID = Request.Form("area")

        objTVCDet.Fec_Creacion = Request.Form("fechac")
        objTVCDet.Estado = Request.Form("estado")

        objTVCDet.FechaActualizacion = Date.Now
        objTVCDet.Usuario = Request.Form("user")

        ObjListTVCDet.Add(objTVCDet)

        result = SQL_TVC.UpdateTVC(objTVCDet)

        Response.Write(result)

    End Sub

#End Region

#Region "DROP LIST"

    ''' <summary>
    ''' funcion que carga el objeto DDL operario
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Operario()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = Request.Form("tabla")

        ObjListDroplist = SQL_TVC.ReadCharge_DropList(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL operario nueva causal
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Operario_Det()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = ""

        ObjListDroplist = SQL_TVC.ReadCharge_DropList_operario(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL CAUSALSAP
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Causal()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Type As String = Request.Form("Type")

        ObjListDroplist = SQL_TVC.ReadCharge_DropList_Causal(vl_S_Type)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Turno
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Turno()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = ""

        ObjListDroplist = SQL_TVC.ReadCharge_DropList_Turno(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Accion
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Accion()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = ""

        ObjListDroplist = SQL_TVC.ReadCharge_DropList_Accion(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que carga el objeto DDL Area
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDDL_Area()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim vl_S_Tabla As String = ""

        ObjListDroplist = SQL_TVC.ReadCharge_DropList_Area(vl_S_Tabla)
        Response.Write(JsonConvert.SerializeObject(ObjListDroplist.ToArray()))

    End Sub

#End Region

#Region "FUNCIONES"

    ''' <summary>
    ''' funcion que trae el centro y planta del puesto de trabajo o maquina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cargar_Centro_planta()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
        Dim ID_Maquina As String = Request.Form("ID_Maquina")

        ObjlistTVC = SQL_TVC.SearchCentroPlanta(ID_Maquina)
        Response.Write(JsonConvert.SerializeObject(ObjlistTVC.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que trae los datos para las ordenes
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DatosTVC()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
        Dim ID_Maquina As String = Request.Form("ID_Maquina")
        Dim StartDate As String = Request.Form("StartDate")
        Dim EndDate As String = Request.Form("EndDate")

        ObjlistTVC = SQL_TVC.GridTVC(ID_Maquina, StartDate.Replace("/", "-"), EndDate.Replace("/", "-"))
        Response.Write(JsonConvert.SerializeObject(ObjlistTVC.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que trae el encabesado del detalle TVC
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub TVCEncabezadoDet()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjlistTVC As New List(Of CGA_TVC_OpClass)
        Dim Maq As String = Request.Form("Maq")
        Dim Orden As String = Request.Form("Orden")
        Dim Opera As String = Request.Form("Opera")
        Dim Centro As String = Request.Form("Centro")

        ObjlistTVC = SQL_TVC.EncTVCDet(Maq, Orden, Opera, Centro)
        Response.Write(JsonConvert.SerializeObject(ObjlistTVC.ToArray()))

    End Sub

    ''' <summary>
    ''' funcion que trae el los datos para el grid del detalle TVC
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub TVCGridDet()

        Dim SQL_TVC As New CGA_TVC_OpSQLClass
        Dim ObjlistTVC As New List(Of CGA_TVC_OPDetClass)
        Dim Maq As String = Request.Form("Maq")
        Dim Orden As String = Request.Form("Orden")
        Dim Opera As String = Request.Form("Opera")
        Dim Centro As String = Request.Form("Centro")

        ObjlistTVC = SQL_TVC.GridDetTVC(Maq, Orden, Opera, Centro)

        If ObjlistTVC Is Nothing Then

            Dim objTVC As New CGA_TVC_OPDetClass
            ObjlistTVC = New List(Of CGA_TVC_OPDetClass)

            objTVC.Operario_ID = 0

            ObjlistTVC.Add(objTVC)
        End If


        Response.Write(JsonConvert.SerializeObject(ObjlistTVC.ToArray()))

    End Sub

#End Region

End Class