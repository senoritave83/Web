Imports Classes
Imports System.Data

Partial Class Pedidos_Pedidos_prn
    Inherits XMWebPage
    Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todos os Pedidos"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BindGrid()

    End Sub

    Public Sub BindGrid()
        Dim rpt As New clsRelatorio()
        Dim dtsPedidos As DataSet
        Try
            If VerificaPermissao(Request("Secao"), ACAO_VISUALIZAR_TODOS) Then
                dtsPedidos = rpt.GetExportarPedidos(Request("Filtro"), CInt(Request("IDVendedor")), _
                                                              Request("Cliente"), Request("Inicio"), _
                                                              Request("Fim"), CInt(Request("Status")), _
                                                              CInt(Request("Tipo")) _
                                        )
            Else
                dtsPedidos = rpt.GetExportarPedidos(Request("Filtro"), CInt(Request("IDVendedor")), _
                                                              Request("Cliente"), Request("Inicio"), _
                                                              Request("Fim"), CInt(Request("Status")), _
                                                              CInt(Request("Tipo")), User.IDUser _
                                        )
            End If

            GridView1.DataSource = dtsPedidos
            GridView1.DataBind()

            Dim TotalGeral As Double = dtsPedidos.Tables(1).Rows(0).Item("TotalGeral")
            DirectCast(GridView1.FooterRow.FindControl("lblValorTotal"), Label).Text = TotalGeral.ToString("C2")

            lblQtdRegistros.Text = "Total de Pedidos: " & CInt(Request("QtdRegistros"))
        Catch
            divBody.Visible = False
            lblError.Text = "Erro ao tentar Imprimir. <br /> Entre em contato com o Administrador do Sistema!"
        End Try
    End Sub

End Class
