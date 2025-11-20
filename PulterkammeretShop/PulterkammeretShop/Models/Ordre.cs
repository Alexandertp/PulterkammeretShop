namespace PulterkammeretShop.Models;

public class Ordre
{
    public int totalPris
    {
        get { return totalPris;} 
        set {totalPris = value;}
    }
    public string ordreDato = "";
    Ordre()
    {
        ordreDato = DateTime.Now.ToShortDateString();
    }
    public List<Spil> varer = new List<Spil>();
}