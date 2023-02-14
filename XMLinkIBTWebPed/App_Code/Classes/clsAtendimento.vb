

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsAtendimento
        Inherits BaseClass



#Region "Declarations"
        Protected m_blnVencido As Boolean
        Protected m_blnExecutado As Boolean
        Protected m_blnFinalizado As Boolean
        Protected m_strData As String
        Protected m_strStatus As String

#End Region


#Region "Properties"

        Public Property Vencido() As Boolean
            Get
                Return m_blnVencido
            End Get
            Set(ByVal value As Boolean)
                m_blnVencido = value
            End Set
        End Property

        Public Property Executado() As Boolean
            Get
                Return m_blnExecutado
            End Get
            Set(ByVal value As Boolean)
                m_blnExecutado = value
            End Set
        End Property

        Public Property Finalizado() As Boolean
            Get
                Return m_blnFinalizado
            End Get
            Set(ByVal value As Boolean)
                m_blnFinalizado = value
            End Set
        End Property


        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDatePropertyValue(m_strData)
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return m_strStatus
            End Get
        End Property

#End Region


#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_blnExecutado = dr.GetByte(dr.GetOrdinal("Executado")) = 1
            m_blnFinalizado = dr.GetByte(dr.GetOrdinal("Finalizado")) = 1
            m_blnVencido = dr.GetByte(dr.GetOrdinal("Vencido")) = 1
            If dr.IsDBNull(dr.GetOrdinal("Data")) Then
                m_strData = ""
            Else
                m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            End If
            m_strStatus = dr.GetString(dr.GetOrdinal("Status"))
        End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVendedor As Integer) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ATENDIMENTO"
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
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
            m_blnExecutado = False
            m_blnVencido = False
            m_blnFinalizado = False
            m_strData = _getDateTimeDBValue(Now())
            m_strStatus = ""
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarClientes(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ATENDIMENTO_CLIENTES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        Public Function AdicionarCliente(ByVal vIDCliente As Integer) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "IN_ATENDIMENTO_CLIENTE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.VarChar).Value = vIDCliente

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    AdicionarCliente = True
                Else
                    AdicionarCliente = False
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
        Public Sub Finalizar()
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_ATENDIMENTO_FINALIZAR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub


#End Region

    End Class
End Namespace

