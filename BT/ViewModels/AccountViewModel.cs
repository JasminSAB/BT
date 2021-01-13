using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BT.Helpers;

namespace BT.ViewModels
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ContactInfoViewModel> ContactInfo { get; set; }
        public int NumberOfContacts { get; set; }
        public string AccountTypeCss { get; set; }
    }
}
