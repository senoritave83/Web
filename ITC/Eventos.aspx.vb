Public Class Eventos
    Inherits System.Web.UI.Page
    Protected WithEvents dtlEventos As System.Web.UI.WebControls.DataList

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
            Dim eventos As New Evento()
            Dim ds As DataSet = eventos.ListaEventos
            dtlEventos.DataSource = ds
            dtlEventos.DataBind()
        End If
    End Sub

End Class
