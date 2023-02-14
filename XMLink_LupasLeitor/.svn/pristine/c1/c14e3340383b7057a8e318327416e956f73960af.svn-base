Imports Classes

Partial Class Roteiros_consignado
    Inherits XMWebPage
    Protected cls As clsCliente
    Protected Const VW_IDCLIENTE As String = "IDCliente"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsCliente()
        If Not Page.IsPostBack Then
            ViewState(VW_IDCLIENTE) = CInt("0" & Request("IDCliente"))
            cls.Load(ViewState(VW_IDCLIENTE))
            Inflate()
        Else
            cls.Load(ViewState(VW_IDCLIENTE))
        End If
    End Sub

    Protected Sub Inflate()
        lblCliente.Text = cls.Cliente
        lblCNPJ.Text = cls.CNPJ
        lblCodigo.Text = cls.Codigo
        lblTextoNomeFantasia.Text = cls.NomeFantasia

        BindProdutos()
    End Sub

    Protected Sub BindProdutos()
        grdProdutos.DataSource = cls.Consignacao.ListarProdutosConsignados()
        grdProdutos.DataBind()
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Editing = True
        BindProdutos()
    End Sub

    Public Property Editing() As Boolean
        Get
            Return btnGravar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnGravar.Visible = value
            btnEditar.Visible = Not value
            btnCancelar.Visible = value
            btnAdicionar.Visible = Not value
            btnVoltar.Visible = Not value
        End Set
    End Property

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Editing = False
        BindProdutos()
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim col As New clsConsignacao.clsProdutosConsignados

        For Each row As GridViewRow In grdProdutos.Rows
            Dim intIDProduto As Integer
            intIDProduto = grdProdutos.DataKeys(row.RowIndex).Value
            Dim txtEstoque As TextBox = CType(row.FindControl("txtEstoque"), TextBox)
            col.Add(intIDProduto, txtEstoque.Text)
        Next
        cls.Consignacao.AtualizaQuantidades(col)
        Editing = False
        BindProdutos()
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Response.Redirect("consignadoadicionar.aspx?idcliente=" & cls.IDCliente)
    End Sub
End Class
