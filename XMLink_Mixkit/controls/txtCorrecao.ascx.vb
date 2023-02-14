
Partial Class controls_txtCorrecao
    Inherits System.Web.UI.UserControl

    Public Property Value() As Decimal
        Get
            If txtCorrecao.Text = "" Then
                Return 0
            Else
                Return CDec(txtCorrecao.Text)
            End If
        End Get
        Set(ByVal value As Decimal)
            txtCorrecao.Text = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return txtCorrecao.Enabled
        End Get
        Set(ByVal value As Boolean)
            txtCorrecao.Enabled = value
        End Set
    End Property

    Public Property Required() As Boolean
        Get
            Return valReqCorrecao.Enabled
        End Get
        Set(ByVal value As Boolean)
            valReqCorrecao.Enabled = value
        End Set
    End Property


    Public ReadOnly Property GetInnerClientID() As String
        Get
            Return txtCorrecao.ClientID
        End Get
    End Property
End Class
