Public Class importacao
    Inherits XMProtectedPage
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents valRequired As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnApagar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents filArquivo As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents cboTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboFiltroTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboFiltroStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected cls As clsImportacao
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
        cls = New clsImportacao(Me)
        If Not Page.IsPostBack Then
            Dim tip As New clsTipo(Me)
            cboTipo.DataSource = tip.Listar
            cboTipo.DataBind()
            cboFiltroTipo.DataSource = tip.Listar
            cboFiltroTipo.DataBind()
            cboFiltroTipo.Items.Insert(0, New ListItem("Todos", "0"))
            tip = Nothing
            BindGrid()
            btnEnviar.Enabled = CheckPermission("Importação de Arquivos", "Enviar arquivo de importação")
            btnApagar.Enabled = CheckPermission("Importação de Arquivos", "Apagar arquivo enviado")
            dtgGrid.Columns.Item(6).Visible = CheckPermission("Importação de Arquivos", "Processar Arquivo")
        End If
    End Sub

    Public overridable Sub BindGrid()
        dtgGrid.DataSource = cls.Listar(cboFiltroTipo.SelectedItem.Value, cboFiltroStatus.SelectedItem.Value)
        dtgGrid.DataBind()
    End Sub


    Protected overridable Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        Dim arqs() As String
        arqs = Split(Request("chkSelected"), ",")
        Dim i As Integer
        For i = 0 To UBound(arqs)
            If Not Trim(arqs(i)) = "" Then
                cls.Delete(Trim(arqs(i)))
            End If
        Next
        BindGrid()
    End Sub

    Public overridable Sub dtgGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Dim strFile As String = dtgGrid.DataKeys(e.Item.ItemIndex)
        If e.CommandName = "Processar" Then
            Processa_Arquivo(strFile)
        End If
        BindGrid()
    End Sub

    Protected Overridable Sub Processa_Arquivo(ByVal vArquivo As String)
        cls.ProcessaArquivo(vArquivo)
    End Sub

    Protected Overridable Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim s1, strMessage As String
        s1 = cls.InsereArquivo(cboTipo.SelectedItem.Value)
        'If file1.PostedFile.FileName.EndsWith(".zip") = True Then
        '    file1.PostedFile.SaveAs(s1 & ".zip")
        '    strMessage = Extrair_Arquivos(s1, Importar.GetPath)
        'Else
        filArquivo.PostedFile.SaveAs(s1)
        'End If
        MostraGravado("Importacao.aspx")
    End Sub

    Protected Overridable Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        BindGrid()
    End Sub
End Class
