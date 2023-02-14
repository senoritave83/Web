Imports XMSistemas.Web.Base

Partial Class home_agendamentos
    Inherits XMProtectedPage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            ViewState("Desc") = True
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")
            txtDataInicial.Text = Now.AddDays(-7).ToString("dd/MM/yyyy")
            BindGrid()
        End If

    End Sub



    Protected Sub BindGrid()
        Dim cls As New clsAgenda
        Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, 0, SelectCliente1.Cliente, SelectDestinatario1.Destinatario, txtDataInicial.Text, txtDataFinal.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Paginate1.PageSize)
        Paginate1.DataSource = ret
        grdAgendamentos.DataSource = ret.Data
        Paginate1.DataBind()
        grdAgendamentos.DataBind()
        grdAgendamentos.Visible = grdAgendamentos.Items.Count > 0
        ltrSemAgendamentos.Visible = Not grdAgendamentos.Visible
    End Sub




    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Response.Redirect("agendamento.aspx")
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFiltrar.Click
        BindGrid()
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub
End Class
