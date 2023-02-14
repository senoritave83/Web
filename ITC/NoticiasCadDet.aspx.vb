Public Class NoticiasCadDet

    Inherits XMWebPage

    Protected WithEvents reqTitulo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTitulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqData As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtData As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtReportagem As System.Web.UI.WebControls.TextBox
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnIncluir As Button
    Protected WithEvents btnGravar As Button
    Protected WithEvents btnApagar As Button

    Private clsNot As Noticia

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

            Dim objIdNoticia As Object = DeCryptography(Request("IdNoticia"))
            If IsNumeric(objIdNoticia) Then
                ViewState("IdNoticia") = objIdNoticia
            Else
                ViewState("IdNoticia") = 0
            End If

            clsNot = New Noticia(ViewState("IdNoticia"))
            Inflate()
            clsNot = Nothing

            IIf(CheckPermission("Cadastro de Noticias", "Adicionar"), btnIncluir.Visible = True, btnIncluir.Visible = False)
            IIf(CheckPermission("Cadastro de Noticias", "Atualizar"), btnGravar.Visible = True, btnGravar.Visible = False)
            IIf(CheckPermission("Cadastro de Noticias", "Apagar"), btnApagar.Visible = True, btnApagar.Visible = False)

        End If

    End Sub

    Private Sub Inflate()
        With clsNot
            txtTitulo.Text = .Titulo
            txtData.Text = .Data
            txtReportagem.Text = .Reportagem
        End With
    End Sub

    Private Sub Deflate()
        With clsNot
            .Titulo = txtTitulo.Text
            .Data = txtData.Text
            .Reportagem = txtReportagem.Text
        End With
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click

        clsNot = New Noticia
        If clsNot.Delete(ViewState("IdNoticia")) = True Then
            Response.Redirect("noticiascad.aspx")
        Else
            ShowErro("Não foi possível excluir esta notícias")
        End If

    End Sub

    Private Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        clsNot = New Noticia(ViewState("IdNoticia"))
        Deflate()
        clsNot.Update()
        Gravado("noticiascaddet.aspx?idnoticia=" & CryptographyEncoded(clsNot.IdNoticia))
        clsNot = Nothing

    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click

        Response.Redirect("noticiascaddet.aspx?idnoticia=" & CryptographyEncoded("0"))

    End Sub
End Class
