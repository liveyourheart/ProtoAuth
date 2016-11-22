using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProtoAuth.Models
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        [ForeignKey("ClientUser")]
        public Guid ClientUserId { get; set; }
        public Guid EnterpriseID { get; set; }
        public int CID { get; set; }
        public string Name { get; set; }
    }
}