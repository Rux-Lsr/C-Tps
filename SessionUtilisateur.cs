using FonctionsApp;
using EnterpriseApp;
namespace UserSessionApp
{
    interface SessionUtilisateur
{
    
    private static void CreerEmployes(Entreprise entreprise)
    {
        string msg  = $"\"*******************CREATION D'EMPLOYE(s)*******************";
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);
        if(entreprise.Postes.Count == 0){
            Console.WriteLine("Non existence de poste, Veuillez en creer dans la session admin avant de vous diriger vers la creation d'employe");
            return;
        }
        Console.Write("Quel Nombre d'employés voulez vous ? \n>");
            int EmployeeNumber = 0;
            List<Salaire>Employees = new List<Salaire>();

            while (Fonction.TestOnNumber(Console.ReadLine(), ref EmployeeNumber)) ;

            
            msg  = $"\"*******************Creation de {EmployeeNumber} Employé(s)*******************";
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);
            for (int i = 0; i < EmployeeNumber; i++)
            {
                msg  = $"\"*******************Creation de {EmployeeNumber} Employé(s)*******************";
                Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
                Console.WriteLine(msg);
                string nom, sexe, date;
                int poste, ValidYear = 0;
                Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
                Console.WriteLine(msg=$"*********EMPLOYE N° {i + 1}*********");

                      Console.Write("Entrez le nom\n>");
                  while (Fonction.TestOnName(nom = Console.ReadLine()));

                 
                      Console.Write("Entrez le sexe\n>");  
                  while (Fonction.TestOnSex(sexe = Console.ReadLine()));

                
                    Console.Write("Entrez la date de recrutement (Format: jj/mm/aaaa) : \n>");
                  while (Fonction.TestOnDate(date = Console.ReadLine(), ref ValidYear) || !Fonction.InTheInterval(entreprise.DateCreation, DateTime.Now.Year, ValidYear)) ;


                do
                {
                        Console.Write("Entrez le poste:");
                        PrintAllPoste(entreprise);         
                } while (!int.TryParse(Console.ReadLine(), out poste) || (poste > entreprise.Postes.Count || poste < 0));

                string Matricule = $"{DateTime.Parse(date).Year % 100}{entreprise.Postes[poste].NomPoste[0]}{(i+1).ToString("D4")}";
                entreprise.Salaires.Add(new Salaire(nom, sexe, DateTime.Parse(date).Year, entreprise.GetPoste(poste), Matricule));
            }
    }
    
    private static void PrintAllPoste(Entreprise entreprise){
        int count = 0;
        foreach (var item in entreprise.Postes)
        {
           Console.Write($"{count++} - {item.NomPoste} ");
        }
        Console.Write("\n> ");
    }
    private static void PrintSalairesInformations(Entreprise entreprise)
    {
        Console.Clear();
        if (entreprise.Salaires.Count == 0)
        {
            Console.WriteLine("!!!Pas d'employés!!!!");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("{0,-10} {1,-25} {2,-5} {3,-5} {4,-25} {5,-25}", "Matricule", "Nom", "Sexe", "Annee", "Poste", "Salaire");
        Console.ResetColor();

        foreach (var item in entreprise.Salaires)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0,-10} {1,-25} {2,-5} {3,-5} {4,-25} {5,-25}", item.Matricule, item.NomEmploye, item.SexeEmploye, item.AnneRecrutement, item.PosteEmploye.NomPoste, item.CalculerSalaire());
        }
    }

    public static void Action(Entreprise entreprise){
        string msg = "MENU-User";
        string[] options = {"Ajouter Employe", "Afficher information Employe", "quitter"};
        int selectedOption = 0;
        Console.CursorVisible = false;
        while(true)
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);

            for (int i = 0; i < options.Length; i++)
            {
                if(i == selectedOption){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("-> ");
                }else{
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
                    if(selectedOption < 0)
                        selectedOption = options.Length-1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption++;
                    if(selectedOption >= options.Length)
                        selectedOption = 0;
                    break;

                default:
                    break;
            }
            if(key.Key == ConsoleKey.Enter)
            {
                switch(selectedOption){
                    case 0:
                        Console.Clear();
                        CreerEmployes(entreprise);
                        break;
                    case 1:
                        Console.Clear();
                        PrintSalairesInformations(entreprise);
                        break;
                    default:
                        break;
                }
                Console.Write("Touche 'entrer' pour continuer et 'echap' pour Sortir de la session user...");
                Console.CursorVisible = true;
                ConsoleKeyInfo touche = Console.ReadKey();
                
                if (touche.Key == ConsoleKey.Escape)
                    break;
            }

            
        }
        Console.Clear();
            Console.WriteLine("Fin Session Utilisateur ...");
    }
}
}       