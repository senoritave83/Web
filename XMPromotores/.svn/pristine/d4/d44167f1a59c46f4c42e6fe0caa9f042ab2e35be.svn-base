Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports Classes

Partial Class reports_rptShowReport
    Inherits XMWebPage

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        verificaFila()

    End Sub

    Private Sub verificaFila()

        Dim clsRep As New clsReports()
        Dim ds As DataSet = clsRep.verificaFila(ViewState("repId"))

        If ds.Tables.Count > 0 Then
            With ds.Tables(0)
                If .Rows.Count > 0 Then
                    If .Rows(0).Item("Fila") = 0 Then
                        If .Rows(0).Item("Status") = 2 Then

                            pnlWaiting.Visible = False
                            pnlCompleted.Visible = True
                            trCancelarExecucao.Visible = False

                            Timer1.Enabled = False

                            Dim strFileURL As String = AppSettings("UrlRelatorios") & ""
                            If strFileURL = "" Then
                                strFileURL = "files/"
                            End If

                            ltFileLink.Text = "Relatório gerado<br>Solicitado em " & .Rows(0).Item("Data") & "<br>Gerado em: " & .Rows(0).Item("DataGeracao") & "<br>Link para o relatório: <a href='" & strFileURL & .Rows(0).Item("Arquivo") & ".zip' alt=''>" & .Rows(0).Item("Relatorio") & "</a>"

                        Else

                            If .Rows(0).Item("Tentativas") = 12 Then

                                clsRep.cancelarFila(ViewState("repId"))

                                pnlCompleted.Visible = False
                                pnlWaiting.Visible = False
                                pnlRelCancelado.Visible = True
                                Exit Sub

                            End If

                            ltFileLink.Text = ""
                            ltMensagem.Text = " Por favor aguarde. Seu relatório está sendo gerado."
                            ltMensagem.Text = ltMensagem.Text & "<br>Status: " & IIf(.Rows(0).Item("Mensagem") = "", "Iniciando...", .Rows(0).Item("Mensagem"))

                            If .Rows(0).Item("Tentativas") > 1 Then


                                ltMensagem.Text = ltMensagem.Text & "<br>Tentativas: " & .Rows(0).Item("Tentativas")

                            End If


                            trCancelarExecucao.Visible = True

                        End If

                    Else

                        pnlWaiting.Visible = True
                        pnlCompleted.Visible = False
                        ltFileLink.Text = ""
                        ltMensagem.Text = " Por favor aguarde. Seu relatório está sendo gerado.<br>Existe" & IIf(.Rows(0).Item("Fila") > 1, "m", "") & " " & .Rows(0).Item("Fila") & " relatório" & IIf(.Rows(0).Item("Fila") > 1, "s", "") & " na fila"
                        trCancelarExecucao.Visible = True

                    End If
                End If
            End With
        End If

        clsRep = Nothing

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ViewState("repId") = Request("repId")

            verificaFila()

        End If

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Dim clsRep As New clsReports()
        clsRep.cancelarFila(ViewState("repId"))

        pnlCompleted.Visible = False
        pnlWaiting.Visible = False
        pnlRelCancelado.Visible = True

    End Sub

End Class
