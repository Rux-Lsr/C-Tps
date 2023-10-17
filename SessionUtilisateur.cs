using FonctionsApp;
using EnterpriseApp;
namespace UserSessionApp
{
    interface SessionUtilisateur
{
    
    public static void CreerEmployes(Entreprise entreprise)
    {
        if(entreprise.Postes.Count == 0){
            Console.WriteLine("Non existence de poste, Veuillez en creer dans la session admin avant de vous diriger vers la creation d'employe");
            return;
        }
        Console.Write("Quel Nombre d'employés voulez vous ? \n>");
            int EmployeeNumber = 0;
            while (Fonction.TestOnNumber(Console.ReadLine(), ref EmployeeNumber)) ;
            List<Salaire>Employees = new List<Salaire>();

            Console.WriteLine($"\"*******************Creation de {EmployeeNumber} Employé(s) Date de creation entreprise = {entreprise.DateCreation}*******************");
            for (int i = 0; i < EmployeeNumber; i++)
            {
                string nom, sexe, date;
                int poste, ValidYear = 0;
                Console.WriteLine($"*********Salaire N° {i + 1}*********");

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
    public static void PrintSalairesInformations(Entreprise entreprise){
        Console.WriteLine("Matricule|Nom                      |sexe|Annee|Poste                      |Salaire                      ");
        foreach (var item in entreprise.Salaires)
        {
            Console.WriteLine($"{item.Matricule}|{item.NomEmploye}                      |{item.SexeEmploye}|{item.AnneRecrutement}|{item.PosteEmploye}                      |{item.SalaireEmploye}                     "); 
        }
    }
}
}