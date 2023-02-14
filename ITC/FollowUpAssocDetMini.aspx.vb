Public Class FollowUpAssocDetMini
    Inherits XMWebPage
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblData As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpresa As System.Web.UI.WebControls.Label
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtDataAgenda As System.Web.UI.WebControls.TextBox
    Protected WithEvents BotaoAtualizar As Button
    Protected WithEvents BotaoVoltar As Button
    Protected WithEvents hdItemExcluir As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnNovoFollowup As Button
    Protected WithEvents Tudo As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Falha As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents dtlFollowUP As DataGrid
    Protected WithEvents lnkRegistros As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents divRegistros As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents cboPrioridade As ComboBox

    Private Foll As FollowUp
    Private Associados As clsAssociados

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            BotaoVoltar.Attributes.Add("onclick", "window.close();")

            Dim m_IdAssociado, m_IdIdFollowUP As Integer

            Dim objAssociado As Object = DeCryptography(Page.Request("IdAssociado"))
            If IsNumeric(objAssociado) Then
                m_IdAssociado = objAssociado
            End If
            ViewState("IdAssociado") = CInt(0 & m_IdAssociado)

            Dim objIdFollowUP As Object = DeCryptography(Page.Request("IdFollowUP"))
            If IsNumeric(objIdFollowUP) Then
                m_IdIdFollowUP = objIdFollowUP
            Else
                m_IdIdFollowUP = 0
            End If
            ViewState("IdFollowUP") = CInt(0 & m_IdIdFollowUP)

            ViewState("IDUsuario") = Usuario.IDUsuario
            ViewState("IDEmpresa") = Usuario.IdEmpresa
            ChecaPermissao()

            If m_IdIdFollowUP <> 0 Then
                BotaoAtualizar.Visible = False
                txtDataAgenda.ReadOnly = True
                txtDescricao.ReadOnly = True
            End If

            With cboPrioridade
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(0, "Selecione...")
                .AddItem(1, "Baixa")
                .AddItem(2, "Média")
                .AddItem(3, "Alta")
            End With
            ViewState("IdPrioridade") = cboPrioridade.Value

            Inflate()

        End If

    End Sub

    Private Sub BindRegistros()
        Foll = New FollowUp
        dtlFollowUP.DataSource = Foll.List(Usuario.IDUsuario, TIPO_CADASTRO.ASSOCIADO, ViewState("IdAssociado"), "", "", "", "")
        dtlFollowUP.DataBind()
        Foll = Nothing
    End Sub

    Private Sub ChecaPermissao()

        Foll = New FollowUp(ViewState("IdFollowUP"), TIPO_CADASTRO.ASSOCIADO)

        If Foll.ChecaPermissao(ViewState("IDUsuario"), TIPO_CADASTRO.ASSOCIADO, ViewState("IDEmpresa"), ViewState("IdAssociado")) Then
            Tudo.Visible = True
            Falha.Visible = False
        Else
            Tudo.Visible = False
            Falha.Visible = True
        End If

    End Sub

    Private Sub Inflate()

        Foll = New FollowUp(ViewState("IdFollowUP"), TIPO_CADASTRO.ASSOCIADO)

        Associados = New clsAssociados(ViewState("IdAssociado"))
        ViewState("Associado") = Associados.Fantasia.ToUpper()
        Associados = Nothing

        lblEmpresa.Text = ViewState("Associado")

        txtDescricao.Text = Foll.Descricao
        lblData.Text = IIf(ViewState("IdFollowUP") = 0, Format(Now(), "dd/MM/yyyy"), XMCheckDate(Foll.Data))
        txtDataAgenda.Text = XMCheckDate(Foll.DataAgenda)

        Foll = Nothing

    End Sub

    Private Sub BotaoAtualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BotaoAtualizar.Click

        Foll = New FollowUp(ViewState("IdFollowUP"), TIPO_CADASTRO.ASSOCIADO)
        With Foll
            .Descricao = txtDescricao.Text
            .IdEmpresaObra = ViewState("IdAssociado")
            .IdAssociado = Usuario.IdEmpresa
            .IdUsuario = Usuario.IDUsuario
            .Tipo = TIPO_CADASTRO.ASSOCIADO
            .DataAgenda = txtDataAgenda.Text
            .Update()
        End With
        Foll = Nothing
        Gravado("followupassocdetmini.aspx?idassociado=" & CryptographyEncoded(ViewState("IdAssociado")) & "&idfollowup=" & CryptographyEncoded(ViewState("IdFollowUP")))

    End Sub

    Private Sub btnNovoFollowup_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovoFollowup.Click

        Response.Redirect("followupassocdetmini.aspx?idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))


    End Sub

    'Private Sub Botao_Excluir()

    '    Foll = New FollowUp
    '    Foll.Excluir(hdItemExcluir.Value)
    '    Foll = Nothing
    '    Response.Redirect("followupobradet.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")))

    'End Sub

    Private Sub BotaoVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BotaoVoltar.Click
        Response.Write("<script language='javascript'>{ window.close(); }</script>")
    End Sub

    Private Sub lnkRegistros_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRegistros.ServerClick

        If divRegistros.Visible = True Then
            divRegistros.Visible = False
        Else
            BindRegistros()
            divRegistros.Visible = True
        End If

    End Sub
End Class