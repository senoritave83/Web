

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsCatalogoProduto
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDProdutoFoto As Integer
        Protected m_intIDProduto As Integer
        Protected m_strTipo As String
        Protected m_strComentario As String
        Protected m_strDescricaoProd As String
        Protected m_blnCapa As Boolean
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDProdutoFoto As Integer
            Get
                Return m_intIDProdutoFoto
            End Get
        End Property

        Public Overridable ReadOnly Property IDProduto As Integer
            Get
                Return m_intIDProduto
            End Get
        End Property

        Public Overridable Property Tipo As String
            Get
                Return m_strTipo
            End Get
            Set(ByVal Value As String)
                m_strTipo = Value
            End Set
        End Property

        Public Overridable Property Comentario As String
            Get
                Return m_strComentario
            End Get
            Set(ByVal Value As String)
                m_strComentario = Value
            End Set
        End Property

        Public Overridable Property DescricaoProduto As String
            Get
                Return m_strDescricaoProd
            End Get
            Set(ByVal Value As String)
                m_strDescricaoProd = Value
            End Set
        End Property

        Public Overridable Property Capa As Boolean
            Get
                Return m_blnCapa
            End Get
            Set(ByVal Value As Boolean)
                m_blnCapa = Value
            End Set
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDProdutoFoto = dr.GetInt32(dr.GetOrdinal("IDProdutoFoto"))
            m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
            m_strTipo = dr.GetString(dr.GetOrdinal("Tipo"))
            m_strComentario = dr.GetString(dr.GetOrdinal("Comentario"))
            m_strDescricaoProd = dr.GetString(dr.GetOrdinal("DescricaoProd"))
            m_blnCapa = dr.GetBoolean(dr.GetOrdinal("Capa"))
            m_blnIsNew = False
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.Int).Value = m_intIDProdutoFoto
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 10).Value = m_strTipo
            cmd.Parameters.Add("@COMENTARIO", SqlDbType.VarChar, 1000).Value = m_strComentario
            cmd.Parameters.Add("@CAPA", SqlDbType.Bit).Value = m_blnCapa
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDProduto">Chave primaria IDProduto</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDProduto As Integer, Optional ByVal vIDProdutoFoto As Integer = 0) As Boolean
            If vIDProduto = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.Int).Value = vIDProdutoFoto
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDProdutoFoto = 0
            m_intIDProduto = 0
            m_strTipo = ""
            m_strComentario = ""
            m_blnCapa = False
            m_blnIsNew = True
        End Sub


        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(ByVal vIDProdutoFoto As Integer, ByVal vIDProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.Int).Value = vIDProdutoFoto
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'ProdutoFoto' the following row:  IDProdutoFoto=" & m_intIDProdutoFoto & " IDProduto=" & m_intIDProduto & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTO_FOTOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOFOTOS"
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        Public Function VerificaProduto(ByVal vIdProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataSet) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VERIFICAPRODUTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que insere dados na tabela de fotos
        ''' </summary>
        Public Function NovaFoto(ByVal vIDProduto As Integer, ByVal vExtension As String) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 10).Value = vExtension
            Return ExecuteScalar(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace

