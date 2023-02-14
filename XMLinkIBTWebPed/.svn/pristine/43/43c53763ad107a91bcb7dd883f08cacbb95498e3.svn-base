Namespace Controls

    Partial Class VerRoteiro
        Inherits System.Web.UI.UserControl
        Protected m_intDia As Integer = 0
        Protected m_intMes As Integer = 0
        Protected m_intDiaSemana As Integer = 0
        Protected m_strDias As String = ""
        Protected m_strMeses As String = ""
        Protected m_strDiasSemana As String = ""

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

        Public Overridable Property Dia() As Integer
            Get
                Return m_intDia
            End Get
            Set(ByVal Value As Integer)
                m_intDia = Value
                If Value = 0 Then
                    m_strDias = "Todos"
                Else
                    Dim m_colTemp As New Collections.Generic.List(Of String)
                    For iTemp As Integer = 0 To 30
                        If ((2 ^ iTemp) And CInt(m_intDia)) Then
                            m_colTemp.Add((iTemp + 1))
                        End If
                    Next
                    m_strDias = MontaLista(m_colTemp)
                End If
                lblDias.Text = m_strDias
            End Set
        End Property

        Public Overridable Property Mes() As Integer
            Get
                Return m_intMes
            End Get
            Set(ByVal Value As Integer)
                m_intMes = Value
                If Value = 0 Then
                    m_strMeses = "Todos"
                Else
                    Dim m_colTemp As New Collections.Generic.List(Of String)
                    For iTemp As Integer = 0 To 30
                        If ((2 ^ iTemp) And CInt(m_intMes)) Then
                            m_colTemp.Add(MonthName(iTemp + 1))
                        End If
                    Next
                    m_strMeses = MontaLista(m_colTemp)
                End If
                lblMeses.Text = m_strMeses
            End Set
        End Property

        Public Overridable Property DiaSemana() As Integer
            Get
                Return m_intDiaSemana
            End Get
            Set(ByVal Value As Integer)
                m_intDiaSemana = Value
                If Value = 0 Then
                    m_strDiasSemana = "Todos"
                Else
                    m_strDiasSemana = ""
                    Dim m_colTemp As New Collections.Generic.List(Of String)
                    For iTemp As Integer = 0 To 30
                        If ((2 ^ iTemp) And CInt(m_intDiaSemana)) Then
                            m_colTemp.Add(WeekdayName(iTemp + 1))
                        End If
                    Next
                    m_strDiasSemana = MontaLista(m_colTemp)
                End If
                lblDiasSemana.Text = m_strDiasSemana
            End Set
        End Property

        Protected Function MontaLista(ByVal col As Collections.Generic.List(Of String)) As String
            Dim strRet As String = ""
            For i As Integer = 0 To col.Count - 1
                If i > 0 Then
                    If i < col.Count - 1 Then
                        strRet &= ", "
                    Else
                        strRet &= " e "
                    End If
                End If
                strRet &= col.Item(i)
            Next
            Return strRet
        End Function

        'Protected Sub CreateItens()

        '    Dim iTemp As Integer, iValue As Integer

        '    chkDia.Items.Clear()
        '    chkMes.Items.Clear()
        '    chkDiaSemana.Items.Clear()

        '    'VERIFICANDO DIA
        '    For iTemp = 0 To 30
        '        Dim lst As New ListItem()
        '        iValue = 2 ^ iTemp
        '        lst.Selected = (iValue And CInt(m_intDia))
        '        lst.Text = iTemp + 1
        '        lst.Value = iValue
        '        chkDia.Items.Add(lst)
        '    Next

        '    'VERIFICANDO MÊS
        '    For iTemp = 0 To 11
        '        Dim lst As New ListItem()
        '        iValue = 2 ^ iTemp
        '        lst.Selected = (iValue And CInt(m_intMes))
        '        lst.Text = MonthName(iTemp + 1)
        '        lst.Value = iValue
        '        chkMes.Items.Add(lst)
        '    Next

        '    'VERIFICANDO DIA DA SEMANA
        '    For iTemp = 0 To 6
        '        Dim lst As New ListItem()
        '        iValue = 2 ^ iTemp
        '        lst.Selected = (iValue And CInt(m_intDiaSemana))
        '        lst.Text = WeekdayName(iTemp + 1)
        '        lst.Value = iValue
        '        chkDiaSemana.Items.Add(lst)
        '    Next
        'End Sub

        'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    If Not Page.IsPostBack Then
        '        CreateItens()
        '    End If
        'End Sub


    End Class


End Namespace
