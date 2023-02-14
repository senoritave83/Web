
Imports System.Diagnostics.EventLog

Public Class clsGrupos

    Inherits DataClass

    Private m_IdGrupo As Integer
    Private m_DescricaoGrupo As String

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdGrupo As Integer)
        If IdGrupo > 0 Then
            Load(IdGrupo)
        End If
    End Sub

    Private Sub Load(ByVal IdGrupo As Integer)
        If IdGrupo = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_GRUPOS " & IdGrupo)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdGrupo = CLng(0 & row("IDGRUPO"))
        Me.m_DescricaoGrupo = CStr(row("DESCRICAOGRUPO") & "")
    End Sub

    Private Function Deflate() As String
        Return m_IdGrupo & ",'" & m_DescricaoGrupo & "'"
    End Function

    Private Sub Clear()
        m_IdGrupo = 0
        m_DescricaoGrupo = ""
    End Sub

    Public ReadOnly Property IdGrupo()
        Get
            Return m_IdGrupo
        End Get
    End Property

    Public Property Grupo() As String
        Get
            Return m_DescricaoGrupo
        End Get
        Set(ByVal Value As String)
            m_DescricaoGrupo = Value
        End Set
    End Property

    Public Function Update() As Boolean

        Try

            Dim sql As String = ""
            Dim myData As DataSet

            sql = "SP_SV_GRUPOS " & Deflate()
            myData = GetDataSet(sql)

            If myData.Tables(0).Rows.Count <= 0 Then
                Throw New ArgumentException("NÃO HOUVE RETORNO DE DADOS!")
                Return False
            Else
                Inflate(myData.Tables(0).Rows(0))
                Return True
            End If
            myData = Nothing

        Catch e As Exception

            Return False

        End Try

    End Function

    Public Function List() As DataSet
        'permissões dos usuários do sistema
        Try
            Return GetDataSet("SP_SE_GRUPOS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListPermissoes(ByVal p_IdGrupo As Integer) As DataSet
        'permissões dos usuários do sistema
        Try
            Return GetDataSet("SP_SE_PERMISSOES_GRUPOS " & p_IdGrupo)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function


    Public Function SavePermissoes(ByVal Permissoes As String) As Boolean
        Try
            ExecuteNonQuery("SP_SV_PERMISSOES_GRUPO '" & Permissoes & "', " & m_IdGrupo)
            Return True
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Return False
        End Try
    End Function

End Class
