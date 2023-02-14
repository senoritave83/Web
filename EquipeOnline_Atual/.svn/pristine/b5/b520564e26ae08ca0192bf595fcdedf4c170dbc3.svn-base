
Partial Class configuracoes_ConfigGerais
    Inherits XMWebPage
    Protected cls As clsConfig

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsConfig()
        If Not IsPostBack Then

            If Not IsAdmin() Then Response.Redirect("../Default.aspx")

            inflate()

        End If

    End Sub

    Private Sub inflate()

        setComboValue(radCopiarEndereco, cls.CopiarEnderecoOrigemDestino)
        setComboValue(radMostrarOrigemDestino, IIf(cls.OrigemDestino = True, 1, 0))

    End Sub

    Private Sub deflate()

        cls.CopiarEnderecoOrigemDestino = getComboValues(radCopiarEndereco)
        cls.OrigemDestino = getComboValues(radMostrarOrigemDestino)

    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default2.aspx")
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click

        deflate()
        cls.Update()

    End Sub

End Class
