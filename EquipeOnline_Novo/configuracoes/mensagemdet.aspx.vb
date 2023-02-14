Imports System.Data.SqlClient

Partial Class configuracoes_mensagemdet
    Inherits XMProtectedPage

    Protected cls As clsMensagem
    Protected intIDMensagem As Integer


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsMensagem()
        If Not IsPostBack Then
            intIDMensagem = CLng("0" & Request("IDMensagem"))
            ViewState("IDMensagem") = intIDMensagem
            cls.Load(intIDMensagem)
            Inflate()
        Else
            intIDMensagem = CLng("0" & ViewState("IDMensagem"))
            cls.Load(intIDMensagem)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtMensagem.Text = .Mensagem
            txtNome.Text = .Nome
        End With
        If intIDMensagem = 0 Then
            btnExcluir.Enabled = False
            btnSalvar.Enabled = True
            btnVoltar.Enabled = True
            btnNovo.Enabled = False
        Else
            btnExcluir.Enabled = True
            btnSalvar.Enabled = True
            btnVoltar.Enabled = True
            btnNovo.Enabled = True
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Mensagem = txtMensagem.Text
        End With
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        cls.Delete()
        Response.Redirect("Mensagens.aspx")
    End Sub

    Private Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Response.Redirect("Mensagemdet.aspx?idMensagem=0")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        Deflate()
        Try
            cls.Update()
            MostraGravado("Mensagens.aspx")
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
        Response.Redirect("Mensagens.aspx")
    End Sub


End Class
