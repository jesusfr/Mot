using System;
using System.Runtime.Serialization;


namespace Twitter.API
{
	[DataContract]
	public class Tweet
	{
		
	public Nullable<bool> coordinates;
	public Nullable<bool> favorited;
	public Nullable<bool> truncated;
    public string created_at;
    public string id_str;
    public string in_reply_to_user_id_str;
    public Nullable<bool> contributors;
	
	[DataMember]
    public string text{
			set{}
			get{return text;}
	}
	public double id;
	public int retweet_count;
	public double in_reply_to_status_id_str;
    public double geo;
	public Nullable<bool> retweeted;
    public double in_reply_to_user_id;
    public double in_reply_to_screen_name;
	
	public class user{
      public string profile_sidebar_border_color;
      public string name;
      public Nullable<bool> profile_background_tile;
      public string profile_sidebar_fill_color;
      public string profile_image_url;
      public string created_at;
      public string location;
      public string profile_link_color;
      public string id_str;
      public Nullable<bool> follow_request_sent;
      public Nullable<bool> is_translator;
      public Nullable<bool> contributors_enabled;
      public string url;
      public int favourites_count;
      public double utc_offset;
      public double id;
      public int listed_count;
      public Nullable<bool> profile_use_background_image;
      public double followers_count;
      public string lang;
      public Nullable<bool> @protected;
      public string profile_text_color;
      public Nullable<bool> notifications;
      public Nullable<bool> verified;
      public string time_zone;
      public Nullable<bool> geo_enabled;
	  public string profile_background_color;
      public string description;
      public double friends_count;
      public double statuses_count;
      public string profile_background_image_url;
      public string screen_name;
      public Nullable<bool> show_all_inline_media;
      public Nullable<bool> following;
    }
		
    public Nullable<bool> place;
    public string source;
    public Nullable<bool> in_reply_to_status_id;
  }

}
