public class Salaire
{
     public string Matricule { get; set; }
    public string NomEmploye { get; set; }
    public string SexeEmploye { get; set; }
    public int AnneRecrutement { get; set; }
    public Poste PosteEmploye { get; set; }
    public double SalaireEmploye { get; set; }
    public static int NumeroEmploye { get; set; } = 0;

    // Constructeur
   public Salaire(string nomEmploye, string sexeEmploye, int anneRecrutement, Poste posteEmploye)
    {
       Matricule = $"{AnneRecrutement % 100}{char.ToUpper(PosteEmploye.NomPoste[0])}{NumeroEmploye.ToString("D4")}";
        NomEmploye = nomEmploye;
        SexeEmploye = sexeEmploye;
        AnneRecrutement = anneRecrutement;
        PosteEmploye = posteEmploye;
        SalaireEmploye = CalculerSalaire();
        NumeroEmploye++;
    }

    // Méthode pour calculer le salaire d'un employé
    public double CalculerSalaire()
    {
        try
        {
            int anciennete = DateTime.Now.Year - AnneRecrutement;
            double augmentation = (double)(PosteEmploye.SalaireDeBase * PosteEmploye.TauxAugmentation / 100) * anciennete;
            double salaire = (double)(PosteEmploye.SalaireDeBase + augmentation) / PosteEmploye.DiviseurSalaire;

            return salaire;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors du calcul du salaire: " + ex.Message);
            return 0;
        }
    }
   

       
    
}
