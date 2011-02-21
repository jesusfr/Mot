using System;
using System.Collections.Specialized;
using Twitter.API;
using System.Web;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;


namespace Twitter.API
{
	
	public class Oauth
	{
		
		
		public const string REQUEST_TOKEN = "http://twitter.com/oauth/request_token";
        public const string AUTHORIZE = "http://twitter.com/oauth/authorize";
        public const string ACCESS_TOKEN = "http://twitter.com/oauth/access_token";
		
		protected const string OAuthConsumerKeyKey = "oauth_consumer_key";
        protected const string OAuthCallbackKey = "oauth_callback";
        protected const string OAuthVersionKey = "oauth_version";
        protected const string OAuthSignatureMethodKey = "oauth_signature_method";
        protected const string OAuthSignatureKey = "oauth_signature";
        protected const string OAuthTimestampKey = "oauth_timestamp";
        protected const string OAuthNonceKey = "oauth_nonce";
        protected const string OAuthTokenKey = "oauth_token";
        protected const string OAuthTokenSecretKey = "oauth_token_secret";
        protected const string OAuthVerifierKey = "oauth_verifier"; 
		
 		protected const string OAuthVersion = "1.0";
        protected const string OAuthParameterPrefix = "oauth_";       
		
		protected const string HMACSHA1SignatureType = "HMAC-SHA1";
        
		private string _consumerKey = "";
        private string _consumerSecret = "";
        private string _token = "";
        private string _tokenSecret = "";
        private string _pin = ""; 
		
		protected Random random = new Random();
 		
		
        public string ConsumerKey{ 
			get {return _consumerKey;} 
            set { _consumerKey = value; } 
        }
        
        public string ConsumerSecret { 
            get {return _consumerSecret;} 
            set { _consumerSecret = value; } 
        }

		public string Token { 
			get { return _token; } 
			set { _token = value;}
		}
        
		public string PIN { 
			get { return _pin; } 
			set { _pin = value;} 
		}
		
        public string TokenSecret { 
			get { return _tokenSecret; } 
			set { _tokenSecret = value;} 
		}
		
		public string OAuthToken { get; set; }
        
		
		public Oauth (){
			ConsumerKey = "4kNE1dLcVgdCSHUN2o6aaA";
            ConsumerSecret = "kEjDsRBRtYAKJuwdnY8XaqYojiSZG2Jmgms1tL37zM";
			PIN = null;
		}
		
					
		public string oAuthWebRequest(Handler.Method method, string url, string postData){
            
			string outUrl = "";
            string querystring = "";
            string ret = "";


            //Setup postData for signing.
            //Add the postData to the querystring.
            if (method == Handler.Method.POST){
				
                if (postData.Length > 0){
					
                    //Decode the parameters and re-encode using the oAuth UrlEncode method.
                    NameValueCollection qs = HttpUtility.ParseQueryString(postData);
                    postData = "";
                    foreach (string key in qs.AllKeys){
						
                        if (postData.Length > 0){
                            postData += "&";
                        }
						
                        qs[key] = HttpUtility.UrlDecode(qs[key]);
                        qs[key] = Handler.UrlEncode(qs[key]);
                        postData += key + "=" + qs[key];

                    }
					
                    if (url.IndexOf("?") > 0){
                        url += "&";
                    }else{
                        url += "?";
                    }
                    url += postData;
                }
            
			}else if (method == Handler.Method.GET && !String.IsNullOrEmpty(postData)){
                url += "?" + postData;
            }

            Uri uri = new Uri(url);
            
            string nonce = this.GenerateNonce();
            string timeStamp = this.GenerateTimeStamp();

            //Generate Signature
            string sig = this.GenerateSignature(uri,this.ConsumerKey,this.ConsumerSecret,this.Token,this.TokenSecret,method.ToString(),
                timeStamp,nonce,this.PIN,out outUrl,out querystring);

            querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);

            //Convert the querystring to postData
            if (method == Handler.Method.POST)
            {
                postData = querystring;
                querystring = "";
            }

            if (querystring.Length > 0)
            {
                outUrl += "?";
            }

			
            ret = Handler.WebRequest(method, outUrl +  querystring, postData);
			
