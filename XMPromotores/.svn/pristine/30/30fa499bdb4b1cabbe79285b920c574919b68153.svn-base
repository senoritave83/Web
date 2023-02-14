Imports Classes

Partial Class Visita_pesquisa
    Inherits XMWebPage
    Protected cls As clsVisita


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        cls = New clsVisita
        If Not Page.IsPostBack Then
            ViewState("IDVISITA") = CInt("0" & Request("IDVisita"))
            ViewState("TIPOENTIDADE") = CInt("0" & Request("TipoEntidade"))
            ViewState("IDREFERENCIA") = CInt("0" & Request("IDReferencia"))
            ViewState("IDPESQUISA") = CInt("0" & Request("IDPesquisa"))

            Dim pes As New clsPesquisa
            pes.Load(ViewState("IDPESQUISA"))
            ltrTitulo.Text = pes.Pesquisa

        End If
        cls.Load(ViewState("IDVISITA"))

        If cls.IDVisita > 0 Then
            If Not Page.IsPostBack Then
                BindGrid()
                Me.Visible = True
            End If
        Else
            Me.Visible = False
        End If

    End Sub

    Protected Sub BindGrid()

        Dim ds As Data.DataSet = Nothing
        Dim ret As IPaginaResult
        ret = cls.ListarPerguntasFormulario(ViewState("TIPOENTIDADE"), ViewState("IDREFERENCIA"), ViewState("IDPESQUISA"), "", False, Paginate1.CurrentPage, 20)
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        xmProdutos.RowDataSource = ret.Tables(1).Rows
        xmProdutos.ColDataSource = ret.Tables(2).Rows
        xmProdutos.DataSource = ret.Tables(3).Rows
        xmProdutos.ColKeyNames = "IDPergunta"
        xmProdutos.RowKeyNames = "IDReferencia"
        xmProdutos.DataKeyNames = "IDPergunta,IDReferencia"
        xmProdutos.DataBind()


    End Sub


    'Protected Sub xmProdutos_ItemDataBound(ByVal sender As Object, ByVal e As XMSistemas.Web.UI.WebControls.XMCrossRepeaterItemEventArgs) Handles xmProdutos.ItemDataBound
    '    If e.Item.ItemType = XMSistemas.Web.UI.WebControls.XMCrossRepeater.CrossItemType.DataItem Then
    '        Dim ctr As control_pergunta = e.Item.FindControl("pergunta1")
    '        Dim ltr As Literal = e.Item.FindControl("ltrResposta")
    '        If Me.ReadOnly Then
    '            ltr.Text = e.Item.DataItem("Respostas")
    '            ltr.Visible = True
    '            ctr.Visible = False
    '        Else
    '            Dim prds As New clsFormVisita.clsFormProduto
    '            Dim dr As Object = Nothing

    '            If e.Item.DataItem("TipoCampo") = 0 Then
    '                dr = cls.ListarRespostasEntidade(e.Item.DataItem("TipoEntidade"), e.Item.DataItem("IDReferencia"), e.Item.DataItem("IDPergunta"), DataClass.enReturnType.DataSet)
    '            End If
    '            ctr.Mostrar(e.Item.DataItem("IDPergunta"), dr, e.Item.DataItem("Respostas"))
    '            ctr.Visible = True
    '            ltr.Visible = False
    '        End If
    '    End If
    'End Sub



End Class
