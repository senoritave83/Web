

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsUF
        Inherits BaseClass



#Region "Declarations"
        Protected m_strUF As String
        Protected m_sngDescontoMax As Single
        Protected m_blnIsNew As Boolean = True
        Protected m_strCriado As String
        'Protected m_strEstado As String
#End Region


#Region "Properties"
        Public Overridable Property UF() As String
            Get
                Return m_strUF
            End Get
            Set(ByVal Value As String)
                m_strUF = Value
            End Set
        End Property

        Public Overridable Property DescontoMax() As Single
            Get
                Return m_sngDescontoMax
            End Get
            Set(ByVal Value As Single)
                m_sngDescontoMax = Value
            End Set
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property


        'Public Overridable Property Estado() As String
        '    Get
        '        Return m_strEstado
        '    End Get
        '    Set(ByVal Value As String)
        '        m_strEstado = Value
        '    End Set
        'End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            'm_strEstado = dr.GetString(dr.GetOrdinal("Estado"))
            If dr.IsDBNull(dr.GetOrdinal("Criado")) Then
                m_strCriado = ""
            Else
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            End If
            m_strUF = dr.GetString(dr.GetOrdinal("UF"))
            m_sngDescontoMax = dr.GetFloat(dr.GetOrdinal("DescontoMax"))
            m_blnIsNew = False
        End Sub


        Public Function Load(ByVal vUF As String) As Boolean
            If vUF = "UF" Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_UF"
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
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
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ESTADOS"
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarUFsDisponiveis(ByVal vUF As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_UFSDISPONIVEIS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_UF"
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = m_strUF
            cmd.Parameters.Add("@DESCONTOMAX", SqlDbType.Real).value = m_sngDescontoMax
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_UF"
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = m_strUF
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'UF' the following row:  UF=" & m_strUF & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_strUF = ""
            m_sngDescontoMax = 0
            m_blnIsNew = True
            m_strCriado = ""
            'm_strEstado = ""
        End Sub


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
            cmd.CommandText = PREFIXO & "NV_UFS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strUF = "0" Then
                AddBrokenRule("Informe uma UF valida!")
                blnValid = False
            End If

            Return blnValid

        End Function


#End Region

    End Class
End Namespace

