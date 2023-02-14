Namespace Controls
    <Themeable(True)> _
                  Partial Class Roteiro
        Inherits System.Web.UI.UserControl
        Protected m_intDia As Integer = 0
        Protected m_intMes As Integer = 0
        Protected m_intDiaSemana As Integer = 0
        Protected m_intSemanaMes As Integer = 0

        Public Property DayPanelCssClass() As String
            Get
                Return pnlDia.CssClass
            End Get
            Set(ByVal value As String)
                pnlDia.CssClass = value
            End Set
        End Property

        Public Property SemanaMesPanelCssClass() As String
            Get
                Return pnlSemanaMes.CssClass
            End Get
            Set(ByVal value As String)
                pnlSemanaMes.CssClass = value
            End Set
        End Property

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

        Public Property MesPanelCssClass() As String
            Get
                Return pnlMes.CssClass
            End Get
            Set(ByVal value As String)
                pnlMes.CssClass = value
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

        Public Overridable Property Dia() As Integer
            Get
                m_intDia = 0
                For Each lst As ListItem In chkDia.Items
                    If lst.Selected Then m_intDia = CInt(m_intDia) + CInt(lst.Value)
                Next
                Return m_intDia
            End Get
            Set(ByVal Value As Integer)
                m_intDia = Value
                For Each lst As ListItem In chkDia.Items
                    lst.Selected = (lst.Value And CInt(m_intDia))
                Next
            End Set
        End Property

        Public Overridable Property Mes() As Integer
            Get
                m_intMes = 0
                For Each lst As ListItem In chkMes.Items
                    If lst.Selected Then m_intMes = CInt(m_intMes) + CInt(lst.Value)
                Next
                Return m_intMes
            End Get
            Set(ByVal Value As Integer)
                m_intMes = Value
                For Each lst As ListItem In chkMes.Items
                    lst.Selected = (lst.Value And CInt(m_intMes))
                Next
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

        Public Overridable Property SemanaMes() As Integer
            Get
                m_intSemanaMes = 0
                For Each lst As ListItem In chkSemanaMes.Items
                    If lst.Selected Then m_intSemanaMes = CInt(m_intSemanaMes) + CInt(lst.Value)
                Next
                Return m_intSemanaMes
            End Get
            Set(ByVal Value As Integer)
                m_intSemanaMes = Value
                For Each lst As ListItem In chkSemanaMes.Items
                    lst.Selected = (lst.Value And CInt(m_intSemanaMes))
                Next
            End Set
        End Property

        Public Property showSemanaMes() As Boolean
            Get
                Return pnlSemanaMes.Visible = True
            End Get
            Set(ByVal value As Boolean)
                pnlSemanaMes.Visible = value
            End Set
        End Property

        Protected Sub CreateItens()

            Dim iTemp As Integer, iValue As Integer

            chkDia.Items.Clear()
            chkMes.Items.Clear()
            chkDiaSemana.Items.Clear()

            'VERIFICANDO DIA
            For iTemp = 0 To 30
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intDia))
                lst.Text = iTemp + 1
                lst.Value = iValue
                chkDia.Items.Add(lst)
            Next

            'VERIFICANDO MÊS
            For iTemp = 0 To 11
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intMes))
                lst.Text = MonthName(iTemp + 1)
                lst.Value = iValue
                chkMes.Items.Add(lst)
            Next

            'VERIFICANDO DIA DA SEMANA
            For iTemp = 0 To 6
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intDiaSemana))
                lst.Text = WeekdayName(iTemp + 1)
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
