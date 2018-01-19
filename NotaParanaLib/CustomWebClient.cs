using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NotaParanaLib
{
    class CustomWebClient : WebClient
    {
        public string UserAgent { get; set; }
        public CookieContainer CookieContainer { get; private set; }
        public int StatusCode { get; private set; }
        public Uri RedirectUri { get; private set; }
        public Uri ResponseUri { get; private set; }

        public CustomWebClient()
        {
            CookieContainer = new CookieContainer();
        }


        public bool IsRedirect()
        {
            return StatusCode == 302 && !string.IsNullOrEmpty(ResponseHeaders["Location"]);
        }

        public string UploadString(string address, string data)
        {
            try
            {
                return base.UploadString(address, data);
            }
            catch (WebException ex)
            {
                string responseText;

                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }

                return responseText;

            }
        }

        public string RedirectString()
        {
            return DownloadString(ResponseHeaders["Location"]);
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
            
            var request = base.GetWebRequest(address);

            
            var httpRequest = request as HttpWebRequest;

            if (httpRequest != null)
            {                

                httpRequest.AllowAutoRedirect = string.Compare(httpRequest.Method, "GET", true) == 0 ? true : false;
                httpRequest.CookieContainer = CookieContainer;
                httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                httpRequest.ServicePoint.Expect100Continue = false;
            }
            



            return httpRequest;
        }

         
        protected override WebResponse GetWebResponse(WebRequest request)
        {
                var response = base.GetWebResponse(request);
                String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];


                var httpResponse = response as HttpWebResponse;
                ResponseUri = httpResponse.ResponseUri;
                StatusCode = (int)httpResponse.StatusCode;
                RedirectUri = ResponseHeaders["Location"] == null ? null : new Uri(ResponseHeaders["Location"]);
                return response;
            
        }

       

    }
}
