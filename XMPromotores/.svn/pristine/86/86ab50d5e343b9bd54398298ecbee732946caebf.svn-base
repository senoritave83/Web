Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Linha
        Implements ISettingFaixa

#Region "Declarations"
        Protected m_blnUtilizaDescontoMax As Boolean
        Protected m_blnDescontoMaxObrigatorio As Boolean
        Protected m_blnUtilizaCorrecao As Boolean
        Protected m_blnUtilizaAprovacaoManual As Boolean
        Protected m_blnUtilizaFaixaVenda As Boolean
        Protected m_blnUtilizaFaixaPesquisa As Boolean
        Protected m_blnUtilizaFaixa As Boolean
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

        Public Overridable Property UtilizaFaixaVenda() As Boolean Implements ISettingFaixa.UtilizaFaixaVenda
            Get
                Return m_blnUtilizaFaixaVenda
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaFaixaVenda = Value
            End Set
        End Property

        Public Overridable Property UtilizaFaixaPesquisa() As Boolean Implements ISettingFaixa.UtilizaFaixaPesquisa
            Get
                Return m_blnUtilizaFaixaPesquisa
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaFaixaPesquisa = Value
            End Set
        End Property

        Public Overridable ReadOnly Property UtilizaFaixa() As Boolean Implements ISettingFaixa.UtilizaFaixa
            Get
                Return m_blnUtilizaFaixa
            End Get
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Friend Sub New(ByVal dr As IDataReader)
            If Not dr Is Nothing Then

                If dr.IsDBNull(dr.GetOrdinal("LinhaUtilizaDescontoMax")) Then
                    m_blnUtilizaDescontoMax = False
                Else
                    m_blnUtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("LinhaUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("LinhaDescontoMaxObrigatorio")) Then
                    m_blnDescontoMaxObrigatorio = False
                Else
                    m_blnDescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("LinhaDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("LinhaUtilizaCorrecao")) Then
                    m_blnUtilizaCorrecao = False
                Else
                    m_blnUtilizaCorrecao = dr.GetBoolean(dr.GetOrdinal("LinhaUtilizaCorrecao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("LinhaUtilizaAprovacaoManual")) Then
                    m_blnUtilizaAprovacaoManual = False
                Else
                    m_blnUtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("LinhaUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("LinhaUtilizaFaixaVenda")) Then
                    m_blnUtilizaFaixaVenda = False
                Else
                    m_blnUtilizaFaixaVenda = dr.GetBoolean(dr.GetOrdinal("LinhaUtilizaFaixaVenda"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("LinhaUtilizaFaixaPesquisa")) Then
                    m_blnUtilizaFaixaPesquisa = False
                Else
                    m_blnUtilizaFaixaPesquisa = dr.GetBoolean(dr.GetOrdinal("LinhaUtilizaFaixaPesquisa"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("LinhaUtilizaFaixa")) Then
                    m_blnUtilizaFaixa = False
                Else
                    m_blnUtilizaFaixa = dr.GetBoolean(dr.GetOrdinal("LinhaUtilizaFaixa"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@LINHAUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnUtilizaDescontoMax
            prms.Add("@LINHADESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnDescontoMaxObrigatorio
            prms.Add("@LINHAUTILIZACORRECAO", SqlDbType.Bit).Value = m_blnUtilizaCorrecao
            prms.Add("@LINHAUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnUtilizaAprovacaoManual
            prms.Add("@LINHAUTILIZAFAIXAVENDA", SqlDbType.Bit).Value = m_blnUtilizaFaixaVenda
            prms.Add("@LINHAUTILIZAFAIXAPESQUISA", SqlDbType.Bit).Value = m_blnUtilizaFaixaPesquisa
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaDescontoMax = False
            m_blnDescontoMaxObrigatorio = False
            m_blnUtilizaCorrecao = False
            m_blnUtilizaAprovacaoManual = False
            m_blnUtilizaFaixaVenda = False
            m_blnUtilizaFaixaPesquisa = False
            m_blnUtilizaFaixa = False
        End Sub

#End Region

    End Class
End Namespace