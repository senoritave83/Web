Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports ITCOffLine

Public Class EmailProposta
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents txtmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents tblMain As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblResult As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblCc As System.Web.UI.WebControls.Label
    Protected WithEvents txtCc As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCco As System.Web.UI.WebControls.Label
    Protected WithEvents txtCco As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    'Private filCarta As String = CartaAgradecimento()

    Private FrmPropTopoTit As String = getPropriedade("FrmPropTopoTit")
    Private FrmPropLarAC As String = getPropriedade("FrmPropLarAC")
    Private FormPropTracoLaranja As String = getPropriedade("FormPropTracoLaranja")
    Private FrmPropTitObjetivo As String = getPropriedade("FrmPropTitObjetivo")
    Private FormPropTitModulos As String = getPropriedade("FormPropTitModulos")
    Private FormPropTitBeneficios As String = getPropriedade("FormPropTitBeneficios")
    Private FormPropTitNegocios As String = getPropriedade("FormPropTitNegocios")
    Private FormPropTitContato As String = getPropriedade("FormPropTitContato")
    Private FormPropTitInfoITC As String = getPropriedade("FormPropTitInfoITC")
    Private FormPropTitInfoITC2 As String = getPropriedade("FormPropTitInfoITC2")
    Private FormPropSelo As String = getPropriedade("FormPropSelo")
    Private FormPropTracoLar As String = getPropriedade("FormPropTracoLar")
    Private FormPropTraco As String = getPropriedade("FormPropTraco")
    Private FormPropTracoMod As String = getPropriedade("FormPropTracoMod")
    Private FormPropTracoVar As String = getPropriedade("FormPropTracoVar")
    Private LogoPed As String = getPropriedade("LogoPed")
    Private GuiaNeg As String = getPropriedade("GuiaNeg")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            ViewState("IdProp") = DeCryptography(Request("IdProposta"))
            ViewState("Tipo") = Request("tipoProp")
            ViewState("Associado") = Request("na")
            ViewState("EmailVendedor") = Request("ev")
            ViewState("IdPosicao") = Request("idPos")

            Dim emailcontato As String
            emailcontato = Request("emailCont")
            txtmail.Text = emailcontato

            btnEnviar.Attributes.Add("onClick", "if(fncValida()==false)return false;")

        End If

    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim email, cc, cco As String
        email = txtmail.Text
        cc = txtCc.Text
        cco = txtCco.Text

        Dim wc As New System.Net.WebClient
        Dim utf As New System.Text.UTF8Encoding
        Dim strTexto As String = ""

        Try

            Dim conf As New XMLConfig
            Dim sv As String = conf.GetValue("IP_SERVIDOR_LOCAL", "127.0.0.1/itco")
            strTexto = utf.GetString(wc.DownloadData("http://" & sv & "/formularioproposta.aspx?idproposta=" & Server.UrlEncode(CryptographyEncoded(ViewState("IdProp"))) & "&idtipoproposta=" & ViewState("Tipo") & "&email=3"))

            '************* P/ TESTAR O ENVIO DE-MAIL "LOCAL"
            'strTexto = utf.GetString(wc.DownloadData("http://desenv.xmsistemas.com.br/ITCOffNovo/formularioproposta.aspx?idproposta=" & Server.UrlEncode(CryptographyEncoded(ViewState("IdProp"))) & "&idtipoproposta=" & ViewState("Tipo") & "&email=3"))

            strTexto = strTexto.Replace("</HTML>", "")
            strTexto = strTexto.Replace("</body>", "")
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FrmPropTopoTit.jpg", FrmPropTopoTit)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FrmPropLarAC.jpg", FrmPropLarAC)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTracoLaranja.jpg", FormPropTracoLaranja)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FrmPropTitObjetivo.jpg", FrmPropTitObjetivo)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTitModulos.jpg", FormPropTitModulos)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTitBeneficios.jpg", FormPropTitBeneficios)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTitNegocios.jpg", FormPropTitNegocios)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTitContato.jpg", FormPropTitContato)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTitInfoITC.jpg", FormPropTitInfoITC)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTitInfoITC2.jpg", FormPropTitInfoITC2)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropSelo.jpg", FormPropSelo)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTracoLar.jpg", FormPropTracoLar)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTraco.jpg", FormPropTraco)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTracoMod.jpg", FormPropTracoMod)
            strTexto = strTexto.Replace("Imagens/FormularioProposta/FormPropTracoVar.jpg", FormPropTracoVar)

        Catch ex As Exception

            Response.Write("<img src='imagens/logoitcPed.png' border='0' /><br>")
            Response.Write("Erro na tentativa de enviar o e-mail - Erro: " & ex.Message)
            Response.End()

        End Try

        If ViewState("Tipo") = 1 Then
            strTexto = strTexto.Replace("Imagens/FormularioProposta/logoitcPed.png", LogoPed)
        ElseIf ViewState("Tipo") = 2 Then
            strTexto = strTexto.Replace("Imagens/FormularioProposta/Guia_Negocios.png", GuiaNeg)
        End If

        Try
            If ViewState("IdPosicao") = 2 Then
                EnviarEmail_Proposta("Renovação ITC - " & ViewState("Associado"), email, cc, cco, strTexto, ViewState("EmailVendedor"))
            Else
                EnviarEmail_Proposta("Proposta ITC - " & ViewState("Associado"), email, cc, cco, strTexto, ViewState("EmailVendedor"))
            End If

        Catch ex As Exception

            Response.Write("<img src='imagens/logoitcPed.png' border='0' /><br>")
            Response.Write("Erro na tentativa de enviar o e-mail - Erro: " & ex.Message)
            Response.End()

        End Try

        txtmail.Text = ""
        txtCc.Text = ""
        txtCco.Text = ""

        tblMain.Visible = False
        tblResult.Visible = True

    End Sub

End Class

