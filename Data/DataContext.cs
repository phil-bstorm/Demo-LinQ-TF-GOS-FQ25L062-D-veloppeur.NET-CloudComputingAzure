using Data.Models;

namespace Data
{
    public class DataContext
    {
        public List<Student> Students = [
            new Student(1, "Zaza", "Vanderquack", 75),
            new Student(2, "Lena", "Sabrewing", 85),
            new Student(3, "Riri", "Duck", 55),
            new Student(4, "Fifi", "Duck", 80),
            new Student(5, "Loulou", "Duck", 2.5),
        ];

        public IEnumerable<Vehicule> Vehicules = [
            new Voiture(1, "Golf", "VW", Voiture.CarburantEnum.Diesel, 5),
            new Voiture(2, "2101", "Lada", Voiture.CarburantEnum.Essence, 5, true),
            new Voiture(3, "Logan", "Dacia", Voiture.CarburantEnum.Hybride, 4),
            new Avion(4, "Concorde", "Sud-Aviation", 100, false),
            new Voiture(5, "Riva", "Lada", Voiture.CarburantEnum.Diesel, 4),
            new Voiture(6, "1310", "Dacia", Voiture.CarburantEnum.Essence, 5),
            new Avion(7, "A320", "Airbus", 150, false),
            new Voiture(8, "E-tron", "Audi", Voiture.CarburantEnum.Electrique, 3),
            new Voiture(10, "Niva SUV", "Lada", Voiture.CarburantEnum.Essence, 2),
            new Avion(11, "A300-600ST", "Airbus", 265, true)
        ];

        public IEnumerable<Voiture> Voitures = [
            new Voiture(1, "Golf", "VW", Voiture.CarburantEnum.Diesel, 5),
            new Voiture(2, "2101", "Lada", Voiture.CarburantEnum.Essence, 5, true),
            new Voiture(3, "Logan", "Dacia", Voiture.CarburantEnum.Hybride, 4),
            new Voiture(5, "Riva", "Lada", Voiture.CarburantEnum.Diesel, 4),
            new Voiture(6, "1310", "Dacia", Voiture.CarburantEnum.Essence, 5),
            new Voiture(8, "E-tron", "Audi", Voiture.CarburantEnum.Electrique, 3),
            new Voiture(10, "Niva SUV", "Lada", Voiture.CarburantEnum.Essence, 2),
        ];

        public IEnumerable<Auteur> Auteurs = [
            new Auteur(1, "Douglas", "Adams"),
            new Auteur(2, "Carl", "Barks"),
            new Auteur(3, "René", "Barjavel"),
            new Auteur(4, "Don", "Rosa"),
            new Auteur(5, "Clélia", "Rosso")
        ];

        public IEnumerable<Livre> Livres = [
            new Livre(1, "Le Guide du voyageur galactique", 1978, 1),
            new Livre(2, "Donald et le trésor du pirate", 1974, 2),
            new Livre(3, "La Chasse au canard...", 1988, 4),
            new Livre(4, "Le chapeau rouge", 1957, 2),
            new Livre(5, "La nuit des temps", 1968, 3),
            new Livre(6, "Le Retour des trois Caballeros", 2000, 4),
            new Livre(7, "Un avion à réaction !", 1955, 2),
            new Livre(8, "Trois bons petits canards", 2000, 2),
            new Livre(9, "Ravage", 1943, 3),
            new Livre(10, "L'Enchanteur", 1984, 3),
            new Livre(11, "Un baraqué débusqué !", 1955, 2),
            new Livre(12, "Citrouille carabinée", 1988, 4)
        ];
    }
}
