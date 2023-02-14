Imports XMSistemas.Web.Base

Partial Class configuracoes_responsaveis
    Inherits XMProtectedPage

    Protected Const PageSize As Integer = 15

    Protected cls As clsResponsaveis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsResponsaveis
        If Not Page.IsPostBack Then
            If Request("Desc") Is Nothing Then
                ViewState("Desc") = 0
            Else
                ViewState("Desc") = IIf(Request("Desc") = 0, 1, 0)
            End If

            ViewState("Sort") = Request("Sort")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))
            'ViewState("Type") = Request("type")

            fn_CarregaResponsavel()

        End If

        BindGrid()

    End Sub

    Public Sub BindGrid()

        Dim ret As IPaginaResult = Nothing

        ret = cls.ListarResponsaveis(ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"))

        Dim clsRps As New clsResponsaveis
        rptResponsaveis.DataSource = ret.Tables(0)
        rptResponsaveis.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
    End Sub


    Private Sub fn_CarregaResponsavel()
        ''Carrega totais
        Dim oDr As IDataReader = cls.ContarResponsaveis()
        lblAtivo.Text = "0"
        lblPendente.Text = "0"
        lblBloqueado.Text = "0"
        Try

            While oDr.Read()
                If oDr.Item("Ativo").ToString() = "1" Then
                    lblAtivo.Text = oDr("Total").ToString()
                ElseIf oDr.Item("Ativo").ToString() = "2" Then
                    lblPendente.Text = oDr("Total").ToString()
                ElseIf oDr.Item("Ativo").ToString() = "3" Then
                    lblBloqueado.Text = oDr("Total").ToString()
                ElseIf oDr.Item("Ativo").ToString() = "4" Then
                    lblSemServico.Text = oDr("Total").ToString()
                End If
            End While

        Finally
            oDr.Close()
            oDr = Nothing
        End Try

        BindGrid()

    End Sub


    'Protected Sub rptResponsaveis_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptResponsaveis.ItemDataBound

    'End Sub


    'private void rptResponsaveis_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    '{

    '	Repeater oRptSistemas =  new Repeater();
    '	oResponsavel = new NXTNol.clsResponsavel();
    '	HyperLink lnkResponsavel = (HyperLink) e.Item.FindControl("lnkResponsavel");

    '	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    '	{
    '		System.Data.Common.DbDataRecord oRowView = (System.Data.Common.DbDataRecord) e.Item.DataItem;

    '		oRptSistemas = (Repeater) e.Item.FindControl("rptSistemas");
    '		oRptSistemas.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptSistemas_ItemDataBound);
    '		oRptSistemas.DataSource = oResponsavel.fn_PNOL_SEL_RESPONSAVEL_GRUPO(ConfigurationSettings.AppSettings["NOLID"], (Int32) oRowView.GetValue(oRowView.GetOrdinal("rsp_Responsavel_int_PK")), intUsuario, intEmpresa, 0,0);
    '		oRptSistemas.DataBind();			

    '		lnkResponsavel.NavigateUrl = "w_nxt_responsaveis_det_br.aspx?strChave=" + txtChave.Text + "&strUsuario=" + txtUsuario.Text  + "&intCodigo=" + txtCodigo.Text + "&strTipo=" + txtTipo.Text + "&strNOLU=" + txtNOLU.Text + "&strNOLP=" + txtNOLP.Text + "&strNOLK=" + txtNOLK.Text + "&cdResponsavel=" + oRowView.GetValue(oRowView.GetOrdinal("rsp_Responsavel_int_PK")).ToString();
    '	}
    '}

    'private void rptSistemas_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    '{
    '	Repeater oRptGrupos =  new Repeater();
    '	oResponsavel = new NXTNol.clsResponsavel();
    '	SqlDataReader oReader;
    '	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    '	{
    '		System.Data.Common.DbDataRecord oRowView = (System.Data.Common.DbDataRecord) e.Item.DataItem;

    '		oRptGrupos = (Repeater) e.Item.FindControl("rptGrupos");
    '		oReader= oResponsavel.fn_PNOL_SEL_RESPONSAVEL_GRUPO(ConfigurationSettings.AppSettings["NOLID"], (Int32) oRowView.GetValue(oRowView.GetOrdinal("rsp_Responsavel_int_PK")), intUsuario, intEmpresa, (Int32) oRowView.GetValue(oRowView.GetOrdinal("id_system")),0);
    '		oRptGrupos.DataSource = oReader;
    '		oRptGrupos.DataBind();			
    '	}
    '}


    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionar.Click
        Response.Redirect("responsavel_det.aspx")
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        '	oResponsavel = new NXTNol.clsResponsavel();
        If Not String.IsNullOrEmpty(Request("chkResponsavel")) Then

            Dim sep As String = ","
            Dim arrResponsavel As Array

            arrResponsavel = Request("chkResponsavel").Split(sep)

            For i As Integer = 0 To arrResponsavel.Length - 1
                cls.Delete(arrResponsavel(i).ToString)
            Next

            Response.Redirect("responsaveis.aspx")
        End If
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub

End Class
