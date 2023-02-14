Public Class logusuarios

    Inherits XMWebPage

    Protected WithEvents dtgLogUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnProcurar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents BarraNavegacao1 As BarraNavegacao

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
            BarraNavegacao1.Visible = False
        End If

    End Sub

    Private Sub BindDataGrid()

        BarraNavegacao1.Visible = True

        Dim strUsuario As String = IIf(txtUsuario.Text.Trim = "", "NULL", "'" & txtUsuario.Text & "'")

        Dim objDataInicial As Object = txtDataInicial.Text
        If IsDate(objDataInicial) = False Then
            objDataInicial = "NULL"
        Else
            objDataInicial = "'" & Year(txtDataInicial.Text) & "-" & Month(txtDataInicial.Text) & "-" & Day(txtDataInicial.Text) & "'"
        End If

        Dim objDataFinal As Object = txtDataFinal.Text
        If IsDate(objDataFinal) = False Then
            objDataFinal = "NULL"
        Else
            objDataFinal = "'" & Year(txtDataFinal.Text) & "-" & Month(txtDataFinal.Text) & "-" & Day(txtDataFinal.Text) & "'"
        End If

        Dim dt As New DataClass()
        Dim ds As DataSet = dt.GetDataSet("SP_SE_LOG_USUARIOS " & strUsuario & "," & objDataInicial & "," & objDataFinal)
        Dim iCount As Integer = ds.Tables(0).Rows.Count

        dtgLogUsuarios.DataSource = ds
        dtgLogUsuarios.DataBind()

        With dtgLogUsuarios
            If iCount > 0 Then
                Dim strTexto As String = "Página " & (.CurrentPageIndex + 1) & " de " & .PageCount
                strTexto &= " - " & iCount & " registro" & IIf(iCount = 0, "", "s") & " retornado" & IIf(iCount = 0, "", "s")
                BarraNavegacao1.SetDescription(strTexto)
            Else
                BarraNavegacao1.SetDescription("Nenhum Registro Retornado")
            End If
        End With

    End Sub

    Private Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnProcurar.Click
        dtgLogUsuarios.CurrentPageIndex = 0
        BindDataGrid()
    End Sub

    Private Sub BarraNavegacao1_NextReg() Handles BarraNavegacao1.NextReg

        If (dtgLogUsuarios.CurrentPageIndex < (dtgLogUsuarios.PageCount - 1)) Then
            dtgLogUsuarios.CurrentPageIndex += 1
        End If
        BindDataGrid()

    End Sub

    Private Sub BarraNavegacao1_LastReg() Handles BarraNavegacao1.LastReg

        dtgLogUsuarios.CurrentPageIndex = (dtgLogUsuarios.PageCount - 1)
        BindDataGrid()

    End Sub

    Private Sub BarraNavegacao1_FirstReg() Handles BarraNavegacao1.FirstReg

        dtgLogUsuarios.CurrentPageIndex = 0
        BindDataGrid()

    End Sub

    Private Sub BarraNavegacao1_PreviousReg() Handles BarraNavegacao1.PreviousReg

        If (dtgLogUsuarios.CurrentPageIndex > 0) Then
            dtgLogUsuarios.CurrentPageIndex -= 1
        End If
        BindDataGrid()

    End Sub

End Class
