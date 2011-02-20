using System;
namespace Twitter.API
{
	public class User
	{
	  public string profile_sidebar_border_color;
      public string name{
				set;
				get;
	  }
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
      public Nullable<double> utc_offset;
      public Nullable<double> id;
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
      public Nullable<double> friends_count;
      public Nullable<double> statuses_count;
      public string profile_background_image_url;
      public string screen_name;
      public Nullable<bool> show_all_inline_media;
      public Nullable<bool> following;
		
		public User ()
		{
			
		}
		
		
	}
}

