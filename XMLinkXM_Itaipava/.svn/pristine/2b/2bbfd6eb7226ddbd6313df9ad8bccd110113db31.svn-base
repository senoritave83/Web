Imports System.Data.SqlClient
Imports System.Data


Public Class clsRecados
    Inherits BaseClass

    Public Function Listar(ByVal vFiltro As String, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "NV_RECADOS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar).Value = vFiltro
        If vDataInicial <> "" Then
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
        End If
        If vDataFinal <> "" Then
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
        End If
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecutePaginate(cmd, enReturnType.DataReader, vPageSize, vPage)

    End Function


    Public Function Enviar(ByVal vIdEmpresa As Integer, ByVal vGrupo As Boolean, ByVal vID As Integer, ByVal vMensagem As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "IN_RECADO_DIGITAL"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@GRUPO", SqlDbType.Int).Value = IIf(vGrupo, 1, 0)
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = vID
        cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar).Value = vMensagem
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser

        ExecuteNonQuery(cmd)

        Return True

    End Function

    Public Function Destinatarios(ByVal vRegionais As String, ByVal vRevendas As String, ByVal vNiveis As String) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "LS_DESTINATARIOS_RECADO_TEMP"
        cmd.Parameters.Add("@IDEMPRESAUSUARIO", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIOLOGADO", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@REGIONAIS", SqlDbType.VarChar, 1000).Value = vRegionais
        cmd.Parameters.Add("@EMPRESAS", SqlDbType.VarChar, 2000).Value = vRevendas
        cmd.Parameters.Add("@NIVEIS", SqlDbType.VarChar, 1000).Value = vNiveis
        Return ExecuteReader(cmd)
    End Function

    Public Function TipoUsuario() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "LS_TIPOUSUARIO_RECADO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        Return ExecuteReader(cmd)
    End Function

    Public Function Regionais() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "LS_REGIONAIS_USUARIO_RECADO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
        Return ExecuteReader(cmd)
    End Function

    Public Function Revendas(ByVal vRegionais As String) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "LS_REVENDAS_RECADO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
        cmd.Parameters.Add("@REGIONAIS", SqlDbType.VarChar, 1000).Value = vRegionais
        Return ExecuteReader(cmd)
    End Function

    Public Function DestinatariosRecado(ByVal vRegionais As String, ByVal vRevendas As String, ByVal vNiveis As String) As IDataReader
        Return Destinatarios(vRegionais, vRevendas, vNiveis)
    End Function

End Class
