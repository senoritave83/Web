Imports Classes
Imports System.Data

Partial Class Pesquisas_RelatorioAcompanhamentoPesquisas
    Inherits XMWebPage

    Protected Soma As New Somarizador
    Protected clsPesquisa As clsPesquisa
    Protected Const VW_IDPESQUISA As String = "IDPESQUISA"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            Filtro1.DataInicial = Now().AddDays(-3).ToString("dd/MM/yyyy")
            Filtro1.DataFinal = Now().ToString("dd/MM/yyyy")

            Dim vIDPesquisa As Integer = 0

            Integer.TryParse(Request("IDPesquisa"), vIDPesquisa)
            ViewState(VW_IDPESQUISA) = vIDPesquisa

            showData(Filtro1.IDEmpresa, Filtro1.IDPesquisa)

        End If
        
    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDPesquisa)

    End Sub

    Public Function FormataPorcentagem(ByVal vRealizados As Integer, ByVal vJustificados As Integer, ByVal vTotal As Integer) As String
        Dim strReturn As String = "0%"
        If vTotal > 0 Then
            strReturn = FormatPercent((vRealizados + vJustificados) / vTotal, 2)
        End If
        Return strReturn
    End Function

    Public Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdPesquisa As Integer)

        clsPesquisa = New clsPesquisa

        Dim clsEmp As New clsEmpresa

        Dim rep As New clsRelatorioPesquisa
        Dim ds As DataSet = rep.GetAcompanhamentoPesquisa(vIdEmpresa, vIdPesquisa)
        rep = Nothing

        With grdPerformancePesquisa

            'Dim i As Integer = 0
            'For i = .Columns.Count - 1 To 6
            '    Try
            '        .Columns.RemoveAt(i)
            '    Catch ex As Exception
            '        'A COLUNA NAO EXISTE
            '    End Try

            'Next

            For Each col As DataColumn In ds.Tables(0).Columns

                If Left(col.ColumnName, 1) = "_" Then

                    Dim strHeaderName As String = ""
                    strHeaderName = col.ColumnName.Substring(1)

                    Dim bfield As BoundField = New BoundField()
                    'bfield.ItemStyle.BackColor = Drawing.Color.LightCyan

                    bfield.HeaderStyle.ForeColor = Drawing.Color.IndianRed
                    bfield.HeaderStyle.BorderWidth = 1
                    bfield.HeaderStyle.Wrap = True
                    bfield.HeaderStyle.Width = 100

                    bfield.ItemStyle.BorderStyle = BorderStyle.Solid
                    bfield.ItemStyle.BorderColor = Drawing.Color.Gainsboro
                    bfield.ItemStyle.BorderWidth = 1

                    bfield.HeaderText = strHeaderName
                    bfield.DataField = col.ColumnName
                    bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    .Columns.Add(bfield)

                End If

            Next

            .DataSource = ds
            .DataBind()

        End With

        clsPesquisa = Nothing

    End Sub

End Class


