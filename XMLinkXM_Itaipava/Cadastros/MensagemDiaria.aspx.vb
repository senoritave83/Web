Imports System.Configuration.ConfigurationManager
Imports Classes
Imports System.IO
Imports XMSistemas.XMVirtualFile

Namespace Pages.Cadastros

    Partial Public Class MensagemDiaria
        Inherits XMWebPage

        Dim cls As clsMensagemDia
        Protected Const VW_IDMENSAGEMDIARIA As String = "IDMensagemDiaria"
        Protected Const SECAO As String = "Cadastro de Mensagens Diaria"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMensagemDia()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta mensagemgeral?")
                ViewState(VW_IDMENSAGEMDIARIA) = CInt("0" & Request("IDMensagemDiaria"))
                cls.Load(ViewState(VW_IDMENSAGEMDIARIA))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_APAGAR))



                Inflate()
            Else
                cls.Load(ViewState(VW_IDMENSAGEMDIARIA))
            End If
        End Sub

       


        Protected Sub Inflate()
            ' Dim path As System.Web.Hosting.VirtualDirectory = xmvp.GetDirectory(AppSettings("PathImage"))
            'Dim xmvp As New XMSistemas.XMVirtualFile.XMVirtualPath
            Dim savePath As String = AppSettings("PathImage")


            txtMensagem.Text = cls.Mensagem
            txtDataInicial.Text = cls.DataInicio
            txtDataFinal.Text = cls.DataFim
            ImagemFoto.ImageUrl = savePath + cls.Imagem

        End Sub

        Protected Sub Deflate()

            cls.DataInicio = txtDataInicial.Text
            cls.DataFim = txtDataFinal.Text
            cls.Mensagem = txtMensagem.Text
            cls.Imagem = ImagemFoto.ImageUrl

        End Sub

        
        Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
            If filUpload.HasFile Then
                Dim extension As String = filUpload.FileName.Substring(filUpload.FileName.LastIndexOf(".") + 1)
                Dim file_name As String = filUpload.FileName
                Dim vIdMensagemDiaria As Integer
                Dim savePath As String = AppSettings("PathImage")

                '   If ViewState(VW_IDMENSAGEMDIARIA) > 0 Then
                Try
                    vIdMensagemDiaria = (ViewState(VW_IDMENSAGEMDIARIA))
                    file_name = ("IMG" & vIdMensagemDiaria.ToString & "." & extension.ToLower)
                    cls.Imagem = file_name.ToString
                    cls.Update()

                    Dim xm As New XMSistemas.XMVirtualFile.XMFileStream(savePath & file_name & "." & extension.ToLower, IO.FileMode.CreateNew)
                    xm.Write(filUpload.PostedFile.InputStream)
                    xm.Close()

                Catch
                    cls.Delete(ViewState(VW_IDMENSAGEMDIARIA))
                    ShowMsg("Falha ao gravar a foto. Por favor tente novamente.")
                End Try


                'End If

            End If

            If (cls.IsNew() And VerificaPermissao(SECAO, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()

            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MensagemDiaria.aspx?idmensagemdiaria=" & cls.IDMensagemDiaria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()



        End Sub


       

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If filUpload.HasFile Then
                Dim extension As String = filUpload.FileName.Substring(filUpload.FileName.LastIndexOf(".") + 1)
                Dim file_name As String = filUpload.FileName
                Dim vIdMensagemDiaria As Integer
                Dim savePath As String = AppSettings("PathImage")

                Try


                    vIdMensagemDiaria = (ViewState(VW_IDMENSAGEMDIARIA))
                    file_name = ("IMG" & vIdMensagemDiaria.ToString & "." & extension.ToLower)
                    cls.Imagem = file_name.ToString
                    'cls.Update()

                    Dim xm As New XMSistemas.XMVirtualFile.XMFileStream(savePath & file_name & "." & extension.ToLower, IO.FileMode.CreateNew)

                    xm.Write(filUpload.PostedFile.InputStream)
                    xm.Close()

                Catch
                    cls.Delete(ViewState(VW_IDMENSAGEMDIARIA))
                    ShowMsg("Falha ao gravar a foto. Por favor tente novamente.")
                End Try


            End If


            If (cls.IsNew() And VerificaPermissao(SECAO, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()

            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MensagemDiaria.aspx?idmensagemdiaria=" & cls.IDMensagemDiaria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SECAO, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("MensagensDiarias.aspx")
            End If
        End Sub


    End Class

End Namespace

