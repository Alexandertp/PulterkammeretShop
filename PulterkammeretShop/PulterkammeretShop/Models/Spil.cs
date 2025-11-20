using System.IO;
using System;
using PulterkammeretShop.Models;
namespace PulterkammeretShop.Models;

public class Spil
{
    public int id { get; set; }
    public string navn { get; set; }
    public double pris { get; set; }
    
    /// <summary>
    /// Constructer for vores Vare klasse
    ///
    /// skrevet af Kasper Sørensen.
    /// </summary>
    public Spil(int id, string navn, double pris)
    {
        this.id = id;
        this.navn = navn;
        this.pris = pris;
    }
    public string beskrivelse()
    {
        return "Spil ID: " + id + ", Navn: " + navn + ", Pris: " + pris;
    }
}