'************************************************************
'Classe gerada por XM Class Creator - 15/1/2003 12:03:46
'************************************************************
Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsPesquisadores

    Inherits DataClass

    Public Sub New()

    End Sub

    Public Function List(ByVal p_IdPesquisador As Integer) As DataSet
        Try
            List = GetDataSet("SP_SE_PESQUISADORES " & p_IdPesquisador)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
