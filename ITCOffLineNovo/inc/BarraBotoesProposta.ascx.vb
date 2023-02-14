Public MustInherit Class BarraBotoesProposta

    Inherits System.Web.UI.UserControl
    Implements IPostBackEventHandler
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents btnIncluir As System.Web.UI.WebControls.Image
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Image
    Protected WithEvents btnAtualizar As System.Web.UI.WebControls.Image
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Image
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

        strScript = "if(confirm('Deseja realmente excluir este item?')) "
        strScript += "{" & Page.GetPostBackEventReference(Me, "excluir") & "};"
        btnExcluir.Attributes.Add("onClick", strScript)

        strScript = " if (typeof(Page_ClientValidate) == 'function')"
        strScript += "{"
        strScript += "  if(Page_ClientValidate())"
        strScript += "  {"
        strScript += "      if(confirm('Deseja realmente gravar?')) "
        strScript += "      {"
        strScript += Page.GetPostBackEventReference(Me, "gravar") & ";"
        strScript += "      }"
        strScript += "  }"
        strScript += "  else "
        strScript += "  {"
        strScript += "  alert('Verifique os dados obrigatórios antes de gravar.');"
        strScript += "  }"
        strScript += "}"
        strScript += "else"
        strScript += "{"
        strScript += "   if(confirm('Deseja realmente gravar?')) "
        strScript += "   {"
        strScript += Page.GetPostBackEventReference(Me, "gravar") & ";"
        strScript += "   }"
        strScript += "}"
        btnAtualizar.Attributes.Add("onClick", strScript)

        btnIncluir.Attributes.Add("onClick", Page.GetPostBackEventReference(Me, "incluir"))
        btnVoltar.Attributes.Add("onClick", Page.GetPostBackEventReference(Me, "voltar"))

    End Sub

    Public Function AtivarBotoes(ByVal Botoes As Botoes_Ativos) As Boolean

        TDBotaoAtualizar.Visible = (Botoes And Botoes_Ativos.Atualizar)
        TDBotaoApagar.Visible = (Botoes And Botoes_Ativos.Excluir)
        TDBotaoIncluir.Visible = (Botoes And Botoes_Ativos.Incluir)
        TDBotaoVoltar.Visible = (Botoes And Botoes_Ativos.Voltar)

    End Function

    Public Function InativarBotoes(ByVal Botoes As Botoes_Ativos) As Boolean

        If (Botoes And Botoes_Ativos.Atualizar) Then TDBotaoAtualizar.Visible = False
        If (Botoes And Botoes_Ativos.Excluir) Then TDBotaoApagar.Visible = False
        If (Botoes And Botoes_Ativos.Incluir) Then TDBotaoIncluir.Visible = False
        If (Botoes And Botoes_Ativos.Voltar) Then TDBotaoVoltar.Visible = False

    End Function


    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
        If eventArgument = "excluir" Then
            RaiseEvent Excluir()
        ElseIf eventArgument = "gravar" Then
            RaiseEvent Atualizar()
        ElseIf eventArgument = "incluir" Then
            RaiseEvent Incluir()
        ElseIf eventArgument = "voltar" Then
            RaiseEvent Voltar()
        End If
    End Sub
End Class
