Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports ITCOffLine


Public Class agradecimento

    Inherits XMWebPage

    Protected WithEvents txtCod As TextBox
    Protected WithEvents txtmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtac As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblMain As HtmlTable
    Protected WithEvents tblResult As HtmlTable
    Protected WithEvents lblAC As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents btnEnviar As Button


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


    Private filCarta As String = CartaAgradecimento()
    Private urlITC As String = getPropriedade("urlITC")

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        Dim p_Cod = Request("c") & ""
        If p_Cod <> "" Then
            txtCod.Text = DeCryptography(p_Cod)
        End If
        'btnEnviar.attributes.add("onClick","Javascript:alert('E-Mail Enviado!');")

    End Sub


    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim ei As String = ""
        Dim para As String = ""
        Dim AC As String = ""
        Dim conteudo As String = ""

        Dim p_LinkObra As String = ""

        ei = txtCod.Text
        para = txtmail.Text
        AC = txtac.Text
        p_LinkObra = GetLink(ei)

        'response.write(p_LinkObra)

        'response.end

        If File.Exists(filCarta) Then

            Dim str As New StreamReader(filCarta)
            conteudo = str.ReadToEnd
            conteudo = conteudo.replace("<CAMINHOITC>", urlITC)
            conteudo = conteudo.replace("<LINK>", p_LinkObra)
            conteudo = conteudo.replace("<AC>", AC)
            str.Close()

        End If

        Try

            EnviarEmail("A ITC agradece as informações divulgadas", para, conteudo)

        Catch ex As Exception

            Response.Write("Erro na tentativa de enviar o e-mail - Erro: " & ex.Message)
            Response.End()

        End Try

        tblMain.Visible = False
        tblResult.Visible = True

        txtCod.Text = ""
        txtac.Text = ""
        txtmail.Text = ""

    End Sub
End Class
