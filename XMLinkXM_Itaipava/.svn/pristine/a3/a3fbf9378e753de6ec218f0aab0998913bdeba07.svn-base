
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Pedido
        Inherits XMWebPage
        Dim cls As clsPedido
        Protected Const VW_IDPEDIDO As String = "IDPedido"
        Protected Const VW_IDVISITA As String = "IDVisita"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then
                ViewState(VW_IDPEDIDO) = CStr("" & Request("IDPedido"))
                ViewState(VW_IDVISITA) = CInt(0 & Request("IDVisita"))
                cls.Load(ViewState(VW_IDPEDIDO))

                btnCancelarExportacao.Enabled = VerificaPermissao("Pedido", "Cancelar Exportação")
                btnExportar.Enabled = VerificaPermissao("Pedido", "Exportar Pedido")
                btnAprovar.Enabled = VerificaPermissao("Pedido", "Aprovar pedidos")
                btnReprovar.Enabled = VerificaPermissao("Pedido", "Reprovar pedidos")
                btnCancelarPedido.Enabled = VerificaPermissao("Pedido", "Cancelar Pedido")
                lnkCondicaoPagto.Visible = VerificaPermissao("Pedido", "Alterar Condicão de Pagto") And cls.IDStatusPedido = 3

                BindCondicaoPagto()
                Inflate()
                BindGrid()

                EstadoAprovacao = 0

            Else
                cls.Load(ViewState(VW_IDPEDIDO))

          End If
        End Sub

        Protected Sub BindCondicaoPagto()
            Dim condPagto As New clsCondicao
            cboIDCondicaoPagto.DataSource = condPagto.Listar()
            cboIDCondicaoPagto.DataBind()
            If cls.IDCondicao = 0 Then cboIDCondicaoPagto.Items.Insert(0, New ListItem("Não Definida", 0))
        End Sub

        Protected Sub Inflate()

            lblVendedor.Text = cls.Vendedor
            lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
            lblDataEmissao.Text = cls.DataEmissao
            lblDataEntrega.Text = cls.DataEntrega
            lblStatus.Text = cls.StatusPedido
            lblNumeroPedido.Text = cls.NumeroPedido
            cboIDCondicaoPagto.SelectedValue = cls.IDCondicao
            Localizacao1.Latitude = cls.Latitude
            Localizacao1.Longitude = cls.Longitude
            lblTipoPedido.Text = cls.TipoPedido
            lnkVisita.Text = cls.IDVisita
            lnkVisita.NavigateUrl = "visita.aspx?idvisita=" & cls.IDVisita

            trIDCondicao.Visible = (cls.IDTipoPedido = 1)

            grdHistorico.DataSource = cls.Historico()
            grdHistorico.DataBind()
            grdHistorico.Visible = (grdHistorico.Rows.Count > 0)

            'lblDataDevolucao.Text = cls.DataDevolucao
        End Sub

        Protected Sub BindGrid()


            Dim dr As Data.IDataReader = cls.ListItensPedido(DataClass.enReturnType.DataReader)

            grdItens.DataSource = dr
            grdItens.DataBind()

            'VERIFICA SE O PEDIDO ESTÁ EM TRANSITO E 
            'EXIBE A COLUNA DE EXCLUSÃO DE ITEM
            grdItens.Columns(6).Visible = (cls.IDStatusPedido = 3) 'EM TRANSITO

            For Each row As System.Web.UI.WebControls.GridViewRow In grdItens.Rows

                Dim imgDel As ImageButton = row.FindControl("imgRot")
                If grdItens.Rows.Count = 1 Then
                    If Not imgDel Is Nothing Then
                        imgDel.OnClientClick = "return confirm('Exclusão não permitida quando o pedido tem apenas um item. CONFIRMA CANCELAMENTO AUTOMÁTICO DO PEDIDO ?');"
                        imgDel.CommandName = "CancelarPedido"
                    End If
                Else
                    If Not imgDel Is Nothing Then
                        imgDel.OnClientClick = "return confirm('Deseja realmente excluir este item ?');"
                        imgDel.CommandName = "ExcluirItem"
                    End If
                End If

            Next

            ltrTotal.Text = "Total: <b>R$ " & FormatNumber(cls.Total, 2) & "</b>"


        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            If ViewState(VW_IDVISITA) = 0 Then
                Response.Redirect("pedidos.aspx")
            Else
                Response.Redirect("visita.aspx?idvisita=" & ViewState(VW_IDVISITA))
            End If
        End Sub


        Protected Property EstadoAprovacao() As Byte
            Get
                Return CByte("0" & ViewState("EstadoAprovacao"))
            End Get
            Set(ByVal value As Byte)
                btnCancelarExportacao.Visible = False
                btnExportar.Visible = False
                btnCancelarPedido.Visible = False
                If value = 0 Then
                    btnConfirmar.Visible = False
                    btnCancelar.Visible = False
                    btnVoltar.Visible = True
                    lblEntrarMotivo.Visible = False
                    txtMotivo.Visible = False
                    If cls.IDStatusPedido = 3 Then
                        btnAprovar.Visible = True
                        btnReprovar.Visible = True
                    ElseIf cls.IDStatusPedido = 1 Then
                        btnCancelarExportacao.Visible = cls.Exportado
                        btnExportar.Visible = Not btnCancelarExportacao.Visible
                        btnCancelarPedido.Visible = Not btnCancelarExportacao.Visible
                        btnAprovar.Visible = False
                        btnReprovar.Visible = False
                    Else
                        btnAprovar.Visible = False
                        btnReprovar.Visible = False
                    End If
                ElseIf value = 1 Then
                    btnVoltar.Visible = False
                    btnConfirmar.Visible = True
                    txtMotivo.Visible = False
                    lblEntrarMotivo.Visible = False
                    btnAprovar.Visible = False
                    btnReprovar.Visible = False
                    btnCancelar.Visible = True
                ElseIf value = 2 Then
                    btnVoltar.Visible = False
                    lblEntrarMotivo.Visible = True
                    btnConfirmar.Visible = True
                    txtMotivo.Visible = True
                    btnAprovar.Visible = False
                    btnReprovar.Visible = False
                    btnCancelar.Visible = True
                End If
                ViewState("EstadoAprovacao") = value
            End Set
        End Property

        Protected Sub btnAprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprovar.Click
            EstadoAprovacao = 1
        End Sub

        Protected Sub btnReprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprovar.Click
            EstadoAprovacao = 2
        End Sub

        Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
            If EstadoAprovacao = 1 Then
                cls.AprovarPedido()
            ElseIf EstadoAprovacao = 2 Then
                If txtMotivo.Text = "" Then Exit Sub
                cls.ReprovarPedido(txtMotivo.Text)
            End If
            Response.Redirect("pedido.aspx?idpedido=" & ViewState(VW_IDPEDIDO) & "&idvisita=" & ViewState(VW_IDVISITA))
            EstadoAprovacao = 0
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            EstadoAprovacao = 0
        End Sub


        Protected Sub btnCancelarExportacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarExportacao.Click
            cls.CancelarExportacao()
            Response.Redirect("pedido.aspx?idpedido=" & ViewState(VW_IDPEDIDO) & "&idvisita=" & ViewState(VW_IDVISITA))
        End Sub

        Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
            cls.ExportarPedido()
            Response.Redirect("pedido.aspx?idpedido=" & ViewState(VW_IDPEDIDO) & "&idvisita=" & ViewState(VW_IDVISITA))
        End Sub

        Protected Sub btnCancelarPedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarPedido.Click
            cls.CancelarPedido()
            Response.Redirect("pedido.aspx?idpedido=" & ViewState(VW_IDPEDIDO) & "&idvisita=" & ViewState(VW_IDVISITA))
        End Sub

        Protected Sub grdItens_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdItens.RowCommand

            If e.CommandName = "ExcluirItem" Then

                cls.ExcluirItem(e.CommandArgument)
                Response.Redirect("pedido.aspx?idpedido=" & ViewState(VW_IDPEDIDO) & "&idvisita=" & ViewState(VW_IDVISITA))

            ElseIf e.CommandName = "CancelarPedido" Then

                cls.CancelarPedido()
                Response.Redirect("pedido.aspx?idpedido=" & ViewState(VW_IDPEDIDO) & "&idvisita=" & ViewState(VW_IDVISITA))

            End If

        End Sub

        Protected Sub btnGravarCondicao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravarCondicao.Click
            If VerificaPermissao("Pedido", "Alterar Condicão de Pagto") And cls.IDStatusPedido = 3 Then
                cls.GravarCondicaoPagto(cboIDCondicaoPagto.SelectedValue)
                cls.Load(ViewState(VW_IDPEDIDO))
                Inflate()
            End If
            btnVoltarCondicao_Click(sender, e)
        End Sub

        Protected Sub lnkCondicaoPagto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCondicaoPagto.Click
            lnkCondicaoPagto.Visible = False
            cboIDCondicaoPagto.Enabled = True
            btnGravarCondicao.Visible = True
            btnVoltarCondicao.Visible = True
        End Sub

        Protected Sub btnVoltarCondicao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltarCondicao.Click
            lnkCondicaoPagto.Visible = True
            cboIDCondicaoPagto.Enabled = False
            btnGravarCondicao.Visible = False
            btnVoltarCondicao.Visible = False
        End Sub

        Protected Sub grdItens_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdItens.RowDataBound

            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.DataItem("PodeApagar") = 1 And cls.IDStatusPedido = 3 Then
                    Dim imgDel As ImageButton = e.Row.FindControl("imgRot")
                    If Not imgDel Is Nothing Then
                        imgDel.Visible = True
                    End If
                End If
            End If

        End Sub
    End Class

End Namespace

