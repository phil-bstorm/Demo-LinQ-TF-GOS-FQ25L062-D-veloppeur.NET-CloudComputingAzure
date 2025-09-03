using Data;
using Data.Models;

// Cast VS OfType

// - Cast
// Essaie de caster tout les éléments (et donc peut planter si conversion impossible)
{
    IEnumerable<Vehicule> vehicules = new DataContext().Vehicules;

    // Récuperer tous les avions
    //IEnumerable<Avion> resulta1 = vehicules.Cast<Avion>();
    //IEnumerable<Avion> resulta1 = from Avion a in vehicules
    //                              select a;

    // On peut le combiné avec un "Where"
    IEnumerable<Avion> resulta1 = vehicules.Where(v => v is Avion).Cast<Avion>();

    foreach (Avion av in resulta1)
    {
        Console.WriteLine(av.Id);
    }
}

// - OfType
// Cast uniquement les élément compatible (et donc ne plante pas!)
{
    IEnumerable<Vehicule> vehicules = new DataContext().Vehicules;

    IEnumerable<Avion> resulta1 = vehicules.OfType<Avion>();
    //IEnumerable<Avion> resulta1 = from a in vehicules.OfType<Avion>()
    //                              select a;

    foreach (Avion av in resulta1)
    {
        Console.WriteLine(av.Id);
    }
}