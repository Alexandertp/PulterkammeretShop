namespace PulterkammeretShop.Models;

public class Ordre
{
    private int _totalPris;
    public int totalPris
    {
        get { return _totalPris;} 
        set {_totalPris = value;}
    }
    
    public string ordreDato = "";
    
    public Ordre()
    {
        ordreDato = DateTime.Now.ToShortDateString();
        varer = new List<Spil>();
    }
    
    public List<Spil> varer = new List<Spil>();
}