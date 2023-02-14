Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class Relatorios_produtos
    Inherits XMWebPage
    Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todos os Pedidos"
    Private m_EstoqueTotal As Integer
    Private m_QtdeVendidaTotal As Integer
    Private m_QtdePorDiaTotal As Double
    Private m_PrevEstoqueTotal As Double

    Public ReadOnly Property EstoqueTotal() As Integer
        Get
            Return m_EstoqueTotal
        End Get
    End Property

    Public ReadOnly Property QtdeVendidaTotal() As Integer
        Get
            Return m_QtdeVendidaTotal
        End Get
    End Property

    Public ReadOnly Property QtdePorDiaTotal() As Double
        Get
            Return m_QtdePorDiaTotal
        End Get
    End Property

    Public ReadOnly Property PrevEstoqueTotal() As Double
        Get
            Return m_PrevEstoqueTotal
        End Get
    End Property

    'Evento que verifica se o usuário solicitou a impressão dos dados e altera a Master Page.
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Request("print") Is Nothing Then
            Me.MasterPageFile = "~/Relatorios/Imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim cat As New clsCategoria
            rptCategorias.DataSource = cat.Listar()
            rptCategorias.DataBind()

        End If
    End Sub

    Protected Function getProdutos(ByVal vIdCategoria As String) As DataSet

        Dim rep As New clsRelatorio
        Dim ds As DataSet = Nothing
        If VerificaPermissao("Pedidos", ACAO_VISUALIZAR_TODOS) Then
            ds = rep.GetRelatorioProdutos(Request("di"), Request("df"), CInt(vIdCategoria))
        Else
            ds = rep.GetRelatorioProdutos(Request("di"), Request("df"), CInt(vIdCategoria), Me.User.IDUser)
        End If
        rep = Nothing

        If ds.Tables(0).Rows.Count > 0 Then

            m_EstoqueTotal = 0
            m_QtdeVendidaTotal = 0
            m_QtdePorDiaTotal = 0
            m_PrevEstoqueTotal = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                m_EstoqueTotal += ds.Tables(0).Rows(i).Item("Estoque")
                m_QtdeVendidaTotal += ds.Tables(0).Rows(i).Item("Qtd_Vendida")
                m_QtdePorDiaTotal += ds.Tables(0).Rows(i).Item("Media_dia")
                m_PrevEstoqueTotal += ds.Tables(0).Rows(i).Item("Dias_Coberto")
            Next

        End If

        Return ds

    End Function
End Class
