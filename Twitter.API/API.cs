using System;
using System.Web;
using Newtonsoft.Json;

namespace Twitter.API
{
	public class API{
		
		private Oauth _oAuth = new Oauth();
		
		public API (){
			
		 		
		}
		
		public void Authentication(string pin){
				_oAuth.PIN = pin;
				_oAuth.AccessTokenGet(_oAuth.OAuthToken, pin);
		}
		
		public string AuthLink(){
				return _oAuth.AuthorizationLinkGet();
		}
		
		
		
		public void sendTweet(string text){
            try{
				
				
				// URL-encode the tweet...
                string tweet = HttpUtility.UrlEncode(text);
				
				_oAuth.oAuthWebRequest(Handler.Method.POST,"http://twitter.com/statuses/update.json","status="+tweet);
				
				
            }catch(Exception ex){
				Console.WriteLine(ex.Message);
				Console.Write(ex.StackTrace);
               	//return null;
            }

           
        }
		
		public Tweet[] retriveTimeline(int count){
		  string timeline = null;
			
			try{
				
			     timeline = _oAuth.oAuthWebRequest(Handler.Method.GET,"http://api.twitter.com/1/statuses/home_timeline.json","count="+count.ToString());
				
            }catch(Exception ex){
				Console.WriteLine(ex.Message);
				Console.Write(ex.StackTrace);
               	return null;
            }
		
			return JsonConvert.DeserializeObject<Tweet[]>(timeline);
		}
		
		public Tweet[] retriveMentions(int count){
		  string mentions = null;
			
			try{
				
			     mentions = _oAuth.oAuthWebRequest(Handler.Method.GET,"http://api.twitter.com/1/statuses/mentions.json","count="+count.ToString());
				
            }catch(Exception ex){
				Console.WriteLine(ex.Message);
				Console.Write(ex.StackTrace);
            }
		
			return JsonConvert.DeserializeObject<Tweet[]>(mentions);
		}
		
		
	}
}

