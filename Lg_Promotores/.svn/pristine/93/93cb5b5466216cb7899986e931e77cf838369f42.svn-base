
Imports Classes
Imports XMSistemas.XMVirtualFile

Namespace Pages.Visita

    Partial Public Class VisitaPerguntaResposta
        Inherits XMWebPage
        Dim cls As clsVisita
        Protected Const VW_IDVISITA As String = "IDVisita"
        Protected Const VW_IDPERGUNTA As String = "IDPergunta"
        Protected Const VW_TIPOPERGUNTA As String = "TipoPergunta"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsVisita()
            If Not Page.IsPostBack Then

                ViewState(VW_IDVISITA) = CInt("0" & Request("IDVisita"))
                ViewState(VW_IDPERGUNTA) = CInt("0" & Request("IDPergunta"))
                ViewState(VW_TIPOPERGUNTA) = 0

                cls.Load(ViewState(VW_IDVISITA))

                Enabled = True
                Inflate()
                ExibirPergunta()
            Else
                cls.Load(ViewState(VW_IDVISITA))
            End If

        End Sub

        Protected Sub ExibirPergunta()
            Dim dr As System.Data.IDataReader
            dr = cls.ListarPerguntasLoja()

            Dim iTemp As Integer = 0
            Dim strRespostaSimples As String = ""
            Dim blnEncontrado As Boolean = False

            Do While dr.Read
                If dr.GetInt32(dr.GetOrdinal("IDPergunta")) = ViewState(VW_IDPERGUNTA) Then
                    If Not dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                        strRespostaSimples = dr.GetString(dr.GetOrdinal("Resposta"))
                        ViewState(VW_TIPOPERGUNTA) = dr.GetByte(dr.GetOrdinal("TipoCampo"))
                    End If
                    blnEncontrado = True
                    Exit Do
                End If
            Loop

            checkTipoPergunta()

            dr.Close()

            If Not blnEncontrado Then
                Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA"))
            Else
                pergunta1.Mostrar(ViewState(VW_IDPERGUNTA), cls.ListarRespostasLoja(ViewState(VW_IDPERGUNTA)), strRespostaSimples)
            End If

        End Sub

        Protected Sub checkTipoPergunta()
            tblFotos.Visible = Not (ViewState(VW_TIPOPERGUNTA) <> 2)
            pergunta1.FotoEnabled = Not (ViewState(VW_TIPOPERGUNTA) <> 2)
        End Sub

        Protected Property Enabled() As Boolean
            Get
                Return pergunta1.Enabled
            End Get
            Set(ByVal value As Boolean)
                checkTipoPergunta()
                pergunta1.Enabled = value
                btnEditar.Enabled = value And VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnGravar.Enabled = value And VerificaPermissao(SecaoAtual, ACAO_EDITAR)
            End Set
        End Property

        Protected Sub Inflate()

            Dim clsProm As clsPromotor
            Dim clsLid As clsLider
            Dim clsLoj As clsLoja

            Try

                clsProm = New clsPromotor
                clsProm.Load(cls.IDPromotor)
                If VirtualFile.FileExists("~/imagens/promotor/" & clsProm.Foto) Then
                    imgPromotor.ImageUrl = VirtualFile.GetDirectAccessUrl("~/imagens/promotor/" & clsProm.Foto)
                Else
                    imgPromotor.ImageUrl = "~/imagens/noimage.png"
                End If
                lblNomePromotor.Text = "Promotor: " & clsProm.Promotor
                lblTelefonePromotor.Text = IIf(clsProm.Telefone <> "", "Telefone: ", "") & clsProm.Telefone

                clsLid = New clsLider
                clsLid.Load(clsProm.IDLider)
                If VirtualFile.FileExists("~/imagens/Lider/" & clsLid.Foto) Then
                    imgLider.ImageUrl = VirtualFile.GetDirectAccessUrl("~/imagens/Lider/" & clsLid.Foto)
                Else
                    imgLider.ImageUrl = "~/imagens/noimage.png"
                End If
                lblNomeLider.Text = "Líder: " & clsLid.Lider

                clsLoj = New clsLoja
                clsLoj.Load(cls.IDLoja)
                If VirtualFile.FileExists("~/imagens/Contato_Loja/" & clsLoj.Imagem) Then
                    imgContatoLoja.ImageUrl = VirtualFile.GetDirectAccessUrl("~/imagens/Contato_Loja/" & clsLoj.Imagem)
                Else
                    imgContatoLoja.ImageUrl = "~/imagens/noimage.png"
                End If
                If clsLoj.Contato <> "" Then
                    lblContatoLoja.Text = IIf(clsLoj.Cargo <> "", clsLoj.Cargo & ": ", "Contato na Loja: ") & clsLoj.Contato
                    lblTelContatoLoja.Text = clsLoj.Telefone
                Else
                    lblContatoLoja.Text = "Contato na Loja"
                    lblTelContatoLoja.Text = ""
                End If

            Catch ex As Exception


            Finally

                clsProm = Nothing
                clsLid = Nothing
                clsLoj = Nothing

            End Try
        End Sub


        Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            Dim colRespostas As Generic.List(Of String)
            colRespostas = pergunta1.GetRespostas()

            If colRespostas.Count > 0 Then
                cls.AdicionarRespostasLoja(ViewState(VW_IDPERGUNTA), colRespostas.ToArray())
                Response.Redirect("visita.aspx?idvisita=" & ViewState(VW_IDVISITA))
            End If
        End Sub

        Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
            Enabled = True
        End Sub
    End Class

End Namespace

