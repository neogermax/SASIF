Public Class CGA_CentroClass
#Region "campos"
    Private _Centro_ID As Integer
    Private _Descripcion As String
    Private _Descripcion_Planta As String
    Private _FechaActualizacion As String
    Private _Usuario As String
#End Region

#Region "proiedades"
    Public Property Centro_ID() As Integer
        Get
            Return Me._Centro_ID
        End Get
        Set(ByVal value As Integer)
            Me._Centro_ID = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Me._Descripcion
        End Get
        Set(ByVal value As String)
            Me._Descripcion = value
        End Set
    End Property
    Public Property Descripcion_Planta() As String
        Get
            Return Me._Descripcion_Planta
        End Get
        Set(ByVal value As String)
            Me._Descripcion_Planta = value
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
