using Data;
using Data.Models;

IEnumerable<Vehicule> vehicules = new DataContext().Vehicules;

#region COUNT
// Compter le nombre de VOITURE qui ont plus de 3 portes
// méthode where + count
int totalDeVoitureAvec3Portes = vehicules.OfType<Voiture>()
                                     .Where(v => v.NbPorte > 3)
                                     .Count();

// méthode filtrage dans le count
int totalDeVoitureAvec3Portes_bis_1 = vehicules.OfType<Voiture>()
                                     .Count(v => v.NbPorte > 3);

// Expression de requête et puis on count sur le résultat (version avec variable)
IEnumerable<Voiture> voituresAvec3Portes = from v in vehicules.OfType<Voiture>()
                                           where v.NbPorte > 3
                                           select v;
int total = voituresAvec3Portes.Count();

// Expression de requête et puis on count sur le résultat (version sans variable)
int totalDeVoitureAvec3Portes_bis_2 = (from v in vehicules.OfType<Voiture>()
                                       where v.NbPorte > 3
                                       select v).Count();



Console.WriteLine("Voiture avec 3 portes: " + totalDeVoitureAvec3Portes);
#endregion

// Compter le nombre place avec tout les avions
int nombreDePlaces = vehicules.OfType<Avion>()
                        .Sum(a => a.NbPlace);

int nombreDeplaces_bis = (from v in vehicules.OfType<Avion>()
                          select v).Sum(v => v.NbPlace);
int nombreDeplaces_bis_1 = (from v in vehicules.OfType<Avion>()
                            select v.NbPlace).Sum();

Console.WriteLine("Le nombres total est " + nombreDePlaces);

// Compter le nombre place moyenne dans tout les avions
double nombreDePlacesAvg = vehicules.OfType<Avion>()
                        .Average(a => a.NbPlace);

double nombreDeplacesAvg_bis = (from v in vehicules.OfType<Avion>()
                                select v).Average(v => v.NbPlace);
double nombreDeplacesAvg_bis_1 = (from v in vehicules.OfType<Avion>()
                                  select v.NbPlace).Average();

Console.WriteLine("Le nombres total est " + nombreDePlaces);

// Compte le nombre de marque de voiture

var nbrDeMarque = vehicules.OfType<Voiture>() // on filtre pour ne garder que les Voitures
                            .Select(v => v.Marque) // on ne garde que la marque de chaque voitures [VW,Lada,Dacia,Lada,Dacia,Audi,Lada]
                            .Distinct() // on enleve les doublons [VW,Lada,Dacia,Audi]
                            .Count(); // on compte le nbr d'élément: 4

Console.WriteLine("Nombre de marques: " + nbrDeMarque);