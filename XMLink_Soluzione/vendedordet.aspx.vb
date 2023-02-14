Imports System.Data.SqlClient

Public Class vendedordet
    Inherits XMProtectedPage
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected cls As clsVendedor
    Protected WithEvents valReqTel As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valRegTel As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lstGrupo As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
    Protected WithEvents valNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtDesconto As System.Web.UI.WebControls.TextBox
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlSenha As System.Web.UI.WebControls.Panel
    Protected WithEvents chkTodosClientes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAcessoWeb As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cboAtivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblRoteiro As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lnkRoteiro As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lnkRoteiro2 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents dtgGridRoteiros As DataGrid
    Protected WithEvents lnkPrevious As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkNext As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblMensagem As Label
    Protected WithEvents tblPaginacao As HtmlTable
    Protected WithEvents btnCadastrarRoteiro As Button
    Protected clsRot As clsRoteiros
    Protected intIDVendedor As Integer

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
        cls = New clsVendedor(Me)
        If Not Page.IsPostBack Then
            intIDVendedor = CLng("0" & Request("IDVendedor"))
            Dim cbi As ListItem

            cbi = New ListItem("(remover)", cls.STATUS_VENDEDOR.NENHUM)
            cboAtivo.Items.Add(cbi)
            cbi = New ListItem("Ativo", cls.STATUS_VENDEDOR.ATIVO)
            cboAtivo.Items.Add(cbi)
            cbi = New ListItem("Pendente", cls.STATUS_VENDEDOR.PENDENTE)
            cboAtivo.Items.Add(cbi)
            cbi = New ListItem("Bloqueado", cls.STATUS_VENDEDOR.BLOQUEADO)
            cboAtivo.Items.Add(cbi)

            ViewState("IDVendedor") = intIDVendedor
            cls.Load(intIDVendedor)
            CarregaGrupos()
            Inflate()

            If intIDVendedor = 0 Then
                tdCodigo.Visible = EditCodigos
                cboAtivo.SelectedValue = cls.STATUS_VENDEDOR.ATIVO
            Else
                txtCodigo.Enabled = EditCodigos
            End If

        Else
            intIDVendedor = CLng("0" & ViewState("IDVendedor"))
            cls.Load(intIDVendedor)
        End If
        BindGrid()
    End Sub

    Private Sub CarregaGrupos()
        lstGrupo.Items.Clear()
        Dim ds As DataSet
        ds = cls.ListarGrupos
        Dim i As Integer
        Dim li As ListItem
        With ds.Tables(0).Rows
            For i = 0 To .Count - 1
                li = New ListItem(.Item(i).Item("grp_Grupo_chr"), .Item(i).Item("grp_Grupo_int_PK"))
                li.Selected = .Item(i).Item("selected")
                lstGrupo.Items.Add(li)
            Next
        End With
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
            txtTelefone.Text = .Telefone
            txtObservacao.Text = .Observacao
            txtID.Text = .ID
            txtDesconto.Text = cls.DescontoMaximo
            txtCodigo.Text = cls.Codigo
            txtLogin.Text = .Login
            chkTodosClientes.Checked = .TodosClientes
            chkAcessoWeb.Checked = .AcessoWeb
            txtSenha.Text = .Senha
            cboAtivo.SelectedValue = .Status

        End With
        If intIDVendedor = 0 Then
            pnlSenha.Visible = True
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Vendedores", "Alterar Vendedor"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            pnlSenha.Visible = IIf(CheckPermission("Cadastro de Vendedores", "Editar Senha"), True, False)
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Vendedores", "Adicionar Vendedor"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Vendedores", "Apagar Vendedor"), BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Vendedores", "Alterar Vendedor"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Telefone = txtTelefone.Text
            .ID = txtID.Text
            .Codigo = txtCodigo.Text
            .DescontoMaximo = txtDesconto.Text
            .Login = txtLogin.Text
            .Senha = txtSenha.Text
            .TodosClientes = chkTodosClientes.Checked
            .AcessoWeb = chkAcessoWeb.Checked
            .Status = cboAtivo.SelectedValue
            .Grupo.Clear()
            Dim i As Integer
            For i = 0 To lstGrupo.Items.Count - 1
                If lstGrupo.Items(i).Selected Then .Grupo.Add(lstGrupo.Items(i).Value)
            Next
            .Observacao = txtObservacao.Text
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Vendedores.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDVendedor = 0 And CheckPermission("Cadastro de Vendedores", "Adicionar Vendedor") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDVendedor > 0 And CheckPermission("Cadastro de Vendedores", "Alterar Vendedor") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDVendedor, txtCodigo.Text, txtNome.Text) Then
            ShowMsg("O Vendedor já existe! Por favor verifique o código, nome, id e telefone.")
            Exit Sub
        End If
        If cls.ExisteLogin(intIDVendedor, txtLogin.Text, chkAcessoWeb.Checked) Then
            ShowMsg("O login informado já existe! Por favor digite outro login.")
            Exit Sub
        End If
        Deflate()
        Try
            cls.Update()
        Catch e As SqlException
            If e.Number = 50000 Then
                ShowError(e.Message)
                Exit Sub
            Else
                Throw e
            End If
        End Try
        MostraGravado("Vendedordet.aspx?idvendedor=" & cls.IDVendedor)
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Vendedordet.aspx?idvendedor=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Vendedores.aspx")
    End Sub

    Public Sub BindGrid()
        Dim ds As DataSet
        clsRot = New clsRoteiros(Me)
        ds = clsRot.Listar(ViewState("IDVendedor"), ViewState("Sort") & "", ViewState("Desc"), ViewState("CurrentPage"), PageSize)
        If ds.Tables.Count < 0 Then

            lblMensagem.Visible = True
            tblPaginacao.Visible = False

        Else
            lblMensagem.Visible = False
            dtgGridRoteiros.DataSource = ds.Tables(0)
            dtgGridRoteiros.DataBind()
            Dim intMaxPages As Integer = ds.Tables(1).Rows(0).Item(0) \ PageSize
            If ViewState("CurrentPage") > intMaxPages Then
                ViewState("CurrentPage") = intMaxPages
            End If
            If ViewState("CurrentPage") > 0 Then
                lnkPrevious.Enabled = True
                lnkPrevious.CommandArgument = ViewState("CurrentPage") - 1
            Else
                lnkPrevious.Enabled = False
            End If
            If ViewState("CurrentPage") < intMaxPages Then
                lnkNext.Enabled = True
                lnkNext.CommandArgument = ViewState("CurrentPage") + 1
            Else
                lnkNext.Enabled = False
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
        Response.Redirect("RoteiroCli.aspx?IDVendedor=" & ViewState("IDVendedor"))
    End Sub
End Class
