Imports Classes
Imports XMSistemas.Web.XMGMapControl

Partial Class Relatorios_rotalog
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Dim vIDEmpresa As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            vIDEmpresa = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            Dim vei As New clsVeiculo

            cboVeiculo.DataSource = vei.Listar(0, 0)
            cboVeiculo.DataBind()
            cboVeiculo.Items.Insert(0, New ListItem("Selecione o veículo...", 0))

            vei = Nothing

            txtData.Text = Now.ToString("dd/MM/yyyy")
            XMMapViewer1.Visible = False


        End If
    End Sub

    Private Sub BindMapa()

        Dim rep As New clsRelatorio()
        Dim ds As System.Data.DataSet = rep.GetRelatorioEntregas(Me.User.IDEmpresa, cboVeiculo.SelectedItem.Value, txtData.Text, drpPrecisao.SelectedItem.Value)

        'XMMapViewer1.DataSource = ds
        'XMMapViewer1.DataBind()
        'XMMapViewer1.Visible = True

        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                With XMMapViewer1

                    .Sequences.Clear()

                    Dim seq As XMMapViewerSequence

                    With ds.Tables(2).Rows
                        For i As Integer = 0 To .Count - 1
                            seq = New XMMapViewerSequence
                            seq.SequenceID = .Item(i).Item("SequenceID")
                            seq.IconURL = .Item(i).Item("IconURL")
                            seq.IconShadowURL = .Item(i).Item("IconShadowURL")
                            seq.ShowMarker = (.Item(i).Item("Showmarker") = 1)
                            seq.ShowLine = (.Item(i).Item("ShowLine") = 1)
                            seq.IconWidth = .Item(i).Item("IconWidth")
                            seq.IconHeight = .Item(i).Item("IconHeight")
                            seq.LineColor = System.Drawing.ColorTranslator.FromHtml(.Item(i).Item("LineColor"))
                            XMMapViewer1.Sequences.Add(seq)
                        Next

                    End With

                    'Dim intQuant As Integer = ds.Tables(0).Rows(0).Item("Quant")

                    'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                    '    seq = New XMMapViewerSequence

                    '    If i <> intQuant Then

                    '        If i = 0 Then
                    '            seq.IconURL = "http://labs.google.com/ridefinder/images/mm_20_blues.png"
                    '        ElseIf i < intQuant Then
                    '            seq.IconURL = " "
                    '        Else
                    '            seq.IconURL = "http://labs.google.com/ridefinder/images/mm_20_yellow.png"
                    '        End If

                    '        seq.ShowMarker = True
                    '        seq.SequenceID = ds.Tables(0).Rows(i).Item("Sequencia")
                    '        seq.ShowLine = False
                    '        seq.IconWidth = 20
                    '        seq.IconHeight = 20

                    '        .Sequences.Add(seq)

                    '    Else

                    '        seq.ShowMarker = False
                    '        seq.SequenceID = ds.Tables(0).Rows(i).Item("Sequencia")
                    '        seq.ShowLine = True

                    '        .Sequences.Add(seq)

                    '    End If

                    'Next

                    .DataSource = ds.Tables(0)
                    .DataBind()
                    .Visible = True

                    grdEntregas.DataSource = ds.Tables(1)
                    grdEntregas.DataBind()

                End With

            End If



        Else

            XMMapViewer1.Visible = False

        End If


        rep = Nothing

    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click

        BindMapa()

    End Sub

End Class
