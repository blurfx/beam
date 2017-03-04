using System.Runtime.Serialization;

namespace Beam.TwitterCore.Model
{
    [DataContract]
    public class Status
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public StatusEntities entities { get; set; }
        public string source { get; set; }
        public long? in_reply_to_status_id { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public long? in_reply_to_user_id { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public string in_reply_to_screen_name { get; set; }
        private object geo { get; set; }     //this field is deprecated, use coordinates field instead.
        public Coordinates coordinates { get; set; }
        public Place place { get; set; }           // object type fields must be implemented. check here https://dev.twitter.com/overview/api/tweets
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public int retweet_count { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public string lang { get; set; }

        public StatusError errors { get; set; }
    }

    public class StatusError
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
