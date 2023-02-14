
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


    Protected Sub btnAnexarFoto_Click(sender As Object, e As System.EventArgs) Handles btnAnexarFoto.Click

        Dim filename As String = flImgOS.FileName
        ViewState("FileName") = flImgOS.FileName
        'Dim NameImg As String = imgOS.ImageUrl.Substring(imgOS.ImageUrl.LastIndexOf("/") + 1)

        If flImgOS.HasFile Then
            Dim filenameGuid As Guid = Guid.NewGuid
            Dim extension As String = flImgOS.FileName.Substring(flImgOS.FileName.LastIndexOf(".") + 1)

            If Not XMSistemas.XMVirtualFile.VirtualFile.FileExists(ConfigurationManager.AppSettings("DirFotosOS") & ViewState("FileName")) Then

                Dim xm As New XMSistemas.XMVirtualFile.XMFileStream(ConfigurationManager.AppSettings("DirFotosOS") & ViewState("FileName"), IO.FileMode.CreateNew)

                xm.Write(flImgOS.PostedFile.InputStream)
                xm.Close()

                imgOS.ImageUrl = "../thumbnail.ashx?width=150&filename=~/images/FotosOS/" & ViewState("FileName")
                'imgOS.ImageUrl = "../thumbnail.ashx?width=150&filename=~/images/FotosOS/" & ViewState("FileName") & "." & extension

                'cls.NovaFoto(ViewState(VW_IDPRODUTO), ViewState("FileName"), extension, "")

                'BindFotos()

            End If

        End If

        'Protected Sub BindFoto()
        '    If UsaFotos Then
        '        pnlFoto.Visible = True

        '        Dim foto As New clsProdutoFoto
        '        Dim dr As System.Data.IDataReader = foto.Listar(ViewState(VW_IDPRODUTO), DataClass.enReturnType.DataReader)

        '        If dr.Read Then
        '            lnkFoto.NavigateUrl = "produtofoto.aspx?idproduto=" & ViewState(VW_IDPRODUTO) & "&idprodutofoto=" & dr.GetGuid(dr.GetOrdinal("idprodutofoto")).ToString
        '            imgProduto.ImageUrl = "../thumbnail.ashx?width=150&filename=~/images/FotosOS/" & dr.GetString(dr.GetOrdinal("Nome"))
        '        End If
        '    Else
        '        pnlFoto.Visible = False
        '    End If
        'End Sub



    End Sub


    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviar.Click
        clsOs.EnviarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, os_editor1.Observacao, os_editor1.TempoLimite, os_editor1.IDPrioridade, ViewState("FileName"))
        Response.Redirect("default.aspx")
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click
        clsOs.GuardarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, os_editor1.Observacao, os_editor1.TempoLimite, os_editor1.IDPrioridade)
        Response.Redirect("default.aspx")
    End Sub


    Private Sub btnAgendarOS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgendarOS.Click
        If cboTipoAgendamento.SelectedValue = "0" Then
            clsOs.AgendarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, os_editor1.Observacao, os_editor1.TempoLimite, CDate(calDataEnvio.SelectedDate.ToString("yyyy-MM-dd") & " " & txtHoraEnvio.Text), os_editor1.IDPrioridade)
        Else
            clsOs.AgendarOS(os_editor1.Cliente, os_editor1.Endereco, os_editor1.Referencia, os_editor1.IDDestinatario, os_editor1.Observacao, os_editor1.TempoLimite, txtNome.Text, Agenda1.Dia, Agenda1.Mes, Agenda1.DiaSemana, Agenda1.TipoFrequencia, Agenda1.HoraExecucao, Agenda1.HoraFinal, Agenda1.Intervalo, Agenda1.DataInicio, Agenda1.DataFinal, os_editor1.IDPrioridade)
        End If
        Response.Redirect("default.aspx")
    End Sub

End Class
