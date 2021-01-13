using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT.ViewModels
{
    public class ContactInfoViewModel
    {
        public int ContactInfoId { get; set; }
        public int AccountId { get; set; }
        public AccountViewModel Account { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
    }
}
