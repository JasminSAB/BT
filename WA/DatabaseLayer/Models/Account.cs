using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WA.DatabaseLayer.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ContactInfo> ContactInfo { get; set; }

        [NotMapped]
        public int NumberOfContacts { get; set; }
    }
}
