Imports ITCOffLine
Imports System.Data

Public Class ProcurarEmpresaContato
    Inherits System.Web.UI.Page
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents Table2 As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnProcurar As System.Web.UI.WebControls.Button
    Protected WithEvents dtgEmpresas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal
    Protected WithEvents txtBusca As System.Web.UI.WebControls.TextBox
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
            BarraNavegacao1.SetDescription("Nenhum Registro Retornado")
        End If
    End Sub

    Public Sub SelItemProg(ByVal src As Object, ByVal e As DataGridCommandEventArgs)

        dtgEmpresas.SelectedIndex = e.Item.ItemIndex


        Dim strJavaScript As String = "<script language=""javascript"">" & vbCrLf
        strJavaScript += "window.opener.frmCad.hdIdEmpresa.value = " & dtgEmpresas.DataKeys.Item(dtgEmpresas.SelectedIndex) & ";" & vbCrLf
        strJavaScript += "window.opener.frmCad.lblFantasia.value = '" & dtgEmpresas.Items(dtgEmpresas.SelectedIndex).Cells(1).Text & "';" & vbCrLf
        strJavaScript += "window.close();"
        strJavaScript += "</script>"

        Literal1.Text = strJavaScript

    End Sub

    Private Sub BindGrid()
        Dim Emp As New clsEmpresas(0)
        Dim ds As DataSet = Emp.List(ViewState("Busca"), "", "", "", 1, 3)
        Dim iCount As Integer = ds.Tables(0).Rows.Count
        dtgEmpresas.DataSource = ds
        dtgEmpresas.DataBind()
        With dtgEmpresas
            If iCount > 0 Then
                Dim strTexto As String = "Página " & (.CurrentPageIndex + 1) & " de " & .PageCount
                strTexto &= " - " & iCount & " registro" & IIf(iCount = 0, "", "s") & " retornado" & IIf(iCount = 0, "", "s")
                BarraNavegacao1.SetDescription(strTexto)
            Else
                BarraNavegacao1.SetDescription("Nenhum Registro Retornado")
            End If
        End With
        Emp = Nothing
    End Sub

    Private Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        If txtBusca.Text.Trim <> "" Then
            ViewState("Busca") = txtBusca.Text
            BindGrid()
        End If
    End Sub

    Private Sub BarraNavegacao1_NextReg() Handles BarraNavegacao1.NextReg
        If (dtgEmpresas.CurrentPageIndex < (dtgEmpresas.PageCount - 1)) Then
            dtgEmpresas.CurrentPageIndex += 1
        End If
        BindGrid()
    End Sub

    Private Sub BarraNavegacao1_LastReg() Handles BarraNavegacao1.LastReg
        dtgEmpresas.CurrentPageIndex = (dtgEmpresas.PageCount - 1)
        BindGrid()
    End Sub

    Private Sub BarraNavegacao1_FirstReg() Handles BarraNavegacao1.FirstReg
        dtgEmpresas.CurrentPageIndex = 0
        BindGrid()
    End Sub

    Private Sub BarraNavegacao1_PreviousReg() Handles BarraNavegacao1.PreviousReg
        If (dtgEmpresas.CurrentPageIndex > 0) Then
            dtgEmpresas.CurrentPageIndex -= 1
        End If
        BindGrid()
    End Sub

End Class
