Imports Classes
Imports System.Data
Imports XMSistemas.Web.XMGMapControl

Partial Class Relatorios_relatorio_roteiro_det
    Inherits XMWebPage

    Private Sub BindMapa(ByVal vIDEmpresa As Integer, ByVal vIDVendedor As Integer, ByVal vData As String)

        Dim rep As New clsRelatorio()
        Dim ds As System.Data.DataSet = rep.GetRelatorioRota(vIDEmpresa, vIDVendedor, vData)

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

                    divEmpty.Visible = False
                    divErroPosicaoMapa.Visible = False

                End With

            Else

                If ds.Tables(1).Rows.Count <> 0 Then
                    divErroPosicaoMapa.Visible = True
                    divEmpty.Visible = False
                Else
                    divErroPosicaoMapa.Visible = False
                    divEmpty.Visible = True
                End If

                XMMapViewer1.Visible = False

            End If

            'grdPedidos.DataSource = ds.Tables(1)
            'grdPedidos.DataBind()

        Else

            XMMapViewer1.Visible = False
            divEmpty.Visible = True
            divErroPosicaoMapa.Visible = False

        End If

        rep = Nothing

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ViewState("Hora") = Format(Now(), "dd/MM/yyyy")

        If Request("pr") = "2" Then

            Dim blnMapa As Boolean = False
            If CStr(Request("map") & "").ToLower = "true" Then
                blnMapa = True
            End If
            showData(Request("em"), Request("ger"), Request("sup"), Request("vend"), Request("di"), blnMapa)
            Filtro1.Visible = False
            If blnMapa = True Then
                lblPeriodoData.Text = "Data Selecionada: " & Request("di") & "<br>" & "Vendedor(a) Selecionado(a): " & Request("vend") & " - " & Request("nomevend")
            Else
                lblPeriodoData.Text = "Data Selecionada: " & Request("di")
            End If

        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.MapaRoteiro)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vData As String, ByVal vMapa As Boolean)

        Dim dtsRoteiro As DataSet
        Dim rep As New clsRelatorio

        dtsRoteiro = rep.GetRelatorioRoteiro(vIdEmpresa, vIdGerente, vIdSupervisor, vIdVendedor, vData)

        If vMapa = True And Filtro1.IDVendedor = 0 Then
            Filtro1.ShowlblMapa = True
        Else
            Filtro1.ShowlblMapa = False
        End If


        If vMapa Then
            BindMapa(vIdEmpresa, vIdVendedor, vData)
        Else
            If dtsRoteiro.Tables(0).Rows.Count = 0 Then
                divEmpty.Visible = True
                XMMapViewer1.Visible = False
                divErroPosicaoMapa.Visible = False
            Else
                grdRelatorio.DataSource = dtsRoteiro
                grdRelatorio.DataBind()
                divEmpty.Visible = False
                XMMapViewer1.Visible = False
                divErroPosicaoMapa.Visible = False
            End If
        End If
        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub
    
    
End Class
