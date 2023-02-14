Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsCUB

    Inherits DataClass

    Private m_IdCUB As Integer
    Private m_Titulo As String
    Private m_Data As String
    Private m_Descricao As String

    Public ReadOnly Property IdCUB()
        Get
            Return m_IdCUB
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

    Public Property Data() As Object
        Get
            If IsDate(m_Data) Then
                Return Right("00" & Day(m_Data), 2) & "/" & Right("00" & Month(m_Data), 2) & "/" & Right("0000" & Year(m_Data), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_Data = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_Data = Nothing
            End If
        End Set
    End Property

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdCUB As Integer)
        If IdCUB = 0 Then
            Clear()
        Else
            Load(IdCUB)
        End If
    End Sub

    Private Sub Clear()
        m_IdCUB = 0
        m_Titulo = ""
        m_Data = ""
        m_Descricao = ""
    End Sub

    Private Function Load(ByVal IdCUB As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_CUB " & IdCUB)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_CUB " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdCUB = CLng(0 & row("IdCUB"))
        Me.m_Titulo = CStr(row("Titulo") & "")
        Me.m_Data = CStr(row("Data") & "")
        Me.m_Descricao = CStr(row("Descricao") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_IdCUB & ","
        strDeflate &= "'" & m_Titulo.Replace("'", "''") & "',"
        strDeflate &= "'" & m_Data & "',"
        strDeflate &= "'" & m_Descricao.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Delete(ByVal IdCUB As Integer) As Boolean
        ExecuteNonQuery("SP_DE_CUB " & IdCUB)
        Return True
    End Function

    Public Function List(ByVal IdCUB As Integer) As DataSet
        Return GetDataSet("SP_SE_CUB " & IdCUB)
    End Function

End Class
