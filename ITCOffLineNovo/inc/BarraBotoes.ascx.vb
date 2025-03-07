Public MustInherit Class BarraBotoes

    Inherits System.Web.UI.UserControl
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents btnIncluir As Button
    Protected WithEvents btnExcluir As Button
    Protected WithEvents btnAtualizar As Button
    Protected WithEvents btnVoltar As Button
    Protected WithEvents Table2 As System.Web.UI.WebControls.Table
    Protected WithEvents TDBotaoIncluir As System.Web.UI.WebControls.TableCell
    Protected WithEvents TDBotaoApagar As System.Web.UI.WebControls.TableCell
    Protected WithEvents TDBotaoAtualizar As System.Web.UI.WebControls.TableCell
    Protected WithEvents TDBotaoVoltar As System.Web.UI.WebControls.TableCell

    Public Event Incluir()
    Public Event Excluir()
    Public Event Atualizar()
    Public Event Voltar()

    Public Enum Botoes_Ativos
        Incluir = 1
        Excluir = 2
        Atualizar = 4
        Voltar = 8
    End Enum

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

        Dim strScript As String = ""

        'strScript = "if(confirm('Deseja realmente excluir este item?')) "
        'strScript += "{" & Page.GetPostBackEventReference(Me, "excluir") & "};"
        'btnExcluir.Attributes.Add("onClick", strScript)

        'strScript = " if (typeof(Page_ClientValidate) == 'function')"
        'strScript += "{"
        'strScript += "  if(Page_ClientValidate())"
        'strScript += "  {"
        'strScript += "      if(confirm('Deseja realmente gravar?')) "
        'strScript += "      {"
        'strScript += Page.GetPostBackEventReference(Me, "gravar") & ";"
        'strScript += "      }"
        'strScript += "  }"
        'strScript += "  else "
        'strScript += "  {"
        'strScript += "  alert('Verifique os dados obrigatórios antes de gravar.');"
        'strScript += "  }"
        'strScript += "}"
        'strScript += "else"
        'strScript += "{"
        'strScript += "   if(confirm('Deseja realmente gravar?')) "
        'strScript += "   {"
        'strScript += Page.GetPostBackEventReference(Me, "gravar") & ";"
        'strScript += "   }"
        'strScript += "}"
        'btnAtualizar.Attributes.Add("onClick", strScript)

        'btnIncluir.Attributes.Add("onClick", Page.GetPostBackEventReference(Me, "incluir"))
        'btnVoltar.Attributes.Add("onClick", Page.GetPostBackEventReference(Me, "voltar"))

    End Sub

    Public Sub AtivarBotoes(ByVal Botoes As Botoes_Ativos)

        TDBotaoAtualizar.Visible = (Botoes And Botoes_Ativos.Atualizar)
        TDBotaoApagar.Visible = (Botoes And Botoes_Ativos.Excluir)
        TDBotaoIncluir.Visible = (Botoes And Botoes_Ativos.Incluir)
        TDBotaoVoltar.Visible = (Botoes And Botoes_Ativos.Voltar)

    End Sub

    Public Sub InativarBotoes(ByVal Botoes As Botoes_Ativos)

        If (Botoes And Botoes_Ativos.Atualizar) Then TDBotaoAtualizar.Visible = False
        If (Botoes And Botoes_Ativos.Excluir) Then TDBotaoApagar.Visible = False
        If (Botoes And Botoes_Ativos.Incluir) Then TDBotaoIncluir.Visible = False
        If (Botoes And Botoes_Ativos.Voltar) Then TDBotaoVoltar.Visible = False

    End Sub

    Private Sub btnAtualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtualizar.Click
        RaiseEvent Atualizar()
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        RaiseEvent Excluir()
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        RaiseEvent Incluir()
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        RaiseEvent Voltar()
    End Sub

End Class
