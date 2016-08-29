Public Class CGA_CausalesClass
#Region "campos"
    Private _Causal_ID As Integer
    Private _Descripcion As String
    Private _Tipo As String
    Private _FechaActualizacion As String
    Private _Usuario As String
    Private _DesTipo As String
#End Region

#Region "proiedades"
    Public Property Causal_ID() As Integer
        Get
            Return Me._Causal_ID
        End Get
        Set(ByVal value As Integer)
            Me._Causal_ID = value
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
    Public Property Tipo() As String
        Get
            Return Me._Tipo
        End Get
        Set(ByVal value As String)
            Me._Tipo = value
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
    Public Property DesTipo() As String
        Get
            Return Me._DesTipo
        End Get
        Set(ByVal value As String)
            Me._DesTipo = value
        End Set
    End Property
#End Region
End Class
