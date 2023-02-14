Public Class GuiaFornecedoresDet

    Inherits System.Web.UI.Page
    Protected WithEvents dtlFornecedores As System.Web.UI.WebControls.DataList
    Protected xmWeb As XMWebPage

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

        xmWeb = New XMWebPage

        Dim objIdProduto As Object = xmWeb.DeCryptography(Page.Request("p"))
        If IsNumeric(objIdProduto) Then
            ViewState("IdProduto") = objIdProduto
        Else
            ViewState("IdProduto") = 0
        End If

        If ViewState("IdProduto") = 0 Then
            Response.Redirect("guiafornecedores.aspx")
        Else
            Dim assoc As New clsAssociados(0)
            dtlFornecedores.DataSource = assoc.List(ViewState("IdProduto"))
            dtlFornecedores.DataBind()
        End If
    End Sub

End Class
