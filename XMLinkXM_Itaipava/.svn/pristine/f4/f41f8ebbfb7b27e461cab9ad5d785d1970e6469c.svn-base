

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsJustificativaPesquisa
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDJustificativa As Integer
		Protected m_strJustificativa As String
		Protected m_strCriado As String
        Protected m_blnIsNew As Boolean = True
        Protected m_blnReincidencia As Boolean
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDJustificativa As Integer
			Get
				Return m_intIDJustificativa
			End Get
		End Property

		Public Overridable Property Justificativa As String
			Get
				Return m_strJustificativa
			End Get
			Set(ByVal Value As String)
				m_strJustificativa = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public Property Reincidencia() As Boolean
            Get
                Return m_blnReincidencia
            End Get
            Set(ByVal value As Boolean)
                m_blnReincidencia = value
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
			m_intIDJustificativa = dr.GetInt32(dr.GetOrdinal("IDJustificativa"))
			m_strJustificativa = dr.GetString(dr.GetOrdinal("Justificativa"))
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            m_blnReincidencia = dr.GetByte(dr.GetOrdinal("Reincidencia"))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_JUSTIFICATIVAPESQUISA"
			cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).value = m_intIDJustificativa
            cmd.Parameters.Add("@JUSTIFICATIVA", SqlDbType.VarChar, 100).Value = m_strJustificativa
            cmd.Parameters.Add("@REINCIDENCIA", SqlDbType.Bit).Value = m_blnReincidencia
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
        ''' <param name="vIDJustificativa">Chave primaria IDJustificativa</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDJustificativa As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDJustificativa = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_JUSTIFICATIVAPESQUISA"
            cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).Value = vIDJustificativa
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
			m_intIDJustificativa = 0
			m_strJustificativa = ""
            m_strCriado = ""
            m_blnReincidencia = False
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_JUSTIFICATIVAPESQUISA"
			cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).value = m_intIDJustificativa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'JustificativaPesquisa' the following row:  IDJustificativa=" & m_intIDJustificativa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_JUSTIFICATIVAPESQUISAS"
            cmd.CommandType = CommandType.StoredProcedure
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
			cmd.CommandText = PREFIXO & "NV_JUSTIFICATIVAPESQUISAS"
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

