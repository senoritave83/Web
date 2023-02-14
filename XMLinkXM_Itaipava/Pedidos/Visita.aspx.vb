
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Visita
        Inherits XMWebPage
		
        Dim cls As clsVisita
        Protected ped As clsPedido
        Protected Const VW_IDVISITA As String = "IDVisita"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            ped = New clsPedido()
            If Not Page.IsPostBack Then

                ViewState(VW_IDVISITA) = Cint("0" & Request("IDVisita"))
                cls.Load(ViewState(VW_IDVISITA))
				
                Inflate()

                BindInvestimentos()
                BindPedidos()

            Else
                cls.Load(ViewState(VW_IDVISITA))
          End If
        End Sub

        Private Sub BindInvestimentos()
            Dim vin As New clsVisitaInvestimento
            grdInvestimentos.DataSource = vin.Listar(cls.IDVisita)
            grdInvestimentos.DataBind()
            plhInvestimentos.Visible = grdInvestimentos.Rows.Count > 0
        End Sub

        Private Sub BindPedidos()
            grdPedidos.DataSource = ped.Listar(cls.IDVisita)
            grdPedidos.DataBind()
            'plhPedidos.Visible = grdPedidos.Rows.Count > 0
        End Sub

        Protected Sub Inflate()
            lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
            lblVendedor.Text = cls.Vendedor
            lblData.Text = cls.Data
            lblStatus.Text = cls.Status
            LocalizacaoInicio.Latitude = cls.LatitudeInicio
            LocalizacaoInicio.Longitude = cls.LongitudeInicio
            LocalizacaoFinal.Latitude = cls.LatitudeFinal
            LocalizacaoFinal.Longitude = cls.LongitudeFinal
            lblInicio.Text = cls.Inicio
            lblTermino.Text = cls.Termino
            chkVisForaRota.Checked = cls.IDVisForaRota
            trVisForaRota.Visible = chkVisForaRota.Checked

            Dim cli As New clsCliente()
            cli.Load(cls.IDCliente)
            lblEndereco.Text = cli.EnderecoCompleto
            LocalizacaoCliente.Latitude = cli.Latitude
            LocalizacaoCliente.Longitude = cli.Longitude
            cli = Nothing


        End Sub

        Protected Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.ServerClick
            Response.Redirect("visitas.aspx?idvisita=" & ViewState(VW_IDVISITA))
        End Sub
    End Class

End Namespace

