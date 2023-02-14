

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsRoteiro
		Inherits BaseClass

#Region "Declarations"
        Protected m_intIDRoteiro As Integer
        Protected m_intIDPromotor As Integer
        Protected m_strData As String
        Protected m_intDia As Integer
        Protected m_intMes As Integer
        Protected m_intDiaSemana As Integer
        Protected m_intSemanaMes As Integer
        Protected m_blnAtivo As Boolean

#End Region

#Region "Properties"
        Public Overridable ReadOnly Property IDRoteiro() As Integer
            Get
                Return m_intIDRoteiro
            End Get
        End Property

        Public Overridable ReadOnly Property IDPromotor() As Integer
            Get
                Return m_intIDPromotor
            End Get
        End Property

        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDateTimePropertyValue(m_strData)
            End Get
        End Property

        Public Overridable Property Dia() As Integer
            Get
                Return m_intDia
            End Get
            Set(ByVal Value As Integer)
                m_intDia = Value
            End Set
        End Property

        Public Overridable Property Mes() As Integer
            Get
                Return m_intMes
            End Get
            Set(ByVal Value As Integer)
                m_intMes = Value
            End Set
        End Property

        Public Overridable Property DiaSemana() As Integer
            Get
                Return m_intDiaSemana
            End Get
            Set(ByVal Value As Integer)
                m_intDiaSemana = Value
            End Set
        End Property

        Public Overridable Property SemanaMes() As Integer
            Get
                Return m_intSemanaMes
            End Get
            Set(ByVal Value As Integer)
                m_intSemanaMes = Value
            End Set
        End Property

        Public Overridable Property Ativo() As Boolean
            Get
                Return m_blnAtivo
            End Get
            Set(ByVal Value As Boolean)
                m_blnAtivo = Value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDRoteiro = 0
            End Get
        End Property

#End Region
	
#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDRoteiro = dr.GetInt32(dr.GetOrdinal("IDRoteiro"))
            m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            If dr.IsDBNull(dr.GetOrdinal("Dia")) Then
                m_intDia = 0
            Else
                m_intDia = dr.GetInt32(dr.GetOrdinal("Dia"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Mes")) Then
                m_intMes = 0
            Else
                m_intMes = dr.GetInt32(dr.GetOrdinal("Mes"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DiaSemana")) Then
                m_intDiaSemana = 0
            Else
                m_intDiaSemana = dr.GetInt32(dr.GetOrdinal("DiaSemana"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("SemanaMes")) Then
                m_intSemanaMes = 0
            Else
                m_intSemanaMes = dr.GetInt32(dr.GetOrdinal("SemanaMes"))
            End If
            m_blnAtivo = dr.GetBoolean(dr.GetOrdinal("Ativo"))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_ROTEIRO"
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@DIA", SqlDbType.Int).Value = m_intDia
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = m_intMes
            cmd.Parameters.Add("@DIASEMANA", SqlDbType.Int).Value = m_intDiaSemana
            cmd.Parameters.Add("@SEMANAMES", SqlDbType.Int).Value = m_intSemanaMes
            cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = m_blnAtivo
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

            Me.User.Log("Cadastro de Roteiros", "Gravar - IDROTEIRO=" & m_intIDRoteiro & " IDPROMOTOR=" & m_intIDPromotor & " DIA=" & m_intDia & " MES=" & _
                  m_intMes & " DIASEMANA=" & m_intDiaSemana & " SEMANAMES=" & m_intSemanaMes & " ATIVO=" & m_blnAtivo)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDRoteiro">Chave primaria IDRoteiro</param>
        ''' <param name="vIDPromotor">Chave primaria IDPromotor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDRoteiro As Integer, ByVal vIDPromotor As Integer) As Boolean
            m_intIDPromotor = vIDPromotor

            If vIDRoteiro = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ROTEIRO"
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
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

            Me.User.Log("Cadastro de Roteiros", "Visualizar - IDROTEIRO=" & vIDRoteiro & " IDPROMOTOR=" & vIDPromotor)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDRoteiro = 0
            m_strData = ""
            m_intDia = 0
            m_intMes = 0
            m_intDiaSemana = 0
            m_intSemanaMes = 0
            m_blnAtivo = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Delete(m_intIDRoteiro, m_intIDPromotor)
        End Sub

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(ByVal vIDRoteiro As Integer, ByVal vIDPromotor As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_ROTEIRO"
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Roteiros", "Apagar - IDROTEIRO=" & vIDRoteiro & " IDPROMOTOR=" & vIDPromotor)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Roteiro' the following row:  IDRoteiro=" & vIDRoteiro & " IDEmpresa=" & User.IDEmpresa & " IDPromotor=" & vIDPromotor & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

            Clear()

        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDPromotor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_ROTEIROS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vIDPromotor">Chave primária do promotor</param>
        ''' <param name="vDia">Filtro</param>
        ''' <param name="vDiaSemana">Filtro</param>
        ''' <param name="vMes">Filtro</param>
        ''' <param name="vSemanaMes">Filtro</param>
        ''' <param name="vFiltro">Filtro</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDPromotor As Integer, ByVal vDia As Integer, ByVal vMes As Integer, ByVal vDiaSemana As Integer, ByVal vSemanaMes As Integer, ByVal vFiltro As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_ROTEIROS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@DIA", SqlDbType.Int).Value = vDia
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = vMes
            cmd.Parameters.Add("@DIASEMANA", SqlDbType.Int).Value = vDiaSemana
            cmd.Parameters.Add("@SEMANAMES", SqlDbType.Int).Value = vSemanaMes
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFiltro
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa das lojas do roteiro
        ''' </summary>
        ''' <param name="vIDPromotor">Chave primária do promotor</param>
        ''' <param name="vIDRoteiro">Chave primária do roteiro</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarLojas(ByVal vIDPromotor As Integer, ByVal vIDRoteiro As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_ROTEIRO_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa dos horários pré definidos
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarHoras(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_ROTEIRO_HORAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa das lojas do roteiro
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarLojas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_ROTEIRO_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_ROTEIROS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
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

        Public Sub RetirarLoja(ByVal vIDLoja As Integer)
           
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_ROTEIRO_LOJA"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Roteiros", "RetirarLoja - IDLOJA=" & vIDLoja & " IDROTEIRO=" & m_intIDRoteiro)

        End Sub

        Public Sub AdicionarLoja(ByVal vIDLoja As Integer, ByVal vIDPesquisa As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_ROTEIRO_LOJA"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Roteiros", "AdicionarLoja - IDLOJA=" & vIDLoja & " IDROTEIRO=" & m_intIDRoteiro)

        End Sub


#End Region

    End Class
End Namespace

