
Imports Classes

Namespace Pages.Visita

    Partial Public Class Visita
        Inherits XMWebPage
        Dim cls As clsVisita
        Protected Const VW_IDVISITA As String = "IDVisita"
        Const PAGESIZE As Integer = 15
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsVisita()
            If Not Page.IsPostBack Then

                ViewState(VW_IDVISITA) = CInt("0" & Request("IDVisita"))
                cls.Load(ViewState(VW_IDVISITA))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)

                Dim tjf As New clsTipoJustificativa
                cboIDTipoJustificativa.DataSource = tjf.Listar
                cboIDTipoJustificativa.DataBind()
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("Selecione", -1))

                Inflate()

                BindGridPedidos()

            Else

                cls.Load(ViewState(VW_IDVISITA))

            End If

        End Sub

        Protected Sub Inflate()
            lblCliente.Text = cls.Cliente
            lblVendedor.Text = cls.Vendedor
            lblData.Text = cls.Data
            setComboValue(cboIDTipoJustificativa, cls.IDTipoJustificativa)
        End Sub

        Protected Sub Deflate()
            cls.IDTipoJustificativa = cboIDTipoJustificativa.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/pedidos/visita.aspx?idvisita=" & cls.IDVisita)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Protected Function isEncontrado(ByVal value As Object) As Boolean
            If IsDBNull(value) Then
                Return False
            Else
                Return CBool(value)
            End If
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function Encontrado(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                If value = True Then
                    Return "Sim"
                Else
                    Return "Não"
                End If
            End If
        End Function

        Protected Function GetPreco(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                Return FormatCurrency(value, 2)
            End If
        End Function

        Protected Function GetNullable(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                Return value
            End If
        End Function

        Public Sub BindGridPedidos()

            Dim clsPed As New clsPedido

            GridView1.DataSource = clsPed.Listar(ViewState(VW_IDVISITA), DataClass.enReturnType.DataReader)

            GridView1.DataBind()

            clsPed = Nothing

        End Sub

    End Class

End Namespace

