Public MustInherit Class Bloco3

    Inherits System.Web.UI.UserControl
    Protected WithEvents dtlEventos As System.Web.UI.WebControls.DataList
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

        Dim eventos As New Evento()
        Dim ds As DataSet = eventos.UltimosEventos(5)
        dtlEventos.DataSource = ds
        dtlEventos.DataBind()

    End Sub

End Class
