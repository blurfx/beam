using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Beam.Model
{
    [DataContract]
    public class Tweet
    {
        [DataMember(Name="id")]
        public long Id { get; set; }
        
        [DataMember(Name="text")]
        public string Text { get; set; }

        [DataMember(Name="created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name="source")]
        public string Source { get; set; }

        [DataMember(Name="in_reply_to_status_id")]
        public long? inReplyToStatusId { get; set; }

        [DataMember(Name="in_reply_to_user_id")]
        public long? inReplyToUserId { get; set; }

        [DataMember(Name="in_reply_to_screen_name")]
        public string inReplyToScreenName { get; set; }

        [DataMember(Name="user")]
        public User User { get; set; }

        [DataMember(Name="retweet_count")]
        public int RetweetCount { get; set; }

        [DataMember(Name="favorite_count")]
        public int FavoriteCount { get; set; }

        [DataMember(Name="favorited")]
        public bool Favorited { get; set; }

        [DataMember(Name="retweeted")]
        public bool Retweeted { get; set; }
        
        /* todo 
         * geo, coordinates, place, contributors, retweeted_status,entities,
         */
    }
}
