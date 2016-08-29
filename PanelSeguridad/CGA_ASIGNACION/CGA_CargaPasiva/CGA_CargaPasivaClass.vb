Public Class CGA_CargaPasivaClass

#Region "campos"
    Private _CP_ID As Integer

    Private _Centro_ID As Integer
    Private _GRPMaquina_ID As Integer
    Private _Puestotrabajo_ID As String
    Private _Orden_ID As Integer
    Private _Departamento As String
    Private _HPlan As Decimal
    Private _N_Oferta As Integer

    Private _Descrip_Puestotrabajo As String
    Private _Descrip_GRPMaquina As String
    Private _Descrip_Centro As String
    Private _Descrip_Departamento As String

    Private _FechaActualizacion As String
    Private _Usuario As String
#End Region

#Region "propiedades"
    Public Property CP_ID() As Integer
        Get
            Return Me._CP_ID
        End Get
        Set(ByVal value As Integer)
            Me._CP_ID = value
        End Set
    End Property

    Public Property Centro_ID() As Integer
        Get
            Return Me._Centro_ID
        End Get
        Set(ByVal value As Integer)
            Me._Centro_ID = value
        End Set
    End Property
    Public Property GRPMaquina_ID() As Integer
        Get
            Return Me._GRPMaquina_ID
        End Get
        Set(ByVal value As Integer)
            Me._GRPMaquina_ID = value
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
    Public Property Departamento() As String
        Get
            Return Me._Departamento
        End Get
        Set(ByVal value As String)
            Me._Departamento = value
        End Set
    End Property
    Public Property HPlan() As Decimal
        Get
            Return Me._HPlan
        End Get
        Set(ByVal value As Decimal)
            Me._HPlan = value
        End Set
    End Property
    Public Property N_Oferta() As Integer
        Get
            Return Me._N_Oferta
        End Get
        Set(ByVal value As Integer)
            Me._N_Oferta = value
        End Set
    End Property

    Public Property Descrip_Puestotrabajo() As String
        Get
            Return Me._Descrip_Puestotrabajo
        End Get
        Set(ByVal value As String)
            Me._Descrip_Puestotrabajo = value
        End Set
    End Property
    Public Property Descrip_GRPMaquina() As String
        Get
            Return Me._Descrip_GRPMaquina
        End Get
        Set(ByVal value As String)
            Me._Descrip_GRPMaquina = value
        End Set
    End Property
    Public Property Descrip_Centro() As String
        Get
            Return Me._Descrip_Centro
        End Get
        Set(ByVal value As String)
            Me._Descrip_Centro = value
        End Set
    End Property
    Public Property Descrip_Departamento() As String
        Get
            Return Me._Descrip_Departamento
        End Get
        Set(ByVal value As String)
            Me._Descrip_Departamento = value
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
