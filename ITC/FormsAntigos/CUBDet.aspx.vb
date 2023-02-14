Public Class CUBDet

    Inherits System.Web.UI.Page
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblData As System.Web.UI.WebControls.Label
    Protected WithEvents lblReportagem As System.Web.UI.WebControls.Label

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
            If Not IsNumeric(Page.Request("IdCUB")) Then
                Response.Redirect("CUB.aspx")
            ElseIf Page.Request("IdCUB") = 0 Then
                Response.Redirect("CUB.aspx")
            Else
                Dim clsCUB As clsCUB
                clsCUB = New clsCUB(Page.Request("IdCUB"))
                With clsCUB
                    lblTitulo.Text = .Titulo
                    lblData.Text = "postada em " & .Data
                    lblReportagem.Text = .Descricao
                End With
            End If
        End If
    End Sub

End Class
