Public Class Adm_RolesClass

#Region "campos"
    Private _Rol_ID As String
    Private _Descripcion As String
    Private _Sigla As String
    Private _Estado As String
#End Region

#Region "propiedades"
    Public Property Rol_ID() As String
        Get
            Return Me._Rol_ID
        End Get
        Set(ByVal value As String)
            Me._Rol_ID = value
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
    Public Property Sigla() As String
        Get
            Return Me._Sigla
        End Get
        Set(ByVal value As String)
            Me._Sigla = value
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
