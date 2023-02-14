

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsVendedor
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDVendedor As Integer
		Protected m_strVendedor As String
		Protected m_strTelefone As String
		Protected m_strLogin As String
		Protected m_strSenha As String
		Protected m_strID As String
        Protected m_blnTeste As Boolean
        Protected m_strCriado As String
        Protected m_blnEspecial As Boolean
        Protected m_intIDNivel As Integer
        Protected m_blnIsNew As Boolean = True
        Protected m_intIDTipoVendedor As Integer
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDVendedor As Integer
			Get
				Return m_intIDVendedor
			End Get
		End Property

		Public Overridable Property Vendedor As String
			Get
				Return m_strVendedor
			End Get
			Set(ByVal Value As String)
				m_strVendedor = Value
			End Set
		End Property

		Public Overridable Property Telefone As String
			Get
				Return m_strTelefone
			End Get
			Set(ByVal Value As String)
				m_strTelefone = Value
			End Set
		End Property

		Public Overridable Property Login As String
			Get
				Return m_strLogin
			End Get
			Set(ByVal Value As String)
				m_strLogin = Value
			End Set
		End Property

		Public Overridable Property Senha As String
			Get
				Return m_strSenha
			End Get
			Set(ByVal Value As String)
				m_strSenha = Value
			End Set
		End Property

		Public Overridable Property ID As String
			Get
				Return m_strID
			End Get
			Set(ByVal Value As String)
				m_strID = Value
			End Set
		End Property

        Public Property IDNivel() As Integer
            Get
                Return m_intIDNivel
            End Get
            Set(ByVal value As Integer)
                m_intIDNivel = value
            End Set
        End Property

        Public Property IDTipoVendedor() As Integer
            Get
                Return m_intIDTipoVendedor
            End Get
            Set(ByVal value As Integer)
                m_intIDTipoVendedor = value
            End Set
        End Property

        Public Overridable Property Teste() As Boolean
            Get
                Return m_blnTeste
            End Get
            Set(ByVal Value As Boolean)
                m_blnTeste = Value
            End Set
        End Property

        Public Overridable Property Especial() As Boolean
            Get
                Return m_blnEspecial
            End Get
            Set(ByVal Value As Boolean)
                m_blnEspecial = Value
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
			m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
			m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
			if dr.IsDBNull(dr.GetOrdinal("Telefone")) Then 
				m_strTelefone = ""
			else
				m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
			end if
			m_strLogin = dr.GetString(dr.GetOrdinal("Login"))
			if dr.IsDBNull(dr.GetOrdinal("Senha")) Then 
				m_strSenha = ""
			else
				m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("ID")) Then 
				m_strID = ""
			else
				m_strID = dr.GetString(dr.GetOrdinal("ID"))
			end if
            If dr.IsDBNull(dr.GetOrdinal("Teste")) Then
                m_blnTeste = False
            Else
                m_blnTeste = (dr.GetInt32(dr.GetOrdinal("Teste")) = 1)
            End If
            If dr.IsDBNull(dr.GetOrdinal("Especial")) Then
                m_blnEspecial = False
            Else
                m_blnEspecial = (dr.GetBoolean(dr.GetOrdinal("Especial")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDNivel")) Then
                m_intIDNivel = 0
            Else
                m_intIDNivel = (dr.GetInt32(dr.GetOrdinal("IDNivel")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDTipoVendedor")) Then
                m_intIDTipoVendedor = 0
            Else
                m_intIDTipoVendedor = (dr.GetInt32(dr.GetOrdinal("IDTipoVendedor")))
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
			cmd.CommandText = PREFIXO & "SV_VENDEDOR"
			cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = m_intIDVendedor
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar, 30).value = m_strVendedor
			cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).value = m_strTelefone
			cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).value = m_strLogin
			cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).value = m_strSenha
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).value = m_strID
            cmd.Parameters.Add("@TESTE", SqlDbType.Bit).Value = m_blnTeste
            cmd.Parameters.Add("@ESPECIAL", SqlDbType.Bit).Value = m_blnEspecial
            cmd.Parameters.Add("@IDNIVEL", SqlDbType.Int).Value = m_intIDNivel
            cmd.Parameters.Add("@IDTIPOVENDEDOR", SqlDbType.Int).Value = m_intIDTipoVendedor
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
        ''' <param name="vIDVendedor">Chave primaria IDVendedor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVendedor As Integer, ByVal vIdEmpresa As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDVendedor = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VENDEDOR"
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
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
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVendedor">Chave primaria IDVendedor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVendedor As Integer) As Boolean
            Return Load(vIDVendedor, User.IDEmpresa)
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDVendedor = 0
			m_strVendedor = ""
			m_strTelefone = ""
			m_strLogin = ""
			m_strSenha = ""
			m_strID = ""
            m_blnTeste = False
            m_strCriado = ""
            m_blnEspecial = False
            m_intIDNivel = 0
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_VENDEDOR"
			cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = m_intIDVendedor
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Vendedor' the following row:  IDVendedor=" & m_intIDVendedor & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
        End Sub

	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_VENDEDORES"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarGerenteVendas(ByVal vIDEmpresa As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_GERENTE_VENDAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            Return ExecuteCommand(cmd, vReturnType)
        End Function



        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarSupervisores(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return ListarSupervisores(0, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarSupervisores(ByVal vIdGerenteVendas As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return ListarSupervisores(User.IDEmpresa, vIdGerenteVendas, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarSupervisores(ByVal vIDEmpresa As Integer, ByVal vIdGerenteVendas As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_SUPERVISORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIdGerenteVendas
            Return ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa com o campo de grupo
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDGrupo As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VENDEDORES_GRUPO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDGRUPO", SqlDbType.Int).Value = vIDGrupo
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa com o campo de grupo
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarVendedoresSup(ByVal vIDSupervisor As Integer, ByVal vIDEmpresa As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VENDEDORES_SUPERVISOR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa com o campo de grupo
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarVendedoresSup(ByVal vIDSupervisor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Return ListarVendedoresSup(vIDSupervisor, User.IDEmpresa, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa com o campo de grupo
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDGrupo As Integer, ByVal vIDSupervisor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VENDEDORES_GRUPO_SUPERVISOR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDGRUPO", SqlDbType.Int).Value = vIDGrupo
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
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
			cmd.CommandText = PREFIXO & "NV_VENDEDORES"
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

