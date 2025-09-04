/*
{
    "VW" : [new Voiture(1, "Golf", "VW", Voiture.CarburantEnum.Diesel, 5), ];
    "Lada": [            
        new Voiture(2, "2101", "Lada", Voiture.CarburantEnum.Essence, 5, true),            
        new Voiture(5, "Riva", "Lada", Voiture.CarburantEnum.Diesel, 4),
    ]


}
*/

using Data;
using Data.Models;

IEnumerable<Voiture> voitures = new DataContext().Voitures;

IEnumerable<IGrouping<string, Voiture>> voitureParMarque = from v in voitures
                       group v by v.Marque;

IEnumerable<IGrouping<string, Voiture>> voitureParMarque_bis = voitures.GroupBy(v => v.Marque);

/*
Marque: "Lada"
    - "id" : "Model"
    - "id" : "Model"

Marque: "Audi"
    - "id" : "model"
 */

foreach (IGrouping<string, Voiture> uneMarqueAvecVoiture in voitureParMarque)
{
    Console.WriteLine($"Marque: '{uneMarqueAvecVoiture.Key}'");

    foreach (Voiture v in uneMarqueAvecVoiture)
    {
        Console.WriteLine($"\t - {v.Id} : {v.Modele}");
    }
}

// ----------------------------------
// IEnumerable<IGrouping<Voiture.CarburantEnum, Voiture>>
var voitureParCarburant = voitures.GroupBy(v => v.Carburant);

foreach (var unCarburantAvecVoiture in voitureParCarburant)
{
    Console.WriteLine($"Carburant {unCarburantAvecVoiture.Key.ToString()}");

    foreach (Voiture v in unCarburantAvecVoiture)
    {
        Console.WriteLine($"\t - {v.Id} : {v.Modele}");
    }
}


// Lister les voitures par carburant, on veut voir le model et la marque dans une seule prop

/*
 {
    "Diesel": [
        { Nom: "Marque model" }
        { Nom: "Marque model" }
        { Nom: "Marque model" }
        { Nom: "Marque model" }
    ],
    "Essence": [
        { Nom: "Marque model" }
        { Nom: "Marque model" }
        { Nom: "Marque model" }
        { Nom: "Marque model" }
    ],
} 
 */

Console.WriteLine("-----------------------------");

var group2 = voitures
                    .Select(v => new { 
                        Nom = $"{v.Marque} {v.Modele}",
                        Carburant = v.Carburant,
                        Id = v.Id,
                    })
                    .GroupBy(v => v.Carburant);

foreach (var unCarburantAvecVoiture in group2)
{
    Console.WriteLine($"Carburant {unCarburantAvecVoiture.Key.ToString()}");

    foreach (var v in unCarburantAvecVoiture)
    {
        Console.WriteLine($"\t - {v.Id} : {v.Nom}");
    }
}

Console.WriteLine("----------------------------");

var group3 = voitures
                    .GroupBy(v => v.Carburant)
                    .Select(g => new
                    {
                        clef = g.Key,
                        valeurs = g.Select(el => new {
                            Nom = $"{el.Marque} {el.Modele}",
                            Carburant = el.Carburant,
                            Id = el.Id,
                        })
                    });


foreach (var unCarburantAvecVoiture in group3)
{
    Console.WriteLine($"Carburant {unCarburantAvecVoiture.clef.ToString()}");

    foreach (var v in unCarburantAvecVoiture.valeurs)
    {
        Console.WriteLine($"\t - {v.Id} : {v.Nom}");
    }
}


var group4 = from v in voitures
            group new { Nom = $"{v.Marque} {v.Modele}", Portes = v.NbPorte } by v.Carburant;


foreach (var unCarburantAvecVoiture in group4)
{
    Console.WriteLine($"Carburant {unCarburantAvecVoiture.Key.ToString()}");

    foreach (var v in unCarburantAvecVoiture)
    {
        Console.WriteLine($"\t - {v.Nom} : {v.Portes}");
    }
}