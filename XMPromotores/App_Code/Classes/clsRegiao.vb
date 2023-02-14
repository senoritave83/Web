

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsRegiao
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDRegiao As Integer
		Protected m_strRegiao As String
		Protected m_strCriado As String

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDRegiao As Integer
			Get
				Return m_intIDRegiao
			End Get
		End Property

		Public Overridable Property Regiao As String
			Get
				Return m_strRegiao
			End Get
			Set(ByVal Value As String)
				m_strRegiao = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDRegiao = 0
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDRegiao = dr.GetInt32(dr.GetOrdinal("IDRegiao"))
            If dr.IsDBNull(dr.GetOrdinal("Regiao")) Then
                m_strRegiao = ""
            Else
                m_strRegiao = dr.GetString(dr.GetOrdinal("Regiao"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))


        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_REGIAO"
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = m_intIDRegiao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@REGIAO", SqlDbType.VarChar, 50).Value = m_strRegiao

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

            Me.User.Log("Promotor", "Update - IDREGIAO=" & m_intIDRegiao & " REGIAO=" & m_strRegiao)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDRegiao">Chave primaria IDRegiao</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDRegiao As Integer) As Boolean

            If vIDRegiao = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_REGIAO"
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
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

            Me.User.Log("Promotor", "Load - IDREGIAO=" & vIDRegiao)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDRegiao = 0
            m_strRegiao = ""
            m_strCriado = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_REGIAO"
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = m_intIDRegiao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Regiao' the following row:  IDRegiao=" & m_intIDRegiao & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

            Me.User.Log("Promotor", "Delete - IDREGIAO=" & m_intIDRegiao)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_REGIOES"
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

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_REGIOES"
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
        ''' <param name="vIDRegiao">Chave primaria do registro atual.</param>
        ''' <param name="vNome">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDRegiao As Integer, ByVal vNome As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_REGIAO_EXISTENTE"
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@REGIAO", SqlDbType.VarChar, 50).Value = vNome

            Return ExecuteScalar(cmd)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strRegiao = "" Then
                AddBrokenRule("Por favor informe o nome da região!")
                blnValid = False
            ElseIf Existe(m_intIDRegiao, m_strRegiao) Then
                AddBrokenRule("Região informada já existente!")
                blnValid = False
            End If
            Return blnValid
        End Function


#End Region



    End Class
End Namespace

