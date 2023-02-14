

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

    Public Class clsEmail
        Inherits BaseClass




#Region "Declarations"
        Protected m_intIDUsuario As Integer
        Protected m_strIDPedido As String
        Protected m_strSubject As String
        Protected m_strEnviadoDE As String
        Protected m_strEnviadoPara As String
        Protected m_strDataEnvio As String
        Protected m_strStatusEnvio As String

#End Region


#Region "Properties"
     
        Public Overridable ReadOnly Property IDUsuario As Integer
            Get
                Return m_intIDUsuario
            End Get
        End Property

        Public Overridable Property NumPedido As String
            Get
                Return m_strIDPedido
            End Get
            Set(ByVal Value As String)
                m_strIDPedido = Value
            End Set
        End Property



        Public Overridable Property Subject As String
            Get
                Return m_strSubject
            End Get
            Set(ByVal Value As String)
                m_strSubject = Value
            End Set
        End Property

        Public Overridable Property EnviadoDE As String
            Get
                Return m_strEnviadoDE
            End Get
            Set(ByVal Value As String)
                m_strEnviadoDE = Value
            End Set
        End Property

        Public Overridable Property EnviadoPara As String
            Get
                Return m_strEnviadoPara
            End Get
            Set(ByVal Value As String)
                m_strEnviadoPara = Value
            End Set
        End Property

        Public Overridable Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strDataEnvio)

            End Get

            Set(ByVal value As String)
                m_strDataEnvio = value

            End Set
        End Property

        Public Overridable Property IdStatus As String
            Get
                Return m_strStatusEnvio
            End Get
            Set(ByVal Value As String)
                m_strStatusEnvio = Value
            End Set
        End Property


#End Region


        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            Try
                m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))

                If dr.IsDBNull(dr.GetOrdinal("NumPedido")) Then
                    m_strIDPedido = ""
                Else
                    m_strIDPedido = dr.GetString(dr.GetOrdinal("NumPedido"))
                End If

                If dr.IsDBNull(dr.GetOrdinal("Assunto")) Then
                    m_strSubject = ""
                Else
                    m_strSubject = dr.GetString(dr.GetOrdinal("Assunto"))
                End If

                If dr.IsDBNull(dr.GetOrdinal("EnviadoPara")) Then
                    m_strEnviadoPara = ""
                Else
                    m_strEnviadoPara = dr.GetString(dr.GetOrdinal("Assunto"))
                End If


                If dr.IsDBNull(dr.GetOrdinal("EnviadoDe")) Then
                    m_strEnviadoDE = ""
                Else
                    m_strEnviadoDE = dr.GetString(dr.GetOrdinal("EnviadoDe"))
                End If

                m_strDataEnvio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEnvio")))


                If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
                    m_strStatusEnvio = ""
                Else
                    m_strStatusEnvio = dr.GetString(dr.GetOrdinal("IdStatus"))
                End If



            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCategoria">Chave primaria IDCategoria</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPedido As Integer) As Boolean
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_EMAIL"
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.Int).Value = vIDPedido
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDEmpresa
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
                    Try
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


        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_EMAIL"
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.Int).Value = m_strIDPedido
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
        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vIDPedido As Byte, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_EMAIL"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = vIDPedido
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




    End Class

End Namespace