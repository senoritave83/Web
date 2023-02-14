Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Condicao

#Region "Declarations"
        Protected m_blnCondicaoUtilizaDescontoMax As Boolean
        Protected m_blnCondicaoDescontoMaxObrigatorio As Boolean
        Protected m_blnCondicaoUtilizaCorrecao As Boolean
        Protected m_blnCondicaoUtilizaAprovacaoManual As Boolean
        Protected m_blnCondicaoUtilizaValorMinimo As Boolean
        Protected m_blnCondicaoUtilizaNumParcelas As Boolean
#End Region


#Region "Properties"

        Public Overridable Property UtilizaDescontoMax() As Boolean
            Get
                Return m_blnCondicaoUtilizaDescontoMax
            End Get
            Set(ByVal Value As Boolean)
                m_blnCondicaoUtilizaDescontoMax = Value
            End Set
        End Property

        Public Overridable Property DescontoMaxObrigatorio() As Boolean
            Get
                Return m_blnCondicaoDescontoMaxObrigatorio
            End Get
            Set(ByVal Value As Boolean)
                m_blnCondicaoDescontoMaxObrigatorio = Value
            End Set
        End Property

        Public Overridable Property UtilizaCorrecao() As Boolean
            Get
                Return m_blnCondicaoUtilizaCorrecao
            End Get
            Set(ByVal Value As Boolean)
                m_blnCondicaoUtilizaCorrecao = Value
            End Set
        End Property

        Public Overridable Property UtilizaAprovacaoManual() As Boolean
            Get
                Return m_blnCondicaoUtilizaAprovacaoManual
            End Get
            Set(ByVal Value As Boolean)
                m_blnCondicaoUtilizaAprovacaoManual = Value
            End Set
        End Property

        Public Overridable Property UtilizaValorMinimo() As Boolean
            Get
                Return m_blnCondicaoUtilizaValorMinimo
            End Get
            Set(ByVal Value As Boolean)
                m_blnCondicaoUtilizaValorMinimo = Value
            End Set
        End Property

        Public Overridable Property UtilizaNumParcelas() As Boolean
            Get
                Return m_blnCondicaoUtilizaNumParcelas
            End Get
            Set(ByVal Value As Boolean)
                m_blnCondicaoUtilizaNumParcelas = Value
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
                If dr.IsDBNull(dr.GetOrdinal("CondicaoUtilizaDescontoMax")) Then
                    m_blnCondicaoUtilizaDescontoMax = False
                Else
                    m_blnCondicaoUtilizaDescontoMax = dr.GetBoolean(dr.GetOrdinal("CondicaoUtilizaDescontoMax"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("CondicaoDescontoMaxObrigatorio")) Then
                    m_blnCondicaoDescontoMaxObrigatorio = False
                Else
                    m_blnCondicaoDescontoMaxObrigatorio = dr.GetBoolean(dr.GetOrdinal("CondicaoDescontoMaxObrigatorio"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("CondicaoUtilizaCorrecao")) Then
                    m_blnCondicaoUtilizaCorrecao = False
                Else
                    m_blnCondicaoUtilizaCorrecao = dr.GetBoolean(dr.GetOrdinal("CondicaoUtilizaCorrecao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("CondicaoUtilizaAprovacaoManual")) Then
                    m_blnCondicaoUtilizaAprovacaoManual = False
                Else
                    m_blnCondicaoUtilizaAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("CondicaoUtilizaAprovacaoManual"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("CondicaoUtilizaValorMinimo")) Then
                    m_blnCondicaoUtilizaValorMinimo = False
                Else
                    m_blnCondicaoUtilizaValorMinimo = dr.GetBoolean(dr.GetOrdinal("CondicaoUtilizaValorMinimo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("CondicaoUtilizaNumParcelas")) Then
                    m_blnCondicaoUtilizaNumParcelas = False
                Else
                    m_blnCondicaoUtilizaNumParcelas = dr.GetBoolean(dr.GetOrdinal("CondicaoUtilizaNumParcelas"))
                End If
            End If
        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@CONDICAOUTILIZADESCONTOMAX", SqlDbType.Bit).Value = m_blnCondicaoUtilizaDescontoMax
            prms.Add("@CONDICAODESCONTOMAXOBRIGATORIO", SqlDbType.Bit).Value = m_blnCondicaoDescontoMaxObrigatorio
            prms.Add("@CONDICAOUTILIZACORRECAO", SqlDbType.Bit).Value = m_blnCondicaoUtilizaCorrecao
            prms.Add("@CONDICAOUTILIZAAPROVACAOMANUAL", SqlDbType.Bit).Value = m_blnCondicaoUtilizaAprovacaoManual
            prms.Add("@CONDICAOUTILIZAVALORMINIMO", SqlDbType.Bit).Value = m_blnCondicaoUtilizaValorMinimo
            prms.Add("@CONDICAOUTILIZANUMPARCELAS", SqlDbType.Bit).Value = m_blnCondicaoUtilizaNumParcelas
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnCondicaoUtilizaDescontoMax = False
            m_blnCondicaoDescontoMaxObrigatorio = False
            m_blnCondicaoUtilizaCorrecao = False
            m_blnCondicaoUtilizaAprovacaoManual = False
            m_blnCondicaoUtilizaValorMinimo = False
            m_blnCondicaoUtilizaNumParcelas = False
        End Sub

#End Region

    End Class
End Namespace