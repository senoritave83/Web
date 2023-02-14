Public Class BarraBotoes2
    Inherits System.Web.UI.UserControl

    Public Event Incluir()
    Public Event Excluir()
    Public Event Gravar()
    Public Event Voltar()


    Public Enum Botoes_Ativos
        Incluir = 1
        Excluir = 2
        Atualizar = 4
        Voltar = 8
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        RaiseEvent Gravar()
    End Sub

    Protected Sub btn_Voltar_Click(sender As Object, e As EventArgs) Handles btn_Voltar.Click
        RaiseEvent Voltar()
    End Sub

    Protected Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        RaiseEvent Incluir()
    End Sub

    Protected Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        RaiseEvent Excluir()
    End Sub


    Public Sub AtivarBotoes(ByVal Botoes As Botoes_Ativos)

        TDBotaoGravar.Visible = (Botoes And Botoes_Ativos.Atualizar)
        TDBotaoExcluir.Visible = (Botoes And Botoes_Ativos.Excluir)
        TDBotaoIncluir.Visible = (Botoes And Botoes_Ativos.Incluir)
        TDBotaoVoltar.Visible = (Botoes And Botoes_Ativos.Voltar)

    End Sub

    Public Sub InativarBotoes(ByVal Botoes As Botoes_Ativos)

        If (Botoes And Botoes_Ativos.Atualizar) Then TDBotaoGravar.Visible = False
        If (Botoes And Botoes_Ativos.Excluir) Then TDBotaoExcluir.Visible = False
        If (Botoes And Botoes_Ativos.Incluir) Then TDBotaoIncluir.Visible = False
        If (Botoes And Botoes_Ativos.Voltar) Then TDBotaoVoltar.Visible = False

    End Sub

End Class