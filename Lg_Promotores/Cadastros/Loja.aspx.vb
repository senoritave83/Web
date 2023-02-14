
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Loja
        Inherits XMWebPage
        Dim cls As clsLoja
        Protected Const VW_IDLOJA As String = "IDLoja"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsLoja()
            If Not Page.IsPostBack Then

                Dim clsCli As clsCliente
                clsCli = New clsCliente
                drpIDCliente.DataSource = clsCli.Listar(DataClass.enReturnType.DataReader)
                drpIDCliente.DataBind()
                drpIDCliente.Items.Insert(0, New ListItem("Selecione a revenda...", 0))
                clsCli = Nothing

                Dim clsReg As clsRegiao
                clsReg = New clsRegiao
                drpIDRegiao.DataSource = clsReg.Listar(DataClass.enReturnType.DataReader)
                drpIDRegiao.DataBind()
                drpIDRegiao.Items.Insert(0, New ListItem("Selecione...", 0))
                clsReg = Nothing

                Dim clsShop As clsShopping = New clsShopping
                tljTipoLoja.DataSource = clsShop.Listar(DataClass.enReturnType.DataReader)
                tljTipoLoja.DataBind()
                clsShop = Nothing

                Dim clsTipLoja As clsTipoLoja
                clsTipLoja = New clsTipoLoja
                drpIDTipoLoja.DataSource = clsTipLoja.Listar(DataClass.enReturnType.DataReader)
                drpIDTipoLoja.DataBind()
                drpIDTipoLoja.Items.Insert(0, New ListItem("Selecione...", 0))
                clsTipLoja = Nothing

                Dim clsEst As clsEstado
                clsEst = New clsEstado
                drpIdUF.DataSource = clsEst.Listar(DataClass.enReturnType.DataReader)
                drpIdUF.DataBind()
                drpIdUF.Items.Insert(0, New ListItem("Selecione...", 0))
                clsEst = Nothing

                'Dim clsConsumo As New clsClassificacao(1)
                'cboIDClassificacaoConsumo.DataSource = clsConsumo.Listar
                'cboIDClassificacaoConsumo.DataBind()
                'cboIDClassificacaoConsumo.Items.Insert(0, New ListItem("", 0))

                'Dim clsLoja As New clsClassificacao(2)
                'cboIDClassificacaoLoja.DataSource = clsLoja.Listar
                'cboIDClassificacaoLoja.DataBind()
                'cboIDClassificacaoLoja.Items.Insert(0, New ListItem("", 0))

                'Dim cat As New clsCategoria
                'cboIDSegmento.DataSource = cat.Listar
                'cboIDSegmento.DataBind()
                'cboIDSegmento.Items.Insert(0, New ListItem("", 0))

                'Dim ope As New clsOperadora
                'cboIDOperadora.DataSource = ope.Listar
                'cboIDOperadora.DataBind()
                'cboIDOperadora.Items.Insert(0, New ListItem("", 0))


                drpIdStatus.Items.Insert(0, New ListItem("Ativo", "1"))
                drpIdStatus.Items.Insert(1, New ListItem("Inativo", "0"))

                subAddConfirm(btnApagar, "Deseja realmente apagar esta loja?")
                ViewState(VW_IDLOJA) = CInt("0" & Request("IDLoja"))
                cls.Load(ViewState(VW_IDLOJA))
                ViewState("CNPJValido") = False

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                BindCategoria()
                BindSubCategoria()
                BindProduto()

                validacaoCNPJ()
                MensagensErroPeronalizadas()

            Else
                cls.Load(ViewState(VW_IDLOJA))

            End If

            txtCNPJ.Enabled = VerificaPermissao(SecaoAtual, "Editar CNPJ")

        End Sub

        Private Sub MensagensErroPeronalizadas()
            valCompIDTipoLoja.ErrorMessage = SettingsExpression.GetProperty("caption", "Loja.TipoLoja", "Tipo de Loja") & " Incorreto."
            valCompIDCliente.ErrorMessage = SettingsExpression.GetProperty("caption", "Loja.FiltroRevenda", "Revenda") & " Incorreta."
        End Sub


        Private Sub validacaoCNPJ()

            If cls.isNew And ViewState("CNPJValido") = False Then

                trVerificaCNPJ.Visible = True
                trBotoesCNPJ.Visible = True

                trMainCadastro.Visible = False
                trBotoesMain.Visible = False
                phlOpcoes.Visible = False

            Else

                trVerificaCNPJ.Visible = False
                trBotoesCNPJ.Visible = False

                trMainCadastro.Visible = True
                trBotoesMain.Visible = True
                phlOpcoes.Visible = Not cls.isNew

                Inflate()

            End If

        End Sub

        Protected Sub Inflate()

            SetComboValue(drpIDCliente, cls.IDCliente)
			txtCodigo.Text = cls.Codigo
			me.PageName = cls.Codigo
            txtLoja.Text = cls.Loja
            If cls.isNew = False Then txtCNPJ.Text = cls.CNPJ
            'If VerificaPermissao(SecaoAtual, ACAO_EDITAR) = True Then
            '    txtCNPJ.Enabled = True
            'Else
            '    txtCNPJ.Enabled = False
            'End If
			txtIE.Text = cls.IE
			txtEndereco.Text = cls.Endereco
			txtNumero.Text = cls.Numero
			txtComplemento.Text = cls.Complemento
			txtBairro.Text = cls.Bairro
            txtCidade.Text = cls.Cidade
            txtRazaoSocial.Text = cls.RazaoSocial
            txtFilial.Text = cls.Filial

			txtCep.Text = cls.Cep
            txtTelefone.Text = cls.Telefone
			txtCelular.Text = cls.Celular
			txtFax.Text = cls.Fax
            txtEmail.Text = cls.Email
            txtGerenteLoja.Text = cls.GerenteLoja

            txtLatitude.Text = CStr(cls.Latitude & "").Replace(",", ".")
            txtLongitude.Text = CStr(cls.Longitude & "").Replace(",", ".")

            '****************************
            'SETANDO COMBOS
            '****************************
            setComboValue(drpIdUF, cls.UF)
            setComboValue(drpIDTipoLoja, cls.IDTipoLoja)
            setComboValue(drpIDRegiao, cls.IDRegiao)
            setComboValue(drpIdStatus, cls.Status)

            With tljTipoLoja
                .IdShopping = cls.IdShopping
                .TipoLoja = IIf(.IdShopping > 0, 1, 0)
            End With

            phlOpcoes.Visible = cls.IDLoja > 0
            BindProdutos()
            ImageUploaderLoja.Imagem = cls.Imagem

            With CamposAdicionais1
                .Entidade = "Loja"
                .CarregaDados(cls.IDLoja)
                .Visible = True
            End With

        End Sub


        Protected Sub BindProdutos()
            grdProdutos.DataSource = cls.ListarSegmentacao()
            grdProdutos.DataBind()
        End Sub

        Protected Sub Deflate()


            cls.IDCliente = getComboValues(drpIDCliente)

            If SettingsExpression.GetProperty("IsCNPJ", "Loja.Codigo", False) = False Then
                cls.Codigo = txtCodigo.Text
            Else
                cls.Codigo = txtCNPJ.Text
            End If

            cls.Loja = txtLoja.Text
            cls.RazaoSocial = txtRazaoSocial.Text
            cls.Filial = txtFilial.Text
            cls.CNPJ = txtCNPJ.Text
            cls.IE = txtIE.Text
            cls.Endereco = txtEndereco.Text
            cls.Numero = txtNumero.Text
            cls.Complemento = txtComplemento.Text
            cls.Bairro = txtBairro.Text
            cls.Cidade = txtCidade.Text
            cls.Cep = txtCep.Text
            cls.Telefone = txtTelefone.Text
            cls.Celular = txtCelular.Text
            cls.Fax = txtFax.Text
            cls.Email = txtEmail.Text
            cls.GerenteLoja = txtGerenteLoja.Text
            If IsNumeric(txtLatitude.Text) Then
                cls.Latitude = txtLatitude.Text
            End If
            If IsNumeric(txtLongitude.Text) Then
                cls.Longitude = txtLongitude.Text
            End If

            '****************************
            'SETANDO COMBOS
            '****************************
            cls.UF = drpIdUF.SelectedItem.Value
            cls.IDTipoLoja = getComboValue(drpIDTipoLoja)
            cls.IDRegiao = getComboValue(drpIDRegiao)
            cls.Status = getComboValue(drpIdStatus)
            cls.IDTipoLoja = getComboValues(drpIDTipoLoja)
            cls.IdShopping = IIf(tljTipoLoja.TipoLoja = 0, 0, tljTipoLoja.IdShopping)
            cls.Imagem = ImageUploaderLoja.Imagem

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                If Not ImageUploaderLoja.ShowSaveButton And ImageUploaderLoja.HasPostedFile Then
                    ImageUploaderLoja.Gravar()
                End If
                With CamposAdicionais1
                    .Entidade = "Loja"
                    .GravarDados(cls.IDLoja)
                End With
                MostraGravado("~/cadastros/Loja.aspx?idloja=" & cls.IDLoja)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Lojas.aspx")
        End Sub

        Protected Sub cboCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
            BindSubCategoria()
            BindProduto()
        End Sub

        Protected Sub cboSubCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCategoria.SelectedIndexChanged
            BindProduto()
        End Sub

        Protected Sub BindCategoria()
            Dim cat As New clsCategoria()
            cboCategoria.DataSource = cat.Listar()
            cboCategoria.DataBind()
            cboCategoria.Items.Insert(0, New ListItem("TODOS", "0"))
        End Sub

        Protected Sub BindSubCategoria()
            Dim sct As New clsSubCategoria()
            cboSubCategoria.DataSource = sct.Listar(cboCategoria.SelectedValue, DataClass.enReturnType.DataReader)
            cboSubCategoria.DataBind()
            cboSubCategoria.Items.Insert(0, New ListItem("TODAS", "0"))
        End Sub

        Protected Sub BindProduto()
            Dim prd As New clsProduto()
            cboProduto.DataSource = prd.Listar(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, DataClass.enReturnType.DataReader)
            cboProduto.DataBind()
            cboProduto.Items.Insert(0, New ListItem("TODOS", "0"))
        End Sub

        Protected Sub btnAddSegmentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSegmentacao.Click
            cls.AdicionarProdutos(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, cboProduto.SelectedValue)
            BindProdutos()
        End Sub

        Protected Sub grdProdutos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProdutos.RowCommand
            If e.CommandName = "Retirar" Then
                cls.RetirarProdutos(grdProdutos.DataKeys(e.CommandArgument).Value)
                BindProdutos()
            End If
        End Sub

        Sub CNPJValidation(ByVal source As Object, ByVal args As ServerValidateEventArgs)

            Try

                If txtVerificaCNPJ.Text <> "" Then
                    If cls.CNPJExiste(txtVerificaCNPJ.Text) Then
                        CustomValidator1.Visible = True
                        Console.WriteLine("CNPJ ja existe")
                        args.IsValid = False
                    End If
                End If

            Catch ex As Exception

                args.IsValid = False

            End Try

        End Sub

        Protected Sub btnValidarCNPJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidarCNPJ.Click

            If Page.IsValid Then
                ViewState("CNPJValido") = Page.IsValid
                txtCNPJ.Text = txtVerificaCNPJ.Text

                validacaoCNPJ()
            End If

        End Sub

        Protected Sub ImageUploaderLoja_onSavingFile(ByRef filename As String) Handles ImageUploaderLoja.onSavingFile
            filename = Guid.NewGuid.ToString() & IO.Path.GetExtension(filename)
        End Sub

        Protected Sub btnVerificarPosicao_Click(sender As Object, e As System.EventArgs) Handles btnVerificarPosicao.Click

            Dim strURL As String = System.Configuration.ConfigurationManager.AppSettings("apiGoogleMaps") & ""
            Dim strEndereco As String = txtEndereco.Text
            Dim strNumero As String = txtNumero.Text
            Dim strBairro As String = txtBairro.Text
            Dim strCidade As String = txtCidade.Text
            Dim strUF As String = drpIdUF.SelectedItem.Text

            If strEndereco <> "" Then strURL = strURL & strEndereco & "+"
            If strNumero <> "" Then strURL = strURL & strNumero & "+"
            If strBairro <> "" Then strURL = strURL & strBairro & "+"
            If strCidade <> "" Then strURL = strURL & strCidade & "+"
            If strUF <> "" Then strURL = strURL & strUF & "+"

            strURL &= "&sensor=true"

            Dim webRequest As System.Net.HttpWebRequest = Net.WebRequest.Create(strURL)
            Dim webResponse As System.Net.HttpWebResponse = webRequest.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(webResponse.GetResponseStream())
            Dim strReturn As String = sr.ReadToEnd()
            webResponse.Close()

            Dim myDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
            myDoc.LoadXml(strReturn)
            Dim root As System.Xml.XmlElement = myDoc.DocumentElement()
            Dim myNode1 As System.Xml.XmlNode = root.SelectSingleNode("result/geometry/location")
            Dim strLatitude As String = myNode1.SelectSingleNode("lat").InnerText
            Dim strLongitude As String = myNode1.SelectSingleNode("lng").InnerText
            txtLatitude.Text = strLatitude
            txtLongitude.Text = strLongitude

        End Sub

    End Class

End Namespace

