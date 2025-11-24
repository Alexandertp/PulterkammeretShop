namespace PulterkammeretShop.Models
{
    public class Account
    {
        public int id  { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        /// <summary>
        /// Skrevet af Anne Sofie
        /// </summary>
        public Account()
        {
            int id;
            string name;
            string password;
        }
    }
}