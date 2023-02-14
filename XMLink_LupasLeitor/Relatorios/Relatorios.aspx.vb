Imports Classes

Partial Class Relatorios_Relatorios
    Inherits XMWebPage

    Dim rep As clsRelatorio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If VerificaPermissao("Relatórios", "Pedidos por Status") Then
                cboRelatorio.Items.Add(New ListItem("Pedidos por Status", "status"))
            End If
            ' ****** Relatório obsoleto (mediante solicitação IBT em 31/01/2012)
            'If VerificaPermissao("Relatórios", "Vendas por Vendedor") Then
            '    cboRelatorio.Items.Add(New ListItem("Vendas por Vendedor", "vendedor"))
            'End If
            ' ******
            If VerificaPermissao("Relatórios", "Velocidade de Vendas") Then
                cboRelatorio.Items.Add(New ListItem("Velocidade de Vendas", "produtos"))
            End If
            cboRelatorio.Items.Add(New ListItem("Fechamento", "Fechamento"))
            cboRelatorio.Items.Add(New ListItem("Tabela de Preços", "Precos"))
            If VerificaPermissao("Relatórios", "Consignação de Clientes") Then
                cboRelatorio.Items.Add(New ListItem("Consignação de Clientes", "consignado"))
            End If
            If VerificaPermissao("Relatórios", "Estoque do Vendedor") Then
                cboRelatorio.Items.Add(New ListItem("Estoque do Vendedor", "estoque_vendedor"))
            End If
            If VerificaPermissao("Relatórios", "Clientes Não Visitados") Then
                cboRelatorio.Items.Add(New ListItem("Clientes Não Visitados", "visitas_positivacao"))
            End If
            If VerificaPermissao("Relatórios", "Retorno e Reposição") Then
                cboRelatorio.Items.Add(New ListItem("Retorno e Reposição", "retorno_Reposicao"))
            End If

            rep = New clsRelatorio
            ListarVendedores()
            ListarClientes()

            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

            'cboRelatorio.Attributes.Add("onChange", "btnExibir.disabled=true;")

        End If

    End Sub

    Protected Sub cboRelatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRelatorio.SelectedIndexChanged
        If cboRelatorio.SelectedValue = "Precos" Then
            FiltroItem_Calendario.Visible = False
            divVendedores.Visible = False
            divClientes.Visible = False
            lblData.Text = "De"
            divAcao.Visible = False
            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
        ElseIf cboRelatorio.SelectedValue = "Fechamento" Then
            divVendedores.Visible = True
            lstVendedores.AutoPostBack = False
            FiltroItem_Calendario.Visible = True
            divClientes.Visible = False
            lblData.Text = "De"
            divAcao.Visible = False
            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
        ElseIf cboRelatorio.SelectedValue = "consignado" Then
            FiltroItem_Calendario.Visible = False
            divVendedores.Visible = True
            lstVendedores.AutoPostBack = True
            divClientes.Visible = True
            lblData.Text = "De"
            divAcao.Visible = False
            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
        ElseIf cboRelatorio.SelectedValue = "estoque_vendedor" Then
            FiltroItem_Calendario.Visible = False
            divVendedores.Visible = True
            lstVendedores.AutoPostBack = False
            divClientes.Visible = False
            lblData.Text = "De"
            divAcao.Visible = False
            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
        ElseIf cboRelatorio.SelectedValue = "visitas_positivacao" Then
            FiltroItem_Calendario.Visible = False
            divVendedores.Visible = True
            lstVendedores.AutoPostBack = False
            divClientes.Visible = False
            lblData.Text = "Desde"
            divAcao.Visible = False
            txtDataInicial.Text = Now.AddDays(-31).ToString("dd/MM/yyyy")
        ElseIf cboRelatorio.SelectedValue = "retorno_Reposicao" Then
            FiltroItem_Calendario.Visible = True
            divVendedores.Visible = True
            lstVendedores.AutoPostBack = False
            divClientes.Visible = False
            lblData.Text = "De"
            divAcao.Visible = True
            txtDataInicial.Text = Now.AddDays(-31).ToString("dd/MM/yyyy")
        Else
            FiltroItem_Calendario.Visible = True
            divVendedores.Visible = False
            divClientes.Visible = False
            lblData.Text = "De"
            divAcao.Visible = False
            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
        End If

        'btnExibir.Disabled = False

    End Sub

    Private Sub ListarVendedores()

        lstVendedores.DataSource = rep.ListVendedoresRpt("0", User.IDUser)
        lstVendedores.DataBind()
        'If lstVendedores.Items.Count > 1 Then
        '    lstVendedores.Items.Insert(0, New ListItem("Todos", 0))
        '    lstVendedores.SelectedValue = 0
        'End If

    End Sub

    Private Sub ListarClientes(Optional ByVal vIdVendedores As String = "0")

        lstClientes.DataSource = rep.ListClientesRptConsignado("0", vIdVendedores)
        lstClientes.DataBind()
        'lstClientes.Items.Insert(0, New ListItem("Todos", 0))
        'lstClientes.SelectedValue = 0

    End Sub


    'Protected Sub btnExibir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExibir.ServerClick
    '    Dim strScript As String = "fncExibir('frame')"
    '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "frame", strScript, True)
    'End Sub

    'Protected Sub btnImprimir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.ServerClick
    '    Dim strScript As String = "fncExibir('print')"
    '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "frame", strScript, True)
    'End Sub

    Protected Sub lstVendedores_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstVendedores.SelectedIndexChanged
        rep = New clsRelatorio
        Dim strVendedores As String = getComboValues(lstVendedores)
        ListarClientes(strVendedores)
    End Sub

End Class
