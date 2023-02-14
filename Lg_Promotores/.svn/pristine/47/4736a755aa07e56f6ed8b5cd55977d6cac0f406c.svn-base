Imports Classes
Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptLojasPromotores
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            carregaClientes()
            carregaShopping()
            carregaRegioes()
            carregaTipoLojas()

            verificaContextoCoordenador()

            txtDataInicial.Text = Format(Now(), "dd/MM/yyyy")
            txtDataFinal.Text = Format(Now(), "dd/MM/yyyy")

        End If

    End Sub

    Private Sub carregaClientes()

        lstClientes.Items.Clear()
        lstLojas.Items.Clear()

        Dim clsCli As clsCliente
        clsCli = New clsCliente
        lstClientes.DataSource = clsCli.Listar(DataClass.enReturnType.DataReader)
        lstClientes.DataBind()
        Dim it As New ListItem("TODAS", "0")
        it.Selected = True
        lstClientes.Items.Insert(0, it)
        clsCli = Nothing

    End Sub

    Private Sub carregaLojas()

        Dim p_Clientes As String = getComboValues(lstClientes)

        Dim clsLoj As clsLoja
        clsLoj = New clsLoja
        lstLojas.DataSource = clsLoj.Listar(p_Clientes, DataClass.enReturnType.DataReader)
        lstLojas.DataBind()
        Dim it As New ListItem("TODAS", "0")
        it.Selected = True
        lstLojas.Items.Insert(0, it)
        clsLoj = Nothing

    End Sub

    Private Sub carregaShopping()

        Dim clsShop As clsShopping
        clsShop = New clsShopping
        lstShopping.DataSource = clsShop.Listar(DataClass.enReturnType.DataReader)
        lstShopping.DataBind()
        lstShopping.Items.Insert(0, New ListItem("Loja de Rua", "-1"))
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstShopping.Items.Insert(0, it)
        clsShop = Nothing

    End Sub

    Private Sub verificaContextoCoordenador()

        carregaCoordenadores(Me.User.IdCoordenador)
        carregaSegmento()

        If Me.User.IdCoordenador > 0 Then
            setComboValue(lstCoordenador, Me.User.IdCoordenador)
            lstCoordenador.Enabled = False
            lstCoordenador.Attributes.Add("onchange", "javascript:return false")

            btnPromotores.Enabled = False

        End If

        If Me.User.IdLider > 0 Then

            Dim lid As New clsLider
            lid.Load(Me.User.IdLider)

            carregaCoordenadores(lid.IDCoordenador)
            carregaLideres(Me.User.IdLider)

            setComboValue(lstCoordenador, lid.IDCoordenador)
            setComboValue(lstLider, Me.User.IdLider)

            btnLideres.Enabled = False
            btnPromotores.Enabled = False

            'lstLider.Enabled = False
            'lstCoordenador.Enabled = False

            lid = Nothing

            carregaPromotores()

        Else

            btnLideres.Enabled = True
            btnPromotores.Enabled = True
            carregaLideres(Me.User.IdLider)

        End If

    End Sub

    Private Sub carregaCoordenadores(Optional ByVal p_IdCoordenador As Integer = 0)
        Dim p_Segmento As String = cboSegmento.SelectedValue

        lstCoordenador.Items.Clear()

        Dim clsCrd As New clsCoordenador

        Dim dr As SqlDataReader = clsCrd.ListarCoordenadorSegmento(p_Segmento, DataClass.enReturnType.DataReader)
        Do While dr.Read
            If (p_IdCoordenador > 0 And p_IdCoordenador = dr("IdCoordenador")) Or p_IdCoordenador = 0 Then
                lstCoordenador.Items.Add(New ListItem(dr("Coordenador") & "", dr("IdCoordenador")))
            End If
        Loop
        If lstCoordenador.Items.Count > 0 Then
            Dim it As New ListItem("TODOS", "0")
            it.Selected = True
            lstCoordenador.Items.Insert(0, it)
        End If

        clsCrd = Nothing

        lstLider.Items.Clear()
        lstPromotor.Items.Clear()
    End Sub

    Private Sub carregaLideres(Optional ByVal p_IdLider As Integer = 0)
        Dim p_Coordenadores As String = getComboValues(lstCoordenador)
        Dim p_Segmento As String = cboSegmento.SelectedValue

        lstLider.Items.Clear()

        Dim clsLid As clsLider
        clsLid = New clsLider
        Dim dr As SqlDataReader = clsLid.ListarLiderSegmento(p_Coordenadores, p_Segmento, DataClass.enReturnType.DataReader)
        Do While dr.Read
            If (p_IdLider > 0 And p_IdLider = dr("IdLider")) Or p_IdLider = 0 Then
                lstLider.Items.Add(New ListItem(dr("Lider") & "", dr("IdLider")))
            End If
        Loop
        If lstCoordenador.Items.Count > 0 Then
            Dim it As New ListItem("TODOS", "0")
            it.Selected = True
            lstLider.Items.Insert(0, it)
        End If

        clsLid = Nothing

        lstPromotor.Items.Clear()
    End Sub

    Private Sub carregaSegmento()

        cboSegmento.Items.Clear()

        Dim clsSeg As New clsCategoria
        Dim dr As SqlDataReader = clsSeg.Listar(DataClass.enReturnType.DataReader)
        Do While dr.Read
            cboSegmento.Items.Add(New ListItem(dr("Categoria"), dr("Categoria")))
        Loop
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        cboSegmento.Items.Insert(0, it)
        clsSeg = Nothing

        lstPromotor.Items.Clear()

    End Sub

    Private Sub carregaPromotores()

        Dim p_Lideres As String = getComboValues(lstLider)
        Dim p_Segmento As String = cboSegmento.SelectedValue
        Dim p_Coordenadores As String = getComboValues(lstCoordenador)

        Dim clsPro As clsPromotor
        clsPro = New clsPromotor
        lstPromotor.DataSource = clsPro.ListarPromotorSegmento(p_Coordenadores, p_Lideres, p_Segmento, DataClass.enReturnType.DataReader)
        lstPromotor.DataBind()
        If lstPromotor.Items.Count > 0 Then
            Dim it As New ListItem("TODOS", "0")
            it.Selected = True
            lstPromotor.Items.Insert(0, it)        
        End If
        clsPro = Nothing

    End Sub

    Private Sub carregaTipoLojas()

        Dim clsTipo As clsTipoLoja, strScript As String = "", i As Integer = 0

        ltScriptTipoLoja.Text = ""
        clsTipo = New clsTipoLoja

        Dim dr As SqlDataReader = clsTipo.Listar(DataClass.enReturnType.DataReader)
        While dr.Read
            If strScript = "" Then
                strScript = "<script language='javascript'>" & vbCrLf
                strScript &= "function XM_RadioButtonValue_TipoLoja() {" & vbCrLf
                strScript &= "var m_Value = '';" & vbCrLf
            End If
            strScript &= "if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkTipoLoja_" & i & ".checked==true) m_Value+='" & dr("IdTipoLoja") & ",';" & vbCrLf
            chkTipoLoja.Items.Add(New ListItem(dr("TipoLoja"), dr("IdTipoLoja")))
            i += 1
        End While
        If strScript <> "" Then
            strScript &= "return m_Value;" & vbCrLf
            strScript &= "}" & vbCrLf
            strScript &= "</script>" & vbCrLf
            ltScriptTipoLoja.Text = strScript

        End If

        clsTipo = Nothing

    End Sub

    Private Sub carregaRegioes()

        Dim clsReg As clsRegiao, strScript As String = "", i As Integer = 0

        ltScriptRegiao.Text = ""
        clsReg = New clsRegiao

        Dim dr As SqlDataReader = clsReg.Listar(DataClass.enReturnType.DataReader)
        While dr.Read
            If strScript = "" Then
                strScript = "<script language='javascript'>" & vbCrLf
                strScript &= "function XM_RadioButtonValue_Regiao() {" & vbCrLf
                strScript &= "var m_Value = '';" & vbCrLf
            End If
            strScript &= "if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkRegiao_" & i & ".checked==true) m_Value+='" & dr("IdRegiao") & ",';" & vbCrLf
            chkRegiao.Items.Add(New ListItem(dr("Regiao"), dr("IdRegiao")))
            i += 1
        End While
        If strScript <> "" Then
            strScript &= "return m_Value;" & vbCrLf
            strScript &= "}" & vbCrLf
            strScript &= "</script>" & vbCrLf
            ltScriptRegiao.Text = strScript

        End If

        clsReg = Nothing

    End Sub

    Protected Sub btnVisLojas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisLojas.Click
        carregaLojas()
    End Sub

    Protected Sub btnLideres_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLideres.Click
        carregaLideres()
    End Sub

    Protected Sub btnPromotores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPromotores.Click
        carregaPromotores()
    End Sub

    Protected Sub cboSegmento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSegmento.SelectedIndexChanged
        carregaCoordenadores()
        carregaLideres()
    End Sub
End Class
