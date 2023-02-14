

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace Classes

	Public Class clsCargo
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCargo As Integer
		Protected m_strCargo As String
		Protected m_intIDSuperior As Integer
		Protected m_intModulos As Integer
        Protected m_strCriado As String
        Protected m_indAdicionarLoja As Byte
        Protected m_blnIsNew As Boolean = True
        Protected m_objPermissoes As clsPermissaoCargo
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCargo As Integer
			Get
				Return m_intIDCargo
			End Get
		End Property

		Public Overridable Property Cargo As String
			Get
				Return m_strCargo
			End Get
			Set(ByVal Value As String)
				m_strCargo = Value
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

		Public Overridable Property Modulos As Integer
			Get
				Return m_intModulos
			End Get
			Set(ByVal Value As Integer)
				m_intModulos = Value
			End Set
		End Property


        Public Overridable Property AdicionarLoja() As Byte
            Get
                Return m_indAdicionarLoja
            End Get
            Set(ByVal Value As Byte)
                m_indAdicionarLoja = Value
            End Set
        End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public ReadOnly Property Permissoes() As clsPermissaoCargo
            Get
                If m_objPermissoes Is Nothing Then
                    m_objPermissoes = New clsPermissaoCargo(m_intIDCargo)
                End If
                Return m_objPermissoes
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
			m_intIDCargo = dr.GetInt32(dr.GetOrdinal("IDCargo"))
			m_strCargo = dr.GetString(dr.GetOrdinal("Cargo"))
			if dr.IsDBNull(dr.GetOrdinal("IDSuperior")) Then 
				m_intIDSuperior = 0
			else
				m_intIDSuperior = dr.GetInt32(dr.GetOrdinal("IDSuperior"))
			end if
			m_intModulos = dr.GetInt32(dr.GetOrdinal("Modulos"))
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("AdicionarLoja")) Then
                m_indAdicionarLoja = 0
            Else
                m_indAdicionarLoja = dr.GetByte(dr.GetOrdinal("AdicionarLoja"))
            End If
            m_objPermissoes = Nothing
            m_blnIsNew = False
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_CARGO"
			cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).value = m_intIDCargo
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CARGO", SqlDbType.VarChar, 100).value = m_strCargo
			cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).value = m_intIDSuperior
			cmd.Parameters.Add("@MODULOS", SqlDbType.Int).value = m_intModulos
            cmd.Parameters.Add("@ADICIONARLOJA", SqlDbType.TinyInt).Value = m_indAdicionarLoja
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
        ''' <param name="vIDCargo">Chave primaria IDCargo</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDCargo As Integer) As Boolean
			If vIDCargo = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CARGO"
			cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).value = vIDCargo
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
			m_intIDCargo = 0
			m_strCargo = ""
			m_intIDSuperior = 0
			m_intModulos = 0
            m_strCriado = ""
            m_indAdicionarLoja = 0
            m_blnIsNew = True
            m_objPermissoes = Nothing
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_CARGO"
			cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).value = m_intIDCargo
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Cargo' the following row:  IDCargo=" & m_intIDCargo & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CARGOS"
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
			cmd.CommandText = PREFIXO & "NV_CARGOS"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
			cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
			cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
			cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

		End Function



        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarCargosSuperiores(ByVal vIDCargo As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CARGOS_SUPERIORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIOLOGADO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
            Return ExecuteCommand(cmd, vReturnType)

        End Function



		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

        Public Class clsPermissaoCargo
            Inherits BaseClass

#Region "Declarations"
            Protected m_intIDCargo As Integer
            Protected m_lstPermissoes As List(Of Integer) = Nothing
#End Region

            Friend Sub New(ByVal vIDCargo As Integer)
                m_intIDCargo = vIDCargo
            End Sub

#Region "Metodos"

            ''' <summary>
            ''' 	Função que adiciona um item na tabela
            ''' </summary>
            Public Sub Add(ByVal vIDPermissao As Integer, ByVal vIDCargo As Integer)
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "IN_PERMISSAO_CARGO"
                cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
                cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                ExecuteNonQuery(cmd)
            End Sub

            ''' <summary>
            ''' 	Função que adiciona um item na tabela
            ''' </summary>
            Public Sub Add(ByVal vIDPermissao As Integer)
                Add(vIDPermissao, m_intIDCargo)
            End Sub

            ''' <summary>
            ''' 	Função que remove um item na tabela
            ''' </summary>
            Public Sub Delete(ByVal vIDPermissao As Integer, ByVal vIDCargo As Integer)
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_PERMISSAO_CARGO"
                cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
                cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                ExecuteNonQuery(cmd)
            End Sub

            ''' <summary>
            ''' 	Função que remove um item na tabela
            ''' </summary>
            Public Sub Delete(ByVal vIDPermissao As Integer)
                Delete(vIDPermissao, m_intIDCargo)
            End Sub


            ''' <summary>
            ''' 	Função que retorna uma listagem de Permissoes no Cargo
            ''' </summary>
            ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
            ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
            Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

                Dim cmd As New SqlCommand()
                cmd.CommandText = PREFIXO & "LS_CARGO_PERMISSOES"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = m_intIDCargo
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                Return ExecuteCommand(cmd, vReturnType)

            End Function

            Public Function Contains(ByVal vIDPermissao As Integer) As Boolean
                If m_lstPermissoes Is Nothing Then
                    Dim dr As IDataReader = Nothing
                    Try
                        dr = Listar(enReturnType.DataReader)
                        m_lstPermissoes = New List(Of Integer)
                        Listar(enReturnType.DataReader)
                        Do While dr.Read
                            m_lstPermissoes.Add(dr.GetInt32(dr.GetOrdinal("IDPermissao")))
                        Loop
                    Finally
                        If Not dr Is Nothing Then
                            If Not dr.IsClosed Then
                                dr.Close()
                            End If
                            dr = Nothing
                        End If
                    End Try
                End If
                Return m_lstPermissoes.Contains(vIDPermissao)
            End Function

            Public Function Contains(ByVal vIDPermissao As Integer, ByVal vIDCargo As Integer) As Boolean
                Dim cn As SqlConnection = GetDBConnection()
                Try
                    Dim cmd As New SqlCommand()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = PREFIXO & "BS_PERMISSAO_CARGO_EXISTE"
                    Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                    parameter.Direction = ParameterDirection.ReturnValue
                    cmd.Parameters.Add(parameter)
                    cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
                    cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
                    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                    Contains = (ExecuteScalar(cmd) > 0)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            End Function

#End Region


        End Class



    End Class
End Namespace

