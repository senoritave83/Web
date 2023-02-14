Public Class ControleVendEmp

    Inherits XMWebPage

    Protected WithEvents dtgFollowUP As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtEmpresa As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As HtmlInputButton
    Protected WithEvents btnNovoFollowup As HtmlInputButton
    Protected WithEvents tblResult As HtmlTable
    Protected WithEvents BarraNavegacao1 As BarraNavegacao
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
        If Not Page.IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()

        tblResult.Visible = False

        Foll = New FollowUp
        Dim ds As DataSet = Foll.ListarOrigensFollowUp(Usuario.IDUsuario, TIPO_CADASTRO.EMPRESA, txtEmpresa.Text, Me.Usuario.IdEmpresa, "")
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                dtgFollowUP.DataSource = ds
                dtgFollowUP.DataBind()
                tblResult.Visible = True
            End If
        End If
        Foll = Nothing

    End Sub

    Private Sub BarraNavegacao1_NextReg() Handles BarraNavegacao1.NextReg
        If (dtgFollowUP.CurrentPageIndex < (dtgFollowUP.PageCount - 1)) Then
            dtgFollowUP.CurrentPageIndex += 1
        End If
        BindGrid()
    End Sub

    Private Sub BarraNavegacao1_LastReg() Handles BarraNavegacao1.LastReg
        dtgFollowUP.CurrentPageIndex = (dtgFollowUP.PageCount - 1)
        BindGrid()
    End Sub

    Private Sub BarraNavegacao1_FirstReg() Handles BarraNavegacao1.FirstReg
        dtgFollowUP.CurrentPageIndex = 0
        BindGrid()
    End Sub

    Private Sub BarraNavegacao1_PreviousReg() Handles BarraNavegacao1.PreviousReg
        If (dtgFollowUP.CurrentPageIndex > 0) Then
            dtgFollowUP.CurrentPageIndex -= 1
        End If
        BindGrid()
    End Sub

    Private Sub btnProcurar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.ServerClick
        dtgFollowUP.CurrentPageIndex = 0
        BindGrid()
    End Sub
End Class
