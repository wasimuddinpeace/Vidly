namespace Vidly.Models
{
    public class MembershipType
    {
        public byte MembershipTypeID { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte Discount { get; set; }
        public string Name { get; set; }
    }
}