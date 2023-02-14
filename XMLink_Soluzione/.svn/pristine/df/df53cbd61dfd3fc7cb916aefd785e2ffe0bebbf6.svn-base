Public Class wapconfig
    Inherits XMProtectedPage
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents cboItensPerPage As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboBuscaProduto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboVisualizaEstoque As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboBuscaCliente As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboEntradaProduto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboVendaSEstoque As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboMostraResumo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboInformacaoCliente As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDescontoExcessivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboClienteOutroVendedoir As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDigitaPreco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDigitaDesconto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents cboFiltrarCategoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDigitaDataEntrega As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDigitaObservacao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboTotalPedidos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboLimiteCredito As System.Web.UI.WebControls.DropDownList
    Protected cls As clsSettings

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
        cls = New clsSettings(Me)
        If Not IsPostBack Then
            Inflate()
            btnSalvar.Enabled = CheckPermission("Configurações do Sistema", "Alterar configurações")
        End If
    End Sub

    Private Sub Inflate()
        With cls
            SetComboValue(cboItensPerPage, .ItemsPerPage)
            SetComboValue(cboBuscaProduto, .BuscaProduto)
            SetComboValue(cboVisualizaEstoque, .VisualizaEstoque)
            SetComboValue(cboBuscaCliente, .BuscaCliente)
            SetComboValue(cboEntradaProduto, .EntradaProduto)
            SetComboValue(cboVendaSEstoque, .VendaSEstoque)
            SetComboValue(cboMostraResumo, .MostraItensResumo)
            SetComboValue(cboInformacaoCliente, .ExibeDadosCliente)
            SetComboValue(cboDescontoExcessivo, .VendaDescontoExcedente)
            SetComboValue(cboClienteOutroVendedoir, .VendaClienteOutroVendedor)
            SetComboValue(cboDigitaPreco, .DigitaPreco)
            SetComboValue(cboDigitaDesconto, .DigitaDesconto)
            SetComboValue(cboFiltrarCategoria, .FiltrarPorCategoria)
            SetComboValue(cboDigitaDataEntrega, .DigitaDataEntrega)
            SetComboValue(cboDigitaObservacao, .DigitaObservacao)
            SetComboValue(cboTotalPedidos, .ExibeTotalPedidos)
            SetComboValue(cboLimiteCredito, .ConsiderarLimiteCredito)
        End With
    End Sub

    Private Sub SetComboValue(ByVal vDropDownList As DropDownList, ByVal Value As String)
        On Error Resume Next
        vDropDownList.ClearSelection()
        vDropDownList.Items.FindByValue(Value).Selected = True
    End Sub

    Private Function GetComboValue(ByVal vDropDownList As DropDownList) As String
        If vDropDownList.SelectedIndex >= 0 Then
            Return vDropDownList.SelectedItem.Value
        Else
            Return 0
        End If
    End Function

    Private Sub Deflate()
        With cls
            .ItemsPerPage = GetComboValue(cboItensPerPage)
            .BuscaProduto = GetComboValue(cboBuscaProduto)
            .VisualizaEstoque = GetComboValue(cboVisualizaEstoque)
            .BuscaCliente = GetComboValue(cboBuscaCliente)
            .EntradaProduto = GetComboValue(cboEntradaProduto)
            .VendaSEstoque = GetComboValue(cboVendaSEstoque)
            .MostraItensResumo = GetComboValue(cboMostraResumo)
            .ExibeDadosCliente = GetComboValue(cboInformacaoCliente)
            .VendaDescontoExcedente = GetComboValue(cboDescontoExcessivo)
            .VendaClienteOutroVendedor = GetComboValue(cboClienteOutroVendedoir)
            .DigitaPreco = GetComboValue(cboDigitaPreco)
            .DigitaDesconto = GetComboValue(cboDigitaDesconto)
            .FiltrarPorCategoria = GetComboValue(cboFiltrarCategoria)
            .DigitaDataEntrega = GetComboValue(cboDigitaDataEntrega)
            .DigitaObservacao = GetComboValue(cboDigitaObservacao)
            .ExibeTotalPedidos = GetComboValue(cboTotalPedidos)
            .ConsiderarLimiteCredito = GetComboValue(cboLimiteCredito)
        End With
    End Sub


    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Deflate()
    End Sub


End Class

