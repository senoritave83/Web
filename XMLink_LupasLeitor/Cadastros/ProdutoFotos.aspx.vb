Imports System.Web.Services


Imports Classes

Partial Class Cadastros_ProdutoFotos
    Inherits XMWebPage

    Dim cls As clsProdutoFoto
    Protected Const VW_IDPRODUTO As String = "IDProduto"



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cls = New clsProdutoFoto()
        If Not Page.IsPostBack Then
            'subAddConfirm(btnApagar, "Deseja realmente apagar esta produtofoto?")
            ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
            'cls.Load(ViewState(VW_IDPRODUTOFOTO), ViewState(VW_IDPRODUTO))

            btnSubir.Enabled = IIf(cls.IsNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
            'btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
            'btnApagar.Enabled = iif(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

            Inflate()
            BindFotos()
        Else
            'cls.Load(ViewState(VW_IDPRODUTOFOTO), ViewState(VW_IDPRODUTO))
        End If
    End Sub

    Protected Sub BindFotos()
        rptFotos.DataSource = cls.Listar(ViewState(VW_IDPRODUTO))
        rptFotos.DataBind()
    End Sub


    Protected Sub Inflate()
        Dim prd As New clsProduto
        prd.Load(ViewState(VW_IDPRODUTO))
        lblCodigo.Text = prd.Codigo
        lblDescricao.Text = prd.Descricao
    End Sub

    Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        If filUpload.HasFile Then
            Dim filename As Guid = Guid.NewGuid
            Dim extension As String = filUpload.FileName.Substring(filUpload.FileName.LastIndexOf(".") + 1)

            Dim xm As New XMSistemas.XMVirtualFile.XMFileStream("~/imagens/produtos/" & filename.ToString & "." & extension, IO.FileMode.CreateNew)
            xm.Write(filUpload.PostedFile.InputStream)
            xm.Close()

            cls.NovaFoto(ViewState(VW_IDPRODUTO), filename, extension, "")

            BindFotos()
        End If
    End Sub

    Protected Sub Checked_Change(ByVal source As Object, ByVal e As EventArgs)
        Dim di As DataListItem = CType(source, RadioButton).Parent
        Dim idfoto As New Guid(rptFotos.DataKeys(di.ItemIndex).ToString())
        cls.Load(idfoto, ViewState(VW_IDPRODUTO))
        cls.Capa = True
        cls.Update()
        BindFotos()

    End Sub


    Protected Sub rptFotos_ItemCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles rptFotos.ItemCommand
        If e.CommandName = "Apagar" Then
            cls.Delete(New Guid(e.CommandArgument.ToString()), ViewState(VW_IDPRODUTO))
        ElseIf e.CommandName = "Gravar" Then
            cls.Load(New Guid(e.CommandArgument.ToString()), ViewState(VW_IDPRODUTO))
            cls.Comentario = CType(e.Item.FindControl("txtComentario"), TextBox).Text
            cls.Update()
        End If
        BindFotos()

    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("Produto.aspx?idproduto=" & ViewState(VW_IDPRODUTO))
    End Sub
End Class
