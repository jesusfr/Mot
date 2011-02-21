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
			Tweet[] tl = null;
			
			System.Diagnostics.Process.Start(api.AuthLink());
			Console.WriteLine("Pin:");
			string pin = Console.ReadLine();
			api.Authentication(pin);
			
			Console.WriteLine("Looking for the last 10 tweets");	

			tl = api.retriveTimeline(10);
			
			foreach(Tweet t in tl){
				Console.WriteLine("From:" + t.user.name + ":");
				Console.WriteLine("tweet:" + t.text);
				Console.WriteLine();
			}
            
			Console.WriteLine("TL END");
			
			
			Console.WriteLine("Looking for the last 10 Mentions");	

			tl = api.retriveMentions(10);
			
			foreach(Tweet t in tl){
				Console.WriteLine("From:" + t.user.name + ":");
				Console.WriteLine("tweet:" + t.text);
				Console.WriteLine();
			}
            
			Console.WriteLine("Mentions END");
			
			
            Console.ReadKey();
				
			
		}
	}
}

