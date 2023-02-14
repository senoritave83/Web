'************************************************************
'Classe gerada por XM Class Creator - 20/1/2003 17:41:28
'************************************************************

Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsTipos

    Inherits DataClass

    Private m_intIdTipo As Integer
    Private m_strDescricaoTipo As String
    Private m_strSiglaTipo As String

    Public Property IdTipo() As Integer
        Get
            Return m_intIdTipo
        End Get
        Set(ByVal Value As Integer)
            m_intIdTipo = Value
        End Set
    End Property

    Public Property DescricaoTipo() As String
        Get
            Return m_strDescricaoTipo
        End Get
        Set(ByVal Value As String)
            m_strDescricaoTipo = Value
        End Set
    End Property

    Public Property SiglaTipo() As String
        Get
            Return m_strSiglaTipo
        End Get
        Set(ByVal Value As String)
            m_strSiglaTipo = Value
        End Set
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIdTipo = CLng(0 & row("IdTipo"))
        Me.m_strDescricaoTipo = CStr(row("DescricaoTipo") & "")
        Me.m_strSiglaTipo = CStr(row("SiglaTipo") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intIdTipo & "" & ","
        strDeflate &= "'" & m_strDescricaoTipo & "'" & ","
        strDeflate &= "'" & m_strSiglaTipo & "'" & ","
        strDeflate = Mid(strDeflate, 1, Len(strDeflate) - 1)
        Deflate = strDeflate
    End Function

    Public Sub Update()
        Dim sql As String
        sql = "SP_SV_Tipos " & Deflate()
        Dim myData As DataSet

        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub New(ByVal p_IntTipo As Integer)
        If p_IntTipo = 0 Then
            Clear()
        Else
            Load(m_intIdTipo)
        End If
    End Sub

    Protected Sub Load(ByVal p_IntTipo As Integer)
        If p_IntTipo = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_Tipos " & p_IntTipo)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
    End Sub

    Public Sub New()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Clear()
    End Sub

    Private Sub Clear()
        m_intIdTipo = 0
        m_strDescricaoTipo = ""
        m_strSiglaTipo = ""
    End Sub

    Public Function List() As DataSet
        Try
            List = GetDataSet("SP_SE_TIPOS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function List(ByVal SiglaSegInt As Integer) As DataSet

        Dim SiglaSegStr As String
        SiglaSegStr = ""

        If SiglaSegInt = 1 Then
            SiglaSegStr = "IND"
        ElseIf SiglaSegInt = 2 Then
            SiglaSegStr = "COM"
        Else
            SiglaSegStr = "RES"
        End If

        Try
            List = GetDataSet("SP_SE_TIPOS '" & SiglaSegStr & "'")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListSubTipos(ByVal IdTipo As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_LISTASUBTIPOS ")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListSubTiposHome(ByVal IdTipo As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_SUBTIPOSHOME " & IdTipo)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListTiposHome() As DataSet
        Try
            Return GetDataSet("SP_SE_TIPOSHOME ")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class