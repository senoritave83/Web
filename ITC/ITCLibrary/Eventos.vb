Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class Evento

    Inherits DataClass

    Private m_IdEvento As Integer
    Private m_Titulo As String
    Private m_DataInicial As String
    Private m_DataFinal As String
    Private m_DescricaoEvento As String

    Public ReadOnly Property IdEvento()
        Get
            Return m_IdEvento
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

    Public Property DescricaoEvento() As String
        Get
            Return m_DescricaoEvento
        End Get
        Set(ByVal Value As String)
            m_DescricaoEvento = Value
        End Set
    End Property

    Public Property DataInicial() As Object
        Get
            If IsDate(m_DataInicial) Then
                Return Right("00" & Day(m_DataInicial), 2) & "/" & Right("00" & Month(m_DataInicial), 2) & "/" & Right("0000" & Year(m_DataInicial), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_DataInicial = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_DataInicial = Nothing
            End If
        End Set
    End Property

    Public Property DataFinal() As Object
        Get
            If IsDate(m_DataInicial) Then
                Return Right("00" & Day(m_DataFinal), 2) & "/" & Right("00" & Month(m_DataFinal), 2) & "/" & Right("0000" & Year(m_DataFinal), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_DataFinal = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_DataFinal = Nothing
            End If
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal IdEvento As Integer)
        Load(IdEvento)
    End Sub

    Private Function Load(ByVal IdEvento As Integer)

        Dim myDataInicial As DataSet
        myDataInicial = GetDataSet("SP_SE_EVENTO " & IdEvento)

        If myDataInicial.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myDataInicial.Tables(0).Rows(0))
        End If
        myDataInicial.Dispose()

    End Function

    Public Function Delete(ByVal IdEvento As Integer) As Boolean
        ExecuteNonQuery("SP_DE_EVENTO " & IdEvento)
        Return True
    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_EVENTOS " & Deflate()
        Dim myDataInicial As DataSet = GetDataSet(sql)
        If myDataInicial.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myDataInicial.Tables(0).Rows(0))
        End If
        myDataInicial.Dispose()

    End Sub

    Public Function UltimosEventos(ByVal Quantidade As Integer)
        Try
            Return GetDataSet("SP_SE_ULTIMOSEVENTOS " & Quantidade)
        Catch e As Exception

        End Try
    End Function

    Public Function ListaEventos()
        Try
            Return GetDataSet("SP_SE_EVENTOS")
        Catch e As Exception

        End Try
    End Function

    Public Function Lista()
        Try
            Return GetDataSet("SP_SE_EVENTO")
        Catch e As Exception

        End Try
    End Function

    Private Sub Inflate(ByVal row As DataRow)

        Me.m_IdEvento = CLng(0 & row("IdEvento"))
        Me.m_Titulo = CStr(row("NomeEvento") & "")
        Me.m_DataInicial = CStr(row("DataInicial") & "")
        Me.m_DataFinal = CStr(row("DataFinal") & "")
        Me.m_DescricaoEvento = CStr(row("DescricaoEvento") & "")

    End Sub

    Private Function Deflate() As String

        Dim strDeflate As String

        strDeflate &= m_IdEvento & ","
        strDeflate &= "'" & m_Titulo.Replace("'", "''") & "',"
        strDeflate &= "'" & m_DataInicial & "',"
        strDeflate &= "'" & m_DataFinal & "',"
        strDeflate &= "'" & m_DescricaoEvento.Replace("'", "''") & "'"

        Return strDeflate

    End Function

End Class
