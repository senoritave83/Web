			function XM_GetRand()
			{
				var dt = new Date();
				return dt.toUTCString();
			}
			function XM_GetSelectedItems(p_ListName)
			{

				var p_Items = ''; 
				var p_List = document.getElementById(p_ListName); 		
				for(var i = 0; i < p_List.length; i++)
				{
					if(p_List[i].selected)
					{
						if(p_Items!='')p_Items += ',';
						p_Items += p_List[i].value;
					}
				}
				if(p_Items=='')
				{
					for(var i = 0; i < p_List.length; i++)
					{
						if(p_Items!='')p_Items += ',';
						p_Items += p_List[i].value;
					}				
				}
				return p_Items;
			}
			function XM_ClearListBox(p_ListName)
			{
				var p_List = document.getElementById(p_ListName);
				p_List.options.length = 0
			}
			function XM_PopulateList(p_Type, p_Param, p_FieldText, p_FieldValue, p_ListTo, p_DefaultItem)
			{
				XM_ClearListBox(p_ListTo);
				if(p_DefaultItem != undefined)
				{
					if (p_DefaultItem)
					{
						var p_DefItem = document.createElement("option");
						p_DefItem.text = 'SELECIONE...';
						p_DefItem.value = '0';
						document.getElementById(p_ListTo).add(p_DefItem);
					}
				}
				
				var p_URL = 'populate_data.aspx?tp=' + p_Type + '&pr=' + p_Param + '&tmr=' + XM_GetRand();
				var vXML = SendRequest(p_URL);
				var doc = new ActiveXObject("Microsoft.XMLDOM");
				if (doc.loadXML(vXML) === true) 
				{
					var p_Data =doc.getElementsByTagName('data');
					for(i=0;i<p_Data.length;i++)
					{	
						if(p_Data[i].getElementsByTagName(p_FieldText).item(0) != undefined &&
						p_Data[i].getElementsByTagName(p_FieldValue).item(0)!= undefined)
						{
							var p_Text = p_Data[i].getElementsByTagName(p_FieldText).item(0).text.toUpperCase();
							var p_Value =p_Data[i].getElementsByTagName(p_FieldValue).item(0).text;						   
							var p_Item = document.createElement("option");
							p_Item.text = p_Text;
							p_Item.value = p_Value;
							document.getElementById(p_ListTo).add(p_Item);
						}
					}

				}
			}