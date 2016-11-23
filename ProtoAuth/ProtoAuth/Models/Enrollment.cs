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
        public Guid ClientUserId { get; set; }
        public Guid EnterpriseId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceOrderId { get; set; }
    }
}