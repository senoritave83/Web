Imports Classes

Partial Class sistema_Configuracoes

    Inherits XMWebPage
    Protected Const SECAO As String = "Configurações"
    Dim cls As clsConfiguracoes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cls = New clsConfiguracoes()

        If Not Page.IsPostBack Then

            cls.Load(Me.User.IDEmpresa)
            btnGravar.Enabled = VerificaPermissao(SECAO, ACAO_EDITAR)
            Inflate()

        Else
            cls.Load(Me.User.IDEmpresa)
        End If

    End Sub

    Protected Sub Inflate()
        chkAceitaSomenteCondicoesCadastradas.Checked = cls.AceitaSomenteCondicoesCadastradas
        chkAguardaAprovacaoCondicaoCliente.Checked = cls.AguardaAprovacaoCondicaoCliente
        chkAguardaAprovacaoClienteDuplicata.Checked = cls.AguardaAprovacaoClienteDuplicataVencida
        chkPermiteAcumuloRoteiros.Checked = cls.RevendaPermiteAcumuloRoteiros
        chkAguardaAprovacaoPedidosBonificados.Checked = cls.AguardaAprovacaoPedidosBonificados
    End Sub

    Protected Sub Deflate()
        cls.AceitaSomenteCondicoesCadastradas = chkAceitaSomenteCondicoesCadastradas.Checked
        cls.AguardaAprovacaoCondicaoCliente = chkAguardaAprovacaoCondicaoCliente.Checked
        cls.AguardaAprovacaoClienteDuplicataVencida = chkAguardaAprovacaoClienteDuplicata.Checked
        cls.RevendaPermiteAcumuloRoteiros = chkPermiteAcumuloRoteiros.Checked
        cls.AguardaAprovacaoPedidosBonificados = chkAguardaAprovacaoPedidosBonificados.Checked
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        If VerificaPermissao(SECAO, ACAO_EDITAR) = False Then
            Exit Sub
        End If

        Deflate()
        cls.Update()
        Inflate()
        MostraGravado("~/Cadastros/configuracoes.aspx")

    End Sub

End Class

