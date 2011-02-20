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
    public string text
    {
        set;
        get;
    }
		
	public double id;
	public int retweet_count;
	public double in_reply_to_status_id_str;
    public double geo;
	public Nullable<bool> retweeted;
    public double in_reply_to_user_id;
    public double in_reply_to_screen_name;
	
    [DataMember]
	public User user{
		set;
		get;
	}
    public Nullable<bool> place;
    public string source;
    public Nullable<bool> in_reply_to_status_id;
  }

}
