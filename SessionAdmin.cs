using FonctionsApp;
using EnterpriseApp;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
namespace SessionAdminApp
{
    interface SessionAdmin
    {

        private  static void EntrerInformationsEntreprise(ref Entreprise entreprise)
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
            Console.Clear();
            Console.WriteLine("Les informations de l'entreprise ont été enregistrées.");
        }
        private static void CreerPostes(ref Entreprise entreprise){
            int nbrePoste = 0;
            Console.Clear();
            Console.Write("entrez le nombre de poste à creer \n> ");
            nbrePoste = int.Parse(Console.ReadLine());
            Console.Clear();
                string nomPoste;
                double salaireBase, TauxAugmentation, DiviseurSalaire;
                int count = 0;
                
                while (true)
                {   
                    bool resp = false;
                    try
                    {
                        
                        
                        do
                        {
                            Console.WriteLine("*******Employe "+count+1+"********");
                            Console.Write("Nom : ");    
                            nomPoste = Console.ReadLine();
                            Console.Write("Salaire de base : ");  
                            salaireBase = double.Parse(Console.ReadLine());
                            Console.Write("Taux augmentation : ");  
                            TauxAugmentation = double.Parse(Console.ReadLine());
                            Console.Write("Diviseur Salaire (x) : ");  
                            DiviseurSalaire = double.Parse(Console.ReadLine());
                            Console.Clear();
                            resp = entreprise.AjouterPoste(new Poste(nomPoste.ToUpper(), TauxAugmentation, DiviseurSalaire, salaireBase));
                            
                        } while (resp);
                        
                        if(++count == nbrePoste) 
                            break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur : "+ex.Message);
                    }
                }
        }

       
        public static void Action(Entreprise entreprise){
            
               int choix;
            do
            {
                Console.Write("1 - Remplir les infos de l'entreprise\n2 - Creer des poste pour votre entreprise\n3 - Afficher les informations de poste\n4 - Afficher Les information de l'entreprise\n0-Quitter\n> ");
                int t = 0;
                t = int.Parse(Console.ReadLine());
                while(t>4 || t<0){
                    Console.WriteLine($"{t} est non valide, entrez à nouveau un nombre compris entre 0 et 4 : \n> ");
                    t = int.Parse(Console.ReadLine());
                }
                switch (t)
                {
                    case 1:
                        EntrerInformationsEntreprise(ref entreprise);
                        break;
                    case 2:
                        CreerPostes(ref entreprise);
                        break;
                    case 3:
                        printPostesInformations(entreprise);
                        break;
                    case 4:
                        GetEnterpriseInformationAsString(entreprise);
                        break;
                    default:
                        Console.WriteLine("Fin du travail d'administration");
                        return;
                }
                Console.WriteLine("Tapez O pour quitter ...");
                choix = int.Parse(Console.ReadLine());
            } while (choix!=0);

        }
        private static void GetEnterpriseInformationAsString(Entreprise entreprise){
            Console.WriteLine( $"Nom: {entreprise.NomEntreprise} Anee de creation  : {entreprise.DateCreation}");
        }
        private static void printPostesInformations(Entreprise entreprise){
            Console.WriteLine($"|{"Nom du poste",-20}|{"Salaire de base",-20}|{"Taux d'augmentation",-20}|{"Diviseur de salaire",-20}|");
            foreach (var item in entreprise.Postes)
            {
                
                Console.WriteLine($"|{item.NomPoste,-20}|{item.SalaireDeBase,-20:C2}|{item.TauxAugmentation,-20:P2}|{item.DiviseurSalaire,-20:N2}|");
            }
        }

    }

}