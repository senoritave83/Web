Imports System.Data
Imports Classes
Imports Ionic.Utils.Zip

Partial Class integracao_exportacaodet
    Inherits XMWebPage

    '*************************************************
    'ATUALIZADA EM 22/05/2006 por Marcelo R
    '*************************************************
    '-------------------------
    'CABECALHO PEDIDO 
    'EPEDIDOS.TXT
    '-------------------------
    'codigo cliente		8  número
    'numero pedido		8  número
    'reservado		8  número
    'data entrega		8  (ddmmyyyy)
    'data emissao		8  (ddmmyyyy)
    'codigo vendedor		8  número
    'motivo			10 
    'desconto		1  texto 
    'valor desconto		5  número (2 casas decimais)
    'codigo operacao		3  texto
    'instrucoes		60 texto
    'codigo pedido		25 texto
    'canal			5  número
    'flag tipo desconto	1  numero
    'codigo ean cliente	13 texto


    '-------------------------
    'ITENS PEDIDO
    'EITENS.TXT
    '-------------------------
    'CODIGO cliente		8  número
    'numero pedido		8  número
    'reservado		8  
    'data entrega		8  (ddmmyyyy)
    'codigo vendedor		8  número
    'codigo produto		25 número
    'quantidade		15 número
    'codigo operacao		3  texto
    'numero da linha		5  número
    'unidade medida		2  texto
    'motivo desconto		10 texto
    'valor desconto		5 número (2 casas decimais)
    'codigo ean produto	13 texto


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '****************************************************************
        'IMPORTACAO GENERAL MILLS CONFORME LAYOUT ABAIXO
        'SERÃO GERADOS DOIS ARQUIVOS .TXT (PEDIDOS.TXT E ITENSPEDIDO.TXT)
        'E DEPOIS COLOCADOS EM UM ARQUIVO .ZIP
        '****************************************************************

        Dim imp As clsIntegracao

        Try

            imp = New clsIntegracao()

            Dim dr As IDataReader
            dr = imp.ExportarPedido(Request("dtini") & "", Request("dtfn") & "", CInt("0" & Request("sta")))

            Dim strFile As String = "FMINAS_" & Now().ToString("yyyyMMdd-hhmmss") & ".ZIP"

            'Cria arquivo ZIP no stream de resposta
            Dim zip As New ZipFile(Response.OutputStream)

            Do
                Dim memPed As New IO.MemoryStream
                Dim intNumPedido As Integer = 0
                Dim stmPed As New IO.StreamWriter(memPed)
                Do While dr.Read
                    intNumPedido = dr.GetInt32(1)
                    stmPed.WriteLine(dr.GetString(0))
                Loop
                stmPed.Flush()
                zip.AddFileStream("PEDIDO_" & intNumPedido & ".TXT", "", memPed)
            Loop While dr.NextResult


            'Cria arquivo de Pedidos

            'Grava resposta
            Response.Clear()
            Response.ClearHeaders()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & strFile)

            zip.Save()
            zip.Dispose()
            zip = Nothing

        Catch ex As System.Exception
            Throw ex
        Finally


        End Try

    End Sub

End Class
