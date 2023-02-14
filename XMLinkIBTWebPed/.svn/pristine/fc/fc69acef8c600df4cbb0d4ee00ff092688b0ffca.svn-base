

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsUF
        Inherits BaseClass



#Region "Declarations"
        Protected m_strUF As String
        Protected m_strEstado As String
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property UF() As String
            Get
                Return m_strUF
            End Get
        End Property

        Public Overridable Property Estado() As String
            Get
                Return m_strEstado
            End Get
            Set(ByVal Value As String)
                m_strEstado = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_strUF = dr.GetString(dr.GetOrdinal("UF"))
            m_strEstado = dr.GetString(dr.GetOrdinal("Estado"))
        End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vUF">Chave primaria UF</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vUF As String) As Boolean
            If vUF = "" Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ESTADO"
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
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
            m_strUF = ""
            m_strEstado = ""
        End Sub


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

#End Region

    End Class
End Namespace

