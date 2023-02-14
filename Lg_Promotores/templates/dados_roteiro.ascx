<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dados_roteiro.ascx.vb" Inherits="templates_dados_roteiro" %>
            <tr>
                <td bgcolor='Gray'>
                    <table width='100%'>
                        <tr>
                            <td><b>Roteiro:</b></td><td>123</td>
                        </tr><tr>
                            <td>Dias:</td><td><b>Dia 3, segunda, tercas e quartas em julho e junho</b></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor='White'>
                   <asp:DataGrid ID='dtgLojasRoteiro' runat='server'>
                        
                   </asp:DataGrid>
                </td>
            </tr>
             