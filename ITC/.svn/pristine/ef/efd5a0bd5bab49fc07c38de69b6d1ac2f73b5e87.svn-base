Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Public Class clsSaibaMais

    Inherits DataClass

    Private m_IdSaibaMais As Integer
    Private m_Imagem As String
    Private m_Descricao As String
    Private m_IdStatus As Integer
    Private m_strLink As String

    Public ReadOnly Property IdSaibaMais()
        Get
            Return m_IdSaibaMais
        End Get
    End Property

    Public Property Imagem() As String
        Get
            Return m_Imagem
        End Get
        Set(ByVal Value As String)
            m_Imagem = Value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return m_Descricao
        End Get
        Set(ByVal Value As String)
            m_Descricao = Value
        End Set
    End Property

    Public Property IdStatus() As Integer
        Get
            Return m_IdStatus
        End Get
        Set(ByVal Value As Integer)
            m_IdStatus = Value
        End Set
    End Property

    Public Property Link() As String
        Get
            Return m_strLink
        End Get
        Set(ByVal Value As String)
            m_strLink = Value
        End Set
    End Property

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdDica As Integer)
        If IdDica = 0 Then
            Clear()
        Else
            Load(IdDica)
        End If
    End Sub

    Private Sub Clear()
        m_IdSaibaMais = 0
        m_Imagem = ""
        m_Descricao = ""
        m_IdStatus = 0
        m_strLink = ""
    End Sub

    Private Function Load(ByVal IdSaibaMais As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_SaibaMais " & IdSaibaMais)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_SaibaMais " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdSaibaMais = CLng(0 & row("sbm_registro_int_pk"))
        Me.m_Imagem = CStr(row("sbm_imagem_chr") & "")
        Me.m_Descricao = CStr(row("sbm_texto_chr") & "")
        Me.m_IdStatus = CInt(0 & row("sbm_ativo_ind"))
        Me.m_strLink = CStr(row("sbm_link_chr") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_IdSaibaMais & ","
        strDeflate &= "'" & m_Imagem.Replace("'", "''") & "',"
        strDeflate &= "'" & m_Descricao.Replace("'", "''") & "',"
        strDeflate &= m_IdStatus & ",'"
        strDeflate &= m_strLink & "'"
        Return strDeflate
    End Function

    Public Function Delete(ByVal IdSaibaMais As Integer) As Boolean
        ExecuteNonQuery("SP_DE_SaibaMais " & IdSaibaMais)
        Return True
    End Function

    Public Function List() As DataSet
        Return GetDataSet("SP_LS_SAIBAMAIS")
    End Function

    Public Function ListTodas() As DataSet
        Return GetDataSet("SP_SE_SAIBAMAISFULL")
    End Function

End Class
