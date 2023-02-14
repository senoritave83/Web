Public Class CUBCadDet

    Inherits XMWebPage

    Protected WithEvents reqTitulo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTitulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqData As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtData As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReportagem As System.Web.UI.WebControls.TextBox
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnIncluir As Button
    Protected WithEvents btnGravar As Button
    Protected WithEvents btnApagar As Button
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Private cub As clsCUB

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

            Dim objIdCUB As Object = DeCryptography(Request("IdCUB"))
            If IsNumeric(objIdCUB) Then
                ViewState("IdCUB") = objIdCUB
            Else
                ViewState("IdCUB") = 0
            End If

            cub = New clsCUB(ViewState("IdCUB"))
            Inflate()
            cub = Nothing

            IIf(CheckPermission("Cadastro de CUB", "Adicionar"), btnIncluir.Visible = True, btnIncluir.Visible = False)
            IIf(CheckPermission("Cadastro de CUB", "Atualizar"), btnGravar.Visible = True, btnGravar.Visible = False)
            IIf(CheckPermission("Cadastro de CUB", "Apagar"), btnApagar.Visible = True, btnApagar.Visible = False)

        End If

    End Sub

    Private Sub Inflate()
        With cub
            txtTitulo.Text = .Titulo
            txtData.Text = .Data
            txtReportagem.Text = .Descricao
        End With
    End Sub

    Private Sub Deflate()
        With cub
            .Titulo = txtTitulo.Text
            .Data = txtData.Text
            .Descricao = txtReportagem.Text
        End With
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click

        cub = New clsCUB
        If cub.Delete(ViewState("IdCUB")) = True Then
            Response.Redirect("cubcad.aspx")
        Else
            ShowErro("Não foi possível excluir este CUB")
        End If
    End Sub

    Private Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        cub = New clsCUB(ViewState("IdCUB"))
        Deflate()
        cub.Update()
        Gravado("cubcaddet.aspx?idcub=" & CryptographyEncoded(cub.IdCUB))
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Response.Redirect("cubcaddet.aspx?idcub=" & CryptographyEncoded("0"))
    End Sub
End Class
