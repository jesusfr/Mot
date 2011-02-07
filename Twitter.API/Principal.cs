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
				
			api.sendTweet("Un domingo largo lleno de algoritmos y estructuras de datos, viendo la emoción un Heap a la vez.");
		
			//Console.WriteLine(tw.id);
			Console.WriteLine("fin");
	
				
			
		}
	}
}

