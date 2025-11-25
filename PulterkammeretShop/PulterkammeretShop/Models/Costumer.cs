using Microsoft.AspNetCore.Identity;

namespace PulterkammeretShop.Models
{
    public class Costumer : Account
    {
        /// <summary>
        /// Skrevet af Oliver Frølund
        /// </summary>
        public Costumer(int Id, string Name, string Password, int PhoneNumber, string Address, string PaymentInfo)
        {
            int id;
            string name;
            string password;
            int phoneNumber;
            string address;
            string paymentInfo;
        }
        List <Ordre> ordre = new List<Ordre>();
    }
}
