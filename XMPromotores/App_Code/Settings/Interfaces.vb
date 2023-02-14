Imports Microsoft.VisualBasic

Namespace Settings


    Public Interface ISettingTabelaPreco
        Property UtilizaTabelaPreco() As Boolean
        Property UtilizaTabelaPrecoMultipla() As Boolean
    End Interface

    Public Interface ISettingCondicao
        Property UtilizaCondicaoPagamento() As Boolean
        Property UtilizaCondicaoPagamentoMultipla() As Boolean
    End Interface

    Public Interface ISettingForma
        Property UtilizaFormaPagamento() As Boolean
        Property UtilizaFormaPagamentoMultipla() As Boolean
    End Interface

    Public Interface ISettingFaixa
        Property UtilizaFaixaVenda() As Boolean
        Property UtilizaFaixaPesquisa() As Boolean
        ReadOnly Property UtilizaFaixa() As Boolean
    End Interface


End Namespace
