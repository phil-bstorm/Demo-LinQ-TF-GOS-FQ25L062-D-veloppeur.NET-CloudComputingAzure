using Data;
using Data.Models;

IEnumerable<Vehicule> vehicules = new DataContext().Vehicules;

// récupérer toutes les voitures qui ont 3 portes, on affiche marque et le model
IEnumerable<string> result1 = vehicules.OfType<Voiture>()
                                         .Where(v => v.NbPorte == 3)
                                         .Select(v => $"{v.Marque} - {v.Modele}");

var result1_bis = vehicules.OfType<Voiture>()
                                         .Where(v => v.NbPorte == 3)
                                         .Select(v => new { Marque = v.Marque, Modele = v.Modele }); 