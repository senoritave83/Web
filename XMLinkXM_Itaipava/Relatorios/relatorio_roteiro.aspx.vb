
Partial Class Relatorios_relatorio_roteiro
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If User.IDEmpresa = 0 Then
                If VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    Dim cls As New Classes.clsEmpresa
                    cboEmpresa.DataSource = cls.ListarAutorizadas()
                    cboEmpresa.DataBind()
                    cboEmpresa.Items.Insert(0, New ListItem("TODAS", 0))
                    setComboValue(cboEmpresa, User.IDEmpresa)
                    divEmpresa.Visible = True
                Else
                    cboEmpresa.Items.Clear()
                    cboEmpresa.Items.Add(New ListItem("Atual", User.IDEmpresa))
                    divEmpresa.Visible = False
                End If
            Else
                cboEmpresa.Items.Clear()
                cboEmpresa.Items.Add(New ListItem("Atual", User.IDEmpresa))
                divEmpresa.Visible = False
            End If

            Dim ven As New Classes.clsVendedor
            cboVendedor.DataSource = ven.Listar()
            cboVendedor.DataBind()
            cboVendedor.Items.Insert(0, New ListItem("Selecione...", 0))
            ven = Nothing

            txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")
            btnExportar.Visible = False
            btnImprimir.Visible = False
        Else
            frmRelatorio.Attributes.Add("src", GetUrl())
            btnExportar.Visible = True
            btnImprimir.Visible = True
        End If
    End Sub

    Protected Sub btnExibir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExibir.ServerClick
        frmRelatorio.Attributes.Add("src", GetUrl())
        btnExportar.Visible = True
        btnImprimir.Visible = True
    End Sub

    Private Function GetUrl(Optional ByVal vPrint As Integer = 0) As String
        Return "relatorio_roteiro_det.aspx?" & _
                "&di=" & txtDataInicial.Text & _
                "&df=" & txtDataFinal.Text & _
                "&em=" & cboEmpresa.SelectedValue & _
                "&ven=" & cboVendedor.SelectedValue & _
                "&dt=" & Now().ToString("ddMMyyyyhhmmss") & _
                "&tx=" & Server.UrlEncode("Relatório de roteiro") & _
                "&pr=" & vPrint
    End Function

    Protected Sub btnExportar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        ClientScript.RegisterClientScriptBlock(Me.GetType, "imprimir", "<script type='text/javascript'>var wn = window.open('" & GetUrl(2) & "', 'ImprimirRelatorio', 'height=600, width=800, resizable=1, toolbars=1, scrollbars=1');</script>")
    End Sub


    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ClientScript.RegisterClientScriptBlock(Me.GetType, "imprimir", "<script type='text/javascript'>var wn = window.open('" & GetUrl(1) & "', 'ImprimirRelatorio', 'height=600, width=800, resizable=1, toolbars=1, scrollbars=1');</script>")
    End Sub
End Class
