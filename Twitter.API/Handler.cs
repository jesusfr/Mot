using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.IO;
using System.Text;

namespace Twitter.API
{
	public class Handler{
		
		//Characters that HTTP can hanndle
		private static string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
		
		public enum Method { GET, POST };
		
		/// <summary>
		/// Here is a wapper to de System.Net.WebRequest that process POST data when is necesary.
		/// </summary>
		/// <param name="method">
		/// A <see cref="Method"/>
		/// </param>
		/// <param name="url">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="postData">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public static string WebRequest(Method method, string url, string postData){
            
			HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

			
			
            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
          
			
            if (method == Method.POST){
				
                webRequest.ContentType = "application/x-www-form-urlencoded";
				requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try{
                
					requestWriter.Write(postData);
				
				}catch{
				
					throw;
			    
				}finally{
					
                    requestWriter.Close();
                    requestWriter = null;
					
                }
            }

            responseData = WebResponseGet(webRequest);
			
            webRequest = null;

            return responseData;
        }
		
		
		public static string WebResponseGet(HttpWebRequest request){
            
			StreamReader reader = null;
            string response = "";

            try{
				
				reader = new StreamReader(request.GetResponse().GetResponseStream());
				response = reader.ReadToEnd();
            
			}catch(Exception ex){
				
				Console.WriteLine(ex.Message);
				Console.Write(ex.StackTrace); 
				throw;
            
			}finally{
				
                request.GetResponse().GetResponseStream().Close();
                reader.Close();
                reader = null;
            }

            return response;
        }
		
		
		
		public static string ComputeHash(HashAlgorithm ha, string data){
			
            if (ha == null){
                throw new ArgumentNullException("hashAlgorithm");
            }

            if (string.IsNullOrEmpty(data)){
                throw new ArgumentNullException("data");
            }

            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
            byte[] hash = ha.ComputeHash(buffer);

            return Convert.ToBase64String(hash);
        }

	
		public static string UrlEncode(string st){
			
            StringBuilder result = new StringBuilder();

            foreach (char s in st){
                if (unreservedChars.IndexOf(s) != -1)
                    result.Append(s);
                else
                    result.Append('%' + String.Format("{0:X2}",(int) s));
            }

            return result.ToString();
        }
		
		public static List<Parameter> GetParameters(string pmt){
			
            if (pmt.StartsWith("?")){
                pmt = pmt.Remove(0, 1);
            }

            List<Parameter> result = new List<Parameter>();

            if (!string.IsNullOrEmpty(pmt)){
				
                string[] p = pmt.Split('&');
                
				foreach (string s in p){
					
                    if (!string.IsNullOrEmpty(s) && !s.StartsWith("oauth_")){
						
                        if (s.IndexOf('=') > -1){
                            string[] temp = s.Split('=');
                            result.Add(new Parameter(temp[0], temp[1]));
                        }else
                            result.Add(new Parameter(s, string.Empty));
                        
                    }
                }
            }
			return result;
        }
		
		public static string NormalizeRequestParameters(IList<Parameter> pmt){
			
            StringBuilder sb = new StringBuilder();
            Parameter p = null;
            
			for (int i = 0; i < pmt.Count; i++){
				
                p = pmt[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < pmt.Count - 1){
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

	} 
}


