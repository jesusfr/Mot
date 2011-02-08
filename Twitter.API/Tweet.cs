using System;
using Newtonsoft.Json;

namespace Twitter.API
{
	
	[JsonObject(MemberSerialization.OptIn)]
	public class Tweet:JsonSerializer
	{
		
		[JsonProperty(PropertyName = "id")]	
		public string id{
			get{return id;}
			set{}
		}
	
//		[JsonProperty(PropertyName = "coordinates")]
//		public string  coordinates{
//				set;
//				get;
//		}
//	
//		[JsonProperty(PropertyName = "created_at")]
//		public string  created_at{
//				set;
//				get;
//		}
//	
//		[JsonProperty(PropertyName = "truncated")]
//		Nullable<bool>  truncated{
//				set;
//				get;
//		}
//	
//	[JsonProperty(PropertyName = "favorited")]
//	Nullable<bool>  favorited{
//			set;
//			get;
//	}
//	
//	
//	[JsonProperty(PropertyName = "id_str")]
//	public string  id_str{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "in_reply_to_user_id_str")]
//	public string  in_reply_to_user_id_str{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "contributors")]
//	public string  contributors{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "text")]
//	public string  text{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "retweet_count")]
//	public int 	retweet_count{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "in_reply_to_status_id_str")]
//	public string  in_reply_to_status_id_str{
//			set;
//			get;
//	}
//		
//	[JsonProperty(PropertyName = "geo")]
//	public string  geo{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "retweeted")]
//	Nullable<bool>  retweeted{
//			set;
//			get;
//	}
//		
//
//	[JsonProperty(PropertyName = "in_reply_to_user_id")]
//	public string  in_reply_to_user_id{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "source")]
//	public string  source{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "in_reply_to_screen_name")]
//	public string  in_reply_to_screen_name{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "place")]
//	public string  place{
//			set;
//			get;
//	}
//	
//	[JsonProperty(PropertyName = "in_reply_to_status_id")]
//	public string	in_reply_to_status_id{
//			set;
//			get;
//	}

	}
}

///*{
//    "coordinates": null,
//    "created_at": "Fri Jan 28 03:04:40 +0000 2011",
//    "truncated": false,
//    "favorited": false,
//    "id_str": "30823543100932096",
//    "in_reply_to_user_id_str": null,
//    "contributors": null,
//    "text": "Como llegaron los filtros a twitter o como perdi mis amigos imaginarios.",
//    "id": 30823543100932096,
//    "retweet_count": 0,
//    "in_reply_to_status_id_str": null,
//    "geo": null,
//    "retweeted": false,
//    "in_reply_to_user_id": null,
//    
//    "source": "web",
//    "in_reply_to_screen_name": null,
//    "place": null,
//    "in_reply_to_status_id": null
//  }
//  
//  
//  
//  */