Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports XMSistemas.Web.Base

Namespace Classes

	Public Class clsVendedor
        Inherits BaseClass

	#Region "Declarations" 
		Protected m_intIDVendedor As Integer
		Protected m_strCodigo As String
		Protected m_strVendedor As String
		Protected m_strTelefone As String
		Protected m_strLogin As String
		Protected m_strSenha As String
		Protected m_strID As String
		Protected m_strObservacao As String
		Protected m_strSubscriberID As String
		Protected m_strRefreshed As String
		Protected m_sngMaxDesconto As Single
		Protected m_strCriado As String
		Protected m_indTodosClientes As Byte
		Protected m_intNumeroPedido As Integer
		Protected m_strGuid As String
        Protected m_clsConsignacao As clsConsignacaoVendedor
        Protected m_clsEstoque As clsPedidoEstoqueVendedor

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDVendedor As Integer
			Get
				Return m_intIDVendedor
			End Get
		End Property

		Public Overridable Property Codigo As String
			Get
				Return m_strCodigo
			End Get
			Set(ByVal Value As String)
				m_strCodigo = Value
			End Set
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

		Public Overridable Property Observacao As String
			Get
				Return m_strObservacao
			End Get
			Set(ByVal Value As String)
				m_strObservacao = Value
			End Set
		End Property

		Public Overridable Property SubscriberID As String
			Get
				Return m_strSubscriberID
			End Get
			Set(ByVal Value As String)
				m_strSubscriberID = Value
			End Set
		End Property

		Public Overridable Property Refreshed As String
			Get
				Return _getDateTimePropertyValue(m_strRefreshed)
			End Get
			Set(ByVal Value As String)
				m_strRefreshed = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property MaxDesconto As Single
			Get
				Return m_sngMaxDesconto
			End Get
			Set(ByVal Value As Single)
				m_sngMaxDesconto = Value
			End Set
		End Property

        Public Overridable Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
            Set(ByVal Value As String)
                m_strCriado = Value
            End Set

        End Property

		Public Overridable Property TodosClientes As Byte
			Get
				Return m_indTodosClientes
			End Get
			Set(ByVal Value As Byte)
				m_indTodosClientes = Value
			End Set
		End Property

		Public Overridable Property NumeroPedido As Integer
			Get
				Return m_intNumeroPedido
			End Get
			Set(ByVal Value As Integer)
				m_intNumeroPedido = Value
			End Set
		End Property

		Public Overridable Property Guid As String
			Get
				Return m_strGuid
			End Get
			Set(ByVal Value As String)
				m_strGuid = Value
			End Set
        End Property

        Public ReadOnly Property Consignacao() As clsConsignacaoVendedor
            Get
                If m_clsConsignacao Is Nothing Then
                    m_clsConsignacao = New clsConsignacaoVendedor(m_intIDVendedor)
                End If
                Return m_clsConsignacao
            End Get
        End Property

        Public ReadOnly Property Estoque() As clsPedidoEstoqueVendedor
            Get
                If m_clsEstoque Is Nothing Then
                    m_clsEstoque = New clsPedidoEstoqueVendedor()
                End If
                Return m_clsEstoque
            End Get
        End Property


	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			try
				m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
				m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
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
				if dr.IsDBNull(dr.GetOrdinal("Observacao")) Then 
					m_strObservacao = ""
				else
					m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("SubscriberID")) Then 
					m_strSubscriberID = ""
				else
					m_strSubscriberID = dr.GetString(dr.GetOrdinal("SubscriberID"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Refreshed")) Then 
					m_strRefreshed = ""
				else
					m_strRefreshed = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Refreshed")))
				end if
				if dr.IsDBNull(dr.GetOrdinal("MaxDesconto")) Then 
					m_sngMaxDesconto = 0
				else
					m_sngMaxDesconto = dr.GetFloat(dr.GetOrdinal("MaxDesconto"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Criado")) Then 
					m_strCriado = ""
				else
					m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
				end if
				if dr.IsDBNull(dr.GetOrdinal("TodosClientes")) Then 
					m_indTodosClientes = 0
				else
					m_indTodosClientes = dr.GetByte(dr.GetOrdinal("TodosClientes"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("NumeroPedido")) Then 
					m_intNumeroPedido = 0
				else
					m_intNumeroPedido = dr.GetInt32(dr.GetOrdinal("NumeroPedido"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Guid")) Then 
					m_strGuid = ""
				else
					m_strGuid = dr.GetString(dr.GetOrdinal("Guid"))
				end if

			Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SV_VENDEDOR"
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = m_intIDVendedor
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = m_strCodigo
                cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar, 60).value = m_strVendedor
                cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).value = m_strTelefone
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).value = m_strLogin
                cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).Value = m_strSenha
                cmd.Parameters.Add("@DATACRIADO", SqlDbType.DateTime).Value = m_strCriado
                cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = m_strID
                cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 2000).value = m_strObservacao
                cmd.Parameters.Add("@SUBSCRIBERID", SqlDbType.VarChar, 300).value = m_strSubscriberID
                If m_strRefreshed <> "" Then
                    cmd.Parameters.Add("@REFRESHED", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strRefreshed)
                End If
                cmd.Parameters.Add("@MAXDESCONTO", SqlDbType.Real).value = m_sngMaxDesconto
                cmd.Parameters.Add("@TODOSCLIENTES", SqlDbType.TinyInt).value = m_indTodosClientes
                cmd.Parameters.Add("@NUMEROPEDIDO", SqlDbType.Int).value = m_intNumeroPedido
                cmd.Parameters.Add("@GUID", SqlDbType.VarChar, 40).value = m_strGuid
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVendedor">Chave primaria IDVendedor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVendedor As Integer) As Boolean
            Try
                If vIDVendedor = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_VENDEDOR"
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = vIDVendedor
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDVendedor = 0
            m_strCodigo = ""
            m_strVendedor = ""
            m_strTelefone = ""
            m_strLogin = ""
            m_strSenha = ""
            m_strID = ""
            m_strObservacao = ""
            m_strSubscriberID = ""
            m_strRefreshed = ""
            m_sngMaxDesconto = 0
            m_strCriado = ""
            m_indTodosClientes = 0
            m_intNumeroPedido = 0
            m_strGuid = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_VENDEDOR"
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = m_intIDVendedor
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Vendedor' the following row:  IDVendedor=" & m_intIDVendedor & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
                Clear()
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VENDEDORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem dos clientes pertecentes ao vendedor
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarClientes(ByVal vIdVendedor As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VENDEDOR_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.VarChar, 255).Value = vIdVendedor
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
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_VENDEDORES"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                'cmd.Parameters.Add("@STATUSVEND", SqlDbType.Int).Value = vStatusVend
                cn.Open()

                If vReturnType = enReturnType.DataReader Then
                    Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If dr.Read Then
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = dr.GetInt32(0)
                        If dr.NextResult Then
                            ret.Data = dr
                        End If
                    End If
                Else
                    Try
                        Dim ad As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                        ret.Data = ds.Tables(1)
                    Finally
                        If (Not cn Is Nothing) Then
                            cn.Close()
                            cn = Nothing
                        End If
                    End Try
                End If

            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return ret
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
        Public Function ListarVendedoresConsignacao(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_VENDEDORES_CONSIGNACAO"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                cn.Open()

                If vReturnType = enReturnType.DataReader Then
                    Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If dr.Read Then
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = dr.GetInt32(0)
                        If dr.NextResult Then
                            ret.Data = dr
                        End If
                    End If
                Else
                    Try
                        Dim ad As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                        ret.Data = ds.Tables(1)
                    Finally
                        If (Not cn Is Nothing) Then
                            cn.Close()
                            cn = Nothing
                        End If
                    End Try
                End If

            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return ret
        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIdUsuario">Chave primaria IDVendedor do registro atual.</param>
        Public Function RecuperaCodigoVendedor(ByVal vIdUsuario As Integer) As Integer

            Dim intIdVendedor As Integer = 0

            Try

                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_VENDEDOR_USUARIO"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIdUsuario
                cn.Open()

                Try
                    intIdVendedor = cmd.ExecuteScalar()
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try

            Catch ex As Exception


                If (1 = 2) Then
                    Throw
                End If

            End Try

            Return intIdVendedor

        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDVendedor">Chave primaria IDVendedor do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDVendedor As Integer, ByVal vCodigo As String) As Boolean
            Dim blnExiste As Boolean = True
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_VENDEDOR_EXISTENTE"
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = vIDVendedor
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = vCodigo
                cn.Open()
                Try
                    blnExiste = cmd.ExecuteScalar()
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnExiste
        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Try
                If m_strCodigo = "" Then
                    AddBrokenRule("O código é obrigatório!")
                    blnValid = False
                ElseIf Existe(m_intIDVendedor, m_strCodigo) Then
                    AddBrokenRule("O código informado já existe!")
                    blnValid = False
                End If
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnValid
        End Function

	#End Region



	End Class
End Namespace
