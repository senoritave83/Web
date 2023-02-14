			
			var objListXML;
			var p_FieldTextXML;
			var p_FieldValueXML;
			var docXML;
		
			function XM_GetRand()
			{
				var dt = new Date();
				return dt.toUTCString();
			}
			function XM_GetSelectedItems(p_ListTo, p_ReturnType)
			{
			
				/*
				p_ReturnType:
				1 - value
				2 - text
				*/
				var p_List = document.getElementById(p_ListTo);
				var p_Items = ''; 
				for(var i = 0; i < p_List.length; i++)
				{
					if(p_List[i].selected)
					{
						if(p_Items!='')p_Items += ',';
						p_Items += (p_ReturnType == 1 ? p_List[i].value : p_List[i].text);
					}
				}
				if(p_Items=='')
				{
					for(var i = 0; i < p_List.length; i++)
					{
						if(p_Items!='')p_Items += ',';
						p_Items += (p_ReturnType == 1 ? p_List[i].value : p_List[i].text);
					}				
				}
				return p_Items;
			}
			function XM_ClearListBox(p_List)
			{
				document.getElementById(p_List).options.length = 0;
			}
			function XM_PopulateList(p_Type, p_Param, p_FieldText, p_FieldValue, p_ListTo, p_DefaultItem)
			{

				objListXML = p_ListTo;
				p_FieldTextXML = p_FieldText;
				p_FieldValueXML = p_FieldValue;
				
				XM_ClearListBox(p_ListTo)
				
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
				if(is_firefox==false)XM_LoadXML(vXML);

			}
			function XM_PopulateXML()
			{
				
				//alert(is_firefox);
									
				var p_Data =docXML.getElementsByTagName('data');
				for(i=0;i<p_Data.length;i++)
				{	
					
					//var items = p_Data[i].getElementsByTagName(p_FieldTextXML)[0];
					//alert(w[i].childNodes[0].nodeValue
					//alert(p_Data[i].childNodes.length);
					//alert(p_Data[i].getElementsByTagName(p_FieldTextXML)[0].textContent);
					//alert(p_Data[i].getElementsByTagName(p_FieldValueXML)[0].textContent);
					//alert(items.textContent);
					//break;
					
					if(p_Data[i].getElementsByTagName(p_FieldTextXML).item(0) != undefined &&
					p_Data[i].getElementsByTagName(p_FieldValueXML).item(0)!= undefined)
					{
												
						
						if(is_firefox==false)
						{
							var p_Text = p_Data[i].getElementsByTagName(p_FieldTextXML).item(0).text.toUpperCase();
							var p_Value =p_Data[i].getElementsByTagName(p_FieldValueXML).item(0).text;		
							var p_Item = document.createElement("option");
							p_Item.text = p_Text;
							p_Item.value = p_Value;
							document.getElementById(objListXML).add(p_Item);
							//break;				   
						}
						else
						{
							var p_Text = p_Data[i].getElementsByTagName(p_FieldTextXML)[0].textContent;
							var p_Value =p_Data[i].getElementsByTagName(p_FieldValueXML)[0].textContent;
							/*alert(p_Text);
							alert(p_Value);*/
							var index=document.getElementById(objListXML).options.length
							document.getElementById(objListXML).options[index] = new Option( p_Text, p_Value, false, false); 
							//break;
						}
											}
				}
			}
			function XM_LoadXML(vXML)
			{

				//alert(vXML);
				if (is_firefox==false)
					{
						docXML = new ActiveXObject("Microsoft.XMLDOM");
						if (docXML.loadXML(vXML) === true) XM_PopulateXML()
					}
				else
					{
						parser=new DOMParser();
						docXML=parser.parseFromString(vXML,"text/xml");
						XM_PopulateXML();
					}
				

			}