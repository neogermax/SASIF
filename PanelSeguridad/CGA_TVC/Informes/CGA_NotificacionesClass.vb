Public Class CGA_NotificacionesClass

#Region "campos"
    Private _Centro_ID As Integer
    Private _Orden_ID As Integer
    Private _Puestotrabajo_ID As String

    Private _ZPP078_N_Pedido As String
    Private _ZPP078_Posicion As String
    Private _ZPP078_Nombre As String
    Private _ZPP078_N_Personal As String
    Private _ZPP078_NombrePersonal As String
    Private _ZPP078_FechaIni As String
    Private _ZPP078_Duracmin As String

    Private _ZPP079_N_Personal As String
    Private _ZPP079_NombrePersonal As String
    Private _ZPP079_FechaIni As String
    Private _ZPP079_Duracmin As String
    Private _ZPP079_DescMotivo As String

    Private _KSB1_Cccoste As String
    Private _KSB1_OrdPartner As String
    Private _KSB1_N_pers As String
    Private _KSB1_FeContab As String
    Private _KSB1_CtdReg As String
    Private _KSB1_ClAct As String
    Private _KSB1_Usuario As String

    Private _DescripCentro As String
    Private _DescripMaquina As String

#End Region

#Region "propiedades"
    Public Property Centro_ID() As Integer
        Get
            Return Me._Centro_ID
        End Get
        Set(ByVal value As Integer)
            Me._Centro_ID = value
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
    Public Property Puestotrabajo_ID() As String
        Get
            Return Me._Puestotrabajo_ID
        End Get
        Set(ByVal value As String)
            Me._Puestotrabajo_ID = value
        End Set
    End Property

    Public Property ZPP078_N_Pedido() As String
        Get
            Return Me._ZPP078_N_Pedido
        End Get
        Set(ByVal value As String)
            Me._ZPP078_N_Pedido = value
        End Set
    End Property
    Public Property ZPP078_Posicion() As String
        Get
            Return Me._ZPP078_Posicion
        End Get
        Set(ByVal value As String)
            Me._ZPP078_Posicion = value
        End Set
    End Property
    Public Property ZPP078_Nombre() As String
        Get
            Return Me._ZPP078_Nombre
        End Get
        Set(ByVal value As String)
            Me._ZPP078_Nombre = value
        End Set
    End Property
    Public Property ZPP078_N_Personal() As String
        Get
            Return Me._ZPP078_N_Personal
        End Get
        Set(ByVal value As String)
            Me._ZPP078_N_Personal = value
        End Set
    End Property
    Public Property ZPP078_NombrePersonal() As String
        Get
            Return Me._ZPP078_NombrePersonal
        End Get
        Set(ByVal value As String)
            Me._ZPP078_NombrePersonal = value
        End Set
    End Property
    Public Property ZPP078_FechaIni() As String
        Get
            Return Me._ZPP078_FechaIni
        End Get
        Set(ByVal value As String)
            Me._ZPP078_FechaIni = value
        End Set
    End Property
    Public Property ZPP078_Duracmin() As String
        Get
            Return Me._ZPP078_Duracmin
        End Get
        Set(ByVal value As String)
            Me._ZPP078_Duracmin = value
        End Set
    End Property

    Public Property ZPP079_N_Personal() As String
        Get
            Return Me._ZPP079_N_Personal
        End Get
        Set(ByVal value As String)
            Me._ZPP079_N_Personal = value
        End Set
    End Property
    Public Property ZPP079_NombrePersonal() As String
        Get
            Return Me._ZPP079_NombrePersonal
        End Get
        Set(ByVal value As String)
            Me._ZPP079_NombrePersonal = value
        End Set
    End Property
    Public Property ZPP079_FechaIni() As String
        Get
            Return Me._ZPP079_FechaIni
        End Get
        Set(ByVal value As String)
            Me._ZPP079_FechaIni = value
        End Set
    End Property
    Public Property ZPP079_Duracmin() As String
        Get
            Return Me._ZPP079_Duracmin
        End Get
        Set(ByVal value As String)
            Me._ZPP079_Duracmin = value
        End Set
    End Property
    Public Property ZPP079_DescMotivo() As String
        Get
            Return Me._ZPP079_DescMotivo
        End Get
        Set(ByVal value As String)
            Me._ZPP079_DescMotivo = value
        End Set
    End Property

    Public Property KSB1_Cccoste() As String
        Get
            Return Me._KSB1_Cccoste
        End Get
        Set(ByVal value As String)
            Me._KSB1_Cccoste = value
        End Set
    End Property
    Public Property KSB1_OrdPartner() As String
        Get
            Return Me._KSB1_OrdPartner
        End Get
        Set(ByVal value As String)
            Me._KSB1_OrdPartner = value
        End Set
    End Property
    Public Property KSB1_N_pers() As String
        Get
            Return Me._KSB1_N_pers
        End Get
        Set(ByVal value As String)
            Me._KSB1_N_pers = value
        End Set
    End Property
    Public Property KSB1_FeContab() As String
        Get
            Return Me._KSB1_FeContab
        End Get
        Set(ByVal value As String)
            Me._KSB1_FeContab = value
        End Set
    End Property
    Public Property KSB1_CtdReg() As String
        Get
            Return Me._KSB1_CtdReg
        End Get
        Set(ByVal value As String)
            Me._KSB1_CtdReg = value
        End Set
    End Property
    Public Property KSB1_ClAct() As String
        Get
            Return Me._KSB1_ClAct
        End Get
        Set(ByVal value As String)
            Me._KSB1_ClAct = value
        End Set
    End Property
    Public Property KSB1_Usuario() As String
        Get
            Return Me._KSB1_Usuario
        End Get
        Set(ByVal value As String)
            Me._KSB1_Usuario = value
        End Set
    End Property

    Public Property DescripCentro() As String
        Get
            Return Me._DescripCentro
        End Get
        Set(ByVal value As String)
            Me._DescripCentro = value
        End Set
    End Property
    Public Property DescripMaquina() As String
        Get
            Return Me._DescripMaquina
        End Get
        Set(ByVal value As String)
            Me._DescripMaquina = value
        End Set
    End Property

#End Region


End Class
