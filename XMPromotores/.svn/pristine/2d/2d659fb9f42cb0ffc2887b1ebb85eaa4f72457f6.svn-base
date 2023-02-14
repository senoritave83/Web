Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Tabela

#Region "Declarations"
        Protected m_blnUtilizaDescontoMax As Boolean
        Protected m_blnDescontoMaxObrigatorio As Boolean
        Protected m_blnUtilizaPrecoCalculado As Boolean
        Protected m_blnUtilizaAprovacaoManual As Boolean
        Protected m_blnUtilizaPrecoLivre As Boolean
        Protected m_blnUtilizaPrecoIndividual As Boolean
        Protected m_blnUtilizaBonificacao As Boolean
        Protected m_blnUtilizaEspecial As Boolean
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

        Public Overridable Property UtilizaPrecoCalculado() As Boolean
            Get
                Return m_blnUtilizaPrecoCalculado
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaPrecoCalculado = Value
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

        Public Overridable Property UtilizaPrecoIndividual() As Boolean
            Get
                Return m_blnUtilizaPrecoIndividual
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaPrecoIndividual = Value
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

        Public Overridable Property UtilizaEspecial() As Boolean
            Get
                Return m_blnUtilizaEspecial
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaEspecial = Value
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
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaDescontoMax")) Then
                    m_blnUtilizaDescontoMax = False
                Else
                    m_blnUtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaDescontoMaxObrigatorio")) Then
                    m_blnDescontoMaxObrigatorio = False
                Else
                    m_blnDescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("TabelaDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaPrecoCalculado")) Then
                    m_blnUtilizaPrecoCalculado = False
                Else
                    m_blnUtilizaPrecoCalculado = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaPrecoCalculado"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaAprovacaoManual")) Then
                    m_blnUtilizaAprovacaoManual = False
                Else
                    m_blnUtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaPrecoLivre")) Then
                    m_blnUtilizaPrecoLivre = False
                Else
                    m_blnUtilizaPrecoLivre = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaPrecoLivre"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaPrecoIndividual")) Then
                    m_blnUtilizaPrecoIndividual = False
                Else
                    m_blnUtilizaPrecoIndividual = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaPrecoIndividual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaBonificacao")) Then
                    m_blnUtilizaBonificacao = False
                Else
                    m_blnUtilizaBonificacao = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaBonificacao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TabelaUtilizaEspecial")) Then
                    m_blnUtilizaEspecial = False
                Else
                    m_blnUtilizaEspecial = dr.GetBoolean(dr.GetOrdinal("TabelaUtilizaEspecial"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@TABELAUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnUtilizaDescontoMax
            prms.Add("@TABELADESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnDescontoMaxObrigatorio
            prms.Add("@TABELAUTILIZAPRECOCALCULADO", SqlDbType.Bit).Value = m_blnUtilizaPrecoCalculado
            prms.Add("@TABELAUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnUtilizaAprovacaoManual
            prms.Add("@TABELAUTILIZAPRECOLIVRE", SqlDbType.Bit).Value = m_blnUtilizaPrecoLivre
            prms.Add("@TABELAUTILIZAPRECOINDIVIDUAL", SqlDbType.Bit).Value = m_blnUtilizaPrecoIndividual
            prms.Add("@TABELAUTILIZABONIFICACAO", SqlDbType.Bit).Value = m_blnUtilizaBonificacao
            prms.Add("@TABELAUTILIZAESPECIAL", SqlDbType.Bit).Value = m_blnUtilizaEspecial
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaDescontoMax = False
            m_blnDescontoMaxObrigatorio = False
            m_blnUtilizaPrecoCalculado = False
            m_blnUtilizaAprovacaoManual = False
            m_blnUtilizaPrecoLivre = False
            m_blnUtilizaPrecoIndividual = False
            m_blnUtilizaBonificacao = False
            m_blnUtilizaEspecial = False
        End Sub

#End Region

    End Class
End Namespace