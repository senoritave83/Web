

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsMotivoFolga
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDMotivoFolga As Integer
		Protected m_strMotivoFolga As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDMotivoFolga As Integer
			Get
				Return m_intIDMotivoFolga
			End Get
		End Property

		Public Overridable Property MotivoFolga As String
			Get
				Return m_strMotivoFolga
			End Get
			Set(ByVal Value As String)
				m_strMotivoFolga = Value
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
			m_intIDMotivoFolga = dr.GetInt32(dr.GetOrdinal("IDMotivoFolga"))
			m_strMotivoFolga = dr.GetString(dr.GetOrdinal("MotivoFolga"))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_MOTIVOFOLGA"
			cmd.Parameters.Add("@IDMOTIVOFOLGA", SqlDbType.Int).value = m_intIDMotivoFolga
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@MOTIVOFOLGA", SqlDbType.VarChar, 200).value = m_strMotivoFolga
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

            Me.User.Log("Cadastro de Motivos de Ausencia", "Gravar - IDMOTIVOFOLGA=" & m_intIDMotivoFolga & " MOTIVOFOLGA=" & m_strMotivoFolga)


		End Sub

	
        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDMotivoFolga">Chave primaria IDMotivoFolga</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDMotivoFolga As Integer) As Boolean
			If vIDMotivoFolga = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_MOTIVOFOLGA"
			cmd.Parameters.Add("@IDMOTIVOFOLGA", SqlDbType.Int).value = vIDMotivoFolga
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

            Me.User.Log("Cadastro de Motivos de Ausencia", "Visualizar - IDMOTIVOFOLGA=" & vIDMotivoFolga)

		End Function			

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDMotivoFolga = 0
			m_strMotivoFolga = ""
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_MOTIVOFOLGA"
			cmd.Parameters.Add("@IDMOTIVOFOLGA", SqlDbType.Int).value = m_intIDMotivoFolga

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Motivos de Ausencia", "Apagar - IDMOTIVOFOLGA=" & m_intIDMotivoFolga)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MotivoFolga' the following row:  IDMotivoFolga=" & m_intIDMotivoFolga & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()



		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_MOTIVOFOLGAS"
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
			cmd.CommandText = PREFIXO & "NV_MOTIVOFOLGAS"
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

