<%@ page title="" language="VB" masterpagefile="~/hotsite/login.master" autoeventwireup="false" CodeFile="login.aspx.vb"  inherits="home_login" %>
<asp:Content id="Content3" runat="server" contentplaceholderid="head">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
			<ul class="breadcrumb">
                <li><a href="#">Portal de Servi&ccedil;os</a>/</li>
                <li><span>Equipe Online</span></li>
            </ul>        
		    <div class="main mainDeslog">
			    <img src="../images/pictures/banner_EOL.jpg" width="880" height="220" alt="Equipe Online" />
                <br class="clear"/>               
			          
                <div class="fRight">
                    <form id="form1" runat="server">
                        <p>
                            <span class="fLeft">
                                <label for="chave">Chave</label>
                                <span><asp:TextBox id="txtChave" runat='server' TabIndex="1" MaxLength="20" size="20" cssclass="formulario" AUTOCOMPLETE="OFF" /></span>
                            </span>
                            
                            <span class="fRight">
                                <label for="login">Login</label>
                                <span><asp:TextBox id="txtUser" runat="server" TabIndex="2" MaxLength="20" size="20" cssclass="formulario" AUTOCOMPLETE="OFF" /></span> 
                            </span>                          
                        </p>
                        <p>
                            <label for="senha">Senha</label>
                            <span><asp:TextBox id="txtPassword" TextMode="Password" runat="server" cssclass="formulario" TabIndex="3" size="20" MaxLength="20" AUTOCOMPLETE="OFF" /></span>
                            <asp:ImageButton runat="server" id="btnOk" ImageUrl="~/images/buttons/btn_continuar.png" alt="" />
                            <br class="clear"/>
                            <a href="../inicio/esqueci.aspx">Esqueci minha senha</a>
                        </p>
                        <p>
                            <label><asp:Label runat='server' ID='lblMensagem' cssclass="erro" Visible='false'></asp:Label></label>
                        </p>
                        <p style="font-size:10px; color:#766A62">*Melhor visualizado no navegador Internet Explorer.</p>
                    </form>
                </div>
                <br class="clear"/>
            </div>  
	
		

</asp:Content>
 

