<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Config.aspx.vb" Inherits="Sistema_Config" title="XM Promotores - Yes Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
		<table id='tblEditArea' style="width: 815px">
		    <tr>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='2'>&nbsp;</td>
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 185px">
				    Meta de Performance (%):
				</td>
				<td class='tdField' style="width: 383px">
					<asp:TextBox runat='server' ID='txtPerformance' CssClass="formulario" />
                    <asp:CompareValidator ID="CompareValidator3" ControlToValidate='txtPerformance' runat='server' Operator="LessThanEqual" Type='Double' ValueToCompare='100' ErrorMessage='A meta de performance n&atilde;o pode ser superior a 100%!' Text='*' Display='None' />
                    <asp:CompareValidator ID="CompareValidator4" ControlToValidate='txtPerformance' runat='server' Operator="GreaterThanEqual" Type='Double' ValueToCompare='0' ErrorMessage='A meta de performance n&atilde;o pode ser inferior a 0%!' Text='*' Display='None' />
					<asp:CompareValidator runat='server' ID='CompareValidator1' Display='None' ErrorMessage='Valor de performance inv&aacute;lido!' ControlToValidate='txtPerformance' Operator='DataTypeCheck' Type="Integer" />
					<asp:RequiredFieldValidator runat='server' ID='valReqPerformance' Display='None' ErrorMessage='Performance &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPerformance' />
				</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader' style="width: 185px">
				    *Exibir durante a visita o &uacute;ltimo pre&ccedil;o coletado do produto na loja:
				</td>
              <td class='tdField' style="width: 383px">
				  <asp:RadioButtonList runat="server" ID="txtPrecoVisita" RepeatDirection="Horizontal" Width="170">
                    <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Nao" Value="2" Selected></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
			</tr>

			<tr class="trField">
			    <td  class='tdFieldHeader' style="width: 185px">*TIPO DA COLETA CÓDIGO DE BARRAS DOS PRODUTOS:
             </td>

                <td class='tdField' style="width: 474px">
				  <asp:RadioButtonList runat="server" ID="txtCodigoBarras"  RepeatDirection="Horizontal" Width="170" style="margin-left: 0px">
                    <asp:ListItem Text="Livre" Value="1" Selected></asp:ListItem>
                    <asp:ListItem Text="EAN-13" Value="2" ></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
			</tr>

		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
	    </ul>
    </div>
</asp:Content>

