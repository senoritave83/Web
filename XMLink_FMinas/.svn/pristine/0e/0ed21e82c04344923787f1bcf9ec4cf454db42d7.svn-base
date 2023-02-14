

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsBloqueio
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDBloqueio As Integer
		Protected m_strBloqueio As String
		Protected m_varPermitePedido As Boolean
		Protected m_strCriado As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDBloqueio As Integer
			Get
				Return m_intIDBloqueio
			End Get
		End Property

		Public Overridable Property Bloqueio As String
			Get
				Return m_strBloqueio
			End Get
			Set(ByVal Value As String)
				m_strBloqueio = Value
			End Set
		End Property

		Public Overridable Property PermitePedido As Boolean
			Get
				Return m_varPermitePedido
			End Get
			Set(ByVal Value As Boolean)
				m_varPermitePedido = Value
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
			m_intIDBloqueio = dr.GetInt32(dr.GetOrdinal("IDBloqueio"))
			m_strBloqueio = dr.GetString(dr.GetOrdinal("Bloqueio"))
			m_varPermitePedido = dr.GetBoolean(dr.GetOrdinal("PermitePedido"))
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_BLOQUEIO"
			cmd.Parameters.Add("@IDBLOQUEIO", SqlDbType.Int).value = m_intIDBloqueio
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@BLOQUEIO", SqlDbType.VarChar, 30).value = m_strBloqueio
			cmd.Parameters.Add("@PERMITEPEDIDO", SqlDbType.Bit).value = m_varPermitePedido
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
        ''' <param name="vIDBloqueio">Chave primaria IDBloqueio</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDBloqueio As Integer) As Boolean
			If vIDBloqueio = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_BLOQUEIO"
			cmd.Parameters.Add("@IDBLOQUEIO", SqlDbType.Int).value = vIDBloqueio
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
		End Function			

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDBloqueio = 0
			m_strBloqueio = ""
			m_varPermitePedido = Nothing
			m_strCriado = ""
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_BLOQUEIO"
			cmd.Parameters.Add("@IDBLOQUEIO", SqlDbType.Int).value = m_intIDBloqueio
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Bloqueio' the following row:  IDBloqueio=" & m_intIDBloqueio & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_BLOQUEIOS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

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
            cmd.CommandText = PREFIXO & "NV_BLOQUEIOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function
	  


		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

