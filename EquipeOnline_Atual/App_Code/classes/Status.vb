Imports System.Data
Imports System.Data.Common

Imports System.Data.SqlClient

Public Class clsStatus
    Inherits DataClass

    Public Function Listar() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_STATUS"
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteReader(cmd)
    End Function

End Class
