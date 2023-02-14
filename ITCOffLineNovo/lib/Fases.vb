
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsFases

    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListFases() As DataSet
        Try
            ListFases = GetDataSet("SP_SE_FASES")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
