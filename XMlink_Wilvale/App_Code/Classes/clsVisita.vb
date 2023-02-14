Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

    Public Class clsVisita
        Inherits BaseClass



#Region "Declarations"

        Protected m_intIDVisita As Integer
        Protected m_intIDCliente As Integer
        Protected m_strCliente As String
        Protected m_intIDVendedor As Integer
        Protected m_strVendedor As String
        Protected m_strData As String
        Protected m_intNumDevice As Integer
        Protected m_intIDStatus As Integer
        Protected m_strStatus As String
        Protected m_intNumProdutosVisita As Integer
        Protected m_intIDTipoJustificativa As Integer
        Protected m_strTipoJustificativa As String
        Protected m_intProdutosColetados As Integer
        Protected m_strResponsavel As String
        Protected m_strLatitude As Double
        Protected m_strLongitude As Double

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

        Public Overridable Property IDCliente() As Integer
            Get
                Return m_intIDCliente
            End Get
            Set(ByVal Value As Integer)
                m_intIDCliente = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
            End Get
        End Property

        Public Overridable Property IDVendedor() As Integer
            Get
                Return m_intIDVendedor
            End Get
            Set(ByVal Value As Integer)
                m_intIDVendedor = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Vendedor() As String
            Get
                Return m_strVendedor
            End Get
        End Property

        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDateTimePropertyValue(m_strData)
            End Get
        End Property

        Public Overridable Property IDTipoJustificativa() As Integer
            Get
                Return m_intIDTipoJustificativa
            End Get
            Set(ByVal Value As Integer)
                m_intIDTipoJustificativa = Value
            End Set
        End Property

        Public Overridable ReadOnly Property TipoJustificativa() As String
            Get
                Return m_strTipoJustificativa
            End Get
        End Property

        Public Overridable ReadOnly Property Latitude() As Double
            Get
                Return m_strLatitude
            End Get
        End Property

        Public Overridable ReadOnly Property Longitude() As Double
            Get
                Return m_strLongitude
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IdCliente"))
            m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
            If dr.IsDBNull(dr.GetOrdinal("Data")) Then
                m_strData = ""
            Else
                m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDTipoJustificativa")) Then
                m_intIDTipoJustificativa = 0
            Else
                m_intIDTipoJustificativa = dr.GetInt32(dr.GetOrdinal("IDTipoJustificativa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TipoJustificativa")) Then
                m_strTipoJustificativa = ""
            Else
                m_strTipoJustificativa = dr.GetString(dr.GetOrdinal("TipoJustificativa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Latitude")) Then
                m_strLatitude = 0
            Else
                m_strLatitude = dr.GetFloat(dr.GetOrdinal("Latitude"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Longitude")) Then
                m_strLongitude = 0
            Else
                m_strLongitude = dr.GetFloat(dr.GetOrdinal("Longitude"))
            End If

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_VISITA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = m_intIDTipoJustificativa
            Dim dr As IDataReader = MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
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
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As Integer) As Boolean

            If vIDVisita = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita

            Dim dr As IDataReader = MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
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

            m_intIDVisita = 0
            m_intIDCliente = 0
            m_intIDVendedor = 0
            m_strData = ""
            m_intNumDevice = 0
            m_intIDStatus = 0
            m_strStatus = ""
            m_intNumProdutosVisita = 0
            m_intIDTipoJustificativa = 0
            m_strResponsavel = ""
            m_strLatitude = 0
            m_strLongitude = 0

        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VISITA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            cmd.ExecuteNonQuery()

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Visita' the following row:  IDEmpresa=" & User.IDEmpresa & " IDVisita=" & m_intIDVisita & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
            cmd.CommandText = PREFIXO & "LS_VISITAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDVendedor">Filtro</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vIDTipoJustificativa">Valor 0 - Sem justificativa, -1 - Todas</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDTipoJustificativa As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vIDUsuario As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim ret As New PaginateResult

            Try

                Dim cn As SqlConnection = GetDBConnection()
                cn.Open()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_VISITAS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
                If vDataInicial <> "" Then
                    cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
                End If
                If vDataFinal <> "" Then
                    cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
                End If
                cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = vIDTipoJustificativa
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                If vIDUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
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
                Throw ex
            End Try

            Return ret

        End Function

     
        Protected Overrides Function CheckIfSubClassIsValid() As Boolean

            Dim blnValid As Boolean = True
            Return blnValid

        End Function

#End Region


    End Class
End Namespace

