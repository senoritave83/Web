
Partial Class home_agendamento
    Inherits XMProtectedPage
    Protected cls As clsAgenda
    Protected Const VW_IDAGENDAMENTO As String = "IDAgendamento"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsAgenda
        If Not Page.IsPostBack Then
            Agenda1.CreateItens()
            ViewState(VW_IDAGENDAMENTO) = CInt("0" & Request("IDAgendamento"))
            cls.Load(ViewState(VW_IDAGENDAMENTO))
        Else
            cls.Load(ViewState(VW_IDAGENDAMENTO))
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            If Not cls.IsNew Then
                Inflate()
            End If
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            Agenda1.DataInicio = .DataInicio
            Agenda1.DataFinal = .DataFinal
            Agenda1.TipoFrequencia = .FrequenciaTipo
            Agenda1.HoraExecucao = .HoraInicio
            Agenda1.HoraFinal = .HoraFinal
            Agenda1.Intervalo = .Intervalo
            os_editor1.TempoLimite = .TempoLimite
            chkAtivo.Checked = .Ativo
            Agenda1.Dia = .Dia
            Agenda1.Mes = .Mes
            Agenda1.DiaSemana = .DiaSemana
            os_editor1.Cliente = .Cliente
            os_editor1.Endereco = .Endereco
            os_editor1.IDDestinatario = .IDDestinatario
            os_editor1.Observacao = .Observacao
            os_editor1.Referencia = .Referencia
            txtAgendamento.Text = .Agendamento
            os_editor1.IDPrioridade = .IDPrioridade
        End With

    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        With cls
            .DataInicio = Agenda1.DataInicio
            .DataFinal = Agenda1.DataFinal
            .FrequenciaTipo = Agenda1.TipoFrequencia
            .HoraInicio = Agenda1.HoraExecucao
            .HoraFinal = Agenda1.HoraFinal
            .Intervalo = Agenda1.Intervalo
            .Dia = Agenda1.Dia
            .Mes = Agenda1.Mes
            .DiaSemana = Agenda1.DiaSemana
            .Cliente = os_editor1.Cliente
            .Endereco = os_editor1.Endereco
            .IDDestinatario = os_editor1.IDDestinatario
            .Observacao = os_editor1.Observacao
            .Referencia = os_editor1.Referencia
            .Agendamento = txtAgendamento.Text
            .TempoLimite = os_editor1.TempoLimite
            .Ativo = chkAtivo.Checked
            .IDPrioridade = os_editor1.IDPrioridade
            .Update()
        End With
        MostraGravado("agendamentos.aspx")
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        cls.Delete()
        Response.Redirect("agendamentos.aspx")
    End Sub
End Class
