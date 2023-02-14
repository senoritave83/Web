
Partial Class configuracoes_usuariodet
    Inherits XMProtectedPage
    Protected cls As clsUsuario
    Protected intIDUsuario As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsUsuario()
        If Not Page.IsPostBack Then

            If Not IsAdmin() Then Response.Redirect("../Default.aspx")

            intIDUsuario = CLng("0" & Request("IDUsuario"))
            ViewState("IDUsuario") = intIDUsuario
            cls.Load(intIDUsuario)
            Inflate()
            btnExcluir.Attributes.Add("onClick", "if(confirm('Tem certeza que deseja excluir o operador " & txtNome.Text & "')==false)return false;)")
        Else
            intIDUsuario = CLng("0" & ViewState("IDUsuario"))
            cls.Load(intIDUsuario)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
            chkAdmin.Checked = .Administrador
            txtLogin.Text = .Login
        End With
        If intIDUsuario = 0 Then
            btnNovo.Visible = False
            btnExcluir.Visible = False
            tbDados.Visible = True
            trEditarSenha.Visible = False
        Else
            btnNovo.Visible = True
            btnExcluir.Visible = True
            tbDados.Visible = False
            trEditarSenha.Visible = True
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Administrador = chkAdmin.Checked
            If tbDados.Visible = True Then
                .Login = txtLogin.Text
            End If
        End With
    End Sub



    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        If CheckPermission("Cadastro de Usuarios", "Excluir Usuario") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        cls.Delete()
        Response.Redirect("Usuarios.aspx")
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        If intIDUsuario = 0 And CheckPermission("Cadastro de Usuarios", "Adicionar Usuario") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDUsuario > 0 And CheckPermission("Cadastro de Usuarios", "Alterar Usuario") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDUsuario, txtNome.Text, txtLogin.Text, txtSenha.Text) Then
            ShowMsg("O login escolhido já existe! Favor escolher outro!")
            Exit Sub
        End If
        Deflate()
        Try
            cls.Update()
            If tbDados.Visible = True And txtSenha.Text <> "" Then
                cls.AlteraSenha(txtSenha.Text)
                tbDados.Visible = False
            End If
            MostraGravado("Usuarios.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("Usuarios.aspx")
    End Sub

    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Response.Redirect("Usuariodet.aspx?idUsuario=0")
    End Sub

    Protected Sub btnEditar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.ServerClick
        tbDados.Visible = Not tbDados.Visible
    End Sub
End Class
