Public Class CGA_TVC_InfClass

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

#Region "campos consulta primera tabla"
    Private _Puestotrabajo_ID As String
    Private _GRPMaquina_ID As Integer

    Private _Descrip_Puestotrabajo As String
    Private _Descrip_GRPMaquina As String
    Private _Descrip_Centro As String

    Private _FechaCreacion As String 'FECHA INICIAL
    Private _FechaFinMasTardia As String 'FECHA FINAL

    Private _Orden_ID As Integer
    Private _Operacion_ID As Integer
    Private _FechaLiberacReal As String 'FECHA DE LIBERACION
    Private _FechaCier As String 'FECHA DE CIERRE
    Private _FechaRegEntrega As String 'FECHA DE ENTREGA A DESPACHO
    Private _StatusSistema As String
    Private _FechaPreferenciaEntrega As Date
    Private _SEMAFORO As String
    Private _DesStatusSistema As String
#End Region

#Region "propiedades consulta primera tabla"
    Public Property Puestotrabajo_ID() As String
        Get
            Return Me._Puestotrabajo_ID
        End Get
        Set(ByVal value As String)
            Me._Puestotrabajo_ID = value
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
    Public Property Descrip_Puestotrabajo() As String
        Get
            Return Me._Descrip_Puestotrabajo
        End Get
        Set(ByVal value As String)
            Me._Descrip_Puestotrabajo = value
        End Set
    End Property
    Public Property Descrip_GRPMaquina() As String
        Get
            Return Me._Descrip_GRPMaquina
        End Get
        Set(ByVal value As String)
            Me._Descrip_GRPMaquina = value
        End Set
    End Property
    Public Property Descrip_Centro() As String
        Get
            Return Me._Descrip_Centro
        End Get
        Set(ByVal value As String)
            Me._Descrip_Centro = value
        End Set
    End Property
    Public Property FechaCreacion() As String
        Get
            Return Me._FechaCreacion
        End Get
        Set(ByVal value As String)
            Me._FechaCreacion = value
        End Set
    End Property
    Public Property FechaFinMasTardia() As String
        Get
            Return Me._FechaFinMasTardia
        End Get
        Set(ByVal value As String)
            Me._FechaFinMasTardia = value
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
    Public Property Operacion_ID() As Integer
        Get
            Return Me._Operacion_ID
        End Get
        Set(ByVal value As Integer)
            Me._Operacion_ID = value
        End Set
    End Property
    Public Property FechaLiberacReal() As String
        Get
            Return Me._FechaLiberacReal
        End Get
        Set(ByVal value As String)
            Me._FechaLiberacReal = value
        End Set
    End Property
    Public Property FechaCier() As String
        Get
            Return Me._FechaCier
        End Get
        Set(ByVal value As String)
            Me._FechaCier = value
        End Set
    End Property
    Public Property FechaRegEntrega() As String
        Get
            Return Me._FechaRegEntrega
        End Get
        Set(ByVal value As String)
            Me._FechaRegEntrega = value
        End Set
    End Property
    Public Property StatusSistema() As String
        Get
            Return Me._StatusSistema
        End Get
        Set(ByVal value As String)
            Me._StatusSistema = value
        End Set
    End Property
    Public Property FechaPreferenciaEntrega() As Date
        Get
            Return Me._FechaPreferenciaEntrega
        End Get
        Set(ByVal value As Date)
            Me._FechaPreferenciaEntrega = value
        End Set
    End Property
    Public Property SEMAFORO() As String
        Get
            Return Me._SEMAFORO
        End Get
        Set(ByVal value As String)
            Me._SEMAFORO = value
        End Set
    End Property
    Public Property DesStatusSistema() As String
        Get
            Return Me._DesStatusSistema
        End Get
        Set(ByVal value As String)
            Me._DesStatusSistema = value
        End Set
    End Property
#End Region

#Region "Campos calculo tvc"
    Private _CantidadOperacion As Integer
    Private _ValorPrefijado_1 As Decimal
    Private _ValorPrefijado_2 As Decimal
    Private _TPlaneado As Decimal
    Private _ActivNotificada_1 As Decimal
    Private _ActivNotificada_2 As Decimal
    Private _TReal As Decimal
    Private _Clase As String
    Private _TIEMPO As Double
#End Region

#Region "Propiedades calculo tvc"
    Public Property CantidadOperacion() As Integer
        Get
            Return Me._CantidadOperacion
        End Get
        Set(ByVal value As Integer)
            Me._CantidadOperacion = value
        End Set
    End Property
    Public Property ValorPrefijado_1() As Decimal
        Get
            Return Me._ValorPrefijado_1
        End Get
        Set(ByVal value As Decimal)
            Me._ValorPrefijado_1 = value
        End Set
    End Property
    Public Property ValorPrefijado_2() As Decimal
        Get
            Return Me._ValorPrefijado_2
        End Get
        Set(ByVal value As Decimal)
            Me._ValorPrefijado_2 = value
        End Set
    End Property
    Public Property TPlaneado() As Decimal
        Get
            Return Me._TPlaneado
        End Get
        Set(ByVal value As Decimal)
            Me._TPlaneado = value
        End Set
    End Property
    Public Property ActivNotificada_1() As Decimal
        Get
            Return Me._ActivNotificada_1
        End Get
        Set(ByVal value As Decimal)
            Me._ActivNotificada_1 = value
        End Set
    End Property
    Public Property ActivNotificada_2() As Decimal
        Get
            Return Me._ActivNotificada_2
        End Get
        Set(ByVal value As Decimal)
            Me._ActivNotificada_2 = value
        End Set
    End Property
    Public Property TReal() As Decimal
        Get
            Return Me._TReal
        End Get
        Set(ByVal value As Decimal)
            Me._TReal = value
        End Set
    End Property
    Public Property Clase() As String
        Get
            Return Me._Clase
        End Get
        Set(ByVal value As String)
            Me._Clase = value
        End Set
    End Property
    Public Property TIEMPO() As Double
        Get
            Return Me._TIEMPO
        End Get
        Set(ByVal value As Double)
            Me._TIEMPO = value
        End Set
    End Property

#End Region


End Class
