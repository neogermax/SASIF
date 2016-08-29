Public Class CGA_OperarioClass
#Region "campos"
    Private _Operario_ID As Integer
    Private _Identificacion As Integer
    Private _Nombre As String
    Private _Centro_ID As Integer
    Private _CentroCosto_ID As Integer
    Private _Area_ID As Integer
    Private _FechaActualizacion As String
    Private _Usuario As String
    Private _DesCentro As String
    Private _DesCCostos As String
    Private _DesArea As String

#End Region

#Region "proiedades"
    Public Property Operario_ID() As Integer
        Get
            Return Me._Operario_ID
        End Get
        Set(ByVal value As Integer)
            Me._Operario_ID = value
        End Set
    End Property
    Public Property Identificacion() As Integer
        Get
            Return Me._Identificacion
        End Get
        Set(ByVal value As Integer)
            Me._Identificacion = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Set(ByVal value As String)
            Me._Nombre = value
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
    Public Property CentroCosto_ID() As Integer
        Get
            Return Me._CentroCosto_ID
        End Get
        Set(ByVal value As Integer)
            Me._CentroCosto_ID = value
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
    Public Property DesCentro() As String
        Get
            Return Me._DesCentro
        End Get
        Set(ByVal value As String)
            Me._DesCentro = value
        End Set
    End Property
    Public Property DesCCostos() As String
        Get
            Return Me._DesCCostos
        End Get
        Set(ByVal value As String)
            Me._DesCCostos = value
        End Set
    End Property
    Public Property DesArea() As String
        Get
            Return Me._DesArea
        End Get
        Set(ByVal value As String)
            Me._DesArea = value
        End Set
    End Property

#End Region
End Class
