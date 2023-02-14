
Partial Class home_calendario
    Inherits XMProtectedPage

    Protected m_col As Dictionary(Of String, Integer)
    Protected cls As New clsAgenda


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            SelectedDate = Now()

            BindMeses()
            BindCalendar()
        Else
            BindData()
        End If

    End Sub

    Public Property SelectedDate() As Date
        Get
            Return ViewState("SelectedDate")
        End Get
        Set(ByVal value As Date)
            ViewState("SelectedDate") = value
        End Set
    End Property

    Protected Sub BindMeses()
        BindData()
        Dim meses As New List(Of String)
        For i As Integer = 1 To 12
            meses.Add("01/" & Right("00" & i, 2) & "/" & SelectedDate.Year)
        Next
        lstMeses.SelectedIndex = CDate(SelectedDate).Month - 1
        lstMeses.DataSource = meses
        lstMeses.DataBind()
    End Sub

    Protected Sub BindData()
        m_col = New Dictionary(Of String, Integer)
        Dim dr As IDataReader = cls.GetAgendamentoDias(SelectedDate.AddMonths(-1))
        Do While dr.Read
            m_col.Add(dr.GetDateTime(0).ToShortDateString, dr.GetInt32(1))
        Loop
        dr.Close()

        dr = cls.GetAgendamentoDias(SelectedDate)
        Do While dr.Read
            m_col.Add(dr.GetDateTime(0).ToShortDateString, dr.GetInt32(1))
        Loop
        dr.Close()

        dr = cls.GetAgendamentoDias(SelectedDate.AddMonths(1))
        Do While dr.Read
            m_col.Add(dr.GetDateTime(0).ToShortDateString, dr.GetInt32(1))
        Loop
        dr.Close()

    End Sub

    Protected Sub BindCalendar()

        calCalendarioMesAnterior.VisibleDate = SelectedDate.AddMonths(-1)
        calCalendarioMesAtual.VisibleDate = SelectedDate
        calCalendarioMesProximo.VisibleDate = SelectedDate.AddMonths(+1)

        grdAgendamentos.DataSource = cls.GetAgendamentoDia(SelectedDate)
        grdAgendamentos.DataBind()
        grdAgendamentos.Visible = grdAgendamentos.Items.Count > 0
        ltrSemAgendamento.Visible = Not grdAgendamentos.Visible

        ltrDia.Text = SelectedDate.ToLongDateString
    End Sub

    Protected Sub calCalendario_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs)
        If e.Day.Date.Month <> CType(sender, Calendar).VisibleDate.Month Then
            e.Cell.Text = ""
        Else
            If e.Day.Date.ToShortDateString() = SelectedDate.ToShortDateString() Then
                e.Cell.Font.Bold = True
                'e.Cell.BackColor = Drawing.Color.Goldenrod
                e.Cell.BackColor = Drawing.Color.GhostWhite
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F3F3F3")
                e.Cell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E05206")
            Else
                e.Cell.ForeColor = Drawing.Color.Black
            End If
            If m_col.ContainsKey(e.Day.Date.ToShortDateString) Then
                If e.Day.Date.ToShortDateString = SelectedDate.ToShortDateString Then
                    e.Cell.BackColor = Drawing.Color.Gray
                Else
                    e.Cell.BackColor = Drawing.Color.Gainsboro
                End If

            End If
        End If
    End Sub

    Protected Sub calCalendario_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not sender.Equals(calCalendarioMesAnterior) Then
            calCalendarioMesAnterior.SelectedDates.Clear()
        ElseIf Not sender.Equals(calCalendarioMesAtual) Then
            calCalendarioMesAtual.SelectedDates.Clear()
        ElseIf Not sender.Equals(calCalendarioMesProximo) Then
            calCalendarioMesProximo.SelectedDates.Clear()
        End If

        SelectedDate = sender.SelectedDate
        BindCalendar()
        BindMeses()
    End Sub

    Protected Sub lstMeses_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles lstMeses.ItemCommand
        If e.CommandName = "SelectMonth" Then
            SelectedDate = CDate(e.CommandArgument)
            BindMeses()
            BindCalendar()
        ElseIf e.CommandName = "ChangeYear" Then
            SelectedDate = SelectedDate.AddYears(e.CommandArgument)
            BindMeses()
            BindCalendar()
        End If

    End Sub

    Protected Sub lstMeses_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles lstMeses.ItemCreated
        If e.Item.ItemType = ListItemType.Header Then
            Dim lnk As LinkButton = e.Item.FindControl("lnkPrevYear")
            lnk.Visible = SelectedDate.Year > Now.Year
            lnk = e.Item.FindControl("lnkNextYear")
            lnk.Visible = SelectedDate.Year < (Now.Year + 2)
        End If
    End Sub
End Class
