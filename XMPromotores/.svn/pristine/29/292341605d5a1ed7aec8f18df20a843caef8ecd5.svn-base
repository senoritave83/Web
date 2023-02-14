Imports Classes
Imports System.Data

Partial Class formulario_pergunta

    Inherits XMWebPage

    Protected cls As clsFormVisita

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita

        If Not Page.IsPostBack Then
            IDVisita = Request("idvisita")
            TipoEntidade = Request("tipoentidade")
            IDReferencia = Request("idreferencia")
            IDCurrentPergunta = Request("idpergunta")
            pergunta1.RegisterScript()
        End If

        cls.Load(ViewState("IDVISITA"))

        If Not Page.IsPostBack Then
            ExibirPergunta()
        End If

    End Sub

    Protected Property IDVisita() As Integer
        Get
            Return CInt("0" & ViewState("IDVISITA"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IDVISITA") = value
        End Set
    End Property

    Protected Property TipoEntidade() As Byte
        Get
            Return CInt("0" & ViewState("TIPOENTIDADE"))
        End Get
        Set(ByVal value As Byte)
            ViewState("TIPOENTIDADE") = value
        End Set
    End Property

    Protected Property IDReferencia() As Integer
        Get
            Return CInt("0" & ViewState("IDREFERENCIA"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IDREFERENCIA") = value
        End Set
    End Property

    Protected Property IDCurrentPergunta() As Integer
        Get
            Return CInt("0" & ViewState("IDCURRENTPERGUNTA"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IDCURRENTPERGUNTA") = value
        End Set
    End Property


    Protected Sub ExibirPergunta()
        Dim dr As IDataReader
        dr = cls.ListarPerguntasEntidade(TipoEntidade, IDReferencia)
        Dim iTemp As Integer = 0
        Dim blnEncontrado As Boolean = False
        Dim strRespostaSimples As String = ""
        Do While dr.Read
            If dr.GetInt32(dr.GetOrdinal("IDPergunta")) = IDCurrentPergunta Then
                If Not dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                    strRespostaSimples = dr.GetString(dr.GetOrdinal("Resposta"))
                End If
                blnEncontrado = True
                Exit Do
            End If
        Loop
        dr.Close()
        dr.Dispose()

        If Not blnEncontrado Then
            Response.Redirect("visita.aspx?idvisita=" & IDVisita)
        Else
            pergunta1.Mostrar(IDCurrentPergunta, cls.ListarRespostasEntidade(TipoEntidade, IDReferencia, IDCurrentPergunta), strRespostaSimples)
        End If

    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        Dim colRespostas As Generic.List(Of String)
        colRespostas = pergunta1.GetRespostas()

        If colRespostas.Count > 0 Then
            cls.AdicionarRespostasEntidade(TipoEntidade, IDReferencia, IDCurrentPergunta, colRespostas.ToArray())
            Response.Redirect("visita.aspx?idvisita=" & IDVisita)
        Else
            pergunta1.VerificaExibicao(IDCurrentPergunta)
        End If
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("visita.aspx?idvisita=" & IDVisita)
    End Sub
End Class
