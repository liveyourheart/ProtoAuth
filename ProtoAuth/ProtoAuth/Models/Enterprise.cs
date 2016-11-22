using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoAuth.Models
{
    public class Enterprise
    {
        public Guid Id { get; set; }
        public int EnterpriseNumber { get; set; }
        public string Name { get; set; }
    }
}