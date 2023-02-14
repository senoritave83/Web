Namespace controls


    Partial Class xmcolor
        Inherits System.Web.UI.UserControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            ColorLink.HRef = "javascript:changeColor(document." & Me.Page.Form.ClientID & "." & ColorName.ClientID & ");"
        End Sub

        Public Property Color() As String
            Get
                Return ColorName.Value
            End Get
            Set(ByVal Value As String)
                ColorName.Value = Value
                ColorCell.Style.Item("background-color") = Value
            End Set
        End Property

    End Class

End Namespace
