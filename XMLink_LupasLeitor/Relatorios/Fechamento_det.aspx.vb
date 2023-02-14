Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class Relatorios_Fechamento_det
    Inherits XMWebPage
    Dim rep As clsRelatorio
    Dim ds As DataSet
    Private m_ValorTotal As Double
    Private m_QtdeTotal As Integer

    Public ReadOnly Property ValorTotal() As Double
        Get
            Return m_valorTotal
        End Get
    End Property

    Public ReadOnly Property QtdeTotal() As Integer
        Get
            Return m_QtdeTotal
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
            rep = New clsRelatorio
            
            'POPULA O DATAGRID DE VENDAS POR FORMA DE PAGAMENTO (RESUMO)
            grdPagtoResumo.DataSource = GridPagamento(Request("ven"), "RESUMO")
            grdPagtoResumo.DataBind()

            'POPULA O REPEATER DE CATEGORIAS DE PRODUTOS PARA O GRID DE VENDAS (RESUMO)
            rptCategoriaProdutoResumo.DataSource = RptCategoriasProduto()
            rptCategoriaProdutoResumo.DataBind()

            'POPULA O REPEATER DE VENDEDORES QUE SERÃO EXIBIDOS NO RELATÓRIO
            rptFechamento.DataSource = rep.ListVendedoresRpt(Request("ven"), "FECHAMENTO", Request("di"), Request("df"))
            rptFechamento.DataBind()

            divResumoGeral.Visible = rptFechamento.Items.Count > 1
            divRptFechamentoEmpty.Visible = rptFechamento.Items.Count = 0

            'If rptFechamento.Items.Count > 1 Then
            '    divResumoGeral.Visible = True
            '    divRptFechamentoEmpty.Visible = False
            'Else
            '    divRptFechamentoEmpty.Visible = True
            '    divResumoGeral.Visible = False
            'End If

        End If
    End Sub

    ''' <summary>
    ''' Função que obtem uma listagem de categorias de produtos de acordo com os filtros selecionados
    ''' </summary>
    ''' <param name="vIDVendedor">Chave primária do vendedor</param>
    ''' <returns>Objeto DataReader</returns>
    Public Function RptCategoriasProduto(Optional ByVal vIDVendedor As Integer = 0) As Object
        Dim dr As IDataReader
        dr = rep.ListCategoriaRpt(Request("di"), Request("df"), vIDVendedor)
        Return dr
    End Function

    ''' <summary>
    ''' Função que obtem as informações de vendas de acordo com os filtros selecionados
    ''' </summary>
    ''' <param name="vIDCategoria">Chave primária da categoria de produto</param>
    ''' <param name="vIDVendedor">Chave primária do vendedor</param>
    ''' <param name="Tipo">Tipo de informações que serão obtidas (para o Vendedor ou para o Resumo)</param>
    ''' <returns>Objeto DataSet com informações da 1º Tabela</returns>
    Public Function GridVendas(ByVal vIDCategoria As String, ByVal vIDVendedor As String, ByVal Tipo As String) As Object
        ds = rep.GetRelatorioFechamento(Request("di"), Request("df"), Tipo, vIDVendedor, vIDCategoria)

        If ds.Tables(0).Rows.Count > 0 Then

            m_QtdeTotal = 0
            m_ValorTotal = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                m_QtdeTotal += ds.Tables(0).Rows(i).Item("QtdeProduto")
                m_ValorTotal += ds.Tables(0).Rows(i).Item("TotalProduto")
            Next

        End If

        Return ds.Tables(0)
    End Function

    ''' <summary>
    ''' Função que obtem as informações de pagamento de acordo com os filtros selecionados
    ''' </summary>
    ''' <param name="vIDVendedor">Chave primária do vendedor</param>
    ''' <param name="Tipo">Tipo de informações que serão obtidas (para o Vendedor ou para o Resumo)</param>
    ''' <returns>Objeto DataSet com informações da 2º Tabela</returns>
    Public Function GridPagamento(ByVal vIDVendedor As String, ByVal Tipo As String) As Object
        ds = rep.GetRelatorioFechamento(Request("di"), Request("df"), Tipo, vIDVendedor)

        If ds.Tables(1).Rows.Count > 0 Then

            m_ValorTotal = 0
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                m_ValorTotal += ds.Tables(1).Rows(i).Item("TotalFormaPagto")
            Next

        End If

        Return ds.Tables(1)
    End Function
End Class
