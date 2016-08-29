Public Class CGA_MaquinaClass
#Region "campos"
    Private _Maquina_ID As String
    Private _Descripcion As String
    Private _Centro_ID As Integer
    Private _GRPMaquina_ID As String
    Private _CentroCosto_ID As String
    Private _FechaActualizacion As String
    Private _Usuario As String
    Private _DesCentro As String
    Private _DesGRPMaquina As String
    Private _DesCentroCosto As String

    Private _Largo As Decimal
    Private _Ancho As Decimal
    Private _Espesor_Diametro As Decimal
    Private _Fec_Inicial_Mant As String
    Private _Fec_Final_Mant As String
    Private _H_Inicial_Mant As String
    Private _H_Final_Mant As String
    Private _Fec_Inicial_NDisp As String
    Private _Fec_Final_NDisp As String
    Private _H_Inicial_NDisp As String
    Private _H_Final_NDisp As String
    Private _Tarifa As Integer
    Private _CodMaterial As Integer

#End Region

#Region "proiedades"
    Public Property Maquina_ID() As String
        Get
            Return Me._Maquina_ID
        End Get
        Set(ByVal value As String)
            Me._Maquina_ID = value
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
    Public Property Centro_ID() As Integer
        Get
            Return Me._Centro_ID
        End Get
        Set(ByVal value As Integer)
            Me._Centro_ID = value
        End Set
    End Property
    Public Property GRPMaquina_ID() As Integer
        Get
            Return Me._GRPMaquina_ID
        End Get
        Set(ByVal value As Integer)
            Me._GRPMaquina_ID = value
        End Set
    End Property
    Public Property CentroCosto_ID() As String
        Get
            Return Me._CentroCosto_ID
        End Get
        Set(ByVal value As String)
            Me._CentroCosto_ID = value
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
    Public Property DesCentro() As String
        Get
            Return Me._DesCentro
        End Get
        Set(ByVal value As String)
            Me._DesCentro = value
        End Set
    End Property
    Public Property DesGRPMaquina() As String
        Get
            Return Me._DesGRPMaquina
        End Get
        Set(ByVal value As String)
            Me._DesGRPMaquina = value
        End Set
    End Property
    Public Property DesCentroCosto() As String
        Get
            Return Me._DesCentroCosto
        End Get
        Set(ByVal value As String)
            Me._DesCentroCosto = value
        End Set
    End Property

    Public Property Largo() As Decimal
        Get
            Return Me._Largo
        End Get
        Set(ByVal value As Decimal)
            Me._Largo = value
        End Set
    End Property
    Public Property Ancho() As Decimal
        Get
            Return Me._Ancho
        End Get
        Set(ByVal value As Decimal)
            Me._Ancho = value
        End Set
    End Property
    Public Property Espesor_Diametro() As Decimal
        Get
            Return Me._Espesor_Diametro
        End Get
        Set(ByVal value As Decimal)
            Me._Espesor_Diametro = value
        End Set
    End Property
    Public Property Fec_Inicial_Mant() As String
        Get
            Return Me._Fec_Inicial_Mant
        End Get
        Set(ByVal value As String)
            Me._Fec_Inicial_Mant = value
        End Set
    End Property
    Public Property Fec_Final_Mant() As String
        Get
            Return Me._Fec_Final_Mant
        End Get
        Set(ByVal value As String)
            Me._Fec_Final_Mant = value
        End Set
    End Property
    Public Property H_Inicial_Mant() As String
        Get
            Return Me._H_Inicial_Mant
        End Get
        Set(ByVal value As String)
            Me._H_Inicial_Mant = value
        End Set
    End Property
    Public Property H_Final_Mant() As String
        Get
            Return Me._H_Final_Mant
        End Get
        Set(ByVal value As String)
            Me._H_Final_Mant = value
        End Set
    End Property
    Public Property Fec_Inicial_NDisp() As String
        Get
            Return Me._Fec_Inicial_NDisp
        End Get
        Set(ByVal value As String)
            Me._Fec_Inicial_NDisp = value
        End Set
    End Property
    Public Property Fec_Final_NDisp() As String
        Get
            Return Me._Fec_Final_NDisp
        End Get
        Set(ByVal value As String)
            Me._Fec_Final_NDisp = value
        End Set
    End Property
    Public Property H_Inicial_NDisp() As String
        Get
            Return Me._H_Inicial_NDisp
        End Get
        Set(ByVal value As String)
            Me._H_Inicial_NDisp = value
        End Set
    End Property
    Public Property H_Final_NDisp() As String
        Get
            Return Me._H_Final_NDisp
        End Get
        Set(ByVal value As String)
            Me._H_Final_NDisp = value
        End Set
    End Property
    Public Property Tarifa() As Integer
        Get
            Return Me._Tarifa
        End Get
        Set(ByVal value As Integer)
            Me._Tarifa = value
        End Set
    End Property
    Public Property CodMaterial() As Integer
        Get
            Return Me._CodMaterial
        End Get
        Set(ByVal value As Integer)
            Me._CodMaterial = value
        End Set
    End Property
#End Region
End Class
