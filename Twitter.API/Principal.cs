using System;
using System.IO;
using ServiceStack.Text;
using Newtonsoft.Json;

namespace Twitter.API
{
	public class Principal{
		
		
		public Principal (){
		
		}
		
		public static void Main(){
			
			
			API api = new API();
			Console.WriteLine("Me preparo a buscar el tweet");	
			//api.sendTweet("");
			String tweet = api.retriveTimeline(10);//.Split(new char[]{'[',']'},StringSplitOptions.RemoveEmptyEntries)[0];
			
			Console.WriteLine("tweet antes de ser parseado");
			Console.WriteLine(tweet);
			Console.WriteLine();
			
			//Tweet[] tw = TypeSerializer.DeserializeFromString<Tweet[]>(tweet); 
			
			Tweet[] tw = JsonConvert.DeserializeObject<Tweet[]>(tweet);
			
			Console.WriteLine("tweet despues de ser parseado");
			
			foreach(Tweet t in tw){
				Console.WriteLine(t.user.name + ":");
				Console.WriteLine(t.text);
				Console.WriteLine();
			}
            
			Console.WriteLine("fin");
            Console.ReadKey();
				
			
		}
	}
}

