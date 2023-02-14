<%
Response.Expires = -1
Response.Expiresabsolute = Now() - 1
Response.AddHeader "pragma","no-cache"
Response.AddHeader "cache-control","private"
Response.CacheControl = "no-cache"

'// Pastas para anexar arquivos
Const Conn = "UID=itc2;PWD=@#zaq3469;driver={SQL Server};SERVER=127.0.0.1;DATABASE=itc"

Const CaminhoArquivoBanner = "/imgsBanners/"
Const CaminhoArquivoPaginas = "/imgsPages/"
Const CaminhoArquivoNoticias = "/imgsNoticias/"
Const CaminhoArquivoInforma = "/imgsInforma/"
Const CaminhoArquivoIndice = "/imgsIndices/"
Const CaminhoArquivoEventos = "/imgsEventos/"
Const CaminhoArquivoNovasPaginas = "/"

Const titPage = ".: ITC.NET :. "
Const var_EmailSite = "suporte@itc.etc.br"
'Const var_EmailSite = "desenvolvimento@brochura.com.br"
Const var_QtdRegsPagina = 30

Const var_conf_email_envio = ""
Const var_conf_email_pass = ""
Const var_conf_smtp = ""
Const var_conf_smtp_port = ""

%>