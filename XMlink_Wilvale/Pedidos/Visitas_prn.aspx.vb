Imports Classes

Partial Class Visitas_Visitas_prn
    Inherits XMWebPage
    Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todos as Visitas"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BindGrid()

    End Sub

    Public Sub BindGrid()
        Dim rpt As New clsRelatorio()
        Try
            If VerificaPermissao(Request("Secao"), ACAO_VISUALIZAR_TODOS) Then
                GridView1.DataSource = rpt.GetExportarVisitas(Request("Filtro"), CInt(Request("IDVendedor")), _
                                                              Request("Inicio"), Request("Fim"), _
                                                              CInt(Request("Justificativa")) _
                                        )
            Else
                GridView1.DataSource = rpt.GetExportarVisitas(Request("Filtro"), CInt(Request("IDVendedor")), _
                                                              Request("Inicio"), Request("Fim"), _
                                                              CInt(Request("Justificativa")), User.IDUser _
                                        )
            End If

            GridView1.DataBind()
            lblQtdRegistros.Text = "Total de Visitas: " & CInt(Request("QtdRegistros"))
        Catch
            divBody.Visible = False
            lblError.Text = "Erro ao tentar Imprimir. <br /> Entre em contato com o Administrador do Sistema!"
        End Try
    End Sub
End Class
