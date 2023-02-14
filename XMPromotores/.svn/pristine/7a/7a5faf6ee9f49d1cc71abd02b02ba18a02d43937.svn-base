<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ImageUploader.ascx.vb" Inherits="inc_ImageUploader" %>
<div class='ImageUploader'>
    <asp:Image  ImageUrl='' runat='server' id='img' CssClass='normal' />
    
    <span id="SpanEdicao" runat="server" visible='True' Class='ImagemTrocar'>
		<input class="bt_sel_img"  type="button" onclick="document.getElementById('arquivo').click();" value="Trocar imagem" runat='server' id='btnSelecionarArquivo' />
    </span>
    
    <span id="SpanUpload" runat="server" style="display:none;">
	    <asp:FileUpload cssclass="bt_sel_img" runat='server' ID='filImagem' EnableTheming='False' Height='27px' />
        <asp:PlaceHolder runat='server' ID='plhBotoes'>
	            <input type="button" id='btnVoltar' runat="server" value='Cancelar' class="btn_edit_cancel"/>
	            <asp:Button runat='server' ID='btnSubir' Text='OK' Enabled='true' EnableTheming='false' CssClass="btn_edit_ok" />
        </asp:PlaceHolder>
    </span>
</div> 
    <script type='text/javascript'>
        function fncTrocaImagem(img, change) {
            if (change)
                img.className = 'troca'
            else
                img.className = 'normal';
        }
        
        function fncSubir(file)
        {
            var bntSubir = document.getElementById('<% = btnSubir.ClientID %>');
            if (file.value.length > 0) {
                bntSubir.click();
            }
        } 
       
    </script>


