Imports System.Data.SqlClient

#Region "Enumerators"

Public Enum enVisualizaEstoque
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enVendaSEstoque
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enDigitaObservacao
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enDigitaPreco
    Nao = 0
    Sim = 1
    Percentual = 2
End Enum 'OK


Public Enum enDigitaDataEntrega
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enBuscaProduto
    BuscaPorNome = 0
    BuscaPorCodigo = 1
End Enum 'OK

Public Enum enEntradaProduto
    BuscaPorNome = 0
    BuscaPorCodigo = 1
End Enum 'OK

Public Enum enFiltrarPorCategoria
    Nao = 0
    Sim = 1
End Enum

Public Enum enBuscaCliente
    BuscaPorNome = 0
    BuscaPorCodigo = 1
End Enum 'OK

Public Enum enDigitaDesconto
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enExibeDadosCliente
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enExibeTotalPedidos
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enSenhaNumerica
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enCodigoProdutoNumerico
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enCodigoClienteNumerico
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enVendaDescontoExcedente
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enMostraItensResumo
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enVendaClienteOutroVendedor
    Nao = 0
    Sim = 1
End Enum 'OK

Public Enum enConsiderarLimiteCredito
    Nao = 0
    Sim = 1
End Enum 'OK

#End Region


Public Class clsSettings
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

#Region "PROTECTED FUNCTIONS"

    Protected Function GetXMSetting(ByVal vKey As String, ByVal vDefault As Object) As Object
        Dim ds As DataSet
        ds = GetDataSet(PREFIXO & "SE_SETTING " & XMPage.IDEmpresa & ", '" & vKey.Replace("'", "''") & "'")
        If ds.Tables(0).Rows.Count = 0 Then
            GetXMSetting = vDefault
        Else
            GetXMSetting = ds.Tables(0).Rows(0).Item(1)
        End If
    End Function

    Protected Sub SAveXMSetting(ByVal vKey As String, ByVal Value As String)
        Dim cmd As New SqlCommand
        Dim cn As New SqlConnection(XMPage.Application("cnStr"))
        cn.Open()
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = PREFIXO & "SV_SETTING " & XMPage.IDEmpresa & ", '" & vKey.Replace("'", "''") & "', '" & Value.Replace("'", "''") & "'"
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd = Nothing
        cn = Nothing
    End Sub
#End Region


