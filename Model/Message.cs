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
    public class MessageWrapper
    {
        [DataMember(Name = "direct_message")]
        public Message Message;
    }

    [DataContract]
    public class Message
    {
        [DataMember(Name="id")]
        public long Id { get; set; }

        [DataMember(Name="text")]
        public string Text { get; set; }

        [DataMember(Name="sender")]
        public User Sender { get; set; }

        [DataMember(Name="recipient")]
        public User Recipient { get; set; }

        [DataMember(Name="created_at")]
        public string CreatedAt { get; set; }
        /* todo: entities */
    }
}
