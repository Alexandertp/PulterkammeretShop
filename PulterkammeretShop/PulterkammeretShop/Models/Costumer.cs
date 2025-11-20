namespace PulterkammeretShop.Models
{
    public class Costumer : Account
    {
        /// <summary>
        /// Skrevet af Oliver Frølund
        /// </summary>
        public Costumer()
        {
            int id;
            string name;
            string password;
            int phoneNumber;
            string address;
            string paymentInfo;
        }
        List <Spil> Orders = new List<Spil>();

        public void addToOrder(int id, string input)
        {
            Orders.Add(new Spil(1000, "Matador", 299));
        }
    }
}
