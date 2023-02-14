Public MustInherit Class BarraNavegacao
    Inherits System.Web.UI.UserControl

    Protected WithEvents Firstbutton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Prevbutton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Nextbutton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Lastbutton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblDescricao As System.Web.UI.WebControls.Label
    Protected WithEvents tblbarranavegacao As System.Web.UI.HtmlControls.HtmlTable

    Public Event NextReg()
    Public Event PreviousReg()
    Public Event LastReg()
    Public Event FirstReg()

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
        'Put user code to initialize the page here
    End Sub

    Public Sub PagerButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        'used by external paging UI
        Dim arg As String = sender.CommandArgument

        Select Case arg
            Case "next"
                RaiseEvent NextReg()


            Case "prev"
                RaiseEvent PreviousReg()


            Case "last"
                RaiseEvent LastReg()


            Case Else
                RaiseEvent FirstReg()

        End Select

    End Sub

    Public Sub SetFirstRegLabelDescription(ByVal Description As String)
        Firstbutton.Text = Description
    End Sub

    Public Sub SetLastRegLabelDescription(ByVal Description As String)
        Lastbutton.Text = Description
    End Sub

    Public Sub SetPreviousRegLabelDescription(ByVal Description As String)
        Prevbutton.Text = Description
    End Sub

    Public Sub SetNextRegLabelDescription(ByVal Description As String)
        Nextbutton.Text = Description
    End Sub

    Public Sub SetDescription(ByVal Description As String)
        lblDescricao.Text = Description
    End Sub

End Class
