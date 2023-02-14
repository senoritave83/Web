

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics


Namespace Classes

	Public Class clsTipo
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDTipo As Integer
		Protected m_strTipo As String
		Protected m_intTamanho As Short
		Protected m_strCriado As String
        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDTipo As Integer
			Get
				Return m_intIDTipo
			End Get
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

		Public Overridable Property Tipo As String
			Get
				Return m_strTipo
			End Get
			Set(ByVal Value As String)
				m_strTipo = Value
			End Set
		End Property

		Public Overridable Property Tamanho As Short
			Get
				Return m_intTamanho
			End Get
			Set(ByVal Value As Short)
				m_intTamanho = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property


	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDTipo = dr.GetInt32(dr.GetOrdinal("IDTipo"))
            If dr.IsDBNull(dr.GetOrdinal("Tipo")) Then
                m_strTipo = ""
            Else
                m_strTipo = dr.GetString(dr.GetOrdinal("Tipo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Tamanho")) Then
                m_intTamanho = 0
            Else
                m_intTamanho = dr.GetInt16(dr.GetOrdinal("Tamanho"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Criado")) Then
                m_strCriado = ""
            Else
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            End If
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_TIPO"
            cmd.Parameters.Add("@IDTIPO", SqlDbType.Int).Value = m_intIDTipo
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 50).Value = m_strTipo
            cmd.Parameters.Add("@TAMANHO", SqlDbType.SmallInt).Value = m_intTamanho
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
        ''' <param name="vIDTipo">Chave primaria IDTipo</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDTipo As Integer) As Boolean
            If vIDTipo = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TIPO"
            cmd.Parameters.Add("@IDTIPO", SqlDbType.Int).Value = vIDTipo
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
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDTipo = 0
            m_strTipo = ""
            m_intTamanho = 0
            m_strCriado = ""
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_TIPO"
            cmd.Parameters.Add("@IDTIPO", SqlDbType.Int).Value = m_intIDTipo
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Tipo' the following row:  IDTipo=" & m_intIDTipo & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_TIPOS"
            cmd.CommandType = CommandType.StoredProcedure
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
            cmd.CommandText = PREFIXO & "NV_TIPOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)
        End Function
	  
        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Return True
        End Function

	#End Region



	End Class
End Namespace

