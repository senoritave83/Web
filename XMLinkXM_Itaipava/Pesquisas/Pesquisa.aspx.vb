
Imports Classes
Imports System.Collections.Generic

Namespace Pages.Pesquisas

    Partial Public Class Pesquisa
        Inherits XMWebPage

        Protected cls As clsPesquisa
        Protected Const VW_IDPESQUISA As String = "IDPesquisa"
        Protected Const Secao As String = "Cadastro de Pesquisa"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsPesquisa()

            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta pesquisa?")
                ViewState(VW_IDPESQUISA) = CInt("0" & Request("IDPesquisa"))
                cls.Load(ViewState(VW_IDPESQUISA))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                btnGravar.Enabled = cls.IsValidToEdit()

                Inflate()

            Else

                cls.Load(ViewState(VW_IDPESQUISA))

            End If

        End Sub

        Protected Sub Inflate()

            txtDataInicio.Text = cls.DataInicio
            txtDataFim.Text = cls.DataFim
            txtVisitasMes.Text = cls.VisitasMes
            txtPesquisa.Text = cls.Pesquisa

            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If

            chkPricing.Checked = cls.Pricing

            If cls.IDPesquisa > 0 Then

                grdProdutos.Visible = True
                grdMarca.Visible = True
                grdEmpresas.Visible = True

                Dim clsProd As New clsProdutoPesquisa
                grdProdutos.DataSource = clsProd.Listar()
                grdProdutos.DataBind()

                Dim clsMarca As New clsMarca
                grdMarca.DataSource = clsMarca.Listar()
                grdMarca.DataBind()

                Dim clsEmpresa As New clsEmpresa
                grdEmpresas.DataSource = clsEmpresa.Listar()
                grdEmpresas.DataBind()

            Else

                grdProdutos.Visible = False
                grdMarca.Visible = False
                grdEmpresas.Visible = False

            End If

            

        End Sub

        Protected Sub Deflate()

            cls.DataInicio = txtDataInicio.Text
            cls.DataFim = txtDataFim.Text
            cls.VisitasMes = txtVisitasMes.Text
            cls.Pesquisa = txtPesquisa.Text
            cls.Pricing = chkPricing.Checked

            Dim produtoInput As String = Request.Form("Produto")

            cls.Produtos.Clear()

            If Not produtoInput Is Nothing Then
                cls.Produtos.AddRange(Array.ConvertAll(produtoInput.Split(","), New Converter(Of String, Integer)(AddressOf ConvertStringToInt)))
            End If

            Dim marcaInput As String = Request.Form("Marca")

            cls.Marcas.Clear()

            If Not marcaInput Is Nothing Then
                cls.Marcas.AddRange(Array.ConvertAll(marcaInput.Split(","), New Converter(Of String, Integer)(AddressOf ConvertStringToInt)))
            End If

            Dim empresaInput As String = Request.Form("Empresa")

            cls.Empresas.Clear()

            If Not empresaInput Is Nothing Then
                cls.Empresas.AddRange(Array.ConvertAll(empresaInput.Split(","), New Converter(Of String, Integer)(AddressOf ConvertStringToInt)))
            End If

        End Sub

        Private Function ConvertStringToInt(ByVal str As String) As Integer

            Return CInt(str)

        End Function

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If Page.IsValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Pesquisas/Pesquisa.aspx?idpesquisa=" & cls.IDPesquisa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Pesquisas.aspx")
            End If
        End Sub

        Public Sub dateValidator(ByVal sender As Object, ByVal args As ServerValidateEventArgs)

            Dim data As String = args.Value

            args.IsValid = IsDate(data)

            Exit Sub

            Dim values() As String
            Dim mes As Integer
            Dim ano As Integer

            values = data.Split("/")

            If Not values.Length = 2 Then
                args.IsValid = False
            ElseIf Not (Integer.TryParse(values(0), mes) And Integer.TryParse(values(1), ano)) Then
                args.IsValid = False
            ElseIf mes < 1 Or mes > 12 Or ano < Date.Today.Year Then
                args.IsValid = False
            ElseIf Date.Today.Year = ano And Date.Today.Month >= mes Then
                args.IsValid = False
            End If

        End Sub

    End Class

End Namespace

