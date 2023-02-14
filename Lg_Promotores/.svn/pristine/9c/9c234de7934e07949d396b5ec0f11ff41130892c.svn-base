<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ImageUploader.ascx.vb" Inherits="inc_ImageUploader" %>
<div class='ImageUploader'>
    <asp:Image  ImageUrl='' runat='server' id='img' Width='150' CssClass='normal' />
    <div id="divEdicao" runat="server" visible='True' style='height:40px;background-color:Gray;width:150px;'>
	    <input type="button" runat='server' value="Trocar imagem" id="btTroca" name="btTroca" style="width:100%;">
    </div>
    <div id="divUpload" runat="server" style="display:none;width:150px;background-color:Gray;">
        <asp:FileUpload runat='server' ID='filImagem' Width='100%' EnableTheming='False' Height='18px' />
        <asp:PlaceHolder runat='server' ID='plhBotoes'>
            <div style="float:left;background-color:Gray;width:50%;">
	            <input type="button" id='btnVoltar' runat="server" value='Cancelar' style="width:100%;" />
	        </div> 
            <div style="float:right;background-color:Gray;width:50%;">
	            <asp:Button runat='server' ID='btnSubir' Text='Subir'  Enabled='false' style="width:100%;" EnableTheming='false' />
            </div>
        </asp:PlaceHolder>
    </div>
</div> 
    <script type='text/javascript'>
        function fncTrocaImagem(img, change) {
            if (change)
                img.className = 'troca'
            else
                img.className = 'normal';
        }
        
    </script>
