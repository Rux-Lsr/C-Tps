namespace EnterpriseApp
{
    public class Entreprise
    {
        public string NomEntreprise { get; set; } = "Not Defined";
        public int DateCreation { get; set; } = 2000;
        public List<Poste> Postes { get; set; } = new List<Poste>();
        public List<Salaire> Salaires { get; set; } = new List<Salaire>();

        // Constructeur
        public Entreprise(string nom, int dateCreation)
        {
            NomEntreprise = nom;
            DateCreation = dateCreation;
        }

        public Poste GetPoste(int poste){
            return Postes[poste];
        }
        public List<Poste> GetAllPostes(){
            return Postes;
        }
        public void SetPoste(Poste poste){
            Postes.Add(poste);
        }

        // Méthode pour ajouter un poste à l'entreprise
        public bool AjouterPoste(Poste poste)
        {
            if (Postes.Any(p => p.NomPoste == poste.NomPoste))
            {
                Console.WriteLine("Le poste existe déjà, veuillez ressaisir ...");
                return true;
            }
            else
            {
                Postes.Add(poste);
                Console.WriteLine("Le poste a été ajouté avec succès.");
                return false;
            }
        }
        public void AjouterEmploye(Salaire salaire){
            if(Salaires.Any(p => p.Matricule == salaire.Matricule))
            {
                Console.WriteLine("Matricule deja existant !");
            }else{
                Salaires.Add(salaire);
            }
        }
        
    }

}