Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Marca
        Implements ISettingFaixa

#Region "Declarations"
        Protected m_blnUtilizaDescontoMax As Boolean
        Protected m_blnDescontoMaxObrigatorio As Boolean
        Protected m_blnUtilizaCorrecao As Boolean
        Protected m_blnUtilizaConcorrente As Boolean = True
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

        Public Overridable Property UtilizaConcorrente() As Boolean
            Get
                Return m_blnUtilizaConcorrente
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaConcorrente = Value
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

                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaDescontoMax")) Then
                    m_blnUtilizaDescontoMax = False
                Else
                    m_blnUtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaDescontoMaxObrigatorio")) Then
                    m_blnDescontoMaxObrigatorio = False
                Else
                    m_blnDescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("MarcaDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaCorrecao")) Then
                    m_blnUtilizaCorrecao = False
                Else
                    m_blnUtilizaCorrecao = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaCorrecao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaConcorrente")) Then
                    m_blnUtilizaConcorrente = False
                Else
                    m_blnUtilizaConcorrente = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaConcorrente"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaAprovacaoManual")) Then
                    m_blnUtilizaAprovacaoManual = False
                Else
                    m_blnUtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaFaixaVenda")) Then
                    m_blnUtilizaFaixaVenda = False
                Else
                    m_blnUtilizaFaixaVenda = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaFaixaVenda"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaFaixaPesquisa")) Then
                    m_blnUtilizaFaixaPesquisa = False
                Else
                    m_blnUtilizaFaixaPesquisa = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaFaixaPesquisa"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("MarcaUtilizaFaixa")) Then
                    m_blnUtilizaFaixa = False
                Else
                    m_blnUtilizaFaixa = dr.GetBoolean(dr.GetOrdinal("MarcaUtilizaFaixa"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@MARCAUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnUtilizaDescontoMax
            prms.Add("@MARCADESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnDescontoMaxObrigatorio
            prms.Add("@MARCAUTILIZACORRECAO", SqlDbType.Bit).Value = m_blnUtilizaCorrecao
            prms.Add("@MARCAUTILIZACONCORRENTE", SqlDbType.Bit).Value = m_blnUtilizaConcorrente
            prms.Add("@MARCAUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnUtilizaAprovacaoManual
            prms.Add("@MARCAUTILIZAFAIXAVENDA", SqlDbType.Bit).Value = m_blnUtilizaFaixaVenda
            prms.Add("@MARCAUTILIZAFAIXAPESQUISA", SqlDbType.Bit).Value = m_blnUtilizaFaixaPesquisa
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaDescontoMax = False
            m_blnDescontoMaxObrigatorio = False
            m_blnUtilizaCorrecao = False
            m_blnUtilizaAprovacaoManual = False
            m_blnUtilizaConcorrente = False
            m_blnUtilizaFaixaVenda = False
            m_blnUtilizaFaixaPesquisa = False
            m_blnUtilizaFaixa = False
        End Sub

#End Region

    End Class
End Namespace