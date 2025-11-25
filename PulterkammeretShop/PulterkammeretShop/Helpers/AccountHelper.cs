using PulterkammeretShop.Models;

namespace PulterkammeretShop.Helpers
{
    /// <summary>
    /// Skrevet af Kaser, Oliver, WooHooWizard
    /// </summary>
    public class AccountHelper
    {
        private List<Employee> ListeMedAlleEmployees = new List<Employee>();
        private List<Customer> ListeMedAlleCostumers = new List<Customer>();
        public AccountHelper()
        {
            ListeMedAlleEmployees = GetEmployees();
            ListeMedAlleCostumers = GetCustomers();
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
        public List<Customer> GetCustomers()
        {
            string[] importTekst = System.IO.File.ReadAllLines("Customers.txt");
            List<Customer> customerListeTemp = new List<Customer>();
            foreach (string customer in importTekst)
            {
                string[] splitArr = customer.Split(",");
                int newId = Convert.ToInt32(splitArr[0]);
                string newName = splitArr[1];
                string newPassword = splitArr[2];
                int newPhoneNumber = Convert.ToInt32(splitArr[3]);
                string newAddress = splitArr[4];
                string newPayment = splitArr[5];
                customerListeTemp.Add(new Customer(newId, newName, newPassword, newPhoneNumber, newAddress, newPayment));
            }
            return customerListeTemp;
        }
    }
}


