
Partial Class integracao_Default
    Inherits XMWebPage

    Protected Sub rptItens_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptItens.ItemDataBound
        Dim x As Object = e.Item.DataItem
    End Sub
End Class
