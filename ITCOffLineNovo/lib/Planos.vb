
Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsPlanos
    Inherits DataClass

    Sub New()

    End Sub

    Public Function ListPlanos(ByVal vIdProposta As Integer, ByVal vIdOrcamentoProposta As Integer, ByVal vIdPedido As Integer) As DataSet
        Try
            ListPlanos = GetDataSet("SP_SE_PLANOS " & vIdProposta & "," & vIdOrcamentoProposta & "," & vIdPedido)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ConvertDoubleToSQL(ByVal vDbl As Double) As String
        Return vDbl.ToString.Replace(".", "").Replace(",", ".")
    End Function

End Class
