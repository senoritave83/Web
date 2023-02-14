
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

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

End Class
