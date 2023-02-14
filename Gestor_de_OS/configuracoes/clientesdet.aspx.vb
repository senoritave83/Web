Imports System.Data.SqlClient

Partial Class configuracoes_clientesdet
    Inherits XMProtectedPage
    Protected cls As clsClientes
    Protected intIDCliente As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsClientes()
        If Not IsPostBack Then
            intIDCliente = CInt("0" & Request("IDCliente"))
            ViewState("IDCliente") = intIDCliente
            cls.Load(intIDCliente)
            Inflate()

        Else
            intIDCliente = CLng("0" & ViewState("IDCliente"))
            cls.Load(intIDCliente)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
            txtRazao.Text = .Razao
            txtCNPJ.Text = .CNPJ
            txtEndereco.Text = .Endereco
            txtReferencia.Text = .Referencia
            txtBairro.Text = .Bairro
            txtCidade.Text = .Cidade
            txtCep.Text = .Cep
            txtUF.Text = .UF
            txtContato.Text = .Contato
            txtTelefone.Text = .Telefone
            txtObservacao.Text = .Observacao
        End With
        If intIDCliente = 0 Then
            btnExcluir.Enabled = False
            btnSalvar.Enabled = True
            btnVoltar.Enabled = True
            btnNovo.Enabled = False
            btnNovo.Visible = False
            btnExcluir.Visible = False
        Else
            btnNovo.Visible = True
            btnExcluir.Visible = True
            btnExcluir.Enabled = True
            btnSalvar.Enabled = True
            btnVoltar.Enabled = True
            btnNovo.Enabled = True
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Razao = txtRazao.Text
            .CNPJ = txtCNPJ.Text
            .Endereco = txtEndereco.Text
            .Referencia = txtReferencia.Text
            .Bairro = txtBairro.Text
            .Cidade = txtCidade.Text
            .Cep = txtCep.Text
            .UF = txtUF.Text
            .Contato = txtContato.Text
            .Telefone = txtTelefone.Text
            .Observacao = txtObservacao.Text
        End With
    End Sub

    Private Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Response.Redirect("clientesdet.aspx?idcliente=0")
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        cls.Delete()
        Response.Redirect("clientes.aspx")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        Deflate()
        Try
            cls.Update()
            MostraGravado("clientes.aspx")
        Catch ex As SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("clientes.aspx")
    End Sub


End Class
