Imports Classes
Imports System
Imports System.Data
Imports System.Data.SqlClient


Partial Class reports_rptPerformance
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

    Private Sub verificaContextoCoordenador()

        carregaCoordenadores(Me.User.IdCoordenador)
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

    Private Sub carregaClientes()

        lstClientes.Items.Clear()
        lstLojas.Items.Clear()

        Dim clsCli As clsCliente
        clsCli = New clsCliente
        lstClientes.DataSource = clsCli.Listar(DataClass.enReturnType.DataReader)
        lstClientes.DataBind()
        clsCli = Nothing

    End Sub

    Private Sub carregaLojas()

        Dim p_Clientes As String = getComboValues(lstClientes)

        Dim clsLoj As clsLoja
        clsLoj = New clsLoja
        lstLojas.DataSource = clsLoj.Listar(p_Clientes, DataClass.enReturnType.DataReader)
        lstLojas.DataBind()
        clsLoj = Nothing

    End Sub

    Private Sub carregaShopping()

        Dim clsShop As clsShopping
        clsShop = New clsShopping
        lstShopping.DataSource = clsShop.Listar(DataClass.enReturnType.DataReader)
        lstShopping.DataBind()
        lstShopping.Items.Insert(0, New ListItem("Loja de Rua", "0"))
        clsShop = Nothing

    End Sub

    Private Sub carregaCoordenadores(Optional ByVal p_IdCoordenador As Integer = 0)

        lstCoordenador.Items.Clear()

        Dim clsCrd As clsCoordenador
        clsCrd = New clsCoordenador
        Dim dr As SqlDataReader = clsCrd.Listar(DataClass.enReturnType.DataReader)
        Do While dr.Read
            If (p_IdCoordenador > 0 And p_IdCoordenador = dr("IdCoordenador")) Or p_IdCoordenador = 0 Then
                lstCoordenador.Items.Add(New ListItem(dr("Coordenador") & "", dr("IdCoordenador")))
            End If
        Loop
        clsCrd = Nothing

        lstLider.Items.Clear()
        lstPromotor.Items.Clear()

    End Sub

    Private Sub carregaLideres(Optional ByVal p_IdLider As Integer = 0)

        lstLider.Items.Clear()

        Dim p_Coordenadores As String = getComboValues(lstCoordenador)

        Dim clsLid As clsLider
        clsLid = New clsLider
        Dim dr As SqlDataReader = clsLid.Listar(p_Coordenadores, DataClass.enReturnType.DataReader)
        Do While dr.Read
            If (p_IdLider > 0 And p_IdLider = dr("IdLider")) Or p_IdLider = 0 Then
                lstLider.Items.Add(New ListItem(dr("Lider") & "", dr("IdLider")))
            End If
        Loop
        clsLid = Nothing

        lstPromotor.Items.Clear()

    End Sub

    Private Sub carregaPromotores()

        lstPromotor.Items.Clear()

        Dim p_Lideres As String = getComboValues(lstLider, True)

        Dim clsPro As clsPromotor
        clsPro = New clsPromotor
        lstPromotor.DataSource = clsPro.Listar(p_Lideres, DataClass.enReturnType.DataReader)
        lstPromotor.DataBind()
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
End Class
