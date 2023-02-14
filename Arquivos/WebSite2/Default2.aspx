<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <asp:gridview id="GridView1" runat="server" autogeneratecolumns="false" font-names="Arial" caption="Using ImageField">
	 
	<columns>
	 
	<asp:boundfield datafield="ID" headertext="ID">
	 
	<asp:boundfield datafield="Name" headertext=" Nome da Imagem ">
	 
	<asp:imagefield dataimageurlfield="ID" dataimageurlformatstring="ImageVB.aspx?ImageID={0}" controlstyle-width="100" controlstyle-height="100" headertext="Preview da Imagem">
	 
		 
	<asp:GridView></asp:imagefield></asp:boundfield></asp:boundfield></columns></asp:gridview>



    </div>
    </form>
</body>
</html>
