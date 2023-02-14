
Partial Class include_os_editor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cfg As New clsConfig()

        If Not Page.IsPostBack Then

            BindDestinatario()

            Dim msp As New clsMensagem()
            cboMensagens.DataSource = msp.Listar
            cboMensagens.DataBind()
            msp = Nothing
            tdMsg.Visible = (cboMensagens.Items.Count > 0)
            tdDsc.ColSpan = IIf((cboMensagens.Items.Count > 0), 1, 2)


            txtTempoLimite.Text = ConverterMinutos(cfg.TempoLimite)


        End If

        trOrigemDestino1.Visible = cfg.OrigemDestino
        trOrigemDestino2.Visible = cfg.OrigemDestino
        trOrigemDestino3.Visible = cfg.OrigemDestino
        trOrigemDestino4.Visible = cfg.OrigemDestino
        trOrigemDestino5.Visible = cfg.OrigemDestino
        trOrigemDestino6.Visible = cfg.OrigemDestino

        cfg = Nothing

    End Sub

    'txtCliente.Text, txtEndereco.Text, txtReferencia.Text, cboResponsavel.SelectedItem.Value, txtObservacao.Text, CInt(txtTempoLimite.Text)

    Public Property Cliente() As String
        Get
            Return txtCliente.Text
        End Get
        Set(ByVal value As String)
            txtCliente.Text = value
        End Set
    End Property

    Public Property Endereco() As String
        Get
            Return txtEndereco.Text
        End Get
        Set(ByVal value As String)
            txtEndereco.Text = value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return txtReferencia.Text
        End Get
        Set(ByVal value As String)
            txtReferencia.Text = value
        End Set
    End Property

    Public Property EnderecoDestino() As String
        Get
            Return txtEnderecoDestino.Text
        End Get
        Set(ByVal value As String)
            txtEnderecoDestino.Text = value
        End Set
    End Property

    Public Property ReferenciaDestino() As String
        Get
            Return txtReferenciaDestino.Text
        End Get
        Set(ByVal value As String)
            txtReferenciaDestino.Text = value
        End Set
    End Property

    Public Property IDDestinatario() As Integer
        Get
            Return cboResponsavel.SelectedValue
        End Get
        Set(ByVal value As Integer)
            setComboValue(cboResponsavel, value)
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return txtObservacao.Text
        End Get
        Set(ByVal value As String)
            txtObservacao.Text = value
            ltrCaracteres.Text = (500 - value.Length)
        End Set
    End Property

    Public Property TempoLimite() As Integer
        Get
            Return ConverterHoras(txtTempoLimite.Text)
        End Get
        Set(ByVal value As Integer)
            txtTempoLimite.Text = ConverterMinutos(value)
        End Set
    End Property

    Public Property IDPrioridade() As Integer
        Get
            Return cboPrioridade.SelectedValue
        End Get
        Set(ByVal value As Integer)
            setComboValue(cboPrioridade, value)
        End Set
    End Property

    Private Sub BindDestinatario()

        cboResponsavel.Items.Clear()
        Dim rsp As New clsResponsaveis

        cboResponsavel.DataSource = rsp.ListarDestinatariosAtivos()
        cboResponsavel.DataBind()

        'Dim grp As New clsGrupo
        'Dim dr As IDataReader = grp.Listar()
        'Do While dr.Read
        '    cboResponsavel.Items.Insert(0, New ListItem("<" & dr.GetString(dr.GetOrdinal("grp_Grupo_chr")) & ">", dr.GetInt32(dr.GetOrdinal("grp_Grupo_int_PK")) * -1))
        'Loop
        'dr.Close()

        cboResponsavel.Items.Insert(0, New ListItem("Selecione...", "0"))
        rsp = Nothing

    End Sub

    ''' <summary>
    ''' Método que transforma minutos em horas
    ''' </summary>
    ''' <param name="TempoLimite">Tempo em minutos</param>
    ''' <returns>Horas com formatação hh:mm</returns>
    Public Function ConverterMinutos(ByVal TempoLimite As Integer) As String
        Try
            Dim minutos As Integer
            Dim Tempo() As String = CStr(TempoLimite / 60).Split(",")
            If Tempo.Length > 1 Then
                Tempo(1) = CDec("0," & Tempo(1))
                minutos = CInt(Tempo(1) * 60)
            Else
                minutos = 0
            End If
            Return Right("0" & Tempo(0), 2) & ":" & Right("0" & minutos, 2)
        Catch
            Return "00:00"
        End Try
    End Function

    ''' <summary>
    ''' Método que transforma horas em minutos
    ''' </summary>
    ''' <param name="TempoLimite">Tempo em horas</param>
    ''' <returns>Minutos no formato inteiro</returns>
    Public Function ConverterHoras(ByVal TempoLimite As String) As Integer
        Try
            Dim minutos As Integer
            Dim horas() As String = TempoLimite.Split(":")
            If horas.Length > 1 Then
                minutos = horas(0) * 60
                minutos += horas(1)
            Else
                minutos = horas(0) * 60
            End If
            Return minutos
        Catch
            Return 0
        End Try
    End Function

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ltrCaracteres.Text = 500 - (txtCliente.Text.Length + txtEndereco.Text.Length + txtReferencia.Text.Length + txtObservacao.Text.Length)
    End Sub
End Class
