

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsTabela
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDtabela As Integer
		Protected m_strTabela As String
		Protected m_strCriado As String
        Protected m_blnBonificacao As Boolean
        Protected m_blnAtivo As Boolean
        Protected m_blnAprovacaoManual As Boolean
        Protected m_blnEspecial As Boolean
        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDtabela As Integer
			Get
				Return m_intIDtabela
			End Get
		End Property

		Public Overridable Property Tabela As String
			Get
				Return m_strTabela
			End Get
			Set(ByVal Value As String)
				m_strTabela = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable Property Bonificacao As Boolean
			Get
                Return m_blnBonificacao
			End Get
			Set(ByVal Value As Boolean)
                m_blnBonificacao = Value
			End Set
		End Property

        Public Overridable Property Ativo() As Boolean
            Get
                Return m_blnAtivo
            End Get
            Set(ByVal Value As Boolean)
                m_blnAtivo = Value
            End Set
        End Property


        Public Property AprovacaoManual() As Boolean
            Get
                Return m_blnAprovacaoManual
            End Get
            Set(ByVal value As Boolean)
                m_blnAprovacaoManual = value
            End Set
        End Property

        Public Property Especial() As Boolean
            Get
                Return m_blnEspecial
            End Get
            Set(ByVal value As Boolean)
                m_blnEspecial = value
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
			m_intIDtabela = dr.GetInt32(dr.GetOrdinal("IDtabela"))
			m_strTabela = dr.GetString(dr.GetOrdinal("Tabela"))
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			if dr.IsDBNull(dr.GetOrdinal("Bonificacao")) Then 
                m_blnBonificacao = False
			else
                m_blnBonificacao = dr.GetBoolean(dr.GetOrdinal("Bonificacao"))
			end if
            If dr.IsDBNull(dr.GetOrdinal("Ativo")) Then
                m_blnAtivo = False
            Else
                m_blnAtivo = dr.GetBoolean(dr.GetOrdinal("Ativo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("AprovacaoManual")) Then
                m_blnAprovacaoManual = False
            Else
                m_blnAprovacaoManual = dr.GetBoolean(dr.GetOrdinal("AprovacaoManual"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Especial")) Then
                m_blnEspecial = False
            Else
                m_blnEspecial = dr.GetBoolean(dr.GetOrdinal("Especial"))
            End If
            m_blnIsNew = False
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_TABELA"
			cmd.Parameters.Add("@IDTABELA", SqlDbType.Int).value = m_intIDtabela
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@TABELA", SqlDbType.VarChar, 50).value = m_strTabela
            cmd.Parameters.Add("@BONIFICACAO", SqlDbType.Bit).Value = m_blnBonificacao
            cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = m_blnAtivo
            cmd.Parameters.Add("@APROVACAOMANUAL", SqlDbType.Bit).Value = m_blnAprovacaoManual
            cmd.Parameters.Add("@ESPECIAL", SqlDbType.Bit).Value = m_blnEspecial
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
        ''' <param name="vIDtabela">Chave primaria IDtabela</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDtabela As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDtabela = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TABELA"
            cmd.Parameters.Add("@IDTABELA", SqlDbType.Int).Value = vIDtabela
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
			m_intIDtabela = 0
			m_strTabela = ""
			m_strCriado = ""
            m_blnBonificacao = False
            m_blnAtivo = True
            m_blnAprovacaoManual = False
            m_blnEspecial = False
			m_blnIsNew = true 
		End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_TABELAS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vIDVendedor">Chave primária do vendedor</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDVendedor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_TABELAS_VENDEDORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vAtivo">Filtro</param>
        ''' <param name="vBonificacao">Filtro</param>
        ''' <param name="vAprovacaoManual">Filtro</param>
        ''' <param name="vEspecial">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vAtivo As Byte, ByVal vBonificacao As Byte, ByVal vAprovacaoManual As Byte, ByVal vEspecial As Byte, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_TABELAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
            cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).value = vAtivo
            cmd.Parameters.Add("@BONIFICACAO", SqlDbType.TinyInt).value = vBonificacao
            cmd.Parameters.Add("@APROVACAOMANUAL", SqlDbType.TinyInt).value = vAprovacaoManual
            cmd.Parameters.Add("@ESPECIAL", SqlDbType.TinyInt).value = vEspecial
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarTabelas(ByVal vIdProduto As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTO_TABELAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Rotina que gravar as Tabelas dos vendedores
        ''' </summary>
        Public Sub GravaTabelaProduto(ByVal vIdProduto As Integer, ByVal vIdTabela As Integer, ByVal vQuantidadeMinima As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_TABELA_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDTABELA", SqlDbType.Int).Value = vIdTabela
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            cmd.Parameters.Add("@QtdeMinima", SqlDbType.Int).Value = vQuantidadeMinima
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Me.User.IDUser

            ExecuteNonQuery(cmd)

        End Sub


        ''' <summary>
        ''' 	Rotina que gravar as Tabelas dos vendedores
        ''' </summary>
        Public Sub GravaTabelasVendedor(ByVal vIDVendedor As Integer, ByVal vIDTabela As Integer, ByVal vSelected As Boolean)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_TABELA_VENDEDOR"
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDTABELA", SqlDbType.Int).Value = vIDTabela
            cmd.Parameters.Add("@SELECTED", SqlDbType.Bit).Value = vSelected
            ExecuteNonQuery(cmd)
        End Sub



		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

