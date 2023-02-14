Public MustInherit Class MostraDicas
    Inherits System.Web.UI.UserControl
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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

        Dim dicas As New Dica()
        Dim ds As DataSet = dicas.ListarUltimaDica()
        dicas = Nothing

        Dim i As Integer
        If ds.Tables.Count > 0 Then
            Label1.Text = "<b>" & ds.Tables(0).Rows(i).Item("TITULO") & "</b><br><br>"
            Label1.Text += ds.Tables(0).Rows(i).Item("DESCRICAO") & "<br>"
        End If

        ds.Dispose()
        ds = Nothing

    End Sub

End Class
