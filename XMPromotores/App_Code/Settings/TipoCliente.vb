Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class TipoCliente
        Implements ISettingTabelaPreco, ISettingCondicao, ISettingForma

#Region "Declarations"
        Protected m_blnUtilizaDescontoMax As Boolean
        Protected m_blnDescontoMaxObrigatorio As Boolean
        Protected m_blnUtilizaCorrecao As Boolean
        Protected m_blnUtilizaAprovacaoManual As Boolean
        Protected m_blnUtilizaLimiteCredito As Boolean
        Protected m_blnUtilizaSegmentacao As Boolean
        Protected m_blnUtilizaTabelaPreco As Boolean
        Protected m_blnUtilizaTabelaPrecoMultipla As Boolean
        Protected m_blnUtilizaCondicaoPagamento As Boolean
        Protected m_blnUtilizaCondicaoPagamentoMultipla As Boolean
        Protected m_blnUtilizaFormaPagamento As Boolean
        Protected m_blnUtilizaFormaPagamentoMultipla As Boolean
#End Region


#Region "Properties"

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

        Public Overridable Property UtilizaLimiteCredito() As Boolean
            Get
                Return m_blnUtilizaLimiteCredito
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaLimiteCredito = Value
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

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Friend Sub New(ByVal dr As IDataReader)
            If Not dr Is Nothing Then
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaDescontoMax")) Then
                    m_blnUtilizaDescontoMax = False
                Else
                    m_blnUtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteDescontoMaxObrigatorio")) Then
                    m_blnDescontoMaxObrigatorio = False
                Else
                    m_blnDescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("TipoClienteDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaCorrecao")) Then
                    m_blnUtilizaCorrecao = False
                Else
                    m_blnUtilizaCorrecao = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaCorrecao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaAprovacaoManual")) Then
                    m_blnUtilizaAprovacaoManual = False
                Else
                    m_blnUtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaLimiteCredito")) Then
                    m_blnUtilizaLimiteCredito = False
                Else
                    m_blnUtilizaLimiteCredito = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaLimiteCredito"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaSegmentacao")) Then
                    m_blnUtilizaSegmentacao = False
                Else
                    m_blnUtilizaSegmentacao = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaSegmentacao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaTabelaPreco")) Then
                    m_blnUtilizaTabelaPreco = False
                Else
                    m_blnUtilizaTabelaPreco = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaTabelaPreco"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaTabelaPrecoMultipla")) Then
                    m_blnUtilizaTabelaPrecoMultipla = False
                Else
                    m_blnUtilizaTabelaPrecoMultipla = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaTabelaPrecoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaCondicaoPagamento")) Then
                    m_blnUtilizaCondicaoPagamento = False
                Else
                    m_blnUtilizaCondicaoPagamento = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaCondicaoPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaCondicaoPagamentoMultipla")) Then
                    m_blnUtilizaCondicaoPagamentoMultipla = False
                Else
                    m_blnUtilizaCondicaoPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaCondicaoPagamentoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaFormaPagamento")) Then
                    m_blnUtilizaFormaPagamento = False
                Else
                    m_blnUtilizaFormaPagamento = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaFormaPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoClienteUtilizaFormaPagamentoMultipla")) Then
                    m_blnUtilizaFormaPagamentoMultipla = False
                Else
                    m_blnUtilizaFormaPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("TipoClienteUtilizaFormaPagamentoMultipla"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@TIPOCLIENTEUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnUtilizaDescontoMax
            prms.Add("@TIPOCLIENTEDESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnDescontoMaxObrigatorio
            prms.Add("@TIPOCLIENTEUTILIZACORRECAO", SqlDbType.Bit).Value = m_blnUtilizaCorrecao
            prms.Add("@TIPOCLIENTEUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnUtilizaAprovacaoManual
            prms.Add("@TIPOCLIENTEUTILIZALIMITECREDITO", SqlDbType.Bit).Value = m_blnUtilizaLimiteCredito
            prms.Add("@TIPOCLIENTEUTILIZASEGMENTACAO", SqlDbType.Bit).Value = m_blnUtilizaSegmentacao
            prms.Add("@TIPOCLIENTEUTILIZATABELAPRECO", SqlDbType.Bit).Value = m_blnUtilizaTabelaPreco
            prms.Add("@TIPOCLIENTEUTILIZATABELAPRECOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaTabelaPrecoMultipla
            prms.Add("@TIPOCLIENTEUTILIZACONDICAOPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamento
            prms.Add("@TIPOCLIENTEUTILIZACONDICAOPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamentoMultipla
            prms.Add("@TIPOCLIENTEUTILIZAFORMAPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamento
            prms.Add("@TIPOCLIENTEUTILIZAFORMAPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamentoMultipla
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaDescontoMax = False
            m_blnDescontoMaxObrigatorio = False
            m_blnUtilizaCorrecao = False
            m_blnUtilizaAprovacaoManual = False
            m_blnUtilizaLimiteCredito = False
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