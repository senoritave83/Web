
Partial Class controls_progresso
    Inherits System.Web.UI.UserControl

    Public Property Value() As Integer
        Get
            If ViewState("Value") Is Nothing Then
                Return 0
            Else
                Return ViewState("Value")
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Value") = value
        End Set
    End Property

    Public Property SecondValue() As Integer
        Get
            If ViewState("SecondValue") Is Nothing Then
                Return 0
            Else
                Return ViewState("SecondValue")
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("SecondValue") = value
        End Set
    End Property

    Public Property MaxValue() As Integer
        Get
            If ViewState("MaxValue") Is Nothing Then
                Return 100
            Else
                Return ViewState("MaxValue")
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("MaxValue") = value
        End Set
    End Property

    Public Property MinValue() As Integer
        Get
            If ViewState("MinValue") Is Nothing Then
                Return 0
            Else
                Return ViewState("MinValue")
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("MinValue") = value
        End Set
    End Property

    Private Function GetPercent() As Single
        If (MaxValue - MinValue) > 0 Then
            Return ((Value / (MaxValue - MinValue) * 100))
        Else
            Return 0
        End If
    End Function

    Private Function GetSecondPercent() As Single
        If (MaxValue - MinValue) > 0 Then
            Return ((SecondValue / (MaxValue - MinValue) * 100))
        Else
            Return 0
        End If
    End Function


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        If GetPercent() = 0 Then
            divBar.Visible = False
        Else
            divBar.Visible = True
        End If

        If GetSecondPercent() = 0 Then
            divBar2.Visible = False
        Else
            divBar2.Visible = True
        End If

        divBar.Style.Item("width") = CInt(GetPercent()) & "%"
        divBar2.Style.Item("width") = CInt(GetSecondPercent()) & "%"
        ltrProgresso.Text = CInt(GetPercent() + GetSecondPercent()) & "%"
        'imgProgress.Width = ((Value / (MaxValue - MinValue) * 100))
    End Sub
End Class
