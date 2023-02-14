

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsVisitaPerguntaResposta
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDVisita As Integer
        Protected m_intIDPergunta As Integer
        Protected m_strPergunta As String
        Protected m_intItemResposta As Integer
        Protected m_strResposta As String

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

        Public Overridable ReadOnly Property IDPergunta() As Integer
            Get
                Return m_intIDPergunta
            End Get
        End Property

        Public Overridable ReadOnly Property Pergunta() As String
            Get
                Return m_strPergunta
            End Get
        End Property

        Public Overridable ReadOnly Property ItemResposta() As Integer
            Get
                Return m_intItemResposta
            End Get
        End Property

        Public Overridable Property Resposta() As String
            Get
                Return m_strResposta
            End Get
            Set(ByVal Value As String)
                m_strResposta = Value
            End Set
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            m_intIDPergunta = dr.GetInt32(dr.GetOrdinal("IDPergunta"))
            m_strPergunta = dr.GetString(dr.GetOrdinal("Pergunta"))
            m_intItemResposta = dr.GetInt32(dr.GetOrdinal("ItemResposta"))
            If dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                m_strResposta = ""
            Else
                m_strResposta = dr.GetString(dr.GetOrdinal("Resposta"))
            End If

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_VISITAPERGUNTARESPOSTA"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@ITEMRESPOSTA", SqlDbType.Int).Value = m_intItemResposta
            cmd.Parameters.Add("@RESPOSTA", SqlDbType.VarChar, 100).Value = m_strResposta
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

            Me.User.Log("VisitaPerguntaResposta", "Update - IDVISITA=" & m_intIDVisita & " IDPERGUNTA=" & m_intIDPergunta & " ITEMRESPOSTA=" & m_intItemResposta & " RESPOSTA=" & _
                        m_strResposta)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <param name="vIDPergunta">Chave primaria IDPergunta</param>
        ''' <param name="vItemResposta">Chave primaria ItemResposta</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As Integer, ByVal vIDPergunta As Integer, ByVal vItemResposta As Integer) As Boolean

            If vIDVisita = 0 And vIDPergunta = 0 And vItemResposta = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITAPERGUNTARESPOSTA"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
            cmd.Parameters.Add("@ITEMRESPOSTA", SqlDbType.Int).Value = vItemResposta

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

            Me.User.Log("VisitaPerguntaResposta", "Load - IDVISITA=" & vIDVisita & " IDPERGUNTA=" & vIDPergunta & " ITEMRESPOSTA=" & vItemResposta)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDVisita = 0
            m_intIDPergunta = 0
            m_intItemResposta = 0
            m_strResposta = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VISITAPERGUNTARESPOSTA"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@ITEMRESPOSTA", SqlDbType.Int).Value = m_intItemResposta

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'VISITAPERGUNTARESPOSTA' the following row:  IDVisita=" & m_intIDVisita & " IDEmpresa=" & User.IDEmpresa & " IDPergunta=" & m_intIDPergunta & " ItemResposta=" & m_intItemResposta & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

            Me.User.Log("VisitaPerguntaResposta", "Delete - IDVISITA=" & m_intIDVisita & " IDPERGUNTA=" & m_intIDPergunta & " ITEMRESPOSTA=" & m_intItemResposta)

        End Sub


#End Region



    End Class
End Namespace

