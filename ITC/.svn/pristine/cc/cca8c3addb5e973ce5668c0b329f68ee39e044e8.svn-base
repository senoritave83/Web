Public Class AssociadosDet

    Inherits XMWebPage

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblAssociadosDet As HtmlTable
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtModulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdEstado As ComboBox
    Protected WithEvents cboIdRamo As ComboBox
    Protected WithEvents txtEnderecoCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplementoCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEPCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidadeCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdEstadoCobranca As ComboBox
    Protected WithEvents txtEnderecoFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplementoFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEPFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidadeFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdEstadoFaturamento As ComboBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInscricaoEstadual As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtDataAtivacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicioPlano As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFimPlano As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacoes As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblObservacoes As System.Web.UI.WebControls.Label
    Protected WithEvents cboTipoPessoa As ComboBox
    Protected WithEvents lblVendedor As Label
    Protected WithEvents cboIdStatus As ComboBox
    Protected WithEvents cboIdAtividade As ComboBox
    Protected WithEvents cboIdFormaPagamento As ComboBox
    Protected WithEvents cboIdPosicao As ComboBox
    Protected WithEvents txtNumFunc As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProdutos As Button
    Protected WithEvents txtProduto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImagemGuia As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAssinatura As Button
    Protected WithEvents label As System.Web.UI.WebControls.Label
    Protected WithEvents txtPrimeiroContrato As TextBox
    Protected WithEvents txtSkype As TextBox
    'Protected WithEvents chkAparecerNoGuia As System.Web.UI.WebControls.CheckBox

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

            Dim objAssociado As Object = DeCryptography(Page.Request("Codigo"))
            Dim m_IdAssociado As Integer
            If IsNumeric(objAssociado) Then
                m_IdAssociado = objAssociado
            Else
                m_IdAssociado = 0
            End If
            ViewState("IdAssociado") = CInt(0 & m_IdAssociado)

            With cboTipoPessoa
                .AddItem(1, "Física")
                .AddItem(2, "Jurídica")
                .Value = 2
            End With

            Dim Sta As New clsStatus
            With cboIdStatus
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Sta.ListStatus
                .DataTextField = "DescricaoStatus"
                .DataValueField = "IdStatus"
                .DataBind()
            End With

            Dim Est As New clsEstados
            With cboIdEstado
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Est.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With

            With cboIdEstadoCobranca
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Est.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With

            With cboIdEstadoFaturamento
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Est.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With

            Est = Nothing

            Dim Pos As New clsPosicao
            With cboIdPosicao
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Pos.ListPosicao
                .DataTextField = "DescricaoPosicao"
                .DataValueField = "IdPosicao"
                .DataBind()
            End With
            Pos = Nothing

            Dim FPagto As New clsFormaPagamento
            With cboIdFormaPagamento
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = FPagto.ListFormaPagamento
                .DataTextField = "Descricao"
                .DataValueField = "IdFormaPagamento"
                .DataBind()
            End With
            FPagto = Nothing

            Dim At As New clsRamosAtividades
            With cboIdRamo
                .AutoPostBack = True
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = At.ListRamos
                .DataTextField = "Descricaoramo"
                .DataValueField = "Idramo"
                .DataBind()
            End With
            At = Nothing

            Associados = New clsAssociados(ViewState("IdAssociado"))
            Inflate()
            BindContatos()
            BindUsuarios(ViewState("IdAssociado"))

        Else

            Associados = New clsAssociados(ViewState("IdAssociado"))

        End If


            btnProdutos.Enabled = True

        'Componentes desabilitados
        cboIdAtividade.Enabled = False
        cboIdEstado.Enabled = False
        cboIdEstadoCobranca.Enabled = False
        cboIdEstadoFaturamento.Enabled = False
        cboIdFormaPagamento.Enabled = False
        cboIdPosicao.Enabled = False
        cboIdRamo.Enabled = False
        cboIdStatus.Enabled = False
        cboTipoPessoa.Enabled = False

    End Sub

    Private Sub BindAtividades(ByVal IdRamo As Integer)
        If IdRamo > 0 Then
            Dim Ram As New clsRamosAtividades()
            With cboIdAtividade
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Ram.ListAtividades(IdRamo)
                .DataTextField = "DescricaoAtividadeRamo"
                .DataValueField = "IdAtividadeRamo"
                .DataBind()
            End With
            Ram = Nothing
        Else
            cboIdAtividade.Clear()
            cboIdAtividade.AddItem(0, "Selecione o Ramo...   ")
        End If
    End Sub

    Private Sub BindContatos()
        Dim clsContato As New clsContatoAssociados(Me)
        dtgContatos.DataSource = clsContato.List(ViewState("IdAssociado"))
        dtgContatos.DataBind()
        clsContato = Nothing
    End Sub

    Private Sub BindUsuarios(ByVal IdAssociado As Integer)
        Dim Usu As New clsUsuario
        dtgUsuarios.DataSource = Usu.ListUsuariosEmpresa(IdAssociado)
        dtgUsuarios.DataBind()
        Usu = Nothing
    End Sub

    Private Sub Inflate()

        With Associados
            lblCodigo.Text = Right("0000000" & .Codigo, 7)
            txtFantasia.Text = .Fantasia
            txtModulo.Text = .Modulo
            txtRazaoSocial.Text = .RazaoSocial
            txtEndereco.Text = .Endereco
            txtComplemento.Text = .Complemento
            txtCEP.Text = .CEP
            txtCidade.Text = .Cidade
            cboIdEstado.Value = .Estado
            txtEnderecoCobranca.Text = .EnderecoCobranca
            txtComplementoCobranca.Text = .ComplementoCobranca
            txtCEPCobranca.Text = .CEPCobranca
            txtCidadeCobranca.Text = .CidadeCobranca
            cboIdEstadoCobranca.Value = .EstadoCobranca
            txtEnderecoFaturamento.Text = .EnderecoFaturamento
            txtComplementoFaturamento.Text = .ComplementoFaturamento
            txtCEPFaturamento.Text = .CEPFaturamento
            txtCidadeFaturamento.Text = .CidadeFaturamento
            cboIdEstadoFaturamento.Value = .EstadoFaturamento
            txtImagemGuia.Text = .ImagemGuia
            'chkAparecerNoGuia.Checked = .AparecerNoGuia
            cboIdRamo.Value = .IdRamo
            BindAtividades(cboIdRamo.Value)
            cboIdAtividade.Value = .IdAtividade
            cboIdFormaPagamento.Value = .IdFormaPagto

            cboIdPosicao.Value = .IdPosicao
            cboIdStatus.Value = .IdStatus
            'cboIdVendedor.Value = .IdVendedor
            lblVendedor.Text = .Vendedor

            txtCNPJ.Text = .CNPJ
            txtInscricaoEstadual.Text = .InscricaoEstadual
            txtWebSite.Text = .WebSite
            txtEmail.Text = .EMail
            txtDataInicioPlano.Text = .InicioPlano
            txtDataFimPlano.Text = .FimPlano
            txtDataAtivacao.Text = .DataAtivacao
            txtObservacoes.Text = .Observacoes
            txtNumFunc.Text = .NumFunc
            If .Codigo > 0 Then
                cboTipoPessoa.Value = .IdPessoa
                lblObservacoes.Text = "Plano de " & .QuantidadeDiasPlano & " dias - "
                If .DiasFimPlano = 0 Then
                    lblObservacoes.Text &= "Último dia do plano"
                Else
                    If .DiasFimPlano > 0 Then
                        lblObservacoes.Text &= "Falta" & IIf(.DiasFimPlano = 1, " ", "m ") & .DiasFimPlano & " dia" & IIf(.DiasFimPlano = 1, "", "s") & " para acabar o plano."
                    Else
                        lblObservacoes.Text &= "Plano Encerrado"
                    End If
                End If
            Else
                cboTipoPessoa.Value = 2
                lblObservacoes.Text = ""
            End If
            txtProduto.Text = .Produtos
            txtPrimeiroContrato.Text = .PrimeiroContrato
            txtSkype.Text = .Skype
        End With

    End Sub


    Private Sub cboIdRamo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdRamo.SelectedIndexChanged
        BindAtividades(cboIdRamo.Value)
    End Sub

    Private Sub btnProdutos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProdutos.Click
        Response.Redirect("produtosassociados.aspx?IdAssociado=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub btnAssinatura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssinatura.Click
        Response.Redirect("associadostiposregioes.aspx?IdAssociado=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub
End Class
