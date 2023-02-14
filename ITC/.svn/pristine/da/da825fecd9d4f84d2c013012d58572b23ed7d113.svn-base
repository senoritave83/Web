Public Class ProdutosAssociados

    Inherits XMWebPage
    Protected WithEvents chkProdutos As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnVoltar As Button
    Private ProdAss As clsProdutosAssociado

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
        If Not Page.IsPostBack Then
            ViewState("IdAssociado") = DeCryptography(Page.Request("IdAssociado"))
            If Not IsNumeric(ViewState("IdAssociado")) Then ViewState("IdAssociado") = 0
            ProdAss = New clsProdutosAssociado
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        chkProdutos.Items.Clear()
        Dim ds As DataSet = ProdAss.ListProdutosAssociado(ViewState("IdAssociado"))
        With ds.Tables
            If .Count > 0 Then
                If .Item(0).Rows.Count > 0 Then
                    Dim i As Integer
                    Dim lst As ListItem
                    For i = 0 To .Item(0).Rows.Count - 1
                        lst = New ListItem()
                        lst.Text = .Item(0).Rows(i).Item("DESCRICAOPRODUTO")
                        lst.Value = .Item(0).Rows(i).Item("IDPRODUTO")
                        lst.Selected = (.Item(0).Rows(i).Item("IDASSOCIADO") > 0)
                        chkProdutos.Items.Add(lst)
                    Next
                End If
            End If
        End With
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub
End Class
