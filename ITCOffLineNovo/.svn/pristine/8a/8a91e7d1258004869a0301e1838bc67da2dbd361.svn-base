'Imports System.Web.UI.WebControls
Imports System.Drawing
Imports ITCOffLine
Imports System.Data

Public Class FormularioProposta
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblValor As System.Web.UI.WebControls.Label
    Protected WithEvents lblPeriodo As System.Web.UI.WebControls.Label
    Protected WithEvents lblValidadeProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblObservacao As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblModulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpresaDestinatario As System.Web.UI.WebControls.Label
    Protected WithEvents lblDestinatario As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblOrcamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato As System.Web.UI.WebControls.Label
    Protected WithEvents lblIdProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblOpcao As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelefonesVendedor As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTelefoneVendedor2 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblCelularVendedor As System.Web.UI.WebControls.Label
    Protected WithEvents rptOrcamentos As System.Web.UI.WebControls.Repeater
    Protected WithEvents ImgFormPropTracoMod As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents lblTelefoneVendedor2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCelularVendedor As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private Propostas As clsProposta
    Private PropostaOrcamento As clsPropostaOrcamentos
    Private PropostaAssociado As clsAssociados
    Private PropostaUsuario As clsUsuario
    Private p_Value As Double


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then

            ViewState("IdProposta") = Request("IdProposta")
            If Request("email") = "3" Then ViewState("IdProposta") = Server.UrlDecode(ViewState("IdProposta"))
            ViewState("IdTipoProposta") = Request("idTipoProposta")
            Inflate(DeCryptography(ViewState("IdProposta")))
            ViewState("Opcao") = 1

        End If

        ListarOrcamentos()

    End Sub

    Public Function DeCryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Decrypt(param)
        Return strReturn
    End Function

    Private Sub Inflate(ByVal vIDProposta As Integer)

        Propostas = New clsProposta
        Propostas.Load(vIDProposta)

        lblIdProposta.Text = Propostas.IdProposta
        ViewState("ValidadeProposta") = Propostas.ValidadeProposta

        lblDataProposta.Text = Server.HtmlEncode(Propostas.DataPropostaForm)
        lblEmpresaDestinatario.Text = Server.HtmlEncode(Propostas.RazaoSocial)
        lblDestinatario.Text = Server.HtmlEncode(Propostas.ContatoCad)

        lblContato.Text = Server.HtmlEncode(Propostas.Vendedor)
        lblEmail.Text = Server.HtmlEncode(Propostas.EmailVendedor)

        lblTelefonesVendedor.Text = Propostas.TelefonesVendedor
        'lblTelefoneVendedor2.Text = Propostas.TelefoneVendedor2
        'lblCelularVendedor.Text = Propostas.CelularVendedor

    End Sub

    Private Sub ListarOrcamentos()

        Dim Orcamentos As New clsPropostaOrcamentos
        rptOrcamentos.DataSource = Orcamentos.ListarOrcamentos(DeCryptography(ViewState("IdProposta")))
        rptOrcamentos.DataBind()

    End Sub

    Function ListarFormOrcamentos(ByVal vIdOrcamento As Integer) As DataSet

        ViewState("Observacao") = ""
        Return ListarFormOrcamentosItem(vIdOrcamento)

    End Function

    Function ListarFormOrcamentosItem(ByVal vIdOrcamento As Integer) As DataSet

        Dim PropOrc As New clsPropostaOrcamentos
        Dim ds As DataSet = PropOrc.ListFormPropostaOrcamentoItem(vIdOrcamento)
        Return ds

    End Function

    Protected Sub rptLbl_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

            e.Item.Visible = (e.Item.ItemIndex = 0)
            ViewState("Observacao") = e.Item.DataItem("Observacoes")

            Dim Img As HtmlImage = e.Item.FindControl("ImgFormPropTracoMod")
            Img.Visible = Not (rptOrcamentos.Items.Count = (CType(e.Item.Parent.Parent, RepeaterItem).DataItem("Quant") - 1))

        End If

    End Sub

    'Protected Sub rptOrcamentos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)

    '    If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

    '        Dim lblOpcao As Label = e.Item.FindControl("lblOpcao")
    '        If Not lblOpcao Is Nothing Then
    '            lblOpcao.Text = ViewState("Opcao")
    '        End If

    '        ViewState("Opcao") += 1

    '    End If

    'End Sub

End Class
