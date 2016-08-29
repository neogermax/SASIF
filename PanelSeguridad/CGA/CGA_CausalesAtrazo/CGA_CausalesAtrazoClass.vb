Public Class CGA_CausalesAtrazoClass

#Region "campos"
    Private _Causal_ID As String
    Private _CausalRaiz As String
    Private _GerenciaResponsable As String
    Private _Area_Responsable As String
    Private _Comentario As String
    Private _FechaActualizacion As String
    Private _Usuario As String
#End Region

#Region "proiedades"
    Public Property Causal_ID() As String
        Get
            Return Me._Causal_ID
        End Get
        Set(ByVal value As String)
            Me._Causal_ID = value
        End Set
    End Property
    Public Property CausalRaiz() As String
        Get
            Return Me._CausalRaiz
        End Get
        Set(ByVal value As String)
            Me._CausalRaiz = value
        End Set
    End Property
    Public Property GerenciaResponsable() As String
        Get
            Return Me._GerenciaResponsable
        End Get
        Set(ByVal value As String)
            Me._GerenciaResponsable = value
        End Set
    End Property
     Public Property Area_Responsable() As String
        Get
            Return Me._Area_Responsable
        End Get
        Set(ByVal value As String)
            Me._Area_Responsable = value
        End Set
    End Property
    Public Property Comentario() As String
        Get
            Return Me._Comentario
        End Get
        Set(ByVal value As String)
            Me._Comentario = value
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
