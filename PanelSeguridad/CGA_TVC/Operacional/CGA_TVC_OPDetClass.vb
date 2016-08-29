Public Class CGA_TVC_OPDetClass

#Region "campos"
    Private _Centro_ID As Integer
    Private _Puestotrabajo_ID As String
    Private _Orden_ID As Integer
    Private _Operacion_ID As Integer
    Private _Turno_ID As Integer
    Private _Operario_ID As Integer
    Private _Causal_ID As Integer
    Private _CausalSAP_ID As Integer

    Private _Accion_ID As Integer
    Private _Area_ID As Integer

    Private _DESOperario As String
    Private _DESCausal As String
    Private _DESAccion As String
    Private _DESArea As String

    Private _Observacion_Ope As String
    Private _Descripcion_Analis As String
    Private _Fec_Ent_Accion As String
    Private _Fec_Creacion As String
    Private _Estado_ID As Integer
    Private _Estado As String
    Private _FechaActualizacion As String
    Private _Usuario As String

#End Region

#Region "Propiedades"
    Public Property Centro_ID() As Integer
        Get
            Return Me._Centro_ID
        End Get
        Set(ByVal value As Integer)
            Me._Centro_ID = value
        End Set
    End Property
    Public Property Puestotrabajo_ID() As String
        Get
            Return Me._Puestotrabajo_ID
        End Get
        Set(ByVal value As String)
            Me._Puestotrabajo_ID = value
        End Set
    End Property
    Public Property Orden_ID() As Integer
        Get
            Return Me._Orden_ID
        End Get
        Set(ByVal value As Integer)
            Me._Orden_ID = value
        End Set
    End Property
    Public Property Operacion_ID() As Integer
        Get
            Return Me._Operacion_ID
        End Get
        Set(ByVal value As Integer)
            Me._Operacion_ID = value
        End Set
    End Property
    Public Property Turno_ID() As Integer
        Get
            Return Me._Turno_ID
        End Get
        Set(ByVal value As Integer)
            Me._Turno_ID = value
        End Set
    End Property
    Public Property Operario_ID() As Integer
        Get
            Return Me._Operario_ID
        End Get
        Set(ByVal value As Integer)
            Me._Operario_ID = value
        End Set
    End Property
    Public Property Causal_ID() As Integer
        Get
            Return Me._Causal_ID
        End Get
        Set(ByVal value As Integer)
            Me._Causal_ID = value
        End Set
    End Property
    Public Property CausalSAP_ID() As Integer
        Get
            Return Me._CausalSAP_ID
        End Get
        Set(ByVal value As Integer)
            Me._CausalSAP_ID = value
        End Set
    End Property

    Public Property Accion_ID() As Integer
        Get
            Return Me._Accion_ID
        End Get
        Set(ByVal value As Integer)
            Me._Accion_ID = value
        End Set
    End Property
    Public Property Area_ID() As Integer
        Get
            Return Me._Area_ID
        End Get
        Set(ByVal value As Integer)
            Me._Area_ID = value
        End Set
    End Property

    Public Property DESOperario() As String
        Get
            Return Me._DESOperario
        End Get
        Set(ByVal value As String)
            Me._DESOperario = value
        End Set
    End Property
    Public Property DESCausal() As String
        Get
            Return Me._DESCausal
        End Get
        Set(ByVal value As String)
            Me._DESCausal = value
        End Set
    End Property
    Public Property DESAccion() As String
        Get
            Return Me._DESAccion
        End Get
        Set(ByVal value As String)
            Me._DESAccion = value
        End Set
    End Property
    Public Property DESArea() As String
        Get
            Return Me._DESArea
        End Get
        Set(ByVal value As String)
            Me._DESArea = value
        End Set
    End Property

    Public Property Observacion_Ope() As String
        Get
            Return Me._Observacion_Ope
        End Get
        Set(ByVal value As String)
            Me._Observacion_Ope = value
        End Set
    End Property
    Public Property Descripcion_Analis() As String
        Get
            Return Me._Descripcion_Analis
        End Get
        Set(ByVal value As String)
            Me._Descripcion_Analis = value
        End Set
    End Property
    Public Property Fec_Ent_Accion() As String
        Get
            Return Me._Fec_Ent_Accion
        End Get
        Set(ByVal value As String)
            Me._Fec_Ent_Accion = value
        End Set
    End Property
    Public Property Fec_Creacion() As String
        Get
            Return Me._Fec_Creacion
        End Get
        Set(ByVal value As String)
            Me._Fec_Creacion = value
        End Set
    End Property
    Public Property Estado_ID() As Integer
        Get
            Return Me._Estado_ID
        End Get
        Set(ByVal value As Integer)
            Me._Estado_ID = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return Me._Estado
        End Get
        Set(ByVal value As String)
            Me._Estado = value
        End Set
    End Property
    Public Property FechaActualizacion() As String
        Get
            Return Me._FechaActualizacion
        End Get
        Set(ByVal value As String)
            Me._FechaActualizacion = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return Me._Usuario
        End Get
        Set(ByVal value As String)
            Me._Usuario = value
        End Set
    End Property
#End Region

End Class
