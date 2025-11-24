using System.IO;
using System;
using PulterkammeretShop.Models;
namespace PulterkammeretShop.Models;

public class Spil
{
    public int id { get; set; }
    public string navn { get; set; }
    public double pris { get; set; }
    public string kategori  { get; set; }
    public int antal { get; set; }
    
    /// <summary>
    /// Constructer for vores Spil klasse
    ///
    /// skrevet af Kasper Sørensen.
    /// </summary>
    public Spil(int id, string navn, double pris, string kategori)
    {
        this.id = id;
        this.navn = navn;
        this.pris = pris;
        this.kategori = kategori;
        this.antal = 1;
    }
}