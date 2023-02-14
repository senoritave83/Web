Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Grupo
        Implements ISettingTabelaPreco, ISettingCondicao, ISettingForma

#Region "Declarations"
        Protected m_blnUtilizaDescontoMax As Boolean
        Protected m_blnDescontoMaxObrigatorio As Boolean
        Protected m_blnUtilizaCorrecao As Boolean
        Protected m_blnUtilizaAprovacaoManual As Boolean
        Protected m_blnUtilizaPrecoLivre As Boolean
        Protected m_blnUtilizaEspecial As Boolean
        Protected m_blnUtilizaBonificacao As Boolean
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

        Public Overridable Property UtilizaPrecoLivre() As Boolean
            Get
                Return m_blnUtilizaPrecoLivre
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaPrecoLivre = Value
            End Set
        End Property

        Public Overridable Property UtilizaEspecial() As Boolean
            Get
                Return m_blnUtilizaEspecial
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaEspecial = Value
            End Set
        End Property

        Public Overridable Property UtilizaBonificacao() As Boolean
            Get
                Return m_blnUtilizaBonificacao
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaBonificacao = Value
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
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaDescontoMax")) Then
                    m_blnUtilizaDescontoMax = False
                Else
                    m_blnUtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoDescontoMaxObrigatorio")) Then
                    m_blnDescontoMaxObrigatorio = False
                Else
                    m_blnDescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("GrupoDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaCorrecao")) Then
                    m_blnUtilizaCorrecao = False
                Else
                    m_blnUtilizaCorrecao = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaCorrecao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaAprovacaoManual")) Then
                    m_blnUtilizaAprovacaoManual = False
                Else
                    m_blnUtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaPrecoLivre")) Then
                    m_blnUtilizaPrecoLivre = False
                Else
                    m_blnUtilizaPrecoLivre = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaPrecoLivre"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaEspecial")) Then
                    m_blnUtilizaEspecial = False
                Else
                    m_blnUtilizaEspecial = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaEspecial"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaBonificacao")) Then
                    m_blnUtilizaBonificacao = False
                Else
                    m_blnUtilizaBonificacao = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaBonificacao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaSegmentacao")) Then
                    m_blnUtilizaSegmentacao = False
                Else
                    m_blnUtilizaSegmentacao = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaSegmentacao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaTabelaPreco")) Then
                    m_blnUtilizaTabelaPreco = False
                Else
                    m_blnUtilizaTabelaPreco = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaTabelaPreco"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaTabelaPrecoMultipla")) Then
                    m_blnUtilizaTabelaPrecoMultipla = False
                Else
                    m_blnUtilizaTabelaPrecoMultipla = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaTabelaPrecoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaCondicaoPagamento")) Then
                    m_blnUtilizaCondicaoPagamento = False
                Else
                    m_blnUtilizaCondicaoPagamento = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaCondicaoPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaCondicaoPagamentoMultipla")) Then
                    m_blnUtilizaCondicaoPagamentoMultipla = False
                Else
                    m_blnUtilizaCondicaoPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaCondicaoPagamentoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaFormaPagamento")) Then
                    m_blnUtilizaFormaPagamento = False
                Else
                    m_blnUtilizaFormaPagamento = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaFormaPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("GrupoUtilizaFormaPagamentoMultipla")) Then
                    m_blnUtilizaFormaPagamentoMultipla = False
                Else
                    m_blnUtilizaFormaPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("GrupoUtilizaFormaPagamentoMultipla"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@GRUPOUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnUtilizaDescontoMax
            prms.Add("@GRUPODESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnDescontoMaxObrigatorio
            prms.Add("@GRUPOUTILIZACORRECAO", SqlDbType.Bit).Value = m_blnUtilizaCorrecao
            prms.Add("@GRUPOUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnUtilizaAprovacaoManual
            prms.Add("@GRUPOUTILIZAPRECOLIVRE", SqlDbType.Bit).Value = m_blnUtilizaPrecoLivre
            prms.Add("@GRUPOUTILIZAESPECIAL", SqlDbType.Bit).Value = m_blnUtilizaEspecial
            prms.Add("@GRUPOUTILIZABONIFICACAO", SqlDbType.Bit).Value = m_blnUtilizaBonificacao
            prms.Add("@GRUPOUTILIZASEGMENTACAO", SqlDbType.Bit).Value = m_blnUtilizaSegmentacao
            prms.Add("@GRUPOUTILIZATABELAPRECO", SqlDbType.Bit).Value = m_blnUtilizaTabelaPreco
            prms.Add("@GRUPOUTILIZATABELAPRECOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaTabelaPrecoMultipla
            prms.Add("@GRUPOUTILIZACONDICAOPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamento
            prms.Add("@GRUPOUTILIZACONDICAOPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamentoMultipla
            prms.Add("@GRUPOUTILIZAFORMAPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamento
            prms.Add("@GRUPOUTILIZAFORMAPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamentoMultipla
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaDescontoMax = False
            m_blnDescontoMaxObrigatorio = False
            m_blnUtilizaCorrecao = False
            m_blnUtilizaAprovacaoManual = False
            m_blnUtilizaPrecoLivre = False
            m_blnUtilizaEspecial = False
            m_blnUtilizaBonificacao = False
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