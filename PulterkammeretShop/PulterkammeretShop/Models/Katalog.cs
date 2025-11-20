namespace PulterkammeretShop.Models
{
    public class Katalog
    {
        private List<Spil> ListeMedAlleSpil = new List<Spil>();
        public Katalog()
        {
            List<Spil> VisAlleSpil()
            {
                return ListeMedAlleSpil;
            }
        }
        int i = 0;
        public void HentSpilFraFil()
        {
            string[] importTekst = System.IO.File.ReadAllLines(@"SpilKatalog.txt");
            Spil[] produktListeTemp = new Spil[importTekst.Length];
            foreach (string spil in importTekst)
            {
                string[] splitArr = spil.Split(',');
                int newId = Convert.ToInt32(splitArr[0]);
                string newNavn = splitArr[1];
                double newPris = Convert.ToDouble(splitArr[2]);
                produktListeTemp[i] = new Spil(newId, newNavn, newPris);
                ListeMedAlleSpil.Add(produktListeTemp[i]);
            }
            foreach (Spil item in ListeMedAlleSpil)
            {
                Console.WriteLine(item.beskrivelse());
                Console.WriteLine();
            }
        }
    }
}