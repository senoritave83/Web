
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Mapas
        Inherits XMWebPage

        Protected cls As clsMapa
        

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMapa()
            If Not Page.IsPostBack Then

                CarregaMapa(Request("IDMapa"), CInt("0" & Request("Tipo")))

                Dim sta As New clsMapaStatus
                cboIDStatus.DataSource = sta.Listar
                cboIDStatus.DataBind()
                cboIDStatus.Items.Insert(0, New ListItem("TODOS", 0))
                sta = Nothing

                Dim ven As New clsVendedor
                cboIDSupervisor.DataSource = ven.ListarSupervisores()
                cboIDSupervisor.DataBind()
                cboIDSupervisor.Items.Insert(0, New ListItem("TODOS", 0))
                ven = Nothing

                Dim gru As New clsGrupo
                cboIdGrupo.DataSource = gru.ListarGrupos_Usuario(Me.User.IDUser, True)
                cboIdGrupo.DataBind()
                cboIdGrupo.Items.Insert(0, New ListItem("TODOS", 0))
                gru = Nothing

                setComboValue(cboIDStatus, 0)

                txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
                txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

                Me.RecuperaFiltro(Paginate1, txtCliente, txtVendedor, txtDataInicial, txtDataFinal, cboIDStatus, cboIDSupervisor, cboIdGrupo)

                BindGrid()

            End If
            btnGravar.Attributes.Add("onClick", "fncCompareValidator(true);")
            btnCancelar.Attributes.Add("onClick", "fncCompareValidator(false);")
        End Sub

        Public Sub BindGrid()

            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, txtCliente.Text, txtVendedor.Text, txtMotorista.Text, cboIDSupervisor.SelectedValue, cboIdGrupo.SelectedValue, cboIDStatus.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(Paginate1, txtCliente, txtVendedor, txtDataInicial, txtDataFinal, cboIDStatus, cboIDSupervisor, cboIdGrupo)

        End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub



        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            grdPedidos.SelectedIndex = -1
            BindGrid()
        End Sub

        'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        '    If e.Row.RowType = DataControlRowType.DataRow Then
        '        'If e.Row.DataItem.Item("Transito") = 1 Then
        '        '    e.Row.CssClass = "VisitaTransito"
        '        'End If
        '    End If

        'End Sub



        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub		

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
            grdPedidos.SelectedIndex = -1
        End Sub


#Region "Detalhes"

        Protected Sub CarregaMapa(ByVal vIDMapa As Double, ByVal vTipo As Integer)
            If cls.Load(vIDMapa, vTipo) Then
                plhDetalhes.Visible = True
                Inflate()
                BindPedidos()
            Else
                plhDetalhes.Visible = False
            End If
            ViewState("IDMapa") = vIDMapa
            ViewState("Tipo") = vTipo

        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "Select" Then
                CarregaMapa(GridView1.DataKeys(e.CommandArgument).Item(0), GridView1.DataKeys(e.CommandArgument).Item(1))
                trObservacao.Visible = False
                trConfirmacao.Visible = False
            End If
        End Sub

        Private Sub BindPedidos()
            grdPedidos.DataSource = cls.ListarPedidos()
            grdPedidos.DataBind()
            plhPedidos.Visible = grdPedidos.Rows.Count > 0
        End Sub

        Private Sub BindAlteracao()

            Dim mot As New clsMotorista
            cboIDMotorista.DataSource = mot.Listar
            cboIDMotorista.DataBind()
            cboIDMotorista.Items.Insert(0, New ListItem("Selecione..", 0))
            mot = Nothing

            Dim vei As New clsVeiculo
            cboVeiculo.DataSource = vei.Listar
            cboVeiculo.DataBind()
            cboVeiculo.Items.Insert(0, New ListItem("Selecione..", 0))
            mot = Nothing

        End Sub

        Protected Sub Inflate()
            lnkVisita.Text = cls.IDMapa
            'lnkVisita.NavigateUrl = "Visita.aspx?idvisita=" & cls.IDVisita
            lblRota.Text = cls.IDPasta
            lblVendedor.Text = cls.IDVendedor & " - " & cls.Vendedor
            lblData.Text = cls.Data
            lblStatus.Text = cls.Status
            lblMotorista.Text = cls.Motorista
            lblVeiculo.Text = cls.Placa
            LocalizacaoInicio.Latitude = cls.LatitudeInicio
            LocalizacaoInicio.Longitude = cls.LongitudeInicio
            LocalizacaoFinal.Latitude = cls.LatitudeFinal
            LocalizacaoFinal.Longitude = cls.LongitudeFinal
            lblInicio.Text = cls.Inicio
            lblTermino.Text = cls.Fim
            plhInicio.Visible = cls.IDStatus > 1
            plhFinal.Visible = cls.IDStatus > 2

            trAlterar.Visible = cls.IDStatus = 1 'Se o Status for Em Aberto, aparece o botão Alterar
            BindAlteracao()
            cboIDMotorista.SelectedValue = cls.IDMotorista
            cboVeiculo.SelectedValue = cls.Placa
            lblMotorista.Visible = True
            lblVeiculo.Visible = True
            cboIDMotorista.Visible = False
            cboVeiculo.Visible = False
            plhGravar.Visible = False
        End Sub

        Protected Sub Deflate()
            cls.Placa = cboVeiculo.SelectedValue
            cls.IDMotorista = cboIDMotorista.SelectedValue
        End Sub

        Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
            lblMotorista.Visible = False
            lblVeiculo.Visible = False
            trAlterar.Visible = False
            cboIDMotorista.Visible = True
            cboVeiculo.Visible = True
            plhGravar.Visible = True
            trObservacao.Visible = False
            trConfirmacao.Visible = False
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            CompValcboIdMotorista.Enabled = False
            CarregaMapa(ViewState("IDMapa"), ViewState("Tipo"))
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If cls.Load(ViewState("IDMapa"), ViewState("Tipo")) Then
                Deflate()

                If cls.Update() Then
                    BindGrid()
                    Inflate()
                    trConfirmacao.Visible = True
                    trObservacao.Visible = False
                Else
                    CarregaMapa(ViewState("IDMapa"), ViewState("Tipo"))
                    trObservacao.Visible = True
                    trConfirmacao.Visible = False
                End If

            End If

        End Sub

#End Region
    End Class

End Namespace

