
Imports System.Diagnostics.EventLog

Public Class clsFormaPagamento
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListFormaPagamento() As DataSet
        Try
            ListFormaPagamento = GetDataSet("SP_SE_FormaPagamento")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
