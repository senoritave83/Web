Imports System.Data.SqlClient

Public Class distribuidoresDet
    Inherits XMProtectedPage
    Protected cls As clsDistribuidor
    Protected intIDistribuidor As Integer
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPontos As System.Web.UI.WebControls.Label
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtFator As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMeta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDesconto As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboAtivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDistribuidorCliente As ComboBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected WithEvents valReqTel As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valRegTel As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lstClientes As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
    Protected WithEvents valNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents pnlSenha As System.Web.UI.WebControls.Panel
    Protected WithEvents chkTodosClientes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAcessoWeb As System.Web.UI.WebControls.CheckBox
    Protected WithEvents tblRoteiro As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lnkRoteiro As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lnkRoteiro2 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lnkNext As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tblPaginacao As HtmlTable
    Protected WithEvents btnCadastrarRoteiro As Button
    Protected clsDis As clsDistribuidor


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
        'Put user code to initialize the page here

        cls = New clsDistribuidor(Me)
        If Not Page.IsPostBack Then
            intIDistribuidor = CLng("0" & Request("IDistribuidor"))
            Dim cbi As ListItem

            cbi = New ListItem("Inativo", clsDistribuidor.STATUS_DISTRIBUIDOR.INATIVO)
            cboAtivo.Items.Add(cbi)
            cbi = New ListItem("Ativo", clsDistribuidor.STATUS_DISTRIBUIDOR.ATIVO, True)
            cboAtivo.Items.Add(cbi)
            cbi = New ListItem("Pendente", clsDistribuidor.STATUS_DISTRIBUIDOR.PENDENTE)
            cboAtivo.Items.Add(cbi)
            cbi = New ListItem("Bloqueado", clsDistribuidor.STATUS_DISTRIBUIDOR.BLOQUEADO)
            cboAtivo.Items.Add(cbi)

            ViewState("IDistribuidor") = intIDistribuidor
            cls.Load(intIDistribuidor)

            Dim cliDistribuidor As New clsDistribuidor(Me)
            cboDistribuidorCliente.DataSource = cliDistribuidor.ListarClientes
            cboDistribuidorCliente.DataBind()
            cliDistribuidor = Nothing

            Inflate()

        Else
            intIDistribuidor = CLng("0" & ViewState("IDistribuidor"))
            cls.Load(intIDistribuidor)
        End If
        BindGrid()

    End Sub


    Protected Sub Inflate()
        With cls
            TxtMeta.Text = FormatNumber(.MetaAnual, 2)
            TxtFator.Text = .FatorTabela
            txtDesconto.Text = .Desconto
            lblPontos.Text = .Pontos
            txtEmail.Text = .Email
            txtObservacao.Text = .Observacao
            txtLogin.Text = .Login
            txtSenha.Text = .Senha
            cboAtivo.SelectedValue = .Status
            cboDistribuidorCliente.Value = .IDCliente

        End With
        If intIDistribuidor = 0 Then
            pnlSenha.Visible = True
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Distribuidores", "Alterar Distribuidor"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            pnlSenha.Visible = IIf(CheckPermission("Cadastro de Distribuidores", "Editar Senha"), True, False)
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Distribuidores", "Adicionar Distribuidor"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Distribuidores", "Apagar Distribuidor"), BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Distribuidores", "Alterar Distribuidor"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .FatorTabela = TxtFator.Text
            .MetaAnual = TxtMeta.Text
            .Desconto = txtDesconto.Text
            .Pontos = lblPontos.Text
            .Email = txtEmail.Text
            .Login = txtLogin.Text
            .Senha = txtSenha.Text
            .Status = cboAtivo.SelectedValue
            .Observacao = txtObservacao.Text
            .IDCliente = cboDistribuidorCliente.Value
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("distribuidores.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar

        If intIDistribuidor = 0 And CheckPermission("Cadastro de Distribuidores", "Adicionar Distribuidor") = False Then
            ShowMsg("Permiss�o Negada")
            Exit Sub
        End If

        If intIDistribuidor > 0 And CheckPermission("Cadastro de Distribuidores", "Alterar Distribuidor") = False Then
            ShowMsg("Permiss�o Negada")
            Exit Sub
        End If

        If cls.Existe(intIDistribuidor, cboDistribuidorCliente.Value) Then
            ShowMsg("O Distribuidor j� existe! Por favor verifique com o Administrador.")
            Exit Sub
        End If

        Deflate()
        cls.Update()
        MostraGravado("Distribuidoresdet.aspx?IDistribuidor=" & cls.IDDistribuidor)

    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Distribuidoresdet.aspx?IDistribuidor=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Distribuidores.aspx")
    End Sub

    Public Sub BindGrid()
        Dim ds As DataSet
        clsDis = New clsDistribuidor(Me)
        ds = clsDis.Listar(ViewState("IDistribuidor"), ViewState("Sort") & "", ViewState("Desc"), ViewState("CurrentPage"), PageSize)
        If ds.Tables.Count < 0 Then
            tblPaginacao.Visible = False
        Else
            Dim intMaxPages As Integer = ds.Tables(1).Rows(0).Item(0) \ PageSize
            If ViewState("CurrentPage") > intMaxPages Then
                ViewState("CurrentPage") = intMaxPages
            End If

        End If

    End Sub

    Public Sub DataGrid_Command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If
        BindGrid()
    End Sub

    Private Sub lnkRoteiro_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRoteiro.ServerClick
        tblRoteiro.Visible = True
        BindGrid()
    End Sub

    Private Sub lnkRoteiro2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRoteiro2.ServerClick
        tblRoteiro.Visible = True
        BindGrid()
    End Sub

    Private Sub btnCadastrarRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCadastrarRoteiro.Click
        Response.Redirect("RoteiroCli.aspx?IDistribuidor=" & ViewState("IDistribuidor"))
    End Sub

End Class