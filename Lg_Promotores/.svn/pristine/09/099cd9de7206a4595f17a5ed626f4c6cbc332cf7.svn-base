

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsClassificacao
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDClassificacao As Integer
		Protected m_strClassificacao As String
		Protected m_strCriado As String
		Protected m_indTipo As Byte

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDClassificacao As Integer
			Get
				Return m_intIDClassificacao
			End Get
		End Property

		Public Overridable Property Classificacao As String
			Get
				Return m_strClassificacao
			End Get
			Set(ByVal Value As String)
				m_strClassificacao = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public Overridable ReadOnly Property Tipo() As Byte
            Get
                Return m_indTipo
            End Get
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDClassificacao = 0
            End Get
        End Property

#End Region
	
#Region "Metodos"

        Public Sub New(ByVal vIDTipo As Byte)
            MyBase.new()
            m_indTipo = vIDTipo
        End Sub

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDClassificacao = dr.GetInt32(dr.GetOrdinal("IDClassificacao"))
            If dr.IsDBNull(dr.GetOrdinal("Classificacao")) Then
                m_strClassificacao = ""
            Else
                m_strClassificacao = dr.GetString(dr.GetOrdinal("Classificacao"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            m_indTipo = dr.GetByte(dr.GetOrdinal("Tipo"))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CLASSIFICACAO"
            cmd.Parameters.Add("@IDCLASSIFICACAO", SqlDbType.Int).Value = m_intIDClassificacao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CLASSIFICACAO", SqlDbType.VarChar, 50).Value = m_strClassificacao
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = m_indTipo

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

            Me.User.Log("Classificacao", "Update - IDCLASSIFICACAO=" & m_intIDClassificacao & " CLASSIFICACAO=" & m_strClassificacao & " TIPO=" & m_indTipo)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDClassificacao">Chave primaria IDClassificacao</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDClassificacao As Integer) As Boolean

            If vIDClassificacao = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CLASSIFICACAO"
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = m_indTipo
            cmd.Parameters.Add("@IDCLASSIFICACAO", SqlDbType.Int).Value = vIDClassificacao
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

            Me.User.Log("Classificacao", "Load - TIPO=" & m_indTipo & " IDCLASSIFICACAO=" & vIDClassificacao)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDClassificacao = 0
            m_strClassificacao = ""
            m_strCriado = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CLASSIFICACAO"
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = m_indTipo
            cmd.Parameters.Add("@IDCLASSIFICACAO", SqlDbType.Int).Value = m_intIDClassificacao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)
            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Classificacao' the following row:  IDClassificacao=" & m_intIDClassificacao & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

            Clear()

            Me.User.Log("Classificacao", "Delete - TIPO=" & m_indTipo & " IDCLASSIFICACAO=" & m_intIDClassificacao)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLASSIFICACOES"
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = m_indTipo
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            Return MyBase.ExecuteCommand(cmd, vReturnType)
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
            cmd.CommandText = PREFIXO & "NV_CLASSIFICACOES"
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = m_indTipo
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
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

