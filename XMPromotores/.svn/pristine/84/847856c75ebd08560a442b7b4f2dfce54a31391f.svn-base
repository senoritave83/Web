Imports Classes

<PersistChildren(True)> _
Partial Class controls_Localizacao
    Inherits System.Web.UI.UserControl
    Implements XMWebEditPage.IEditPageObserver

    Private cls As New clsLocalizacao

#Region "Default Methods"

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If TypeOf (Me.Page) Is XMWebEditPage Then
            CType(Page, XMWebEditPage).AddObserver(Me)
        End If
    End Sub

    <PersistenceMode(PersistenceMode.InnerProperty)> _
    Public Property Title() As String
        Get
            Return Me.ltrTitle.Text
        End Get
        Set(ByVal value As String)
            Me.ltrTitle.Text = value
        End Set
    End Property

    <PersistenceMode(PersistenceMode.InnerProperty)> _
    Public Property EmptyDataText() As String
        Get
            Return ViewState("EmptyDataText")
        End Get
        Set(ByVal value As String)
            ViewState("EmptyDataText") = value
        End Set
    End Property

    Public Property UtilizaLocalizacao() As Boolean
        Get
            If ViewState("UtilizaLocalizacao") Is Nothing Then
                Return True
            End If
            Return ViewState("UtilizaLocalizacao")
        End Get
        Set(ByVal value As Boolean)
            ViewState("UtilizaLocalizacao") = value
        End Set
    End Property


    Public Property IDReferencia() As Integer
        Get
            If ViewState("IDReferencia") Is Nothing Then
                Return 0
            End If
            Return ViewState("IDReferencia")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDReferencia") = value
        End Set
    End Property

    Public Property Entidade() As enTipoEntidade
        Get
            If ViewState("Entidade") Is Nothing Then
                Return 0
            End If
            Return ViewState("Entidade")
        End Get
        Set(ByVal value As enTipoEntidade)
            ViewState("Entidade") = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            If ViewState("Enabled") Is Nothing Then
                Return True
            End If
            Return ViewState("Enabled")
        End Get
        Set(ByVal value As Boolean)
            ViewState("Enabled") = value
            btnAdicionarSegmento.Enabled = value
            tdTipoBuscaLoja.Enabled = value
            txtBuscaLoja.Enabled = value
            btnBuscaLoja.Enabled = value
            grdSegmentos.Columns(6).Visible = value
            cboUF.Enabled = value
            txtCidade.Enabled = value
            cboIDLoja.Enabled = value
            cboIDRegiao.Enabled = value
            cboIDTipoLoja.Enabled = value
            cboIDBandeira.Enabled = value
        End Set
    End Property

    Protected ReadOnly Property XMLinkSettings() As Settings.clsXMLinkSettings
        Get
            Dim c As New Settings.clsXMLinkSettings
            Return c
        End Get
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UtilizaLocalizacao Then

                If SettingsExpression.GetProperty("modo", " ConfiguracoesGerais.ComponenteLocalizacao", "Padrao") = "Padrao" Then
                    cboIDBandeira.Visible = True
                    txtBandeira_AutoComplete.Enabled = False
                    txtBandeira.Visible = False
                    BindBandeiras()
                Else
                    cboIDBandeira.Visible = False
                    txtBandeira_AutoComplete.Enabled = True
                    txtBandeira.Visible = True
                End If

                'COMBOS
                BindRegiao()
                BindEstados()
                BindTipoLoja()
                cboIDLoja.Items.Clear()
                cboIDLoja.Items.Insert(0, New ListItem("Todas", "0"))

                BindGridSegmentos()

            Else
                pnlLocalizacao.Visible = False
            End If
        End If
    End Sub

    Protected Sub BindBandeiras()
        Dim ban As New clsCliente
        cboIDBandeira.DataSource = ban.Listar()
        cboIDBandeira.DataBind()
        cboIDBandeira.Items.Insert(0, New ListItem("Todas", "0"))
    End Sub

    Protected Sub BindLojas()

        Dim intIdCliente As Integer = 0
        If Not cboIDBandeira.SelectedItem Is Nothing Then
            intIdCliente = cboIDBandeira.SelectedItem.Value
        Else
            intIdCliente = hdIdBandeira.Value
        End If

        If intIdCliente = 0 And cboUF.SelectedIndex = 0 And cboIDRegiao.SelectedItem.Value = 0 Then
            cboIDLoja.Items.Clear()
            cboIDLoja.Items.Insert(0, New ListItem("Todas", "0"))
        Else
            Dim cli As New clsLoja
            cboIDLoja.Items.Clear()
            cboIDLoja.DataSource = cli.Listar("", intIdCliente, cboUF.SelectedValue, cboIDTipoLoja.SelectedItem.Value, 0, cboIDRegiao.SelectedItem.Value, "", False, 0, 0, clsLoja.STATUS_LOJA.ATIVO, txtCidade.Text).Data
            cboIDLoja.DataBind()
            cboIDLoja.Items.Insert(0, New ListItem("Todas", "0"))
            cli = Nothing
        End If

    End Sub

    Protected Sub BindRegiao()
        Dim reg As New clsRegiao
        cboIDRegiao.DataSource = reg.Listar()
        cboIDRegiao.DataBind()
        cboIDRegiao.Items.Insert(0, New ListItem("Todas", "0"))

    End Sub

    Protected Sub BindEstados()
        Dim est As New clsEstado
        cboUF.DataSource = est.Listar()
        cboUF.DataBind()
        cboUF.Items.Insert(0, New ListItem("Todos", ""))
    End Sub

    Protected Sub BindTipoLoja()
        Dim tip As New clsTipoLoja
        cboIDTipoLoja.DataSource = tip.Listar()
        cboIDTipoLoja.DataBind()
        cboIDTipoLoja.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub BindGridSegmentos()
        If Me.UtilizaLocalizacao Then
            grdSegmentos.DataSource = cls.Listar(Me.Entidade, Me.IDReferencia, tdTipoBuscaLoja.SelectedItem.Value, txtBuscaLoja.Text)
            grdSegmentos.DataBind()
        End If
    End Sub

    Protected Sub cboUF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUF.SelectedIndexChanged
        BindLojas()
    End Sub

    Protected Sub cboIDBandeira_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDBandeira.SelectedIndexChanged
        BindLojas()
    End Sub

    Protected Sub cboIDTipoLoja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDTipoLoja.SelectedIndexChanged
        BindLojas()
    End Sub

    Protected Sub cboIDRegiao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDRegiao.SelectedIndexChanged
        BindLojas()
    End Sub

    Protected Sub grdSegmentos_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSegmentos.DataBound
        grdSegmentos.EmptyDataText = EmptyDataText
    End Sub

    Protected Sub grdSegmentos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSegmentos.RowCommand
        If e.CommandName = "RetirarSegmento" Then
            cls.Retirar(Entidade, IDReferencia, grdSegmentos.DataKeys(e.CommandArgument).Value)
            BindGridSegmentos()
        End If
    End Sub

    Protected Sub btnBuscaLoja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaLoja.Click
        BindGridSegmentos()
    End Sub


    Public Sub NotifyDelete(ByVal vEntidade As Geral.enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyDelete
    End Sub

    Public Sub NotifyInflate(ByVal vEntidade As Geral.enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyInflate
        If UtilizaLocalizacao Then
            IDReferencia = vID
            Entidade = vEntidade
            BindGridSegmentos()
        End If
    End Sub

    Public Sub NotifyUpdate(ByVal vEntidade As Geral.enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyUpdate
    End Sub

    Protected Sub btnAdicionarSegmento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarSegmento.Click

        Dim intIdCliente As Integer = 0
        If Not cboIDBandeira.SelectedItem Is Nothing Then
            intIdCliente = cboIDBandeira.SelectedItem.Value
        Else
            intIdCliente = hdIdBandeira.Value
        End If
        cls.Adicionar(Entidade, IDReferencia, cboUF.SelectedValue, txtCidade.Text, intIdCliente, cboIDLoja.SelectedValue, cboIDRegiao.SelectedValue, cboIDTipoLoja.SelectedValue)
        BindGridSegmentos()

        hdIdBandeira.Value = "0"
        txtBandeira.Text = ""
        cboIDLoja.Items.Clear()
        cboIDLoja.Items.Insert(0, New ListItem("Todas", "0"))

    End Sub

    Protected Sub hdIdBandeira_ValueChanged(sender As Object, e As System.EventArgs) Handles hdIdBandeira.ValueChanged

        Dim vIdCliente As String = hdIdBandeira.Value
        Dim cli As New clsLoja
        cboIDLoja.Items.Clear()
        cboIDLoja.DataSource = cli.Listar("", vIdCliente, cboUF.SelectedValue, cboIDTipoLoja.SelectedItem.Value, 0, cboIDRegiao.SelectedItem.Value, "", False, 0, 0, clsLoja.STATUS_LOJA.ATIVO, txtCidade.Text).Data
        cboIDLoja.DataBind()
        cboIDLoja.Items.Insert(0, New ListItem("Todas", "0"))
        cli = Nothing

    End Sub

End Class
