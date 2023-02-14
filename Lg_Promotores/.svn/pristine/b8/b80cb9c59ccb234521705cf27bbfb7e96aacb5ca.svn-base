
Partial Class controls_Localizacao
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property IDEmpresa() As Integer
        Set(ByVal value As Integer)
            ViewState("IDEmpresa") = value
        End Set
    End Property

    Public WriteOnly Property IDVisita() As Integer
        Set(ByVal value As Integer)
            ViewState("IDVisita") = value
        End Set
    End Property

    Public WriteOnly Property TipoMapa() As Integer
        Set(ByVal value As Integer)
            ViewState("TipoMapa") = value
        End Set
    End Property

    Public Property Latitude() As Double
        Get
            Return ViewState("Latitude")
        End Get
        Set(ByVal value As Double)
            ViewState("Latitude") = value
        End Set
    End Property

    Public Property Longitude() As Double
        Get
            Return ViewState("Longitude")
        End Get
        Set(ByVal value As Double)
            ViewState("Longitude") = value
        End Set
    End Property

    Public Property CssClass() As String
        Get
            Return ViewState("CssClass")
        End Get
        Set(ByVal value As String)
            ViewState("CssClass") = value
        End Set
    End Property

    Protected Function GetPos(ByVal Value As Double) As String
        Dim strTemp As String = ""
        Dim intTemp As Integer
        If Value < 0 Then Value = Value * -1

        Dim dblResto As Double = Value
        intTemp = Int(dblResto)
        strTemp = intTemp & "º"

        dblResto = (dblResto - intTemp) * 60
        intTemp = Int(dblResto)
        strTemp &= intTemp & "'"

        dblResto = (dblResto - intTemp) * 60
        intTemp = Int(dblResto)
        strTemp &= intTemp & "''"

        Return strTemp

    End Function



    Public ReadOnly Property Posicao() As String
        Get
            If Latitude <> 0 And Longitude <> 0 Then
                Dim strPosicao As String = ""
                If Latitude > 0 Then
                    strPosicao = GetPos(Latitude) & "N"
                Else
                    strPosicao = GetPos(Latitude) & "S"
                End If
                strPosicao &= " "
                If Longitude > 0 Then
                    strPosicao &= GetPos(Longitude) & "E"
                Else
                    strPosicao &= GetPos(Longitude) & "W"
                End If

                Return strPosicao
            Else
                Return ""
            End If
        End Get
    End Property

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim strPos As String = Posicao
        If strPos <> "" Then
            ltrLocal.Text = "<a href='#' onclick='verMapa(""" & ViewState("IDEmpresa") & """,""" & ViewState("IDVisita") & """,""" & ViewState("TipoMapa") & """)'" & IIf(CssClass <> "", " class='" & CssClass & "'", "") & ">" & strPos & "</a>"
        Else
            ltrLocal.Text = "Sem posição"
        End If
    End Sub
End Class
