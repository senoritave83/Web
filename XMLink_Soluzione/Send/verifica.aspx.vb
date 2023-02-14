Public Class verifica
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim cls As clsImportacao
        cls = New clsImportacao(Me)
        Dim vArquivo As String = Request("File")
        If cls.ComparaArquivo(Request("File"), CInt(Request("Length"))) Then


            Dim ds As DataSet, iIDTipo As Integer
            Dim sColumns, sDescription, sDestinationTable, sProcedure, sDestinationColumns As String
            ds = cls.GetTipoConfiguracao(vArquivo)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    sColumns = .Item(0)
                    sDescription = .Item(1)
                    sDestinationTable = .Item(2)
                    sProcedure = .Item(3)
                    iIDTipo = .Item(4)
                    sDestinationColumns = .Item(5)
                End With
                ds.Dispose()
                ds = Nothing
                Dim dts As New XMDTS.DTSImportacao(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "dts.log")
                dts.Processar(vArquivo, iIDTipo, sColumns, sDescription, sDestinationTable, sProcedure, sDestinationColumns)
                Response.Write(cls.GetObservacao(vArquivo))
            Else
                Response.Write(cls.ConfirmaArquivo(Request("File"), CInt(Request("Length"))))
            End If

            'Dim vIDTipo As XMDtsMixkit.Tipo_Arquivo = cls.GetTipoArquivo(vArquivo)
            'Select Case vIDTipo
            '    Case XMDtsMixkit.Tipo_Arquivo.Clientes
            '        Dim dts As New XMDtsMixkit.DTSCliente(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "auto.log")
            '        dts.Processar(vArquivo)
            '        dts = Nothing
            '        Response.Write(cls.GetObservacao(vArquivo))
            '    Case XMDtsMixkit.Tipo_Arquivo.Produtos
            '        Dim dts As New XMDtsMixkit.DTSProdutos(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "auto.log")
            '        dts.Processar(vArquivo)
            '        dts = Nothing
            '        Response.Write(cls.GetObservacao(vArquivo))
            '    Case XMDtsMixkit.Tipo_Arquivo.Categorias
            '        Dim dts As New XMDtsMixkit.DTSCategoria(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "auto.log")
            '        dts.Processar(vArquivo)
            '        dts = Nothing
            '        Response.Write(cls.GetObservacao(vArquivo))
            '    Case XMDtsMixkit.Tipo_Arquivo.Condicao_de_pagamento
            '        Dim dts As New XMDtsMixkit.DTSCondicao(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "auto.log")
            '        dts.Processar(vArquivo)
            '        dts = Nothing
            '        Response.Write(cls.GetObservacao(vArquivo))
            '    Case XMDtsMixkit.Tipo_Arquivo.Status_dos_Pedidos
            '        Dim dts As New XMDtsMixkit.DTSPedidos(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "auto.log")
            '        dts.Processar(vArquivo)
            '        dts = Nothing
            '        Response.Write(cls.GetObservacao(vArquivo))
            '    Case XMDtsMixkit.Tipo_Arquivo.Vendedores
            '        Dim dts As New XMDtsMixkit.DTSVendedores(Me.ConnectionString, Me.IDEmpresa, cls.GetPath, "auto.log")
            '        dts.Processar(vArquivo)
            '        dts = Nothing
            '        Response.Write(cls.GetObservacao(vArquivo))
            '    Case Else
            '        If cls.AgendarArquivo(Request("File")) Then
            '            Response.Write(cls.ConfirmaArquivo(Request("File"), CInt(Request("Length"))))
            '        Else
            '            Response.Write(cls.ProcessaArquivo(Request("File"), CInt(Request("Length"))))
            '        End If
            'End Select
        Else
                Response.Write("Tamanho do arquivo inválido!")
        End If

    End Sub

End Class
