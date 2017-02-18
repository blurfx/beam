using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Beam.TwitterCore.Models
{
    [DataContract]
    public class DeleteWrapper {
        [DataMember(Name = "delete")]
        public Delete Delete { get; set; }
    }

    [DataContract]
    public class Delete
    {
        [DataMember(Name = "status")]
        public DeletedStatus Status { get; set; }
    }

    [DataContract]
    public class DeletedStatus
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "user_id")]
        public long UserId { get; set; }
    }
}
