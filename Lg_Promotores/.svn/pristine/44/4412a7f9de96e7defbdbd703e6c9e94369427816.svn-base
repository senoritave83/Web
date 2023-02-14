

Imports Classes

Namespace Pages.Cadastros.export

    Partial Public Class MensagemDias
        Inherits XMWebPage
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			Dim cls As new clsMensagemDia
            grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), Request.QueryString("txtDataInicioInicial"), Request.QueryString("txtDataInicioFinal"), CInt(Request("cboIDCategoria")), Request("SortExpression"), False, 0, 0).Data
            grdExportar.DataBind()
            'Filtro=&txtFiltro=&Letras1=&Paginate1=0&txtDataInicioInicial=&txtDataInicioFinal=&cboIDCategoria=0&

			Response.AddHeader("Last-Modified", Now().ToString)
            Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Mensagens_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
			Response.ContentType = "application/vnd.ms-excel"


		End Sub

	End Class

End Namespace

