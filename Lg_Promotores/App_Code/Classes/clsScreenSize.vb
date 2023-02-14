

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsScreenSize
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDScreenSize As Integer
		Protected m_strScreenSize As String
		Protected m_strCriado As String

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDScreenSize As Integer
			Get
				Return m_intIDScreenSize
			End Get
		End Property

		Public Overridable Property ScreenSize As String
			Get
				Return m_strScreenSize
			End Get
			Set(ByVal Value As String)
				m_strScreenSize = Value
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
				m_intIDScreenSize = dr.GetInt32(dr.GetOrdinal("IDScreenSize"))
				m_strScreenSize = dr.GetString(dr.GetOrdinal("ScreenSize"))
				if dr.IsDBNull(dr.GetOrdinal("Criado")) Then 
					m_strCriado = ""
				else
					m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
				end if

		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
				Dim cmd As New SqlCommand()
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = PREFIXO & "SV_SCREENSIZE"
				cmd.Parameters.Add("@IDSCREENSIZE", SqlDbType.Int).value = m_intIDScreenSize
				cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
				cmd.Parameters.Add("@SCREENSIZE", SqlDbType.VarChar, 50).value = m_strScreenSize
	
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
            End Try

            Me.User.Log("ScreenSize", "Update - IDSCREENSIZE=" & m_intIDScreenSize & " SCREENSIZE=" & m_strScreenSize)

		End Sub

	
        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDScreenSize">Chave primaria IDScreenSize</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDScreenSize As Integer) As Boolean

				If vIDScreenSize = 0 Then 
					Clear()
					return false
				End if
				Dim cmd As New SqlCommand()
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = PREFIXO & "SE_SCREENSIZE"
				cmd.Parameters.Add("@IDSCREENSIZE", SqlDbType.Int).value = vIDScreenSize
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
            End Try

            Me.User.Log("ScreenSize", "Load - IDSCREENSIZE=" & vIDScreenSize)

		End Function			

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDScreenSize = 0
			m_strScreenSize = ""
			m_strCriado = ""
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
				Dim cmd As New SqlCommand()
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = PREFIXO & "DE_SCREENSIZE"
				cmd.Parameters.Add("@IDSCREENSIZE", SqlDbType.Int).value = m_intIDScreenSize
				cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
				
            ExecuteNonQuery(cmd)
					myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'ScreenSize' the following row:  IDScreenSize=" & m_intIDScreenSize & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

            Clear()

            Me.User.Log("ScreenSize", "Delete - IDSCREENSIZE=" & m_intIDScreenSize)

		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object
			Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_SCREENSIZES"
				cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
      
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
		Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

				Dim cmd As New SqlCommand()
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = PREFIXO & "NV_SCREENSIZES"
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
		end Function

	#End Region



	End Class
End Namespace

