Imports Classes


<PersistChildren(True)> _
Partial Class controls_produtoconcorrente
    Inherits System.Web.UI.UserControl
    Implements XMWebEditPage.IEditPageObserver

    Protected cls As clsProdutoConcorrente


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

    Public Property UtilizaProdutoConcorrente() As Boolean
        Get
            If ViewState("UtilizaProdutoConcorrente") Is Nothing Then
                Return True
            End If
            Return ViewState("UtilizaProdutoConcorrente")
        End Get
        Set(ByVal value As Boolean)
            ViewState("UtilizaProdutoConcorrente") = value
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
            btnAddSegmentacao.Enabled = value
            grdProdutos.Columns(5).Visible = value
            cboIDCategoria.Enabled = value
            cboIDProduto.Enabled = value
            cboIDSubCategoria.Enabled = value
            cboIDMarca.Enabled = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsProdutoConcorrente
    End Sub

#Region "Segmentacao por produto"


    Protected Sub cboIDMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDMarca.SelectedIndexChanged
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
        cboIDMarca.DataSource = mar.Listar(DataClass.enReturnType.DataReader)
        cboIDMarca.DataBind()
        cboIDMarca.Items.Insert(0, New ListItem("TODAS", "0"))
    End Sub

    Protected Sub BindCategoria()
        Dim cat As New clsCategoria()
        cboIDCategoria.DataSource = cat.Listar()
        cboIDCategoria.DataBind()
        cboIDCategoria.Items.Insert(0, New ListItem("TODOS", "0"))
    End Sub

    Protected Sub BindSubCategoria()

        Dim p_Categorias As String = getComboValues(cboIDCategoria)

        Dim sct As New clsSubCategoria()
        cboIDSubCategoria.DataSource = sct.Listar(p_Categorias, DataClass.enReturnType.DataReader)
        cboIDSubCategoria.DataBind()
        cboIDSubCategoria.Items.Insert(0, New ListItem("TODAS", "0"))

    End Sub

    Protected Sub BindProduto()
        cls = New clsProdutoConcorrente
        cboIDProduto.DataSource = cls.ListarDisponiveis(IDReferencia, cboIDCategoria.SelectedValue, cboIDSubCategoria.SelectedValue, cboIDMarca.SelectedValue, DataClass.enReturnType.DataReader)
        cboIDProduto.DataBind()
        cboIDProduto.Items.Insert(0, New ListItem("Selecione...", "0"))
    End Sub

    Protected Sub btnAddSegmentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSegmentacao.Click
        cls.AdicionarConcorrente(IDReferencia, cboIDProduto.SelectedValue)
        BindGridProdutos()
        BindProduto()
    End Sub

    Protected Sub grdProdutos_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProdutos.DataBound
        grdProdutos.EmptyDataText = EmptyDataText
    End Sub

    Protected Sub grdProdutos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProdutos.RowCommand
        If e.CommandName = "RetirarProduto" Then
            cls.RemoverConcorrente(IDReferencia, grdProdutos.DataKeys(e.CommandArgument).Value)
            BindGridProdutos()
            BindProduto()
        End If
    End Sub

    Protected Sub BindGridProdutos()
        grdProdutos.DataSource = cls.Listar(IDReferencia)
        grdProdutos.DataBind()
    End Sub

#End Region

    Public Sub NotifyDelete(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyDelete

    End Sub

    Public Sub NotifyInflate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyInflate
        IDReferencia = vID
        Me.Entidade = vEntidade
        If UtilizaProdutoConcorrente Then
            BindCategoria()

            Dim prd As New clsProduto
            prd.Load(IDReferencia)
            cboIDCategoria.SelectedValue = prd.IDCategoria
            BindSubCategoria()
            cboIDSubCategoria.SelectedValue = prd.IDSubCategoria
            BindFornecedor()
            BindProduto()

            BindGridProdutos()
        Else
            pnlConcorrente.Visible = False
        End If
    End Sub

    Public Sub NotifyUpdate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyUpdate

    End Sub

End Class
