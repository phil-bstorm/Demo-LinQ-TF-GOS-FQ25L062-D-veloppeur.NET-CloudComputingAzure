namespace Data.Models
{
    public class Auteur
    {
        public Auteur(int id, string prenom, string nom)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
        }

        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}
