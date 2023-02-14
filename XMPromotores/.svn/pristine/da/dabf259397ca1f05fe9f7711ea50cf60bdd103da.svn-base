
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Promotor_Roteiro
        Inherits XMWebPage
        Dim cls As clsUsuario
        Protected Const VW_IDPROMOTOR As String = "IDPromotor"
        Protected Const VW_PAGEBACK As String = "PAGEBACK"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsUsuario()
            If Not Page.IsPostBack Then

                ViewState(VW_PAGEBACK) = Request.ServerVariables.Item("HTTP_REFERER")

                'COMBOS
                ViewState(VW_IDPROMOTOR) = CInt("0" & Request("IDPromotor"))
                cls.Load(ViewState(VW_IDPROMOTOR))
                ViewState("IDSTATUSPROMOTOR") = 1

                If plhLinkPeriodo.Visible Or VerificaPermissao(Secao, ACAO_ADICIONAR) = False Or ViewState("IDSTATUSPROMOTOR") = 0 Then
                    btnAddRoteiro.Enabled = False
                Else
                    btnAddRoteiro.Enabled = True
                End If

                Inflate()
            Else
                cls.Load(ViewState(VW_IDPROMOTOR))
            End If
        End Sub

        Public Function PermiteApagar() As Boolean
            Return VerificaPermissao(Secao, "Apagar Roteiro")
        End Function

        Protected Sub Inflate()

            lblPromotor.Text = cls.Usuario
            Me.PageName = cls.Usuario

            Dim rot As New clsRoteiro
            rptRoteiros.DataSource = rot.Listar(cls.IDUsuario, rotFiltro.Dia, rotFiltro.Mes, rotFiltro.DiaSemana, rotFiltro.SemanaMes, txtFiltro.Text, DataClass.enReturnType.DataSet)
            rptRoteiros.DataBind()
            pnlRoteiros.Visible = (cls.IDUsuario > 0)
        End Sub

        Protected Function GetLojasRoteiro(ByVal vIDRoteiro As Integer) As Object
            Dim rot As New clsRoteiro
            Return rot.ListarLojas(cls.IDUsuario, vIDRoteiro)
        End Function

        Protected Sub btnAddRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRoteiro.Click
            Response.Redirect("roteiro.aspx?idpromotor=" & cls.IDUsuario)
        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            'Response.Redirect(ViewState(VW_PAGEBACK))
             Response.Redirect("default.aspx")
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

