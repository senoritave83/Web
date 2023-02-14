

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsRegional
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDRegional As Integer
		Protected m_strRegional As String
		Protected m_intIDSuperior As Integer
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDRegional As Integer
			Get
				Return m_intIDRegional
			End Get
		End Property

		Public Overridable Property Regional As String
			Get
				Return m_strRegional
			End Get
			Set(ByVal Value As String)
				m_strRegional = Value
			End Set
		End Property

		Public Overridable Property IDSuperior As Integer
			Get
				Return m_intIDSuperior
			End Get
			Set(ByVal Value As Integer)
				m_intIDSuperior = Value
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
			m_intIDRegional = dr.GetInt32(dr.GetOrdinal("IDRegional"))
			m_strRegional = dr.GetString(dr.GetOrdinal("Regional"))
			if dr.IsDBNull(dr.GetOrdinal("IDSuperior")) Then 
				m_intIDSuperior = 0
			else
				m_intIDSuperior = dr.GetInt32(dr.GetOrdinal("IDSuperior"))
			end if
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_REGIONAL"
			cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).value = m_intIDRegional
			cmd.Parameters.Add("@REGIONAL", SqlDbType.VarChar, 50).value = m_strRegional
			cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).value = m_intIDSuperior
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
        ''' <param name="vIDRegional">Chave primaria IDRegional</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDRegional As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDRegional = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_REGIONAL"
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIDRegional
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
			m_intIDRegional = 0
			m_strRegional = ""
			m_intIDSuperior = 0
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_REGIONAL"
			cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).value = m_intIDRegional

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Regional' the following row:  IDRegional=" & m_intIDRegional & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_REGIONAIS"
            cmd.CommandType = CommandType.StoredProcedure
          	Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem das empresas pertencentes a regional
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarEmpresas(ByVal vIDRegional As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_REGIONAL_EMPRESAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIDRegional
            Return ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem das empresas pertencentes a regional
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarRegionaisSubordinadas(ByVal vIDRegional As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_REGIONAIS_SUBORDINADAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIDRegional
            Return ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem das empresas pertencentes a regional
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarRegionaisPossiveisSuperiores(ByVal vIDRegional As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_REGIONAIS_POSSIVEIS_SUPERIORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIDRegional
            Return ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem das empresas pertencentes a regional
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarEmpresas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return ListarEmpresas(m_intIDRegional, vReturnType)
        End Function

        Public Function RegionaisUsuario() As IDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_REGIONAIS_USUARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            Return ExecuteReader(cmd)
        End Function

        Public Function IsEmpresaInRegional(ByVal vIDEmpresa As Integer) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "SE_REGIONAL_EMPRESA_PERTENCE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = m_intIDRegional
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            Return ExecuteScalar(cmd)
        End Function

        Public Sub RemoveEmpresaToRegional(ByVal vIDEmpresa As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "DE_REGIONAL_EMPRESA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = m_intIDRegional
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            ExecuteNonQuery(cmd)
        End Sub

        Public Sub AddEmpresaToRegional(ByVal vIDEmpresa As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "IN_REGIONAL_EMPRESA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = m_intIDRegional
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            ExecuteNonQuery(cmd)
        End Sub


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
            cmd.CommandText = PREFIXO & "NV_REGIONAIS"
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

