var agt = navigator.userAgent.toLowerCase();
var is_ie = (agt.indexOf('msie') != -1);
var is_ie5 = (agt.indexOf('msie 5') != -1);
var is_firefox = (agt.indexOf('firefox') != -1);

function CreateXmlHttpReq(handler) {

	var xmlhttp = null;
	if (is_ie) {
		var control = (is_ie5) ? "Microsoft.XMLHTTP" : "Msxml2.XMLHTTP";
		try {
			xmlhttp = new ActiveXObject(control);
			xmlhttp.onreadystatechange = handler;
			} 
		catch(e) {
			alert("You need to enable active scripting and activeX controls");
		}
	} else {
		xmlhttp = new XMLHttpRequest();
		//xmlhttp.onreadystatechange = handler;
		xmlhttp.onerror = handler;
	}
	
	return xmlhttp;
}

function DummyHandler() {
}

var uniqnum_counter = (new Date).getTime();
function XmlHttpGET(xmlhttp, url) {
					if(is_firefox){
							xmlhttp.onreadystatechange = function() {   
													if ( xmlhttp.readyState == 4 ) {   
														if ( xmlhttp.status == 200 ) {   
															var vXML = xmlhttp.responseText;
															XM_LoadXML(vXML)
														}   
													}   
												};
							xmlhttp.open('GET', url, true);
						}
					else
					{
						xmlhttp.open('GET', url, false);
					}
					xmlhttp.send(null);
					return xmlhttp.ResponseText;
					
			}
function XmlHttpPOST(xmlhttp, url, vPost) {
					xmlhttp.open('POST', url, false);
					xmlhttp.send(vPost);
					return xmlhttp.ResponseText;
			}
			
function SendRequest(url) {
		var xmlhttp = CreateXmlHttpReq(DummyHandler);
		++uniqnum_counter;
		return XmlHttpGET(xmlhttp, url + "&rand=" + uniqnum_counter);
}

function PostRequest(url, vPost) {
		var xmlhttp = CreateXmlHttpReq(DummyHandler);
		++uniqnum_counter;
		return XmlHttpPOST(xmlhttp, url + "&rand=" + uniqnum_counter, vPost);
}
