Public Class ControleAssociadosAcesso

    Inherits XMWebPage

    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAssociado As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPesquisar As Button
    Protected WithEvents dtgResultados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnNovaPesquisa As Button
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblResultados As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents nav As BarraNavegacao
    Protected WithEvents tblNav As HtmlTable
    Protected WithEvents cboOrdenar As ComboBox
    Protected WithEvents cboStatus As System.Web.UI.WebControls.DropDownList

    Private Controle As New clsControleAcessos()

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

            tblNav.Visible = False

            With cboOrdenar
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(1, "ASSOCIADO")
                .AddItem(2, "DIAS SEM ACESSO")
            End With

            Dim Sta As New clsStatus
            With cboStatus
                .CssClass = "f8"
                .DataSource = Sta.ListStatus
                .DataBind()
            End With

        End If

    End Sub

    Sub BindGrid()

        Controle = New clsControleAcessos
        dtgResultados.DataSource = Controle.PesquisarSemAcesso(txtDataInicio.Text, txtDataFim.Text, Usuario.IdEmpresa, txtAssociado.Text, cboOrdenar.Value, cboStatus.SelectedItem.Value)
        dtgResultados.DataBind()
        nav.SetDescription("")
        Controle = Nothing

    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgResultados.CurrentPageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Private Sub nav_NextReg() Handles nav.NextReg
        If (dtgResultados.CurrentPageIndex < (dtgResultados.PageCount - 1)) Then
            dtgResultados.CurrentPageIndex += 1
        End If

        BindGrid()

    End Sub

    Private Sub nav_LastReg() Handles nav.LastReg
        dtgResultados.CurrentPageIndex = (dtgResultados.PageCount - 1)

        BindGrid()

    End Sub

    Private Sub nav_FirstReg() Handles nav.FirstReg
        dtgResultados.CurrentPageIndex = 0

        BindGrid()

    End Sub

    Private Sub nav_PreviousReg() Handles nav.PreviousReg
        If (dtgResultados.CurrentPageIndex > 0) Then
            dtgResultados.CurrentPageIndex -= 1
        End If

        BindGrid()

    End Sub

    Private Sub btnNovaPesquisa_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaPesquisa.Click

        Response.Redirect("controleassociadosacesso.aspx")

    End Sub

    Private Sub btnPesquisar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click

        BindGrid()
        tblNav.Visible = True

    End Sub
End Class
