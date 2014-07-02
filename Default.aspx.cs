
namespace PocketApplication
{
	using System;
	using System.Web;
	using System.Web.UI;
	using System.Net;
	using System.Collections.Specialized;
	using PocketApplication;
	using System.IO;

	
	public partial class Default : System.Web.UI.Page
	{
		
		public void LoginToPocket (object sender, EventArgs args)
		{
			var Response1 = new Byte[4];

			string cons_key = "29462-39df871daf6e48422ebe3a5d";

			using (var wb = new WebClient())
			{
				var data = new NameValueCollection();


				data["consumer_key"] = "29462-39df871daf6e48422ebe3a5d";
				data["redirect_uri"] = "localhost:8080/loggedin.aspx";

				var url = "https://getpocket.com/v3/oauth/request";

				Response1 = wb.UploadValues(url, "POST", data);
			}

			string str = System.Text.Encoding.Default.GetString(Response1);

			char[] a = { '=' };

			string[] ss1 = str.Split (a);

			string acc_token = ss1 [1];


			StreamWriter sw = new StreamWriter("Public/codes.txt");
			sw.WriteLine ("29462-39df871daf6e48422ebe3a5d");
			sw.WriteLine (acc_token);
			sw.Close ();


			string redstr = string.Format ("https://getpocket.com/auth/authorize?request_token={0}&redirect_uri={1}", acc_token, "http://localhost:8080/loggedin.aspx");

			Response.Redirect (redstr);





		}
	}
}

