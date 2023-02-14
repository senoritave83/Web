Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsVendedores

    Inherits DataClass
    Private m_IdVendedor As Integer
    Private m_NomeVendedor As String
    Private m_IdUsuario As Integer
    Private m_NomeUsuario As String

    Public ReadOnly Property IdVendedor() As Integer
        Get
            Return m_IdVendedor
        End Get
    End Property

    Public Property NomeVendedor() As String
        Get
            Return m_NomeVendedor
        End Get
        Set(ByVal Value As String)
            m_NomeVendedor = Value
        End Set
    End Property

    Public Property IdUsuario() As Integer
        Get
            Return m_IdUsuario
        End Get
        Set(ByVal Value As Integer)
            m_IdUsuario = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_NomeUsuario
        End Get
        Set(ByVal Value As String)
            m_NomeUsuario = Value
        End Set
    End Property

    Public Function ListVendedores() As DataSet
        Try
            ListVendedores = GetDataSet("SP_SE_VENDEDORES")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListVendedores(ByVal NomeVendedor As String, ByVal p_IdEmpresa As Integer, ByVal p_IdUsuario As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_VENDEDORES 0, '" & NomeVendedor & "', " & p_IdEmpresa & "," & p_IdUsuario)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdVendedor As Integer)
        If IdVendedor = 0 Then
            Clear()
        Else
            Load(IdVendedor)
        End If

    End Sub

    Private Sub Clear()
        m_IdVendedor = 0
        m_NomeVendedor = ""
        m_NomeUsuario = ""
        m_IdUsuario = 0
    End Sub

    Private Function Load(ByVal IdVendedor As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_VENDEDOR " & IdVendedor)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Function ExisteUsuarioVendedor(ByVal p_IdVendedor As Integer, ByVal p_IdUsuario As Integer) As Boolean

        Dim sql As String, blnReturn As Boolean = False
        sql = "SP_SE_EXISTEUSUARIOVENDEDOR " & m_IdVendedor & "," & p_IdUsuario
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            blnReturn = IIf(myData.Tables(0).Rows(0).Item(0) = 1, True, False)
        End If
        myData.Dispose()

        Return blnReturn

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_VENDEDORES " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub


    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdVendedor = CLng(0 & row("IdVendedor"))
        Me.m_NomeVendedor = CStr(row("Nome") & "")
        Me.m_IdUsuario = CLng(0 & row("Usu_Usuario_Int_FK"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String = m_IdVendedor & ",'" & m_NomeVendedor.Replace("'", "''") & "'," & m_IdUsuario
        Return strDeflate
    End Function

End Class
