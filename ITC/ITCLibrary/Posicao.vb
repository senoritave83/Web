Imports System.Diagnostics.EventLog

Public Class clsPosicao
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListPosicao() As DataSet
        Try
            ListPosicao = GetDataSet("SP_SE_Posicao")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
