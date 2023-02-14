Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Loja
        Implements ISettingTabelaPreco, ISettingCondicao, ISettingForma

        Protected m_blnUtilizaDescontoMax As Boolean
        Protected m_blnDescontoMaxObrigatorio As Boolean
        Protected m_blnUtilizaCorrecao As Boolean
        Protected m_blnUtilizaAprovacaoManual As Boolean
        Protected m_blnUtilizaSegmentacao As Boolean
        Protected m_blnUtilizaTabelaPreco As Boolean
        Protected m_blnUtilizaTabelaPrecoMultipla As Boolean
        Protected m_blnUtilizaCondicaoPagamento As Boolean
        Protected m_blnUtilizaCondicaoPagamentoMultipla As Boolean
        Protected m_blnUtilizaFormaPagamento As Boolean
        Protected m_blnUtilizaFormaPagamentoMultipla As Boolean

        Public Overridable Property UtilizaDescontoMax() As Boolean
            Get
                Return m_blnUtilizaDescontoMax
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaDescontoMax = Value
            End Set
        End Property

        Public Overridable Property DescontoMaxObrigatorio() As Boolean
            Get
                Return m_blnDescontoMaxObrigatorio
            End Get
            Set(ByVal Value As Boolean)
                m_blnDescontoMaxObrigatorio = Value
            End Set
        End Property

        Public Overridable Property UtilizaCorrecao() As Boolean
            Get
                Return m_blnUtilizaCorrecao
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaCorrecao = Value
            End Set
        End Property

        Public Overridable Property UtilizaAprovacaoManual() As Boolean
            Get
                Return m_blnUtilizaAprovacaoManual
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaAprovacaoManual = Value
            End Set
        End Property

        Public Overridable Property UtilizaSegmentacao() As Boolean
            Get
                Return m_blnUtilizaSegmentacao
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaSegmentacao = Value
            End Set
        End Property

        Public Overridable Property UtilizaTabelaPreco() As Boolean Implements ISettingTabelaPreco.UtilizaTabelaPreco
            Get
                Return m_blnUtilizaTabelaPreco
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaTabelaPreco = Value
            End Set
        End Property

        Public Overridable Property UtilizaTabelaPrecoMultipla() As Boolean Implements ISettingTabelaPreco.UtilizaTabelaPrecoMultipla
            Get
                Return m_blnUtilizaTabelaPrecoMultipla
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaTabelaPrecoMultipla = Value
            End Set
        End Property

        Public Overridable Property UtilizaCondicaoPagamento() As Boolean Implements ISettingCondicao.UtilizaCondicaoPagamento
            Get
                Return m_blnUtilizaCondicaoPagamento
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaCondicaoPagamento = Value
            End Set
        End Property

        Public Property UtilizaCondicaoPagamentoMultipla() As Boolean Implements ISettingCondicao.UtilizaCondicaoPagamentoMultipla
            Get
                Return m_blnUtilizaCondicaoPagamentoMultipla
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaCondicaoPagamentoMultipla = Value
            End Set
        End Property

        Public Overridable Property UtilizaFormaPagamento() As Boolean Implements ISettingForma.UtilizaFormaPagamento
            Get
                Return m_blnUtilizaFormaPagamento
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaFormaPagamento = Value
            End Set
        End Property

        Public Overridable Property UtilizaFormaPagamentoMultipla() As Boolean Implements ISettingForma.UtilizaFormaPagamentoMultipla
            Get
                Return m_blnUtilizaFormaPagamentoMultipla
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaFormaPagamentoMultipla = Value
            End Set
        End Property

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Friend Sub New(ByVal dr As IDataReader)
            If Not dr Is Nothing Then
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaDescontoMax")) Then
                    UtilizaDescontoMax = False
                Else
                    UtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraDescontoMaxObrigatorio")) Then
                    DescontoMaxObrigatorio = False
                Else
                    DescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("BandeiraDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaCorrecao")) Then
                    UtilizaCorrecao = False
                Else
                    UtilizaCorrecao = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaCorrecao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaAprovacaoManual")) Then
                    UtilizaAprovacaoManual = False
                Else
                    UtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaSegmentacao")) Then
                    UtilizaSegmentacao = False
                Else
                    UtilizaSegmentacao = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaSegmentacao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaTabelaPreco")) Then
                    UtilizaTabelaPreco = False
                Else
                    UtilizaTabelaPreco = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaTabelaPreco"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaTabelaPrecoMultipla")) Then
                    UtilizaTabelaPrecoMultipla = False
                Else
                    UtilizaTabelaPrecoMultipla = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaTabelaPrecoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaCondicaoPagamento")) Then
                    UtilizaCondicaoPagamento = False
                Else
                    UtilizaCondicaoPagamento = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaCondicaoPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaCondicaoPagamentoMultipla")) Then
                    UtilizaCondicaoPagamentoMultipla = False
                Else
                    UtilizaCondicaoPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaCondicaoPagamentoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaFormaPagamento")) Then
                    UtilizaFormaPagamento = False
                Else
                    UtilizaFormaPagamento = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaFormaPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("BandeiraUtilizaFormaPagamentoMultipla")) Then
                    UtilizaFormaPagamentoMultipla = False
                Else
                    UtilizaFormaPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("BandeiraUtilizaFormaPagamentoMultipla"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@BANDEIRAUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnUtilizaDescontoMax
            prms.Add("@BANDEIRADESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnDescontoMaxObrigatorio
            prms.Add("@BANDEIRAUTILIZACORRECAO", SqlDbType.Bit).Value = m_blnUtilizaCorrecao
            prms.Add("@BANDEIRAUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnUtilizaAprovacaoManual
            prms.Add("@BANDEIRAUTILIZASEGMENTACAO", SqlDbType.Bit).Value = m_blnUtilizaSegmentacao
            prms.Add("@BANDEIRAUTILIZATABELAPRECO", SqlDbType.Bit).Value = m_blnUtilizaTabelaPreco
            prms.Add("@BANDEIRAUTILIZATABELAPRECOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaTabelaPrecoMultipla
            prms.Add("@BANDEIRAUTILIZACONDICAOPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamento
            prms.Add("@BANDEIRAUTILIZACONDICAOPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamentoMultipla
            prms.Add("@BANDEIRAUTILIZAFORMAPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamento
            prms.Add("@BANDEIRAUTILIZAFORMAPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamentoMultipla
        End Sub



        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaDescontoMax = False
            m_blnDescontoMaxObrigatorio = False
            m_blnUtilizaCorrecao = False
            m_blnUtilizaAprovacaoManual = False
            m_blnUtilizaSegmentacao = False
            m_blnUtilizaTabelaPreco = False
            m_blnUtilizaTabelaPrecoMultipla = False
            m_blnUtilizaCondicaoPagamento = False
            m_blnUtilizaCondicaoPagamentoMultipla = False
            m_blnUtilizaFormaPagamento = False
            m_blnUtilizaFormaPagamentoMultipla = False
        End Sub


#End Region

    End Class
End Namespace
