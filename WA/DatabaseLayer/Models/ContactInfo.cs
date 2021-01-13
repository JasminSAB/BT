namespace WA.DatabaseLayer.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
    }
}
