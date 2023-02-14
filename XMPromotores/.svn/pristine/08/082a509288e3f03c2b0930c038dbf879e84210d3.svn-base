
Imports Classes

<PersistChildren(True)> _
Partial Class controls_Segmentacao
    Inherits System.Web.UI.UserControl
    Implements XMWebEditPage.IEditPageObserver

    Private cls As New clsSegmentacao

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If TypeOf (Me.Page) Is XMWebEditPage Then
            CType(Page, XMWebEditPage).AddObserver(Me)
        End If
    End Sub

    Public Property Style() As String
        Get
            Return ViewState("Style")
        End Get
        Set(ByVal value As String)
            ViewState("Style") = value
        End Set
    End Property

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

    Public Property UtilizaSegmentacao() As Boolean
        Get
            If ViewState("UtilizaSegmentacao") Is Nothing Then
                Return True
            End If
            Return ViewState("UtilizaSegmentacao")
        End Get
        Set(ByVal value As Boolean)
            ViewState("UtilizaSegmentacao") = value
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
            btnAddSegmentacao.Enabled = value
            rdTipoBusCaProduto.Enabled = value
            txtBuscaProduto.ReadOnly = Not value
            btnBuscarProdutos.Enabled = value
            grdSegmentacao.Columns(5).Visible = value
            cboIDCategoria.Enabled = value
            cboIDProduto.Enabled = value
            cboIDSubCategoria.Enabled = value
            cboIDMarca.Enabled = value
            cboConcorrente.Enabled = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UtilizaSegmentacao Then

                BindCategoria()
                BindSubCategoria()
                BindFornecedor()

                cboIDProduto.Items.Clear()
                cboIDProduto.Items.Insert(0, New ListItem("TODOS", "0"))

                'Settings
                With XMLinkSettings
                    trCategoria.Visible = .Produto.ClassificaCategoria
                    trSubCategoria.Visible = .Produto.ClassificaSubCategoria
                    trMarca.Visible = .Produto.ClassificaMarca
                    trConcorrente.Visible = .Marca.UtilizaConcorrente

                    grdSegmentacao.Columns(0).Visible = .Marca.UtilizaConcorrente
                    grdSegmentacao.Columns(1).Visible = .Produto.ClassificaMarca
                    grdSegmentacao.Columns(2).Visible = .Produto.ClassificaCategoria
                    grdSegmentacao.Columns(3).Visible = .Produto.ClassificaSubCategoria

                    rdTipoBusCaProduto.Items.Clear()
                    If .Produto.ClassificaMarca Then rdTipoBusCaProduto.Items.Add(New ListItem("Marca", "Marca"))
                    If .Produto.ClassificaCategoria Then rdTipoBusCaProduto.Items.Add(New ListItem("Segmento", "Categoria"))
                    If .Produto.ClassificaSubCategoria Then rdTipoBusCaProduto.Items.Add(New ListItem("Categoria", "SubCategoria"))
                    rdTipoBusCaProduto.Items.Add(New ListItem("Produto", "Produto"))
                    rdTipoBusCaProduto.SelectedValue = "Produto"

                End With
            Else
                pnlSegmentacao.Visible = False
            End If
        End If

    End Sub

    Protected ReadOnly Property XMLinkSettings() As Settings.clsXMLinkSettings
        Get
            Dim c As New Settings.clsXMLinkSettings
            Return c
        End Get
    End Property

