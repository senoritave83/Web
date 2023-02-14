

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics


Namespace Classes

	Public Class clsPermissao
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDPermissao As Integer
		Protected m_strPermissao As String
		Protected m_strCriado As String

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDPermissao As Integer
			Get
				Return m_intIDPermissao
			End Get
		End Property

		Public Overridable Property Permissao As String
			Get
				Return m_strPermissao
			End Get
			Set(ByVal Value As String)
				m_strPermissao = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDPermissao = 0
            End Get
        End Property

        
#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDPermissao = dr.GetInt32(dr.GetOrdinal("IDPermissao"))
            If dr.IsDBNull(dr.GetOrdinal("Permissao")) Then
                m_strPermissao = ""
            Else
                m_strPermissao = dr.GetString(dr.GetOrdinal("Permissao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Criado")) Then
                m_strCriado = ""
            Else
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            End If

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PERMISSAO"
            cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).value = m_intIDPermissao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@PERMISSAO", SqlDbType.VarChar, 256).value = m_strPermissao
            Dim dr As IDataReader = ExecuteCommand(cmd, enReturnType.DataReader)
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

            Me.User.Log("Permissoes do Sistema", "Gravar - IDPERMISSAO=" & m_intIDPermissao & " PERMISSAO=" & m_strPermissao)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPermissao">Chave primaria IDPermissao</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPermissao As Integer) As Boolean

            If vIDPermissao = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PERMISSAO"
            cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim dr As IDataReader = ExecuteCommand(cmd, enReturnType.DataReader)
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

            Me.User.Log("Permissoes do Sistema", "Visualizar - IDPERMISSAO=" & vIDPermissao)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDPermissao = 0
            m_strPermissao = ""
            m_strCriado = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERMISSAO"
            cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = m_intIDPermissao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa
            ExecuteNonQuery(cmd)

            Me.User.Log("Permissoes do Sistema", "Apagar - IDPERMISSAO=" & m_intIDPermissao)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Permissao' the following row:  IDPermissao=" & m_intIDPermissao & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PERMISSOES"
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
        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PERMISSOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vIdUsuario">Id do Usuário</param>		
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIdUsuario As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERMISSOES_USUARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIdUsuario
            cmd.Parameters.Add("@IDUSUARIOLOGADO", SqlDbType.Int).Value = Me.User.IDUser
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Return blnValid
        End Function



        Public Function ListarSecoes(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_SECOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        Public Function ListarAcoes(ByVal vSecao As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_SECAO_ACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@SECAO", SqlDbType.VarChar).Value = vSecao
            cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = m_intIDPermissao
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        Public Function VerificaPermissao(ByVal vSecao As String, ByVal vAcao As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_VERIFICAR_PERMISSAO"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@SECAO", SqlDbType.VarChar, 50).Value = vSecao
            cmd.Parameters.Add("@ACAO", SqlDbType.VarChar, 50).Value = vAcao
            ExecuteNonQuery(cmd)
            If cmd.Parameters("@RETURN_VALUE").Value = 0 Then
                Return False
            Else
                Return True
            End If

        End Function

        Public Function VerificaPermissao(ByVal vSecao As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_VERIFICAR_PERMISSAOSECAO"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@SECAO", SqlDbType.VarChar, 50).Value = vSecao
            ExecuteNonQuery(cmd)
            If cmd.Parameters("@RETURN_VALUE").Value = 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Sub GravarAcao(ByVal vIDAcao As Integer, ByVal vSelecionado As Boolean)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "UP_PERMISSAO_ACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = m_intIDPermissao
            cmd.Parameters.Add("@IDACAO", SqlDbType.Int).Value = vIDAcao
            cmd.Parameters.Add("@SELECIONADO", SqlDbType.Bit).Value = vSelecionado
            ExecuteNonQuery(cmd)

            Me.User.Log("Permissoes do Sistema", "GravarAcao - IDPERMISSAO=" & m_intIDPermissao & " IDACAO=" & vIDAcao & " SELECIONADO=" & vSelecionado)

        End Sub

#End Region



    End Class
End Namespace

