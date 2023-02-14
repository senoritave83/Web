Imports Classes
Imports System
Imports System.Data

Partial Class TesteFreezeTable
    Inherits System.Web.UI.Page

    Protected Const ACAO_ADICIONAR As String = "Adicionar"
    Protected Const ACAO_EDITAR As String = "Editar"
    Protected Const ACAO_APAGAR As String = "Apagar"
    Public Const PAGESIZE As Integer = 10

    Private lstDays As Collections.Generic.List(Of Date)
    Private lstDaysFolga As Collections.Generic.List(Of Date)

    Private m_strComboInterno As String

    Public Class DiaLoja


        Protected _Selecionado As clsRoteiroPeriodo.SelectionState
        Protected _HoraRoteiroLojaInicio As String
        Protected _HoraRoteiroLojaFim As String
        Protected _HoraRoteiroLojaAlmocoInicio As String
        Protected _HoraRoteiroLojaAlmocoFim As String
        Protected _IDLoja As Integer
        Protected _Data As Date
        Protected _DiaFolga As Boolean
        Protected _Pesquisa As Boolean

#Region "Properties"

        Public Property Selecionado() As clsRoteiroPeriodo.SelectionState
            Get
                Return _Selecionado
            End Get
            Set(ByVal value As clsRoteiroPeriodo.SelectionState)
                _Selecionado = value
            End Set
        End Property

        Public Property IDLoja() As Integer
            Get
                Return _IDLoja
            End Get
            Set(ByVal value As Integer)
                _IDLoja = value
            End Set
        End Property

        Public Property Data() As Date
            Get
                Return _Data
            End Get
            Set(ByVal value As Date)
                _Data = value
            End Set
        End Property

        Public Property HoraInicio() As String
            Get
                Return _HoraRoteiroLojaInicio
            End Get
            Set(ByVal value As String)
                _HoraRoteiroLojaInicio = value
            End Set
        End Property

        Public Property HoraFim() As String
            Get
                Return _HoraRoteiroLojaFim
            End Get
            Set(ByVal value As String)
                _HoraRoteiroLojaFim = value
            End Set
        End Property

        Public Property HoraAlmocoInicio() As String
            Get
                Return _HoraRoteiroLojaAlmocoInicio
            End Get
            Set(ByVal value As String)
                _HoraRoteiroLojaAlmocoInicio = value
            End Set
        End Property

        Public Property HoraAlmocoFim() As String
            Get
                Return _HoraRoteiroLojaAlmocoFim
            End Get
            Set(ByVal value As String)
                _HoraRoteiroLojaAlmocoFim = value
            End Set
        End Property

        Public Property Pesquisa() As Boolean
            Get
                Return _Pesquisa
            End Get
            Set(ByVal value As Boolean)
                _Pesquisa = value
            End Set
        End Property

        Public Property DiaFolga() As Boolean
            Get
                Return _DiaFolga
            End Get
            Set(ByVal value As Boolean)
                _DiaFolga = value
            End Set
        End Property

