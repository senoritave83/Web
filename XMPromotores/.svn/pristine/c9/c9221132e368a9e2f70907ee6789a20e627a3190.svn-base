Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class Cadastros_export_produtos
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsProduto

        Dim ds As DataSet = cls.ListarCampos(Request.QueryString("Filtro"), CInt(Request("cboIDCategoria")), CInt(Request("cboIDSubCategoria")), CInt(Request("cboIDFornecedor")), Request("SortExpression"), False, 0, 0)

        With grdExportar

            For Each col As DataColumn In ds.Tables(0).Columns

                Dim strHeaderName As String = ""
                If col.ColumnName.ToUpper = "CATEGORIA" Then
                    strHeaderName = SettingsExpression.GetProperty("caption", "Categoria", "Segmento")
                ElseIf col.ColumnName.ToUpper = "IDCATEGORIA" Then
                    strHeaderName = SettingsExpression.GetProperty("captionid", "Categoria", "IdSegmento")
                ElseIf col.ColumnName.ToUpper = "SUBCATEGORIA" Then
                    strHeaderName = SettingsExpression.GetProperty("caption", "SubCategoria", "Categoria")
                ElseIf col.ColumnName.ToUpper = "IDSUBCATEGORIA" Then
                    strHeaderName = SettingsExpression.GetProperty("captionid", "SubCategoria", "IdCategoria")
                Else
                    strHeaderName = col.ColumnName
                End If
                Dim bfield As BoundField = New BoundField()
                bfield.HeaderText = strHeaderName
                bfield.DataField = col.ColumnName

                .Columns.Add(bfield)

            Next

            .DataSource = ds
            .DataBind()

        End With

        Response.AddHeader("Last-Modified", Now().ToString)
        Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Produtos_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
        Response.ContentType = "application/vnd.ms-excel"


    End Sub

End Class
