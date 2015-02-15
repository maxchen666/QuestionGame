using System;
using Xamarin.Forms;
using ify.Model;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace ify.ViewModel
{
	public class QuestionViewModel
	{
		public ProductModel product = new ProductModel();

		public QuestionViewModel ()
		{
		}

		public void Load()
		{
			string url = "https://dl.dropboxusercontent.com/u/30107414/game.json";

			HttpWebResponse wrResp = null;
			HttpWebRequest wrReq = (HttpWebRequest)WebRequest.Create(url);
			wrReq.Method = "GET";
			wrReq.ContentType = "text/xml";
			Encoding encoding = Encoding.GetEncoding("utf-8");
			string responseMessage = "";

			try
			{
				// Execute on the url
				wrResp = (HttpWebResponse)GetResponse(wrReq);

				// Interpret the response
				Stream sr1 = wrResp.GetResponseStream();
				StreamReader srResponse = new StreamReader(sr1, encoding);
				responseMessage = srResponse.ReadToEnd();

				product = JsonConvert.DeserializeObject<ProductModel> (responseMessage);
			}
			catch (WebException ex)
			{
				responseMessage = ex.ToString();
			}
		}

		public WebResponse GetResponse(WebRequest request){
			ManualResetEvent evt = new ManualResetEvent (false);
			WebResponse response = null;
			request.BeginGetResponse ((IAsyncResult ar) => {
				response = request.EndGetResponse(ar);
				evt.Set();
			}, null);
			bool ret = evt.WaitOne (TimeSpan.FromSeconds(30));
			if (!ret) {
				response = null;
			}
			return response as WebResponse;
		}

		public Stream GetRequestStream(WebRequest request){
			ManualResetEvent evt = new ManualResetEvent (false);
			Stream requestStream = null;
			request.BeginGetRequestStream ((IAsyncResult ar) => {
				requestStream = request.EndGetRequestStream(ar);
				evt.Set();
			}, null);
			bool ret = evt.WaitOne (TimeSpan.FromSeconds(30));
			if (!ret) {
				requestStream = null;
			}
			return requestStream;
		}
	}
}

