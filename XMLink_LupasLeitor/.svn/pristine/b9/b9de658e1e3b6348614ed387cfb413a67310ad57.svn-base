

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

	Public Class clsProduto
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDProduto As Integer
		Protected m_strCodigo As String
		Protected m_strDescricao As String
		Protected m_intIDCategoria As Integer
		Protected m_strCategoria As String
		Protected m_intEstoque As Integer
		Protected m_decPrecoUnitario As Decimal
		Protected m_strCriado As String
		Protected m_decPrecoReduzido As Decimal
        Protected m_indProgramado As Byte
        Protected m_dataCriado As String
        Protected m_decPrecoVista As Decimal
        Protected m_decPrecoPre As Decimal
        Protected m_decPrecoBoleto As Decimal
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDProduto As Integer
			Get
				Return m_intIDProduto
			End Get
		End Property

		Public Overridable Property Codigo As String
			Get
				Return m_strCodigo
			End Get
			Set(ByVal Value As String)
				m_strCodigo = Value
			End Set
		End Property

		Public Overridable Property Descricao As String
			Get
				Return m_strDescricao
			End Get
			Set(ByVal Value As String)
				m_strDescricao = Value
			End Set
		End Property

		Public Overridable Property IDCategoria As Integer
			Get
				Return m_intIDCategoria
			End Get
			Set(ByVal Value As Integer)
				m_intIDCategoria = Value
			End Set
		End Property

		Public Overridable readonly Property Categoria As String
			Get
				Return m_strCategoria
			End Get
		End Property

		Public Overridable Property Estoque As Integer
			Get
				Return m_intEstoque
			End Get
			Set(ByVal Value As Integer)
				m_intEstoque = Value
			End Set
		End Property

		Public Overridable Property PrecoUnitario As Decimal
			Get
				Return m_decPrecoUnitario
			End Get
			Set(ByVal Value As Decimal)
				m_decPrecoUnitario = Value
			End Set
        End Property


        Public Overridable Property PrecoVista As Decimal
            Get
                Return m_decPrecoVista
            End Get
            Set(ByVal Value As Decimal)
                m_decPrecoVista = Value
            End Set
        End Property

        Public Overridable Property PrecoPre As Decimal
            Get
                Return m_decPrecoPre
            End Get
            Set(ByVal Value As Decimal)
                m_decPrecoPre = Value
            End Set
        End Property

        Public Overridable Property PrecoBoleto As Decimal
            Get
                Return m_decPrecoBoleto
            End Get
            Set(ByVal Value As Decimal)
                m_decPrecoBoleto = Value
            End Set
        End Property


        Public Overridable Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
            Set(ByVal Value As String)
                m_strCriado = Value
            End Set
        End Property

        Public Overridable Property PrecoReduzido As Decimal
            Get
                Return m_decPrecoReduzido
            End Get
            Set(ByVal Value As Decimal)
                m_decPrecoReduzido = Value
            End Set
        End Property

        Public Overridable Property Programado As Byte
            Get
                Return m_indProgramado
            End Get
            Set(ByVal Value As Byte)
                m_indProgramado = Value
            End Set
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            Try
                m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
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

                If dr.IsDBNull(dr.GetOrdinal("PrecoVista")) Then
                    m_decPrecoVista = Nothing
                Else
                    m_decPrecoVista = dr.GetDecimal(dr.GetOrdinal("PrecoVista"))
                End If

                If dr.IsDBNull(dr.GetOrdinal("PrecoPre")) Then
                    m_decPrecoPre = Nothing
                Else
                    m_decPrecoPre = dr.GetDecimal(dr.GetOrdinal("PrecoPre"))
                End If

                If dr.IsDBNull(dr.GetOrdinal("PrecoBoleto")) Then
                    m_decPrecoBoleto = Nothing
                Else
                    m_decPrecoBoleto = dr.GetDecimal(dr.GetOrdinal("PrecoBoleto"))
                End If
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
                If dr.IsDBNull(dr.GetOrdinal("PrecoReduzido")) Then
                    m_decPrecoReduzido = Nothing
                Else
                    m_decPrecoReduzido = dr.GetDecimal(dr.GetOrdinal("PrecoReduzido"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("Programado")) Then
                    m_indProgramado = 0
                Else
                    m_indProgramado = dr.GetByte(dr.GetOrdinal("Programado"))
                End If

            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SV_PRODUTO"
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 40).Value = m_strCodigo
                cmd.Parameters.Add("@DESCRICAO", SqlDbType.NVarChar, 120).Value = m_strDescricao
                cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = m_intIDCategoria
                cmd.Parameters.Add("@ESTOQUE", SqlDbType.Int).Value = m_intEstoque
                cmd.Parameters.Add("@PRECOUNITARIO", SqlDbType.Money).Value = m_decPrecoUnitario
                cmd.Parameters.Add("@PRECOVISTA", SqlDbType.Money).Value = m_decPrecoVista
                cmd.Parameters.Add("@PRECOPRE", SqlDbType.Money).Value = m_decPrecoPre
                cmd.Parameters.Add("@PRECOBOLETO", SqlDbType.Money).Value = m_decPrecoBoleto
                cmd.Parameters.Add("@PRECOREDUZIDO", SqlDbType.Money).Value = m_decPrecoReduzido
                cmd.Parameters.Add("@PROGRAMADO", SqlDbType.TinyInt).Value = m_indProgramado
                cmd.Parameters.Add("@DATACRIADO", SqlDbType.DateTime).Value = m_strCriado
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDProduto">Chave primaria IDProduto</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDProduto As Integer) As Boolean
            Try
                If vIDProduto = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PRODUTO"
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDProduto = 0
            m_strCodigo = ""
            m_strDescricao = ""
            m_intIDCategoria = 0
            m_intEstoque = 0
            m_decPrecoUnitario = Nothing
            m_decPrecoVista = Nothing
            m_strCriado = ""
            m_decPrecoReduzido = Nothing
            m_decPrecoPre = Nothing
            m_decPrecoBoleto = Nothing
            m_indProgramado = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_PRODUTO"
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Produto' the following row:  IDProduto=" & m_intIDProduto & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
                Clear()
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de produtos por categoria
        ''' </summary>		
        ''' <param name="vIDCategoria">Chave primária da categoria do produto</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListaProdutoCategoria(ByVal vIDCategoria As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOS_CATEGORIA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.VarChar, 255).Value = vIDCategoria
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de produtos por categoria
        ''' </summary>		
        ''' <param name="vIDCategoria">Chave primária da categoria do produto</param>
        ''' <param name="vIDPedidoEstoqueVendedor">Garante a exibição dos produtos que não estão presentes na tabela de movimentação> item</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListaProdutoCategoriaSemMovimentacao(ByVal vIDCategoria As String, ByVal vIDPedidoEstoqueVendedor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOSCATEGORIA_SEMMOVIMENTACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.VarChar, 255).Value = vIDCategoria
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).Value = vIDPedidoEstoqueVendedor
            Return MyBase.ExecuteCommand(cmd, vReturnType)

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
        Public Function Listar(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_PRODUTOS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                cn.Open()

                If vReturnType = enReturnType.DataReader Then
                    Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If dr.Read Then
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = dr.GetInt32(0)
                        If dr.NextResult Then
                            ret.Data = dr
                        End If
                    End If
                Else
                    Try
                        Dim ad As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                        ret.Data = ds.Tables(1)
                    Finally
                        If (Not cn Is Nothing) Then
                            cn.Close()
                            cn = Nothing
                        End If
                    End Try
                End If

            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return ret
        End Function




        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDProduto">Chave primaria IDProduto do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDProduto As Integer, ByVal vCodigo As String) As Boolean
            Dim blnExiste As Boolean = True
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PRODUTO_EXISTENTE"
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 40).Value = vCodigo
                cn.Open()
                Try
                    blnExiste = cmd.ExecuteScalar()
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnExiste
        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Try
                If m_strCodigo = "" Then
                    AddBrokenRule("O código é obrigatório!")
                    blnValid = False
                ElseIf Existe(m_intIDProduto, m_strCodigo) Then
                    AddBrokenRule("O código informado já existe!")
                    blnValid = False
                End If
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

