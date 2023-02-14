Public MustInherit Class Rodapé
    Inherits System.Web.UI.UserControl
    Protected WithEvents lblRodape2 As System.Web.UI.WebControls.Label

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
        lblRodape2.Text = "Copyright " & Year(Now) & " - XM Sistemas Distribuídos Ltda"

        If TypeOf (Me.Page) Is XMWebPage Then
            lblRodape2.Text &= "<!-- G:" & CType(Me.Page, XMWebPage).Usuario.UserGuid() & " -->"
        End If

    End Sub

End Class
