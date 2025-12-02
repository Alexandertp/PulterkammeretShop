using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PulterkammeretShop.Models;

namespace PulterkammeretShop.Helpers
{
    public class Katalog
    {
        private const string katalogPath = "SpilKatalog.txt";
        private List<Spil> ListeMedAlleSpil = new List<Spil>();

        public Katalog()
        {
            ListeMedAlleSpil = HentSpilFraFil();
        }

        /// <summary>
        /// Reads a text file and separates out values
        ///
        /// By Anne-Sofie & Alexander
        /// </summary>
        public List<Spil> HentSpilFraFil()
        {
            string[] importTekst = System.IO.File.ReadAllLines(katalogPath); 
            List<Spil> produktListeTemp = new List<Spil>();
            foreach (string spil in importTekst)
            {
                string[] splitArr = spil.Split(',');
                int newId = Convert.ToInt32(splitArr[0]);
                string newNavn = splitArr[1];
                int newPris = Convert.ToInt32(splitArr[2]);
                string newKategori = splitArr[3];
                produktListeTemp.Add(new Spil(newId, newNavn, newPris, newKategori));
            }
            return produktListeTemp;
        }

        /// <summary>
        /// Takes a Spil object and appends it to the Katalog File :DDD
        ///
        /// By Alexander
        /// </summary>
        public void AddSpil(Spil spil)
        {
            StreamWriter skriver = System.IO.File.AppendText(katalogPath);
            skriver.WriteLine();
            skriver.Write($"{spil.id},{spil.navn},{spil.pris},{spil.kategori}");
            skriver.Close();

            ListeMedAlleSpil.Add(spil);
        }
        
        //  TODO: Udvid med Frølund
        public List<Spil> Search(string? SpilNavn, string? SpilKategori)
        {
            List<Spil> søgeResultat =  new List<Spil>();
            
            if (SpilNavn != null)
            {
                SpilNavn = SpilNavn.ToLower();
                søgeResultat = ListeMedAlleSpil.FindAll(spil => spil.navn.ToLower().Contains(SpilNavn));
                if (SpilKategori != null &&  SpilKategori != "null")
                {
                    søgeResultat = søgeResultat.FindAll(spil => spil.kategori.Contains(SpilKategori));
                }
            }
            else
            {
                søgeResultat = ListeMedAlleSpil.FindAll(spil => spil.kategori.Contains(SpilKategori));
            }
            
            return søgeResultat;
        }
    }
}