
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsProdutos

    Inherits DataClass

    Private m_IdProduto As Integer
    Private m_DescricaoProduto As String

    Public ReadOnly Property IdProduto() As Integer
        Get
            Return m_IdProduto
        End Get
    End Property

    Public Property DescricaoProduto() As String
        Get
            Return m_DescricaoProduto
        End Get
        Set(ByVal Value As String)
            m_DescricaoProduto = Value
        End Set
    End Property

    Public Function ListProdutos() As DataSet
        Try
            Return GetDataSet("SP_SE_PRODUTOS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListProdutos(ByVal DescricaoProduto As String) As DataSet
        Try
            If DescricaoProduto.Trim = "" Then
                DescricaoProduto = "NULL"
            Else
                DescricaoProduto = "'" & DescricaoProduto & "'"
            End If
            Return GetDataSet("SP_SE_PRODUTOS 0, " & DescricaoProduto)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListProdutosGuia(ByVal p_Letra As String) As DataSet
        Try
            Return GetDataSet("SP_SE_PRODUTOSGUIA '" & p_Letra & "'")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdProduto As Integer)
        If IdProduto = 0 Then
            Clear()
        Else
            Load(IdProduto)
        End If

    End Sub

    Private Sub Clear()
        m_IdProduto = 0
        m_DescricaoProduto = ""
    End Sub

    Private Function Load(ByVal IdProduto As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_PRODUTO " & IdProduto)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_PRODUTOS " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub


    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdProduto = CLng(0 & row("IdProduto"))
        Me.m_DescricaoProduto = CStr(row("DescricaoProduto") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String = m_IdProduto & ",'" & m_DescricaoProduto.Replace("'", "''") & "'"
        Return strDeflate
    End Function

End Class
