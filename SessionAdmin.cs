using FonctionsApp;
using EnterpriseApp;
using System.Runtime.CompilerServices;
namespace SessionAdminApp
{
    interface SessionAdmin
    {

        /// <summary>
        ///     Remplir les informations necessaires pour etre une entreprise
        /// </summary>
        public  static void EntrerInformationsEntreprise(ref Entreprise entreprise)
        {
            string nom;
            int dateCreation = 0;

            Console.WriteLine("Entrez le nom de l'entreprise:");
            while(Fonction.TestOnName(nom = Console.ReadLine()));

            Console.WriteLine("Entrez l'annees de creation de l'entreprise (au format yyyy)");
            while(Fonction.TestOnNumber(Console.ReadLine(), ref dateCreation) | !Fonction.InTheInterval(1900, DateTime.Now.Year, dateCreation));

            // Création d'un objet Entreprise avec les informations entrées
            entreprise.NomEntreprise = nom;
            entreprise.DateCreation = dateCreation;

            Console.WriteLine("Les informations de l'entreprise ont été enregistrées.");
        }

        public static Poste CreerPoste( Entreprise entreprise)
        {
            Poste poste;
            do{
                string nom;
                Console.WriteLine("Entrez le nom du poste:");
                while(Fonction.TestOnName(nom = Console.ReadLine()));
                Console.WriteLine("Entrez le taux d'augmentation pour ce poste:");
                decimal tauxAugmentation = 0;
                while(Fonction.TestOnDecimalNumber(Console.ReadLine(), ref tauxAugmentation));
                Console.WriteLine("Entrez le diviseur de salaire pour ce poste:");
                int diviseurSalaire = int.Parse(Console.ReadLine());
                poste = new Poste(nom, tauxAugmentation, diviseurSalaire);
            }
            // Création d'un objet Poste avec les informations entrées
            while(entreprise.AjouterPoste(poste));

            Console.WriteLine("Le poste a été créé avec succès.");
            return poste;
        }

        public static void CreerPostes( Entreprise entreprise){
            int nbreEmploye = 0;
            
            Console.WriteLine("Quel nombre de poste voulez creer?\n>");
            while(Fonction.TestOnNumber(Console.ReadLine(), ref nbreEmploye));

            for (int i = 0; i < nbreEmploye; i++)
            {
                entreprise.SetPoste(CreerPoste(entreprise)); 
            }
            InitialiserSalaires(entreprise);
        }

        public static void InitialiserSalaires( Entreprise entreprise)
        {
            foreach (Poste poste in entreprise.GetAllPostes())
            {
                Console.WriteLine($"Entrez le salaire de base pour le poste {poste.NomPoste}:");
                decimal salaireDeBase = decimal.Parse(Console.ReadLine());

                poste.SalaireDeBase = salaireDeBase;

                Console.WriteLine($"Le salaire de base pour le poste {poste.NomPoste} a été initialisé à {salaireDeBase}.");
            }
        }
        public void Menu(){
            Console.WriteLine("1 - Remplir les infos de l'entreprise\n2 - Creer des poste pour votre entreprise\n 0-Quitter");
        }
        public static void GetEnterpriseInformationAsString(Entreprise entreprise){
            Console.WriteLine( $"Nom: {entreprise.NomEntreprise} Anee de creation  : {entreprise.DateCreation}");
        }
        public static void printPostesInformations(Entreprise entreprise){
            Console.WriteLine($"|{"Nom du poste",-20}|{"Salaire de base",-20}|{"Taux d'augmentation",-20}|{"Diviseur de salaire",-20}|");
            foreach (var item in entreprise.GetAllPostes())
            {
                
                Console.WriteLine($"|{item.NomPoste,-20}|{item.SalaireDeBase,-20:C2}|{item.TauxAugmentation,-20:P2}|{item.DiviseurSalaire,-20:N2}|");
            }
        }

    }

}