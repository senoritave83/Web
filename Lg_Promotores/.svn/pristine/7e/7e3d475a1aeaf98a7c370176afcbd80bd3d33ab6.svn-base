Imports Classes
Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptTotalMostruarios
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            carregaLojas()
            carregaShopping()
            carregaRegioes()
            carregaTipoLojas()
            carregaSubCategorias()

            txtDataInicial.Text = Format(Now(), "dd/MM/yyyy")
            txtDataFinal.Text = Format(Now(), "dd/MM/yyyy")

        End If

    End Sub

    Private Sub carregaSubCategorias()

        lstSubCategoria.Items.Clear()

        Dim clsSubCat As clsSubCategoria
        clsSubCat = New clsSubCategoria
        lstSubCategoria.DataSource = clsSubCat.Listar(DataClass.enReturnType.DataReader)
        lstSubCategoria.DataBind()
        clsSubCat = Nothing

    End Sub

    Private Sub carregaLojas()

        Dim rep As New clsReports

        Dim clsLoj As clsLoja
        clsLoj = New clsLoja
        lstLojas.DataSource = rep.ListarLojasMostruario()
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

End Class
