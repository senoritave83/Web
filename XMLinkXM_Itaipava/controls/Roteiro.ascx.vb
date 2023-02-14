Namespace Controls
    <Themeable(True)> _
    Partial Class Roteiro
        Inherits System.Web.UI.UserControl
        Protected m_intDiaSemana As Integer = 0


        Public Property Width() As System.Web.UI.WebControls.Unit
            Get
                Return pnlRoteiro.Width
            End Get
            Set(ByVal value As System.Web.UI.WebControls.Unit)
                pnlRoteiro.Width = value
            End Set
        End Property

        Public Property Height() As System.Web.UI.WebControls.Unit
            Get
                Return pnlRoteiro.Height
            End Get
            Set(ByVal value As System.Web.UI.WebControls.Unit)
                pnlRoteiro.Height = value
            End Set
        End Property

        Public Property CssClass() As String
            Get
                Return pnlRoteiro.CssClass
            End Get
            Set(ByVal value As String)
                pnlRoteiro.CssClass = value
            End Set
        End Property

        Public Property WeekDayPanelCssClass() As String
            Get
                Return pnlDiaSemana.CssClass
            End Get
            Set(ByVal value As String)
                pnlDiaSemana.CssClass = value
            End Set
        End Property



        Public Overridable Property DiaSemana() As Integer
            Get
                m_intDiaSemana = 0
                For Each lst As ListItem In chkDiaSemana.Items
                    If lst.Selected Then m_intDiaSemana = CInt(m_intDiaSemana) + CInt(lst.Value)
                Next
                Return m_intDiaSemana
            End Get
            Set(ByVal Value As Integer)
                m_intDiaSemana = Value
                For Each lst As ListItem In chkDiaSemana.Items
                    lst.Selected = (lst.Value And CInt(m_intDiaSemana))
                Next
            End Set
        End Property

        Protected Sub CreateItens()

            Dim iTemp As Integer, iValue As Integer

            chkDiaSemana.Items.Clear()

            'VERIFICANDO DIA DA SEMANA
            For iTemp = 0 To 5
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intDiaSemana))
                lst.Text = WeekdayName(iTemp + 1, False, Microsoft.VisualBasic.FirstDayOfWeek.Monday)
                lst.Value = iValue
                chkDiaSemana.Items.Add(lst)
            Next
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                CreateItens()
            End If
        End Sub
    End Class

End Namespace
