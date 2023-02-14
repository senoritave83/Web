
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Visita
        Inherits XMWebPage
        Dim cls As clsVisita
        Protected Const VW_IDVISITA As String = "IDVISITA"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            If Not Page.IsPostBack Then
                ViewState(VW_IDVISITA) = CStr("" & Request("IDVisita"))
                cls.Load(ViewState(VW_IDVISITA))

                Inflate()
                BindGrid()
            Else
                cls.Load(ViewState(VW_IDVISITA))
            End If
        End Sub


        Protected Sub Inflate()

            lblVendedor.Text = cls.Vendedor
            lblCliente.Text = cls.Cliente
            lblData.Text = cls.Data
            lblInicio.Text = cls.Inicio
            lblTermino.Text = cls.Termino
            lblStatus.Text = IIf(cls.IDJustificativa > 0, "Justificada", "Realizada")
            trJustificativa.Visible = (cls.IDJustificativa > 0)
            lblJustificativa.Text = cls.Justificativa
            Localizacao1.Latitude = cls.LatitudeInicio
            Localizacao1.Longitude = cls.LongitudeInicio
            Localizacao2.Latitude = cls.LatitudeFinal
            Localizacao2.Longitude = cls.LongitudeFinal
        End Sub



        Protected Sub BindGrid()
            Dim ped As New clsPedido
            grdPedidos.DataSource = ped.Listar(cls.IDVisita, DataClass.enReturnType.DataReader)
            grdPedidos.DataBind()
            plhPedidos.Visible = grdPedidos.Rows.Count > 0
        End Sub

    End Class

End Namespace

