Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsEmpresasObras

    Inherits DataClass

    Private m_IdObra As Integer
    Private m_IdEmpresa As Integer
    Private m_Fantasia As String
    Private m_RazaoSocial As String
    Private m_IdModalidade As Integer
    Private m_IdModalidadeAntigo As Integer

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdObra As Integer, ByVal IdEmpresa As Integer, ByVal IdModalidade As Integer)
        If IdObra = 0 Or IdEmpresa = 0 Or IdModalidade = 0 Then
            Clear()
        Else
            Load(IdObra, IdEmpresa, IdModalidade)
        End If
    End Sub

    Private Sub Load(ByVal IdObra As Integer, ByVal IdEmpresa As Integer, ByVal IdModalidade As Integer)
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_OBRAS_EMPRESAS " & IdObra & ", " & IdEmpresa & ", " & IdModalidade)
        If myData.Tables(0).Rows.Count <= 0 Then
            Clear()
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdObra = CLng(0 & row("IdObra"))
        Me.m_IdEmpresa = CLng(0 & row("IdEmpresa"))
        Me.m_IdModalidade = CLng(0 & row("IdModalidade"))
        Me.m_Fantasia = CStr(row("Fantasia") & "")
        Me.m_RazaoSocial = CStr(row("RazaoSocial") & "")
    End Sub

    Public Sub Apagar()
        Dim sql As String
        sql = "SP_DE_OBRAS_EMPRESAS " & m_IdObra & "," & m_IdEmpresa & "," & m_IdModalidade
        ExecuteNonQuery(sql)
    End Sub


    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_OBRAS_EMPRESAS " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Function Deflate() As String

        Dim strDeflate As String

        strDeflate = m_IdObra & ","
        strDeflate &= m_IdEmpresa & ","
        strDeflate &= m_IdModalidade & ","
        strDeflate &= Microsoft.VisualBasic.IIf(m_IdModalidadeAntigo > 0, m_IdModalidadeAntigo, "NULL")

        Return strDeflate

    End Function

    Private Sub Clear()
        m_IdObra = 0
        m_IdEmpresa = 0
        m_IdModalidade = 0
    End Sub

    Public Property IdEmpresa() As Integer
        Get
            Return m_IdEmpresa
        End Get
        Set(ByVal Value As Integer)
            m_IdEmpresa = Value
        End Set
    End Property

    Public Property IdObra() As Integer
        Get
            Return m_IdObra
        End Get
        Set(ByVal Value As Integer)
            m_IdObra = Value
        End Set
    End Property

    Public Property IdModalidade() As Integer
        Get
            Return m_IdModalidade
        End Get
        Set(ByVal Value As Integer)
            m_IdModalidade = Value
        End Set
    End Property

    Public WriteOnly Property IdModalidadeAntigo() As Integer
        Set(ByVal Value As Integer)
            m_IdModalidadeAntigo = Value
        End Set
    End Property

    Public Function List(ByVal IdObra As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try
            List = GetDataSet("SP_SE_OBRAS_EMPRESAS " & IdObra & ", " & IdEmpresa)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
