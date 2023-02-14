Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class clsExportacao
    Inherits BaseClass

    'Public Function ExportarDados(ByVal p_IdClientes As String, ByVal p_IdLojas As String, _
    '                                  ByVal p_IdCoordenadores As String, ByVal p_IdLideres As String, ByVal p_IdPromotores As String, _
    '                                  ByVal p_IdCategorias As String, ByVal p_IdSubCategorias As String, ByVal p_IdProdutos As String, _
    '                                  ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, ByVal p_IdRegiao As String, ByVal p_IdStatus As Byte, _
    '                                  ByVal p_IDJustificativas As String, ByVal p_Tabelas As Byte, _
    '                                  ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Shopping As String) As IDataReader

    '    Dim cmd As New SqlCommand()
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = PREFIXO & "RPT_EXPORTAR_DADOS"
    '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
    '    cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 512).Value = p_IdClientes
    '    cmd.Parameters.Add("@IDLOJAS", SqlDbType.VarChar, 512).Value = p_IdLojas
    '    cmd.Parameters.Add("@IDCOORDENADORES", SqlDbType.VarChar, 512).Value = p_IdCoordenadores
    '    cmd.Parameters.Add("@IDLIDERES", SqlDbType.VarChar, 512).Value = p_IdLideres
    '    cmd.Parameters.Add("@IDPROMOTORES", SqlDbType.VarChar, 512).Value = p_IdPromotores
    '    cmd.Parameters.Add("@IDCATEGORIAS", SqlDbType.VarChar, 512).Value = p_IdCategorias
    '    cmd.Parameters.Add("@IDSUBCATEGORIAS", SqlDbType.VarChar, 512).Value = p_IdSubCategorias
    '    cmd.Parameters.Add("@IDPRODUTOS", SqlDbType.VarChar, 512).Value = p_IdProdutos
    '    cmd.Parameters.Add("@IDESTADOS", SqlDbType.VarChar, 512).Value = p_IdEstados
    '    cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.VarChar, 512).Value = p_IdTipoLoja
    '    cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar, 512).Value = p_IdRegiao
    '    cmd.Parameters.Add("@IDSTATUS", SqlDbType.TinyInt).Value = p_IdStatus
    '    cmd.Parameters.Add("@IDSHOPPING", SqlDbType.VarChar, 512).Value = p_Shopping
    '    cmd.Parameters.Add("@IDJUSTIFICATIVAS", SqlDbType.VarChar, 512).Value = p_IDJustificativas
    '    cmd.Parameters.Add("@PERIODOINICIAL", SqlDbType.VarChar, 10).Value = p_PeriodoInicial
    '    cmd.Parameters.Add("@PERIODOFINAL", SqlDbType.VarChar, 10).Value = p_PeriodoFinal
    '    cmd.Parameters.Add("@TABELAS", SqlDbType.TinyInt).Value = p_Tabelas

    '    Return ExecuteReader(cmd)

    'End Function

    Public Function ExportarDados(ByVal p_IdClientes As String, ByVal p_IdLojas As String, _
                                  ByVal p_IdCoordenadores As String, ByVal p_IdLideres As String, ByVal p_IdPromotores As String, _
                                  ByVal p_IdCategorias As String, ByVal p_IdSubCategorias As String, ByVal p_IdProdutos As String, _
                                  ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, ByVal p_IdRegiao As String, ByVal p_IdStatus As Byte, _
                                  ByVal p_IDJustificativas As String, ByVal p_Tabelas As Byte, _
                                  ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Shopping As String, ByVal p_Fields As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "RPT_EXPORTAR_DADOS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 512).Value = p_IdClientes
        cmd.Parameters.Add("@IDLOJAS", SqlDbType.VarChar, 512).Value = p_IdLojas
        cmd.Parameters.Add("@IDCOORDENADORES", SqlDbType.VarChar, 512).Value = p_IdCoordenadores
        cmd.Parameters.Add("@IDLIDERES", SqlDbType.VarChar, 512).Value = p_IdLideres
        cmd.Parameters.Add("@IDPROMOTORES", SqlDbType.VarChar, 512).Value = p_IdPromotores
        cmd.Parameters.Add("@IDCATEGORIAS", SqlDbType.VarChar, 512).Value = p_IdCategorias
        cmd.Parameters.Add("@IDSUBCATEGORIAS", SqlDbType.VarChar, 512).Value = p_IdSubCategorias
        cmd.Parameters.Add("@IDPRODUTOS", SqlDbType.VarChar, 512).Value = p_IdProdutos
        cmd.Parameters.Add("@IDESTADOS", SqlDbType.VarChar, 512).Value = p_IdEstados
        cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.VarChar, 512).Value = p_IdTipoLoja
        cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar, 512).Value = p_IdRegiao
        cmd.Parameters.Add("@IDSTATUS", SqlDbType.TinyInt).Value = p_IdStatus
        cmd.Parameters.Add("@IDSHOPPING", SqlDbType.VarChar, 512).Value = p_Shopping
        cmd.Parameters.Add("@IDJUSTIFICATIVAS", SqlDbType.VarChar, 512).Value = p_IDJustificativas
        cmd.Parameters.Add("@PERIODOINICIAL", SqlDbType.VarChar, 10).Value = p_PeriodoInicial
        cmd.Parameters.Add("@PERIODOFINAL", SqlDbType.VarChar, 10).Value = p_PeriodoFinal
        cmd.Parameters.Add("@TABELAS", SqlDbType.TinyInt).Value = p_Tabelas
        cmd.Parameters.Add("@FIELDS", SqlDbType.VarChar, 8000).Value = p_Fields

        Return ExecuteCommand(cmd, vReturnType)

        Me.User.Log("Exportacao", "ExportarDados - IDCLIENTES=" & p_IdClientes & " IDLOJAS=" & p_IdLojas & " IDCOORDENADORES=" & p_IdCoordenadores & _
                    " IDLIDERES=" & p_IdLideres & " IDPROMOTORES=" & p_IdPromotores & " IDCATEGORIAS=" & p_IdCategorias & _
                    " IDSUBCATEGORIAS=" & p_IdSubCategorias & " IDPRODUTOS=" & p_IdProdutos & " IDESTADOS=" & p_IdEstados & _
                    " IDTIPOLOJA=" & p_IdTipoLoja & " IDREGIAO=" & p_IdRegiao & " IDSTATUS=" & p_IdStatus & " IDSHOPPING=" & p_Shopping & _
                    " IDJUSTIFICATIVAS=" & p_IDJustificativas & " PERIODOINICIAL=" & p_PeriodoInicial & " PERIODOFINAL=" & p_PeriodoFinal & _
                    " TABELAS=" & p_Tabelas & " FIELDS=" & p_Fields)

    End Function

End Class
