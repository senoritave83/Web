

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics


Namespace Classes

	Public Class clsCondicao
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCondicao As Integer
		Protected m_strCodigo As String
		Protected m_strCondicao As String
        Protected m_dblCorrecao As Single
        Protected m_strCriado As String
        Protected m_intParcelas As Integer
        Protected m_blnIsNew As Boolean = True
        Protected m_intStatus As Integer
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDCondicao() As Integer
            Get
                Return m_intIDCondicao
            End Get
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

        Public Overridable Property Codigo() As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property Condicao() As String
            Get
                Return m_strCondicao
            End Get
            Set(ByVal Value As String)
                m_strCondicao = Value
            End Set
        End Property

        Public Overridable Property Correcao() As Double
            Get
                Return m_dblCorrecao
            End Get
            Set(ByVal Value As Double)
                m_dblCorrecao = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public Overridable Property Parcelas() As Integer
            Get
                Return m_intParcelas
            End Get
            Set(ByVal Value As Integer)
                m_intParcelas = Value
            End Set
        End Property

        Public Overridable Property IdStatus As Integer
            Get
                Return m_intStatus
            End Get
            Set(ByVal Value As Integer)
                m_intStatus = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDCondicao = dr.GetInt32(dr.GetOrdinal("IDCondicao"))
            If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
                m_intStatus = 0
            Else
                m_intStatus = dr.GetByte(dr.GetOrdinal("IdStatus"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Condicao")) Then
                m_strCondicao = ""
            Else
                m_strCondicao = dr.GetString(dr.GetOrdinal("Condicao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Correcao")) Then
                m_dblCorrecao = 0
            Else
                m_dblCorrecao = dr.GetDouble(dr.GetOrdinal("Correcao"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("Parcelas")) Then
                m_intParcelas = 0
            Else
                m_intParcelas = dr.GetInt32(dr.GetOrdinal("Parcelas"))
            End If
            m_blnIsNew = False


        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CONDICAO"
            cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = m_intIDCondicao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = m_strCodigo
            cmd.Parameters.Add("@CONDICAO", SqlDbType.NVarChar, 100).Value = m_strCondicao
            cmd.Parameters.Add("@CORRECAO", SqlDbType.Real).Value = m_dblCorrecao
            cmd.Parameters.Add("@PARCELAS", SqlDbType.Int).Value = m_intParcelas
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = m_intStatus

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

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCondicao">Chave primaria IDCondicao</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCondicao As Integer) As Boolean
            If vIDCondicao = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CONDICAO"
            cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = vIDCondicao
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

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDCondicao = 0
            m_strCodigo = ""
            m_strCondicao = ""
            m_dblCorrecao = 0
            m_strCriado = ""
            m_intParcelas = 0
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CONDICAO"
            cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = m_intIDCondicao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Condicao' the following row:  IDCondicao=" & m_intIDCondicao & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_CONDICOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
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
        Public Function Listar(ByVal vFilter As String, ByVal vAtivo As Byte, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CONDICOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vAtivo

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function




        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDCondicao">Chave primaria IDCondicao do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDCondicao As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CONDICAO_EXISTENTE"
            cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = vIDCondicao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = vCodigo

            Return ExecuteScalar(cmd)
        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCodigo = "" Then
                AddBrokenRule("O código é obrigatório!")
                blnValid = False
            ElseIf Existe(m_intIDCondicao, m_strCodigo) Then
                AddBrokenRule("O código informado já existe!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



	End Class
End Namespace

