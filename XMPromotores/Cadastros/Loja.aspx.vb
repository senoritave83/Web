Imports Classes
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics


Namespace Pages.Cadastros

    Partial Public Class Loja
        Inherits XMWebEditPage
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

                drpIdStatus.Items.Insert(0, New ListItem("Ativo", "1"))
                drpIdStatus.Items.Insert(1, New ListItem("Inativo", "0"))

                subAddConfirm(btnApagar, "Deseja realmente apagar esta loja?")
                ViewState(VW_IDLOJA) = CInt("0" & Request("IDLoja"))
                cls.Load(ViewState(VW_IDLOJA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))
                phlOpcoes.Visible = Not cls.isNew

                ExibirValidacao()
                MensagensErroPeronalizadas()

            Else
                cls.Load(ViewState(VW_IDLOJA))

            End If

            txtCNPJ.Enabled = VerificaPermissao(Secao, "Editar CNPJ")

        End Sub

        Private Sub MensagensErroPeronalizadas()
            valCompIDTipoLoja.ErrorMessage = SettingsExpression.GetProperty("caption", "Loja.TipoLoja", "Tipo de Loja") & " Incorreto."
            valCompIDCliente.ErrorMessage = SettingsExpression.GetProperty("caption", "Loja.FiltroRevenda", "Revenda") & " Incorreta."
        End Sub

        Private Sub ExibirValidacao()

            If cls.isNew And (SettingsExpression.GetProperty("required", " Loja.CNPJ", True) = True Or SettingsExpression.GetProperty("validate", " Loja.CNPJ", True) = True) Then

                trVerificaCNPJ.Visible = True
                trBotoesCNPJ.Visible = True

                trMainCadastro.Visible = False
                trBotoesMain.Visible = False

            Else

                trVerificaCNPJ.Visible = False
                trBotoesCNPJ.Visible = False

                trMainCadastro.Visible = True
                trBotoesMain.Visible = True

                Inflate()

            End If

        End Sub

        Private Sub validacaoCNPJ(ByVal p_Exibir As Boolean)

            Dim blnValidarCNPJ As Boolean = False

            If cls.isNew Then

                If SettingsExpression.GetProperty("required", " Loja.CNPJ", True) = True Then

                    If p_Exibir = False Then blnValidarCNPJ = True

                ElseIf SettingsExpression.GetProperty("validate", " Loja.CNPJ", True) = True Then

                    If p_Exibir = False Then blnValidarCNPJ = True

                Else

                    blnValidarCNPJ = True

                End If

            End If

            trVerificaCNPJ.Visible = blnValidarCNPJ
            trBotoesCNPJ.Visible = blnValidarCNPJ

            trMainCadastro.Visible = Not blnValidarCNPJ
            trBotoesMain.Visible = Not blnValidarCNPJ

            If trMainCadastro.Visible Then Inflate()

        End Sub

        Protected Sub Inflate()


            If SettingsExpression.GetProperty("IsCNPJ", "Loja.Codigo", False) = True Or SettingsExpression.GetProperty("CodigoAutomatico", "Loja.Codigo", False) = True Then
                txtCodigo.ReadOnly = True
            Else
                txtCodigo.ReadOnly = False
            End If

            setComboValue(drpIDCliente, cls.IDCliente)
            txtCodigo.Text = cls.Codigo
            Me.PageName = cls.Codigo
            txtLoja.Text = cls.Loja
            If cls.isNew = False Then txtCNPJ.Text = cls.CNPJ

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
            txtObservacao.Text = cls.Observacoes

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
            ImageUploaderLoja.Imagem = cls.Imagem

            With CamposAdicionais1
                .Entidade = "Loja"
                .CarregaDados(cls.IDLoja)
                .Visible = True
            End With

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Loja, cls.IDLoja)

        End Sub


        Protected Sub Deflate()


            cls.IDCliente = getComboValues(drpIDCliente)
            'If m_strCodigo = "" Then
            '    AddBrokenRule("O c�digo � obrigatorio!")
            '    blnValid = False
            'ElseIf Existe(m_intIDLoja, m_strCodigo) Then
            '    AddBrokenRule("O Codigo informado ja existe!")
            '    blnValid = False
            'ElseIf CNPJExiste(m_strCNPJ) Then
            '    blnValid = False
            '    AddBrokenRule("O CNPJ j� existe!")
            'End If
            'Return blnValid

            '*****************************************************************************
            ''VERIFICA��O DE CADASTRO DOS C�DIGOS DAS LOJAS
            ''REGRAS:
            '' 1 - verificar se c�digo ser� baseado no CNPJ
            '' 2 - verificar se campo c�digo ir� aparecer na tela ou n�o
            '' 3 - se o campo n�o for baseado no CNPJ, verificar se o c�digo ser� definido pelo usu�rio ou pelo sistema
            ''    3a - se n�o aparecer na tela, deve ser definido pelo sistema
            ''    3b - se aparecer na tela e for definido pelo usu�rio, n�o pode deixar utilizar um c�digo j� existente
            ''    3c - se aparecer na tela e n�o for definido pelo usu�rio, utilizar o Id da Loja
            '*****************************************************************************
            If SettingsExpression.GetProperty("codigoautomatico", "Loja.Codigo", False) = True Then
                If SettingsExpression.GetProperty("IsCNPJ", "Loja.Codigo", False) = True Then
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_IGUAL_CNPJ
                    cls.Codigo = txtCNPJ.Text
                Else
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_AUTOMATICO
                    cls.Codigo = txtCodigo.Text
                End If
            Else
                If cls.isNew Then
                    If txtCodigo.Visible = True And txtCodigo.ReadOnly = False Then
                        cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_DEFINIDO_PELO_USUARIO
                        If cls.Existe(0, txtCodigo.Text) Then
                            cls.AddBrokenRule("C�digo informado j� existe")
                        End If
                    Else
                        cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_AUTOMATICO
                    End If
                Else
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_DEFINIDO_PELO_USUARIO
                    If cls.Existe(cls.IDLoja, txtCodigo.Text) Then
                        cls.AddBrokenRule("C�digo informado j� existe")
                    End If
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_DEFINIDO_PELO_USUARIO
                End If
                cls.Codigo = txtCodigo.Text
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
            cls.Observacoes = txtObservacao.Text

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

        <System.Web.Script.Services.ScriptMethod(), _
        System.Web.Services.WebMethod()> _
        Public Shared Function ProcurarBandeiras(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

            Dim ban As New clsCliente
            Dim lstBandeiras As New List(Of String)
            Dim sdr As System.Data.SqlClient.SqlDataReader = ban.Listar_AutoComplete(prefixText, count)
            While sdr.Read
                Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr(1).ToString(), sdr(0).ToString())
                lstBandeiras.Add(item)
            End While
            Return lstBandeiras

        End Function

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then

                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Loja, cls.IDLoja)

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

        Sub ValidarCodigo(sender As Object, e As ServerValidateEventArgs)

            e.IsValid = True

            If SettingsExpression.GetProperty("codigoautomatico", "Loja.Codigo", False) = True Then
                If SettingsExpression.GetProperty("IsCNPJ", "Loja.Codigo", False) = True Then
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_IGUAL_CNPJ
                    cls.Codigo = txtCNPJ.Text
                Else
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_AUTOMATICO
                    cls.Codigo = txtCodigo.Text
                End If
            Else
                If cls.isNew Then
                    If txtCodigo.Visible = True And txtCodigo.ReadOnly = False Then
                        cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_DEFINIDO_PELO_USUARIO
                        If cls.Existe(0, txtCodigo.Text) Then
                            e.IsValid = False
                        End If
                    Else
                        cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_AUTOMATICO
                    End If
                Else
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_DEFINIDO_PELO_USUARIO
                    If cls.Existe(cls.IDLoja, txtCodigo.Text) Then
                        e.IsValid = False
                    End If
                    cls.TipoCadastroCodigo = clsLoja.TIPO_CADASTRO_CODIGO.CODIGO_DEFINIDO_PELO_USUARIO
                End If
                cls.Codigo = txtCodigo.Text
            End If

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Loja, cls.IDLoja)

                cls.Delete()
                Response.Redirect("Lojas.aspx")
            End If
        End Sub

        Sub CNPJValidation(ByVal source As Object, ByVal args As ServerValidateEventArgs)

            Try

                If txtVerificaCNPJ.Text <> "" Then
                    If cls.CNPJExiste(txtVerificaCNPJ.Text) Then

                        args.IsValid = False
                    End If
                End If

            Catch ex As Exception

                args.IsValid = False

            End Try

        End Sub

        Protected Sub btnValidarCNPJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidarCNPJ.Click

            If Page.IsValid Then
                If Not cls.CNPJExiste(txtVerificaCNPJ.Text) Then
                    txtCNPJ.Text = txtVerificaCNPJ.Text

                    trVerificaCNPJ.Visible = False
                    trBotoesCNPJ.Visible = False

                    trMainCadastro.Visible = True
                    trBotoesMain.Visible = True

                    txtCNPJ.Enabled = False
                Else
                    lstErros.Items.Add("O CNPJ digitado j� Existe!")

                End If

            End If

        End Sub

        Protected Sub ImageUploaderLoja_onSavingFile(ByRef filename As String) Handles ImageUploaderLoja.onSavingFile
            filename = Guid.NewGuid.ToString() & IO.Path.GetExtension(filename)
        End Sub

       
        Protected Sub btnVerificarPosicao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerificarPosicao.Click

           

            Dim strURL As String = System.Configuration.ConfigurationManager.AppSettings("apiGoogleMaps") & ""
            Dim strEndereco As String = txtEndereco.Text
            Dim strNumero As String = txtNumero.Text
            Dim strBairro As String = txtBairro.Text
            Dim strCidade As String = txtCidade.Text
            Dim strUF As String = drpIdUF.SelectedItem.Text

            If strEndereco = "" Then
                Dim strMessage As String
                Dim lblEnderecoVazio As New Label()
                strMessage = "Voce Precisa Preencher o Endere�o"
                lblEnderecoVazio.Text = strMessage
            Else
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

            End If

        End Sub
    End Class

End Namespace

