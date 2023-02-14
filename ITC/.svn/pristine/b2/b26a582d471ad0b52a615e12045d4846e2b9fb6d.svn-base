Public Class PesquisaTabelaAtividadesEmpresa
    Inherits XMWebPage
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgAtividadesEmpresa As System.Web.UI.WebControls.DataGrid

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
            BindAtividades()
        End If
    End Sub

    Private Sub BindAtividades()
        Dim Ativ As New clsAtividades()
        With dtgAtividadesEmpresa

            Dim ds As DataSet = Ativ.ListAtividadesTabela
            Dim iCount As Integer = ds.Tables(0).Rows.Count
            .DataSource = ds
            .DataBind()

            'If iCount > 0 Then
            '    Dim strTexto As String = "Página " & (.CurrentPageIndex + 1) & " de "
            '    If iCount Mod .PageSize > 0 Then
            '        strTexto &= CInt((iCount / .PageSize) + 1)
            '    Else
            '        strTexto &= iCount
            '    End If
            '    strTexto &= " - " & iCount & " registro" & IIf(iCount = 0, "", "s") & " retornado" & IIf(iCount = 0, "", "s")
            '    BarraNavAtividadesEmpresa.SetDescription(strTexto)
            'Else
            '    BarraNavAtividadesEmpresa.SetDescription("Nenhum Registro Retornado")
            'End If

        End With

        Ativ = Nothing
    End Sub

    'Private Sub BarraNavAtividadesEmpresa_NextReg() Handles BarraNavAtividadesEmpresa.NextReg
    '    If (dtgAtividadesEmpresa.CurrentPageIndex < (dtgAtividadesEmpresa.PageCount - 1)) Then
    '        dtgAtividadesEmpresa.CurrentPageIndex += 1
    '    End If
    '    BindAtividades()
    'End Sub

    'Private Sub BarraNavAtividadesEmpresa_LastReg() Handles BarraNavAtividadesEmpresa.LastReg
    '    dtgAtividadesEmpresa.CurrentPageIndex = (dtgAtividadesEmpresa.PageCount - 1)
    '    BindAtividades()
    'End Sub

    'Private Sub BarraNavAtividadesEmpresa_FirstReg() Handles BarraNavAtividadesEmpresa.FirstReg
    '    dtgAtividadesEmpresa.CurrentPageIndex = 0
    '    BindAtividades()
    'End Sub

    'Private Sub BarraNavAtividadesEmpresa_PreviousReg() Handles BarraNavAtividadesEmpresa.PreviousReg
    '    If (dtgAtividadesEmpresa.CurrentPageIndex > 0) Then
    '        dtgAtividadesEmpresa.CurrentPageIndex -= 1
    '    End If
    '    BindAtividades()
    'End Sub

End Class
