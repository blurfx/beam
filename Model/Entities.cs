using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Beam.Model
{
    [DataContract]
    public class Entities
    {
        [DataMember(Name = "user_mentions")]
        public List<Mention> Mentions { get; set; }

        [DataMember(Name = "urls")]
        public List<Urls> Urls { get; set; }

        [DataMember(Name = "media")]
        public List<Media> Media { get; set; }
    }

    [DataContract]
    public class Mention
    {
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "indices")]
        public List<int> Index { get; set; }
    }

    [DataContract]
    public class Urls
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "expanded_url")]
        public string ExapndedUrl { get; set; }

        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; set; }

        [DataMember(Name = "indices")]
        public List<int> Index { get; set; }
    }

    [DataContract]
    public class Media
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "indices")]
        public List<int> Index { get; set; }

        [DataMember(Name = "media_url_https")]
        public string MediaUrl { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "expanded_url")]
        public string ExapndedUrl { get; set; }

        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "sizes")]
        public Sizes Sizes { get; set; }
    }

    [DataContract]
    public class Sizes
    {

        [DataMember(Name = "small")]
        public Size Small { get; set; }

        [DataMember(Name = "large")]
        public Size Large { get; set; }

        [DataMember(Name = "thumb")]
        public Size Thumb { get; set; }

        [DataMember(Name = "medium")]
        public Size Medium { get; set; }

    }

    [DataContract]
    public class Size
    {
        [DataMember(Name = "w")]
        public int Width { get; set; }

        [DataMember(Name = "h")]
        public int Height { get; set; }

        [DataMember(Name = "resize")]
        public string Resize { get; set; }
    }
}
