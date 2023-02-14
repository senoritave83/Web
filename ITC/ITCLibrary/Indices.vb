
Imports System.Diagnostics.EventLog

Public Class Indices

    Inherits DataClass

    Private intIdIndiceITC As Integer = 0
    Private strNomeImagem As String = ""
    Private strDescricao As String = ""

    Public ReadOnly Property IdIndice() As Integer
        Get
            Return intIdIndiceITC
        End Get
    End Property

    Public Property NomeImagem() As String
        Get
            Return strNomeImagem
        End Get
        Set(ByVal Value As String)
            strNomeImagem = Value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return strDescricao
        End Get
        Set(ByVal Value As String)
            strDescricao = Value
        End Set
    End Property

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdIndiceITC As Integer)
        If IdIndiceITC > 0 Then
            Load(IdIndiceITC)
        End If
    End Sub

    Private Sub Load(ByVal IdIndiceITC As Integer)
        If IdIndiceITC = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_INDICEITC ")
        If myData.Tables(0).Rows.Count <= 0 Then
            Clear()
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.intIdIndiceITC = CLng(0 & row("IdIndiceITC"))
        Me.strDescricao = CStr(row("Descricao") & "")
        Me.strNomeImagem = CStr(row("NomeImagem") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String = ""
        strDeflate = "'" & strNomeImagem & "',"
        strDeflate += "'" & strDescricao & "'"
        Return strDeflate
    End Function

    Private Sub Clear()
        intIdIndiceITC = 0
        strDescricao = ""
        strNomeImagem = ""
    End Sub

    Public Function Update() As Boolean
        Try
            Dim sql As String = ""
            sql = "SP_SV_INDICEITC " & Deflate()
            ExecuteNonQuery(sql)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    Public Function Delete(ByVal IdIndice As Integer) As Boolean
        ExecuteNonQuery("SP_DE_INDICE " & IdIndice)
        Return True
    End Function

End Class