#Region "PUBLIC PROPERTIES"

    Public Property BuscaCliente() As enBuscaCliente
        Get
            Return GetXMSetting("BuscaCliente", enBuscaCliente.BuscaPorNome)
        End Get
        Set(ByVal Value As enBuscaCliente)
            SAveXMSetting("BuscaCliente", Value)
        End Set
    End Property

    Public Property ConsiderarLimiteCredito() As enConsiderarLimiteCredito
        Get
            Return GetXMSetting("ConsiderarLimiteCredito", enConsiderarLimiteCredito.Nao)
        End Get
        Set(ByVal Value As enConsiderarLimiteCredito)
            SAveXMSetting("ConsiderarLimiteCredito", Value)
        End Set
    End Property

    Public Property BuscaProduto() As enBuscaProduto
        Get
            Return GetXMSetting("BuscaProduto", enBuscaProduto.BuscaPorNome)
        End Get
        Set(ByVal Value As enBuscaProduto)
            SAveXMSetting("BuscaProduto", Value)
        End Set
    End Property

    Public Property ExibeDadosCliente() As enExibeDadosCliente
        Get
            Return GetXMSetting("ExibeDadosCliente", enExibeDadosCliente.Sim)
        End Get
        Set(ByVal Value As enExibeDadosCliente)
            SAveXMSetting("ExibeDadosCliente", Value)
        End Set
    End Property

    Public Property ExibeTotalPedidos() As enExibeTotalPedidos
        Get
            Return GetXMSetting("ExibeTotalPedidos", enExibeTotalPedidos.Sim)
        End Get
        Set(ByVal Value As enExibeTotalPedidos)
            SAveXMSetting("ExibeTotalPedidos", Value)
        End Set
    End Property

    Public Property ItemsPerPage() As Integer
        Get
            Return GetXMSetting("ItemsPerPage", 10)
        End Get
        Set(ByVal Value As Integer)
            SAveXMSetting("ItemsPerPage", Value)
        End Set
    End Property

    Public Property VendaDescontoExcedente() As enVendaDescontoExcedente
        Get
            Return GetXMSetting("VendaDescontoExcedente", enVendaDescontoExcedente.Nao)
        End Get
        Set(ByVal Value As enVendaDescontoExcedente)
            SAveXMSetting("VendaDescontoExcedente", Value)
        End Set
    End Property

    Public Property VendaSEstoque() As enVendaSEstoque
        Get
            Return GetXMSetting("VendaSEstoque", enVendaSEstoque.Nao)
        End Get
        Set(ByVal Value As enVendaSEstoque)
            SAveXMSetting("VendaSEstoque", Value)
        End Set
    End Property

    Public Property VisualizaEstoque() As enVisualizaEstoque
        Get
            Return GetXMSetting("VisualizaEstoque", enVisualizaEstoque.Sim)
        End Get
        Set(ByVal Value As enVisualizaEstoque)
            SAveXMSetting("VisualizaEstoque", Value)
        End Set
    End Property

    Public Property DigitaPreco() As enDigitaPreco
        Get
            Return GetXMSetting("DigitaPreco", enDigitaPreco.Sim)
        End Get
        Set(ByVal Value As enDigitaPreco)
            SAveXMSetting("DigitaPreco", Value)
        End Set
    End Property

    Public Property DigitaObservacao() As enDigitaObservacao
        Get
            Return GetXMSetting("DigitaObservacao", enDigitaObservacao.Sim)
        End Get
        Set(ByVal Value As enDigitaObservacao)
            SAveXMSetting("DigitaObservacao", Value)
        End Set
    End Property

    Public Property DigitaDataEntrega() As enDigitaDataEntrega
        Get
            Return GetXMSetting("DigitaDataEntrega", enDigitaDataEntrega.Sim)
        End Get
        Set(ByVal Value As enDigitaDataEntrega)
            SAveXMSetting("DigitaDataEntrega", Value)
        End Set
    End Property

    Public Property MostraItensResumo() As enMostraItensResumo
        Get
            Return GetXMSetting("MostraItensResumo", enMostraItensResumo.Sim)
        End Get
        Set(ByVal Value As enMostraItensResumo)
            SAveXMSetting("MostraItensResumo", Value)
        End Set
    End Property

    Public Property DigitaDesconto() As enDigitaDesconto
        Get
            Return GetXMSetting("DigitaDesconto", enDigitaDesconto.Nao)
        End Get
        Set(ByVal Value As enDigitaDesconto)
            SAveXMSetting("DigitaDesconto", Value)
        End Set
    End Property

    Public Property EntradaProduto() As enEntradaProduto
        Get
            Return GetXMSetting("EntradaProduto", enEntradaProduto.BuscaPorNome)
        End Get
        Set(ByVal Value As enEntradaProduto)
            SAveXMSetting("EntradaProduto", Value)
        End Set
    End Property

    Public Property VendaClienteOutroVendedor() As enVendaClienteOutroVendedor
        Get
            Return GetXMSetting("VendaClienteOutroVendedor", enVendaClienteOutroVendedor.Nao)
        End Get
        Set(ByVal Value As enVendaClienteOutroVendedor)
            SAveXMSetting("VendaClienteOutroVendedor", Value)
        End Set
    End Property

    Public Property FiltrarPorCategoria() As enFiltrarPorCategoria
        Get
            Return GetXMSetting("FiltrarPorCategoria", enFiltrarPorCategoria.Sim)
        End Get
        Set(ByVal Value As enFiltrarPorCategoria)
            SAveXMSetting("FiltrarPorCategoria", Value)
        End Set
    End Property

#End Region

End Class
