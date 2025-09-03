using Data;
using Data.Models;

IEnumerable<Voiture> voitures = new DataContext().Voitures;

// Trier les voitures par nombre de porte
IEnumerable<Voiture> result1 = voitures.OrderBy(v => v.NbPorte);
IEnumerable<Voiture> result1_bis = from v in voitures
                                   orderby v.NbPorte
                                   select v;

foreach(Voiture voiture in result1)
{
    Console.WriteLine($"id:{voiture.Id} - portes:{voiture.NbPorte}");
}
foreach (Voiture voiture in result1_bis)
{
    Console.WriteLine($"id:{voiture.Id} - portes:{voiture.NbPorte}");
}

IEnumerable<Voiture> result2 = voitures.OrderBy(v => v.Marque.Length);
foreach (Voiture voiture in result2)
{
    Console.WriteLine($"Taille:{voiture.Marque.Length} - Marque:{voiture.Marque}");
}

IEnumerable<Voiture> result3 = from v in voitures
                               orderby v.Marque descending, v.Modele
                               select v;
foreach (Voiture v in result3)
{
    Console.WriteLine($"Marque:{v.Marque} - id: {v.Id}");
}