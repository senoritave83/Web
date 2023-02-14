Imports Classes
Imports System.Data



Partial Class Integracao_exportacaorpt
    Inherits XMWebPage
    Protected cls As clsPedido

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsPedido
        If Not Page.IsPostBack Then
            BindPedidos()
        End If

        If ViewState("IDS") = "" Then
            lblMsgSemPedidos.Visible = True
            btnConfirmar.Visible = False
            ltrScript.Text = ltrScript.Text.Replace("<!-- FUNCAO -->", trPrintHeader.ClientID & ".style.display='inline'")
        Else
            ltrScript.Text = ltrScript.Text.Replace("<!-- FUNCAO -->", "window.print();" & vbCrLf & trPrintHeader.ClientID & ".style.display='inline'")
        End If

    End Sub

    Protected Sub BindPedidos()
        ViewState("IDS") = ""
        rptPedidos.DataSource = cls.Listar("", "", "", CInt("0" & Request("sta")), Request("dtini"), Request("dtfn"), "", False, 0, 0).Data
        rptPedidos.DataBind()
    End Sub

    Protected Function GetItensPedido(ByVal vIDPedido As String) As Data.IDataReader
        Return cls.ListItensPedido(vIDPedido)
    End Function

    Protected Sub rptPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptPedidos.ItemDataBound

        With e.Item
            If .ItemType = ListItemType.AlternatingItem OrElse .ItemType = ListItemType.Item Then
                ViewState("IDS") &= DataBinder.Eval(e.Item.DataItem, "NumeroPedido").ToString() & ","
            End If
        End With
    End Sub

    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        cls.ConfirmaImpressao(ViewState("IDS"))
        lblMsgImpressao.Visible = True
        lblMsgSemPedidos.Visible = False
        If ViewState("IDS") = "" Then
            lblMsgImpressao.Visible = False
        End If
        BindPedidos()
        btnConfirmar.Visible = False
        ltrScript.Text = ""
    End Sub
End Class
