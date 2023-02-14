

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

	Public Class clsRoteiro
		Inherits BaseClass

#Region "Declarations"
        Protected m_intIDRoteiro As Integer
        Protected m_intIDVendedor As Integer
        Protected m_strData As String
        Protected m_intDia As Integer
        Protected m_intMes As Integer
        Protected m_intDiaSemana As Integer
        Protected m_blnAtivo As Boolean

#End Region

#Region "Properties"
        Public Overridable ReadOnly Property IDRoteiro() As Integer
            Get
                Return m_intIDRoteiro
            End Get
        End Property

        Public Overridable ReadOnly Property IDVendedor() As Integer
            Get
                Return m_intIDVendedor
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

        Public Overridable Property Ativo() As Boolean
            Get
                Return m_blnAtivo
            End Get
            Set(ByVal Value As Boolean)
                m_blnAtivo = Value
            End Set
        End Property

#End Region
	
#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            Try
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
                m_blnAtivo = dr.GetBoolean(dr.GetOrdinal("Ativo"))
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
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SV_ROTEIRO"
                cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = m_intIDVendedor
                cmd.Parameters.Add("@DIA", SqlDbType.Int).Value = m_intDia
                cmd.Parameters.Add("@MES", SqlDbType.Int).Value = m_intMes
                cmd.Parameters.Add("@DIASEMANA", SqlDbType.Int).Value = m_intDiaSemana
                cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = m_blnAtivo
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
        ''' <param name="vIDRoteiro">Chave primaria IDRoteiro</param>
        ''' <param name="vIDVendedor">Chave primaria IDPromotor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDRoteiro As Integer, ByVal vIDVendedor As Integer) As Boolean
            m_intIDVendedor = vIDVendedor
            Try
                If vIDRoteiro = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_ROTEIRO"
                cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
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
            m_intIDRoteiro = 0
            m_strData = ""
            m_intDia = 0
            m_intMes = 0
            m_intDiaSemana = 0
            m_blnAtivo = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Delete(m_intIDRoteiro, m_intIDVendedor)
        End Sub

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(ByVal vIDRoteiro As Integer, ByVal vIDVendedor As Integer)
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_ROTEIRO"
                cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Roteiro' the following row:  IDRoteiro=" & vIDRoteiro & " IDEmpresa=" & User.IDEmpresa & " IDVendedor=" & vIDVendedor & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDVendedor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ROTEIROS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa das lojas do roteiro
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarLojas(ByVal vIDVendedor As Integer, ByVal vIDRoteiro As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ROTEIRO_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa das lojas do roteiro
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarLojas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ROTEIRO_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = m_intIDVendedor
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
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_ROTEIROS"
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



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnValid
        End Function

        Public Sub RetirarCliente(ByVal vIDCliente As Integer)
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Try
                    Dim cmd As New SqlCommand()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = PREFIXO & "DE_ROTEIRO_CLIENTE"
                    Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                    parameter.Direction = ParameterDirection.ReturnValue
                    cmd.Parameters.Add(parameter)
                    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                    cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
                    cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro
                    cn.Open()
                    cmd.ExecuteNonQuery()
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

        Public Sub AdicionarCliente(ByVal vIDCliente As Integer)
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Try
                    Dim cmd As New SqlCommand()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = PREFIXO & "IN_ROTEIRO_CLIENTE"
                    Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                    parameter.Direction = ParameterDirection.ReturnValue
                    cmd.Parameters.Add(parameter)
                    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                    cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
                    cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = m_intIDRoteiro
                    cn.Open()
                    cmd.ExecuteNonQuery()
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


#End Region

	End Class
End Namespace

