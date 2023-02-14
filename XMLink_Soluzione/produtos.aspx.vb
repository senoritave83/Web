Imports System.Data.SqlClient

Public Class produtos
    Inherits XMProtectedPage
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents valtxtCodigo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents valtxtDescricao As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valComEstoque As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtEstoque As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtPrecoUnitario As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnNovo As System.Web.UI.WebControls.Button
    Protected WithEvents btnApagar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtFiltro As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents lnkPrevious As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkNext As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cboFiltroCategoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCategoria As ComboBox
    Protected cls As clsProdutos

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsProdutos(Me)
        If Not Page.IsPostBack Then
            Dim cat As New clsCategoria(Me)
            cboCategoria.DataSource = cat.Listar
            cboCategoria.DataBind()
            cboFiltroCategoria.DataSource = cat.Listar
            cboFiltroCategoria.DataBind()
            cboFiltroCategoria.Items.Insert(0, New ListItem("todos", "0"))
            cat = Nothing
            BindGrid()
            ViewState("CurrentPage") = 0
            ViewState("Desc") = True
            ViewState("Sort") = "OS"
            btnNovo.Enabled = CheckPermission("Cadastro de Produtos", "Adicionar Produto")
            btnApagar.Enabled = CheckPermission("Cadastro de Produtos", "Apagar Produto")
        End If
    End Sub


    Private Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        If CheckPermission("Cadastro de Produtos", "Adicionar produto") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(0, txtCodigo.Text) Then
            ShowMsg("O produto com este código já existe!")
            Exit Sub
        End If
        cls.Codigo = txtCodigo.Text
        cls.Descricao = txtDescricao.Text
        cls.Estoque = txtEstoque.Text
        cls.PrecoUnitario = txtPrecoUnitario.Text
        cls.IDCategoria = cboCategoria.Value
        Try
            cls.Update()
        Catch ex As SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
        MostraGravado("produtos.aspx")
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        cls.Delete(Request("chkSelected"))
        BindGrid()
    End Sub



    Public Sub BindGrid()
        Dim ds As DataSet
        ds = cls.Listar(cboFiltroCategoria.SelectedItem.Value, txtFiltro.Text, ViewState("Sort") & "", ViewState("Desc"), ViewState("CurrentPage"), PageSize)
        dtgGrid.DataSource = ds.Tables(0)
        dtgGrid.DataBind()
        Dim intMaxPages As Integer = ds.Tables(1).Rows(0).Item(0) \ PageSize
        If ViewState("CurrentPage") > intMaxPages Then
            ViewState("CurrentPage") = intMaxPages
        End If
        If ViewState("CurrentPage") > 0 Then
            lnkPrevious.Enabled = True
            lnkPrevious.CommandArgument = ViewState("CurrentPage") - 1
        Else
            lnkPrevious.Enabled = False
        End If
        If ViewState("CurrentPage") < intMaxPages Then
            lnkNext.Enabled = True
            lnkNext.CommandArgument = ViewState("CurrentPage") + 1
        Else
            lnkNext.Enabled = False
        End If
    End Sub

    Public Sub DataGrid_Command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If
        BindGrid()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        BindGrid()
    End Sub

End Class
