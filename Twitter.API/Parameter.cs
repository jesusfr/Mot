using System;
namespace Twitter.API
{
	public class Parameter{

            private string name = null;
            private string value = null;

            public Parameter(string name, string value){
                
				this.name = name;
                this.value = value;
            
			}

            public string Name{
			
                get { return name; }
            }

            public string Value{
			
                get { return value; }
            
        	}
	
	}
}

