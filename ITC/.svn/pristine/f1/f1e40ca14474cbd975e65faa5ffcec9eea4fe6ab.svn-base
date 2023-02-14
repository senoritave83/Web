Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Public Class Dica



    Inherits DataClass

    Private m_IdDica As Integer
    Private m_Titulo As String
    Private m_Descricao As String
    Private m_IdStatus As Integer

    Public ReadOnly Property IdDica()
        Get
            Return m_IdDica
        End Get
    End Property

    Public Property Titulo() As String
        Get
            Return m_Titulo
        End Get
        Set(ByVal Value As String)
            m_Titulo = Value
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
        m_IdDica = 0
        m_Titulo = ""
        m_Descricao = ""
        m_IdStatus = 0
    End Sub

    Private Function Load(ByVal IdDica As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_DICAS " & IdDica)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_Dica " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdDica = CLng(0 & row("IdDica"))
        Me.m_Titulo = CStr(row("Titulo") & "")
        Me.m_Descricao = CStr(row("Descricao") & "")
        Me.m_IdStatus = CInt(0 & row("IdStatus"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_IdDica & ","
        strDeflate &= "'" & m_Titulo.Replace("'", "''") & "',"
        strDeflate &= "'" & m_Descricao.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Delete(ByVal IdDica As Integer) As Boolean
        ExecuteNonQuery("SP_DE_Dica " & IdDica)
        Return True
    End Function

    Public Function List(ByVal IdDica As Integer) As DataSet
        Return GetDataSet("SP_SE_DICAS " & IdDica)
    End Function

    Public Function ListarUltimaDica() As DataSet
        Return GetDataSet("SP_SE_ULTIMA_DICA")
    End Function

End Class
