using System;
using System.Web;

namespace Twitter.API
{
	public class API{
		
		private Oauth _oAuth = new Oauth();
		
		public API (){
			
		 		string authLink = _oAuth.AuthorizationLinkGet();
				string pin = null;
                
				// Launch the web browser...
                System.Diagnostics.Process.Start(authLink);
				System.Console.WriteLine("Pin");
				pin = System.Console.ReadLine();
				_oAuth.PIN = pin;
				_oAuth.AccessTokenGet(_oAuth.OAuthToken, pin);
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
		
		public string retriveTimeline(int count){
		  string timeline = null;
			
			try{
				
			     timeline = _oAuth.oAuthWebRequest(Handler.Method.GET,"http://api.twitter.com/1/statuses/home_timeline.json","count="+count.ToString());
				
            }catch(Exception ex){
				Console.WriteLine(ex.Message);
				Console.Write(ex.StackTrace);
               	return null;
            }
		
			return timeline;
		}
		
		public string retriveMentions(int count){
		  string mentions = null;
			
			try{
				
			     mentions = _oAuth.oAuthWebRequest(Handler.Method.GET,"http://api.twitter.com/1/statuses/home_timeline.json","count="+count.ToString());
				
            }catch(Exception ex){
				Console.WriteLine(ex.Message);
				Console.Write(ex.StackTrace);
               	return mentions;
            }
		
			return mentions;
		}
		
		
	}
}

