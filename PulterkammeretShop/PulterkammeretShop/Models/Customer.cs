using Microsoft.AspNetCore.Identity;

namespace PulterkammeretShop.Models
{
    public class Customer : Account
    {
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PaymentInfo { get; set; }

        /// <summary>
        /// Skrevet af Oliver Frølund
        /// </summary>
        public Customer(int Id, string Name, string Password, int PhoneNumber, string Address, string PaymentInfo)
        {
            int id = Id;
            string name = Name;
            string password = Password;
            int phoneNumber = PhoneNumber;
            string address = Address;
            string paymentInfo = PaymentInfo;
        }
        List <Ordre> ordre = new List<Ordre>();
    }
}
