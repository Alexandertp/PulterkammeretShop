using PulterkammeretShop.Models;

namespace PulterkammeretShop.Helpers
{
    /// <summary>
    /// Skrevet af Kaser, Oliver, WooHooWizard
    /// </summary>
    public class AccountHelper
    {
        private List<Employee> ListeMedAlleEmployees = new List<Employee>();
        private List<Costumer> ListeMedAlleCostumers = new List<Costumer>();
        public AccountHelper()
        {
            ListeMedAlleEmployees = GetEmployees();
            ListeMedAlleCostumers = GetCostumers();
        }
        public List<Employee> GetEmployees()
        {
            string[] importTekst = System.IO.File.ReadAllLines("Employee.txt");
            List<Employee> employeeListeTemp = new List<Employee>();
            foreach (string employee in importTekst)
            {
                string[] splitArr = employee.Split(',');
                int newId = Convert.ToInt32(splitArr[0]);
                string newName = splitArr[1];
                string newPassword = splitArr[2];
                employeeListeTemp.Add(new Employee(newId, newName, newPassword));

            }
            return employeeListeTemp;
        }
        public List<Costumer> GetCostumers()
        {
            string[] importTekst = System.IO.File.ReadAllLines("Costumers.txt");
            List<Costumer> costumerListeTemp = new List<Costumer>();
            foreach (string costumer in importTekst)
            {
                string[] splitArr = costumer.Split(",");
                int newId = Convert.ToInt32(splitArr[0]);
                string newName = splitArr[1];
                string newPassword = splitArr[2];
                int newPhoneNumber = Convert.ToInt32(splitArr[3]);
                string newAddress = splitArr[4];
                string newPayment = splitArr[5];
                costumerListeTemp.Add(new Costumer(newId, newName, newPassword, newPhoneNumber, newAddress, newPayment));
            }
            return costumerListeTemp;
        }
    }
}


