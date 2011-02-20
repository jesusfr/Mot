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
			
			Console.WriteLine("Looking for the last 10 tweets");	

			Tweet[] tl = api.retriveTimeline(10);
			
			foreach(Tweet t in tl){
				Console.WriteLine("From:" + t.user.name + ":");
				Console.WriteLine("tweet:" + t.text);
				Console.WriteLine();
			}
            
			Console.WriteLine("TL END");
            Console.ReadKey();
				
			
		}
	}
}

