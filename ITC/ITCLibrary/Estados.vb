
Imports System.Diagnostics.EventLog

Public Class clsEstados
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListEstados() As DataSet
        Try
            ListEstados = GetDataSet("SP_SE_ESTADOS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListEstados(ByVal p_IdEstados As Integer) As DataSet
        Try
            ListEstados = GetDataSet("SP_SE_ESTADOS " & p_IdEstados)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
