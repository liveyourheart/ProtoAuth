using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProtoAuth.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid EnterpriseId { get; set; }
        [ForeignKey("EnterpriseId")]
        public Enterprise Enterprise { get; set; }
        public int CID { get; set; }
        public string Name { get; set; }
        public ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}