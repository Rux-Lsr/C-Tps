using FonctionsApp;
using EnterpriseApp;
using System.Runtime.CompilerServices;
namespace SessionAdminApp
{
    interface SessionAdmin
    {

        public  static void EntrerInformationsEntreprise(ref Entreprise entreprise)
        {
            string nom;
            int dateCreation = 0;

            Console.WriteLine("Entrez le nom de l'entreprise:");
            while(Fonction.TestOnName(nom = Console.ReadLine()));

            Console.WriteLine("Entrez l'annees de creation de l'entreprise (au format yyyy)");
           dateCreation = int.Parse(Console.ReadLine());
            // Création d'un objet Entreprise avec les informations entrées
            entreprise.NomEntreprise = nom;
            entreprise.DateCreation = dateCreation;

            Console.WriteLine("Les informations de l'entreprise ont été enregistrées.");
        }
        public static void CreerPostes( Entreprise entreprise){
            int nbrePoste = 0;
            
            Console.Write("entrez le nombre de poste à creer \n> ");
            nbrePoste = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbrePoste; i++)
            {   
                string nomPoste;
                double salaireBase, TauxAugmentation, DiviseurSalaire;
                Console.Write("Nom : ");    
                nomPoste = Console.ReadLine();
                Console.Write("Salaire de base : ");  
                salaireBase = double.Parse(Console.ReadLine());
                Console.Write("Taux augmentation : ");  
                TauxAugmentation = double.Parse(Console.ReadLine());
                Console.Write("Diviseur Salaire (x) : ");  
                DiviseurSalaire = double.Parse(Console.ReadLine());
      
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