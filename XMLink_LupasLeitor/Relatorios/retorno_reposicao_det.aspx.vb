Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class Relatorios_retorno_reposicao_det
    Inherits XMWebPage
    'Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todos os consignados"

    'Evento que verifica se o usuário solicitou a impressão dos dados e altera a Master Page.
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Request("print") Is Nothing Then
            Me.MasterPageFile = "~/Relatorios/Imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim rep As New clsRelatorio
            'Dim dr As SqlDataReader = Nothing
            'If VerificaPermissao("consignado", ACAO_VISUALIZAR_TODOS) Then
            '    dr = rep.GetRelatorioRetornoReposicao(Request("di"), Request("df"), Request("ven"))
            'Else
            '    dr = rep.GetRelatorioRetornoReposicao(Request("di"), Request("df"), Request("ven"), Me.User.IDUser)
            'End If

            grdRelatorio.DataSource = rep.GetRelatorioRetornoReposicao(Request("di"), Request("df"), CInt(Request("acao")), Request("ven"))
            grdRelatorio.DataBind()

            rep = Nothing

        End If
    End Sub

End Class
