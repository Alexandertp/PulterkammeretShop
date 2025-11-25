using Microsoft.AspNetCore.Identity;

namespace PulterkammeretShop.Models
{
    public class Customer : Account
    {
        public int phoneNumber { get; set; }
        public string address { get; set; }
        public string paymentInfo { get; set; }

        /// <summary>
        /// Skrevet af Oliver Frølund
        /// </summary>
        public Customer(int? Id, string Name, string Password, int PhoneNumber, string Address, string PaymentInfo)
        {
            if (Id == null)
            {
                id = 1;
            }
            else
            {
                id = (int)Id;
            }
            name = Name;
            password = Password;
            phoneNumber = PhoneNumber;
            address = Address;
            paymentInfo = PaymentInfo;
        }
        List <Ordre> ordre = new List<Ordre>();
    }
}
