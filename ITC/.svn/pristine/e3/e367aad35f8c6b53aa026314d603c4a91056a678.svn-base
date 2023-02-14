Public Class EventosCadDet

    Inherits XMWebPage

    Protected WithEvents reqTitulo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTitulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqDataInicial As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents reqDataFinal As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescricaoEvento As System.Web.UI.WebControls.TextBox
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqDescricaoEvento As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnIncluir As Button
    Protected WithEvents btnGravar As Button
    Protected WithEvents btnApagar As Button

    Private clsEventos As Evento

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

            Dim objIdEvento As Object = DeCryptography(Request("IdEvento"))
            If IsNumeric(objIdEvento) Then
                ViewState("IdEvento") = objIdEvento
            Else
                ViewState("IdEvento") = 0
            End If

            clsEventos = New Evento(ViewState("IdEvento"))
            Inflate()
            clsEventos = Nothing

            IIf(CheckPermission("Cadastro de Eventos", "Adicionar"), btnIncluir.Visible = True, btnIncluir.Visible = False)
            IIf(CheckPermission("Cadastro de Eventos", "Atualizar"), btnGravar.Visible = True, btnGravar.Visible = False)
            IIf(CheckPermission("Cadastro de Eventos", "Apagar"), btnApagar.Visible = True, btnApagar.Visible = False)

        End If

    End Sub

    Private Sub Inflate()
        With clsEventos
            txtTitulo.Text = .Titulo
            txtDataInicial.Text = .DataInicial
            txtDataFinal.Text = .DataFinal
            txtDescricaoEvento.Text = .DescricaoEvento.Replace("<BR>", vbCrLf)
        End With
    End Sub

    Private Sub Deflate()
        With clsEventos
            .Titulo = txtTitulo.Text
            .DataInicial = txtDataInicial.Text
            .DataFinal = txtDataFinal.Text
            .DescricaoEvento = txtDescricaoEvento.Text.Replace(vbCrLf, "<BR>")
        End With
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        clsEventos = New Evento
        If clsEventos.Delete(ViewState("IdEvento")) = True Then
            Page.Response.Redirect("eventoscad.aspx")
        Else
            ShowErro("Não foi possível excluir este evento")
        End If
    End Sub

    Private Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        clsEventos = New Evento
        Deflate()
        clsEventos.Update()
        Gravado("eventoscaddet.aspx?idevento=" & CryptographyEncoded(clsEventos.IdEvento))
        clsEventos = Nothing
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Response.Redirect("eventoscaddet.aspx?idevento=" & CryptographyEncoded("0"))
    End Sub
End Class
