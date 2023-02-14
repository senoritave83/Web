

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsCategoria
		Inherits BaseClass

#Region "Declarations"
        Protected m_intIDCategoria As Integer
        Protected m_strCategoria As String
        Protected m_strCriado As String
        Protected m_intOrdem As Integer

#End Region


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCategoria As Integer
			Get
				Return m_intIDCategoria
			End Get
		End Property

		Public Overridable Property Categoria As String
			Get
				Return m_strCategoria
			End Get
			Set(ByVal Value As String)
				m_strCategoria = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable Property Ordem As Integer
			Get
				Return m_intOrdem
			End Get
			Set(ByVal Value As Integer)
				m_intOrdem = Value
			End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDCategoria = 0
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
            If dr.IsDBNull(dr.GetOrdinal("Categoria")) Then
                m_strCategoria = ""
            Else
                m_strCategoria = dr.GetString(dr.GetOrdinal("Categoria"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("Ordem")) Then
                m_intOrdem = 0
            Else
                m_intOrdem = dr.GetInt32(dr.GetOrdinal("Ordem"))
            End If

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CATEGORIA"
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = m_intIDCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CATEGORIA", SqlDbType.VarChar, 50).Value = m_strCategoria
            cmd.Parameters.Add("@ORDEM", SqlDbType.Int).Value = m_intOrdem

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

            cmd.Parameters.Add("@ORDEM", SqlDbType.Int).Value = m_intOrdem
            Me.User.Log("Cadastro de Segmentos", "Gravar - IDSEGMENTO=" & m_intIDCategoria & " SEGMENTO=" & m_strCategoria & " ORDEM=" & m_intOrdem)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCategoria">Chave primaria IDCategoria</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCategoria As Integer) As Boolean

            If vIDCategoria = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CATEGORIA"
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
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

            Me.User.Log("Cadastro de Segmentos", "Visualizar - IDSEGMENTO=" & vIDCategoria)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDCategoria = 0
            m_strCategoria = ""
            m_strCriado = ""
            m_intOrdem = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CATEGORIA"
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = m_intIDCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Segmentos", "Apagar - IDSEGMENTO=" & m_intIDCategoria)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Categoria' the following row:  IDCategoria=" & m_intIDCategoria & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_CATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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

 		Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
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
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDCategoria">Chave primaria IDCategoria do registro atual.</param>
        ''' <param name="vCategoria">Categoria que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDCategoria As Integer, ByVal vCategoria As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CATEGORIA_EXISTENTE"
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CATEGORIA", SqlDbType.VarChar, 50).Value = vCategoria

            Return ExecuteScalar(cmd)

        End Function



		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
            Dim blnValid As Boolean = True
            If m_strCategoria = "" Then
                AddBrokenRule("Por favor informe o segmento!")
                blnValid = False
            ElseIf Existe(m_intIDCategoria, m_strCategoria) Then
                AddBrokenRule("Segmento informado existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

	#End Region



	End Class
End Namespace

