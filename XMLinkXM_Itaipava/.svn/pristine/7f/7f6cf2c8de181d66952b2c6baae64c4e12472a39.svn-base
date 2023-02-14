
Partial Class Relatorios_RelatoriosLog
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If User.IDEmpresa = 0 Then

                Dim clsReg As New Classes.clsRegional
                cboRegional.DataSource = clsReg.RegionaisUsuario
                cboRegional.DataBind()
                cboRegional.Items.Insert(0, New ListItem("TODAS", 0))

                divRegional.Visible = True

            Else

                cboEmpresa.Items.Clear()
                cboEmpresa.Items.Add(New ListItem("Atual", User.IDEmpresa))

                divEmpresa.Visible = False
                divRegional.Visible = False

            End If

            divStatus.Visible = False

            Dim clsVei As New Classes.clsVeiculo
            cboVeiculo.DataSource = clsVei.Listar()
            cboVeiculo.DataBind()
            cboVeiculo.Items.Insert(0, New ListItem("TODOS", ""))
            clsVei = Nothing

            txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")
            btnImprimir.Visible = False

        End If

    End Sub

    Protected Sub btnExibir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExibir.ServerClick

        frmRelatorio.Attributes("src") = GetUrl(0)
        ltImprimir.Text = ""
        btnImprimir.Visible = True

    End Sub

    Private Function GetUrl(Optional ByVal vPrint As Integer = 0) As String

        Return cboRelatorio.SelectedValue() & "_det.aspx?" & _
                            "&di=" & txtDataInicial.Text & _
                            "&df=" & txtDataFinal.Text & _
                            "&em=" & cboEmpresa.SelectedValue & _
                            "&tx=" & cboRelatorio.SelectedItem.Text & _
                            "&dt=" & Now().ToString("ddMMyyyyhhmmss") & _
                            "&st=" & cboStatus.SelectedItem.Value & _
                            "&pl=" & cboVeiculo.SelectedItem.Value & _
                            "&pr=" & vPrint

    End Function

    Protected Sub btnImprimir_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ltImprimir.Text = "<script type='text/javascript'>var wn = window.open('" & GetUrl(1) & "', 'ImprimirRelatorio', 'height=600, width=800, resizable=1, toolbars=1, scrollbars=1');</script>"
    End Sub

    Protected Sub cboRegional_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegional.SelectedIndexChanged

        If VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then

            If cboRegional.SelectedItem.Value > 0 Then

                cboEmpresa.Items.Clear()

                Dim cls As New Classes.clsEmpresa
                cboEmpresa.DataSource = cls.ListarAutorizadas(cboRegional.SelectedItem.Value)
                cboEmpresa.DataBind()
                cboEmpresa.Items.Insert(0, New ListItem("TODAS", 0))
                setComboValue(cboEmpresa, User.IDEmpresa)

                If cboEmpresa.Items.Count = 1 Then
                    divEmpresa.Visible = False
                Else
                    divEmpresa.Visible = True
                End If



            Else

                cboEmpresa.Items.Clear()
                divEmpresa.Visible = False

            End If

        Else

            cboEmpresa.Items.Clear()
            cboEmpresa.Items.Add(New ListItem("Atual", User.IDEmpresa))

            divEmpresa.Visible = False

        End If

    End Sub

    Protected Sub cboRelatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRelatorio.SelectedIndexChanged

        If cboRelatorio.SelectedItem.Value = "performancelog" Then

            divStatus.Visible = False

        Else

            divStatus.Visible = True

        End If

    End Sub

End Class
