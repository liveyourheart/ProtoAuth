using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProtoAuth.Models
{
    public class ClientUser
    {
        [Key]
        public Guid Id { get; set; }
        [EmailAddress]
        public string UserName { get; set; }

        public string UnhashedPassword { get; set; }
        public int TrendsRoleId { get; set; }
    }
}