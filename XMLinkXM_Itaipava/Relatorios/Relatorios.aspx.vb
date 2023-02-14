
Partial Class Relatorios_Relatorios
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim vIDEmpresa As Integer = User.IDEmpresa
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

            txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")
            hidPage.Value = ""

            Dim sta As New Classes.clsStatus
            cboStatus.DataSource = sta.Listar()
            cboStatus.DataBind()
            cboStatus.Items.Insert(0, New ListItem("TODOS", 0))
            sta = Nothing

            Dim stavisita As New Classes.clsVisita
            cboStatusVisita.DataSource = stavisita.ListarStatusVisita()
            cboStatusVisita.DataBind()
            cboStatusVisita.Items.Insert(0, New ListItem("TODOS", 0))
            stavisita = Nothing

            CarregaGerenteVendas()
            CarregaSupervisor(0)
            CarregaVendedor(0)


        Else
            Dim vUrl As String = cboRelatorio.SelectedValue() & "_det.aspx?" & _
                                "&di=" & txtDataInicial.Text & _
                                "&df=" & txtDataFinal.Text & _
                                "&tx=" & cboRelatorio.SelectedItem.Text & _
                                "&em=" & cboEmpresa.SelectedValue & _
                                "&sup=" & cboSupervisor.SelectedValue & _
                                "&dt=" & Now().ToString("ddMMyyyyhhmmss") & _
                                "&vend=" & cboVendedor.SelectedValue & _
                                "&map=" & chkMapa.Checked & _
                                "&sta=" & cboStatus.SelectedValue & _
                                "&cli=" & txtNomeCliente.Text & _
                                "&codcli=" & txtIDCliente.Text & _
                                "&stavis=" & cboStatusVisita.SelectedValue

            frmRelatorio.Attributes("src") = ""
            hidPage.Value = vUrl



        End If


    End Sub

    Protected Sub btnExibir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExibir.ServerClick

        Dim vUrl As String = cboRelatorio.SelectedValue() & "_det.aspx?" & _
                            "&di=" & txtDataInicial.Text & _
                            "&df=" & txtDataFinal.Text & _
                            "&em=" & cboEmpresa.SelectedValue & _
                            "&tx=" & cboRelatorio.SelectedItem.Text & _
                            "&sup=" & cboSupervisor.SelectedValue & _
                            "&dt=" & Now().ToString("ddMMyyyyhhmmss") & _
                            "&dias=" & txtDias.Text & _
                            "&vend=" & cboVendedor.SelectedValue & _
                            "&map=" & chkMapa.Checked & _
                            "&sta=" & cboStatus.SelectedValue & _
                            "&cli=" & txtNomeCliente.Text & _
                            "&codcli=" & txtIDCliente.Text & _
                            "&stavis=" & cboStatusVisita.SelectedValue

        frmRelatorio.Attributes("src") = vUrl
        hidPage.Value = vUrl

    End Sub


    'Protected Sub btnImprimir_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

    '    Dim vUrl As String = cboRelatorio.SelectedValue() & "_det.aspx?" & _
    '                        "&di=" & txtDataInicial.Text & _
    '                        "&df=" & txtDataFinal.Text & _
    '                        "&em=" & cboEmpresa.SelectedValue & _
    '                        "&tx=" & cboRelatorio.SelectedItem.Text & _
    '                        "&sup=" & cboSupervisor.SelectedValue & _
    '                        "&dt=" & Now().ToString("ddMMyyyyhhmmss") & _
    '                        "&dias=" & txtDias.Text & _
    '                        "&pr=1"

    '    ClientScript.RegisterClientScriptBlock(Me.GetType, "imprimir", "<script type='text/javascript'>;</script>")

    'End Sub

    Protected Sub cboRelatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRelatorio.SelectedIndexChanged

        If cboRelatorio.SelectedValue = "Positivacao" Then

            divDataFinal.Visible = False
            divDataInicial.Visible = False
            lblData.Text = "De"
            divDias.Visible = True
            divEmpresa.Visible = True
            divSupervisor.Visible = True
            frmRelatorio.Attributes("src") = ""
            txtDias.Text = "30"
            divVendedor.Visible = False
            divVendedor.Attributes.Add("Class", "FiltroItem")
            divDataInicial.Attributes.Add("Class", "FiltroItem")
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = False
            divStatus.Visible = False
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        ElseIf cboRelatorio.SelectedValue = "AcompPositivacao" Then

            divDataFinal.Visible = True
            divDataInicial.Visible = True
            lblData.Text = "De"
            divDias.Visible = False
            divEmpresa.Visible = True
            divSupervisor.Visible = True
            frmRelatorio.Attributes("src") = ""
            divGerenteVendas.Visible = True
            divVendedor.Visible = True
            divVendedor.Attributes.Add("Class", "FiltroClearRight")
            divDataInicial.Attributes.Add("Class", "FiltroClearLeft")
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = False
            divStatus.Visible = False
            CarregaVendedor(0, True)
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        ElseIf cboRelatorio.SelectedValue = "performance" Then

            divDataFinal.Visible = True
            divDataInicial.Visible = True
            lblData.Text = "De"
            divDias.Visible = False
            divEmpresa.Visible = True
            divSupervisor.Visible = True
            frmRelatorio.Attributes("src") = ""
            divGerenteVendas.Visible = True
            divVendedor.Visible = False
            divVendedor.Attributes.Add("Class", "FiltroItem")
            divDataInicial.Attributes.Add("Class", "FiltroItem")
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = False
            divStatus.Visible = False
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        ElseIf cboRelatorio.SelectedValue = "Consolidado" Then

            divDataFinal.Visible = True
            divDataInicial.Visible = True
            lblData.Text = "De"
            divDias.Visible = False
            divEmpresa.Visible = True
            divSupervisor.Visible = True
            frmRelatorio.Attributes("src") = ""
            divGerenteVendas.Visible = True
            divVendedor.Visible = False
            divVendedor.Attributes.Add("Class", "FiltroItem")
            divDataInicial.Attributes.Add("Class", "FiltroItem")
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = False
            divStatus.Visible = False
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        ElseIf cboRelatorio.SelectedValue = "Relatorio_Roteiro" Then

            divDataFinal.Visible = False
            divDataInicial.Visible = True
            lblData.Text = "Data"
            divDias.Visible = False
            divEmpresa.Visible = False
            divSupervisor.Visible = False
            frmRelatorio.Attributes("src") = ""
            divGerenteVendas.Visible = False
            divVendedor.Visible = True
            divVendedor.Attributes.Add("Class", "FiltroItem")
            divDataInicial.Attributes.Add("Class", "FiltroItem")
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = True
            divStatus.Visible = False
            CarregaVendedor(0, False)
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        ElseIf cboRelatorio.SelectedValue = "Pedidos" Then

            divGerenteVendas.Visible = True
            divVendedor.Visible = True
            divEmpresa.Visible = False
            divSupervisor.Visible = True
            divDataFinal.Visible = False
            lblData.Text = "Data"
            frmRelatorio.Attributes("src") = ""
            divSupervisor.Visible = True
            divMapa.Visible = False
            divStatus.Visible = True
            divStatus.Attributes.Add("Class", "FiltroClearRight")
            divDataInicial.Attributes.Add("Class", "FiltroClearLeft")
            divDias.Visible = False
            CarregaVendedor(0, True)
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        ElseIf cboRelatorio.SelectedValue = "Historico_Visitas" Then

            divDataFinal.Visible = True
            divDataInicial.Visible = True
            lblData.Text = "De"
            divDias.Visible = False
            divEmpresa.Visible = False
            divSupervisor.Visible = False
            frmRelatorio.Attributes("src") = ""
            divGerenteVendas.Visible = False
            divVendedor.Visible = False
            divVendedor.Attributes.Add("Class", "FiltroItem")
            divDataInicial.Attributes.Add("Class", "FiltroItem")
            divStatus.Visible = False
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = False
            CarregaVendedor(0, False)
            divIDCliente.Visible = True
            divNomeCliente.Visible = True
            divStatusVisita.Visible = True

        Else

            divDataFinal.Visible = True
            divDataInicial.Visible = True
            lblData.Text = "De"
            divDias.Visible = False
            divEmpresa.Visible = True
            divSupervisor.Visible = True
            frmRelatorio.Attributes("src") = ""
            divGerenteVendas.Visible = False
            divVendedor.Visible = False
            divVendedor.Attributes.Add("Class", "FiltroItem")
            divDataInicial.Attributes.Add("Class", "FiltroItem")
            divStatus.Attributes.Add("Class", "FiltroItem")
            divMapa.Visible = False
            divStatus.Visible = False
            divIDCliente.Visible = False
            divNomeCliente.Visible = False
            divStatusVisita.Visible = False

        End If

    End Sub

    Private Sub CarregaGerenteVendas()


        Dim ven As New Classes.clsVendedor
        Dim vIDEmpresa As Integer

        vIDEmpresa = cboEmpresa.SelectedValue
        cboGerenteVendas.DataSource = ven.ListarGerenteVendas(vIDEmpresa)
        cboGerenteVendas.DataBind()
        cboGerenteVendas.Items.Insert(0, New ListItem("TODOS", 0))

        ven = Nothing


    End Sub

    Private Sub CarregaSupervisor(ByVal vIdGerenteVendas As Integer)

        Dim ven As New Classes.clsVendedor

        cboSupervisor.DataSource = ven.ListarSupervisores(vIdGerenteVendas)
        cboSupervisor.DataBind()
        cboSupervisor.Items.Insert(0, New ListItem("TODOS", 0))

        ven = Nothing

    End Sub


    Private Sub CarregaVendedor(ByVal vIdSupervisor As Integer, Optional ByVal vTodos As Boolean = True)

        Dim ven As New Classes.clsVendedor

        cboVendedor.DataSource = ven.ListarVendedoresSup(vIdSupervisor)
        cboVendedor.DataBind()
        If vTodos Then cboVendedor.Items.Insert(0, New ListItem("TODOS", 0))

        ven = Nothing

    End Sub

    Protected Sub cboGerenteVendas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboGerenteVendas.SelectedIndexChanged
        CarregaSupervisor(cboGerenteVendas.SelectedItem.Value)
    End Sub

    Protected Sub cboSupervisor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSupervisor.SelectedIndexChanged
        CarregaVendedor(cboSupervisor.SelectedItem.Value)
    End Sub
End Class
