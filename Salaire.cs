public class Salaire
{
     public string Matricule { get; set; }
    public string NomEmploye { get; set; }
    public string SexeEmploye { get; set; }
    public int AnneRecrutement { get; set; }
    public Poste PosteEmploye { get; set; }
    public decimal SalaireEmploye { get; set; }
    public static int NumeroEmploye { get; set; }

    // Constructeur
   public Salaire(string nomEmploye, string sexeEmploye, int anneRecrutement, Poste posteEmploye)
    {
       Matricule = $"{AnneRecrutement % 100}{char.ToUpper(PosteEmploye.NomPoste[0])}{NumeroEmploye.ToString("D4")}";
        NomEmploye = nomEmploye;
        SexeEmploye = sexeEmploye;
        AnneRecrutement = anneRecrutement;
        PosteEmploye = posteEmploye;
        SalaireEmploye = CalculerSalaire();
    }

    // Méthode pour calculer le salaire d'un employé
    public decimal CalculerSalaire()
    {
        try
        {
            int anciennete = DateTime.Now.Year - AnneRecrutement;
            decimal augmentation = (decimal)(PosteEmploye.SalaireDeBase * PosteEmploye.TauxAugmentation / 100) * anciennete;
            decimal salaire = (decimal)(PosteEmploye.SalaireDeBase + augmentation) / PosteEmploye.DiviseurSalaire;

            return salaire;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors du calcul du salaire: " + ex.Message);
            return 0;
        }
    }
   

       
    
}
