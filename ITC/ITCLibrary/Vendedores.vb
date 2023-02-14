Imports System.Diagnostics.EventLog

Public Class clsVendedores
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListVendedores() As DataSet
        Try
            ListVendedores = GetDataSet("SP_SE_VENDEDORES")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
