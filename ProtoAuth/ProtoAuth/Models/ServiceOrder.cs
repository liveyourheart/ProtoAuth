using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProtoAuth.Models
{
    public class ServiceOrder
    {
        public Guid Id { get; set; }
        public int ServiceOrderNumber { get; set; }
        public string Description { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
    }
}