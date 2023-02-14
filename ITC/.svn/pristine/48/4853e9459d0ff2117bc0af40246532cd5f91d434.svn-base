Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class Noticia

    Inherits DataClass

    Private m_IdNoticia As Integer
    Private m_Titulo As String
    Private m_Data As String
    Private m_Reportagem As String

    Public ReadOnly Property IdNoticia()
        Get
            Return m_IdNoticia
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

    Public Property Reportagem() As String
        Get
            Return m_Reportagem
        End Get
        Set(ByVal Value As String)
            m_Reportagem = Value
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

    Public Sub New(ByVal IdNoticia As Integer)
        If IdNoticia = 0 Then
            Clear()
        Else
            Load(IdNoticia)
        End If
    End Sub

    Private Sub Clear()
        m_IdNoticia = 0
        m_Titulo = ""
        m_Data = ""
        m_Reportagem = ""
    End Sub

    Private Function Load(ByVal IdNoticia As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_NOTICIA " & IdNoticia)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_NOTICIAS " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Public Function UltimasNoticias(ByVal Quantidade As Integer)
        Try
            Return GetDataSet("SP_SE_ULTIMASNOTICIAS " & Quantidade)
        Catch e As Exception

        End Try
    End Function

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdNoticia = CLng(0 & row("IdNoticia"))
        Me.m_Titulo = CStr(row("Titulo") & "")
        Me.m_Data = CStr(row("Data") & "")
        Me.m_Reportagem = CStr(row("Reportagem") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_IdNoticia & ","
        strDeflate &= "'" & m_Titulo.Replace("'", "''") & "',"
        strDeflate &= "'" & m_Data & "',"
        strDeflate &= "'" & m_Reportagem.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Delete(ByVal IdNoticia As Integer) As Boolean
        ExecuteNonQuery("SP_DE_NOTICIA " & IdNoticia)
        Return True
    End Function

End Class
