
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class LOG
        Inherits XMWebPage
        Dim cls As clsLOG

        
        '     Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '         cls = New clsLOG()
        '         If Not Page.IsPostBack Then
        '             subAddConfirm(btnApagar, "Deseja realmente apagar esta log?")
        '             cls.Load()
        '	btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
        '	btnNovo.Disabled = Not btnGravar.Enabled
        '	btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

        '	Inflate()
        '         Else
        '             cls.Load()
        '       End If
        '     End Sub

        '     Protected Sub Inflate()
        '         txtUser.Text = cls.Usuario
        'txtModulo.Text = cls.Modulo
        'txtSecao.Text = cls.Secao
        'txtAcao.Text = cls.Acao
        'txtData.Text = cls.Data
        '     End Sub

        '     Protected Sub Deflate()
        '         cls.Usuario = txtUser.Text
        'cls.Modulo = txtModulo.Text
        'cls.Secao = txtSecao.Text
        'cls.Acao = txtAcao.Text
        'cls.Data = txtData.Text
        '     End Sub

        'Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        '    Deflate()
        '    If cls.isValid Then
        '        cls.Update()
        '        Inflate()
        '        MostraGravado("~/Cadastros/LOG.aspx)
        '    End If
        '    lstErros.DataSource = cls.BrokenRules
        '    lstErros.DataBind()

        'End Sub

        'Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        '    cls.Delete()
        '    Response.Redirect("LOGs.aspx")
        'End Sub

	
    End Class

End Namespace

