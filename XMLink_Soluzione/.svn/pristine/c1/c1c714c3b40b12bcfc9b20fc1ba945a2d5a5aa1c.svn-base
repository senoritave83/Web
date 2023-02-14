Imports System.Data.SqlClient

Public Class clientesdet
    Inherits XMProtectedPage
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBairro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected WithEvents txtTabelaPreco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescontoMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUF As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLimite As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgVendedores As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlVendedores As System.Web.UI.WebControls.Panel
    Protected WithEvents cboVendedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAdicionar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents pnlMensagem As System.Web.UI.WebControls.Panel
    Protected WithEvents tdLocalizacao As System.Web.UI.HtmlControls.HtmlTableCell
    Protected cls As clsClientes
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents valNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLatitude As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLongitude As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgLocalizacao As ImageButton
    Protected intIDCliente As Integer

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
        cls = New clsClientes(Me)
        If Not Page.IsPostBack Then
            intIDCliente = CLng("0" & Request("IDCliente"))
            btnAdicionar.Attributes.Add("OnClick", "return fncCheckAdd();")
            Dim ven As New clsVendedor(Me)
            cboVendedor.DataSource = ven.Listar
            cboVendedor.DataBind()
            ven = Nothing
            txtCodigo.Enabled = EditCodigos
            ViewState("IDCliente") = intIDCliente
            cls.Load(intIDCliente)

            If cls.Latitude = 0 Or cls.Longitude = 0 Then
                tdLocalizacao.Visible = False
            End If

            Inflate()
            BindVendedores()
        Else
            intIDCliente = CLng("0" & ViewState("IDCliente"))
            cls.Load(intIDCliente)
        End If
    End Sub

    Protected Sub BindVendedores()
        Dim ven As New clsVendedor(Me)
        dtgVendedores.DataSource = cls.ListarVendedores
        dtgVendedores.DataBind()
        ven = Nothing
        dtgVendedores.Visible = (dtgVendedores.Items.Count > 0)
        pnlMensagem.Visible = Not dtgVendedores.Visible
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
            txtCodigo.Text = .Codigo
            txtCNPJ.Text = .CNPJ
            txtEndereco.Text = .Endereco
            txtReferencia.Text = .Referencia
            txtBairro.Text = .Bairro
            txtCidade.Text = .Cidade
            txtCep.Text = .Cep
            txtUF.Text = .UF
            txtContato.Text = .Contato
            txtTelefone.Text = .Telefone
            txtObservacao.Text = .Observacao
            txtDescontoMax.Text = .DescontoMax.ToString("#0.00")
            txtTabelaPreco.Text = .TabelaPreco.ToString("#0.00")
            txtLimite.Text = .LimiteCredito.ToString("#0.00")
            If (.Latitude = 0) Then
                txtLatitude.Text = "(não cadastrada)"
            Else
                txtLatitude.Text = .Latitude
            End If

            If (.Longitude = 0) Then
                txtLongitude.Text = "(não cadastrada)"
            Else
                txtLongitude.Text = .Longitude
            End If

        End With
        If intIDCliente = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Clientes", "Alterar Cliente"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Clientes", "Adicionar Cliente"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Clientes", "Apagar Cliente"), BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Clientes", "Alterar Cliente"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
        pnlVendedores.Visible = (intIDCliente <> 0)
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Codigo = txtCodigo.Text
            .CNPJ = txtCNPJ.Text
            .Endereco = txtEndereco.Text
            .Referencia = txtReferencia.Text
            .Bairro = txtBairro.Text
            .Cidade = txtCidade.Text
            .Cep = txtCep.Text
            .UF = txtUF.Text
            .Contato = txtContato.Text
            .Telefone = txtTelefone.Text
            .Observacao = txtObservacao.Text
            .DescontoMax = txtDescontoMax.Text
            .TabelaPreco = txtTabelaPreco.Text
            .LimiteCredito = txtLimite.Text
            If IsNumeric(txtLatitude.Text) Then
                .Latitude = txtLatitude.Text
            End If
            If IsNumeric(txtLongitude.Text) Then
                .Longitude = txtLongitude.Text
            End If
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("clientes.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDCliente = 0 And CheckPermission("Cadastro de Clientes", "Adicionar Cliente") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDCliente > 0 And CheckPermission("Cadastro de Clientes", "Alterar Cliente") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDCliente, txtCodigo.Text, txtNome.Text) Then
            ShowMsg("O Cliente já existe! Por favor verifique o código e o nome")
            Exit Sub
        End If
        If (Not IsNumeric(txtLatitude.Text)) And txtLatitude.Text <> "(não cadastrada)" Then
            ShowMsg("A coordenada de latitude não foi informada da maneira correta. As coordenadas de posicionamento devem ser informadas no formato decimal. (ex. -23,5345432)")
            Exit Sub
        End If
        If (Not IsNumeric(txtLongitude.Text)) And txtLongitude.Text <> "(não cadastrada)" Then
            ShowMsg("A coordenada de longitude não foi informada da maneira correta. As coordenadas de posicionamento devem ser informadas no formato decimal. (ex. -46,23545432)")
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
        MostraGravado("clientes.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("clientesdet.aspx?idcliente=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("clientes.aspx")
    End Sub

    Public Sub dtgVendedores_OnItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If e.CommandName = "Excluir" Then
            cls.RetirarVendedor(e.CommandArgument)
        End If
        BindVendedores()
    End Sub

    Private Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionar.Click
        Try
            cls.AcrescentarVendedor(cboVendedor.SelectedItem.Value)
        Finally
            BindVendedores()
        End Try
    End Sub


    'Private Sub imgLocalizacao_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLocalizacao.Click
    '    Response.Redirect("http://www.xmwap.com.br/xmlinkwm/mapa.aspx?lat=" & cls.Latitude & "&lon=" & cls.Longitude)
    'End Sub
End Class
