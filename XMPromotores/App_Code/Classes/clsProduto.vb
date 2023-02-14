

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsProduto
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDProduto As Integer
		Protected m_strCodigo As String
		Protected m_strDescricao As String
        Protected m_strDescricaoResumida As String
        Protected m_intIDCategoria As Integer
		Protected m_intIDSubCategoria As Integer
		Protected m_intIDFornecedor As Integer
		Protected m_strCriado As String
		Protected m_varPrecoMinimo As Decimal
        Protected m_varPrecoMaximo As Decimal
        Protected m_varPrecoSugerido As Decimal
        Protected m_indStatusComercio As Integer 'define se o produto ainda é produzido
        Protected m_indStatusPesquisa As Integer 'define se o produto deve pertencer às pesquisas
        Protected m_strCodigoBarras As String
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

		Public Overridable Property DescricaoResumida As String
			Get
				Return m_strDescricaoResumida
			End Get
			Set(ByVal Value As String)
				m_strDescricaoResumida = Value
			End Set
        End Property

        Public Overridable ReadOnly Property IDCategoria() As Integer
            Get
                Return m_intIDCategoria
            End Get
        End Property

		Public Overridable Property IDSubCategoria As Integer
			Get
				Return m_intIDSubCategoria
			End Get
			Set(ByVal Value As Integer)
				m_intIDSubCategoria = Value
			End Set
		End Property

		Public Overridable Property IDFornecedor As Integer
			Get
				Return m_intIDFornecedor
			End Get
			Set(ByVal Value As Integer)
				m_intIDFornecedor = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable Property PrecoMinimo As Decimal
			Get
				Return m_varPrecoMinimo
			End Get
			Set(ByVal Value As Decimal)
				m_varPrecoMinimo = Value
			End Set
		End Property

		Public Overridable Property PrecoMaximo As Decimal
			Get
				Return m_varPrecoMaximo
			End Get
			Set(ByVal Value As Decimal)
				m_varPrecoMaximo = Value
			End Set
        End Property

        Public Overloads Property PrecoSugerido() As Decimal
            Get
                Return m_varPrecoSugerido
            End Get
            Set(ByVal value As Decimal)
                m_varPrecoSugerido = value
            End Set
        End Property

        Public Overloads Property CodigoBarras() As String
            Get
                Return m_strCodigoBarras
            End Get
            Set(ByVal value As String)
                m_strCodigoBarras = value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDProduto = 0
            End Get
        End Property

        Public Overridable Property StatusComercio() As Integer
            Get
                Return m_indStatusComercio
            End Get
            Set(ByVal Value As Integer)
                m_indStatusComercio = Value
            End Set
        End Property

        Public Overridable Property StatusPesquisa() As Integer
            Get
                Return m_indStatusPesquisa
            End Get
            Set(ByVal Value As Integer)
                m_indStatusPesquisa = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Descricao")) Then
                m_strDescricao = ""
            Else
                m_strDescricao = dr.GetString(dr.GetOrdinal("Descricao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DescricaoResumida")) Then
                m_strDescricaoResumida = ""
            Else
                m_strDescricaoResumida = dr.GetString(dr.GetOrdinal("DescricaoResumida"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDCategoria")) Then
                m_intIDCategoria = 0
            Else
                m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDSubCategoria")) Then
                m_intIDSubCategoria = 0
            Else
                m_intIDSubCategoria = dr.GetInt32(dr.GetOrdinal("IDSubCategoria"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDFornecedor")) Then
                m_intIDFornecedor = 0
            Else
                m_intIDFornecedor = dr.GetInt32(dr.GetOrdinal("IDFornecedor"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("PrecoMinimo")) Then
                m_varPrecoMinimo = Nothing
            Else
                m_varPrecoMinimo = dr.GetDecimal(dr.GetOrdinal("PrecoMinimo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PrecoMaximo")) Then
                m_varPrecoMaximo = Nothing
            Else
                m_varPrecoMaximo = dr.GetDecimal(dr.GetOrdinal("PrecoMaximo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PrecoSugerido")) Then
                m_varPrecoSugerido = Nothing
            Else
                m_varPrecoSugerido = dr.GetDecimal(dr.GetOrdinal("PrecoSugerido"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("StatusComercio")) Then
                m_indStatusComercio = 0
            Else
                m_indStatusComercio = dr.GetValue(dr.GetOrdinal("StatusComercio"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("StatusPesquisa")) Then
                m_indStatusPesquisa = 0
            Else
                m_indStatusPesquisa = dr.GetValue(dr.GetOrdinal("StatusPesquisa"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("CodigoBarras")) Then
                m_strCodigoBarras = ""
            Else
                m_strCodigoBarras = dr.GetString(dr.GetOrdinal("CodigoBarras"))
            End If

        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 25).Value = m_strCodigo
            cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 60).Value = m_strDescricao
            cmd.Parameters.Add("@DESCRICAORESUMIDA", SqlDbType.VarChar, 60).Value = m_strDescricaoResumida
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = m_intIDSubCategoria
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = m_intIDFornecedor
            cmd.Parameters.Add("@PRECOMINIMO", SqlDbType.Money).Value = m_varPrecoMinimo
            cmd.Parameters.Add("@PRECOMAXIMO", SqlDbType.Money).Value = m_varPrecoMaximo
            cmd.Parameters.Add("@PRECOSUGERIDO", SqlDbType.Money).Value = m_varPrecoSugerido
            cmd.Parameters.Add("@STATUSCOMERCIO", SqlDbType.Int).Value = m_indStatusComercio
            cmd.Parameters.Add("@STATUSPESQUISA", SqlDbType.Int).Value = m_indStatusPesquisa
            cmd.Parameters.Add("@CODIGOBARRAS", SqlDbType.VarChar, 60).Value = m_strCodigoBarras

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

            Me.User.Log("Cadastro de Produtos", "Gravar - IDPRODUTO=" & m_intIDProduto & " CODIGO=" & m_strCodigo & " DESCRICAO=" & m_strDescricao & _
                        " DESCRICAORESUMIDA=" & m_strDescricaoResumida & " IDSUBCATEGORIA=" & m_intIDSubCategoria & " IDFORNECEDOR=" & m_intIDFornecedor & _
                        " PRECOMINIMO=" & m_varPrecoMinimo & " PRECOMAXIMO=" & m_varPrecoMaximo & " PRECOSUGERIDO=" & m_varPrecoSugerido & _
                        " STATUSCOMERCIO=" & m_indStatusComercio & " STATUSPESQUISA=" & m_indStatusPesquisa & " CODIGOBARRAS=" & m_strCodigoBarras)

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
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

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

            Me.User.Log("Cadastro de Produtos", "Visualizar - IDPRODUTO=" & vIDProduto)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDProduto = 0
            m_strCodigo = ""
            m_strDescricao = ""
            m_strDescricaoResumida = ""
            m_intIDSubCategoria = 0
            m_intIDFornecedor = 0
            m_strCriado = ""
            m_varPrecoMinimo = Nothing
            m_varPrecoMaximo = Nothing
            m_varPrecoSugerido = Nothing
            m_indStatusComercio = 0
            m_indStatusPesquisa = 0
            m_strCodigoBarras = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PRODUTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Produtos", "Apagar - IDPRODUTO=" & m_intIDProduto)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Produto' the following row:  IDProduto=" & m_intIDProduto & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDSubCategorias As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOS_SUBCATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDSUBCATEGORIAS", SqlDbType.VarChar, 500).Value = vIDSubCategorias
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa 
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vConcorrente As Boolean, ByVal vReturnType As enReturnType) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = IIf(vConcorrente, "2", "1")
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa 
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vReturnType As enReturnType) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Return Listar(vFilter, 0, 0, 0, vOrder, vDescending, vPage, vPageSize, 1, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCategoria">Filtro</param>
        ''' <param name="vIDSubCategoria">Filtro</param>
        ''' <param name="vIDFornecedor">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, _
                               ByVal vIDFornecedor As Integer, ByVal vConcorrente As clsFornecedor.vOpcaoConcorrente, ByVal vOrder As String, ByVal vDescending As Boolean, _
                               ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vStatus As Integer = 2, _
                               Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@STATUSPROD", SqlDbType.TinyInt).Value = vStatus
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = vConcorrente
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)
        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCategoria">Filtro</param>
        ''' <param name="vIDSubCategoria">Filtro</param>
        ''' <param name="vIDFornecedor">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, _
                               ByVal vIDFornecedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, _
                               ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vStatus As Integer = 2, _
                               Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@STATUSPROD", SqlDbType.TinyInt).Value = vStatus
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        Public Function ListarCampos(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, _
                              ByVal vIDFornecedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, _
                              ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vStatus As Integer = 2) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOS_EXP"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@STATUSPROD", SqlDbType.TinyInt).Value = vStatus
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize


            Return ExecuteDataSet(cmd)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa 
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarProdutosPesquisa(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vConcorrente As Boolean, Optional ByVal vIdStatus As Integer = 3, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = IIf(vConcorrente, "2", "1")
            cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = vIdStatus
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa 
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarPrecosProduto(ByVal vIdProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOS_PRECOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa 
        ''' </summary>
        Public Sub AdicionarPrecosProduto(ByVal vIdProduto As Integer, ByVal vUF As String, ByVal vPrecoMinimo As String, ByVal vPrecoMaximo As String)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PRODUTOS_PRECOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            cmd.Parameters.Add("@PRECOMINIMO", SqlDbType.Money).Value = vPrecoMinimo
            cmd.Parameters.Add("@PRECOMAXIMO", SqlDbType.Money).Value = vPrecoMaximo
            ExecuteNonQuery(cmd)

        End Sub

        Public Sub ExcluirPrecoSugerido(ByVal vIdProduto As Integer, ByVal vUF As String)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PRODUTOS_PRECOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            ExecuteNonQuery(cmd)

        End Sub


        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDProduto">Chave primaria IDProduto do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDProduto As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTO_EXISTENTE"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 25).Value = vCodigo
            Return ExecuteScalar(cmd)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vIdCategoria">Id da Categoria</param>		
        ''' <param name="vMovimento">Up ou Down</param>		
        Public Sub TrocarOrdem(ByVal vIdCategoria As Integer, ByVal vMovimento As Integer)
            'Movimentos
            '1 - UP
            '2 - DOWNN
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_TROCAORDEM_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdCategoria
            cmd.Parameters.Add("@MOVIMENTO", SqlDbType.Int).Value = vMovimento
            MyBase.ExecuteNonQuery(cmd)

        End Sub


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCodigo = "" Then
                AddBrokenRule("O código é obrigatorio!")
                blnValid = False
            ElseIf Existe(m_intIDProduto, m_strCodigo) Then
                AddBrokenRule("O Codigo informado ja existe!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region




    End Class
End Namespace

