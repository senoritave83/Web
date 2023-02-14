<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtCorrecao.ascx.vb" Inherits="controls_txtCorrecao" %>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:CompareValidator ControlToValidate='TextBox1' runat='server' Operator='DataTypeCheck' Type='Double' ErrorMessage='Valor da correção inválido!' Text='Valor da correção inválido!' Display='None' />

