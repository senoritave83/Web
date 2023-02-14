
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsCidades
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListCidades(ByVal UF As String) As DataSet
        Try
            ListCidades = GetDataSet("SP_SE_CIDADES " & "'" & UF & "'")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
