Public Class OpeTurnosClass

#Region "campos consulta centro_planta"
    Private _Centro_ID As Integer
    Private _Descripcion As String
    Private _Descripcion_Planta As String
#End Region

#Region "proiedades centro_planta"
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
#End Region

#Region "Campos Originales de la clase"

    Private _PuestoTrabajo_ID As String
    Private _Ano_Mes_ID As String
    Private _Mes As String
    Private _Year As String
    Private _Dia As Integer
    Private _StrDia As String
    Private _StrMes As String
    Private _Day_Type As String

    Private _T_1 As Integer
    Private _T_1_HI As Integer
    Private _T_1_HF As Integer

    Private _T_2 As Integer
    Private _T_2_HI As Integer
    Private _T_2_HF As Integer

    Private _T_3 As Integer
    Private _T_3_HI As Integer
    Private _T_3_HF As Integer

    Private _T_4 As Integer
    Private _T_4_HI As Integer
    Private _T_4_HF As Integer

    Private _T_5 As Integer
    Private _T_5_HI As Integer
    Private _T_5_HF As Integer

    Private _T_6 As Integer
    Private _T_6_HI As Integer
    Private _T_6_HF As Integer

    Private _Presupuesto As Decimal
    Private _Programado As Integer

    Private _FechaActualizacion As String
    Private _Usuario As String
#End Region

#Region "propiedades Originales de la clase"
    Public Property PuestoTrabajo_ID() As String
        Get
            Return Me._PuestoTrabajo_ID
        End Get
        Set(ByVal value As String)
            Me._PuestoTrabajo_ID = value
        End Set
    End Property
    Public Property Ano_Mes_ID() As String
        Get
            Return Me._Ano_Mes_ID
        End Get
        Set(ByVal value As String)
            Me._Ano_Mes_ID = value
        End Set
    End Property
    Public Property Year() As String
        Get
            Return Me._Year
        End Get
        Set(ByVal value As String)
            Me._Year = value
        End Set
    End Property
    Public Property Mes() As String
        Get
            Return Me._Mes
        End Get
        Set(ByVal value As String)
            Me._Mes = value
        End Set
    End Property
    Public Property Dia() As Integer
        Get
            Return Me._Dia
        End Get
        Set(ByVal value As Integer)
            Me._Dia = value
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
    Public Property StrMes() As String
        Get
            Return Me._StrMes
        End Get
        Set(ByVal value As String)
            Me._StrMes = value
        End Set
    End Property
    Public Property Day_Type() As String
        Get
            Return Me._Day_Type
        End Get
        Set(ByVal value As String)
            Me._Day_Type = value
        End Set
    End Property

    Public Property T_1() As Integer
        Get
            Return Me._T_1
        End Get
        Set(ByVal value As Integer)
            Me._T_1 = value
        End Set
    End Property
    Public Property T_1_HI() As Integer
        Get
            Return Me._T_1_HI
        End Get
        Set(ByVal value As Integer)
            Me._T_1_HI = value
        End Set
    End Property
    Public Property T_1_HF() As Integer
        Get
            Return Me._T_1_HF
        End Get
        Set(ByVal value As Integer)
            Me._T_1_HF = value
        End Set
    End Property

    Public Property T_2() As Integer
        Get
            Return Me._T_2
        End Get
        Set(ByVal value As Integer)
            Me._T_2 = value
        End Set
    End Property
    Public Property T_2_HI() As Integer
        Get
            Return Me._T_2_HI
        End Get
        Set(ByVal value As Integer)
            Me._T_2_HI = value
        End Set
    End Property
    Public Property T_2_HF() As Integer
        Get
            Return Me._T_2_HF
        End Get
        Set(ByVal value As Integer)
            Me._T_2_HF = value
        End Set
    End Property

    Public Property T_3() As Integer
        Get
            Return Me._T_3
        End Get
        Set(ByVal value As Integer)
            Me._T_3 = value
        End Set
    End Property
    Public Property T_3_HI() As Integer
        Get
            Return Me._T_3_HI
        End Get
        Set(ByVal value As Integer)
            Me._T_3_HI = value
        End Set
    End Property
    Public Property T_3_HF() As Integer
        Get
            Return Me._T_3_HF
        End Get
        Set(ByVal value As Integer)
            Me._T_3_HF = value
        End Set
    End Property

    Public Property T_4() As Integer
        Get
            Return Me._T_4
        End Get
        Set(ByVal value As Integer)
            Me._T_4 = value
        End Set
    End Property
    Public Property T_4_HI() As Integer
        Get
            Return Me._T_4_HI
        End Get
        Set(ByVal value As Integer)
            Me._T_4_HI = value
        End Set
    End Property
    Public Property T_4_HF() As Integer
        Get
            Return Me._T_4_HF
        End Get
        Set(ByVal value As Integer)
            Me._T_4_HF = value
        End Set
    End Property

    Public Property T_5() As Integer
        Get
            Return Me._T_5
        End Get
        Set(ByVal value As Integer)
            Me._T_5 = value
        End Set
    End Property
    Public Property T_5_HI() As Integer
        Get
            Return Me._T_5_HI
        End Get
        Set(ByVal value As Integer)
            Me._T_5_HI = value
        End Set
    End Property
    Public Property T_5_HF() As Integer
        Get
            Return Me._T_5_HF
        End Get
        Set(ByVal value As Integer)
            Me._T_5_HF = value
        End Set
    End Property

    Public Property T_6() As Integer
        Get
            Return Me._T_6
        End Get
        Set(ByVal value As Integer)
            Me._T_6 = value
        End Set
    End Property
    Public Property T_6_HI() As Integer
        Get
            Return Me._T_6_HI
        End Get
        Set(ByVal value As Integer)
            Me._T_6_HI = value
        End Set
    End Property
    Public Property T_6_HF() As Integer
        Get
            Return Me._T_6_HF
        End Get
        Set(ByVal value As Integer)
            Me._T_6_HF = value
        End Set
    End Property

    Public Property Presupuesto() As Decimal
        Get
            Return Me._Presupuesto
        End Get
        Set(ByVal value As Decimal)
            Me._Presupuesto = value
        End Set
    End Property
    Public Property Programado() As Integer
        Get
            Return Me._Programado
        End Get
        Set(ByVal value As Integer)
            Me._Programado = value
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
