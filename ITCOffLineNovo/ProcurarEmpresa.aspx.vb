Imports ITCOffLine

Public Class ProcurarEmpresa

    Inherits XMWebPage

    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents Table2 As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnProcurar As System.Web.UI.WebControls.Button
    Protected WithEvents dtgEmpresas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal
    Protected WithEvents txtBusca As System.Web.UI.WebControls.TextBox

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
            ViewState("IdObra") = DeCryptography(Page.Request("IdObra"))
        End If

    End Sub

    Public Sub SelItemProg(ByVal src As Object, ByVal e As DataGridCommandEventArgs)

        dtgEmpresas.SelectedIndex = e.Item.ItemIndex


        Dim strJavaScript As String = "<script language=""javascript"">" & vbCrLf
        strJavaScript += "window.opener.location.href = 'empresaobras.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")) & "&idempresa=" & CryptographyEncoded(dtgEmpresas.DataKeys.Item(dtgEmpresas.SelectedIndex)) & "';" & vbCrLf
        strJavaScript += "window.close();"
        strJavaScript += "</script>"

        Literal1.Text = strJavaScript

    End Sub

    Private Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        If txtBusca.Text.Trim <> "" Then
            Dim Emp As New clsEmpresas(0)
            dtgEmpresas.DataSource = Emp.List(txtBusca.Text, "", "", "", 1, 3)
            dtgEmpresas.DataBind()
            Emp = Nothing
        Else
            dtgEmpresas.DataSource = Nothing
        End If
    End Sub
End Class
