using System;
using System.IO;
using Newtonsoft.Json;

namespace Twitter.API
{
	public class Principal{
		
		
		public Principal (){
		
		}
		
		public static void Main(){
			
			
			API api = new API();
				
			//api.sendTweet("");
			Tweet[] tweet = JsonConvert.DeserializeObject<Tweet[]>(api.retriveTimeline(1)); 
			Console.WriteLine(tweet[0].id);
			//Console.WriteLine(api.retriveTimeline(1));
			//Console.WriteLine(tw.id);
			Console.WriteLine("fin");
	
				
			
		}
	}
}

