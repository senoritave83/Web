
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Promotor_Roteiro
        Inherits XMWebPage
        Dim cls As clsPromotor
        Protected Const VW_IDPROMOTOR As String = "IDPromotor"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPromotor()
            If Not Page.IsPostBack Then
                'COMBOS
                ViewState(VW_IDPROMOTOR) = CInt("0" & Request("IDPromotor"))
                cls.Load(ViewState(VW_IDPROMOTOR))
                ViewState("IDSTATUSPROMOTOR") = cls.IdStatus
                'btnAddRoteiro.Enabled = VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                Inflate()
            Else
                cls.Load(ViewState(VW_IDPROMOTOR))
            End If
            'btnAddRoteiro.Enabled = IIf(ViewState("IDSTATUSPROMOTOR") = 0, False, True)
        End Sub

        Protected Sub Inflate()

            lblPromotor.Text = cls.Promotor
            Me.PageName = cls.Promotor

            Dim rot As New clsRoteiro
            rptRoteiros.DataSource = rot.Listar(cls.IDPromotor, rotFiltro.Dia, rotFiltro.Mes, rotFiltro.DiaSemana, rotFiltro.SemanaMes, txtFiltro.Text, DataClass.enReturnType.DataSet)
            rptRoteiros.DataBind()
            pnlRoteiros.Visible = (cls.IDPromotor > 0)
        End Sub

        Protected Function GetLojasRoteiro(ByVal vIDRoteiro As Integer) As Object
            Dim rot As New clsRoteiro
            Return rot.ListarLojas(cls.IDPromotor, vIDRoteiro)
        End Function

        'Protected Sub btnAddRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRoteiro.Click
        '    Response.Redirect("roteiro.aspx?idpromotor=" & cls.IDPromotor)
        'End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            Response.Redirect("promotores.aspx")
        End Sub

        Protected Sub rptRoteiros_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptRoteiros.ItemCommand
            Dim rot As New clsRoteiro
            If e.CommandName = "Apagar" Then
                rot.Delete(e.CommandArgument, ViewState(VW_IDPROMOTOR))
                Response.Redirect("promotor_roteiro.aspx?idpromotor=" & ViewState(VW_IDPROMOTOR))
            End If
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Inflate()
        End Sub
    End Class


End Namespace

