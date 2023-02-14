Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace Classes

    Public Class AtualizaGPS
        Inherits BaseClass

        Public Function getLojas() As System.Data.DataSet

            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT top 10 * FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE ISNULL(LOJ_LATITUDE_NUM,0) = 0"
            cmd.CommandType = Data.CommandType.Text
            Return ExecuteDataSet(cmd)

        End Function


        Public Sub setLoja(ByVal vIdLoja As Integer, vLatitude As String, vLongitude As String)

            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE TB_REP_LOJA_LOJ SET LOJ_LATITUDE_NUM = " & vLatitude & ", loj_longitude_num = " & vLongitude & " WHERE loj_Loja_int_pk=" & vIdLoja
            cmd.CommandType = Data.CommandType.Text
            ExecuteNonQuery(cmd)

        End Sub

    End Class

End Namespace