Imports Classes

Namespace Pages.Cadastros

    Partial Class Cadastros_CadCampo

        Inherits XMWebPage

        Dim cls As clsCampoAdicional
        Protected Const VW_IDCAMPOADICIONAL As String = "IDCampoAdicional"
        Protected Const VW_ENTIDADE As String = "Entidade"
        Protected Const VW_OPCAO As String = "OPCAO"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCampoAdicional()
            If Not Page.IsPostBack Then

                ViewState(VW_IDCAMPOADICIONAL) = CInt("0" & XMCrypto.Decrypt(Request("ic"))) 'IDCAMPOADICIONAL
                ViewState(VW_ENTIDADE) = CStr("" & XMCrypto.Decrypt(Request("e"))) 'ENTIDADE
                cls.Load(ViewState(VW_IDCAMPOADICIONAL), ViewState(VW_ENTIDADE))
                ltNome.Text = cls.Nome
                BindGrid()

            Else
                cls.Load(ViewState(VW_IDCAMPOADICIONAL), ViewState(VW_ENTIDADE))
            End If

        End Sub

#Region "Lista de opções"

        Public Sub BindGrid()
            GridView1.DataSource = cls.ListarOpcoes()
            GridView1.DataBind()
        End Sub

        Protected Sub GridView1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBinding
            GridView1.Columns(0).HeaderText = cls.Nome
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

            If e.CommandName = "Excluir" Then
                cls.ExcluirOpcao(GridView1.DataKeys(e.CommandArgument).Value)
                BindGrid()

            ElseIf e.CommandName = "Select" Then

                ViewState(VW_OPCAO) = GridView1.DataKeys(e.CommandArgument).Value
                updLista.Visible = False

            End If

        End Sub

        Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
            If txtNovo.Text <> "" Then
                cls.AdicionarOpcao(cls.Entidade, cls.IDCampoAdicional, txtNovo.Text)
                txtNovo.Text = ""
                BindGrid()
            End If
        End Sub


#End Region


    End Class

End Namespace
