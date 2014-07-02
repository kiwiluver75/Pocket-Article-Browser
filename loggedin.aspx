<%@ Page Language="C#" Inherits="PocketApplication.loggedin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head runat="server">
	<title>loggedin</title>
	<link rel="stylesheet" href="Public/jquery.flipster.min.css">

</head>
<body>
	<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	<script>window.jQuery || document.write('<script src="/js/jquery-1.10.2.min.js"><\/script>')</script>
	<script src="Public/jquery.flipster.min.js"></script>

	<script language="javascript" type="text/javascript">
		$(function(){ $('.flipster').flipster({ start: 0,} ); });
	</script>

	<form id="form1" runat="server">
		<h1 align="center"> Pocket Article Browser </h1>
		<div class="flipster">
    		<ul id="Firstul" class="flip-items" runat="server">

        		<li id="Item-2" title="Item 2 Title">
            	<img src="" />
        		</li>
        	
  			</ul>
		</div>
	</form>
</body>
</html>
