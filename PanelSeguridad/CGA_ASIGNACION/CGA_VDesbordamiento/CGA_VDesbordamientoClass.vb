Public Class CGA_VDesbordamientoClass

#Region "campos"
    
    Private _Centro_ID As Integer
    Private _GRPMaquina_ID As Integer
    Private _Puestotrabajo_ID As String
    
    Private _Desboramiento_1 As String
    Private _Desboramiento_2 As String
    Private _Desboramiento_3 As String
    Private _Desboramiento_4 As String
    Private _Desboramiento_5 As String
    Private _Desboramiento_6 As String
    Private _Desboramiento_7 As String

    Private _Descrip_Puestotrabajo As String
    Private _Descrip_GRPMaquina As String
    Private _Descrip_Centro As String

    Private _Descrip_Desboramiento_1 As String
    Private _Descrip_Desboramiento_2 As String
    Private _Descrip_Desboramiento_3 As String
    Private _Descrip_Desboramiento_4 As String
    Private _Descrip_Desboramiento_5 As String
    Private _Descrip_Desboramiento_6 As String
    Private _Descrip_Desboramiento_7 As String


    Private _FechaActualizacion As String
    Private _Usuario As String
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
    Public Property GRPMaquina_ID() As Integer
        Get
            Return Me._GRPMaquina_ID
        End Get
        Set(ByVal value As Integer)
            Me._GRPMaquina_ID = value
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

    Public Property Desboramiento_1() As String
        Get
            Return Me._Desboramiento_1
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_1 = value
        End Set
    End Property
    Public Property Desboramiento_2() As String
        Get
            Return Me._Desboramiento_2
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_2 = value
        End Set
    End Property
    Public Property Desboramiento_3() As String
        Get
            Return Me._Desboramiento_3
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_3 = value
        End Set
    End Property
    Public Property Desboramiento_4() As String
        Get
            Return Me._Desboramiento_4
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_4 = value
        End Set
    End Property
    Public Property Desboramiento_5() As String
        Get
            Return Me._Desboramiento_5
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_5 = value
        End Set
    End Property
    Public Property Desboramiento_6() As String
        Get
            Return Me._Desboramiento_6
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_6 = value
        End Set
    End Property
    Public Property Desboramiento_7() As String
        Get
            Return Me._Desboramiento_7
        End Get
        Set(ByVal value As String)
            Me._Desboramiento_7 = value
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

    Public Property Descrip_Desboramiento_1() As String
        Get
            Return Me._Descrip_Desboramiento_1
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_1 = value
        End Set
    End Property
    Public Property Descrip_Desboramiento_2() As String
        Get
            Return Me._Descrip_Desboramiento_2
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_2 = value
        End Set
    End Property
    Public Property Descrip_Desboramiento_3() As String
        Get
            Return Me._Descrip_Desboramiento_3
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_3 = value
        End Set
    End Property
    Public Property Descrip_Desboramiento_4() As String
        Get
            Return Me._Descrip_Desboramiento_4
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_4 = value
        End Set
    End Property
    Public Property Descrip_Desboramiento_5() As String
        Get
            Return Me._Descrip_Desboramiento_5
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_5 = value
        End Set
    End Property
    Public Property Descrip_Desboramiento_6() As String
        Get
            Return Me._Descrip_Desboramiento_6
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_6 = value
        End Set
    End Property
    Public Property Descrip_Desboramiento_7() As String
        Get
            Return Me._Descrip_Desboramiento_7
        End Get
        Set(ByVal value As String)
            Me._Descrip_Desboramiento_7 = value
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
