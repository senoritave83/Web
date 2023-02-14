Imports System.Data.SqlClient

Public Class distribuidorpontos
    Inherits XMProtectedPage
    Protected cls As clsDistribuidor
    Protected intIDistribuidor As Integer
    Protected WithEvents btnGravar As Button

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        cls = New clsDistribuidor(Me)
        If Not Page.IsPostBack Then

            ViewState("CurrentPage") = 0
            ViewState("Desc") = True
            ViewState("Sort") = "OS"

            intIDistribuidor = CLng("0" & Request("IDistribuidor"))
            ViewState("IDistribuidor") = intIDistribuidor

            cls.Load(ViewState("IDistribuidor"))
            lblDistribuidor.Text = cls.Cliente
            BindGrid()

        Else
            intIDistribuidor = CLng("0" & ViewState("IDistribuidor"))
            cls.Load(intIDistribuidor)
        End If


    End Sub

    Private Sub BindGrid()

        Dim ds As DataSet = cls.ListarPontos
        dtgGridPontosDistribuidor.DataSource = ds.Tables(0)
        dtgGridPontosDistribuidor.DataBind()

        With ds.Tables(1).Rows(0)
            lblSaldoInicial.Text = FormatNumber(.Item("Saldo_Inicial"), 2)
            lblTotalCreditos.Text = FormatNumber(.Item("Total_Creditos"), 2)
            lblTotalDebitos.Text = FormatNumber(.Item("Total_Debitos"), 2)
            lblSaldoFinal.Text = FormatNumber(.Item("Saldo_Final"), 2)
        End With

    End Sub

    Public Sub DataGrid_Command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If

        BindGrid()

    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("distribuidoresdet.aspx?IDistribuidor=" & ViewState("IDistribuidor"))
    End Sub

    Protected Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        cls.AdicionarMovimentacaoPontos(getComboValue(drpTipoOperacao), txtValor.Text, txtMotivo.Text)
        Response.Redirect("distribuidorpontos.aspx?IDistribuidor=" & ViewState("IDistribuidor"))
    End Sub

End Class