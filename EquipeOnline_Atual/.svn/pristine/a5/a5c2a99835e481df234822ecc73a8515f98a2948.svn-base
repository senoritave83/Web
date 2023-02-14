Imports System.Data.SqlClient

Public Class clsRelatorio
    Inherits DataClass

    Public Function GetReport_Periodo(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_PERIODO"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
    End Function

    Public Function GetReport_Periodo_Linha(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_PERIODO_LINHA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
    End Function

    Public Function GetReport_Status(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_STATUS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_STATUS " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Status_Linha(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_STATUS_LINHA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_STATUS " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Performance(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_PERFORMANCE"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_STATUS " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Performance_Linha(ByVal vDataIni As Date, ByVal vDataFim As Date) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_PERFORMANCE_LINHA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteReader(cmd)
        'Return GetDataSet("SP_WEB_RPT_STATUS " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Etapas(ByVal vDataIni As Date, ByVal vDataFim As Date) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_ETAPAS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteReader(cmd)
        'Return GetDataSet("SP_WEB_RPT_STATUS " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Etapas_Export(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_ETAPAS_EXPORT"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)

    End Function

    Public Function GetReport_Etapas_Linha(ByVal vDataIni As Date, ByVal vDataFim As Date) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_ETAPAS_LINHA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteReader(cmd)
        'Return GetDataSet("SP_WEB_RPT_STATUS " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Clientes(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_CLIENTES"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_CLIENTES " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Clientes_Linha(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_CLIENTES_LINHA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_CLIENTES " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Responsavel(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_RESPONSAVEL"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_RESPONSAVEL " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Responsavel_Linha(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_RESPONSAVEL_LINHA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)
        'Return GetDataSet("SP_WEB_RPT_RESPONSAVEL " & Identity.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_SLA(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "RPT_SLA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataIni
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFim

        Return ExecuteDataSet(cmd)

    End Function

    'Protected Function Serialize(ByVal ds As DataSet) As String
    '    Dim strX, strY As String
    '    strX = "xValues="
    '    strY = "yValues="
    '    Dim i As Integer
    '    For i = 0 To ds.Tables(0).Rows.Count - 1
    '        strX &= ds.Tables(0).Rows(i).Item(0) & "|"
    '        strY &= ds.Tables(0).Rows(i).Item(1) & "|"
    '    Next
    '    strX = strX.TrimEnd("|")
    '    strY = strY.TrimEnd("|")
    '    Return strX & "&" & strY
    'End Function

End Class
