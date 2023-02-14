Public Class ContatosObras
    Inherits XMWebPage
    Protected WithEvents tblObrasDet As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDD2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboCargo As ComboBox
    Protected WithEvents txtDDDFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents hdIdEmpresa As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents cboTipo1 As ComboBox
    Protected WithEvents cboTipo2 As ComboBox
    Protected WithEvents cboTipo3 As ComboBox
    Protected WithEvents btnVoltar As Button

    Private Contato As clsContatoObras
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Private blnReaproveitar As Boolean = False

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

            With cboTipo1
                .AddItem(1, "TELEFONE")
                .AddItem(2, "CELULAR")
                .AddItem(3, "FAX")
                .AddItem(4, "PABX")
                .AddItem(5, "OBRA")
            End With

            With cboTipo2
                .AddItem(1, "TELEFONE")
                .AddItem(2, "CELULAR")
                .AddItem(3, "FAX")
                .AddItem(4, "PABX")
                .AddItem(5, "OBRA")
            End With

            With cboTipo3
                .AddItem(1, "TELEFONE")
                .AddItem(2, "CELULAR")
                .AddItem(3, "FAX")
                .AddItem(4, "PABX")
                .AddItem(5, "OBRA")
            End With

            Dim crg As New clsCargos(Me)
            cboCargo.DataSource = crg.List
            cboCargo.DataValueField = "IDCargo"
            cboCargo.DataTextField = "DescricaoCargo"
            cboCargo.DataBind()
            crg = Nothing

            Dim objIdObra As Object = DeCryptography(Page.Request("IdObra"))
            Dim m_IdObra As Integer
            If IsNumeric(objIdObra) Then
                m_IdObra = objIdObra
            Else
                m_IdObra = 0
            End If
            ViewState("IDObra") = CInt(0 & m_IdObra)

            Dim objIdContato As Object = DeCryptography(Page.Request("IDContato"))
            Dim m_IdContato As Integer
            If IsNumeric(objIdContato) Then
                m_IdContato = objIdContato
            Else
                m_IdContato = 0
            End If
            ViewState("IDContato") = CInt(0 & m_IdContato)

            Contato = New clsContatoObras(Me)
            Contato.IdContato = ViewState("IDContato")
            Contato.IdObra = ViewState("IDObra")
            Inflate()

        Else

            Contato = New clsContatoObras(Me)
            Contato.IdContato = ViewState("IDContato")
            Contato.IdObra = ViewState("IDObra")

        End If

        'Componentes Desabilitados
        cboCargo.Enabled = False
        cboTipo1.Enabled = False
        cboTipo2.Enabled = False
        cboTipo3.Enabled = False

    End Sub

    Private Sub LerReaproveitar()

        With Contato
            .IdCargo = ViewState("cboIdCargo")
            txtNome.Text = ViewState("txtNome")
            txtDDD.Text = ViewState("txtDDD")
            txtTElefone.Text = ViewState("txtTelefone")
            txtDDDFax.Text = ViewState("DDDFax")
            txtFax.Text = ViewState("txtFax")
            txtEMail.Text = ViewState("txtEMail")
            hdIdEmpresa.Value = ViewState("hdIdEmpresa")
            lblFantasia.Text = ViewState("lblFantasia")
            cboTipo1.Value = ViewState("cboTipo1")
            cboTipo2.Value = ViewState("cboTipo2")
            cboTipo3.Value = ViewState("cboTipo3")
            txtDDD2.Text = ViewState("txtDDD2")
            txtTElefone2.Text = ViewState("txtTelefone2")
        End With
    End Sub

    Private Sub Reaproveitar()

        With Contato
            ViewState("cboIdCargo") = .IdCargo
            ViewState("txtNome") = txtNome.Text
            ViewState("txtDDD") = txtDDD.Text
            ViewState("txtTelefone") = txtTElefone.Text
            ViewState("DDDFax") = txtDDDFax.Text
            ViewState("txtFax") = txtFax.Text
            ViewState("txtEMail") = txtEMail.Text
            ViewState("hdIdEmpresa") = hdIdEmpresa.Value
            ViewState("lblFantasia") = lblFantasia.Text
            ViewState("cboTipo1") = cboTipo1.Value
            ViewState("cboTipo2") = cboTipo2.Value
            ViewState("cboTipo3") = cboTipo3.Value
            ViewState("txtDDD2") = txtDDD2.Text
            ViewState("txtTelefone2") = txtTElefone2.Text
        End With

    End Sub

    Private Sub ApagarReaproveitar()

        With Contato
            ViewState("cboIdCargo") = 0
            ViewState("txtNome") = ""
            ViewState("txtDDD") = ""
            ViewState("txtTelefone") = ""
            ViewState("DDDFax") = ""
            ViewState("txtFax") = ""
            ViewState("txtEMail") = ""
            ViewState("hdIdEmpresa") = 0
            ViewState("lblFantasia") = ""
            ViewState("cboTipo1") = 0
            ViewState("cboTipo2") = 0
            ViewState("cboTipo3") = 0
            ViewState("txtDDD2") = ""
            ViewState("txtTelefone2") = ""
        End With

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
            .IdEmpresa = hdIdEmpresa.Value 'EMPRESA PARTICIPANTE
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
            txtDDDFax.Text = .DDDFax
            txtFax.Text = .Fax
            txtEMail.Text = .EMail
            hdIdEmpresa.Value = .IdEmpresa
            lblFantasia.Text = .Empresa
            cboTipo1.Value = .IdTipoTelefone1
            cboTipo2.Value = .IdTipoTelefone2
            cboTipo3.Value = .IdTipoTelefone3
            txtDDD2.Text = .DDD2
            txtTElefone2.Text = .Telefone2
        End With
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("obrasdet.aspx?codigo=" & CryptographyEncoded(ViewState("IDObra")))
    End Sub
End Class
