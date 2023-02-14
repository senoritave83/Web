
Imports System.Diagnostics.EventLog

Public Class clsRamosAtividades

    Inherits DataClass

    Public Sub New()

    End Sub

    Public Function ListRamos() As DataSet
        Try
            ListRamos = GetDataSet("SP_SE_RAMOS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListAtividades(ByVal IdRamo As Integer) As DataSet
        Try
            ListAtividades = GetDataSet("SP_SE_ATIVIDADES_RAMO 0, " & IdRamo)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
