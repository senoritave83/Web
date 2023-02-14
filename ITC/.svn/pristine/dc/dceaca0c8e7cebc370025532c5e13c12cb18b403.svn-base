Imports System.Diagnostics.EventLog

Public Class clsStatus
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListStatus() As DataSet
        Try
            ListStatus = GetDataSet("SP_SE_STATUS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
