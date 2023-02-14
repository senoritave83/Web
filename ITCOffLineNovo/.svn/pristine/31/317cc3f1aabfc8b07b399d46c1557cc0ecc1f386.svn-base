Imports ITCOffLine

Public Class ContatosAssociados
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTElefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboCargo As ComboBox
    Protected WithEvents cboFuncao As ComboBox
    Protected WithEvents txtDDDFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDDDCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEMail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSkype As System.Web.UI.WebControls.TextBox
    Protected WithEvents Barra As BarraBotoes2

#End Region

    Private Contato As clsContatoAssociados

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



    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir

        Response.Redirect("contatoassociados.aspx?idcontato=" & CryptographyEncoded("0") & "&idassociado=" & CryptographyEncoded(ViewState("IDAssociado")))

    End Sub

    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar

        Deflate()
        Contato.Update()
        Gravado("contatoassociados.aspx?idcontato=" & CryptographyEncoded(Contato.IdContato) & "&idassociado=" & CryptographyEncoded(ViewState("IDAssociado")))

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
            .Skype = txtSkype.Text
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
        Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Associados", "Incluir Usuário"), BarraBotoes2.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Associados", "Gravar Usuário"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + IIf(CheckPermission("Cadastro de Associados", "Apagar Usuário"), BarraBotoes2.Botoes_Ativos.Excluir, 0) + BarraBotoes2.Botoes_Ativos.Voltar)

    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar

        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IDAssociado")))

    End Sub


    Private Sub BarraBotoes_Excluir() Handles Barra.Excluir

        Contato.Apagar(ViewState("IDAssociado"), ViewState("IDContato"))
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IDAssociado")))

    End Sub

End Class
