
Partial Class home_novaordem
    Inherits XMProtectedPage
    Protected clsOs As clsOrdemServico

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsOs = New clsOrdemServico()
    End Sub



    Private Sub btnAgendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgendar.Click

        plhNova.Visible = False
        plhAgenda.Visible = True
        plhBotoesNova.Visible = False
        plhBotaoAgendar.Visible = True
        calDataEnvio.SelectedDate = Now()
        txtHoraEnvio.Text = Now.ToString("HH:mm")
        Agenda1.CreateItens()

        Dim cfg As New clsConfig
        setComboValue(cboTipoAgendamento, 0)
        cboTipoAgendamento.Visible = Not cfg.OrigemDestino
        cfg = Nothing

    End Sub


    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click
        clsOs.GuardarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, _
                            os_editor1.Observacao, os_editor1.TempoLimite, os_editor1.IDPrioridade, _
                            os_editor1.EnderecoDestino, os_editor1.ReferenciaDestino)
        Response.Redirect("default.aspx")
    End Sub

    Private Sub btnAgendarOS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgendarOs.Click
        If cboTipoAgendamento.SelectedValue = "0" Then
            clsOs.AgendarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, _
                            os_editor1.Observacao, os_editor1.TempoLimite, _
                            CDate(calDataEnvio.SelectedDate.ToString("yyyy-MM-dd") & " " & txtHoraEnvio.Text), _
                            os_editor1.IDPrioridade, os_editor1.EnderecoDestino, os_editor1.ReferenciaDestino)
        Else
            clsOs.AgendarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, _
                            os_editor1.Observacao, os_editor1.TempoLimite, txtNome.Text, Agenda1.Dia, Agenda1.Mes, _
                            Agenda1.DiaSemana, Agenda1.TipoFrequencia, Agenda1.HoraExecucao, Agenda1.HoraFinal, Agenda1.Intervalo, _
                            Agenda1.DataInicio, Agenda1.DataFinal, os_editor1.IDPrioridade)
        End If
        Response.Redirect("default.aspx")
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default.aspx")
    End Sub

    Private Sub btnVoltar_Click2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar2.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub cboTipoAgendamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAgendamento.SelectedIndexChanged
        If cboTipoAgendamento.SelectedIndex = 0 Then
            plhSimples.Visible = True
            plhRecorrente.Visible = False
            tdNome.Visible = False
        Else
            plhSimples.Visible = False
            plhRecorrente.Visible = True
            tdNome.Visible = True
        End If
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviar.Click
        clsOs.EnviarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, _
                            os_editor1.IDDestinatario, os_editor1.Observacao, _
                            os_editor1.TempoLimite, os_editor1.IDPrioridade, _
                            os_editor1.enderecodestino, os_editor1.Referenciadestino)
        Response.Redirect("default.aspx")
    End Sub
End Class