#Region "Segmentacao por produto"


    Protected Sub cboConcorrente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConcorrente.SelectedIndexChanged
        BindFornecedor()
        BindProduto()
    End Sub

    Protected Sub cboCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCategoria.SelectedIndexChanged
        BindSubCategoria()
        BindProduto()
    End Sub

    Protected Sub cboSubCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDSubCategoria.SelectedIndexChanged
        BindProduto()
    End Sub

    Protected Sub BindFornecedor()
        Dim mar As New clsFornecedor
        cboIDMarca.DataSource = mar.Listar(0, cboConcorrente.SelectedValue, DataClass.enReturnType.DataReader)
        cboIDMarca.DataBind()
        cboIDMarca.Items.Insert(0, New ListItem("TODAS", "0"))
    End Sub

    Protected Sub BindCategoria()
        Dim cat As New clsCategoria()
        cboIDCategoria.DataSource = cat.ListarSegmento(IIf(cboIDMarca.SelectedValue = "", 0, cboIDMarca.SelectedValue))
        cboIDCategoria.DataBind()
        cboIDCategoria.Items.Insert(0, New ListItem("TODOS", "0"))
    End Sub

    Protected Sub BindSubCategoria()
        'If cboIDCategoria.SelectedValue = 0 Then
        '    cboIDSubCategoria.Items.Clear()
        '    cboIDSubCategoria.Items.Insert(0, New ListItem("TODAS", "0"))
        'Else
        Dim sct As New clsSubCategoria()
        cboIDSubCategoria.DataSource = sct.Listar(cboIDCategoria.SelectedValue, cboIDMarca.SelectedValue, DataClass.enReturnType.DataReader)
        cboIDSubCategoria.DataBind()
        cboIDSubCategoria.Items.Insert(0, New ListItem("TODAS", "0"))
        'End If
    End Sub

    Protected Sub BindProduto()
        'If cboIDSubCategoria.SelectedValue = 0 Then
        '    cboIDProduto.Items.Clear()
        '    cboIDProduto.Items.Insert(0, New ListItem("TODOS", "0"))
        'Else
        Dim prd As New clsProduto()
        cboIDProduto.DataSource = prd.Listar("", cboIDCategoria.SelectedValue, cboIDSubCategoria.SelectedValue, cboIDMarca.SelectedValue, CByte(cboConcorrente.SelectedValue), "Descricao", False, 0, 0, 2, DataClass.enReturnType.DataReader).Data
        cboIDProduto.DataBind()
        cboIDProduto.Items.Insert(0, New ListItem("TODOS", "0"))
        'End If
    End Sub

    Protected Sub btnAddSegmentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSegmentacao.Click
        cls.AddSegmentacao(Entidade, IDReferencia, cboConcorrente.SelectedValue, cboIDMarca.SelectedValue, cboIDCategoria.SelectedValue, cboIDSubCategoria.SelectedValue, cboIDProduto.SelectedValue)
        BindGridProdutos()
    End Sub

    Protected Sub grdSegmentacao_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSegmentacao.DataBound
        grdSegmentacao.EmptyDataText = EmptyDataText
    End Sub

    Protected Sub grdSegmentacao_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSegmentacao.RowCommand
        If e.CommandName = "RetirarProduto" Then
            cls.Remove(grdSegmentacao.DataKeys(e.CommandArgument).Value)
            BindGridProdutos()
        End If
    End Sub

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


    Protected Sub BindGridProdutos()
        If UtilizaSegmentacao Then
            pnlSegmentacao.Visible = (IDReferencia > 0 And Entidade > 0)
            grdSegmentacao.DataSource = cls.Listar(rdTipoBusCaProduto.SelectedItem.Value, txtBuscaProduto.Text, Entidade, IDReferencia)
            grdSegmentacao.DataBind()
        Else
            pnlSegmentacao.Visible = False
        End If

    End Sub

#End Region

    Public Sub NotifyDelete(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyDelete

    End Sub

    Public Sub NotifyInflate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyInflate
        If UtilizaSegmentacao Then
            cls = New clsSegmentacao
            IDReferencia = vID
            Entidade = vEntidade
            BindGridProdutos()
        End If
    End Sub

    Public Sub NotifyUpdate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyUpdate

    End Sub

    Protected Sub btnBuscarProdutos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProdutos.Click
        BindGridProdutos()
    End Sub

    Protected Sub cboIDMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDMarca.SelectedIndexChanged
        BindCategoria()
        BindSubCategoria()
        BindProduto()
    End Sub
End Class
