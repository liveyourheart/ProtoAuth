using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoAuth.Models
{
    public class ClientUserDTO
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string UnhashedPassword { get; set; }
        public int TrendsRoleId { get; set; }
        public int EnterpriseNumber { get; set; }
        public List<int> CustomerPrograms { get; set; }
        public List<int> ServiceOrders { get; set; }

        public ClientUserDTO()
        {
            CustomerPrograms = new List<int>();
            ServiceOrders = new List<int>();
        }
    }
}