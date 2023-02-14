Public Class ControleVendEmpDet

    Inherits XMWebPage

    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm

    Protected WithEvents btnVoltar As HtmlInputButton
    Protected WithEvents btnGravar As HtmlInputButton
    Protected WithEvents lblNomeEmpresa As Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents cboIdVendedor As DropDownList


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then



            ViewState("IdEmpresa") = DeCryptography(Request("IdEmpresa") & "")

            Dim emp As New clsEmpresas(ViewState("IdEmpresa"))
            lblNomeEmpresa.Text = emp.RazaoSocial

            Dim Vend As New clsUsuario
            cboIdVendedor.DataSource = Vend.ListarVendedores(Me.Usuario.IdEmpresa)
            cboIdVendedor.DataBind()
            Vend = Nothing

            cboIdVendedor.Items.Insert(0, New ListItem("Vendedor(a) Não Definido(a)", "0"))

            XMSetListItemValue(cboIdVendedor, emp.VendedorAssociado.IDVendedor)

            ViewState("IdVendedorAtual") = emp.VendedorAssociado.IDVendedor

        End If

    End Sub

    Private Sub btnGravar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.ServerClick
        Dim emp As New clsEmpresas(ViewState("IdEmpresa"))
        emp.VendedorAssociado.Update(Me.Usuario.IDUsuario, XMGetListItemValue(cboIdVendedor))

        If XMGetListItemValue(cboIdVendedor) <> ViewState("IdVendedorAtual") Then

            '-------------------------------------------------------------------
            'ENVIA UM E-MAIL PARA O USUÁRIO QUE GANHOU O CADASTRO
            '-------------------------------------------------------------------
            Dim usu As clsUsuario, strBody As String
            usu = New clsUsuario(XMGetListItemValue(cboIdVendedor), Me.Usuario.IdEmpresa)

            strBody = getFileData("templateEmailAltCad").ToString()
            strBody = strBody.Replace("#MENSAGEM#", "Você está responsável pela empresa " & emp.CodigoAntigo & " - " & emp.RazaoSocial & ".")
            strBody = strBody.Replace("#TITULO#", "Altera&ccedil;&atilde;o de Cadastro de Empresa")
            strBody = strBody.Replace("</head>", "</head><!-- " & usu.IDUsuario & "-" & usu.Usuario & "-->")

            EnviarEmail("Alteração de Cadastro de Empresa", usu.Email, strBody)
            '-------------------------------------------------------------------

            '-------------------------------------------------------------------
            'ENVIA UM E-MAIL PARA O USUÁRIO QUE PERDEU O CADASTRO
            '-------------------------------------------------------------------
            usu = New clsUsuario(ViewState("IdVendedorAtual"), Me.Usuario.IdEmpresa)

            strBody = getFileData("templateEmailAltCad").ToString()
            strBody = strBody.Replace("#MENSAGEM#", "O cadastro da empresa Código " & emp.CodigoAntigo & " - " & emp.RazaoSocial & " foi retirado do seu nome.")
            strBody = strBody.Replace("#TITULO#", "Altera&ccedil;&atilde;o de Cadastro de Empresa")
            strBody = strBody.Replace("</head>", "</head><!-- " & usu.IDUsuario & "-" & usu.Usuario & "-->")

            EnviarEmail("Alteração de Cadastro de Empresa", usu.Email, strBody)
            '-------------------------------------------------------------------

            usu = Nothing

        End If

        Page.Response.Redirect("ControleVendEmpDet.aspx?IdEmpresa=" & CryptographyEncoded(ViewState("IdEmpresa")))

    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.ServerClick
        Page.Response.Redirect("ControleVendEmp.aspx")
    End Sub
End Class