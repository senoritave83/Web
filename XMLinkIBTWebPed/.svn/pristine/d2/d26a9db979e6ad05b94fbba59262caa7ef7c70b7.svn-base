Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsFormaPagamento
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDFormaPagamento As Integer
        Protected m_strCodigo As String
        Protected m_strFormaPagamento As String
        Protected m_sngCorrecao As Single
        Protected m_strCriado As String

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDFormaPagamento As Integer
            Get
                Return m_intIDFormaPagamento
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

        Public Overridable Property FormaPagamento As String
            Get
                Return m_strFormaPagamento
            End Get
            Set(ByVal Value As String)
                m_strFormaPagamento = Value
            End Set
        End Property

        Public Overridable Property Correcao As Single
            Get
                Return m_sngCorrecao
            End Get
            Set(ByVal Value As Single)
                m_sngCorrecao = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            Try
                m_intIDFormaPagamento = dr.GetInt32(dr.GetOrdinal("IDFormaPagamento"))
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
                m_strFormaPagamento = dr.GetString(dr.GetOrdinal("FormaPagamento"))
                If dr.IsDBNull(dr.GetOrdinal("Correcao")) Then
                    m_sngCorrecao = 0
                Else
                    m_sngCorrecao = dr.GetFloat(dr.GetOrdinal("Correcao"))
                End If
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))

            Catch ex As Exception
               Throw New Exception(ex.Message, ex)
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
                cmd.CommandText = PREFIXO & "SV_FORMAPAGAMENTO"
                cmd.Parameters.Add("@IDFORMAPAGAMENTO", SqlDbType.Int).value = m_intIDFormaPagamento
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = m_strCodigo
                cmd.Parameters.Add("@FORMAPAGAMENTO", SqlDbType.NVarChar, 100).value = m_strFormaPagamento
                cmd.Parameters.Add("@CORRECAO", SqlDbType.Real).value = m_sngCorrecao
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
                Throw New Exception(ex.Message, ex)
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDFormaPagamento">Chave primaria IDFormaPagamento</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDFormaPagamento As Integer) As Boolean
            Try
                If vIDFormaPagamento = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_FORMAPAGAMENTO"
                cmd.Parameters.Add("@IDFORMAPAGAMENTO", SqlDbType.Int).value = vIDFormaPagamento
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
                Throw New Exception(ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDFormaPagamento = 0
            m_strCodigo = ""
            m_strFormaPagamento = ""
            m_sngCorrecao = 0
            m_strCriado = ""
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
                cmd.CommandText = PREFIXO & "DE_FORMAPAGAMENTO"
                cmd.Parameters.Add("@IDFORMAPAGAMENTO", SqlDbType.Int).value = m_intIDFormaPagamento
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'FormaPagamento' the following row:  IDFormaPagamento=" & m_intIDFormaPagamento & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
                Clear()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_FORMAPAGAMENTOS"
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
            Dim ret As New PaginateResult
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_FORMAPAGAMENTOS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize
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
                        Dim ad As New SQLDataAdapter(cmd)
                        Dim ds As New dataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.tables(0).rows(0).Item(0)
                        ret.Data = ds.Tables(1)
                    Finally
                        If (Not cn Is Nothing) Then
                            cn.Close()
                            cn = Nothing
                        End If
                    End Try
                End If

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try
            Return ret
        End Function




        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDFormaPagamento">Chave primaria IDFormaPagamento do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDFormaPagamento As Integer, ByVal vCodigo As String) As Boolean
            Dim blnExiste As Boolean = True
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_FORMAPAGAMENTO_EXISTENTE"
                cmd.Parameters.Add("@IDFORMAPAGAMENTO", SqlDbType.Int).value = vIDFormaPagamento
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
                Throw New Exception(ex.Message, ex)
            End Try
            Return blnExiste
        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Try
                If m_strCodigo = "" Then
                    AddBrokenRule("O código é obrigatório!")
                    blnValid = False
                ElseIf Existe(m_intIDFormaPagamento, m_strCodigo) Then
                    AddBrokenRule("O código informado já existe!")
                    blnValid = False
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

