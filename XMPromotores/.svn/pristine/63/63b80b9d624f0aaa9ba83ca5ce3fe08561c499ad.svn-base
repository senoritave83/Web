

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsFornecedor
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDFornecedor As Integer
		Protected m_strFornecedor As String
		Protected m_strCriado As String
        Protected m_blnConcorrente As Boolean

        Public Enum vOpcaoConcorrente As Byte
            Todos = 2
            Propria = 0
            Concorrente = 1
        End Enum

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDFornecedor As Integer
			Get
				Return m_intIDFornecedor
			End Get
		End Property

		Public Overridable Property Fornecedor As String
			Get
				Return m_strFornecedor
			End Get
			Set(ByVal Value As String)
				m_strFornecedor = Value
			End Set
		End Property

        Public Property Concorrente() As Boolean
            Get
                Return m_blnConcorrente
            End Get
            Set(ByVal value As Boolean)
                m_blnConcorrente = value
            End Set
        End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDFornecedor = 0
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDFornecedor = dr.GetInt32(dr.GetOrdinal("IDFornecedor"))
            If dr.IsDBNull(dr.GetOrdinal("Fornecedor")) Then
                m_strFornecedor = ""
            Else
                m_strFornecedor = dr.GetString(dr.GetOrdinal("Fornecedor"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Criado")) Then
                m_strCriado = ""
            Else
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Concorrente")) Then
                m_blnConcorrente = False
            Else
                m_blnConcorrente = dr.GetBoolean(dr.GetOrdinal("Concorrente"))
            End If

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_FORNECEDOR"
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = m_intIDFornecedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FORNECEDOR", SqlDbType.VarChar, 50).Value = m_strFornecedor
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.Bit).Value = m_blnConcorrente
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

            Me.User.Log("Cadastro de Marcas", "Gravar - IDMARCA=" & m_intIDFornecedor & " MARCA=" & m_strFornecedor & " CONCORRENTE=" & m_blnConcorrente)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDFornecedor">Chave primaria IDFornecedor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDFornecedor As Integer) As Boolean

            If vIDFornecedor = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_FORNECEDOR"
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
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

            Me.User.Log("Cadastro de Marcas", "Visualizar - IDMARCA=" & vIDFornecedor)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDFornecedor = 0
            m_strFornecedor = ""
            m_strCriado = ""
            m_blnConcorrente = False
        End Sub



        ''' <summary>
        ''' 	Rotina que inativa o registro atual
        ''' </summary>
        Public Function Delete() As Integer

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_FORNECEDOR"
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = m_intIDFornecedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim drDelete As IDataReader = ExecuteReader(cmd)

            Try
                If drDelete.Read Then

                    If drDelete.GetInt32(drDelete.GetOrdinal("Retorno")) = 1 Then
                        Me.User.Log("Cadastro de Marcas", "Apagar - IDMARCA=" & m_intIDFornecedor)
                        MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Fornecedor' the following row:  IDFornecedor=" & m_intIDFornecedor & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                    End If

                    Clear()
                    Return drDelete.GetInt32(drDelete.GetOrdinal("Retorno"))
                End If
            Finally
                If (Not drDelete Is Nothing) Then
                    drDelete.Close()
                    drDelete = Nothing
                End If
            End Try

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object


            'Dim cmd As New SqlCommand()
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.CommandText = PREFIXO & "LS_FORNECEDORES"
            'cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            'Return MyBase.ExecuteCommand(cmd, vReturnType)

            Return Listar(0, vReturnType)

        End Function


        Public Function Listar(ByVal vIdSegmento As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return Listar(vIdSegmento, vOpcaoConcorrente.Todos, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIdSegmento As Integer, ByVal vConcorrente As vOpcaoConcorrente, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object


            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_FORNECEDORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDSEGMENTO", SqlDbType.Int).Value = vIdSegmento
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = vConcorrente
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

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_FORNECEDORES"
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
        ''' <param name="vIDFornecedor">Chave primaria do registro atual.</param>
        ''' <param name="vFornecedor">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDFornecedor As Integer, ByVal vFornecedor As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_FORNECEDOR_EXISTENTE"
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FORNECEDOR", SqlDbType.VarChar, 50).Value = vFornecedor

            Return ExecuteScalar(cmd)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strFornecedor = "" Then
                AddBrokenRule("Por favor informe o nome da marca!")
                blnValid = False
            ElseIf Existe(m_intIDFornecedor, m_strFornecedor) Then
                AddBrokenRule("Marca informada existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

