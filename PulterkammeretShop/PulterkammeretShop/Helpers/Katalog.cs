using System.Diagnostics;

namespace PulterkammeretShop.Models
{
    public class Katalog
    {
        private List<Spil> ListeMedAlleSpil = new List<Spil>();
        public Katalog()
        {
            ListeMedAlleSpil = HentSpilFraFil();
            List<Spil> VisAlleSpil()
            {
                return ListeMedAlleSpil;
            }
        }
        /// <summary>
        /// Reads a text file and separates out values
        ///
        /// By Anne-Sofie & Alexander
        /// </summary>
        /// <returns></returns>
        public List<Spil> HentSpilFraFil()
        {

            int i = 0;
            string[] importTekst = System.IO.File.ReadAllLines(@"SpilKatalog.txt"); 
            List<Spil> produktListeTemp = new List<Spil>();
            foreach (string spil in importTekst)
            {
                string[] splitArr = spil.Split(',');
                int newId = Convert.ToInt32(splitArr[0]);
                string newNavn = splitArr[1];
                double newPris = Convert.ToDouble(splitArr[2]);
                produktListeTemp.Add(new Spil(newId, newNavn, newPris));
            }
            return  produktListeTemp;
        }
    }
}