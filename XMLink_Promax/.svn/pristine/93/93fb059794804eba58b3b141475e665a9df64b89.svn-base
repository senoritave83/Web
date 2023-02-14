
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class HorarioFuncionamentos
        Inherits XMWebPage
        Dim cls As clsHorarioFuncionamento
        Protected Const SECAO As String = "Controle de Horário"
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsHorarioFuncionamento()
            If Not Page.IsPostBack Then
                btnNovo.Enabled = VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SECAO, ACAO_APAGAR)

                cboInicio.Items.Clear()
                cboFinal.Items.Clear()
                For i As Integer = 0 To 23
                    For j As Integer = 0 To 45 Step 15
                        cboInicio.Items.Add(New ListItem(i.ToString("00") & ":" & j.ToString("00"), i.ToString("00") & j.ToString("00")))
                        cboFinal.Items.Add(New ListItem(i.ToString("00") & ":" & j.ToString("00"), i.ToString("00") & j.ToString("00")))
                    Next
                Next
                cboFinal.Items.Add(New ListItem("24:00", "2400"))

                BindGrid()
            End If			
        End Sub

        Public Sub BindGrid()
            rptGrid.DataSource = cls.Listar
            rptGrid.DataBind()
        End Sub
		

        Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
            btnCancelar.Visible = True
            btnApagar.Visible = False
            btnNovo.Visible = False
            btnGravar.Visible = True
            plhAdicionar.Visible = True
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            btnCancelar.Visible = False
            btnApagar.Visible = True
            btnNovo.Visible = True
            btnGravar.Visible = False
            plhAdicionar.Visible = False
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            cls.Inserir(txtNome.Text, cboInicio.SelectedValue, cboFinal.SelectedValue)
            MostraGravado("~/Cadastros/HorarioFuncionamentos.aspx")
        End Sub

        Protected Sub btnExcluir_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)

        End Sub

        Protected Sub rptGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptGrid.ItemCommand
            cls.Delete(e.CommandArgument)
            BindGrid()
        End Sub
    End Class

End Namespace

