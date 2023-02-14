
Partial Class configuracoes_contingencia
    Inherits XMProtectedPage
    Protected cls As clsConfig

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsConfig()
        If Not IsPostBack Then
            inflate()
        End If

    End Sub

    Private Sub inflate()

        With btnNormal
            .Enabled = cls.ModoContingencia
            .Attributes.Add("onmouseover", "MM_swapImage('btnNormal','','" & ResolveUrl("~/images/buttons/bt_modonormal_over.png") & "',1)")
            If .Enabled Then
                .ImageUrl = ResolveUrl("~/images/buttons/bt_modonormal.png")
            Else
                .ImageUrl = ResolveUrl("~/images/buttons/bt_modonormal_over.png")
            End If
            lblContingencia.Visible = .Enabled
        End With

        With btnContingencia
            .Attributes.Add("onmouseover", "MM_swapImage('btnContingencia','','" & ResolveUrl("~/images/buttons/bt_contingencia_over.png") & "',1)")
            .Enabled = Not btnNormal.Enabled
            If .Enabled Then
                .ImageUrl = ResolveUrl("~/images/buttons/bt_contingencia.png")
            Else
                .ImageUrl = ResolveUrl("~/images/buttons/bt_contingencia_over.png")
            End If
        End With

        lblNormal.Visible = Not lblContingencia.Visible

    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default2.aspx")
    End Sub

    Private Sub btnNormal_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNormal.Click
        cls.ModoContingencia = False
        inflate()
    End Sub

    Private Sub btnContingencia_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnContingencia.Click
        cls.ModoContingencia = True
        inflate()
    End Sub

End Class
