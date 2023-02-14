Namespace Controls

    Partial Class Letras
        Inherits System.Web.UI.UserControl
        Implements IFiltroControl


        Public Event Item_Selected(ByVal vLetra As String)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                BindLetters()
            End If
        End Sub



        Public Property Letra() As String
            Get
                Return ViewState("CurrentLetter")
            End Get
            Set(ByVal value As String)
                If ViewState("CurrentLetter") <> value Then
                    ViewState("CurrentLetter") = value
                    BindLetters()
                End If
            End Set
        End Property


        Protected Sub BindLetters()
            Dim arr() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Todos"}
            rptLetras.DataSource = arr
            rptLetras.DataBind()
        End Sub


        Protected Sub rptLetras_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptLetras.ItemCommand
            If e.CommandName = "Filtrar" Then
                If e.CommandArgument = "Todos" Then
                    ViewState("CurrentLetter") = ""
                    RaiseEvent Item_Selected("")
                    BindLetters()
                Else
                    ViewState("CurrentLetter") = e.CommandArgument
                    RaiseEvent Item_Selected(e.CommandArgument & "%")
                    BindLetters()
                End If
            End If
        End Sub

        Public Property Value() As Object Implements IFiltroControl.Value
            Get
                Return Letra
            End Get
            Set(ByVal value As Object)
                Letra = value
            End Set
        End Property
    End Class

End Namespace
