Imports Classes

Partial Class home_recados
    Inherits XMWebPage

    Dim cls As clsRecados

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsRecados
        If Not Page.IsPostBack Then

            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

            Me.RecuperaFiltro(Paginate1, txtVendedor, txtDataInicial, txtDataFinal)
            Paginate1.SortDirection = SortDirection.Descending
            BindGrid()

            If Me.User.IDEmpresa = 0 Then

                CarregaRegionais()

            Else

                divRegionais.Visible = False
                divRevendas.Visible = False

            End If


            CarregaTipoUsuario()

        End If
    End Sub

    Private Sub CarregaTipoUsuario()

        chkTipo.DataSource = cls.TipoUsuario
        chkTipo.DataBind()

    End Sub

    Private Sub CarregaRegionais()

        cboRegional.DataSource = cls.Regionais
        cboRegional.DataBind()

        cboDestinatario.Items.Clear()
        cboRevendas.Items.Clear()

    End Sub

    Private Sub CarregaRevendas()

        If cboRegional.Items.Count > 0 Then

            ViewState("Regionais") = getComboValues(cboRegional, True)
            ViewState("Revendas") = ""
            ViewState("Niveis") = ""
            cboDestinatario.Items.Clear()

            cboRevendas.DataSource = cls.Revendas(ViewState("Regionais"))
            cboRevendas.DataBind()

        End If

    End Sub


    Private Sub CarregaDestinatarios()

        If (Me.User.IDEmpresa = 0 And cboRevendas.Items.Count > 0) Or Me.User.IDEmpresa > 0 Then

            ViewState("Revendas") = getComboValues(cboRevendas, True)
            ViewState("Niveis") = getComboValues(chkTipo, True)

            cboDestinatario.DataSource = cls.DestinatariosRecado(ViewState("Regionais"), ViewState("Revendas"), ViewState("Niveis"))
            cboDestinatario.DataBind()

        End If

    End Sub

    Public Sub BindGrid()
        Dim ret As IPaginaResult = cls.Listar(txtVendedor.Text, txtDataInicial.Text, txtDataFinal.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
        GridView1.DataSource = ret.Data
        GridView1.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

        Me.GravaFiltro(Paginate1, txtVendedor, txtDataInicial, txtDataFinal)
    End Sub

    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub

    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        BindGrid()
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Paginate1.CurrentPage = 0
        BindGrid()
    End Sub

    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Paginate1.SortExpression = e.SortExpression
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim blnEnviado As Boolean = False

        '**********************************************
        'VERIFICA SEM ESTÁ SELECIONADO UM ITEM ESPECIFICO
        '**********************************************
        For Each it As ListItem In cboDestinatario.Items
            If it.Selected Then

                Dim vDados As Object = Split(it.Value, "_")

                Dim vIdEmpresa As Integer = vDados(0)
                Dim vGrupo As Boolean = vDados(1) = "1"
                Dim vIdGrupoVendedor As Integer = vDados(2)

                cls.Enviar(vIdEmpresa, vGrupo, vIdGrupoVendedor, txtMensagem.Text)
                blnEnviado = True

            End If

        Next

        '**********************************************
        'CASO O USUÁRIO NÃO TENHA SELECIONADO UM ITEM
        'ESPECIFICO, O SISTEMA ENVIA PARA TODOS DA LISTA
        '**********************************************
        If blnEnviado = False Then

            For Each it As ListItem In cboDestinatario.Items

                Dim vDados As Object = Split(it.Value, "_")

                Dim vIdEmpresa As Integer = vDados(0)
                Dim vGrupo As Boolean = vDados(1) = "1"
                Dim vIdGrupoVendedor As Integer = vDados(2)

                cls.Enviar(vIdEmpresa, vGrupo, vIdGrupoVendedor, txtMensagem.Text)

            Next

        End If

        btnNovoEnvio.Visible = True
        pnlMensagem.Visible = True
        btnEnviar.Visible = False
        updEnvio.Visible = False
        BindGrid()

    End Sub

    Protected Sub btnCarregaRevendas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCarregaRevendas.Click

        CarregaRevendas()

    End Sub

    Protected Sub btnCarregaDestinatarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCarregaDestinatarios.Click

        CarregaDestinatarios()

    End Sub

    Protected Sub btnNovoEnvio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovoEnvio.Click

        btnNovoEnvio.Visible = False
        pnlMensagem.Visible = False
        btnEnviar.Visible = True
        updEnvio.Visible = True
        txtMensagem.Text = ""
        txtVendedor.Text = ""
        cboDestinatario.Items.Clear()

    End Sub

End Class
