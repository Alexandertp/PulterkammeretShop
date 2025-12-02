using System.Diagnostics;
using PulterkammeretShop.Models;

namespace PulterkammeretShop.Helpers
{
    /// <summary>
    /// Skrevet af Kasper, Oliver, Anne Sofie
    /// </summary>
    public class AccountHelper
    {
        private string bestillingPath = "Bestillinger/";
        private List<Employee> ListeMedAlleEmployees = new List<Employee>();
        private List<Customer> ListeMedAlleCustomers = new List<Customer>();
        public List<Employee> listeMedAlleEmployees 
        {
            get { return ListeMedAlleEmployees; }
        }
        public List<Customer> listeMedAlleCustomers
        {
            get { return ListeMedAlleCustomers; }
        }
        public AccountHelper()
        {
            ListeMedAlleEmployees = GetEmployees();
            ListeMedAlleCustomers = GetCustomers();
        }
        
        /// <summary>
        /// Indsamler en Liste af Employees fra en fil på computeren
        ///
        /// Skrevet af Oliver, Anne Sofie, og Kasper
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Indsamler en Liste af Customers fra en fil på computeren
        ///
        /// Skrevet af Oliver, Anne Sofie, og Kasper
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            string[] importTekst = System.IO.File.ReadAllLines("Customers.txt");
            List<Customer> customerListeTemp = new List<Customer>();
            //Her tager vi hver plads i importTekst Array'et og laver hver String om til den relevante datatype for et Customer Objekt
            foreach (string customer in importTekst)
            {
                //Her opdeles string 'customer' og bliver lagt i et array, den bliver opdelt ved hvert komma i stringen, kommaerne bliver også fjernet samtidig
                string[] splitArr = customer.Split(",");
                int newId = Convert.ToInt32(splitArr[0]);
                string newName = splitArr[1];
                string newPassword = splitArr[2];
                int newPhoneNumber = Convert.ToInt32(splitArr[3]);
                string newAddress = splitArr[4];
                string newPayment = splitArr[5];
                //Når vi har fundet alle vores værdier laver vi et ny Customer objekt og tilføjer det til listen
                customerListeTemp.Add(new Customer(newId, newName, newPassword, newPhoneNumber, newAddress, newPayment));
            }
            //Når listen er lavet, returnerer vi den.
            return customerListeTemp;
        }

        public void AddNewCustomer(Customer nyKunde)
        {
            StreamWriter skriver = System.IO.File.AppendText("Customers.txt");
            skriver.Write($"\n{nyKunde.id},{nyKunde.name},{nyKunde.password},{nyKunde.phoneNumber},{nyKunde.address},{nyKunde.paymentInfo}");
            skriver.Close();
            ListeMedAlleCustomers.Add(nyKunde);
        }
        
        /// <summary>
        /// Skriver en ordre til en ny fil i en mappe på computeren, hvis mappen ikke allerede eksisterer, skaber den en
        ///
        /// Skrevet af Anne Sofie & Alexander
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="bestilling"></param>
        public void AddOrderToCustomerDirectory(Customer customer, Ordre bestilling)
        {
            string bestillingFolder = bestillingPath + customer.id.ToString() + "/";
            if (!Directory.Exists(bestillingFolder))
            {
                Directory.CreateDirectory(bestillingFolder);
            }
            StreamWriter skriver = System.IO.File.AppendText(bestillingFolder+Directory.GetFiles(bestillingFolder,"*", SearchOption.TopDirectoryOnly).Length + ".txt");
            foreach (Spil spil in bestilling.varer)
            {
                skriver.WriteLine($"{spil.id},{spil.navn},{spil.antal}");
            }
            skriver.Close();
        }
        
        //TODO: Abstract function
        /// <summary>
        /// Henter en Liste af Ordre fra en folder på computeren, ud fra den givne CustomerId
        ///
        /// Skrevet af Kasper & Alexander
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public List<Ordre> ReadCustomerOrders(int CustomerId)
        {
            List<Ordre> output = new List<Ordre>();
            Katalog katalog = new Katalog();
            List<Spil> alleSpil = katalog.HentSpilFraFil();
            string customerPath = bestillingPath + CustomerId + "/";
            if (!Directory.Exists(customerPath))
            {
                Directory.CreateDirectory(customerPath);
            }
            //Dette loop kører igennem hver dokument inde i den folder som indeholder kundens bestillinger. Hver dokument er sin egen ordre, og indeholder en liste af spil
            for (int i = 0; i < Directory.GetFiles(customerPath).Length; i++)
            {
                //Læser indholdet af filen, hver punkt i dette array er en linje i dokumentet
                string[] importTekst = File.ReadAllLines(customerPath + i + ".txt");
                output.Add(new Ordre());
                //Dette loop kører over hver position i array'et ovenover, og repræsenterer hver spil i dokumentet
                
                output[i].varer.AddRange(SpilFraStringArray(importTekst, alleSpil));
                
            }
            return output;
        }

        private List<Spil> SpilFraStringArray(string[] customerOrders, List<Spil> fullSpilListe)
        {
            List<Spil> SpilListe = new List<Spil>();

            foreach (string spil in customerOrders)
            {
                string[] splitArr = spil.Split(",");
                Spil spilFraId = fullSpilListe.Find(findSpil => findSpil.id == Convert.ToInt32(splitArr[0]));
                spilFraId.antal = int.Parse(splitArr[2]);
                SpilListe.Add(spilFraId);
            }
            return  SpilListe;
        }
    }
}