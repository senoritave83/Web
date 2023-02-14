
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsProdutoFoto
        Inherits BaseClass



#Region "Declarations"
        Protected m_varIDProdutoFoto As Guid
        Protected m_intIDProduto As Integer
        Protected m_strComentario As String
        Protected m_blnCapa As Boolean
        Protected m_strExtension As String
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDProdutoFoto() As Guid
            Get
                Return m_varIDProdutoFoto
            End Get
        End Property

        Public Overridable ReadOnly Property IDProduto() As Integer
            Get
                Return m_intIDProduto
            End Get
        End Property


        Public Overridable Property Comentario() As String
            Get
                Return m_strComentario
            End Get
            Set(ByVal Value As String)
                m_strComentario = Value
            End Set
        End Property

        Public ReadOnly Property Foto() As String
            Get
                Return m_varIDProdutoFoto.ToString & "." & m_strExtension
            End Get
        End Property

        Public Overridable Property Extension() As String
            Get
                Return m_strExtension
            End Get
            Set(ByVal Value As String)
                m_strExtension = Value
            End Set
        End Property

        Public Overridable Property Capa() As Boolean
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
            m_varIDProdutoFoto = dr.GetGuid(dr.GetOrdinal("IDProdutoFoto"))
            m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
            m_strComentario = dr.GetString(dr.GetOrdinal("Comentario"))
            m_blnCapa = dr.GetBoolean(dr.GetOrdinal("Capa"))
            m_strExtension = dr.GetString(dr.GetOrdinal("Tipo"))

            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub NovaFoto(ByVal vIDProduto As Integer, ByVal vFileID As Guid, ByVal vExtension As String, ByVal vComentarios As String)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.UniqueIdentifier).Value = vFileID
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 10).Value = vExtension
            cmd.Parameters.Add("@COMENTARIO", SqlDbType.VarChar, 1000).Value = vComentarios
            cmd.Parameters.Add("@CAPA", SqlDbType.Bit).Value = False
            ExecuteNonQuery(cmd)
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.UniqueIdentifier).Value = m_varIDProdutoFoto
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 10).Value = m_strExtension
            cmd.Parameters.Add("@COMENTARIO", SqlDbType.VarChar, 1000).Value = m_strComentario
            cmd.Parameters.Add("@CAPA", SqlDbType.Bit).Value = m_blnCapa
            ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDProdutoFoto">Chave primaria IDProdutoFoto</param>
        ''' <param name="vIDProduto">Chave primaria IDProduto</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDProdutoFoto As Guid, ByVal vIDProduto As Integer) As Boolean
            If vIDProdutoFoto = Nothing And vIDProduto = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.UniqueIdentifier).value = vIDProdutoFoto
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            m_varIDProdutoFoto = Nothing
            m_intIDProduto = 0
            m_strComentario = ""
            m_blnCapa = False
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(ByVal vIDProdutoFoto As Guid, ByVal vIDProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PRODUTOFOTO"
            cmd.Parameters.Add("@IDPRODUTOFOTO", SqlDbType.UniqueIdentifier).Value = vIDProdutoFoto
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOFOTOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDProduto">Filtro</param>
        ''' <param name="vCapa">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDProduto As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOFOTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace