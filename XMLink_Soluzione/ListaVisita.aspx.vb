Public Class ListaVisita
    Inherits XMProtectedPage
    Protected WithEvents rptGrid As System.Web.UI.WebControls.Repeater
    Protected WithEvents lnkPrevious As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkNext As System.Web.UI.WebControls.LinkButton
    Protected cls As clsVisita

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
        cls = New clsVisita(Me)
        If Not Page.IsPostBack Then
            ViewState("CurrentPage") = 0
            ViewState("Desc") = True
            ViewState("Sort") = "OS"
        End If
        BindGrid()
    End Sub


    Public Sub BindGrid()
        Dim ds As DataSet

        ds = cls.List("" & Request("Cliente"), "" & Request("vendedor"), CInt("0" & Request("IDStatus")), CInt("0" & Request("IDGrupo")), Request("DataInicio") & "", Request("DataFinal") & "", ViewState("Sort") & "", ViewState("Desc"), ViewState("CurrentPage"), PageSize)
        rptGrid.DataSource = ds.Tables(0)
        rptGrid.DataBind()
        Dim intMaxPages As Integer = ds.Tables(1).Rows(0).Item(0) \ PageSize
        If ViewState("CurrentPage") > intMaxPages Then
            ViewState("CurrentPage") = intMaxPages
        End If
        If ViewState("CurrentPage") > 0 Then
            lnkPrevious.Enabled = True
            lnkPrevious.CommandArgument = ViewState("CurrentPage") - 1
        Else
            lnkPrevious.Enabled = False
        End If
        If ViewState("CurrentPage") < intMaxPages Then
            lnkNext.Enabled = True
            lnkNext.CommandArgument = ViewState("CurrentPage") + 1
        Else
            lnkNext.Enabled = False
        End If

    End Sub

    Public Sub rptGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If
        BindGrid()
    End Sub

End Class
