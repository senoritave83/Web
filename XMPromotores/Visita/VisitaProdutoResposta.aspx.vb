
Imports Classes
Imports XMSistemas.XMVirtualFile

Namespace Pages.Visita

    Partial Public Class VisitaProdutoResposta
        Inherits XMWebPage
        Dim cls As clsVisitaProduto
        Protected Const VW_IDVISITA As String = "IDVisita"
        Protected Const VW_IDPRODUTO As String = "IDProduto"
        Protected Const VW_IDPERGUNTA As String = "IDPergunta"

        Dim bytTipoPergunta As Byte

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisitaProduto()
            If Not Page.IsPostBack Then
                ViewState(VW_IDVISITA) = CInt("0" & Request("IDVisita"))
                ViewState(VW_IDPRODUTO) = Cint("0" & Request("IDProduto"))
                ViewState(VW_IDPERGUNTA) = CInt("0" & Request("IDPergunta"))
                cls.Load(ViewState(VW_IDVISITA), ViewState(VW_IDPRODUTO))

                btnEditar.Enabled = VerificaPermissao(Secao, ACAO_EDITAR)
                Enabled = False

                Inflate()

                ExibirPergunta()

            Else
                cls.Load(ViewState(VW_IDVISITA), ViewState(VW_IDPRODUTO))
            End If
        End Sub

        Protected Sub ExibirPergunta()
            Dim dr As System.Data.IDataReader
            dr = cls.ListarPerguntas()
            Dim iTemp As Integer = 0
            Dim blnEncontrado As Boolean = False
            Dim strRespostaSimples As String = ""

            Do While dr.Read
                If dr.GetInt32(dr.GetOrdinal("IDPergunta")) = ViewState(VW_IDPERGUNTA) Then
                    If Not dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                        strRespostaSimples = dr.GetString(dr.GetOrdinal("Resposta"))
                        bytTipoPergunta = dr.GetByte(dr.GetOrdinal("Tipo"))
                    End If
                    blnEncontrado = True
                    Exit Do
                End If
            Loop
            If bytTipoPergunta <> 2 Then
                tblFotos.Visible = False
            End If
            dr.Close()
            dr.Dispose()

            If Not blnEncontrado Then
                Response.Redirect("visitaproduto.aspx?idvisita=" & ViewState(VW_IDVISITA) & "&idproduto=" & ViewState(VW_IDPRODUTO))
            Else
                pergunta1.Mostrar(ViewState(VW_IDPERGUNTA), cls.ListarRespostas(ViewState(VW_IDPERGUNTA)), strRespostaSimples)
            End If
        End Sub

        Protected Sub checkTipoPergunta()
            tblFotos.Visible = Not (bytTipoPergunta <> 2)
            pergunta1.FotoEnabled = Not (bytTipoPergunta <> 2)
        End Sub

        Protected Property Enabled() As Boolean
            Get
                Return pergunta1.Enabled
            End Get
            Set(ByVal value As Boolean)
                checkTipoPergunta()
                pergunta1.Enabled = value
                btnGravar.Enabled = value And VerificaPermissao(Secao, ACAO_EDITAR)
            End Set
        End Property

        Protected Sub Inflate()

            Dim clsProm As clsUsuario
            'Dim clsLid As clsLider
            Dim clsLoj As clsLoja
            Dim clsVis As clsVisita

            Try

                clsVis = New clsVisita()
                clsVis.Load(cls.IDVisita)

                clsProm = New clsUsuario
                clsProm.Load(clsVis.IDPromotor)
                If VirtualFile.FileExists("~/imagens/promotor/" & clsProm.Foto) Then
                    imgPromotor.ImageUrl = VirtualFile.GetDirectAccessUrl("~/imagens/promotor/" & clsProm.Foto)
                Else
                    imgPromotor.ImageUrl = "~/imagens/noimage.png"
                End If
                lblNomePromotor.Text = "Promotor: " & clsProm.Usuario
                lblTelefonePromotor.Text = IIf(clsProm.Telefone <> "", "Telefone: ", "") & clsProm.Telefone

                'Todo: Retornar a imagem do superior
                'clsLid = New clsLider
                'clsLid.Load(clsProm.IDLider)
                'If VirtualFile.FileExists("~/imagens/Lider/" & clsLid.Foto) Then
                '    imgLider.ImageUrl = VirtualFile.GetDirectAccessUrl("~/imagens/Lider/" & clsLid.Foto)
                'Else
                '    imgLider.ImageUrl = "~/imagens/noimage.png"
                'End If
                'lblNomeLider.Text = "Líder: " & clsLid.Lider
                'clsLid = Nothing

                clsLoj = New clsLoja
                clsLoj.Load(clsVis.IDLoja)
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
                clsLoj = Nothing
                clsVis = Nothing

            End Try
          
        End Sub


        Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            Dim colRespostas As Generic.List(Of String)
            colRespostas = pergunta1.GetRespostas()

            If colRespostas.Count > 0 Then
                cls.AdicionarRespostas(ViewState(VW_IDPERGUNTA), colRespostas.ToArray())
                Response.Redirect("visita.aspx?idvisita=" & ViewState(VW_IDVISITA))
            End If
        End Sub


        Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
            Enabled = True
        End Sub
    End Class

End Namespace

