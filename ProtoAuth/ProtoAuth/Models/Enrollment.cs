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
        [ForeignKey("ClientUserId")]
        public ClientUser ClientUser { get; set; }
        public Guid EnterpriseId { get; set; }
        [ForeignKey("EnterpriseId")]
        public Enterprise Enterprise { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public Guid ServiceOrderId { get; set; }
        [ForeignKey("ServiceOrderId")]
        public ServiceOrder ServiceOrder { get; set; }
    }
}