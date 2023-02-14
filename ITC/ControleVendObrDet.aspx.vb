Public Class ControleVendObrDet

    Inherits XMWebPage

    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm

    Protected WithEvents btnVoltar As HtmlInputButton
    Protected WithEvents btnGravar As HtmlInputButton
    Protected WithEvents lblNomeObra As Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents cboIdVendedor As DropDownList


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



            ViewState("IdObra") = DeCryptography(Request("IdObra") & "")

            Dim obr As New clsObras(ViewState("IdObra"))
            lblNomeObra.Text = obr.Projeto

            Dim Vend As New clsUsuario
            cboIdVendedor.DataSource = Vend.ListarVendedores(Me.Usuario.IdEmpresa)
            cboIdVendedor.DataBind()
            Vend = Nothing

            cboIdVendedor.Items.Insert(0, New ListItem("Vendedor(a) Não Definido(a)", "0"))

            XMSetListItemValue(cboIdVendedor, obr.VendedorAssociado.IDVendedor)

            ViewState("IdVendedorAtual") = obr.VendedorAssociado.IDVendedor

        End If

    End Sub

    Private Sub btnGravar_ServerClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.ServerClick
        Dim obr As New clsObras(ViewState("IdObra"))

        obr.VendedorAssociado.Update(Me.Usuario.IDUsuario, XMGetListItemValue(cboIdVendedor))

        If XMGetListItemValue(cboIdVendedor) <> ViewState("IdVendedorAtual") Then

            '-------------------------------------------------------------------
            'ENVIA UM E-MAIL PARA O USUÁRIO QUE GANHOU O CADASTRO
            '-------------------------------------------------------------------
            Dim usu As clsUsuario, strBody As String
            Try
                usu = New clsUsuario(XMGetListItemValue(cboIdVendedor), Me.Usuario.IdEmpresa)

                strBody = getFileData("templateEmailAltCad").ToString()
                strBody = strBody.Replace("#MENSAGEM#", "Você está responsável pela obra " & obr.CodigoAntigo & " - " & obr.Projeto & ".")
                strBody = strBody.Replace("#TITULO#", "Altera&ccedil;&atilde;o de Cadastro de Obra")
                strBody = strBody.Replace("</head>", "</head><!-- " & usu.IDUsuario & "-" & usu.Usuario & "-->")

                EnviarEmail("Alteração de Cadastro de Obra", usu.Email, strBody)
                '-------------------------------------------------------------------
            Catch
            End Try
            '-------------------------------------------------------------------
            'ENVIA UM E-MAIL PARA O USUÁRIO QUE PERDEU O CADASTRO
            '-------------------------------------------------------------------
            Try
                usu = New clsUsuario(ViewState("IdVendedorAtual"), Me.Usuario.IdEmpresa)

                strBody = getFileData("templateEmailAltCad").ToString()
                strBody = strBody.Replace("#MENSAGEM#", "O cadastro da obra Código " & obr.CodigoAntigo & " - " & obr.Projeto & " foi retirado do seu nome.")
                strBody = strBody.Replace("#TITULO#", "Altera&ccedil;&atilde;o de Cadastro de Obra")
                strBody = strBody.Replace("</head>", "</head><!-- " & usu.IDUsuario & "-" & usu.Usuario & "-->")

                EnviarEmail("Alteração de Cadastro de Obra", usu.Email, strBody)
                '-------------------------------------------------------------------

                usu = Nothing
            Catch
            End Try

        End If

        Page.Response.Redirect("ControleVendObrDet.aspx?idobra=" & CryptographyEncoded(ViewState("IdObra")))

    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.ServerClick
        Page.Response.Redirect("ControleVendObr.aspx")
    End Sub
End Class