Public Class IndicesITCCad

    Inherits XMWebPage

    Protected WithEvents reqTitulo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeArquivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGravar As Button

    Private Ind As Indices

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

            Ind = New Indices(1) 'só pode ser cadastrado um índice
            With Ind
                txtDescricao.Text = .Descricao
                txtNomeArquivo.Text = .NomeImagem
            End With
            Ind = Nothing

            IIf(CheckPermission("Cadastro de Índices", "Atualizar"), btnGravar.Visible = True, btnGravar.Visible = False)

        End If

    End Sub

    Private Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Ind = New Indices
        With Ind
            .Descricao = txtDescricao.Text
            .NomeImagem = txtNomeArquivo.Text
            .Update()
        End With
        Ind = Nothing

        Gravado("indicesitccad.aspx")
    End Sub
End Class
