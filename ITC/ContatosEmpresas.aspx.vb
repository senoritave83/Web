Public Class ContatosEmpresas
    Inherits XMWebPage
    Protected WithEvents tblObrasDet As HtmlTable
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDD2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboCargo As ComboBox
    Protected WithEvents cboTipo1 As ComboBox
    Protected WithEvents cboTipo2 As ComboBox
    Protected WithEvents cboTipo3 As ComboBox
    Protected WithEvents txtDDDFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnVoltar As Button
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Private Contato As clsContatoEmpresas

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
            With cboCargo
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = crg.List
                .DataValueField = "IDCargo"
                .DataTextField = "DescricaoCargo"
                .DataBind()
            End With
            crg = Nothing

            With cboTipo1
                .AddItem(1, "TELEFONE")
                .AddItem(2, "CELULAR")
                .AddItem(3, "FAX")
                .AddItem(4, "PABX")
            End With

            With cboTipo2
                .AddItem(1, "TELEFONE")
                .AddItem(2, "CELULAR")
                .AddItem(3, "FAX")
                .AddItem(4, "PABX")
            End With

            With cboTipo3
                .AddItem(1, "TELEFONE")
                .AddItem(2, "CELULAR")
                .AddItem(3, "FAX")
                .AddItem(4, "PABX")
            End With

            Dim objIdEmpresa As Object = DeCryptography(Page.Request("IDEmpresa"))
            Dim m_IdEmpresa As Integer
            If IsNumeric(objIdEmpresa) Then
                m_IdEmpresa = objIdEmpresa
            Else
                m_IdEmpresa = 0
            End If
            ViewState("IDEmpresa") = CInt(0 & m_IdEmpresa)

            Dim objIdContato As Object = DeCryptography(Page.Request("IDContato"))
            Dim m_IdContato As Integer
            If IsNumeric(objIdContato) Then
                m_IdContato = objIdContato
            Else
                m_IdContato = 0
            End If
            ViewState("IDContato") = CInt(0 & m_IdContato)

            Contato = New clsContatoEmpresas(Me)
            Contato.IdContato = ViewState("IDContato")
            Contato.IdEmpresa = ViewState("IDEmpresa")
            Inflate()

        Else

            Contato = New clsContatoEmpresas(Me)
            Contato.IdContato = ViewState("IDContato")
            Contato.IdEmpresa = ViewState("IDEmpresa")

        End If

        'Componentes Desabilitados
        cboCargo.Enabled = False
        cboTipo1.Enabled = False
        cboTipo2.Enabled = False
        cboTipo3.Enabled = False

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
            .DDD2 = txtDDD2.Text
            .Telefone2 = txtTElefone2.Text
            .IdTipoTelefone1 = cboTipo1.Value
            .IdTipoTelefone2 = cboTipo2.Value
            .IdTipoTelefone3 = cboTipo3.Value
        End With
    End Sub

    Private Sub Inflate()
        With Contato
            cboCargo.Value = .IdCargo
            txtNome.Text = .NomeContato
            txtDDD.Text = .DDD
            txtTElefone.Text = .Telefone
            txtDDD2.Text = .DDD2
            txtTElefone2.Text = .Telefone2
            txtDDDFax.Text = .DDDFax
            txtFax.Text = .Fax
            txtEMail.Text = .EMail
            cboTipo1.Value = .IdTipoTelefone1
            cboTipo2.Value = .IdTipoTelefone2
            cboTipo3.Value = .IdTipoTelefone3
        End With
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("empresasdet.aspx?codigo=" & CryptographyEncoded(ViewState("IDEmpresa")))
    End Sub
End Class
