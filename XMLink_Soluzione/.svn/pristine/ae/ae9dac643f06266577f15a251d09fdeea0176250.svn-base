
Public Class relatorios
    Inherits XMProtectedPage
    Protected WithEvents cboRelatorio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnExibir As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents frmRelatorio As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents colDtIni As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents colDtFim As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents colVendedor As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents colMes As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents colAno As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtMes As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAno As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboVendedor As ComboBox
    Protected WithEvents valReqInicio As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valCompInicio As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents valReqFinal As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents varCompFinal As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Comparevalidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents btnImprime As System.Web.UI.WebControls.Button
    Protected WithEvents colExib As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdImprime As System.Web.UI.HtmlControls.HtmlTableCell

    Private clsVend As clsVendedor

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

    Private Sub btnExibir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExibir.Click

        BindGrid()

    End Sub

    Public Sub BindGrid()

        frmRelatorio.Attributes.Add("src", "relatorio/" & cboRelatorio.SelectedItem.Value & ".aspx?datainicio=" & Server.UrlEncode(txtDataInicial.Text) & "&datafinal=" & Server.UrlEncode(txtDataFinal.Text) & "&ven=" & Server.UrlEncode(cboVendedor.Value) & "&mes=" & Server.UrlEncode(txtMes.Text) & "&ano=" & Server.UrlEncode(txtAno.Text) & "&nome=" & Server.UrlEncode(cboVendedor.Text))

    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            If CheckPermission("Acesso do Sistema", "Visualizar Relatórios") = False Then
                Response.Redirect("principal.aspx")
            End If

            clsVend = New clsVendedor(Me)
            cboVendedor.DataSource = clsVend.Listar
            cboVendedor.DataBind()

            txtDataFinal.Text = FormatDateTime(Now, DateFormat.ShortDate)
            txtDataInicial.Text = FormatDateTime(Now.AddMonths(-1), DateFormat.ShortDate)
            txtMes.Text = Now.Month
            txtAno.Text = Now.Year

            VerificaDropDown()

        End If


    End Sub

    Private Sub VerificaDropDown()


        If cboRelatorio.SelectedItem.Value = "atendimento" Then
            colDtIni.Visible = False
            colDtFim.Visible = False
            colVendedor.Visible = True
            colMes.Visible = True
            colAno.Visible = True
        ElseIf cboRelatorio.SelectedItem.Value = "roteiro" Then
            colDtIni.Visible = False
            colDtFim.Visible = False
            colVendedor.Visible = True
            colMes.Visible = False
            colAno.Visible = False
        ElseIf cboRelatorio.SelectedItem.Value = "visitas" Then
            colDtIni.Visible = True
            colDtFim.Visible = True
            colVendedor.Visible = True
            colMes.Visible = False
            colAno.Visible = False
        ElseIf cboRelatorio.SelectedItem.Value = "status" Then
            colDtIni.Visible = True
            colDtFim.Visible = True
            colVendedor.Visible = False
            colMes.Visible = False
            colAno.Visible = False            
        Else
            colDtIni.Visible = True
            colDtFim.Visible = True
            colVendedor.Visible = False
            colMes.Visible = False
            colAno.Visible = False
        End If
        '"campanhas"
    End Sub


    Private Sub cboRelatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRelatorio.SelectedIndexChanged

        VerificaDropDown()

        If cboRelatorio.SelectedValue = "atendimento" Or cboRelatorio.SelectedValue = "roteiro" Or cboRelatorio.SelectedValue = "visitas" Then
            tdImprime.Visible = True
        Else
            tdImprime.Visible = False
        End If

        BindGrid()

    End Sub
End Class
