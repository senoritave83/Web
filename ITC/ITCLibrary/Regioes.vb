
Imports System.Diagnostics.EventLog

Public Class clsRegioes
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListRegioes() As DataSet
        Try
            ListRegioes = GetDataSet("SP_SE_Regioes")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
