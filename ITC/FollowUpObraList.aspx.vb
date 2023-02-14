Public Class FollowUpObraList

    Inherits XMWebPage

    Protected WithEvents lnkApagar As LinkButton
    Protected WithEvents dtlFollowUP As DataGrid
    Protected WithEvents btnProcurar As Button
    Protected WithEvents lnkNovo As LinkButton
    Protected WithEvents txtDataAgendamento As TextBox
    Protected WithEvents txtInicial As TextBox
    Protected WithEvents txtDataFinal As TextBox
    Protected WithEvents txtDescricao As TextBox

    Protected WithEvents lblNomeObra As Label
    Private Foll As FollowUp


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

        lnkApagar.Visible = False
        If Usuario.TipoUsuario = ITC_Global.TIPO_USUARIO.MASTER Or Usuario.TipoUsuario = ITC_Global.TIPO_USUARIO.GESTOR Then
            lnkApagar.Visible = True
        End If

        If Not Page.IsPostBack Then

            ViewState("IdObra") = DeCryptography(Request("IdObra") & "")

            Dim obr As New clsObras(ViewState("IdObra"))
            lblNomeObra.Text = obr.Projeto & ""
            obr = Nothing

            BindGrid()

        End If

    End Sub

    Private Sub BindGrid()

        Foll = New FollowUp
        dtlFollowUP.DataSource = Foll.List(Usuario.IDUsuario, TIPO_CADASTRO.OBRA, ViewState("IdObra"), _
                                 txtDataAgendamento.Text, txtInicial.Text, txtDataFinal.Text, txtDescricao.Text)
        dtlFollowUP.DataBind()
        Foll = Nothing

    End Sub

    Private Sub lnkNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNovo.Click

        Response.Redirect("followupobradet.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")) & "&idfollowup=" & CryptographyEncoded("0"))

    End Sub

    Private Sub lnkApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkApagar.Click

        Foll = New FollowUp
        Foll.Excluir(Request("chkIdFollowUp") & "")
        BindGrid()
        Foll = Nothing

    End Sub

    Private Sub btnProcurar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click

        BindGrid()

    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtlFollowUP.CurrentPageIndex = e.NewPageIndex
        BindGrid()
        Foll = Nothing
    End Sub
End Class
