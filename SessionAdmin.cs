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
            } while (++count < nbrePoste);
       
        }

    public static void Action(Entreprise entreprise){
        string[] options = { "Remplir les infos de l'entreprise", "Creer des poste pour votre entreprise", "Afficher les informations de poste", "Afficher Les information de l'entreprise", "Quitter" };
        int selectedOption = 0;

        while (true)
        {
            Console.Clear();

            string msg = "MENU-ADMIN";
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("-> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("   ");
                }

                Console.WriteLine(options[i]);
            }

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption--;
                    if (selectedOption < 0)
                        selectedOption = options.Length - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedOption++;
                    if (selectedOption >= options.Length)
                        selectedOption = 0;
                    break;

                default:
                    break;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedOption)
                {
                    case 0:
                        EntrerInformationsEntreprise(ref entreprise);
                        break;
                    case 1:
                        CreerPostes(ref entreprise);
                        break;
                    case 2:
                        printPostesInformations(entreprise);
                        break;
                    case 3:
                        GetEnterpriseInformationAsString(entreprise);
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }
                Console.WriteLine("Touche 'entrer' pour continuer et 'echap' pour Sortir de la session...");
                ConsoleKeyInfo touche = Console.ReadKey();
                
                if (touche.Key == ConsoleKey.Escape)
                    break;
            }
        }
        Console.WriteLine("Fin du travail d'administration");
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