'************************************************************
'Classe gerada por XM Class Creator - 21/1/2003 12:56:49
'************************************************************

Imports System.Data.SqlClient

Imports System.Diagnostics.EventLog

Public Class clsAtividades

    Inherits DataClass

    Private m_intIdAtividade As Integer
    Private m_strDescricaoAtividade As String
    Private Data As New DataClass()

    Public Property IdAtividade() As Integer
        Get
            Return m_intIdAtividade
        End Get
        Set(ByVal Value As Integer)
            m_intIdAtividade = Value
        End Set
    End Property

    Public Property DescricaoAtividade() As String
        Get
            Return m_strDescricaoAtividade
        End Get
        Set(ByVal Value As String)
            m_strDescricaoAtividade = Value
        End Set
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIdAtividade = CLng(0 & row("IdAtividade"))
        Me.m_strDescricaoAtividade = CStr(row("DescricaoAtividade") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intIdAtividade & "" & ","
        strDeflate &= "'" & m_strDescricaoAtividade & "'" & ","
        strDeflate = Mid(strDeflate, 1, Len(strDeflate) - 1)
        Deflate = strDeflate
    End Function

    Public m_MensagemErro As String = ""
    Public ReadOnly Property MensagemErro()
        Get
            Return m_MensagemErro
        End Get
    End Property

    Public Sub Update()
        Dim sql As String
        sql = "SP_SV_ATIVIDADES " & Deflate()
        Dim myData As DataSet
        m_MensagemErro = ""
        myData = Data.GetDataSet(sql, m_MensagemErro)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub New(ByVal p_IdAtividade As Integer)
        If p_IdAtividade = 0 Then
            Clear()
        Else
            Load(p_IdAtividade)
        End If
    End Sub

    Protected Sub Load(ByVal p_IdAtividade As Integer)
        If p_IdAtividade = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        m_MensagemErro = ""
        myData = Data.GetDataSet("SP_SE_Atividades " & p_IdAtividade, m_MensagemErro)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub New()
        Clear()
    End Sub

    Private Sub Clear()
        m_intIdAtividade = 0
        m_strDescricaoAtividade = ""
    End Sub

    Public Function List() As DataSet
        Try
            m_MensagemErro = ""
            List = Data.GetDataSet("SP_SE_Atividades", m_MensagemErro)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListSubAtividades(ByVal IdAtividade As Integer) As DataSet
        Try
            m_MensagemErro = ""
            ListSubAtividades = Data.GetDataSet("SP_SE_SUBATIVIDADES " & IdAtividade, m_MensagemErro)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListAtividadesTabela() As DataSet
        Try
            m_MensagemErro = ""
            Return Data.GetDataSet("SP_SE_ATIVIDADES_TABELA " & IdAtividade, m_MensagemErro)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class