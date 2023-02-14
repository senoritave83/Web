Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Produto

#Region "Declarations"
        Protected m_blnClassificaMarca As Boolean = True
        Protected m_blnClassificaCategoria As Boolean = True
        Protected m_blnClassificaSubCategoria As Boolean = True
        'Protected m_blnUsaTabelasPreco As Boolean = False
        'Protected m_blnUtilizaEstoque As Boolean = False
        'Protected m_blnUtilizaFaixaVenda As Boolean
        'Protected m_blnUtilizaFaixaPesquisa As Boolean
        'Protected m_blnUtilizaFaixa As Boolean
#End Region


#Region "Properties"


        Public Overridable Property ClassificaMarca() As Boolean
            Get
                Return m_blnClassificaMarca
            End Get
            Set(ByVal Value As Boolean)
                m_blnClassificaMarca = Value
            End Set
        End Property

        Public Overridable Property ClassificaCategoria() As Boolean
            Get
                Return m_blnClassificaCategoria
            End Get
            Set(ByVal Value As Boolean)
                m_blnClassificaCategoria = Value
            End Set
        End Property

        Public Overridable Property ClassificaSubCategoria() As Boolean
            Get
                Return m_blnClassificaSubCategoria
            End Get
            Set(ByVal Value As Boolean)
                m_blnClassificaSubCategoria = Value
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
                If dr.IsDBNull(dr.GetOrdinal("ProdutoClassificaMarca")) Then
                    m_blnClassificaMarca = False
                Else
                    m_blnClassificaMarca = dr.GetBoolean(dr.GetOrdinal("ProdutoClassificaMarca"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ProdutoClassificaCategoria")) Then
                    m_blnClassificaCategoria = False
                Else
                    m_blnClassificaCategoria = dr.GetBoolean(dr.GetOrdinal("ProdutoClassificaCategoria"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("ProdutoClassificaSubCategoria")) Then
                    m_blnClassificaSubCategoria = False
                Else
                    m_blnClassificaSubCategoria = dr.GetBoolean(dr.GetOrdinal("ProdutoClassificaSubCategoria"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            prms.Add("@PRODUTOCLASSIFICAMARCA", SqlDbType.Bit).Value = m_blnClassificaMarca
            prms.Add("@PRODUTOCLASSIFICACATEGORIA", SqlDbType.Bit).Value = m_blnClassificaCategoria
            prms.Add("@PRODUTOCLASSIFICASUBCATEGORIA", SqlDbType.Bit).Value = m_blnClassificaSubCategoria
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnClassificaMarca = True
            m_blnClassificaCategoria = True
            m_blnClassificaSubCategoria = True
        End Sub

#End Region

    End Class
End Namespace