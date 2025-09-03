using Data;
using Data.Models;

IEnumerable<Voiture> voitures = new DataContext().Voitures;

// Récupérer les voitures qui roule au diesel
IEnumerable<Voiture> result1 = voitures.Where(v => v.Carburant == Voiture.CarburantEnum.Diesel);
IEnumerable<Voiture> result1_bis = from v in voitures
                                   where v.Carburant == Voiture.CarburantEnum.Diesel
                                   select v;

Console.WriteLine("Voiture qui roule au diesel");
foreach (Voiture voiture in result1)
{
    Console.WriteLine($"{voiture.Id}");
}
Console.WriteLine("Voiture qui roule au diesel (bis)");

foreach (Voiture voiture in result1_bis)
{
    Console.WriteLine($"{voiture.Id}");
}

// Récupérer les voitures qui roule au diesel et qui ont 4 portes
IEnumerable<Voiture> result2 = voitures.Where(v => v.Carburant == Voiture.CarburantEnum.Diesel && v.NbPorte == 4);
IEnumerable<Voiture> result2_bis1 = voitures.Where(v => v.Carburant == Voiture.CarburantEnum.Diesel)
                                        .Where(v => v.NbPorte == 4);

bool checkPorteEgale4(Voiture v) {
    return v.NbPorte == 4;
}
IEnumerable<Voiture> result2_bis2 = voitures.Where(v => v.Carburant == Voiture.CarburantEnum.Diesel)
                                        .Where(checkPorteEgale4);

IEnumerable<Voiture> result2_bis4 = from v in voitures
                                    where v.Carburant == Voiture.CarburantEnum.Diesel
                                    where v.NbPorte == 4
                                    select v;