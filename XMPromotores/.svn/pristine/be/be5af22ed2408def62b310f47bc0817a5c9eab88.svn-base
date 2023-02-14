Imports Classes
Imports System.Data
Imports System.Data.SqlClient
Imports XMSistemas.XMVirtualFile

Partial Class control_pergunta
    Inherits System.Web.UI.UserControl

    Public Property Width() As Unit
        Get
            Return divControl.Width
        End Get
        Set(ByVal value As Unit)
            divControl.Width = value
            imgRotator.Width = value
        End Set
    End Property

    Public Property Height() As Unit
        Get
            Return divControl.Height
        End Get
        Set(ByVal value As Unit)
            divControl.Height = value
            imgRotator.Height = value
        End Set
    End Property


    Public ReadOnly Property GetRespostas() As Generic.List(Of String)
        Get

            Dim colRespostas As New Generic.List(Of String)
            Dim blnOK As Boolean = True

            If txtResposta.Visible And txtResposta.Text <> "" Then

                Dim tipo As String = txtResposta.Attributes.Item("tipo") & ""
                Dim validar As String = txtResposta.Attributes.Item("validar") & ""

                If validar = "true" Then
                    If tipo.ToUpper = "INTEIRO" Then
                        If Not IsNumeric(txtResposta.Text) Then
                            lblMensagem.Text = "Resposta incorreta. A resposta deve conter apenas números"
                        Else
                            colRespostas.Add(txtResposta.Text)
                        End If
                    ElseIf tipo.ToUpper = "DATA" Then
                        If Not IsDate(txtResposta.Text) Then
                            lblMensagem.Text = "Resposta incorreta. Digite a data corretamente"
                        Else
                            colRespostas.Add(txtResposta.Text)
                        End If
                    Else
                        colRespostas.Add(txtResposta.Text)
                    End If
                Else
                    colRespostas.Add(txtResposta.Text)
                End If

            ElseIf chkLista.Visible Then
                For Each item As ListItem In chkLista.Items
                    If item.Selected Then
                        colRespostas.Add(item.Text)
                    End If
                Next
            ElseIf radLista.Visible Then
                For Each item As ListItem In radLista.Items
                    If item.Selected Then
                        colRespostas.Add(item.Text)
                    End If
                Next
            ElseIf cboLista.Visible Then
                For Each item As ListItem In cboLista.Items
                    If item.Selected Then
                        colRespostas.Add(item.Text)
                    End If
                Next
            End If

            Return colRespostas

        End Get
    End Property

    Public Property IDReferencia() As Integer
        Get
            If ViewState("IDReferencia") Is Nothing Then
                Return 0
            End If
            Return ViewState("IDReferencia")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDReferencia") = value
        End Set
    End Property

    Public Property UseCombo() As Boolean
        Get
            If ViewState("UseCombo") Is Nothing Then
                Return False
            End If
            Return ViewState("UseCombo")
        End Get
        Set(ByVal value As Boolean)
            ViewState("UseCombo") = value
        End Set
    End Property

    Public Property ShowCaption() As Boolean
        Get
            Return plhCaption.Visible
        End Get
        Set(ByVal value As Boolean)
            plhCaption.Visible = value
        End Set
    End Property

    Public Property onBlur() As String
        Get
            Return divControl.Attributes("onChangeFunction")
        End Get
        Set(ByVal value As String)
            txtResposta.Attributes("onBlur") = value
            ' chkLista.Attributes("onClick") = value
            cboLista.Attributes("onchange") = value
            divControl.Attributes.Add("onChangeFunction", value)
            radLista.Attributes("onClick") = value
        End Set
    End Property


    Public Property Enabled() As Boolean
        Get
            Return txtResposta.Enabled
        End Get
        Set(ByVal value As Boolean)
            txtResposta.Enabled = value
            chkLista.Enabled = value
            cboLista.Enabled = value
        End Set
    End Property

    Public Property FotoEnabled() As Boolean
        Get
            If ViewState("FotoEnabled") Is Nothing Then
                Return False
            End If
            Return ViewState("FotoEnabled")
        End Get
        Set(ByVal value As Boolean)
            ViewState("FotoEnabled") = value
        End Set
    End Property

    Private Function GetValue(ByVal data As Object, ByVal vName As String) As Object
        If TypeOf (data) Is System.Data.DataRow Then
            Return CType(data, DataRow).Item(vName)
        Else
            Return DataBinder.Eval(data, vName)
        End If
    End Function

    Public Sub VerificaExibicao(ByVal vIDPergunta As Integer)

        Dim prg As New clsPergunta
        prg.Load(vIDPergunta)

        If prg.TipoCampo = 0 Then

            txtResposta.Visible = False
            imgRotator.Visible = False

            chkLista.Visible = False
            cboLista.Visible = False
            radLista.Visible = False

            If prg.MultiResposta Then
                chkLista.Visible = True
            ElseIf UseCombo Then
                cboLista.Visible = True
            Else
                radLista.Visible = True
            End If

        ElseIf prg.TipoCampo = 2 Then

            radLista.Visible = False
            chkLista.Visible = False
            cboLista.Visible = False
            txtResposta.Visible = False
            imgRotator.Visible = True

        Else
            txtResposta.Visible = True
            radLista.Visible = False
            chkLista.Visible = False
            cboLista.Visible = False
            imgRotator.Visible = False
        End If

    End Sub

    Public Sub Mostrar(ByVal vIDPergunta As Integer, ByRef respostas As Object, ByVal strRespostaSimples As String)
        Dim prg As New clsPergunta

        hidUnica.Value = -1

        prg.Load(vIDPergunta)
        lblPergunta.Text = prg.Pergunta
        divControl.Attributes.Add("tipocampo", prg.TipoCampo)
        divControl.Attributes.Add("idpergunta", prg.IDPergunta)

        divControl.Attributes.Add("condicional", IIf(prg.Condicional, 1, 0))
        divControl.Attributes.Add("dependencia", prg.TipoDependencia)
        divControl.Attributes.Add("iddependente", prg.IDDependente)
        divControl.Attributes.Add("dependentevalor", prg.DependenteValor)
        divControl.Attributes.Add("idreferencia", IDReferencia())
        If prg.TipoCampo = 0 Then

            txtResposta.Visible = False
            imgRotator.Visible = False

            Dim e As IEnumerator = Nothing
            If TypeOf (respostas) Is IEnumerable Then
                e = respostas.GetEnumerator()
            ElseIf TypeOf (respostas) Is DataSet Then
                e = CType(respostas, DataSet).Tables(0).Rows.GetEnumerator()
            End If
            chkLista.Visible = False
            cboLista.Visible = False
            radLista.Visible = False
            If prg.MultiResposta Then
                chkLista.Visible = True
                chkLista.Items.Clear()
                With e
                    Do While e.MoveNext()
                        Dim li As New ListItem(Server.HtmlEncode(CStr(GetValue(e.Current, "Resposta"))))
                        li.Selected = CBool(GetValue(e.Current, "Selecionada"))
                        li.Attributes.Add("index", chkLista.Items.Count)
                        li.Attributes.Add("idresposta", GetValue(e.Current, "IDResposta"))
                        If GetValue(e.Current, "Acao") > 0 Then
                            li.Attributes.Add("condicional", 1)
                            li.Attributes.Add("acao", GetValue(e.Current, "Acao"))
                            li.Attributes.Add("acaovalor", GetValue(e.Current, "AcaoValor"))
                        Else
                            li.Attributes.Add("condicional", 0)
                        End If
                        If CBool(GetValue(e.Current, "Unica")) Then
                            hidUnica.Value = chkLista.Items.Count
                            li.Attributes.Add("unica", "true")
                        End If
                        chkLista.Items.Add(li)
                    Loop
                    chkLista.Attributes.Add("onClick", "verificaUnica(this, document." & Page.Form.ClientID + "." & hidUnica.ClientID & ".value, " & divControl.ClientID & ")")
                End With
                divControl.Attributes.Add("tipo", "list")
            ElseIf UseCombo Then
                cboLista.Visible = True
                cboLista.Items.Clear()
                cboLista.Items.Add("")
                With e
                    Do While e.MoveNext()
                        Dim li As New ListItem(CStr(GetValue(e.Current, "Resposta")))
                        li.Selected = CBool(GetValue(e.Current, "Selecionada"))
                        If GetValue(e.Current, "Acao") > 0 Then
                            li.Attributes.Add("condicional", 1)
                            li.Attributes.Add("acao", GetValue(e.Current, "Acao"))
                            li.Attributes.Add("acaovalor", GetValue(e.Current, "AcaoValor"))
                        Else
                            li.Attributes.Add("condicional", 0)
                        End If
                        cboLista.Items.Add(li)
                    Loop
                End With
                divControl.Attributes.Add("tipo", "combo")
            Else
                radLista.Visible = True
                radLista.Items.Clear()
                With e
                    Do While e.MoveNext()
                        Dim li As New ListItem(CStr(GetValue(e.Current, "Resposta")))
                        li.Selected = CBool(GetValue(e.Current, "Selecionada"))
                        radLista.Items.Add(li)
                    Loop
                End With
                divControl.Attributes.Add("tipo", "radio")
            End If
        ElseIf prg.TipoCampo = 2 Then

            radLista.Visible = False
            chkLista.Visible = False
            cboLista.Visible = False
            txtResposta.Visible = False

            If FotoEnabled Then
                Dim strImagePath As String = "~/imagens/fotos/"
                Dim strImages() As String = Split(strRespostaSimples, ",")

                For i As Integer = 0 To strImages.GetUpperBound(0)
                    If strImages(i).Trim() <> "" Then
                        If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                            imgRotator.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()))
                        Else
                            imgRotator.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                        End If
                    End If
                Next
                imgRotator.Visible = True
            Else
                imgRotator.Visible = False
                lblMensagem.Text = "Pergunta tipo Foto - não é possível o preenchimento!"
            End If
        Else
            txtResposta.Visible = True
            txtResposta.Text = strRespostaSimples
            If prg.TipoCampo = 1 Then
                txtResposta.Attributes.Add("tipo", "inteiro")
                txtResposta.Attributes.Add("opcoes", "format_inline")
                txtResposta.Attributes.Add("validar", "true")
            ElseIf prg.TipoCampo = 4 Then
                txtResposta.Attributes.Add("tipo", "moeda")
                txtResposta.Attributes.Add("opcoes", "format_inline")
                txtResposta.Attributes.Add("validar", "true")
            End If
            radLista.Visible = False
            chkLista.Visible = False
            cboLista.Visible = False
            imgRotator.Visible = False

            End If


    End Sub

    Public Sub RegisterScript()
        If Not Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType, "unique_script") Then
            Dim strScript As New StringBuilder(635)
            strScript.AppendFormat("<script type='text/javascript' language='javascript'>{0}", Environment.NewLine)
            strScript.AppendFormat("    function verificaUnica(obj, vUnico, campo){0}", Environment.NewLine)
            strScript.AppendFormat("    {{{0}", Environment.NewLine)
            strScript.AppendFormat("        var objs = obj.getElementsByTagName(""input""){0}", Environment.NewLine)
            'strScript.AppendFormat("        var vUnico = document.getElementById('" & hidUnica.ClientID & "').value;{0}", Environment.NewLine)
            strScript.AppendFormat("{0}", Environment.NewLine)
            strScript.AppendFormat("        var bUnico = false{0}", Environment.NewLine)
            strScript.AppendFormat("        {0}", Environment.NewLine)
            strScript.AppendFormat("        if (vUnico > -1){0}", Environment.NewLine)
            strScript.AppendFormat("        {{{0}", Environment.NewLine)
            strScript.AppendFormat("            if (objs[vUnico].checked == true){0}", Environment.NewLine)
            strScript.AppendFormat("            {{{0}", Environment.NewLine)
            strScript.AppendFormat("                for (var i = 0; i < objs.length; i++){0}", Environment.NewLine)
            strScript.AppendFormat("                {{{0}", Environment.NewLine)
            strScript.AppendFormat("                   if (i != vUnico){0}", Environment.NewLine)
            strScript.AppendFormat("                   {{{0}", Environment.NewLine)
            strScript.AppendFormat("                        objs[i].checked = false;{0}", Environment.NewLine)
            strScript.AppendFormat("                   }}{0}", Environment.NewLine)
            strScript.AppendFormat("                }}{0}", Environment.NewLine)
            strScript.AppendFormat("            }}{0}", Environment.NewLine)
            strScript.AppendFormat("        }}{0}", Environment.NewLine)
            strScript.AppendFormat("        if (campo.onChangeFunction != undefined) {{eval(campo.onChangeFunction);}}{0}", Environment.NewLine)
            strScript.AppendFormat("    }}{0}", Environment.NewLine)
            strScript.AppendFormat("</script>")
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "unique_script", strScript.ToString())
        End If
    End Sub


End Class
