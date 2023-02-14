
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Sar
        Inherits XMWebPage
        Dim cls As clsSar
        Protected Const VW_IDVISITA As String = "IDVisita"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsSar()
            If Not Page.IsPostBack Then
                ViewState(VW_IDVISITA) = CInt(0 & Request("IDVisita"))
                cls.Load(ViewState(VW_IDVISITA))
                Inflate()
            Else
                cls.Load(ViewState(VW_IDVISITA))
            End If
        End Sub


        Protected Sub Inflate()

            lblIDCliente.Text = cls.IDCliente
            lblCliente.Text = cls.Cliente
            lblEndereco.Text = cls.Endereco
            lblContato.Text = cls.Contato
            lblSAR.Text = cls.Sar
            lblVendedor.Text = cls.Vendedor
            lblVisita.Text = cls.Visita
            lblEnviado.Text = cls.Enviado

        End Sub


        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            If ViewState(VW_IDVISITA) = 0 Then
                Response.Redirect("sars.aspx")
            Else
                Response.Redirect("sars.aspx?idvisita=" & ViewState(VW_IDVISITA))
            End If
        End Sub

    End Class

End Namespace

