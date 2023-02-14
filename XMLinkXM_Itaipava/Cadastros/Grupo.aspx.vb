
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Grupo
        Inherits XMWebPage
		
		Protected Const SECAO as String = "Cadastro de Grupo"
        Dim cls As clsGrupo
        Protected Const VW_IDGRUPO As String = "IDGrupo"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsGrupo()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta grupo?")
                ViewState(VW_IDGRUPO) = Cint("0" & Request("IDGrupo"))
                cls.Load(ViewState(VW_IDGRUPO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDGRUPO))
          End If
        End Sub

        Protected Sub Inflate()
			txtGrupo.Text = cls.Grupo
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
            End If
            BindVendedores()
        End Sub


        Protected Sub BindVendedores()

            Dim ven As New clsVendedor
            Dim dr As System.Data.IDataReader = ven.Listar(cls.IDGrupo)
            lstVendedores.Items.Clear()
            While dr.Read
                Dim li As New ListItem(dr.GetString(dr.GetOrdinal(lstVendedores.DataTextField)), dr.GetInt32(dr.GetOrdinal(lstVendedores.DataValueField)))
                li.Selected = dr.GetInt32(dr.GetOrdinal("Selecionado"))
                lstVendedores.Items.Add(li)
            End While

        End Sub



        Protected Sub Deflate()
			cls.Grupo = txtGrupo.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Grava o vendedor e grupo
                Dim grp As New clsGrupo
                'Grava os grupos ao qual pertence
                For Each li As ListItem In lstVendedores.Items
                    grp.GravaGrupoVendedor(li.Value, cls.IDGrupo, li.Selected)
                Next

                Inflate()
                MostraGravado("~/Cadastros/Grupo.aspx?idgrupo=" & cls.idgrupo)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Grupos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

