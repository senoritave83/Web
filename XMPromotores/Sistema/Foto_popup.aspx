<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Foto_popup.aspx.vb" Inherits="Sistema_Foto_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onunload = refreshParent;
       function refreshParent() {
         window.opener.location.reload();
        }
    </script>
    <title>Editar Foto</title>
</head>
<body >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat='server' EnablePageMethods='true' />
    <asp:UpdatePanel ID="updFiltro" runat="server">
        <ContentTemplate>
            <div>
                <img id='imgfoto' width='700' height='490' runat='server' />
            </div>
            <div style="text-align:center;">
                <asp:ImageButton id='btnRotateLeft' runat='server' Width='40' Height='35' ImageUrl='../imagens/icones/rotate_left.png' alt="Girar para Esquerda" />
		        <asp:ImageButton id='btnRotateRight' runat='server' Width='40' Height='35' ImageUrl='../imagens/icones/rotate_right.png' alt="Girar para Direita" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        var img = document.getElementById('imgfoto');
        window.opener.document.getElementById('imgfoto_' + img.alt).src = img.src + '?dt=' + ($.now());
    </script>
</body>
</html>
