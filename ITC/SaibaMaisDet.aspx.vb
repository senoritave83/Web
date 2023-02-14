Public Class SaibaMaisDet

    Inherits XMWebPage

    Protected WithEvents reqImagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtImagem As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblImagem As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkAtivo As CheckBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnIncluir As Button
    Protected WithEvents btnGravar As Button
    Protected WithEvents btnApagar As Button
    Protected WithEvents txtLink As TextBox
    Protected WithEvents spSize As System.Web.UI.WebControls.Label
    Private SaibaMais As clsSaibaMais

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

            Dim objIdSaibaMais As Object = Request("IdSaibaMais")
            If IsNumeric(objIdSaibaMais) Then
                ViewState("IdSaibaMais") = objIdSaibaMais
            Else
                ViewState("IdSaibaMais") = 0
            End If

            SaibaMais = New clsSaibaMais(ViewState("IdSaibaMais"))
            Inflate()
            If SaibaMais.IdSaibaMais > 0 Then reqImagem.Enabled = False
            SaibaMais = Nothing

            IIf(CheckPermission("Cadastro de SaibaMais", "Adicionar"), btnIncluir.Visible = False, btnIncluir.Visible = True)
            IIf(CheckPermission("Cadastro de SaibaMais", "Atualizar"), btnGravar.Visible = False, btnGravar.Visible = True)
            IIf(CheckPermission("Cadastro de SaibaMais", "Apagar"), btnApagar.Visible = False, btnApagar.Visible = True)

        End If

    End Sub

    Private Sub Inflate()
        With SaibaMais
            lblImagem.ReadOnly = False
            lblImagem.Text = .Imagem
            lblImagem.ReadOnly = True
            txtDescricao.Text = .Descricao
            chkAtivo.Checked = .IdStatus
            txtLink.Text = .Link
        End With
    End Sub

    Private Sub Deflate()
        With SaibaMais

            .Imagem = lblImagem.Text
            .Descricao = txtDescricao.Text
            .Link = txtLink.Text

            Dim m_Ativo As Integer
            If chkAtivo.Checked = True Then
                m_Ativo = 1
            Else
                m_Ativo = 0
            End If

            .IdStatus = m_Ativo
        End With
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        SaibaMais = New clsSaibaMais
        If SaibaMais.Delete(ViewState("IdSaibaMais")) = True Then
            Response.Redirect("SaibaMais.aspx")
        Else
            ShowErro("Não foi possível excluir este SaibaMais")
        End If
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Response.Redirect("SaibaMaisDet.aspx?IdSaibaMais=" & 0)
    End Sub

    Private Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        If Not txtImagem.PostedFile Is Nothing And txtImagem.PostedFile.ContentLength > 0 Then

            Dim fn As String = System.IO.Path.GetFileName(txtImagem.PostedFile.FileName)
            If fn <> "" Then
                lblImagem.ReadOnly = False
                lblImagem.Text = fn
            End If
            Dim SaveLocation As String = Server.MapPath("~/imagens/saibamais") & "\" & fn
            Try
                txtImagem.PostedFile.SaveAs(SaveLocation)
            Catch Exc As Exception
                Response.Write("Error: " & Exc.Message)
            End Try
        End If


        SaibaMais = New clsSaibaMais(ViewState("IdSaibaMais"))
        Deflate()
        SaibaMais.Update()
        Gravado("SaibaMaisDet.aspx?IdSaibaMais=" & SaibaMais.IdSaibaMais)
        SaibaMais = Nothing
    End Sub
End Class
