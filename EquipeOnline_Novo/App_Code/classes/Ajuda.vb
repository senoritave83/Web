Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class clsAjuda
    Inherits DataClass

    Public Function fn_PNOL_SEL_ONLINE_HELP_ARVORE_WEB(ByVal intHelp As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PNOL_SEL_ONLINE_HELP_ARVORE_WEB"
        cmd.Parameters.Add("@CD_ITEM_ONLINE_HELP", SqlDbType.Int).Value = intHelp
        Return ExecuteDataSet(cmd)
    End Function

End Class
