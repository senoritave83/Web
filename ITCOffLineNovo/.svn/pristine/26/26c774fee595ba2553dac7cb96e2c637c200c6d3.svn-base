Imports ITCOffLine
Imports System.Data

Public Class ObrasVersoes

    Inherits XMWebPage
    Protected WithEvents dtgObrasVersoes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Private Obras As New clsObras
    Protected WithEvents btnVoltar As Button
    Private ds As DataSet

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

        Dim objIdObra As Object = DeCryptography(Request("IdObra"))
        If IsNumeric(objIdObra) Then
            ViewState("IdObra") = objIdObra
        Else
            ViewState("IdObra") = 0
        End If

        If Not Page.IsPostBack Then
            ds = Obras.ListVersoes(ViewState("IdObra"))
            dtgObrasVersoes.DataSource = ds
            dtgObrasVersoes.DataBind()
        End If

    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("obrasdet.aspx?Codigo=" & Cryptography(ViewState("IdObra")))
    End Sub
End Class

