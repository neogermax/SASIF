Public Class Adm_LinksClass
#Region "campos"
    Private _Link_ID As String
    Private _Descripcion As String
    Private _Param1 As Integer
    Private _Param2 As String
    Private _Img As String
    Private _LinkPag As String
    Private _Estado As String
#End Region

#Region "propiedades"
    Public Property Link_ID() As String
        Get
            Return Me._Link_ID
        End Get
        Set(ByVal value As String)
            Me._Link_ID = value
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
    Public Property Param1() As Integer
        Get
            Return Me._Param1
        End Get
        Set(ByVal value As Integer)
            Me._Param1 = value
        End Set
    End Property
    Public Property Param2() As String
        Get
            Return Me._Param2
        End Get
        Set(ByVal value As String)
            Me._Param2 = value
        End Set
    End Property
    Public Property Img() As String
        Get
            Return Me._Img
        End Get
        Set(ByVal value As String)
            Me._Img = value
        End Set
    End Property
    Public Property LinkPag() As String
        Get
            Return Me._LinkPag
        End Get
        Set(ByVal value As String)
            Me._LinkPag = value
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
#End Region

End Class