#End Region

    End Class

    Protected Const VW_IDPROMOTOR As String = "IDPromotor"
    Protected Const VW_IDTIPO As String = "IDTipo"

    Protected Function getDias() As Collections.Generic.List(Of Date)
        If lstDays Is Nothing Then MontaDias()
        Return lstDays
    End Function

    Protected Function GetDiasLoja(ByVal vIDLoja As Integer) As Generic.List(Of DiaLoja)
        Dim r As New clsRoteiroPeriodo
        Dim ret As New Generic.List(Of DiaLoja)
        For Each d As Date In getDias()
            Dim rotLojaDia As clsRoteiroPeriodo.LojaRoteiroDia = r.VerificaLojaRoteiroDia(ViewState(VW_IDPROMOTOR), vIDLoja, d)
            Dim t As New DiaLoja
            t.Data = d
            t.IDLoja = vIDLoja
            t.Selecionado = rotLojaDia.Selection
            t.HoraInicio = rotLojaDia.HoraInicio
            t.HoraFim = rotLojaDia.HoraFim
            t.HoraAlmocoInicio = rotLojaDia.HoraAlmocoInicio
            t.HoraAlmocoFim = rotLojaDia.HoraAlmocoFim
            t.DiaFolga = rotLojaDia.DiaFolga
            t.Pesquisa = rotLojaDia.Pesquisa
            ret.Add(t)
        Next
        Return ret
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            '*****************************************************************
            'RECUPERA AS DATAS PASSADAS PELO REDIRECT DO BOTÃO CONFIRMAR CÓPIA
            '*****************************************************************
            Dim diCopiaInicial As String = Request("di")
            Dim diCopiaFinal As String = Request("df")
            If diCopiaInicial <> "" Then diCopiaInicial = XMCrypto.Decrypt(diCopiaInicial)
            If diCopiaFinal <> "" Then diCopiaFinal = XMCrypto.Decrypt(diCopiaFinal)

            txtDataInicial.Text = IIf(diCopiaInicial = "", Now.ToString("dd/MM/yyyy"), diCopiaInicial)
            txtDataFinal.Text = IIf(diCopiaFinal = "", Now.AddDays(4).ToString("dd/MM/yyyy"), diCopiaFinal)

            ViewState(VW_IDPROMOTOR) = CInt("0" & Request("IDPromotor"))
            ViewState("IDSTATUSPROMOTOR") = CInt("0" & Request("st"))

            Dim pro As New clsPromotor()
            pro.Load(ViewState(VW_IDPROMOTOR))
            lblPromotor.Text = pro.Promotor
            pro = Nothing

            Dim uf As New clsEstado
            cboUF.DataSource = uf.Listar
            cboUF.DataBind()
            cboUF.Items.Insert(0, New ListItem("TODOS", ""))
            uf = Nothing

            Dim tlj As New clsTipoLoja
            cboIDTipoLoja.DataSource = tlj.Listar
            cboIDTipoLoja.DataBind()
            cboIDTipoLoja.Items.Insert(0, New ListItem("TODOS", 0))
            tlj = Nothing

            Dim reg As New clsRegiao
            cboIDRegiao.DataSource = reg.Listar
            cboIDRegiao.DataBind()
            cboIDRegiao.Items.Insert(0, New ListItem("TODAS", 0))
            reg = Nothing

            With CType(Page, XMWebPage)
                btnGravar.Enabled = IIf(ViewState("IDSTATUSPROMOTOR") = 0, False, .VerificaPermissao(.SecaoAtual, ACAO_EDITAR))
                plhLojas.Visible = IIf(ViewState("IDSTATUSPROMOTOR") = 0, False, True)
            End With
            btnFiltrar_Click(sender, e)

        End If

        plhLojas.Visible = IIf(ViewState("IDSTATUSPROMOTOR") = 0, False, True)

    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click

        plhImportarRoteiro.Visible = False
        plhRoteiro.Visible = True
        plhLojas.Visible = True

        MontaDias()
        BindGrid()

    End Sub

    Protected Sub BindGrid()

        Dim dr As IDataReader = Nothing
        Dim drIdLojas As IDataReader = Nothing
        Try
            Dim r As New clsRoteiroPeriodo

            dr = r.ListarLojas(ViewState(VW_IDPROMOTOR))
            rptLojas.DataSource = dr
            rptLojas.DataBind()
            plhRoteiro.Visible = True
            lblNumeroLojas.Text = rptLojas.Items.Count()

        Finally
            If Not (dr Is Nothing) Then
                dr.Close()
                dr.Dispose()
                dr = Nothing
            End If
        End Try

    End Sub

    Private Sub MontaDias()
        lstDays = New Collections.Generic.List(Of Date)
        Dim dtInicial As Date = CDate(txtDataInicial.Text)
        Dim dtStep As Date
        For i As Integer = 0 To DateDiff(DateInterval.Day, CDate(txtDataInicial.Text), CDate(txtDataFinal.Text))
            dtStep = dtInicial.AddDays(i)
            lstDays.Add(dtStep)
        Next
    End Sub

    Protected Sub CarregaCombo(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)

        If (e.Item.ItemType = ListItemType.Item) Or _
            (e.Item.ItemType = ListItemType.AlternatingItem) Then

            Dim clsMF As New clsMotivoFolga

            Dim lt As Literal = e.Item.FindControl("ltTeste")
            Dim strCombo As String = ""

            strCombo = "<select id='cboFolga_" & Format(e.Item.DataItem, "yyyyMMdd")
            strCombo &= "' style='width:150px;' name='cboFolga_" & Format(e.Item.DataItem, "yyyyMMdd")
            strCombo &= "' title='Indique o motivo da Folga' size='1' "
            If VerificaDiaFolga(e.Item.DataItem) = False Then
                strCombo &= " disabled "
            End If
            strCombo &= " >"

            Dim dr As Data.SqlClient.SqlDataReader = clsMF.Listar
            strCombo &= "<option " & IIf(VerificaFolgaMotivo(e.Item.DataItem) = "0", "selected", "") & " value='0'>Selecione..</option>"
            Do While dr.Read
                strCombo &= "<option " & IIf(VerificaFolgaMotivo(e.Item.DataItem) = dr("IdMotivoFolga"), "selected", "") & " value='" & dr("IdMotivoFolga") & "'>" & dr("MotivoFolga") & "</option>"
            Loop
            strCombo &= " </select>"

            lt.Text = strCombo

        End If

    End Sub

    Private Sub MontaDiasFolga()

        lstDaysFolga = New Collections.Generic.List(Of Date)
        Dim r As New clsRoteiroPeriodo
        Dim dr As IDataReader = r.ListarDiasFolgaPromotor(ViewState(VW_IDPROMOTOR), txtDataInicial.Text, txtDataFinal.Text)

        Do While dr.Read
            lstDaysFolga.Add(dr(3))
        Loop

        r = Nothing

    End Sub

    Public Function VerificaDiaFolga(ByVal vData As Date) As Boolean

        If lstDaysFolga Is Nothing Then MontaDiasFolga()
        Return lstDaysFolga.Contains(vData)

    End Function

    Public Function VerificaFolgaMotivo(ByVal vData As Date) As Integer

        Dim r As New clsRoteiroPeriodo
        Return r.ListarDiasFolgaMotivoPromotor(ViewState(VW_IDPROMOTOR), vData)

    End Function

    Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        Paginate1.CurrentPage = 0
        ProcurarLojas()
    End Sub

    Protected Sub ProcurarLojas()
        Dim loj As New clsLoja
        Dim ret As PaginateResult = loj.Listar(txtProcurarLoja.Text, 0, cboUF.Text, cboIDTipoLoja.SelectedValue, 0, cboIDRegiao.SelectedValue, "", False, Paginate1.CurrentPage, PAGESIZE, txtProcurarCidade.Text)
        grdProcurar.DataSource = ret.Data
        grdProcurar.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing
    End Sub


    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ProcurarLojas()
    End Sub

    Protected Sub rptLojas_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptLojas.ItemCommand
        Dim cls As New clsRoteiroPeriodo()
        If e.CommandName = "RetirarLoja" Then
            cls.RetiraLoja(ViewState(VW_IDPROMOTOR), e.CommandArgument)
            BindGrid()
        End If
    End Sub

    Protected Sub grdProcurar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcurar.RowCommand
        Dim cls As New clsRoteiroPeriodo()
        If e.CommandName = "AdicionarLoja" Then
            cls.AdicionaLoja(ViewState(VW_IDPROMOTOR), grdProcurar.DataKeys(e.CommandArgument).Value)
            BindGrid()
        End If
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        If Page.IsValid Then

            Dim cls As New clsRoteiroPeriodo()
            Dim p_IdLojas As Object = (Request("IdLoja") & "").Split(",")
            Dim strDadosRoteiro As String = ""
            Dim blnAlterouDados As Boolean = False
            Dim intFolgaMotivo As Integer = 0
            Dim vPesquisa As String = ""
            Dim vFolga As String = ""

            For Each DiaCheck As Date In getDias()


                If TypeOf p_IdLojas Is System.Array Then

                    If CType(p_IdLojas, System.Array).Length > 0 Then

                        For Each objIdLoja As Object In p_IdLojas

                            Dim IdLoja As String = Request("hid_Dia_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd"))
                            vPesquisa = Request("Dia_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd"))
                            vPesquisa = IIf(vPesquisa Is Nothing, "", vPesquisa)

                            vFolga = Request("DiaFolga_" & Format(DiaCheck, "yyyyMMdd"))
                            If vFolga Is Nothing Then
                                vFolga = False
                            Else
                                vFolga = True
                            End If

                            Dim HoraInicio As String = Request("HoraInicio_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
                            Dim HoraFim As String = Request("HoraFim_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
                            Dim HoraAlmocoInicio As String = Request("HoraAlmocoInicio_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
                            Dim HoraAlmocoFim As String = Request("HoraAlmocoFim_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""

                            If HoraAlmocoInicio = "" Or HoraAlmocoFim = "" Then
                                HoraAlmocoInicio = ""
                                HoraAlmocoFim = ""
                            End If
                            intFolgaMotivo = Request("cboFolga_" & Format(DiaCheck, "yyyyMMdd")) & ""
                            If strDadosRoteiro <> "" Then
                                strDadosRoteiro &= "||"
                            End If
                            strDadosRoteiro &= IdLoja & "," & HoraInicio & "," & HoraFim & "," & HoraAlmocoInicio & "," & HoraAlmocoFim & "," & IIf(vPesquisa <> "", 1, 0)

                        Next

                    End If

                End If

                cls.GravaRoteiro(ViewState(VW_IDPROMOTOR), DiaCheck, strDadosRoteiro, IIf(vFolga, 1, 0), intFolgaMotivo)
                strDadosRoteiro = ""
                blnAlterouDados = True

            Next

            If blnAlterouDados Then BindGrid()

        End If

    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("promotor_roteiro.aspx?idpromotor=" & ViewState(VW_IDPROMOTOR) & "&st=" & ViewState("IDSTATUSPROMOTOR"))
    End Sub

    Protected Sub rptDias_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)

        If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then

            Dim img As HtmlImage = e.Item.FindControl("imgCopiarHorarios")
            If Not img Is Nothing Then
                With img
                    .Attributes.Add("onClick", "javas" & "cript:CopiarHorarios('" & DataBinder.Eval(e.Item.DataItem, "IdLoja") & "','" & txtDataInicial.Text & "','" & Format(DataBinder.Eval(e.Item.DataItem, "Data"), "yyyyMMdd") & "');")
                    .Attributes.Add("onMouseOver", "this.style.cursor='hand';")
                    .Src = "~/imagens/copiar.jpg"
                    .Alt = "Copiar horários anteriores"
                    .Disabled = (ViewState("IDSTATUSPROMOTOR") = 0)
                End With
            End If

        End If

    End Sub

    Protected Sub btnImportRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportRoteiro.Click

        plhImportarRoteiro.Visible = True
        plhLojas.Visible = False
        btnFiltrar.Visible = False
        btnGravar.Visible = False
        btnImportRoteiro.Visible = False
        btnConfirmar.Visible = True
        btnCancelarCopiaRoteiro.Visible = True

        txtImportDataInicial.Text = ""
        txtImportDataFinal.Text = ""

        Dim promo As New clsPromotor()
        cboIDPromotor.DataSource = promo.Listar
        cboIDPromotor.DataBind()
        cboIDPromotor.Items.Insert(0, New ListItem("Selecione o promotor...", 0))
        setComboValue(cboIDPromotor, ViewState(VW_IDPROMOTOR))
        promo = Nothing

    End Sub


    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click

        If Page.IsValid Then

            Dim r As New clsRoteiroPeriodo
            Dim dr As DataSet = r.ListarLojas(ViewState(VW_IDPROMOTOR), DataClass.enReturnType.DataSet)
            lblNumeroLojas.Text = dr.Tables(0).Rows.Count

            Dim cls As New clsRoteiroPeriodo()
            Dim p_IdLojas As Object = (Request("IdLoja") & "").Split(",")
            Dim strDadosRoteiro As String = ""
            Dim blnAlterouDados As Boolean = False
            Dim intFolgaMotivo As Integer = 0
            Dim strDiaCopia As String = txtImportDataInicial.Text
            Dim strDiaCopiaFinal As String = txtImportDataFinal.Text
            Dim intIdPromotorCopia As Integer = getComboValue(cboIDPromotor)
            Dim vFolga As String = ""

            Dim pro As New clsPromotor()
            pro.Load(intIdPromotorCopia)
            ViewState("IDSTATUSPROMOTOR") = pro.IdStatus


            For Each DiaCheck As Date In getDias()

                If CDate(strDiaCopia) <= CDate(strDiaCopiaFinal) Then

                    If TypeOf p_IdLojas Is System.Array Then

                        If CType(p_IdLojas, System.Array).Length > 0 Then

                            For Each objIdLoja As Object In p_IdLojas

                                Dim IdLoja As String = Request("hid_Dia_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd"))
                                Dim vPesquisa As String = Request("Dia_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd"))
                                vFolga = Request("DiaFolga_" & Format(DiaCheck, "yyyyMMdd"))

                                Dim HoraInicio As String = Request("HoraInicio_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
                                Dim HoraFim As String = Request("HoraFim_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
                                Dim HoraAlmocoFim As String = Request("HoraAlmocoInicio_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
                                Dim HoraAlmocoInicio As String = Request("HoraAlmocoFim_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""

                                If HoraInicio <> "" And HoraFim <> "" Then

                                    If HoraAlmocoInicio = "" Or HoraAlmocoFim = "" Then
                                        HoraAlmocoInicio = ""
                                        HoraAlmocoFim = ""
                                    End If
                                    intFolgaMotivo = Request("cboFolga_" & Format(DiaCheck, "yyyyMMdd")) & ""
                                    If strDadosRoteiro <> "" Then
                                        strDadosRoteiro &= "||"
                                    End If
                                    strDadosRoteiro &= IdLoja & "," & HoraInicio & "," & HoraFim & "," & HoraAlmocoInicio & "," & HoraAlmocoFim & "," & IIf(vPesquisa <> "", 1, 0)

                                End If

                            Next

                        End If

                    End If

                    'If strDadosRoteiro <> "" Then

                    cls.GravaRoteiro(intIdPromotorCopia, CDate(strDiaCopia), strDadosRoteiro, IIf(vFolga <> "", 1, 0), intFolgaMotivo)
                    strDadosRoteiro = ""
                    blnAlterouDados = True

                    strDiaCopia = DateAdd(DateInterval.Day, 1, CDate(strDiaCopia))

                End If

            Next

            Response.Redirect("roteiro_periodo.aspx?idpromotor=" & intIdPromotorCopia & "&di=" & XMCrypto.Encrypt(txtImportDataInicial.Text) & "&df=" & XMCrypto.Encrypt(txtImportDataFinal.Text) & "&st=" & ViewState("IDSTATUSPROMOTOR"))

        End If

    End Sub

    Protected Sub validacaoDatasCopiaRoteiro(ByVal sender As Object, ByVal args As ServerValidateEventArgs)

        args.IsValid = True

        If txtDataInicial.Text = "" Or txtDataFinal.Text = "" Or txtImportDataInicial.Text = "" Or txtImportDataFinal.Text = "" Then
            args.IsValid = False

        Else

            Dim iDias As Long = DateDiff(DateInterval.Day, CDate(txtDataInicial.Text), CDate(txtDataFinal.Text))
            Dim iDiasImp As Long = DateDiff(DateInterval.Day, CDate(txtImportDataInicial.Text), CDate(txtImportDataFinal.Text))

            If iDias <> iDiasImp Then

                args.IsValid = False
            End If

        End If

    End Sub

    'Protected Sub validacaoHorasRoteiro(ByVal sender As Object, ByVal args As ServerValidateEventArgs)

    '    args.IsValid = True

    '    Dim r As New clsRoteiroPeriodo
    '    Dim dr As DataSet = r.ListarLojas(ViewState(VW_IDPROMOTOR), DataClass.enReturnType.DataSet)
    '    lblNumeroLojas.Text = dr.Tables(0).Rows.Count

    '    'Dim cls As New clsRoteiroPeriodo()
    '    Dim p_IdLojas As Object = (Request("IdLoja") & "").Split(",")
    '    Dim strDadosRoteiro As String = ""
    '    Dim blnAlterouDados As Boolean = False
    '    Dim shtFolga As Short = 0

    '    Dim strDiaCopia As String = txtImportDataInicial.Text
    '    Dim strDiaCopiaFinal As String = txtImportDataFinal.Text
    '    Dim intIdPromotorCopia As Integer = getComboValue(cboIDPromotor)

    '    For Each DiaCheck As Date In getDias()

    '        'If CDate(strDiaCopia) <= CDate(strDiaCopiaFinal) Then

    '        If TypeOf p_IdLojas Is System.Array Then

    '            If CType(p_IdLojas, System.Array).Length > 0 Then

    '                For Each objIdLoja As Object In p_IdLojas

    '                    Dim IdLojaCheck As String = Request("Dia_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd"))
    '                    Dim DiaFolga As String = Request("DiaFolga_" & Format(DiaCheck, "yyyyMMdd"))

    '                    If Not DiaFolga Is Nothing Then
    '                        shtFolga = 1 'CheckBox DiaFolga = True
    '                    Else
    '                        shtFolga = 0 'CheckBox DiaFolga = False
    '                    End If

    '                    Dim HoraInicio As String = ""
    '                    Dim HoraFim As String = ""
    '                    Dim HoraAlmocoFim As String = ""
    '                    Dim HoraAlmocoInicio As String = ""

    '                    If Not IdLojaCheck Is Nothing Then
    '                        HoraInicio = Request("HoraInicio_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
    '                        HoraFim = Request("HoraFim_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
    '                        HoraAlmocoInicio = Request("HoraAlmocoInicio_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
    '                        HoraAlmocoFim = Request("HoraAlmocoFim_" & objIdLoja & "_" & Format(DiaCheck, "yyyyMMdd")) & ""
    '                    End If

    '                    If HoraFim < HoraInicio Or HoraAlmocoFim < HoraAlmocoInicio Then
    '                        args.IsValid = False
    '                        Exit Sub
    '                    End If

    '                Next

    '            End If

    '        End If

    '    Next

    'End Sub



    Protected Sub btnCancelarCopiaRoteiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarCopiaRoteiro.Click

        plhImportarRoteiro.Visible = False
        btnGravar.Enabled = IIf(ViewState("IDSTATUSPROMOTOR") = 0, False, True)
        plhLojas.Visible = IIf(ViewState("IDSTATUSPROMOTOR") = 0, False, True)
        btnImportRoteiro.Visible = True
        btnConfirmar.Visible = False
        btnCancelarCopiaRoteiro.Visible = False
        btnFiltrar.Visible = True


    End Sub

    Protected Sub txtImportDataInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImportDataInicial.TextChanged

        If IsDate(txtImportDataInicial.Text) And IsDate(txtDataInicial.Text) And IsDate(txtDataFinal.Text) Then
            txtImportDataFinal.Text = CDate(txtImportDataInicial.Text).AddDays(DateDiff(DateInterval.Day, CDate(txtDataInicial.Text), CDate(txtDataFinal.Text)))
            btnConfirmar.Enabled = True
        Else
            txtImportDataFinal.Text = ""
            btnConfirmar.Enabled = False
        End If

    End Sub

End Class

