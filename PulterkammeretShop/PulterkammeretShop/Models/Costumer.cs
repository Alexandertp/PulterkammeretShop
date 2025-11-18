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
        List <Vare> Orders = new List<Vare>();

        public void addToOrder(int id, string input)
        {
            Orders.Add(new Vare(id, input));
        }
    }
}
