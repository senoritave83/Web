
Partial Class home_reenviar
    Inherits XMProtectedPage


    Protected cls As clsOrdemServico
    Protected intIDOS As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsOrdemServico()
        If Not IsPostBack Then
            ViewState("CALLER") = CInt("0" & Request("Caller"))
            intIDOS = CLng("0" & Request("IDOS"))
            ViewState("IDOS") = intIDOS
            cls.Load(intIDOS)
            BindCombo()
            Inflate()
        Else
            intIDOS = CLng("0" & ViewState("IDOS"))
            cls.Load(intIDOS)
        End If
    End Sub

    Protected Sub BindCombo()
        Dim rsp As clsResponsaveis
        rsp = New clsResponsaveis()
        cboResponsavel.DataSource = rsp.ListarDestinatariosAtivos
        cboResponsavel.DataBind()
        rsp = Nothing
    End Sub

    Protected Sub Inflate()
        With cls
            lblOS.Text = .NumeroOS
            setComboValue(cboResponsavel, .IDResponsavel)
        End With
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviar.Click
        cls.Reenviar(ViewState("IDOS"), cboResponsavel.SelectedValue)
        Response.Redirect("ordemservico.aspx?idos=" & ViewState("IDOS") & "&")
    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("ordemservico.aspx?idos=" & ViewState("IDOS") & "&")
    End Sub
End Class
