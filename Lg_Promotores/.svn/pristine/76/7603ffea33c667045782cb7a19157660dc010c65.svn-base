Imports Classes
Imports XMSistemas.Web.XMGMapControl

Partial Class Visita_Rota_Popup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rep As New clsRelatorio()

        Try
            Dim ds As System.Data.DataSet = rep.GetRotaVisita(CInt(Request("IDEmpresa")), CInt(Request("IDVisita")), CInt(Request("TipoMapa")))

            If ds.Tables.Count > 0 Then

                If ds.Tables(0).Rows.Count > 0 Then

                    With XMMapViewer1

                        .Sequences.Clear()

                        Dim seq As XMMapViewerSequence
                        Dim intQuant As Integer = ds.Tables(0).Rows(0).Item("Quant")

                        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                            seq = New XMMapViewerSequence

                            If i < intQuant Then

                                If ds.Tables(0).Rows(i).Item("IdPosicao") = 1 Then
                                    seq.IconURL = "http://google.com/mapfiles/ms/micons/rangerstation.png"
                                ElseIf ds.Tables(0).Rows(i).Item("IdPosicao") = 2 Then
                                    seq.IconURL = "http://desenv.xmsistemas.com.br/imagens/man_icon_blue.png"
                                Else
                                    seq.IconURL = "http://labs.google.com/ridefinder/images/mm_20_red.png"
                                End If

                                seq.ShowMarker = True
                                seq.SequenceID = ds.Tables(0).Rows(i).Item("Sequencia")
                                seq.ShowLine = False

                                .Sequences.Add(seq)

                            Else

                                seq.ShowMarker = False
                                seq.SequenceID = ds.Tables(0).Rows(i).Item("Sequencia")
                                seq.ShowLine = True

                                .Sequences.Add(seq)

                            End If

                        Next

                        .DataSource = ds.Tables(0)
                        .DataBind()
                        .Visible = True

                    End With

                End If

            Else

                XMMapViewer1.Visible = False

            End If
        Catch
            XMMapViewer1.Visible = False
            lblError.Text = "Erro ao carregar o mapa.<br> Entre em contato com o administrador do sistema!"
        Finally
            rep = Nothing
        End Try

    End Sub

End Class
