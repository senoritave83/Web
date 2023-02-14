Public Class EmpresaObras

    Inherits XMWebPage

    Protected WithEvents lblFantasia As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazaoSocial As System.Web.UI.WebControls.Label
    Protected WithEvents lblEndereco As System.Web.UI.WebControls.Label
    Protected WithEvents lblCidade As System.Web.UI.WebControls.Label
    Protected WithEvents lblUF As System.Web.UI.WebControls.Label
    Protected WithEvents txtIdEmpresa As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboModalidade As ComboBox
    Protected WithEvents btnVoltar As Button

    Protected WithEvents IdObra As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents tblObrasDet As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label

    Private ObrEmp As clsEmpresasObras

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

            Dim M As New clsModalidades
            With cboModalidade
                .DataSource = M.ListModalidades
                .DataTextField = "DescricaoModalidade"
                .DataValueField = "IdModalidade"
                .DataBind()
            End With
            M = Nothing

            Dim p_IdObra As Integer = 0
            Dim objIdObra As Object = DeCryptography(Request("IDObra"))
            If IsNumeric(objIdObra) Then
                p_IdObra = objIdObra
            End If

            Dim p_IdEmpresa As Integer = 0
            Dim objIdEmpresa As Object = DeCryptography(Request("IDEmpresa"))
            If IsNumeric(objIdEmpresa) Then
                p_IdEmpresa = objIdEmpresa
            End If

            Dim p_IdModalidade As Integer = 0
            Dim objIdModalidade As Object = DeCryptography(Request("IdModalidade"))
            If IsNumeric(objIdModalidade) Then
                p_IdModalidade = objIdModalidade
            End If

            ViewState("IdObra") = CInt(0 & p_IdObra)
            ViewState("IdEmpresa") = CInt(0 & p_IdEmpresa)
            ViewState("IdModalidade") = CInt(0 & p_IdModalidade)
            IdObra.Value = ViewState("IdObra") 'passa os dados para o Input Hidden

            If ViewState("IdEmpresa") > 0 Then
                txtIdEmpresa.Text = ViewState("IdEmpresa")
                ObrEmp = New clsEmpresasObras(ViewState("IdObra"), ViewState("IdEmpresa"), ViewState("IdModalidade"))
                Popular(ViewState("IdObra"), ViewState("IdEmpresa"))
                ObrEmp = Nothing
            Else
                txtIdEmpresa.Text = ""
                Limpar()
            End If

        Else
            txtIdEmpresa.Text = ViewState("IdEmpresa")
            ObrEmp = New clsEmpresasObras(ViewState("IdObra"), ViewState("IdEmpresa"), ViewState("IdModalidade"))
        End If

        'Componentes Desabilitados
        cboModalidade.Enabled = False

    End Sub

    Private Sub Limpar()

        lblFantasia.Text = ""
        lblRazaoSocial.Text = ""
        lblEndereco.Text = ""
        lblCidade.Text = ""
        lblUF.Text = ""

    End Sub

    Private Sub Popular(ByVal p_IdObra As Integer, ByVal p_IdEmpresa As Integer)

        cboModalidade.Value = ObrEmp.IdModalidade
        Dim Emp As New clsEmpresas(p_IdEmpresa)
        With Emp
            lblFantasia.Text = .Fantasia
            lblRazaoSocial.Text = .RazaoSocial
            lblEndereco.Text = .Endereco
            lblCidade.Text = .Cidade
            lblUF.Text = .Estado
        End With
        Emp = Nothing

    End Sub

    Private Sub Deflate()

        ObrEmp.IdObra = ViewState("IdObra")
        ObrEmp.IdEmpresa = ViewState("IdEmpresa")
        ObrEmp.IdModalidade = cboModalidade.Value

    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("obrasdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdObra")))
    End Sub
End Class
