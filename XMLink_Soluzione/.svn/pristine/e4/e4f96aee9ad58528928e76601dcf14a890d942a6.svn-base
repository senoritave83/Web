Public MustInherit Class titulo
    Inherits System.Web.UI.UserControl
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescricao As System.Web.UI.WebControls.Label
    Protected WithEvents plhTitulo As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents imgImagem As System.Web.UI.HtmlControls.HtmlImage

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

    Public Property Descricao() As String
        Get
            Return lblDescricao.Text
        End Get
        Set(ByVal Value As String)
            lblDescricao.Text = Value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal Value As String)
            lblTitulo.Text = Value
        End Set
    End Property

    Public Property Imagem() As String
        Get
            Return imgImagem.Src
        End Get
        Set(ByVal Value As String)
            imgImagem.Src = "../" & Value
        End Set
    End Property

End Class
