Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Cliente
        Implements ISettingTabelaPreco, ISettingCondicao, ISettingForma

#Region "Declarations"
        Protected m_blnUtilizaContato As Boolean
        Protected m_blnUtilizaContatoMultiplo As Boolean
        Protected m_blnUtilizaEndereco As Boolean
        Protected m_blnUtilizaEnderecoMultiplo As Boolean
        Protected m_blnCNPJObrigatorio As Boolean
        Protected m_blnCNPJValido As Boolean
        Protected m_blnUtilizaLimiteCredito As Boolean
        Protected m_blnUtilizaDescontoMaximo As Boolean
        Protected m_blnUtilizaRoteiroUnico As Boolean
        Protected m_blnUtilizaVendedor As Boolean
        Protected m_blnUtilizaVendedorMultiplo As Boolean
        Protected m_blnUtilizaBandeira As Boolean
        Protected m_blnUtilizaEstoqueConsignado As Boolean
        Protected m_blnUtilizaTabelaPreco As Boolean
        Protected m_blnUtilizaTabelaPrecoMultipla As Boolean
        Protected m_blnUtilizaFormaPagamento As Boolean
        Protected m_blnUtilizaFormaPagamentoMultipla As Boolean
        Protected m_blnUtilizaCondicaoPagamento As Boolean
        Protected m_blnUtilizaCondicaoPagamentoMultipla As Boolean
        Protected m_blnUtilizaSegmentacao As Boolean
#End Region


