

Imports Classes

Namespace Pages.Cadastros.export

    Partial Public Class Classificacoes
        Inherits XMWebPage
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim cls As New clsClassificacao(CInt("0" & Request("idtipo")))
            grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), Request("SortExpression"), False, 0, 0).Data
			grdExportar.DataBind()

			Response.AddHeader("Last-Modified", Now().ToString)
			Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Classificacoes_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
			Response.ContentType = "application/vnd.ms-excel"


		End Sub

	End Class

End Namespace

