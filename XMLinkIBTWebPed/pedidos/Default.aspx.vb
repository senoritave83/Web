Imports Classes

Partial Class pedidos_Default
    Inherits XMWebPage
    Protected cls As New clsAtendimento

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsAtendimento()
        If Not Page.IsPostBack Then
            cls.Load(User.IDUser)
            Inflate()
            subAddConfirm(btnAdicionarCliente, "Deseja realmente adicionar o cliente selecionado a lista de atendimentos")
            BindClientes()
        End If
    End Sub

    Private Sub Inflate()
        If cls.Vencido Then
            lblMessage.Text = "O atendimento do dia " & cls.Data & " ainda não foi finalizado."
        End If
        lblData.Text = cls.Data
        lblStatus.Text = cls.Status
        btnAdicionarCliente.Enabled = Not cls.Vencido
        btnFinalizarRoteiro.Enabled = cls.Executado And Not cls.Finalizado
    End Sub

    Private Sub BindClientes()
        grdClientesAtendimento.DataSource = cls.ListarClientes()
        grdClientesAtendimento.DataBind()
    End Sub

    Protected Sub btnAdicionarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarCliente.Click
        If Not cls.Vencido And Not cls.Finalizado Then
            Dim cli As New clsCliente
            If cli.LoadByCodigo(txtCliente.Text) Then
                If cls.AdicionarCliente(cli.IDCliente) Then
                    pnlAdicionar.Visible = False
                    pnlProcurar.Visible = True
                    txtCliente.Text = ""
                    Inflate()
                    Response.Redirect("cliente.aspx?idcliente=" & cli.IDCliente)
                End If
                'BindClientes()
            End If
        End If
    End Sub

    Protected Sub btnFinalizarRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizarRoteiro.Click
        If Not cls.Finalizado And cls.Executado Then
            cls.Finalizar()
        End If
    End Sub

    Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        Dim AtendCli As New clsAtendimentoCliente

        If Not cls.Vencido Then
            If Not txtCliente.Text = "" Then
                Dim cli As New clsCliente
                If cli.LoadByCodigo(txtCliente.Text) Then
                    pnlProcurar.Visible = False
                    pnlAdicionar.Visible = True
                    lblCliente.Text = cli.Cliente
                    lblCNPJ.Text = cli.CNPJ
                    lblCodigo.Text = cli.Codigo
                    lblProcurarMensagem.Text = ""
                    subAddConfirm(btnAdicionarCliente, "Deseja realmente adicionar o cliente selecionado a lista de atendimentos")
                    AtendCli.Load(cli.IDCliente)
                    btnAdicionarCliente.Enabled = AtendCli.PermitePedido
                Else
                    lblProcurarMensagem.Text = "Cliente não localizado!"
                    lblCNPJ.Text = ""
                    txtCliente.Text = ""
                End If
            Else
                lblProcurarMensagem.Text = ""
            End If
        End If

    End Sub

    Protected Sub btnCancelarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarCliente.Click
        pnlProcurar.Visible = True
        pnlAdicionar.Visible = False
        txtCliente.Text = ""

    End Sub
End Class
