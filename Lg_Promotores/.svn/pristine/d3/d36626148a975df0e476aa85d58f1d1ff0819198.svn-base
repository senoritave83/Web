Imports Classes

Partial Class Cadastros_export_produtos
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsProduto
        grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), CInt(Request("cboIDCategoria")), CInt(Request("cboIDSubCategoria")), CInt(Request("cboIDFornecedor")), Request("SortExpression"), False, 0, 0).Data
        grdExportar.DataBind()

        'SortExpression=&SortDirection=&Filtro=&txtFiltro=&Letras1=&Paginate1=0&cboIDCategoria=0&cboIDSubCategoria=0&cboIDFornecedor=0

        Response.AddHeader("Last-Modified", Now().ToString)
        Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Produtos_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
        Response.ContentType = "application/vnd.ms-excel"


    End Sub

End Class
