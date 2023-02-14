Imports Classes

Partial Class Enquetes_FarolDesEquipe
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Dim rep As clsRelatorioEnquete

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim strIdEmpresa As String = Request("ie") & ""
            'strIdEmpresa = XMCrypto.Decrypt(strIdEmpresa)
            If Not IsNumeric(strIdEmpresa) Then strIdEmpresa = 0

            If strIdEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    strIdEmpresa = User.IDEmpresa
                End If
            End If

            ExibeDados()

        End If

    End Sub

    Sub ExibeDados()

        rep = New clsRelatorioEnquete

        BindGrid(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal)

        rep = Nothing

    End Sub

    Private Sub BindGrid(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicio As String, ByVal vDataFinal As String)

        Dim ds As System.Data.DataSet = rep.GetRelatorio_FarolDesempenhoEquipe(vIdEmpresa, vIdGerente, vIdSupervisor, vIdVendedor, vDataInicio, vDataFinal)

        Try

            With XMCrossRepeater_FarolDesempenhoVendedorGeral

                .ColDataSource = ds.Tables(0).Rows
                .RowDataSource = ds.Tables(1).Rows
                .DataSource = ds.Tables(2).Rows
                .DataKeyNames = "IdSupervisor_Vendedor,IDPergunta"
                .RowKeyNames = "IdSupervisor_Vendedor"
                .ColKeyNames = "IDPergunta"

                .DataBind()

            End With

        Catch ex As Exception

            Dim strMessage As String = ex.Message

        End Try
        

    End Sub

    Public Function fncSomarItem(ByVal vName As String, ByVal vValor As String) As Boolean

        If vValor.ToUpper() = "SIM" Then
            Soma.AddNonQuery(1, vName)
        ElseIf vValor.ToUpper() = "NÃO" Then
            Soma.AddNonQuery(0, vName)
        End If

        Return True

    End Function

    Public Function fncVerificaPorcentagemQuant(ByVal vValor As String, ByVal vQuant As String) As Double

        Dim dblReturn As Double = -1
        If IsNumeric(vValor) And IsNumeric(vQuant) Then
            dblReturn = vValor / vQuant
        End If

        Return dblReturn

    End Function

    Public Function fncVerificaPorcentagem(ByVal vName As String) As Double

        Dim dblCount As Double = 0
        Dim dblSoma As Double = 0
        Dim dblReturn As Double = -1

        If Soma.Item(vName).Count > 0 Then
            dblCount = Soma.Item(vName).Count + 1
            dblSoma = Soma.Item(vName).Sum
            'A CONTA É DIVIDA POR 2 PQ O SUMARIZADOR PASSA DUAS VEZES A CADA LINHA
            dblReturn = (dblSoma / dblCount)
        End If

        Return dblReturn

    End Function

    Public Function fncVerificaPorcentagemFooter(ByVal vName As String) As Double

        Dim dblCount As Double = 0
        Dim dblSoma As Double = 0
        Dim dblReturn As Double = -1

        If Soma.Item(vName).Count > 0 Then
            dblCount = Soma.Item(vName).Count + 1
            dblSoma = Soma.Item(vName).Sum
            'A CONTA É DIVIDA POR 2 PQ O SUMARIZADOR PASSA DUAS VEZES A CADA LINHA
            dblReturn = (dblSoma / dblCount)
        End If

        Return dblReturn

    End Function

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir
        ExibeDados()
    End Sub
End Class
