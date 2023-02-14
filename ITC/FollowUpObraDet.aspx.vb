Public Class FollowUpObraDet

    Inherits XMWebPage
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblData As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpresa As System.Web.UI.WebControls.Label
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtDataAgenda As System.Web.UI.WebControls.TextBox
    'Protected WithEvents BotaoApagar As XMDefaultButton
    Protected WithEvents BotaoAtualizar As Button
    Protected WithEvents BotaoVoltar As Button
    Protected WithEvents hdItemExcluir As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnNovoFollowup As Button
    Protected WithEvents cboPrioridade As ComboBox
    Protected WithEvents cboStatusSIG As ComboBox

    Private Foll As FollowUp
    Private Obras As clsObras

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

        'BotaoApagar.Visible = False

        If Not Page.IsPostBack Then

            Dim m_IdObra, m_IdIdFollowUP As Integer

            Dim objObra As Object = DeCryptography(Page.Request("IdObra"))
            If IsNumeric(objObra) Then
                m_IdObra = objObra
            End If
            ViewState("IdObra") = CInt(0 & m_IdObra)

            Dim objIdFollowUP As Object = DeCryptography(Page.Request("IdFollowUP"))
            If IsNumeric(objIdFollowUP) Then
                m_IdIdFollowUP = objIdFollowUP
            Else
                m_IdIdFollowUP = 0
            End If
            ViewState("IdFollowUP") = CInt(0 & m_IdIdFollowUP)

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


            'Foll = New FollowUp(ViewState("IdFollowUP"), TIPO_CADASTRO.OBRA)
            'ViewState("IdStatusSIG") = Foll.IdStatusSIG

            Dim Foll As New FollowUp
            With cboStatusSIG
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(0, "Selecione...")
                .DataSource = Foll.ListStatusSIG()
                .DataTextField = "DescricaoStatusSIG"
                .DataValueField = "IdStatusSIG"
                .DataBind()
            End With

            Inflate()

        End If

    End Sub

    Private Sub Inflate()

        Foll = New FollowUp(ViewState("IdFollowUP"), TIPO_CADASTRO.OBRA)

        Obras = New clsObras(ViewState("IdObra"))
        ViewState("Obra") = Obras.Projeto.ToUpper()
        Obras = Nothing

        lblEmpresa.Text = ViewState("Obra")

        txtDescricao.Text = Foll.Descricao
        lblData.Text = IIf(ViewState("IdFollowUP") = 0, Format(Now(), "dd/MM/yyyy"), XMCheckDate(Foll.Data))
        txtDataAgenda.Text = XMCheckDate(Foll.DataAgenda)
        cboPrioridade.Value = Foll.Prioridade
        cboStatusSIG.Value = Foll.IdStatusSIG
        
        Foll = Nothing

    End Sub

    Private Sub BotaoAtualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BotaoAtualizar.Click

        Foll = New FollowUp(ViewState("IdFollowUP"), TIPO_CADASTRO.OBRA)
        With Foll
            .Descricao = txtDescricao.Text
            .IdEmpresaObra = ViewState("IdObra")
            .IdAssociado = Usuario.IdEmpresa
            .IdUsuario = Usuario.IDUsuario
            .Tipo = TIPO_CADASTRO.OBRA
            .DataAgenda = txtDataAgenda.Text
            .Prioridade = cboPrioridade.Value
            .IdStatusSIG = cboStatusSIG.Value
            .Update()
        End With
        Foll = Nothing
        Gravado("followupobralist.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")) & "&idfollowup=" & CryptographyEncoded(ViewState("IdFollowUP")))

    End Sub

    Private Sub BotaoVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BotaoVoltar.Click

        Response.Redirect("followupobralist.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")))

    End Sub

    Private Sub btnNovoFollowup_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovoFollowup.Click

        Response.Redirect("followupobradet.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")))


    End Sub

    'Private Sub Botao_Excluir()

    '    Foll = New FollowUp
    '    Foll.Excluir(hdItemExcluir.Value)
    '    Foll = Nothing
    '    Response.Redirect("followupobradet.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")))

    'End Sub

End Class
