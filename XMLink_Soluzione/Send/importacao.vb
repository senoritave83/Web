'************************************************************
'Classe gerada por XM Class Creator - 21/1/2003 18:04:47
    '************************************************************

Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics.EventLog

Public Class clsImportacao

    Inherits DataClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        MyBase.New(vXMPage)
    End Sub

    Public Function GetTipoConfiguracao(ByVal vArquivo As String) As DataSet
        Return GetDataSet("SP_SOL_DTS_SE_TIPO_ARQUIVO_CONFIGURACAO '" & vArquivo.Replace("'", "''") & "', " & XMPage.IDEmpresa)
    End Function

    Public Function GetTipoArquivo(ByVal strArquivo As String) As Integer
        Dim ds As DataSet
        ds = GetDataSet("SP_SOL_WEB_SE_TIPO_ARQUIVO " & XMPage.IDEmpresa & ", '" & strArquivo.Replace("'", "''") & "'")
        GetTipoArquivo = ds.Tables(0).Rows(0).Item(0)
        ds.Dispose()
    End Function

    Public Function AgendarArquivo(ByVal vArquivo As String) As Boolean
        Dim ds As DataSet
        ds = GetDataSet("SP_SOL_WEB_SE_AGENDAR_ARQUIVO '" & vArquivo.Replace("'", "''") & "'")
        AgendarArquivo = CBool(ds.Tables(0).Rows(0).Item(0))
        ds.Dispose()
        ds = Nothing
    End Function

    Public Function List() As DataSet
        Return List(0, 0)
    End Function

    Public Function GetPath() As String
        Return XMPage.Application("Path")
    End Function

    Public Function ApagarArquivo(ByVal strArquivo As String)
        ExecuteNonQuery("SP_SOL_WEB_DE_PROCESSO " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "'")
        File.Delete(GetPath() & strArquivo)
    End Function

    Public Function ExportarArquivo() As String
        Dim ds As DataSet
        ds = GetDataSet("SP_SOL_WEB_BS_EXPORTAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario)
        Dim strTemp As String = ""
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            strTemp = strTemp & ds.Tables(0).Rows(i).Item(0) & vbCrLf
        Next
        ds.Dispose()
        ExportarArquivo = strTemp

    End Function

    Public Function ProcessaArquivo(ByVal strArquivo As String, ByVal vLenght As Integer) As String
        'Dim arq As New FileStream(GetPath() & strArquivo, FileMode.Open, FileAccess.Read)
        Dim ts As New StreamReader(GetPath() & strArquivo, System.Text.Encoding.Default, True)
        Dim strLinha, strObs As String
        Dim intNumero As Integer
        Dim intSize As Short
        Dim ds As DataSet
        Dim f As New FileInfo(GetPath() & strArquivo)
        If f.Length <> vLenght Then
            Return "Tamanho do arquivo recebido inválido"
        End If
        ds = GetDataSet("SP_SOL_WEB_BS_IMPORTAR_INICIAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "'")
        intSize = ds.Tables(0).Rows(0).Item(1)
        ds.Dispose()
        strLinha = ts.ReadLine
        intNumero = 1

        Do While Not strLinha Is Nothing
            If Len(strLinha) <> intSize And Len(strLinha) > 0 Then
                strObs = "tamanho do arquivo inválido na linha " & intNumero
                Exit Do
            End If
            If Len(strLinha) > 0 Then
                ExecuteNonQuery("SP_SOL_WEB_BS_IMPORTAR_DADOS " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "', '" & strLinha.Replace("'", "''") & "'")
                intNumero = intNumero + 1
            End If
            strLinha = ts.ReadLine
        Loop
        If strObs <> "" Then
            ExecuteNonQuery("SP_SOL_WEB_BS_IMPORTAR_CANCELAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "', '" & strObs.Replace("'", "''") & "'")
        Else
            ExecuteNonQuery("SP_SOL_WEB_BS_IMPORTAR_PROCESSAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "'")
        End If
        ts.Close()
        ts = Nothing

        ds = GetDataSet("Select pro_Obs_chr From TB_SOL_Processo_pro (NOLOCK) Where pro_Arquivo_chr = '" & strArquivo.Replace("'", "''") & "'")
        Return ds.Tables(0).Rows(0).Item(0)
    End Function

    Public Function InsereArquivo(ByVal vTipo As Integer) As String
        Dim ds As DataSet
        ds = GetDataSet("SP_SOL_WEB_IN_PROCESSO " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", " & vTipo & ", 0")
        Return ds.Tables(0).Rows(0).Item(0) & ""
    End Function

    Public Function ConfirmaArquivo(ByVal vNome As String, ByVal vLength As Integer) As String
        Dim ds As DataSet
        Dim f As New FileInfo(GetPath() & vNome)
        ds = GetDataSet("SP_SOL_WEB_BS_VERIFICA_ARQUIVO '" & vNome.Replace("'", "''") & "', " & vLength & ", " & f.Length)
        Return ds.Tables(0).Rows(0).Item(0) & ""
    End Function

    Public Function ComparaArquivo(ByVal vNome As String, ByVal vLength As Integer) As Boolean
        Dim ds As DataSet
        Dim f As New FileInfo(GetPath() & vNome)
        ds = GetDataSet("SP_SOL_WEB_BS_VERIFICA_ARQUIVO '" & vNome.Replace("'", "''") & "', " & vLength & ", " & f.Length)
        Return CBool(ds.Tables(0).Rows(0).Item(0))
    End Function

    Public Function GetObservacao(ByVal vArquivo As String) As String
        Dim ds As DataSet
        ds = GetDataSet("SP_SOL_WEB_SE_ARQUIVO_OBSERVACAO '" & vArquivo.Replace("'", "''") & "'")
        Return Trim(CStr(ds.Tables(0).Rows(0).Item(0) & "").Replace("DTS", ""))
    End Function

    Public Function List(ByVal vTipo As Short, ByVal vStatus As Short) As DataSet
        Try
            List = GetDataSet("SP_SOL_WM_LS_PROCESSO " & XMPage.IDEmpresa & ", 1, " & vTipo & ", " & vStatus)
        Catch e As System.Exception
            XMPage.LogError(e, "clsImportacao")
        End Try
    End Function
End Class
