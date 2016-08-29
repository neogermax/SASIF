Public Class CGA_FestivosClass

#Region "campos"
    Private _Year As Integer
    Private _Mes_Dia As String
    Private _FechaActualizacion As String
    Private _Usuario As String
    Private _StrMes As String
    Private _StrDia As String
#End Region

#Region "proiedades"
    Public Property Year() As Integer
        Get
            Return Me._Year
        End Get
        Set(ByVal value As Integer)
            Me._Year = value
        End Set
    End Property
    Public Property Mes_Dia() As String
        Get
            Return Me._Mes_Dia
        End Get
        Set(ByVal value As String)
            Me._Mes_Dia = value
        End Set
    End Property
    Public Property StrMes() As String
        Get
            Return Me._StrMes
        End Get
        Set(ByVal value As String)
            Me._StrMes = value
        End Set
    End Property
    Public Property StrDia() As String
        Get
            Return Me._StrDia
        End Get
        Set(ByVal value As String)
            Me._StrDia = value
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
