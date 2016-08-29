Public Class Adm_UsuarioClass
#Region "campos"
    Private _Usuario_ID As String
    Private _Documento As String
    Private _Nombre As String
    Private _Rol_ID As String
    Private _Estado As String
    Private _Password As String
#End Region

#Region "propiedades"
    Public Property Usuario_ID() As String
        Get
            Return Me._Usuario_ID
        End Get
        Set(ByVal value As String)
            Me._Usuario_ID = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return Me._Documento
        End Get
        Set(ByVal value As String)
            Me._Documento = value
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
    Public Property Rol_ID() As String
        Get
            Return Me._Rol_ID
        End Get
        Set(ByVal value As String)
            Me._Rol_ID = value
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
    Public Property Password() As String
        Get
            Return Me._Password
        End Get
        Set(ByVal value As String)
            Me._Password = value
        End Set
    End Property
#End Region

End Class
