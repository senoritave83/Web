Public Class ControleAssociadosDet

    Inherits XMWebPage

    Protected WithEvents lblAssociado As System.Web.UI.WebControls.Label
    Protected WithEvents lblUsuario As System.Web.UI.WebControls.Label
    Protected WithEvents lblUltimoAcesso As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataAcesso As System.Web.UI.WebControls.Label
    Protected WithEvents lblIP As System.Web.UI.WebControls.Label
    Protected WithEvents lblBrowser As System.Web.UI.WebControls.Label
    Protected WithEvents btnBloquearAcesso As System.Web.UI.WebControls.Button
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Button
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblObrasDet As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label

    Private Controle As clsControleAcessos

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

            Dim objIdHistorico As Object = DeCryptography(Page.Request("IdHistorico"))
            If IsNumeric(objIdHistorico) Then
                ViewState("IdHistorico") = objIdHistorico
            Else
                ViewState("IdHistorico") = 0
            End If
            Dados()

        End If
    End Sub

    Private Sub Dados()

        Controle = New clsControleAcessos(ViewState("IdHistorico"))
        Inflate()

    End Sub

    Private Sub Inflate()

        With Controle
            ViewState("IdAssociado") = .IdAssociado
            ViewState("IdUsuario") = .IdUsuario
            lblAssociado.Text = .NomeAssociado
            lblUsuario.Text = .NomeUsuario
            lblBrowser.Text = .Browser
            lblDataAcesso.Text = .DataAcesso
            lblUltimoAcesso.Text = .DataUltimoAcesso
            lblIP.Text = .IP
            ViewState("Tipo") = Microsoft.VisualBasic.IIf(.Ativo, 0, 1)
            If .Ativo Then
                btnBloquearAcesso.Text = "Bloquear Acesso"
            Else
                btnBloquearAcesso.Text = "Liberar Acesso"
            End If
        End With

    End Sub

    Private Sub btnBloquearAcesso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBloquearAcesso.Click
        Controle = New clsControleAcessos(0)
        Controle.BloqueiaAcesso(ViewState("IdUsuario"), ViewState("IdAssociado"), ViewState("Tipo"))
        Controle = Nothing
        Dados()
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("ControleAssociados.aspx")
    End Sub

End Class
