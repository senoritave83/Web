Public Class ContatosAssociados
    Inherits XMWebPage
    Protected WithEvents tblObrasDet As HtmlTable
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboCargo As ComboBox
    Protected WithEvents cboFuncao As ComboBox
    Protected WithEvents txtDDDFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDDCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSkype As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnVoltar As Button
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblTelefone As System.Web.UI.WebControls.Label
    Protected WithEvents lblCargo As System.Web.UI.WebControls.Label
    Protected WithEvents lblFax As System.Web.UI.WebControls.Label
    Protected WithEvents lblCelular As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Private Contato As clsContatoAssociados

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

            Dim crg As New clsCargos(Me)
            cboCargo.DataSource = crg.List
            cboCargo.DataValueField = "IdCargo"
            cboCargo.DataTextField = "DescricaoCargo"
            cboCargo.DataBind()
            crg = Nothing

            Dim func As New clsCargos(Me)
            cboFuncao.DataSource = func.List
            cboFuncao.DataValueField = "IdCargo"
            cboFuncao.DataTextField = "DescricaoCargo"
            cboFuncao.DataBind()
            cboFuncao.EnableValidation = False
            func = Nothing

            Dim objIdAssociado As Object = DeCryptography(Page.Request("IDAssociado"))
            Dim m_IdAssociado As Integer
            If IsNumeric(objIdAssociado) Then
                m_IdAssociado = objIdAssociado
            Else
                m_IdAssociado = 0
            End If
            ViewState("IDAssociado") = CInt(0 & m_IdAssociado)

            Dim objIdContato As Object = DeCryptography(Page.Request("IDContato"))
            Dim m_IdContato As Integer
            If IsNumeric(objIdContato) Then
                m_IdContato = objIdContato
            Else
                m_IdContato = 0
            End If
            ViewState("IDContato") = CInt(0 & m_IdContato)

            Contato = New clsContatoAssociados(Me)
            Contato.IdContato = ViewState("IDContato")
            Contato.IdAssociado = ViewState("IDAssociado")
            Inflate()

        Else

            Contato = New clsContatoAssociados(Me)
            Contato.IdContato = ViewState("IDContato")
            Contato.IdAssociado = ViewState("IDAssociado")

        End If

        'Componentes Desabilitados
        cboCargo.Enabled = False
        cboFuncao.Enabled = False

    End Sub

    Private Sub Deflate()

        With Contato
            .IdCargo = cboCargo.Value
            .NomeContato = txtNome.Text
            .DDD = txtDDD.Text
            .Telefone = txtTElefone.Text
            .DDDFax = txtDDDFax.Text
            .Fax = txtFax.Text
            .EMail = txtEMail.Text
            .Celular = txtCelular.Text
            .DDDCelular = txtDDDCelular.Text
            .IdFuncao = cboFuncao.Value
        End With

    End Sub

    Private Sub Inflate()

        With Contato
            cboCargo.Value = .IdCargo
            txtNome.Text = .NomeContato
            txtDDD.Text = .DDD
            txtTElefone.Text = .Telefone
            txtDDDFax.Text = .DDDFax
            txtFax.Text = .Fax
            txtEMail.Text = .EMail
            txtDDDCelular.Text = .DDDCelular
            txtCelular.Text = .Celular
            cboFuncao.Value = .IdFuncao
            txtSkype.Text = .Skype
        End With

    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click

        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IDAssociado")))

    End Sub
End Class
