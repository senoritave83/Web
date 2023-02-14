

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsJustificativaRuptura
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDJustificativaRuptura As Integer
		Protected m_strJustificativaRuptura As String
        Protected m_strCriado As String
        Protected m_intConcorrente As Integer '0-Não Mostrar, 1-Produto próprio, 2-Produto concorrente, 3-Todos
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable Property IDJustificativaRuptura As Integer
			Get
				Return m_intIDJustificativaRuptura
			End Get
			Set(ByVal Value As Integer)
				m_intIDJustificativaRuptura = Value
			End Set
		End Property

		Public Overridable Property JustificativaRuptura As String
			Get
				Return m_strJustificativaRuptura
			End Get
			Set(ByVal Value As String)
				m_strJustificativaRuptura = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public Overridable Property Concorrente As Integer
            Get
                Return m_intConcorrente
            End Get
            Set(ByVal value As Integer)
                m_intConcorrente = value
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
			m_intIDJustificativaRuptura = dr.GetInt32(dr.GetOrdinal("IDJustificativaRuptura"))
			if dr.IsDBNull(dr.GetOrdinal("JustificativaRuptura")) Then 
				m_strJustificativaRuptura = ""
			else
				m_strJustificativaRuptura = dr.GetString(dr.GetOrdinal("JustificativaRuptura"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Concorrente")) Then
                m_intConcorrente = 0
            Else
                m_intConcorrente = dr.GetByte(dr.GetOrdinal("Concorrente"))
            End If
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_JUSTIFICATIVARUPTURA"
			cmd.Parameters.Add("@IDJUSTIFICATIVARUPTURA", SqlDbType.Int).value = m_intIDJustificativaRuptura
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@JUSTIFICATIVARUPTURA", SqlDbType.VarChar, 50).Value = m_strJustificativaRuptura
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = m_intConcorrente
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

            Me.User.Log("Cadastro de Justificativas de Ruptura", "Gravar - IDJUSTIFICATIVARUPTURA=" & m_intIDJustificativaRuptura & " JUSTIFICATIVARUPTURA=" & m_strJustificativaRuptura & " CONCORRENTE=" & m_intConcorrente)

        End Sub

        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDJustificativaRuptura">Chave primaria vIDJustificativaRuptura</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDJustificativaRuptura As Integer) As Boolean

            If vIDJustificativaRuptura = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_JUSTIFICATIVARUPTURA"
            cmd.Parameters.Add("@IDJUSTIFICATIVARUPTURA", SqlDbType.Int).Value = vIDJustificativaRuptura
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

            Me.User.Log("Cadastro de Justificativas de Ruptura", "Visualizar - IDJUSTIFICATIVARUPTURA=" & vIDJustificativaRuptura)

        End Function		

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDJustificativaRuptura = 0
			m_strJustificativaRuptura = ""
			m_strCriado = ""
			m_blnIsNew = true 
        End Sub

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_JUSTIFICATIVARUPTURA"
            cmd.Parameters.Add("@IDJUSTIFICATIVARUPTURA", SqlDbType.Int).Value = m_intIDJustificativaRuptura
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Justificativas de Ruptura", "Apagar - IDJUSTIFICATIVARUPTURA=" & m_intIDJustificativaRuptura)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'JustificativaRuptura' the following row:  IDJustificativaRuptura=" & m_intIDJustificativaRuptura & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

            Clear()

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
            cmd.CommandText = PREFIXO & "NV_JUSTIFICATIVASRUPTURA"
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

