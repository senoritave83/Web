

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsProduto
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDProduto As Integer
        Protected m_strCodigo As String
        Protected m_strCodigoOriginal As String
        Protected m_strDescricao As String
        Protected m_intIDCategoria As Integer
        Protected m_strCategoria As String
        Protected m_intEstoque As Integer
        Protected m_decPrecoUnitario As Decimal
        Protected m_strCriado As String
        Protected m_sngDescontoMax As Single
        Protected m_blnIsNew As Boolean = True
        Protected m_intProdAtivo As Byte
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDProduto() As Integer
            Get
                Return m_intIDProduto
            End Get
        End Property

        Public Overridable Property Codigo() As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property CodigoOriginal() As String
            Get
                Return m_strCodigoOriginal
            End Get
            Set(ByVal Value As String)
                m_strCodigoOriginal = Value
            End Set
        End Property

        Public Overridable Property Descricao() As String
            Get
                Return m_strDescricao
            End Get
            Set(ByVal Value As String)
                m_strDescricao = Value
            End Set
        End Property

        Public Overridable Property IDCategoria() As Integer
            Get
                Return m_intIDCategoria
            End Get
            Set(ByVal Value As Integer)
                m_intIDCategoria = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Categoria() As String
            Get
                Return m_strCategoria
            End Get
        End Property

        Public Overridable Property Estoque() As Integer
            Get
                Return m_intEstoque
            End Get
            Set(ByVal Value As Integer)
                m_intEstoque = Value
            End Set
        End Property

        Public Overridable Property PrecoUnitario() As Decimal
            Get
                Return m_decPrecoUnitario
            End Get
            Set(ByVal Value As Decimal)
                m_decPrecoUnitario = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public Overridable Property DescontoMax() As Single
            Get
                Return m_sngDescontoMax
            End Get
            Set(ByVal Value As Single)
                m_sngDescontoMax = Value
            End Set
        End Property

        Public Overridable Property ProdutoAtivo() As Boolean
            Get
                Return (m_intProdAtivo <> 0)
            End Get
            Set(ByVal Value As Boolean)
                m_intProdAtivo = IIf(Value, 1, 0)
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
            m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
            m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            If dr.IsDBNull(dr.GetOrdinal("CodigoOriginal")) Then
                m_strCodigoOriginal = ""
            Else
                m_strCodigoOriginal = dr.GetString(dr.GetOrdinal("CodigoOriginal"))
            End If
            m_strDescricao = dr.GetString(dr.GetOrdinal("Descricao"))
            If dr.IsDBNull(dr.GetOrdinal("IDCategoria")) Then
                m_intIDCategoria = 0
            Else
                m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Categoria")) Then
                m_strCategoria = ""
            Else
                m_strCategoria = dr.GetString(dr.GetOrdinal("Categoria"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Estoque")) Then
                m_intEstoque = 0
            Else
                m_intEstoque = dr.GetInt32(dr.GetOrdinal("Estoque"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PrecoUnitario")) Then
                m_decPrecoUnitario = Nothing
            Else
                m_decPrecoUnitario = dr.GetDecimal(dr.GetOrdinal("PrecoUnitario"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("DescontoMax")) Then
                m_sngDescontoMax = 0
            Else
                m_sngDescontoMax = dr.GetFloat(dr.GetOrdinal("DescontoMax"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("ProdutoAtivo")) Then
                m_intProdAtivo = 0
            Else
                m_intProdAtivo = dr.GetByte(dr.GetOrdinal("ProdutoAtivo"))
            End If
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = m_intIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 10).value = m_strCodigo
            cmd.Parameters.Add("@CODIGOORIGINAL", SqlDbType.VarChar, 20).value = m_strCodigoOriginal
            cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 120).value = m_strDescricao
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = m_intIDCategoria
            cmd.Parameters.Add("@ESTOQUE", SqlDbType.Int).value = m_intEstoque
            cmd.Parameters.Add("@PRECOUNITARIO", SqlDbType.Money).value = m_decPrecoUnitario
            cmd.Parameters.Add("@DESCONTOMAX", SqlDbType.Real).Value = m_sngDescontoMax
            cmd.Parameters.Add("@PRODUTOATIVO", SqlDbType.TinyInt).Value = m_intProdAtivo
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
        Public Function Load(ByVal vIDProduto As Integer) As Boolean
            If vIDProduto = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTO"
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
            m_intIDProduto = 0
            m_strCodigo = ""
            m_strCodigoOriginal = ""
            m_strDescricao = ""
            m_intIDCategoria = 0
            m_intEstoque = 0
            m_decPrecoUnitario = Nothing
            m_strCriado = ""
            m_sngDescontoMax = 0
            m_blnIsNew = True
            m_intProdAtivo = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PRODUTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = m_intIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Produto' the following row:  IDProduto=" & m_intIDProduto & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCategoria">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vProdAtivo As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@PRODUTOATIVO", SqlDbType.Int).Value = vProdAtivo
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function




        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDProduto">Chave primaria IDProduto do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDProduto As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTO_EXISTENTE"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 10).value = vCodigo
            Return ExecuteScalar(cmd)

        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCodigo = "" Then
                AddBrokenRule("O código é obrigatório!")
                blnValid = False
            ElseIf Existe(m_intIDProduto, m_strCodigo) Then
                AddBrokenRule("O código informado já existe!")
                blnValid = False
            End If

            Return blnValid

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarPrecoEstado(ByVal vIdProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTO_PRECOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDProduto", SqlDbType.Int).Value = vIdProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function



        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub GravaPrecoProdutoEstado(ByVal vIdProduto As Integer, ByVal vEstado As String, ByVal vPreco As Decimal)

            Dim cmd As New SqlCommand()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTO_PRECOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            cmd.Parameters.Add("@UF", SqlDbType.VarChar, 2).Value = vEstado
            cmd.Parameters.Add("@PRECOUNITARIO", SqlDbType.Money).Value = vPreco
            ExecuteNonQuery(cmd)

        End Sub

#End Region

    End Class
End Namespace

