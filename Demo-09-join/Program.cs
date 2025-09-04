using Data;
using Data.Models;

IEnumerable<Auteur> auteurs = new DataContext().Auteurs;
IEnumerable<Livre> livres = new DataContext().Livres;

#region Inner join
{

    Console.WriteLine("Inner join");

    // La liste des livres avec leur auteur

    var livresAvecAuteur = from l in livres
                           join a in auteurs on l.AuteurId equals a.Id
                           select new
                           {
                               Livreid = l.Id,
                               Titre = l.Titre,
                               NomAuteur = $"{a.Nom} {a.Prenom}",
                               Auteur = a
                           };

    var livresAvecAuteur_bis = livres.Join(
                                    auteurs, // collection à joindre
                                    l => l.AuteurId,// clé de la collection de base (livre)
                                    a => a.Id, // clé de la collection jointe (auteur)
                                    (l, a) => new
                                    {
                                        LivreId = l.Id,
                                        Titre = l.Titre,
                                        NomAuteur = $"{a.Nom} {a.Prenom}",
                                        Auteur = a
                                    }
        );

    foreach (var la in livresAvecAuteur)
    {
        Console.WriteLine($"{la.Titre} - {la.NomAuteur}");
    }
}
#endregion

#region group join

Console.WriteLine("Group Join");

// pour chaque auteurs, je souhaite voir ses livres

var auteursAvecLivres = from a in auteurs
                        join l in livres on a.Id equals l.AuteurId into glivres
                        select new
                        {
                            Nom = a.Nom,
                            Prenom = a.Prenom,
                            Livres = glivres
                        };

var auteursAvecLivres_bis = auteurs.GroupJoin(
        livres,
        a => a.Id,
        l => l.AuteurId,
        (auteur, glivres) => new {
            Nom = auteur.Nom,
            Prenom = auteur.Prenom,
            Livres = glivres.Select(l => new
            {
                Id = l.Id,
                Titre = l.Titre.ToUpper(),
            }),
        }
    );

foreach (var al in auteursAvecLivres_bis)
{
    Console.WriteLine($"Auteur: {al.Nom} {al.Prenom}");

    foreach (var l in al.Livres)
    {
        Console.WriteLine($"\t - {l.Id} : {l.Titre}");
    }
}

#endregion


#region Cross Join

Console.WriteLine("Cross Join");

var livresAuteurs = from l in livres
                    from a in auteurs
                    select new
                    {
                        Auteur = $"{a.Prenom} {a.Nom}",
                        Livre = l.Titre
                    };



foreach (var la in livresAuteurs) {
    Console.WriteLine(la);
}

Console.WriteLine("Cross Join + Where");

var livresAuteurs_Good = from l in livres
                    from a in auteurs
                    where a.Id == l.AuteurId
                    select new
                    {
                        Auteur = $"{a.Prenom} {a.Nom}",
                        Livre = l.Titre
                    };

foreach (var la in livresAuteurs_Good)
{
    Console.WriteLine(la);
}
#endregion