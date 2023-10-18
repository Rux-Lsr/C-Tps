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
            string input, msg = "ENREGISTREMENT DES INFORMATIONS DE L'ENTREPRISE";

            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);
        //Recuperation du nom de l'entreprise
        
            Console.WriteLine("Entrez le nom de l'entreprise:");
            while(Fonction.TestOnName(nom = Console.ReadLine()));
        //Recuperation de la date de creation de l'ntreprise
            do
            {
                Console.WriteLine("Entrez l'annee de creation de l'entreprise (au format yyyy) ");
                input = Console.ReadLine();
                
            } while (Fonction.TestOnNumber(input, ref dateCreation));
        // Modification des informations d'un objet Entreprise avec les informations entrées
            entreprise.NomEntreprise = nom;
            entreprise.DateCreation = dateCreation;
            Console.Clear();
            Console.WriteLine("Les informations de l'entreprise ont été enregistrées.");
        }
        private static void CreerPostes(ref Entreprise entreprise){
            int nbrePoste = 0;
            string nomPoste;
            string msg = "CREATION DES POSTES DE L'ENTREPRISE";
            double salaireBase = 0, TauxAugmentation = 0, DiviseurSalaire = 0;
            int count = 0;
            bool resp;
            
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);
            do
            {
                Console.Write("entrez le nombre de poste à creer \n> ");
            } while (Fonction.TestOnNumber(Console.ReadLine(), ref nbrePoste) || nbrePoste < 0);
            Console.Clear();
                
            
                        do
                        {                                                                                                                               
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
                            Console.WriteLine(msg);
                            Console.WriteLine("*******Poste "+(count+1)+"********");
                        // Recuperation du Nom du poste
                            do
                            {
                                Console.Write("Nom : ");    
                                
                            } while (Fonction.TestOnName(nomPoste = Console.ReadLine()));
                        //Recuperation du salaire de base du poste
                            do
                            {
                                Console.Write("Salaire de base (>0): ");  
                            } while (Fonction.TestOnDoubleNumber(Console.ReadLine(), ref salaireBase) || salaireBase<=0);
                        //Recuperation du taux d'augmentation
                            do
                            {
                                Console.Write("Taux augmentation (> 0): ");  
                            } while (Fonction.TestOnDoubleNumber(Console.ReadLine(), ref TauxAugmentation) || TauxAugmentation<=0);
                        //Recuperation du diviseur de salaire x
                            do
                            {
                                 Console.Write("Diviseur Salaire (x > 0) : ");  
                            } while (Fonction.TestOnDoubleNumber(Console.ReadLine(), ref DiviseurSalaire) || DiviseurSalaire<=0);
                            //Nettoyage de la fenetre de la console
                            Console.Clear();
                            //test de creation du poste 
                            resp = entreprise.AjouterPoste(new Poste(nomPoste.ToUpper(), TauxAugmentation, DiviseurSalaire, salaireBase));
                        } while (resp);
       
        }

       
        public static void Action(Entreprise entreprise){
            
               string choix, msg = "MENU-ADMIN";
                Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
                Console.WriteLine(msg);
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
                        break;
                }
                Console.WriteLine("Tapez q pour quitter  la session Admin...");
                choix = Console.ReadLine() ;
            } while (choix.ToLower() != "q");

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