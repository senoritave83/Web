Imports Classes

Partial Class Enquetes_FarolDesVendedorDet
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

            Dim strIdEnquete As String = Request("e") & ""
            'strIdEnquete = XMCrypto.Decrypt(strIdEnquete)
            If Not IsNumeric(strIdEnquete) Then strIdEnquete = 0

            Dim strIdSupervisor As String = Request("s") & ""
            'strIdSupervisor = XMCrypto.Decrypt(strIdSupervisor)
            If Not IsNumeric(strIdSupervisor) Then strIdSupervisor = 0

            Dim strIdVendedor As String = Request("v") & ""
            'strIdVendedor = XMCrypto.Decrypt(strIdVendedor)
            If Not IsNumeric(strIdVendedor) Then strIdVendedor = 0

            Dim strData As String = Request("dt") & ""
            'strData = XMCrypto.Decrypt(strData)
            If Not IsDate(strData) Then strData = ""

            ViewState("Filtro") = Request("f") & ""

            ViewState("IdEmpresa") = strIdEmpresa
            ViewState("IdEnquete") = strIdEnquete
            ViewState("IdSupervisor") = strIdSupervisor
            ViewState("IdVendedor") = strIdVendedor
            ViewState("DataColeta") = strData

            ExibeDados()

        End If

    End Sub

    Sub ExibeDados()

        rep = New clsRelatorioEnquete

        Dim dr As Data.SqlClient.SqlDataReader = rep.GetRelatorio_DadosEnquete(ViewState("IdEnquete"), ViewState("IdSupervisor"), ViewState("IdVendedor"), ViewState("DataColeta"))

        If dr.Read Then

            lblRevenda.Text = dr("Revenda") & ""
            lblSupervisor.Text = dr("Supervisor") & ""
            lblGerenteVendas.Text = dr("Gerente") & ""
            lblVendedor.Text = dr("Vendedor") & ""
            lblData.Text = FormatDateTime(ViewState("DataColeta"), DateFormat.ShortDate)

        End If

        BindGrid(ViewState("IdEmpresa"), ViewState("IdEnquete"), ViewState("IdSupervisor"), ViewState("IdVendedor"), ViewState("DataColeta"))

        rep = Nothing

    End Sub

    Private Sub BindGrid(ByVal vIdEmpresa As Integer, ByVal vIdEnquete As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vData As String)

        Dim ds As System.Data.DataSet = rep.GetRelatorio_FarolDesempenhoVendedor(vIDEmpresa, vIdEnquete, vIdSupervisor, vIdVendedor, vData)
        If ds.Tables(0).Rows.Count > 0 Then
            divResumo.Visible = True
            grdFarolDesempenhoVendedorGeral.DataSource = ds.Tables(0)
            grdFarolDesempenhoVendedorGeral.DataBind()
        Else
            divResumo.Visible = False
        End If

        With XMCrossRepeater_FarolDesempenhoVendedorGeral

            .ColDataSource = ds.Tables(1).Rows
            .RowDataSource = ds.Tables(2).Rows
            .DataSource = ds.Tables(3).Rows
            .DataKeyNames = "IDCliente,IDPergunta"
            .RowKeyNames = "IDCliente"
            .ColKeyNames = "IDPergunta"

            .DataBind()

        End With

    End Sub

    Protected Sub grdFarolDesempenhoVendedorGeral_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFarolDesempenhoVendedorGeral.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim strTexto As String = System.Web.HttpUtility.HtmlDecode(e.Row.Cells(1).Text.ToUpper).ToUpper()
            If strTexto = "SIM" Then
                e.Row.Cells(1).BackColor = System.Drawing.ColorTranslator.FromHtml("#86BD60")
            ElseIf strTexto = "NÃO" Then
                e.Row.Cells(1).BackColor = System.Drawing.ColorTranslator.FromHtml("#E8574B")
            End If

        End If

    End Sub

    Public Function fncSomarItem(ByVal vName As String, ByVal vValor As String) As Boolean

        If vValor.ToUpper() = "SIM" Then
            Soma.AddNonQuery(1, vName)
        ElseIf vValor.ToUpper() = "NÃO" Then
            Soma.AddNonQuery(0, vName)
        End If

        Return True

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

    Protected Sub btnVoltar_Click(sender As Object, e As System.EventArgs) Handles btnVoltar.Click

        Response.Redirect("faroldesvendedor.aspx?f=" & ViewState("Filtro"))

    End Sub

End Class
