Imports Classes
Imports XMSistemas.Web.XMGMapControl

Partial Class Relatorios_rota
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

            Dim ven As New clsVendedor

            cboIDSupervisor.DataSource = ven.ListarSupervisores()
            cboIDSupervisor.DataBind()
            cboIDSupervisor.Items.Insert(0, New ListItem("TODOS", 0))

            carregaVendedor(0)

            ven = Nothing

            Dim gru As New clsGrupo
            cboIdGrupo.DataSource = gru.ListarGrupos_Usuario(Me.User.IDUser, True)
            cboIdGrupo.DataBind()
            cboIdGrupo.Items.Insert(0, New ListItem("TODOS", 0))
            gru = Nothing

            txtData.Text = Now.ToString("dd/MM/yyyy")
            XMMapViewer1.Visible = False


        End If
    End Sub

    Private Sub carregaVendedor(ByVal vIdSupervisor As Integer)

        Dim ven As New clsVendedor

        cboVendedor.Items.Clear()
        cboVendedor.DataSource = ven.ListarVendedoresSup(vIdSupervisor)
        cboVendedor.DataBind()
        cboVendedor.Items.Insert(0, New ListItem("TODOS", 0))

        ven = Nothing

    End Sub

    Private Sub BindMapa()

        Dim rep As New clsRelatorio()
        Dim ds As System.Data.DataSet = rep.GetRelatorioRota(Me.User.IDEmpresa, cboVendedor.SelectedItem.Value, txtData.Text)

        'XMMapViewer1.DataSource = ds
        'XMMapViewer1.DataBind()
        'XMMapViewer1.Visible = True

        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                With XMMapViewer1

                    .Sequences.Clear()

                    Dim seq As XMMapViewerSequence
                    Dim intQuant As Integer = ds.Tables(0).Rows(0).Item("Quant")

                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                        seq = New XMMapViewerSequence

                        If i < intQuant Then

                            If i = 0 Then
                                seq.IconURL = "http://labs.google.com/ridefinder/images/mm_20_blue.png"
                            ElseIf i < intQuant Then
                                seq.IconURL = "http://labs.google.com/ridefinder/images/mm_20_red.png"
                            Else
                                seq.IconURL = "http://labs.google.com/ridefinder/images/mm_20_yellow.png"
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
                    lblMapaVendedor.Visible = False

                End With

            Else

                If cboVendedor.SelectedItem.Value = 0 Then
                    lblMapaVendedor.Visible = True
                Else
                    lblMapaVendedor.Visible = False
                End If

            End If

            grdPedidos.DataSource = ds.Tables(1)
            grdPedidos.DataBind()

        Else

            XMMapViewer1.Visible = False

        End If


        rep = Nothing

    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click

        BindMapa()

    End Sub

    Protected Sub cboIDSupervisor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboIDSupervisor.SelectedIndexChanged

        carregaVendedor(cboIDSupervisor.SelectedItem.Value)

    End Sub
End Class
