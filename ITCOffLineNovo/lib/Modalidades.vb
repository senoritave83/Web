
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsModalidades

    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListModalidades() As DataSet
        Try
            ListModalidades = GetDataSet("SP_SE_MODALIDADE")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
