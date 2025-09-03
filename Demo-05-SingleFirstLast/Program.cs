using Data;
using Data.Models;

IEnumerable<Voiture> voitures = new DataContext().Voitures;

Voiture? result1 = voitures.Where(v => v.NbPorte == 2).SingleOrDefault();
if (result1 is not null)
{
    Console.WriteLine(result1.Id);
}

Voiture? result2 = voitures.Where(v => v.NbPorte == 10).SingleOrDefault();
Console.WriteLine(result2?.Id);

//Voiture? result3 = voitures.Where(v => v.Marque == "Lada").SingleOrDefault(); // planter car plusieurs résultat :(

Voiture? result4 = voitures.Where(v => v.Marque == "Lada").FirstOrDefault();

Voiture? result5 = voitures.Where(v => v.Marque == "Lada").LastOrDefault();

Voiture? result6 = voitures.FirstOrDefault(v => v.Marque == "Lada");
