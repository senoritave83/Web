Namespace Controls
    <Themeable(True)> _
    Partial Class Agenda
        Inherits System.Web.UI.UserControl
        Protected m_intDia As Integer = 0
        Protected m_intMes As Integer = 0
        Protected m_intDiaSemana As Integer = 0

        Public Property DayPanelCssClass() As String
            Get
                Return pnlDia.CssClass
            End Get
            Set(ByVal value As String)
                pnlDia.CssClass = value
            End Set
        End Property

        Public Property Width() As System.Web.UI.WebControls.Unit
            Get
                Return pnlRoteiro.Width
            End Get
            Set(ByVal value As System.Web.UI.WebControls.Unit)
                pnlRoteiro.Width = value
            End Set
        End Property

        Public Property Height() As System.Web.UI.WebControls.Unit
            Get
                Return pnlRoteiro.Height
            End Get
            Set(ByVal value As System.Web.UI.WebControls.Unit)
                pnlRoteiro.Height = value
            End Set
        End Property

        Public Property CssClass() As String
            Get
                Return pnlRoteiro.CssClass
            End Get
            Set(ByVal value As String)
                pnlRoteiro.CssClass = value
            End Set
        End Property

        Public Property MesPanelCssClass() As String
            Get
                Return pnlMes.CssClass
            End Get
            Set(ByVal value As String)
                pnlMes.CssClass = value
            End Set
        End Property

        Public Property WeekDayPanelCssClass() As String
            Get
                Return pnlDiaSemana.CssClass
            End Get
            Set(ByVal value As String)
                pnlDiaSemana.CssClass = value
            End Set
        End Property

        Public Overridable Property Dia() As Integer
            Get
                m_intDia = 0
                For Each lst As ListItem In chkDia.Items
                    If lst.Selected Then m_intDia = CInt(m_intDia) + CInt(lst.Value)
                Next
                Return m_intDia
            End Get
            Set(ByVal Value As Integer)
                m_intDia = Value
                For Each lst As ListItem In chkDia.Items
                    lst.Selected = (lst.Value And CInt(m_intDia))
                Next
            End Set
        End Property

        Public Overridable Property Mes() As Integer
            Get
                m_intMes = 0
                For Each lst As ListItem In chkMes.Items
                    If lst.Selected Then m_intMes = CInt(m_intMes) + CInt(lst.Value)
                Next
                Return m_intMes
            End Get
            Set(ByVal Value As Integer)
                m_intMes = Value
                For Each lst As ListItem In chkMes.Items
                    lst.Selected = (lst.Value And CInt(m_intMes))
                Next
            End Set
        End Property

        Public Overridable Property DiaSemana() As Integer
            Get
                m_intDiaSemana = 0
                For Each lst As ListItem In chkDiaSemana.Items
                    If lst.Selected Then m_intDiaSemana = CInt(m_intDiaSemana) + CInt(lst.Value)
                Next
                Return m_intDiaSemana
            End Get
            Set(ByVal Value As Integer)
                m_intDiaSemana = Value
                For Each lst As ListItem In chkDiaSemana.Items
                    lst.Selected = (lst.Value And CInt(m_intDiaSemana))
                Next
            End Set
        End Property

        Public Property TipoFrequencia() As Integer
            Get
                Return radTipoFrequenciaDiaria.SelectedValue
            End Get
            Set(ByVal value As Integer)
                If value = 1 Then
                    txtTempo.Enabled = True
                    txtHora.Enabled = False
                    cboTempo.Enabled = True
                    txtHoraInicio.Enabled = True
                    txtHoraTermino.Enabled = True
                    valCompareHora.Enabled = True
                Else
                    txtTempo.Enabled = False
                    txtHora.Enabled = True
                    cboTempo.Enabled = False
                    txtHoraInicio.Enabled = False
                    txtHoraTermino.Enabled = False
                    valCompareHora.Enabled = False
                End If
                setCheckValue(radTipoFrequenciaDiaria, value)
            End Set
        End Property

        Public Property Intervalo() As Integer
            Get
                If cboTempo.SelectedValue = "4" Then
                    'retorna as horas em minutos
                    Return CInt(txtTempo.Text) * 60
                Else
                    Return CInt(txtTempo.Text)
                End If
            End Get
            Set(ByVal value As Integer)
                If value >= 60 Then
                    txtTempo.Text = value / 60
                    cboTempo.SelectedIndex = 1
                Else
                    txtTempo.Text = value
                    cboTempo.SelectedIndex = 0
                End If
            End Set
        End Property

        Public Property HoraExecucao() As Integer
            Get
                If TipoFrequencia = 0 Then
                    Return CHoraGet(txtHora.Text)
                Else
                    Return CHoraGet(txtHoraInicio.Text)
                End If
            End Get
            Set(ByVal value As Integer)
                If TipoFrequencia = 0 Then
                    txtHora.Text = CHoraSet(value)
                Else
                    txtHoraInicio.Text = CHoraSet(value)
                End If
            End Set
        End Property

        Private Function CHoraGet(ByVal value As String) As Integer
            Return CInt(value.Replace(":", "") & "00")
        End Function

        Private Function CHoraSet(ByVal value As Integer) As String
            Dim tmp As String = Right("000000" & value, 6)
            Return Left(tmp, 2) & ":" & tmp.Substring(2, 2)
        End Function

        Public Property HoraFinal() As String
            Get
                Return CHoraGet(txtHoraTermino.Text)
            End Get
            Set(ByVal value As String)
                txtHoraTermino.Text = CHoraSet(value)
            End Set
        End Property

        Public Property DataInicio() As String
            Get
                Return txtDataInicio.Text
            End Get
            Set(ByVal value As String)
                txtDataInicio.Text = value
            End Set
        End Property

        Public Property DataFinal() As String
            Get
                If radDataFinal.SelectedValue = 0 Then
                    Return txtDataTermino.Text
                Else
                    Return ""
                End If
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    radDataFinal.SelectedIndex = 1
                    txtDataTermino.Enabled = False
                Else
                    radDataFinal.SelectedIndex = 0
                    txtDataTermino.Text = value
                    txtDataTermino.Enabled = True
                End If
            End Set
        End Property

        Public Sub CreateItens()
            Dim iTemp As Integer, iValue As Integer

            chkDia.Items.Clear()
            chkMes.Items.Clear()
            chkDiaSemana.Items.Clear()

            'VERIFICANDO DIA
            For iTemp = 0 To 30
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intDia))
                lst.Text = iTemp + 1
                lst.Value = iValue
                chkDia.Items.Add(lst)
            Next

            'VERIFICANDO MÊS
            For iTemp = 0 To 11
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intMes))
                lst.Text = MonthName(iTemp + 1)
                lst.Value = iValue
                chkMes.Items.Add(lst)
            Next

            'VERIFICANDO DIA DA SEMANA
            For iTemp = 0 To 6
                Dim lst As New ListItem()
                iValue = 2 ^ iTemp
                lst.Selected = (iValue And CInt(m_intDiaSemana))
                lst.Text = WeekdayName(iTemp + 1)
                lst.Value = iValue
                chkDiaSemana.Items.Add(lst)
            Next

            txtHora.Text = Now.AddHours(1).ToString("HH:00")
            txtDataTermino.Text = Now.AddMonths(1).AddDays(1).ToString("dd/MM/yyyy")
            txtDataInicio.Text = Now.AddDays(1).ToString("dd/MM/yyyy")
            txtHoraInicio.Text = "00:00"
            txtHoraTermino.Text = "23:59"
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "agendafunctions", GetScript, True)
        End Sub

        Protected Function GetScript() As String

            Dim str As New StringBuilder()

            str.AppendLine("    function fncLimparChecks(vID)")
            str.AppendLine("{")
            str.AppendLine("    var elms = document.getElementsByTagName('input');")
            str.AppendLine("    for (var i = 0; i < elms.length; i++)")
            str.AppendLine("    {")
            str.AppendLine("       var el = elms[i];")
            str.AppendLine("        if (el.id.substring(0, vID.length) == vID)")
            str.AppendLine("        {")
            str.AppendLine("            el.checked = false;")
            str.AppendLine("        }")
            str.AppendLine("    }")
            str.AppendLine("    fncAgendaRefresh();")
            str.AppendLine("}")

            str.AppendLine("function fncVerificaTempo()")
            str.AppendLine("{")
            str.AppendLine("    var txtTempo = document.getElementById('" & txtTempo.ClientID & "');")
            str.AppendLine("    var cboTempo = document.getElementById('" & cboTempo.ClientID & "');")
            str.AppendLine("    var tempo = parseInt(txtTempo.value);")
            str.AppendLine("    if (cboTempo.selectedIndex == 0 && tempo < 10)")
            str.AppendLine("        txtTempo.value = '10';")
            str.AppendLine("    fncAgendaRefresh();")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function fncGetSelecao(panel, vEmpty, vNome) {")
            str.AppendLine("    var ret = vNome + ' ';")
            str.AppendLine("    var blnTemp = false;")
            str.AppendLine("    var elms = panel.getElementsByTagName('input');")
            str.AppendLine("    for (var i = 0; i < elms.length; i++) {")
            str.AppendLine("        var el = elms[i];")
            str.AppendLine("        if (el.checked) {")
            str.AppendLine("            blnTemp = true;")
            str.AppendLine("            ret += getText(panel, el) + ', ';")
            str.AppendLine("        }")
            str.AppendLine("    }")
            str.AppendLine("    if (blnTemp == false)")
            str.AppendLine("    { ret = vEmpty; }")
            str.AppendLine("    else {")
            str.AppendLine("    ret = ret.substring(0, ret.length - 2)")
            str.AppendLine("        if (inStr(ret, ',') > -1) {")
            str.AppendLine("            var i = inStrRev(ret, ',');")
            str.AppendLine("            ret = ret.substring(0, ret.length - i - 1) + ' e ' + ret.substring(ret.length - i, ret.length);")
            str.AppendLine("        }")
            str.AppendLine("    }")
            str.AppendLine("    return ret;")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function getText(vPanel, vInput) {")
            str.AppendLine("    var labels = vPanel.getElementsByTagName('label');")
            str.AppendLine("    for (var i = 0; i < labels.length; i++) {")
            str.AppendLine("        var el = labels[i];")
            str.AppendLine("        if (el.htmlFor == vInput.id) {")
            str.AppendLine("            return el.innerHTML;")
            str.AppendLine("        }")
            str.AppendLine("    }")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function fncAgendaRefresh() {")
            str.AppendLine("")
            str.AppendLine("")
            str.AppendLine("    var vTexto = 'Ocorre ';")
            str.AppendLine("")
            str.AppendLine("    vTexto += fncGetSelecao(" & pnlDia.ClientID & ", ' todos os dias', 'dia(s)');")
            str.AppendLine("    vTexto += fncGetSelecao(" & pnlMes.ClientID & ", ' de todos os meses', ' no(s) mes(es) de ');")
            str.AppendLine("    vTexto += fncGetSelecao(" & pnlDiaSemana.ClientID & ", '', ' no(a) ');")
            str.AppendLine("")
            str.AppendLine("    var vCheckedFrequencia = document.getElementById('" & radTipoFrequenciaDiaria.ClientID & "_1').checked;")
            str.AppendLine("    var txtHora = document.getElementById('" & txtHora.ClientID & "');")
            str.AppendLine("")
            str.AppendLine("    var txtHoraInicio = document.getElementById('" & txtHoraInicio.ClientID & "');")
            str.AppendLine("    var txtHoraTermino = document.getElementById('" & txtHoraTermino.ClientID & "');")
            str.AppendLine("    var txtTempo = document.getElementById('" & txtTempo.ClientID & "');")
            str.AppendLine("    var cboTempo = document.getElementById('" & cboTempo.ClientID & "');")
            str.AppendLine("    if (vCheckedFrequencia){")
            str.AppendLine("        vTexto += ' a cada ' + txtTempo.value + ' ' + cboTempo.options[cboTempo.selectedIndex].text; ")
            str.AppendLine("        vTexto += ' entre ' + txtHoraInicio.value + ' as ' + txtHoraTermino.value + '.'")
            str.AppendLine("    }")
            str.AppendLine("    else")
            str.AppendLine("    { vTexto += ' &agrave;s ' + txtHora.value + '.'; }")
            str.AppendLine("")
            str.AppendLine("    var vCheckedTermino = document.getElementById('" & radDataFinal.ClientID & "_1').checked;")
            str.AppendLine("    var txtDataInicial = document.getElementById('" & txtDataInicio.UID & "');")
            str.AppendLine("    var txtDataFinal = document.getElementById('" & txtDataTermino.UID & "');")
            str.AppendLine("    vTexto += '<br />';")
            str.AppendLine("    if (vCheckedTermino)")
            str.AppendLine("    { vTexto += ' O agendamento ser&aacute; executado a partir do dia ' + txtDataInicial.value + '.'; }")
            str.AppendLine("    else")
            str.AppendLine("    { vTexto += ' O agendamento ser&aacute; executado entre os dias ' + txtDataInicial.value + ' e ' + txtDataFinal.value + '.'; }")
            str.AppendLine("")
            str.AppendLine("    spResumo.innerHTML = vTexto;")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function maskdata(field)")
            str.AppendLine("{")
            str.AppendLine("    var data = field.value;")
            str.AppendLine("    if (data.length == 2){")
            str.AppendLine("        data = data + '/';")
            str.AppendLine("        field.value = data;")
            str.AppendLine("        return true;")
            str.AppendLine("    }")
            str.AppendLine("    if (data.length == 5){")
            str.AppendLine("        data = data + '/';")
            str.AppendLine("        field.value = data;")
            str.AppendLine("        return true;")
            str.AppendLine("    }")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function validaDataTermino(source, args){")
            str.AppendLine("    var vChecked = document.getElementById('" & radDataFinal.ClientID & "_1').checked;")
            str.AppendLine("    var txtDataFinal = document.getElementById('" & txtDataTermino.UID & "');")
            str.AppendLine("    if (! vChecked && txtDataFinal.value == '') {")
            str.AppendLine("        args.IsValid = false;")
            str.AppendLine("    }")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function validaFrequencia(source, args)")
            str.AppendLine("{")
            str.AppendLine("    var vCheckedFrequencia = document.getElementById('" & radTipoFrequenciaDiaria.ClientID & "_1').checked;")
            str.AppendLine("    var src = document.getElementById(eval(source.id).controltovalidate);")
            str.AppendLine("    var txtHora = document.getElementById('" & txtHora.ClientID & "');")
            str.AppendLine("    var txtTempo = document.getElementById('" & txtTempo.ClientID & "');")
            str.AppendLine("    var cboTempo = document.getElementById('" & cboTempo.ClientID & "');")
            str.AppendLine("    if (!vCheckedFrequencia && Right(source.id, 7) == 'valHora') {")
            str.AppendLine("    if (txtHora.value.length < 5)")
            str.AppendLine("        {")
            str.AppendLine("            args.IsValid = false;")
            str.AppendLine("        }")
            str.AppendLine("    }")
            str.AppendLine("    if (vCheckedFrequencia && Right(source.id, 10) == 'CustomHora') {")
            str.AppendLine("        var txtHora;")
            str.AppendLine("        if (Right(source.id, 19) == 'valInicioCustomHora') {")
            str.AppendLine("            txtHora = document.getElementById('" & txtHoraInicio.ClientID & "');")
            str.AppendLine("        } else {")
            str.AppendLine("            txtHora = document.getElementById('" & txtHoraTermino.ClientID & "');")
            str.AppendLine("        }")
            str.AppendLine("        args.IsValid = isHora(txtHora.value);")
            str.AppendLine("    }")
            str.AppendLine("    if (vCheckedFrequencia && Right(source.id, 8) == 'valTempo') {")
            str.AppendLine("        if (txtTempo.value.length == 0)")
            str.AppendLine("        {")
            str.AppendLine("            args.IsValid = false;")
            str.AppendLine("        } else if (!isInteger(txtTempo.value)) {")
            str.AppendLine("            args.IsValid = false;")
            str.AppendLine("        } else {")
            str.AppendLine("            var t = parseInt(txtTempo.value);")
            str.AppendLine("            if (t < 1) {")
            str.AppendLine("                args.IsValid = false;    ")
            str.AppendLine("            } else if (t < 10 && cboTempo.selectedIndex == 0) {")
            str.AppendLine("                args.IsValid = false;    ")
            str.AppendLine("            } else if (t > 59 && cboTempo.selectedIndex == 0) {")
            str.AppendLine("                args.IsValid = false;    ")
            str.AppendLine("            } else if (t > 23 && cboTempo.selectedIndex == 1) {")
            str.AppendLine("                args.IsValid = false;    ")
            str.AppendLine("            }")
            str.AppendLine("        }")
            str.AppendLine("    }")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function fncAlteraDataTermino() {")
            str.AppendLine("    var vChecked = document.getElementById('" & radDataFinal.ClientID & "_1').checked;")
            str.AppendLine("    var txtDataFinal = document.getElementById('" & txtDataTermino.UID & "');")
            str.AppendLine("    if (vChecked) {")
            str.AppendLine("        txtDataFinal.disabled = true;")
            str.AppendLine("    }")
            str.AppendLine("    else {")
            str.AppendLine("        txtDataFinal.disabled = false;")
            str.AppendLine("    }")
            str.AppendLine("    fncAgendaRefresh();")
            str.AppendLine("}")
            str.AppendLine("function fncAlteraFrequencia() {")
            str.AppendLine("    var vChecked = document.getElementById('" & radTipoFrequenciaDiaria.ClientID & "_1').checked;")
            str.AppendLine("    var txtHora = document.getElementById('" & txtHora.ClientID & "');")
            str.AppendLine("    var txtHoraInicio = document.getElementById('" & txtHoraInicio.ClientID & "');")
            str.AppendLine("    var txtHoraTermino = document.getElementById('" & txtHoraTermino.ClientID & "');")
            str.AppendLine("    var txtTempo = document.getElementById('" & txtTempo.ClientID & "');")
            str.AppendLine("    var cboTempo = document.getElementById('" & cboTempo.ClientID & "');")
            str.AppendLine("    var valCompareHora = document.getElementById('" & valCompareHora.ClientID & "');")
            str.AppendLine("    if (vChecked) {")
            str.AppendLine("        txtHora.disabled = true;")
            str.AppendLine("        txtHoraInicio.disabled = false;")
            str.AppendLine("        txtHoraTermino.disabled = false;")
            str.AppendLine("        valCompareHora.enabled = true;")
            str.AppendLine("        cboTempo.disabled = false;")
            str.AppendLine("        txtTempo.disabled = false;")
            str.AppendLine("    }")
            str.AppendLine("    else {")
            str.AppendLine("        txtHora.disabled = false;")
            str.AppendLine("        txtHoraInicio.disabled = true;")
            str.AppendLine("        txtHoraTermino.disabled = true;")
            str.AppendLine("        valCompareHora.enabled = false;")
            str.AppendLine("        cboTempo.disabled = true;")
            str.AppendLine("        txtTempo.disabled = true;")
            str.AppendLine("    }")
            str.AppendLine("    fncAgendaRefresh();")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function mascaraHora(o,f)")
            str.AppendLine("{")
            str.AppendLine("v_obj = o")
            str.AppendLine("v_fun = f")
            str.AppendLine("setTimeout('execmascara()', 1)")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function execmascara(){")
            str.AppendLine("v_obj.value = v_fun(v_obj.value)")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("    //valida formato de hora 00:00 até 23:59 com mascara")
            str.AppendLine("    //er=/^(([01][\d])|([2][0-3]))([0-5][\d])/ //ereg que valida a hora(nao usada aqui)")
            str.AppendLine("function hora(v){")
            str.AppendLine("")
            str.AppendLine("    v=v.replace(/\D/g,''); //Remove tudo o que não é dígito")
            str.AppendLine("    v=v.replace(/^[^012]/,''); //valida o primeiro dígito #")
            str.AppendLine("    v=v.replace(/^([2])([^0-3])/,'$1'); //valida o segundo dígito ##")
            str.AppendLine("    v=v.replace(/^([\d]{2})([^0-5])/,'$1'); //valida o terceiro dígito ###")
            str.AppendLine("    v=v.replace(/(\d{2})(\d)/,'$1:$2'); //Coloca dois ponto entre o segundo e o terceiro dígitos ##:##")
            str.AppendLine("    v=v.substr(0,5); //Remove digitos extras (aceita no max 5 caracteres(contando o ':' no meio) )")
            str.AppendLine("")
            str.AppendLine("    return v;")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("function mascara(o,f)")
            str.AppendLine("{")
            str.AppendLine("    f(o.value);")
            str.AppendLine("}")
            str.AppendLine("")
            str.AppendLine("")
            str.AppendLine("function hora_out(v)")
            str.AppendLine("{")
            str.AppendLine("    var vl = v.value;")
            str.AppendLine("")
            str.AppendLine("    if(vl.length==1)")
            str.AppendLine("        vl=vl+'0:00';")
            str.AppendLine("    else if(vl.length==2)")
            str.AppendLine("        vl=vl+':00';")
            str.AppendLine("    else if(vl.length==3)")
            str.AppendLine("        vl=vl+'00';")
            str.AppendLine("    else if(vl.length==4)")
            str.AppendLine("        vl=vl+'0';")
            str.AppendLine("")
            str.AppendLine("    return v.value = vl;")
            str.AppendLine("}")
            str.AppendLine("")
            Return str.ToString
        End Function

    End Class

End Namespace
