
Imports Classes

Namespace Pages.Roteiros

    Partial Public Class VendedorRoteiros
        Inherits XMWebPage
        Dim cls As clsVendedor
        Protected Const VW_IDVENDEDOR As String = "IDVendedor"
        Protected Const SECAO As String = "Cadastro de Roteiros"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVendedor()
            If Not Page.IsPostBack Then
                'COMBOS
                ViewState(VW_IDVENDEDOR) = CInt("0" & Request(VW_IDVENDEDOR))
                cls.Load(ViewState(VW_IDVENDEDOR))
                btnAddRoteiro.Enabled = VerificaPermissao(SECAO, ACAO_ADICIONAR)
                Inflate()
            Else
                cls.Load(ViewState(VW_IDVENDEDOR))
            End If
        End Sub

        Protected Sub Inflate()

            lblVendedor.Text = cls.Vendedor

            Dim rot As New clsRoteiro
            rptRoteiros.DataSource = rot.Listar(cls.IDVendedor, DataClass.enReturnType.DataSet)
            rptRoteiros.DataBind()
            pnlRoteiros.Visible = (cls.IDVendedor > 0)
        End Sub

        Protected Function GetLojasRoteiro(ByVal vIDRoteiro As Integer) As Object
            Dim rot As New clsRoteiro
            Return rot.ListarLojas(cls.IDVendedor, vIDRoteiro)
        End Function

        Protected Sub btnAddRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRoteiro.Click
            Response.Redirect("roteiro.aspx?idvendedor=" & cls.IDVendedor)
        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            Response.Redirect("vendedores.aspx")
        End Sub

        Protected Sub rptRoteiros_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptRoteiros.ItemCommand
            Dim rot As New clsRoteiro
            If e.CommandName = "Apagar" Then
                rot.Delete(e.CommandArgument, ViewState(VW_IDVENDEDOR))
                Response.Redirect("VendedorRoteiros.aspx?idvendedor=" & ViewState(VW_IDVENDEDOR))
            End If
        End Sub
    End Class


End Namespace