            return ret;
        }
		
		public string GenerateSignature(Uri url, string consumerKey, string consumerSecret, string token, string tokenSecret, string httpMethod, string timeStamp, string nonce, string PIN, out string normalizedUrl, out string normalizedRequestParameters){
            
			normalizedUrl = null;
            normalizedRequestParameters = null;

            
            string signatureBase = this.GenerateSignatureBase(url, consumerKey, token, tokenSecret, httpMethod, timeStamp, nonce, PIN, out normalizedUrl, out normalizedRequestParameters);

            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", Handler.UrlEncode(consumerSecret), string.IsNullOrEmpty(tokenSecret) ? "" : Handler.UrlEncode(tokenSecret)));
			
		   return Handler.ComputeHash(hmacsha1,signatureBase);
                
        }
		
		
		public string GenerateSignatureBase(Uri url, string consumerKey, string token, string tokenSecret, string httpMethod, string timeStamp, string nonce, string PIN, out string normalizedUrl, out string normalizedRequestParameters)
        {
            if (token == null)
            {
                token = string.Empty;
            }

            if (tokenSecret == null)
            {
                tokenSecret = string.Empty;
            }

            if (string.IsNullOrEmpty(consumerKey))
            {
                throw new ArgumentNullException("consumerKey");
            }

            if (string.IsNullOrEmpty(httpMethod))
            {
                throw new ArgumentNullException("httpMethod");
            }


            normalizedUrl = null;
            normalizedRequestParameters = null;

            List<Parameter> parameters = Handler.GetParameters(url.Query);
            parameters.Add(new Parameter(OAuthVersionKey, OAuthVersion));
            parameters.Add(new Parameter(OAuthNonceKey, nonce));
            parameters.Add(new Parameter(OAuthTimestampKey, timeStamp));
            parameters.Add(new Parameter(OAuthSignatureMethodKey, HMACSHA1SignatureType ));
            parameters.Add(new Parameter(OAuthConsumerKeyKey, consumerKey));

            if (!string.IsNullOrEmpty(token))
            {
                parameters.Add(new Parameter(OAuthTokenKey, token));
            }


            if (!String.IsNullOrEmpty(PIN))
            {
                parameters.Add(new Parameter(OAuthVerifierKey, PIN));
            }

            parameters.Sort(new ParameterComparer());

            normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                normalizedUrl += ":" + url.Port;
            }

            normalizedUrl += url.AbsolutePath;
            normalizedRequestParameters = Handler.NormalizeRequestParameters(parameters);

            StringBuilder signatureBase = new StringBuilder();
            signatureBase.AppendFormat("{0}&", httpMethod.ToUpper());
            signatureBase.AppendFormat("{0}&", Handler.UrlEncode(normalizedUrl));
            signatureBase.AppendFormat("{0}", Handler.UrlEncode(normalizedRequestParameters));

            return signatureBase.ToString();
        }
		
		public void AccessTokenGet(string authToken, string PIN)
        {
            this.Token = authToken;
            this._pin = PIN;

            string response = oAuthWebRequest(Handler.Method.GET, ACCESS_TOKEN, String.Empty);

            if (response.Length > 0)
            {
                //Store the Token and Token Secret
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    this.Token = qs["oauth_token"];
                }
                if (qs["oauth_token_secret"] != null)
                {
                    this.TokenSecret = qs["oauth_token_secret"];
                }
            }
        }
		
		public string AuthorizationLinkGet()
        {
            string ret = null;

            // First let's get a REQUEST token.
            string response = oAuthWebRequest(Handler.Method.GET, REQUEST_TOKEN, String.Empty);
            if (response.Length > 0)
            {
                //response contains token and token secret.  We only need the token.
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    OAuthToken = qs["oauth_token"]; // tuck this away for later
                    ret = AUTHORIZE + "?oauth_token=" + qs["oauth_token"];// +"&oauth_callback=oob";
                }
            }
            return ret;
        }

		
        public virtual string GenerateTimeStamp(){
            // Default implementation of UNIX time of the current UTC time
            return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        }

        public virtual string GenerateNonce(){
            return random.Next(123400, 9999999).ToString();
        }
		
	}
	
}

