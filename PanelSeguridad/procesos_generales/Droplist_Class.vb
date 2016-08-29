Public Class Droplist_Class
#Region "campos Drop List"
    Private _ID As String
    Private _descripcion As String
    Private _tipo As String
#End Region

#Region "propiedades Drop list"
    Public Property ID() As String
        Get
            Return Me._ID
        End Get
        Set(ByVal value As String)
            Me._ID = value
        End Set
    End Property
    Public Property descripcion() As String
        Get
            Return Me._descripcion
        End Get
        Set(ByVal value As String)
            Me._descripcion = value
        End Set
    End Property
    Public Property tipo() As String
        Get
            Return Me._tipo
        End Get
        Set(ByVal value As String)
            Me._tipo = value
        End Set
    End Property

#End Region

#Region "campos Encabezado"
    Private _Titulo As String
    Private _LogoSasif As String
    Private _LogoEmpresa As String
    Private _parrafo_1 As String
    Private _parrafo_2 As String
    Private _parrafo_3 As String
#End Region

#Region "propiedades Encabezado"
    Public Property Titulo() As String
        Get
            Return Me._Titulo
        End Get
        Set(ByVal value As String)
            Me._Titulo = value
        End Set
    End Property
    Public Property LogoSasif() As String
        Get
            Return Me._LogoSasif
        End Get
        Set(ByVal value As String)
            Me._LogoSasif = value
        End Set
    End Property
    Public Property LogoEmpresa() As String
        Get
            Return Me._LogoEmpresa
        End Get
        Set(ByVal value As String)
            Me._LogoEmpresa = value
        End Set
    End Property
    Public Property parrafo_1() As String
        Get
            Return Me._parrafo_1
        End Get
        Set(ByVal value As String)
            Me._parrafo_1 = value
        End Set
    End Property
    Public Property parrafo_2() As String
        Get
            Return Me._parrafo_2
        End Get
        Set(ByVal value As String)
            Me._parrafo_2 = value
        End Set
    End Property
    Public Property parrafo_3() As String
        Get
            Return Me._parrafo_3
        End Get
        Set(ByVal value As String)
            Me._parrafo_3 = value
        End Set
    End Property
#End Region

End Class
