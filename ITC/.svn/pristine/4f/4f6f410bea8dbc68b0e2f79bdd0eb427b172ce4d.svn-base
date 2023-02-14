Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsEstagios

    Inherits DataClass

    Public Sub New()
    End Sub

    Public Function List(ByVal IdFase As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_ESTAGIO 0, " & IdFase)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListTabela() As DataSet
        Try
            Return GetDataSet("SP_SE_ESTAGIO_TABELA")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListTabela(ByVal p_IdUsuario As Integer, ByVal p_IdPesquisa As Integer, ByVal p_IdEmpresa As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_ESTAGIO_TABELA_PESQUISA " & p_IdUsuario & "," & p_IdPesquisa & "," & p_IdEmpresa)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListTabela(ByVal p_IdUsuario As Integer, ByVal p_IdPesquisa As Integer, ByVal p_IdEmpresa As Integer, ByVal p_IdFase As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_ESTAGIO_TABELA_PESQUISA " & p_IdUsuario & "," & p_IdPesquisa & "," & p_IdEmpresa & "," & p_IdFase)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
