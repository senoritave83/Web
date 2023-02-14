<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtDescontoMaximo.ascx.vb" Inherits="controls_txtDescontoMaximo" %>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:CompareValidator ControlToValidate='TextBox1' runat='server' Operator='DataTypeCheck' Type='Double' ErrorMessage='Valor do desconto máximo inválido!' />
<asp:CompareValidator ControlToValidate='TextBox1' runat='server' Operator="LessThanEqual" Type='Double' ValueToCompare='100' ErrorMessage='Desconto máximo não pode ser superior a 100%!' Text='*' Display='None' />
<asp:CompareValidator ControlToValidate='TextBox1' runat='server' Operator="GreaterThanEqual" Type='Double' ValueToCompare='0' ErrorMessage='Desconto máximo não pode ser inferior a 0%!' Text='*' Display='None' />
