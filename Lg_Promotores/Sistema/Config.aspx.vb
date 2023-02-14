
Imports Classes


Partial Public Class Sistema_Config
    Inherits XMWebPage
    Dim cls As clsConfig


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsConfig()
        If Not Page.IsPostBack Then
            btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
            Inflate()
        End If
    End Sub

    Protected Sub Inflate()
        txtPerformance.Text = cls.Performance
    End Sub

    Protected Sub Deflate()
        cls.Performance = txtPerformance.Text
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Deflate()
        If cls.isValid Then
            cls.Update()
            Inflate()
            MostraGravado("~/Sistema/Config.aspx")
        End If
        lstErros.DataSource = cls.BrokenRules
        lstErros.DataBind()
    End Sub


End Class



