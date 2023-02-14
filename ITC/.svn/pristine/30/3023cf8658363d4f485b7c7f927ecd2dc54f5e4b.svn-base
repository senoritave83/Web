Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsControleAcessos

    Inherits DataClass

    Private m_IdHistorico As Integer
    Private m_IdUsuario As Integer
    Private m_NomeUsuario As String
    Private m_IdAssociado As Integer
    Private m_NomeAssociado As String
    Private m_DataAcesso As Object
    Private m_DataUltimoAcesso As Object
    Private m_IP As String
    Private m_Browser As String
    Private m_Ativo As Boolean

    Public Sub New()

    End Sub

    Public Sub New(ByVal IdHistorico As Integer)
        If IdHistorico = 0 Then
            clear()
        Else
            Load(IdHistorico)
        End If
    End Sub

    Private Sub clear()
        m_IdHistorico = 0
        m_IdUsuario = 0
        m_IdAssociado = 0
        m_NomeAssociado = ""
        m_DataAcesso = Now
        m_DataUltimoAcesso = Now
        m_IP = ""
        m_Browser = ""
    End Sub

    Private Sub Load(ByVal IdHistorico As Integer)
        If IdHistorico = 0 Then
            clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_DADOSACESSOASSOCIADO " & IdHistorico)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        m_IdHistorico = CLng(0 & row("IDHistorico"))
        m_IdUsuario = CLng(0 & row("IdUsuario"))
        m_NomeUsuario = CStr(row("NOMEUSUARIO") & "")
        m_IdAssociado = CLng(0 & row("IdAssociado"))
        m_NomeAssociado = CStr(row("Fantasia") & "")
        m_DataAcesso = CStr(row("DATAACESSO") & "")
        m_DataUltimoAcesso = CStr(row("DATAULTIMOACESSO") & "")
        m_IP = CStr(row("IPACESSO") & "")
        m_Browser = CStr(row("BROWSER") & "")
        m_Ativo = Microsoft.VisualBasic.IIf(CLng(0 & row("Ativo")) = 0, False, True)
    End Sub

    Public ReadOnly Property IdHistorico() As Integer
        Get
            Return m_IdHistorico
        End Get
    End Property

    Public ReadOnly Property IdUsuario() As Integer
        Get
            Return m_IdUsuario
        End Get
    End Property

    Public ReadOnly Property NomeUsuario() As String
        Get
            Return m_NomeUsuario
        End Get
    End Property

    Public ReadOnly Property IdAssociado() As Integer
        Get
            Return m_IdAssociado
        End Get
    End Property

    Public ReadOnly Property NomeAssociado() As String
        Get
            Return m_NomeAssociado
        End Get
    End Property

    Public ReadOnly Property DataAcesso() As Object
        Get
            Return m_DataAcesso
        End Get
    End Property

    Public ReadOnly Property DataUltimoAcesso() As Object
        Get
            Return m_DataUltimoAcesso
        End Get
    End Property

    Public ReadOnly Property IP() As Object
        Get
            Return m_IP
        End Get
    End Property

    Public ReadOnly Property Browser() As Object
        Get
            Return m_Browser
        End Get
    End Property

    Public ReadOnly Property Ativo() As Boolean
        Get
            Return m_Ativo
        End Get
    End Property

    Public Function Pesquisar(ByVal DataInicial As String, ByVal DataFinal As String, ByVal IdEmpresa As Integer, ByVal Associado As String) As DataSet
        Try
            If Not IsDate(DataInicial) Then
                DataInicial = "NULL"
            Else
                DataInicial = "'" & CDate(DataInicial).ToString("yyyy-MM-dd") & " 00:00:00'"
            End If

            If Not IsDate(DataFinal) Then
                DataFinal = "NULL"
            Else
                DataFinal = "'" & CDate(DataFinal).ToString("yyyy-MM-dd") & " 23:59:59'"
            End If

            If Associado = "" Then
                Associado = "NULL"
            Else
                Associado = "'" & Associado & "'"
            End If

            Pesquisar = GetDataSet("SP_SE_CONTROLEACESSOASSOCIADOS " & DataInicial & "," & DataFinal & "," & IdEmpresa & "," & Associado)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function PesquisarUsuarios(ByVal DataInicial As String, ByVal DataFinal As String, ByVal IdEmpresa As Integer, ByVal Usuario As String) As DataSet
        Try
            If Not IsDate(DataInicial) Then
                DataInicial = "NULL"
            Else
                DataInicial = "'" & CDate(DataInicial).ToString("yyyy-MM-dd") & " 00:00:00'"
            End If

            If Not IsDate(DataFinal) Then
                DataFinal = "NULL"
            Else
                DataFinal = "'" & CDate(DataFinal).ToString("yyyy-MM-dd") & " 23:59:59'"
            End If

            If Usuario = "" Then
                Usuario = "NULL"
            Else
                Usuario = "'" & Usuario & "'"
            End If

            PesquisarUsuarios = GetDataSet("SP_SE_CONTROLEACESSOUSUARIOS " & DataInicial & "," & DataFinal & "," & IdEmpresa & "," & Usuario)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function PesquisarSemAcesso(ByVal DataInicial As String, ByVal DataFinal As String, ByVal IdEmpresa As Integer, ByVal Associado As String, ByVal Ordenar As Integer, ByVal IdStatus As Integer) As DataSet
        Try
            If Not IsDate(DataInicial) Then
                DataInicial = "NULL"
            Else
                DataInicial = "'" & CDate(DataInicial).ToString("yyyy-MM-dd") & " 00:00:00'"
            End If

            If Not IsDate(DataFinal) Then
                DataFinal = "NULL"
            Else
                DataFinal = "'" & CDate(DataFinal).ToString("yyyy-MM-dd") & " 23:59:59'"
            End If

            If Associado = "" Then
                Associado = "NULL"
            Else
                Associado = "'" & Associado & "'"
            End If

            Return GetDataSet("SP_SE_CONTROLEUSUARIOSASSOCIADOS_SEMACESSO " & DataInicial & "," & DataFinal & "," & IdEmpresa & "," & Associado & "," & Ordenar & "," & IdStatus)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function BloqueiaAcesso(ByVal IdUsuario As Integer, ByVal IdAssociado As Integer, ByVal tipo As Integer)
        Try
            ExecuteNonQuery("SP_BS_BLOQUEIAACESSOUSUARIO " & IdAssociado & "," & IdUsuario & "," & tipo)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
