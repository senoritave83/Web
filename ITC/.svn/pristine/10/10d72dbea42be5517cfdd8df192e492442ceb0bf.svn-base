Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsProdutosAssociado

    Inherits DataClass
    Private m_IdAssociado As Integer
    Private m_Associado As String
    Private m_IdProduto As Integer
    Private m_Produto As String
    Private m_Itens As String

    Public Property IdAssociado() As Integer
        Get
            Return m_IdAssociado
        End Get
        Set(ByVal Value As Integer)
            m_IdAssociado = Value
        End Set
    End Property

    Public ReadOnly Property Associado() As String
        Get
            Return m_Associado
        End Get
    End Property

    Public Property IdProduto() As Integer
        Get
            Return m_IdProduto
        End Get
        Set(ByVal Value As Integer)
            m_IdProduto = Value
        End Set
    End Property

    Public ReadOnly Property Produto() As String
        Get
            Return m_Produto
        End Get
    End Property

    Public WriteOnly Property Itens() As String
        Set(ByVal Value As String)
            m_Itens = "'" & Value & "'"
        End Set
    End Property

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal p_IdAssociado As Integer, ByVal p_IdProduto As Integer)
        If p_IdAssociado = 0 Or p_IdProduto = 0 Then
            Clear()
            Exit Sub
        End If
        Load(p_IdAssociado, p_IdProduto)
    End Sub

    Private Sub Load(ByVal p_IdAssociado As Integer, ByVal p_IdProduto As Integer)
        If p_IdAssociado = 0 Or p_IdProduto = 0 Then
            Clear()
            Exit Sub
        End If

        Dim myData As DataSet

        myData = GetDataSet("SP_SE_PRODUTOS_ASSOCIADOS " & p_IdAssociado & "," & p_IdProduto)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String = m_IdAssociado & "," & m_IdProduto
        Return strDeflate
    End Function

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdAssociado = CLng(0 & row("IDASSOCIADO"))
        Me.m_IdProduto = CLng(0 & row("IDPRODUTO"))
        Me.m_Associado = CStr(row("FANTASIA") & "")
        Me.m_Produto = CStr(row("DESCRICAOPRODUTO") & "")
    End Sub

    Public Sub Update()

        Dim sql As String
        Dim myData As DataSet

        sql = "SP_SV_PRODUTOS_ASSOCIADOS " & m_IdAssociado & ", 0, " & m_Itens
        myData = GetDataSet(sql)
        myData.Dispose()

    End Sub

    Private Sub Clear()
        m_IdAssociado = 0
        m_IdProduto = 0
        m_Associado = ""
        m_Produto = ""
    End Sub

    Public Function List(ByVal IdAssociado As Integer, ByVal IdProduto As Integer) As DataSet
        Try
            List = GetDataSet("SP_SE_PRODUTOS_ASSOCIADOS " & IdAssociado & "," & IdProduto)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListProdutosAssociado(ByVal IdAssociado As Integer) As DataSet
        Try
            ListProdutosAssociado = GetDataSet("SP_SE_PRODUTOS_ASSOCIADOS_LISTA " & IdAssociado)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