#Region "Properties"


        Public Overridable Property UtilizaContato() As Boolean
            Get
                Return m_blnUtilizaContato
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaContato = Value
            End Set
        End Property

        Public Overridable Property UtilizaContatoMultiplo() As Boolean
            Get
                Return m_blnUtilizaContatoMultiplo
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaContatoMultiplo = Value
            End Set
        End Property

        Public Overridable Property UtilizaEndereco() As Boolean
            Get
                Return m_blnUtilizaEndereco
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaEndereco = Value
            End Set
        End Property

        Public Overridable Property UtilizaEnderecoMultiplo() As Boolean
            Get
                Return m_blnUtilizaEnderecoMultiplo
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaEnderecoMultiplo = Value
            End Set
        End Property

        Public Overridable Property CNPJObrigatorio() As Boolean
            Get
                Return m_blnCNPJObrigatorio
            End Get
            Set(ByVal Value As Boolean)
                m_blnCNPJObrigatorio = Value
            End Set
        End Property

        Public Overridable Property CNPJValido() As Boolean
            Get
                Return m_blnCNPJValido
            End Get
            Set(ByVal Value As Boolean)
                m_blnCNPJValido = Value
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

        Public Overridable Property UtilizaDescontoMaximo() As Boolean
            Get
                Return m_blnUtilizaDescontoMaximo
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaDescontoMaximo = Value
            End Set
        End Property

        Public Overridable Property UtilizaRoteiroUnico() As Boolean
            Get
                Return m_blnUtilizaRoteiroUnico
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaRoteiroUnico = Value
            End Set
        End Property

        Public Overridable Property UtilizaVendedor() As Boolean
            Get
                Return m_blnUtilizaVendedor
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaVendedor = Value
            End Set
        End Property

        Public Overridable Property UtilizaVendedorMultiplo() As Boolean
            Get
                Return m_blnUtilizaVendedorMultiplo
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaVendedorMultiplo = Value
            End Set
        End Property

        Public Overridable Property UtilizaBandeira() As Boolean
            Get
                Return m_blnUtilizaBandeira
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaBandeira = Value
            End Set
        End Property

        Public Overridable Property UtilizaEstoqueConsignado() As Boolean
            Get
                Return m_blnUtilizaEstoqueConsignado
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaEstoqueConsignado = Value
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
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaContato")) Then
                    m_blnUtilizaContato = False
                Else
                    m_blnUtilizaContato = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaContato"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaContatoMultiplo")) Then
                    m_blnUtilizaContatoMultiplo = False
                Else
                    m_blnUtilizaContatoMultiplo = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaContatoMultiplo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaEndereco")) Then
                    m_blnUtilizaEndereco = False
                Else
                    m_blnUtilizaEndereco = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaEndereco"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaEnderecoMultiplo")) Then
                    m_blnUtilizaEnderecoMultiplo = False
                Else
                    m_blnUtilizaEnderecoMultiplo = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaEnderecoMultiplo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteCNPJObrigatorio")) Then
                    m_blnCNPJObrigatorio = False
                Else
                    m_blnCNPJObrigatorio = dr.GetBoolean(dr.GetOrdinal("ClienteCNPJObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteCNPJValido")) Then
                    m_blnCNPJValido = False
                Else
                    m_blnCNPJValido = dr.GetBoolean(dr.GetOrdinal("ClienteCNPJValido"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaLimiteCredito")) Then
                    m_blnUtilizaLimiteCredito = False
                Else
                    m_blnUtilizaLimiteCredito = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaLimiteCredito"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaDescontoMaximo")) Then
                    m_blnUtilizaDescontoMaximo = False
                Else
                    m_blnUtilizaDescontoMaximo = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaDescontoMaximo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaRoteiroUnico")) Then
                    m_blnUtilizaRoteiroUnico = False
                Else
                    m_blnUtilizaRoteiroUnico = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaRoteiroUnico"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaVendedor")) Then
                    m_blnUtilizaVendedor = False
                Else
                    m_blnUtilizaVendedor = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaVendedor"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaVendedorMultiplo")) Then
                    m_blnUtilizaVendedorMultiplo = False
                Else
                    m_blnUtilizaVendedorMultiplo = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaVendedorMultiplo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaBandeira")) Then
                    m_blnUtilizaBandeira = False
                Else
                    m_blnUtilizaBandeira = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaBandeira"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaEstoqueConsignado")) Then
                    m_blnUtilizaEstoqueConsignado = False
                Else
                    m_blnUtilizaEstoqueConsignado = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaEstoqueConsignado"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaTabelaPreco")) Then
                    m_blnUtilizaTabelaPreco = False
                Else
                    m_blnUtilizaTabelaPreco = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaTabelaPreco"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaTabelaPrecoMultipla")) Then
                    m_blnUtilizaTabelaPrecoMultipla = False
                Else
                    m_blnUtilizaTabelaPrecoMultipla = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaTabelaPrecoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaFormaPagamento")) Then
                    m_blnUtilizaFormaPagamento = False
                Else
                    m_blnUtilizaFormaPagamento = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaFormaPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaFormaPagamentoMultipla")) Then
                    m_blnUtilizaFormaPagamentoMultipla = False
                Else
                    m_blnUtilizaFormaPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaFormaPagamentoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaCondicaoPagamento")) Then
                    m_blnUtilizaCondicaoPagamento = False
                Else
                    m_blnUtilizaCondicaoPagamento = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaCondicaoPagamento"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaCondicaoPagamentoMultipla")) Then
                    m_blnUtilizaCondicaoPagamentoMultipla = False
                Else
                    m_blnUtilizaCondicaoPagamentoMultipla = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaCondicaoPagamentoMultipla"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ClienteUtilizaSegmentacao")) Then
                    m_blnUtilizaSegmentacao = False
                Else
                    m_blnUtilizaSegmentacao = dr.GetBoolean(dr.GetOrdinal("ClienteUtilizaSegmentacao"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@CLIENTEUTILIZACONTATO", SqlDbType.Bit).Value = m_blnUtilizaContato
            prms.Add("@CLIENTEUTILIZACONTATOMULTIPLO", SqlDbType.Bit).Value = m_blnUtilizaContatoMultiplo
            prms.Add("@CLIENTEUTILIZAENDERECO", SqlDbType.Bit).Value = m_blnUtilizaEndereco
            prms.Add("@CLIENTEUTILIZAENDERECOMULTIPLO", SqlDbType.Bit).Value = m_blnUtilizaEnderecoMultiplo
            prms.Add("@CLIENTECNPJOBRIGATORIO", SqlDbType.Bit).Value = m_blnCNPJObrigatorio
            prms.Add("@CLIENTECNPJVALIDO", SqlDbType.Bit).Value = m_blnCNPJValido
            prms.Add("@CLIENTEUTILIZALIMITECREDITO", SqlDbType.Bit).Value = m_blnUtilizaLimiteCredito
            prms.Add("@CLIENTEUTILIZADESCONTOMAXIMO", SqlDbType.Bit).Value = m_blnUtilizaDescontoMaximo
            prms.Add("@CLIENTEUTILIZAROTEIROUNICO", SqlDbType.Bit).Value = m_blnUtilizaRoteiroUnico
            prms.Add("@CLIENTEUTILIZAVENDEDOR", SqlDbType.Bit).Value = m_blnUtilizaVendedor
            prms.Add("@CLIENTEUTILIZAVENDEDORMULTIPLO", SqlDbType.Bit).Value = m_blnUtilizaVendedorMultiplo
            prms.Add("@CLIENTEUTILIZABANDEIRA", SqlDbType.Bit).Value = m_blnUtilizaBandeira
            prms.Add("@CLIENTEUTILIZAESTOQUECONSIGNADO", SqlDbType.Bit).Value = m_blnUtilizaEstoqueConsignado
            prms.Add("@CLIENTEUTILIZATABELAPRECO", SqlDbType.Bit).Value = m_blnUtilizaTabelaPreco
            prms.Add("@CLIENTEUTILIZATABELAPRECOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaTabelaPrecoMultipla
            prms.Add("@CLIENTEUTILIZAFORMAPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamento
            prms.Add("@CLIENTEUTILIZAFORMAPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaFormaPagamentoMultipla
            prms.Add("@CLIENTEUTILIZACONDICAOPAGAMENTO", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamento
            prms.Add("@CLIENTEUTILIZACONDICAOPAGAMENTOMULTIPLA", SqlDbType.Bit).Value = m_blnUtilizaCondicaoPagamentoMultipla
            prms.Add("@CLIENTEUTILIZASEGMENTACAO", SqlDbType.Bit).Value = m_blnUtilizaSegmentacao
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaContato = False
            m_blnUtilizaContatoMultiplo = False
            m_blnUtilizaEndereco = False
            m_blnUtilizaEnderecoMultiplo = False
            m_blnCNPJObrigatorio = False
            m_blnCNPJValido = False
            m_blnUtilizaLimiteCredito = False
            m_blnUtilizaDescontoMaximo = False
            m_blnUtilizaRoteiroUnico = False
            m_blnUtilizaVendedor = False
            m_blnUtilizaVendedorMultiplo = False
            m_blnUtilizaBandeira = False
            m_blnUtilizaEstoqueConsignado = False
            m_blnUtilizaTabelaPreco = False
            m_blnUtilizaTabelaPrecoMultipla = False
            m_blnUtilizaFormaPagamento = False
            m_blnUtilizaFormaPagamentoMultipla = False
            m_blnUtilizaCondicaoPagamento = False
            m_blnUtilizaCondicaoPagamentoMultipla = False
            m_blnUtilizaSegmentacao = False
        End Sub

#End Region

    End Class
End Namespace