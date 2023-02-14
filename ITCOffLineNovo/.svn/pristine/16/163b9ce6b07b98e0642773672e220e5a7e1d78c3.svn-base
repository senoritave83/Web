Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports ITCOffLine

Public Class EmailPedido
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

    Private LogoPed As String = getPropriedade("LogoPed")
    Private GuiaNeg As String = getPropriedade("GuiaNeg")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ViewState("IdPed") = DeCryptography(Request("idped"))
        ViewState("Tipo") = Request("tipo")

        btnEnviar.Attributes.Add("onClick", "if(fncValida()==false)return false;")

    End Sub


    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim email, cc, cco As String
        email = txtmail.Text
        cc = txtCc.Text
        cco = txtCco.Text

        Dim wc As New System.Net.WebClient
        Dim utf As New System.Text.UTF8Encoding
        Dim strTexto As String = ""
        Dim strTextoVerso As String = ""

        Try

            Dim conf As New XMLConfig
            Dim sv As String = conf.GetValue("IP_SERVIDOR_LOCAL", "127.0.0.1/itco")
            strTexto = utf.GetString(wc.DownloadData("http://" & sv & "/formulariopedido.aspx?idpedido=" & Server.UrlEncode(CryptographyEncoded(ViewState("IdPed"))) & "&idtipopedido=" & ViewState("Tipo") & "&email=1"))
            strTextoVerso = utf.GetString(wc.DownloadData("http://" & sv & "/versopedido.aspx"))

            strTexto = strTexto.Replace("</HTML>", "")
            strTexto = strTexto.Replace("</body>", "")

            Dim iStartHeader = strTextoVerso.IndexOf("<!--HEADERXM-->")
            Dim iEndHeader = strTextoVerso.IndexOf("<!--HEADERXM2-->")

            Dim iStartCSSVerso = strTextoVerso.IndexOf("<!--CSS_INICIO-->")
            Dim iEndCSSVerso = strTextoVerso.IndexOf("<!--CSS_FIM-->")

            Dim strCSSVerso = strTextoVerso.Substring(iStartCSSVerso, (iEndCSSVerso - iStartCSSVerso) + 14)
            strTextoVerso = strTextoVerso.Remove(iStartHeader, (iEndHeader - iStartHeader) + 16)
            strTexto = strTexto.Replace("<!--css_verso-->", strCSSVerso)

        Catch ex As Exception

            Response.Write("<img src='imagens/logoitcPed.png' border='0' /><br>")
            Response.Write("Erro na tentativa de enviar o e-mail - Erro: " & ex.Message)
            Response.End()

        End Try

        If ViewState("Tipo") = 1 Then
            strTexto = strTexto.Replace("Imagens/logoitcPed.png", LogoPed)
        ElseIf ViewState("Tipo") = 2 Then
            strTexto = strTexto.Replace("Imagens/Guia_Negocios.png", GuiaNeg)
        End If

        Try
            EnviarEmail_Pedido("ITC - Pedido Eletrônico", email, cc, cco, strTexto & "<br>" & strTextoVerso)

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
