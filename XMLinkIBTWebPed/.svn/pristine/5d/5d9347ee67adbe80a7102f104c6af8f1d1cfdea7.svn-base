Imports Classes

Partial Class pedidos_justificar
    Inherits XMWebPage
    Protected intIDCliente As Integer
    Protected intIDVisita As Integer
    Protected cls As clsAtendimentoCliente


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsAtendimentoCliente()

        If Not Page.IsPostBack Then
            intIDCliente = CInt("0" & Request("idcliente"))
            intIDVisita = CInt("0" & Request("idvisita"))
            ViewState("IDCLIENTE") = intIDCliente
            ViewState("IDVISITA") = intIDVisita
            cls.Load(intIDCliente)

            If Not cls.Finalizado And Not cls.Executado Then
                btnGravar.Enabled = True
            Else
                btnGravar.Enabled = False
            End If

            Dim just As New clsJustificativa
            lstJustificativa.DataSource = just.Listar
            lstJustificativa.DataBind()
            just = Nothing

        Else
            intIDCliente = ViewState("IDCLIENTE")
            intIDVisita = ViewState("IDVISITA")

            cls.Load(intIDCliente)
        End If
    End Sub


    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        cls.Justificar(lstJustificativa.SelectedValue)
        pnlJustificar.Visible = False
        pnlMensagem.Visible = True

    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Response.Redirect("cliente.aspx?idcliente=" & intIDCliente)
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("cliente.aspx?idcliente=" & intIDCliente)
    End Sub
End Class
