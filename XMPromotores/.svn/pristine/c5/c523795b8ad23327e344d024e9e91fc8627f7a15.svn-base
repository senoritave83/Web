Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsEntidade
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDEntidade As Integer
        Protected m_strEntidade As String
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDEntidade() As Integer
            Get
                Return m_intIDEntidade
            End Get
        End Property

        Public Overridable Property Entidade() As String
            Get
                Return m_strEntidade
            End Get
            Set(ByVal Value As String)
                m_strEntidade = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDEntidade = dr.GetInt32(dr.GetOrdinal("IDEntidade"))
            m_strEntidade = dr.GetString(dr.GetOrdinal("Entidade"))
        End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDEntidade">Chave primaria IDEntidade</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDEntidade As Integer) As Boolean
            If vIDEntidade = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ENTIDADE"
            cmd.Parameters.Add("@IDENTIDADE", SqlDbType.Int).value = vIDEntidade
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
            m_intIDEntidade = 0
            m_strEntidade = ""
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ENTIDADES"
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarEmFotos(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ENTIDADES_FOTOS"
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarEmVisitas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ENTIDADES_VISITAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)
        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace