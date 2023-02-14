
Partial Class controls_txtDescontoMaximo
    Inherits System.Web.UI.UserControl

    Public Property Value() As Decimal
        Get
            If chkSemDescontoMax.Checked Then
                Return 100
            ElseIf TextBox1.Text = "" Then
                Return 100
            Else
                Return TextBox1.Text
            End If
        End Get
        Set(ByVal value As Decimal)
            If Required Then
                TextBox1.Text = value
                TextBox1.Enabled = True
            ElseIf value = 100 Then
                TextBox1.Text = ""
                chkComDescontoMax.Checked = False
                chkSemDescontoMax.Checked = True
                TextBox1.Enabled = False
            Else
                TextBox1.Text = value
                chkComDescontoMax.Checked = True
                chkSemDescontoMax.Checked = False
                TextBox1.Enabled = True
            End If
        End Set
    End Property

    Public Property Required() As Boolean
        Get
            Return valReqDescontoMax.Enabled
        End Get
        Set(ByVal value As Boolean)
            If value Then
                trSemDesconto.Visible = False
                tdOpcaoDesconto.Visible = False
            Else
                trSemDesconto.Visible = True
                tdOpcaoDesconto.Visible = True
            End If
            valReqDescontoMax.Enabled = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return TextBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Enabled = value
        End Set
    End Property


End Class
