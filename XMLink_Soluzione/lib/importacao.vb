Imports System.Data.SqlClient
Imports System.IO

Public Class clsImportacao
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        MyBase.New(vXMPage)
    End Sub

    Public Function Listar() As DataSet
        Return Listar(0, 0)
    End Function

    Public Function GetPath() As String
        Return XMPage.GetSetting("File_Directory", XMPage.Request.ServerVariables("APPL_PHYSICAL_PATH") & "files\")
    End Function

    Public Function GetTipoArquivo(ByVal strArquivo As String) As Integer
        Dim ds As DataSet
        ds = GetDataSet(PREFIXO & "SE_TIPO_ARQUIVO " & XMPage.IDEmpresa & ", '" & strArquivo.Replace("'", "''") & "'")
        GetTipoArquivo = ds.Tables(0).Rows(0).Item(0)
        ds.Dispose()
    End Function

    Public Function GetTipoConfiguracao(ByVal vArquivo As String) As DataSet
        Return GetDataSet("SP_SOL_DTS_SE_TIPO_ARQUIVO_CONFIGURACAO '" & vArquivo.Replace("'", "''") & "', " & XMPage.IDEmpresa)
    End Function

    Public Function Delete(ByVal strArquivo As String)
        ExecuteNonQuery(PREFIXO & "DE_PROCESSO " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "'")
        File.Delete(GetPath() & strArquivo)
    End Function

    Public Function ExportarArquivo(ByVal vTipo As Integer) As String
        Dim ds As DataSet
        ds = GetDataSet(PREFIXO & "BS_EXPORTAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario)
        Dim strTemp As String = ""
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            strTemp = strTemp & ds.Tables(0).Rows(i).Item(0) & vbCrLf
        Next
        ds.Dispose()
        ExportarArquivo = strTemp

    End Function

    Public Function ProcessaArquivo(ByVal strArquivo As String)
        'Dim arq As New FileStream(GetPath() & strArquivo, FileMode.Open, FileAccess.Read)
        Dim ts As New StreamReader(GetPath() & strArquivo, System.Text.Encoding.Default, True)
        Dim strLinha, strObs As String
        Dim intNumero As Integer
        Dim intSize As Short
        Dim ds As DataSet
        ds = GetDataSet(PREFIXO & "BS_IMPORTAR_INICIAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "'")
        intSize = ds.Tables(0).Rows(0).Item(1)
        ds.Dispose()
        strLinha = ts.ReadLine
        intNumero = 1

        Do While Not strLinha Is Nothing
            If Len(strLinha) <> intSize Then
                strObs = "tamanho do arquivo inválido na linha " & intNumero
                Exit Do
            End If
            ExecuteNonQuery(PREFIXO & "BS_IMPORTAR_DADOS " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "', '" & strLinha.Replace("'", "''") & "'")
            strLinha = ts.ReadLine
            intNumero = intNumero + 1
        Loop
        If strObs <> "" Then
            ExecuteNonQuery(PREFIXO & "BS_IMPORTAR_CANCELAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "', '" & strObs.Replace("'", "''") & "'")
        Else
            ExecuteNonQuery(PREFIXO & "BS_IMPORTAR_PROCESSAR " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", '" & strArquivo.Replace("'", "''") & "'")
        End If
        ts.Close()
        ts = Nothing
        'arq.Close()
        'arq = Nothing

    End Function

    Public Function InsereArquivo(ByVal vTipo As Integer) As String
        Dim ds As DataSet
        ds = GetDataSet(PREFIXO & "IN_PROCESSO " & XMPage.IDEmpresa & ", " & XMPage.Usuario.IDUsuario & ", " & vTipo)
        Return GetPath() & ds.Tables(0).Rows(0).Item(0) & ""
    End Function

    Public Function Listar(ByVal vTipo As Short, ByVal vStatus As Short) As DataSet
        Try
            Listar = GetDataSet(PREFIXO & "LS_PROCESSO " & XMPage.IDEmpresa & ", 1, " & vTipo & ", " & vStatus)
        Catch e As System.Exception
            XMPage.LogError(e, "clsImportacao")
        End Try
    End Function
End Class
