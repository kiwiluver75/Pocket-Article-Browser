
namespace PocketApplication
{
	using System;
	using System.Web;
	using System.Web.UI;
	using System.Net;
	using System.Collections.Specialized;
	using System.IO;
	using Newtonsoft.Json.Linq;
	using Newtonsoft.Json.Serialization;
	using Newtonsoft.Json.Converters;
	using System.Collections.Generic;

	
	public partial class loggedin : System.Web.UI.Page
	{
		public void Page_Load(object sender, EventArgs e)
		{

			StreamReader sr = new StreamReader("Public/codes.txt");

			var cons_key = sr.ReadLine ();
			var code = sr.ReadLine ();
			sr.Close ();

			var Response2 = new Byte[400];

			using (var wb = new WebClient())
			{
				var data = new NameValueCollection();


				data["consumer_key"] = "29462-39df871daf6e48422ebe3a5d";
				data ["code"] = code;

				var url = "https://getpocket.com/v3/oauth/authorize";

				Response2 = wb.UploadValues(url, "POST", data);


			}

			string str = System.Text.Encoding.Default.GetString(Response2);

			var s1 = Server.UrlDecode (str);

			char[] a = { '=', '&' };

			string[] sarr = s1.Split(a);


			var acc_token = sarr [1];


			var Response3 = new Byte[400];

			using (var wb = new WebClient())
			{
				var data = new NameValueCollection();


				data["consumer_key"] = "29462-39df871daf6e48422ebe3a5d";
				data ["access_token"] = acc_token;
				data ["detail_type"] = "complete";
				data ["contentType"] = "article";


				var url = "https://getpocket.com/v3/get";

				Response3 = wb.UploadValues(url, "POST", data);

			}

			string r1 = System.Text.Encoding.Default.GetString(Response3);

			JObject articles = JObject.Parse(r1);

			var results = articles["list"].Children(); 

			Firstul.InnerHtml = "";

			var num = 1;

			foreach (JToken child in results)
			{
				foreach (JToken grandchild in child) 
				{
					string src = "http://images.shrinktheweb.com/xino.php?stwembed=1&stwaccesskeyid=eeccf91c1051d54&stwsize=xlg&stwurl=" + grandchild ["resolved_url"].ToString ();

					string src1 = "Public/" + num +".jpg";


					using (WebClient client = new WebClient ()) {
						client.DownloadFile (src, src1);
						}
				


					Firstul.InnerHtml += "<li onclick=\"location.href=\'" + grandchild ["resolved_url"].ToString () + "\'\" id=\"Item-" + num + "\" title=\"Item " + num + " Title\"> ";
					Firstul.InnerHtml += "<img  src=\"" + src1 + "\" />";
					Firstul.InnerHtml += "<p> <b>" + grandchild ["resolved_title"].ToString () + "</b></p>";
					Firstul.InnerHtml += "<p> <b>Word Count:</b> " + grandchild ["word_count"].ToString () + "</p>";
					Firstul.InnerHtml += "<p> <b>Excerpt:</b> " + grandchild ["excerpt"].ToString () + "</p>" + "</li>";
				

					num++;

				}
			}



			var x = 2;
			x += 2;
		}
	}
}

