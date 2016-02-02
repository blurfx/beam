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
    public class User
    {
        [DataMember(Name="id")]
        public long Id { get; set; }
        
        [DataMember(Name="screen_name")]
        public string ScreenName { get; set; }
        
        [DataMember(Name="name")]
        public string Name { get; set; }
        
        [DataMember(Name="location")]
        public string Location { get; set; }
        
        [DataMember(Name="url")]
        public string Url { get; set; }
        
        [DataMember(Name="description")]
        public string Description { get; set; }
        
        [DataMember(Name="protected")]
        public bool Protected { get; set; }
        
        [DataMember(Name="verified")]
        public bool verified { get; set; }
        
        [DataMember(Name="followers_count")]
        public int FollowersCount { get; set; }
        
        [DataMember(Name="friends_count")]
        public int FollwingCount { get; set; }
        
        [DataMember(Name="listed_count")]
        public int ListedCount { get; set; }
        
        [DataMember(Name="statuses_count")]
        public int TweetCount { get; set; }
        
        [DataMember(Name="created_at")]
        public string CreatedAt { get; set; }
        
        [DataMember(Name="profile_background_image_url")]
        public string ProfileBackgroundImageUrl { get; set; }
        
        [DataMember(Name="profile_background_image_url_https")]
        public string ProfileBackgroundImageUrlSSL { get; set; }
        
        [DataMember(Name="profile_background_tile")]
        public bool hasProfileBackground { get; set; }
        
        [DataMember(Name="profile_image_url")]
        public string ProfileImageUrl { get; set; }
        
        [DataMember(Name="profile_image_url_https")]
        public string ProfileImageUrlSSL { get; set; }
        
        [DataMember(Name="following")]
        public bool? Following { get; set; }
        
        [DataMember(Name="follow_request_sent")]
        public bool? FollowRequestSent{ get; set; }
        
        [DataMember(Name="notifications")]
        public bool? Notifications{ get; set; }

    }
}
