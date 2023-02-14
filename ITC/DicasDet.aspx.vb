Public Class DicasDet

    Inherits XMWebPage

    Protected WithEvents reqTitulo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTitulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqData As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtReportagem As System.Web.UI.WebControls.TextBox
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnIncluir As Button
    Protected WithEvents btnGravar As Button
    Protected WithEvents btnApagar As Button
    Private Dica As Dica

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

            Dim objIdDica As Object = DeCryptography(Request("IdDica"))
            If IsNumeric(objIdDica) Then
                ViewState("IdDica") = objIdDica
            Else
                ViewState("IdDica") = 0
            End If

            Dica = New Dica(ViewState("IdDica"))
            Inflate()
            Dica = Nothing

            IIf(CheckPermission("Cadastro de Dica", "Adicionar"), btnIncluir.Visible = False, btnIncluir.Visible = True)
            IIf(CheckPermission("Cadastro de Dica", "Atualizar"), btnGravar.Visible = False, btnGravar.Visible = True)
            'IIf(CheckPermission("Cadastro de Dica", "Apagar"), btnApagar.Visible = False, btnApagar.Visible = True)
            btnApagar.Visible = False

        End If

    End Sub

    Private Sub Inflate()
        With Dica
            txtTitulo.Text = .Titulo
            lblStatus.Text = .IdStatus
            txtReportagem.Text = .Descricao
        End With
    End Sub

    Private Sub Deflate()
        With Dica
            .Titulo = txtTitulo.Text
            .Descricao = txtReportagem.Text
        End With
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        Dica = New Dica
        If Dica.Delete(ViewState("IdDica")) = True Then
            Response.Redirect("dicas.aspx")
        Else
            ShowErro("Não foi possível excluir este Dica")
        End If
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Response.Redirect("dicasdet.aspx?iddica=" & CryptographyEncoded("0"))
    End Sub

    Private Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dica = New Dica(ViewState("IdDica"))
        Deflate()
        Dica.Update()
        Gravado("dicasdet.aspx?idDica=" & CryptographyEncoded(Dica.IdDica))
        Dica = Nothing
    End Sub
End Class
