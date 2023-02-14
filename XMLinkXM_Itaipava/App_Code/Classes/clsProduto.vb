

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsProduto
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDProduto As Integer
		Protected m_strDescricao As String
		Protected m_intEmbalagem As Integer
		Protected m_strTipo As String
        Protected m_intIDCategoria As Integer
        Protected m_intIDLinha As Integer
        Protected m_strCriado As String
        Protected m_blnIsNew As Boolean = True
        Protected m_blnBonificacao As Boolean
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDProduto As Integer
			Get
				Return m_intIDProduto
			End Get
		End Property

		Public Overridable Property Descricao As String
			Get
				Return m_strDescricao
			End Get
			Set(ByVal Value As String)
				m_strDescricao = Value
			End Set
		End Property

		Public Overridable Property Embalagem As Integer
			Get
				Return m_intEmbalagem
			End Get
			Set(ByVal Value As Integer)
				m_intEmbalagem = Value
			End Set
		End Property

		Public Overridable Property Tipo As String
			Get
				Return m_strTipo
			End Get
			Set(ByVal Value As String)
				m_strTipo = Value
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

        Public Overridable Property IDLinha() As Integer
            Get
                Return m_intIDLinha
            End Get
            Set(ByVal Value As Integer)
                m_intIDLinha = Value
            End Set
        End Property

        Public Overridable Property Bonificacao() As Boolean
            Get
                Return m_blnBonificacao
            End Get
            Set(ByVal Value As Boolean)
                m_blnBonificacao = Value
            End Set
        End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property



		Public readonly property IsNew() as Boolean
			Get
				return m_blnIsNew
			End Get
		end Property
		
	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
			m_strDescricao = dr.GetString(dr.GetOrdinal("Descricao"))
			if dr.IsDBNull(dr.GetOrdinal("Embalagem")) Then 
				m_intEmbalagem = 0
			else
				m_intEmbalagem = dr.GetInt32(dr.GetOrdinal("Embalagem"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Tipo")) Then 
				m_strTipo = ""
			else
				m_strTipo = dr.GetString(dr.GetOrdinal("Tipo"))
			end if
			m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
            If dr.IsDBNull(dr.GetOrdinal("IDLinha")) Then
                m_intIDLinha = 0
            Else
                m_intIDLinha = dr.GetInt32(dr.GetOrdinal("IDLinha"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Bonificacao")) Then
                m_blnBonificacao = False
            Else
                m_blnBonificacao = dr.GetBoolean(dr.GetOrdinal("Bonificacao"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			m_blnIsNew = false
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
			cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 40).value = m_strDescricao
			cmd.Parameters.Add("@EMBALAGEM", SqlDbType.Int).value = m_intEmbalagem
			cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).value = m_strTipo
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = m_intIDCategoria
            cmd.Parameters.Add("@IDLINHA", SqlDbType.Int).Value = m_intIDLinha
            cmd.Parameters.Add("@BONIFICACAO", SqlDbType.Int).Value = m_blnBonificacao
            Dim dr As IDataReader = ExecuteReader(cmd)
			try
				If dr.Read Then
					Inflate(dr)
				Else
					Clear()
				End If
			finally
				If (Not dr Is Nothing) Then
					dr.Close()
					dr = Nothing
				End If
			end try
		End Sub

	
        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDProduto">Chave primaria IDProduto</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDProduto As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDProduto = 0 Then
                Clear()
                Return blnReturn
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
                    blnReturn = True
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
            Return blnReturn
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDProduto = 0
			m_strDescricao = ""
			m_intEmbalagem = 0
			m_strTipo = ""
            m_intIDCategoria = 0
            m_intIDLinha = 0
			m_strCriado = ""
            m_blnIsNew = True
            m_blnBonificacao = False
		End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarHistorico(ByVal vIdProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTO_HISTORICO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function

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
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Produto' the following row:  IDProduto=" & m_intIDProduto & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal IDCategoriaProd As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = IDCategoriaProd
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
        Public Function Listar(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vIDLinha As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDLINHA", SqlDbType.Int).Value = vIDLinha
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Public Sub GravaTransacao(ByVal vIDTipoPedido As Integer, ByVal vTransacao As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTO_TRANSACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDTIPOPEDIDO", SqlDbType.Int).Value = vIDTipoPedido
            cmd.Parameters.Add("@TRANSACAO", SqlDbType.Int).Value = vTransacao
            ExecuteNonQuery(cmd)
        End Sub

        Public Function ListarFamilias(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTOFAMILIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function ListarTransacoes(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTO_TRANSACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        Public Function ListarFotosProduto(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As String

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PRODUTO_FOTO"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            Dim DR As SqlDataReader = ExecuteCommand(cmd, vReturnType)

            Dim strReturn As String = ""
            If DR.Read Then
                strReturn = DR(0)
            End If
            Return strReturn

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

        Public Sub AddBrokenRuleTransacao(ByVal vMessage As String)
            AddBrokenRule(vMessage)
        End Sub

#End Region

    End Class
End Namespace

