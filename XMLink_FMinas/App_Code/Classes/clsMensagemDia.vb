

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsMensagemDia
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDMensagemDia As Integer
		Protected m_strMensagem As String
		Protected m_strDataInicio As String
		Protected m_strDataDim As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDMensagemDia As Integer
			Get
				Return m_intIDMensagemDia
			End Get
		End Property

		Public Overridable Property Mensagem As String
			Get
				Return m_strMensagem
			End Get
			Set(ByVal Value As String)
				m_strMensagem = Value
			End Set
		End Property

		Public Overridable Property DataInicio As String
			Get
				Return _getDateTimePropertyValue(m_strDataInicio)
			End Get
			Set(ByVal Value As String)
				m_strDataInicio = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property DataDim As String
			Get
				Return _getDateTimePropertyValue(m_strDataDim)
			End Get
			Set(ByVal Value As String)
				m_strDataDim = _setDateTimePropertyValue(Value)
			End Set
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
			m_intIDMensagemDia = dr.GetInt32(dr.GetOrdinal("IDMensagemDia"))
			m_strMensagem = dr.GetString(dr.GetOrdinal("Mensagem"))
			if dr.IsDBNull(dr.GetOrdinal("DataInicio")) Then 
				m_strDataInicio = ""
			else
				m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("DataDim")) Then 
				m_strDataDim = ""
			else
				m_strDataDim = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataDim")))
			end if
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_MENSAGEMDIA"
			cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).value = m_intIDMensagemDia
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 255).value = m_strMensagem
			If m_strDataInicio <> "" Then
				cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strDataInicio)
			End if
			If m_strDataDim <> "" Then
				cmd.Parameters.Add("@DATADIM", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strDataDim)
			End if
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
        ''' <param name="vIDMensagemDia">Chave primaria IDMensagemDia</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDMensagemDia As Integer) As Boolean
			If vIDMensagemDia = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_MENSAGEMDIA"
			cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).value = vIDMensagemDia
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
			m_intIDMensagemDia = 0
			m_strMensagem = ""
			m_strDataInicio = ""
			m_strDataDim = ""
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_MENSAGEMDIA"
			cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).value = m_intIDMensagemDia
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MensagemDia' the following row:  IDMensagemDia=" & m_intIDMensagemDia & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_MENSAGEMDIAS"
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
		Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_MENSAGEMDIAS"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
			cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
			cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
			cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

		End Function
	  


		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

