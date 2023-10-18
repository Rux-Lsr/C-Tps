using FonctionsApp;
using EnterpriseApp;
namespace UserSessionApp
{
    interface SessionUtilisateur
{
    
    private static void CreerEmployes(Entreprise entreprise)
    {
        if(entreprise.Postes.Count == 0){
            Console.WriteLine("Non existence de poste, Veuillez en creer dans la session admin avant de vous diriger vers la creation d'employe");
            return;
        }
        Console.Write("Quel Nombre d'employés voulez vous ? \n>");
            int EmployeeNumber = 0;
            List<Salaire>Employees = new List<Salaire>();

            while (Fonction.TestOnNumber(Console.ReadLine(), ref EmployeeNumber)) ;

            
            string msg  = $"\"*******************Creation de {EmployeeNumber} Employé(s)*******************";
            Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
            Console.WriteLine(msg);
            for (int i = 0; i < EmployeeNumber; i++)
            {
                string nom, sexe, date;
                int poste, ValidYear = 0;
                Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
                Console.WriteLine(msg=$"*********Salaire N° {i + 1}*********");

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


                entreprise.Salaires.Add(new Salaire(nom, sexe, DateTime.Parse(date).Year, entreprise.GetPoste(poste-1)));
            }
    }
    
    private static void PrintAllPoste(Entreprise entreprise){
        int count = 0;
        foreach (var item in entreprise.Postes)
        {
           Console.Write($"{count+1} - {item.NomPoste}");
        }
        Console.Write("\n> ");
    }
    private static void PrintSalairesInformations(Entreprise entreprise){
        Console.WriteLine("Matricule|Nom                      |sexe|Annee|Poste                      |Salaire                      ");
        foreach (var item in entreprise.Salaires)
        {
            Console.WriteLine($"{item.Matricule}|{item.NomEmploye}                      |{item.SexeEmploye}|{item.AnneRecrutement}|{item.PosteEmploye}                      |{item.SalaireEmploye}                     "); 
        }
    }
    public static void Action(Entreprise entreprise){
        string choix, msg = "MENU-User";
        Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth-msg.Length)/2, Console.CursorTop);
                Console.WriteLine(msg);
        
        do
        {
            Console.Write("1 - Ajouter Employe\n2 - Afficher information Employe\n0-quitter\n> ");
            int t = 0;
                t = int.Parse(Console.ReadLine());
                while(t>4 || t<0){
                    Console.WriteLine($"{t} est non valide, entrez à nouveau un nombre compris entre 0 et 4 : \n> ");
                    t = int.Parse(Console.ReadLine());
                }
            switch (t)
            {   
                case 1: 
                    CreerEmployes(entreprise);
                    break;
                case 2:
                    PrintSalairesInformations(entreprise);
                    break;
                default:
                    Console.WriteLine("Fin Session Utilisateur");
                    break;
            }
                Console.WriteLine("Tapez q pour quitter  la session Admin...");
                choix = Console.ReadLine();
        } while (choix.ToLower() != "q");
    }
}
}