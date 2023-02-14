

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsTipoVendedor
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDTipoVendedor As Integer
		Protected m_strTipoVendedor As String
		Protected m_intFuso As Integer
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDTipoVendedor As Integer
			Get
				Return m_intIDTipoVendedor
			End Get
		End Property

		Public Overridable Property TipoVendedor As String
			Get
				Return m_strTipoVendedor
			End Get
			Set(ByVal Value As String)
				m_strTipoVendedor = Value
			End Set
		End Property

		Public Overridable Property Fuso As Integer
			Get
				Return m_intFuso
			End Get
			Set(ByVal Value As Integer)
				m_intFuso = Value
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
			m_intIDTipoVendedor = dr.GetInt32(dr.GetOrdinal("IDTipoVendedor"))
			m_strTipoVendedor = dr.GetString(dr.GetOrdinal("TipoVendedor"))
			m_intFuso = dr.GetInt32(dr.GetOrdinal("Fuso"))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_TIPOVENDEDOR"
			cmd.Parameters.Add("@IDTIPOVENDEDOR", SqlDbType.Int).value = m_intIDTipoVendedor
			cmd.Parameters.Add("@TIPOVENDEDOR", SqlDbType.VarChar, 50).value = m_strTipoVendedor
			cmd.Parameters.Add("@FUSO", SqlDbType.Int).value = m_intFuso
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
        ''' <param name="vIDTipoVendedor">Chave primaria IDTipoVendedor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDTipoVendedor As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDTipoVendedor = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TIPOVENDEDOR"
            cmd.Parameters.Add("@IDTIPOVENDEDOR", SqlDbType.Int).Value = vIDTipoVendedor
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
			m_intIDTipoVendedor = 0
			m_strTipoVendedor = ""
			m_intFuso = 0
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_TIPOVENDEDOR"
			cmd.Parameters.Add("@IDTIPOVENDEDOR", SqlDbType.Int).value = m_intIDTipoVendedor

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'TipoVendedor' the following row:  IDTipoVendedor=" & m_intIDTipoVendedor & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_TIPOVENDEDORES"
            cmd.CommandType = CommandType.StoredProcedure
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vFuso">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
		Public Function Listar(ByVal vFilter As String, vFuso As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_TIPOVENDEDORES"
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@FUSO", SqlDbType.Int).value = vFuso
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

