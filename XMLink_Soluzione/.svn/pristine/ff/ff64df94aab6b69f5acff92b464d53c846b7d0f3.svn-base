Public MustInherit Class BarraBotoes

    Inherits System.Web.UI.UserControl
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents btnIncluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnAtualizar As System.Web.UI.WebControls.Button
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Button

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
        Page.RegisterHiddenField("__EVENTTARGET", "btnAtualizar")
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        RaiseEvent Incluir()
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        RaiseEvent Excluir()
    End Sub

    Private Sub btnAtualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtualizar.Click
        RaiseEvent Atualizar()
    End Sub

    Public Function AtivarBotoes(ByVal Botoes As Botoes_Ativos) As Boolean

        'btnAtualizar.Enabled = False
        'btnExcluir.Enabled = False
        'btnIncluir.Enabled = False
        'btnVoltar.Enabled = False

        btnAtualizar.Enabled = (Botoes And Botoes_Ativos.Atualizar)
        btnExcluir.Enabled = (Botoes And Botoes_Ativos.Excluir)
        btnIncluir.Enabled = (Botoes And Botoes_Ativos.Incluir)
        btnVoltar.Enabled = (Botoes And Botoes_Ativos.Voltar)

        'Select Case Botoes
        '    Case Botoes_Ativos.Atualizar
        '        btnAtualizar.Enabled = True
        '    Case Botoes_Ativos.Excluir
        '        btnExcluir.Enabled = True
        '    Case Botoes_Ativos.Incluir
        '        btnIncluir.Enabled = True
        '    Case Botoes_Ativos.Atualizar + Botoes_Ativos.Excluir
        '        btnAtualizar.Enabled = True
        '        btnExcluir.Enabled = True
        '    Case Botoes_Ativos.Excluir + Botoes_Ativos.Incluir
        '        btnExcluir.Enabled = True
        '        btnIncluir.Enabled = True
        '    Case Botoes_Ativos.Incluir + Botoes_Ativos.Atualizar
        '        btnIncluir.Enabled = True
        '        btnAtualizar.Enabled = True
        '    Case Botoes_Ativos.Incluir + Botoes_Ativos.Atualizar + Botoes_Ativos.Excluir
        '        btnAtualizar.Enabled = True
        '        btnExcluir.Enabled = True
        '        btnIncluir.Enabled = True
        'End Select
    End Function

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        RaiseEvent Voltar()
    End Sub
End Class
